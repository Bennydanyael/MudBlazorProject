using IdentityProvider.Context;
using Providers.DataProvider.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Abstraction.Context
{
    public interface IDbInitializer
    {
        void InitializeSets(BaseDbContext _context, AccountDbContext _accountDbContext);
    }
}
