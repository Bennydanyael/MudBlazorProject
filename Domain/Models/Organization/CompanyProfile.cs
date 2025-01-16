using Common.Abstract.Entity;
using Domain.Abstract.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Organization
{
    public class CompanyProfile : ICompanyProfile, IBaseEntity
    {
        public Guid Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }

        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<CompanyPolicy> CompanyPolicy { get; set; }
    }
}
