using Common.Abstract.Entity;
using IdentityDomain.Abstract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDomain.Models.Users
{
    public class AccountGroup : IAccountGroup, IBaseEntity, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<AccountGroupRole> ApplicationRole { get; set; }
        public virtual ICollection<AccountUserGroup> ApplicationUser { get; set; }
    }
}
