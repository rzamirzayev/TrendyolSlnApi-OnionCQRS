using FluentValidation;
using MediatR;

namespace TrendyolSln.Application.Beheviors
{
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator) 
        {
            this.validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context=new ValidationContext<TRequest>(request);
            var failtures= validator
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .GroupBy(x=>x.ErrorMessage)
                .Select(x => x.First())
                .Where(x => x != null)
                .ToList();

            if (failtures.Any())  throw new ValidationException(failtures);
           
            return next();

        }
    }
}
