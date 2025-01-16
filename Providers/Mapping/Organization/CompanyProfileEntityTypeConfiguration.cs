using Domain.Models.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Providers.Constant;

namespace Providers.Mapping.Organization
{
    internal class CompanyProfileEntityTypeConfiuration : IEntityTypeConfiguration<CompanyProfile>
    {
        public void Configure(EntityTypeBuilder<CompanyProfile> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(ConstantOrganization.CompanyProfileTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.Code);
            _builder.Property(p => p.Name);
            _builder.Property(p => p.Address);
            _builder.Property(p => p.UpdateAt);
            _builder.Property(p => p.CreatedAt);
            _builder.Property(p => p.CreatedDate);
            _builder.Property(p => p.Logo);
            _builder.Property(p => p.Phone);
            _builder.Property(p => p.UpdateDate);
            _builder.Property(p => p.Zip);
        }
    }
}
