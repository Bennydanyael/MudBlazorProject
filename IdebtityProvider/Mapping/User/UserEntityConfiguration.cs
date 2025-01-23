using IdentityProvider.Constant;
using IdentityDomain.Models.Users;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityProvider.Mapping.User
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<AccountUser>
    {
        public void Configure(EntityTypeBuilder<AccountUser> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(PropertyTableUsers.UsersTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.IsDeleted);

            _builder.Property(p => p.CreatedAt).IsRequired();
            _builder.Property(p => p.CreatedDate).IsRequired();
            _builder.Property(p => p.CreatedAt);
            _builder.Property(p => p.CreatedDate);
        }
    }

    internal class EntityConfigurationRole : IEntityTypeConfiguration<AccountRole>
    {
        public void Configure(EntityTypeBuilder<AccountRole> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(PropertyTableUsers.RolesTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.Name).IsRequired();
            _builder.Property(p => p.Description);

            _builder.Property(p => p.IsDeleted);

            _builder.Property(p => p.CreatedAt).IsRequired();
            _builder.Property(p => p.CreatedAt).IsRequired();
            _builder.Property(p => p.UpdateAt);
            _builder.Property(p => p.UpdateDate);
        }
    }

    internal class EntityConfigurationGroup : IEntityTypeConfiguration<AccountGroup>
    {
        public void Configure(EntityTypeBuilder<AccountGroup> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(PropertyTableUsers.GroupsTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.Name).IsRequired();
            _builder.Property(p => p.Description);

            _builder.Property(p => p.IsDeleted);

            _builder.Property(p => p.CreatedAt).IsRequired();
            _builder.Property(p => p.CreatedAt).IsRequired();
            _builder.Property(p => p.UpdateAt);
            _builder.Property(p => p.UpdateDate);
        }
    }

    internal class EntityConfigurationUserGroup : IEntityTypeConfiguration<AccountUserGroup>
    {
        public void Configure(EntityTypeBuilder<AccountUserGroup> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(PropertyTableUsers.GroupsTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.GroupId);
            _builder.Property(p => p.UserId).IsRequired();

            _builder.Property(p => p.IsDeleted);

            _builder.Property(p => p.CreatedAt).IsRequired();
            _builder.Property(p => p.CreatedDate).IsRequired();
            _builder.Property(p => p.UpdateAt);
            _builder.Property(p => p.UpdateDate);
        }
    }

    internal class EntityConfigurationGroupRole : IEntityTypeConfiguration<AccountGroupRole>
    {
        public void Configure(EntityTypeBuilder<AccountGroupRole> _builder)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append(PropertyTableUsers.GroupsTable);

            _builder.ToTable(_sb.ToString());
            _builder.HasKey(p => p.Id);
            _builder.Property(p => p.GroupId);
            _builder.Property(p => p.RoleId).IsRequired();

            _builder.Property(p => p.CreatedAt).IsRequired();
            _builder.Property(p => p.CreatedDate).IsRequired();
            _builder.Property(p => p.UpdateAt);
            _builder.Property(p => p.UpdateDate);
        }
    }
}

