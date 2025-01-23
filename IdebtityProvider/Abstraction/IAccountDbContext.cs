using IdentityDomain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.Abstraction
{
    public interface IAccountDbContext : IDisposable
    {
        DbSet<AccountUser> AccountUser { get; }
        DbSet<AccountGroup> AccountGroup { get; }
        DbSet<AccountRole> AccountRole { get; }
        DbSet<AccountGroupRole> AccountGroupRole { get; }
        DbSet<AccountUserGroup> AccountUserGroup { get; }
    }
}
