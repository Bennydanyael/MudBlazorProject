using SecurityProvider.Abstract.EncryptDecrypt;
using SecurityProvider.Abstract.GeneratorEngine;
using SecurityProvider.EnumEncryption;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Cryptography;
using Common.Common.Enums;

namespace SecurityProvider.Service.EncryptDecrypt
{
    public class AccessSecurity : IAccessSecurity
    {
        #region [Fields]
        private readonly IRSAGeneratorEngine _rsaGeneratorEngine;
        private readonly IAESGeneratorEngine _aesGeneratorEngine;
        #endregion [Fields]
        #region [Ctor]
        public AccessSecurity(IRSAGeneratorEngine rsaGeneratorEngine, IAESGeneratorEngine aesGeneratorEngine)
        {
            _rsaGeneratorEngine = rsaGeneratorEngine;
            _aesGeneratorEngine = aesGeneratorEngine;
        }
        #endregion [Ctor]
        #region [Method]
        public string Encryption(EnumSymmetric _algo, string _plaintext)
        {
            RSAParameters _key = new RSAParameters();
            string _result = string.Empty;
            var _keySize = DisplayName.GetDisplayName(_algo);
            try
            {
                switch (_algo)
                {
                    case EnumSymmetric.AES192:
                        return _aesGeneratorEngine.Encrypt(_plaintext, Convert.ToInt32(_keySize));
                        break;
                    case EnumSymmetric.AES256:
                        return _aesGeneratorEngine.Encrypt(_plaintext, Convert.ToInt32(_keySize));
                        break;
                    case EnumSymmetric.RSA:
                        return _rsaGeneratorEngine.EncryptionString(_plaintext, _key, true);
                        break;
                }
            }
            catch (Exception _ex)
            {
                return _ex.Message;
            }
            return string.Empty;
        }
        public string Decryption(string _chipertext)
        {
            return "";
        }
        public string DecryptionWithState(EnumSymmetric _algo, string _chipertext)
        {
            RSAParameters _key = new RSAParameters();
            string _result = string.Empty;
            var _keySize = DisplayName.GetDisplayName(_algo);
            try
            {
                switch (_algo)
                {
                    case EnumSymmetric.AES192:
                        return _aesGeneratorEngine.Decrypt(_chipertext, Convert.ToInt32(_keySize));
                        break;
                    case EnumSymmetric.AES256:
                        return _aesGeneratorEngine.Decrypt(_chipertext, Convert.ToInt32(_keySize));
                        break;
                    case EnumSymmetric.RSA:
                        return _rsaGeneratorEngine.DecryptionString(_chipertext, _key, true);
                        break;
                }
            }catch(Exception _ex)
            {
                return _ex.Message;
            }
            return "";
        }
        #endregion [Method]
    }
}
