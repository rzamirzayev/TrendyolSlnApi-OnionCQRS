using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Application.Bases;
using TrendyolSln.Application.Features.Auth.Rules;
using TrendyolSln.Application.Interfaces.AutoMapper;
using TrendyolSln.Application.Interfaces.Tokens;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : BaseHandler,IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;

        public RefreshTokenCommandHandler(UserManager<User> userManager,AuthRules authRules,ITokenService tokenService,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.authRules = authRules;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal=tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user=await userManager.FindByEmailAsync(email);
            IList<string> roles=await userManager.GetRolesAsync(user);

            await authRules.RefreshTokenShotuldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccessToken=await tokenService.CreateToken(user, roles);
            string newRefreshToken=tokenService.GenerateRefreshToken();

            user.RefreshToken= newRefreshToken;
            string _token = new JwtSecurityTokenHandler().WriteToken(newAccessToken);
            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            await userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };

        }
    }
}
