using Domain.Models.Personal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Constant;
using System.Text;

namespace Providers.Mapping.Personal
{
    internal class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(ConstantOrganization.CompanyProfileTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.Code);
            _builder.Property(p => p.Name);
            _builder.Property(p => p.FirstName);
            _builder.Property(p => p.LastName);
            _builder.Property(p => p.BirthDate);
            _builder.Property(p => p.TerminateDate);
        }
    }
}
