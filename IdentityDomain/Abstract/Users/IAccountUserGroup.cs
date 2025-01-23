using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDomain.Abstract.Users
{
    public interface IAccountUserGroup
    {
        Guid GroupId { get; set; }
        Guid UserId { get; set; }
    }
}
