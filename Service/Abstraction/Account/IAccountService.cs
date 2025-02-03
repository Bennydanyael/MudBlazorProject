using Common.Common.AlertMessage;
using Service.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.Account
{
    public interface IAccountService
    {
        Task<TransactionResult> Login(string _username, string _password, bool _isRemember);
        Task<TransactionResult> SingUp(UserAccountViewModel _vm);
    }
}
