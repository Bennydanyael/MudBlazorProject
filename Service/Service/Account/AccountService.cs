using Common.Abstract.SqlFactory;
using Common.Common.AlertMessage;
using Common.Common.SqlFactory;
using IdentityProvider.Constant;
using Microsoft.Extensions.Configuration;
using SecurityProvider.Abstract.EncryptDecrypt;
using SecurityProvider.EnumEncryption;
using Service.Abstraction.Account;
using Service.Abstraction.TokenHandler;
using Service.ViewModels.Account;
using SqlKata.Execution;
using System;
using System.Transactions;

namespace Service.Service.Account
{
    public class AccountService : IAccountService
    {
        #region [Fields]
        private readonly ISqlObjectFactory _sqlObjectFactory;
        private readonly IJWTTokenHandler _jWTTokenHandler;
        private readonly IAccessSecurity _accessSecurity;
        private readonly IConfiguration _configuration;
        #endregion [Fields]
        #region [Ctor]
        public AccountService(
            IAccessSecurity accessSecurity,
            ISqlObjectFactory sqlObjectFactory,
            IConfiguration configuration,
            IJWTTokenHandler jWTTokenHandler)
        {
            _configuration = configuration;
            _accessSecurity = accessSecurity;
            _sqlObjectFactory = sqlObjectFactory;
            _jWTTokenHandler = jWTTokenHandler;
        }
        #endregion [Ctor]
        #region [Method]
        public async Task<TransactionResult> Login(string _username, string _password, bool _isRemember)
        {
            try
            {
                if (string.IsNullOrEmpty(_username)) return TransactionResult.Failed(new ErrorMessage { Code = "500", Description = "Error : Empty Username" });
                if (string.IsNullOrEmpty(_password)) return TransactionResult.Failed(new ErrorMessage { Code = "500", Description = "Error : Empty Password" });

                var _isExist = await _sqlObjectFactory.GetConnection().DatabaseQueryFactory()
                    .Query(PropertyTableUsers.UsersTable)
                    .Where(PropertyTableUsers.UsersTable + ".Username", _username)
                    //.Where(PropertyTableUsers.UsersTable+".Password", _getPassword)
                    .FirstOrDefaultAsync<UserAccountViewModel>();
                var _getPassword = _accessSecurity.DecryptionWithState(EnumSymmetric.AES192, _password);
                if (!string.Equals(_password, _getPassword, StringComparison.CurrentCultureIgnoreCase))
                    return TransactionResult.Failed(new ErrorMessage { Code = "", Description = "Login Failed" });
            } catch (Exception _ex)
            {
                return TransactionResult.Failed(new ErrorMessage { Code = "", Description = "Error : " + _ex.Message });
            }
            return TransactionResult.Success;
        }

        public async Task<TransactionResult> SingUp(UserAccountViewModel _vm)
        {
            try
            {
                var _encryptionPassword = string.Empty;
                var _encryption = _configuration["SecurityEncryption:Encryption"];
                if (EnumSymmetric.AES192.ToString() == _encryption.ToString())
                    _encryptionPassword = _accessSecurity.Encryption(EnumSymmetric.AES192, _vm.Password);
                else if (EnumSymmetric.AES256.ToString() == _encryption.ToString())
                    _encryptionPassword = _accessSecurity.Encryption(EnumSymmetric.AES256, _vm.Password);
                else if (EnumSymmetric.RSA.ToString() == _encryption.ToString())
                    _encryptionPassword = _accessSecurity.Encryption(EnumSymmetric.RSA, _vm.Password);

                if (!IsExistUsername(_vm.Username))
                {
                    var _insertUser = await _sqlObjectFactory.GetConnection().DatabaseQueryFactory()
                        .Query(PropertyTableUsers.UsersTable)
                        .InsertAsync(new
                        {
                            Username = _vm.Username,
                            Password = _encryptionPassword,
                            Email = _vm.Email,
                        });
                }
                else return TransactionResult.Failed(new ErrorMessage { Code = "500", Description = "Error : User is Exist." });
            }catch(Exception _ex)
            {
                return TransactionResult.Failed(new ErrorMessage { Code = "500", Description = "Error : "+ _ex.Message });
            }
            return TransactionResult.Success;
        }

        public bool IsExistUsername(string _username) =>
            _sqlObjectFactory.GetConnection().DatabaseQueryFactory()
                    .Query(PropertyTableUsers.UsersTable)
                    .Where(PropertyTableUsers.UsersTable + ".Username", _username)
                    .Exists();
        #endregion [Method]
    }
}
