﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrendyolSln.Application.Interfaces.Tokens;
using TrendyolSln.İnfrastructure.Tokens;

namespace TrendyolSln.İnfrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
            services.AddTransient<ITokenService, TokenService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:secret"])),
                    ValidIssuer = configuration["JWT:issuer"],
                    ValidAudience = configuration["JWT:audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
