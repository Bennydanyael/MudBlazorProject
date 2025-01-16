using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Constant
{
    public static class ConstantClaims
    {
        public static string PrefixeM = "TCM";
        public static string PrefixeD = "TCD";

        private static string Reimbursement = "Reimbursement";

        public static string ReimbursementTable = PrefixeM + Reimbursement;
    }
}
