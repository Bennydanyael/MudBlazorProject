using Common.Abstract.Entity;
using IdentityDomain.Abstract.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDomain.Models.Users
{
    public class AccountGroupRole : IAccountGroupRole, IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid RoleId { get; set; }
        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
