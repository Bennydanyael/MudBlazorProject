using Service.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.TokenHandler
{
    public interface IJWTTokenHandler
    {
        AuthenticationResponse? GenerateToken(AuthenticationRequest _request);
    }
}
