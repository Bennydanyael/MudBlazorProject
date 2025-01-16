using Domain.Models.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Providers.Constant;
using System.Text;

namespace Providers.Mapping.Organization
{
    internal class AnnouncementEntityTypeConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(ConstantOrganization.AnnouncementTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.Code);
            _builder.Property(p => p.Subject);
            _builder.Property(p => p.StartDate);
            _builder.Property(p => p.Type);
            _builder.Property(p => p.EndDate);
            _builder.Property(p => p.LastDate);

            _builder.Property(p => p.CreatedAt);
            _builder.Property(p => p.CreatedDate);
            _builder.Property(p => p.UpdateAt);
            _builder.Property(p => p.UpdateDate);
        }
    }
}
