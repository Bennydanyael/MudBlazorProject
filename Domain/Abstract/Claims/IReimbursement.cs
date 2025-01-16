using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract.Claims
{
    public interface IReimbursement
    {
        int ApprovalStatus { get; set; }
        DateTime ApprovalDate { get; set; }
        decimal ApprovalCost { get; set; }
        decimal Payment { get; set; }
        string Currency { get; set; }
        string RequestNo { get; set; }
    }
}
