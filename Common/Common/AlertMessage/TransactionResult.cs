using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common.AlertMessage
{
    public class TransactionResult
    {
        private static readonly TransactionResult _success = new TransactionResult { Succeeded = true };
        public bool Succeeded { get; protected set; }
        private List<ErrorMessage> _errors = new List<ErrorMessage>();
        public IEnumerable<ErrorMessage> Errors => _errors;
        public static TransactionResult Success => _success;
        public static TransactionResult Failed(params ErrorMessage[] errors)
        {
            var result = new TransactionResult { Succeeded = false };
            if (errors != null) result._errors.AddRange(errors);
            return result;
        }
        public override string ToString()
        {
            return Succeeded ? "Succeeded" :
                   string.Format("{0} : {1}", "Failed", string.Join(",", Errors.Select(x => x.Code).ToList()));
        }
    }
}
