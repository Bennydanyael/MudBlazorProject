using Common.Abstract.Entity;
using Domain.Abstract.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Organization
{
    public class CompanyPolicy : ICompanyPolicy, IBaseEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string PolicyNo { get; set; }
        public string About { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool Display { get; set; }
        public bool TrackAcceptance { get; set; }

        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string CompanyId { get; set; }
        public CompanyProfile CompanyProfile { get; set; }
    }
}
