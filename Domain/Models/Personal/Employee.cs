using Common.Abstract.Entity;
using Domain.Abstract.Personal;
using Domain.Models.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Personal
{
    public class Employee : IEmployee, IBaseEntity
    {
        public Guid Id { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime TerminateDate { get; set; }

        public string? CreatedAt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateAt { get; set; }
        public DateTime? UpdateDate { get; set; }

        public ICollection<Reimbursement> Reimbursement { get; set; }
    }
}
