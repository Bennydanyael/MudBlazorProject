using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDomain.Abstract.Users
{
    public interface IAccountGroup
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
