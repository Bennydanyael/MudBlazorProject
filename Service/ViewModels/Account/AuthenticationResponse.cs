using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Account
{
    public record AuthenticationResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }
        public int ExpirenIn { get; set; }
    }
}
