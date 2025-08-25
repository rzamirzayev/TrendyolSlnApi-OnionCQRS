
using Microsoft.Extensions.DependencyInjection;
using TrendyolSln.Application.Interfaces.AutoMapper;

namespace TrendyolSln.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
