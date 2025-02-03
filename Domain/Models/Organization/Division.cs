using Common.Abstract.Entity;
using Domain.Abstract.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Organization
{
    public class Division : IDivision, IBaseEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Guid? CompanyId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CompanyProfile> CompanyProfile { get; set; }
    }
}
