using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Application.Bases;
using TrendyolSln.Application.Features.Auth.Rules;
using TrendyolSln.Application.Interfaces.AutoMapper;
using TrendyolSln.Application.Interfaces.Tokens;
using TrendyolSln.Application.Interfaces.UnitOfWorks;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler :BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;
        private readonly RoleManager<Role> roleManager;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public LoginCommandHandler(UserManager<User> userManager, AuthRules authRules,IConfiguration configuration,ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await userManager.FindByEmailAsync(request.Email);
            bool checkPasword = await userManager.CheckPasswordAsync(user, request.Password);
            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPasword);

            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken token=await tokenService.CreateToken(user, roles.ToList()); 
            string refreshToken=tokenService.GenerateRefreshToken();

            _=int.TryParse(configuration["JWT:RefreshTokenValidityInDays"],out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime=DateTime.UtcNow.AddDays(refreshTokenValidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token=new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                accessToken = _token,
                refreshToken = refreshToken,
                Expiration = token.ValidTo
            };

        }
    }
}
