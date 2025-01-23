using IdentityProvider.Abstraction;
using IdentityProvider.Mapping.User;
using IdentityDomain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.Context
{
    public class AccountDbContext : DbContext, IAccountDbContext
    {
        public DbSet<AccountUser> AccountUser => Set<AccountUser>();
        public DbSet<AccountGroup> AccountGroup => Set<AccountGroup>();
        public DbSet<AccountRole> AccountRole => Set<AccountRole>();
        public DbSet<AccountGroupRole> AccountGroupRole => Set<AccountGroupRole>();
        public DbSet<AccountUserGroup> AccountUserGroup => Set<AccountUserGroup>();

        protected void OnConfiguration(DbContextOptionsBuilder _builder)
        {
            base.OnConfiguring(_builder);
            _builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
#if DEBUG
            _builder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
