using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolSln.Application.Features.Auth.Command.Login
{
    public class LoginCommandResponse
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
