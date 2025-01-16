using Common.Abstract.Entity;
using Domain.Abstract.Claims;
using Domain.Models.Personal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Claims
{
    public class Reimbursement : IReimbursement, IBaseEntity
    {
        public Guid Id { get; set; }
        public string RequestNo { get; set; }
        public int ApprovalStatus { get; set; }
        public DateTime ApprovalDate { get; set; }
        public decimal ApprovalCost { get; set; }
        public decimal Payment { get; set; }
        public string Currency { get; set; }

        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
