using Domain.Models.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Constant;
using System.Text;

namespace Providers.Mapping.Claims
{
    internal class ReimbursementEntityTypeConfiguration : IEntityTypeConfiguration<Reimbursement>
    {
        public void Configure(EntityTypeBuilder<Reimbursement> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(ConstantClaims.ReimbursementTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.ApprovalStatus);
            _builder.Property(p => p.RequestNo);
            _builder.Property(p => p.ApprovalCost);
            _builder.Property(p => p.ApprovalDate);
            _builder.Property(p => p.Currency);
            _builder.Property(p => p.Payment);

            _builder.Property(p => p.CreatedAt);
            _builder.Property(p => p.CreatedDate);
            _builder.Property(p => p.UpdateAt);
            _builder.Property(p => p.UpdateDate);

            _builder.HasOne(p => p.Employee)
                .WithMany(p => p.Reimbursement)
                .HasForeignKey(p => p.EmployeeId);
        }
    }
}
