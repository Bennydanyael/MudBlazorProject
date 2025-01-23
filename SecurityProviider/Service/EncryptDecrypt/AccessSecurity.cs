using SecurityProvider.Abstract.EncryptDecrypt;
using SecurityProvider.Abstract.GeneratorEngine;
using SecurityProvider.EnumEncryption;

namespace SecurityProvider.Service.EncryptDecrypt
{
    public class AccessSecurity : IAccessSecurity
    {
        #region [Fields]
        private readonly IRSAGeneratorEngine _rsaGeneratorEngine;
        #endregion [Fields]

        #region [Ctor]
        public AccessSecurity(IRSAGeneratorEngine rsaGeneratorEngine)
        {
            _rsaGeneratorEngine = rsaGeneratorEngine;
        }
        #endregion [Ctor]

        #region [Method]
        public string Encryption(string _plaintext)
        {
            return "";
        }
        public string Decryption(string _chipertext)
        {
            return "";
        }
        public string DecryptionWithState(EnumSymmetric _algo, string _password)
        {
            try
            {
                switch (_algo)
                {
                    case EnumSymmetric.AES192:

                        break;
                    case EnumSymmetric.AES26:

                        break;
                    case EnumSymmetric.RSA:

                        break;
                }
            }catch(Exception _ex)
            {

            }
            return "";
        }
        #endregion [Method]
    }
}
