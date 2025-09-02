using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolSln.Application.Bases;

namespace TrendyolSln.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordInvalidException:BaseException
    {
        public EmailOrPasswordInvalidException() : base("Email or password invalid")
        {
        }
    }
}
