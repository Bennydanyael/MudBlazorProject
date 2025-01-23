using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDomain.Abstract.Users
{
   public interface IAccountGroupRole
    {
        Guid GroupId { get; set; }
        Guid RoleId { get; set; }
    }
}
