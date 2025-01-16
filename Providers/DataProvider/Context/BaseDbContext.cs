using Domain.Models.Claims;
using Domain.Models.Organization;
using Domain.Models.Personal;
using Microsoft.EntityFrameworkCore;
using Providers.Abstraction.Context;
using Providers.Mapping.Claims;
using Providers.Mapping.Organization;
using Providers.Mapping.Personal;

namespace Providers.DataProvider.Context
{
    public class BaseDbContext : DbContext, IBaseDbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> _options) : base(_options) { }

        //Organization
        public DbSet<Announcement> Announcement => Set<Announcement>();
        public DbSet<CompanyProfile> CompanyProfile => Set<CompanyProfile>();
        public DbSet<CompanyPolicy> CompanyPolicy => Set<CompanyPolicy>();
        
        //Claims
        public DbSet<Reimbursement> Reimbursement => Set<Reimbursement>();

        //Personal
        public DbSet<Employee> Employee => Set<Employee>();

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
            //Organization
            modelBuilder.ApplyConfiguration(new AnnouncementEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyProfileEntityTypeConfiuration());
            modelBuilder.ApplyConfiguration(new CompanyPolicyEntityTypeConfiguration());
            
            //Claims
            modelBuilder.ApplyConfiguration(new ReimbursementEntityTypeConfiguration());
            
            //Employee
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
