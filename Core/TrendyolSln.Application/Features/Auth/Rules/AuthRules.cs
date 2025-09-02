using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Application.Bases;
using TrendyolSln.Application.Features.Auth.Exceptions;
using TrendyolSln.Domain.Entities;

namespace TrendyolSln.Application.Features.Auth.Rules
{
    public class AuthRules:BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user != null) throw new UserAlreadyExistException(); 
            return Task.CompletedTask;
        }
        public Task EmailOrPasswordShouldNotBeInvalid(User? user,bool checkPassword)
        {
            if (user == null || !checkPassword) throw new EmailOrPasswordInvalidException();
            return Task.CompletedTask;
        }

        public Task RefreshTokenShotuldNotBeExpired(DateTime? expiryDate)
        {
            if(expiryDate<DateTime.UtcNow) throw new RefreshTokenExpiredException();
            return Task.CompletedTask;
        }

    }
}
