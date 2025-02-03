using Microsoft.IdentityModel.Tokens;
using Service.Abstraction.TokenHandler;
using Service.ViewModels.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Service.TokenHandler
{
    public class JWTTokenHandler : IJWTTokenHandler
    {
        public const string JWT_SECURITY_KEY = "BaseProjectSuccessfullyTralalaTrilili";
        private const int JWT_TOKEN_VALIDATION_MINS = 20;
        private readonly List<UserAccountViewModel> _userAccountList;
        public JWTTokenHandler()
        {
            _userAccountList = new List<UserAccountViewModel>
            {
                new UserAccountViewModel{ Username = "Admin", Password = "Sabeso76",  },
                new UserAccountViewModel{ Username = "User1", Password = "Sabeso76" }
            };
        }

        public AuthenticationResponse? GenerateToken(AuthenticationRequest _request)
        {
            if (!string.IsNullOrEmpty(_request.Username) && string.IsNullOrWhiteSpace(_request.Password))
                return null;

            var _userAccount = _userAccountList.Where(c => c.Username == _request.Username && c.Password == _request.Password).FirstOrDefault();
            if (_userAccount == null) return null;
            var _expiredToken = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDATION_MINS);
            var _tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var _claimIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, _request.Username),
                new Claim(ClaimTypes.Role, _userAccount.RoleId)
            });

            var _signCredentials = new SigningCredentials(new SymmetricSecurityKey(_tokenKey), SecurityAlgorithms.HmacSha256);
            var _securityTokeDescriptor = new SecurityTokenDescriptor
            {
                Subject = _claimIdentity,
                Expires = _expiredToken,
                SigningCredentials = _signCredentials
            };
            var _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var _securityToken = _jwtSecurityTokenHandler.CreateToken(_securityTokeDescriptor);
            var _token = _jwtSecurityTokenHandler.WriteToken(_securityToken);

            return new AuthenticationResponse
            {
                Username = _userAccount.Username,
                ExpirenIn = (int)_expiredToken.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = _token
            };
        }
    }
}
