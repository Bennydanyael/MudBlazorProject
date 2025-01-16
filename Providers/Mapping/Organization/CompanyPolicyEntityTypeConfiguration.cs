using Domain.Models.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Mapping.Organization
{
    internal class CompanyPolicyEntityTypeConfiguration : IEntityTypeConfiguration<CompanyPolicy>
    {
        public void Configure(EntityTypeBuilder<CompanyPolicy> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(ConstantOrganization.CompanyPolicyTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.Code);
            _builder.Property(p => p.Name);
            _builder.Property(p => p.About);
            _builder.Property(p => p.PolicyNo);
            _builder.Property(p => p.Display);
            _builder.Property(p => p.EffectiveDate);
            _builder.Property(p => p.TrackAcceptance);

            _builder.Property(p => p.CreatedAt);
            _builder.Property(p => p.CreatedDate);
            _builder.Property(p => p.UpdateAt);
            _builder.Property(p => p.UpdateDate);

            _builder.HasOne(p => p.CompanyProfile)
                .WithMany(p => p.CompanyPolicy)
                .HasForeignKey(p => p.CompanyId);

        }
    }
}
