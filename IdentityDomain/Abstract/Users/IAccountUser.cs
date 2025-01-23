using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDomain.Abstract.Users
{
    public interface IAccountUser
    {
        string? PathPicture { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
    }
}
