using SecurityProvider.Abstract.GeneratorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProvider.Service.SecurityEngine
{
    public class AESGeneratorEngine : IAESGeneratorEngine
    {
        #region [Fields]
        #endregion [Fields]
        #region [Ctor]
        #endregion [Ctor]
        #region [Method]
        public string Encrypt(string _plaintext, int _keySize)
        {
            byte[] _key;
            byte[] _iv;
            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.KeySize = _keySize;
                _key = aesAlgorithm.Key;
                _iv = aesAlgorithm.IV;
                // Create encryptor object
                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor(_key, _iv);
                byte[] encryptedData;
                //Encryption will be done in a memory stream through a CryptoStream object
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(_plaintext);
                        }
                        encryptedData = ms.ToArray();
                    }
                }
                return Convert.ToBase64String(encryptedData);
            }
        }

        public string Decrypt(string _cipherText, int _keySize)
        {
            byte[] _key;
            byte[] _iv;

            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.KeySize = _keySize;
                _key = aesAlgorithm.Key;
                _iv = aesAlgorithm.IV;

                // Create decryptor object
                ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(_key, _iv);
                byte[] cipher = Convert.FromBase64String(_cipherText);

                //Decryption will be done in a memory stream through a CryptoStream object
                using (MemoryStream ms = new MemoryStream(cipher))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
        #endregion [Method]
    }
}
