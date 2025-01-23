using Common.Abstract.SqlFactory;
using Common.Common.AlertMessage;
using Common.Common.SqlFactory;
using IdentityProvider.Constant;
using Service.Abstraction.Account;
using Service.Abstraction.TokenHandler;
using SqlKata.Execution;
using System.Transactions;

namespace Service.Service.Account
{
    public class AccountService : IAccountService
    {
        #region [Fields]
        private readonly ISqlObjectFactory _sqlObjectFactory;
        private readonly IJWTTokenHandler _jWTTokenHandler;
        #endregion [Fields]
        #region [Ctor]
        public AccountService(
            ISqlObjectFactory sqlObjectFactory,
            IJWTTokenHandler jWTTokenHandler)
        {
            _sqlObjectFactory = sqlObjectFactory;
            _jWTTokenHandler = jWTTokenHandler;
        }
        #endregion [Ctor]

        #region [Method]
        public TransactionResult Login(string _username, string _password, bool _isRemember)
        {
            if (string.IsNullOrEmpty(_username)) return TransactionResult.Failed(new ErrorMessage { Code = "500", Description = "Error : Empty Username" });
            if (string.IsNullOrEmpty(_password)) return TransactionResult.Failed(new ErrorMessage { Code = "500", Description = "Error : Empty Password" });
            var _getPassword = 
            
            var _isExist = _sqlObjectFactory.GetConnection().DatabaseQueryFactory()
                .Query(PropertyTableUsers.UsersTable)
                .Where(PropertyTableUsers.UsersTable+".Username", _username)
                .Where(PropertyTableUsers.UsersTable+".Password", _password)
                .Exists();

            return TransactionResult.Success;
        }

        #endregion [Method]
    }
}
