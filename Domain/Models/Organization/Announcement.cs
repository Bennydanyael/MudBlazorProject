using Common.Abstract.Entity;
using Domain.Abstract.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Organization
{
    public class Announcement : IAnnouncement, IBaseEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastDate { get; set; }

        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
