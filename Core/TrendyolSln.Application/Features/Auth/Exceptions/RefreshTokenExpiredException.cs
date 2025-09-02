using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Application.Bases;

namespace TrendyolSln.Application.Features.Auth.Exceptions
{
    public class RefreshTokenExpiredException: BaseException
    {
        public RefreshTokenExpiredException() : base("Refresh token expired")
        {
        }
    }

}
