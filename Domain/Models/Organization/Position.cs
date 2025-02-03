using Common.Abstract.Entity;
using Domain.Abstract.Organization;
using Domain.Models.Personal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Organization
{
    public class Position : IPosition, IBaseEntity, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
        public string Responsibilities { get; set; }
        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }

        public Guid? CompanyId { get; set; }
        public Guid? DepartmentId { get; set; }

        public virtual ICollection<CompanyProfile> Company { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
