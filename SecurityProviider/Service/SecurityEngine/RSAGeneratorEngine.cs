using SecurityProvider.Abstract.GeneratorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProvider.Service.SecurityEngine
{
    public class RSAGeneratorEngine : IRSAGeneratorEngine
    {
        private string _privateKey = "zxcvbnmmasdfghjklqwertyuiop";
        public byte[] Encryption(byte[] _plaintext, RSAParameters _key, bool _isPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(_key);
                    encryptedData = RSA.Encrypt(_plaintext, _isPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public byte[] Decryption(byte[] _encrypted, RSAParameters _key, bool _isPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(_key);
                    decryptedData = RSA.Decrypt(_encrypted, _isPadding);
                    var _stringEncrypted = Encoding.UTF8.GetString(decryptedData);
                    var _decrypted = _stringEncrypted.Split("+")[1].ToString();
                    decryptedData = Encoding.UTF8.GetBytes(_decrypted);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public string EncryptionString(string _plaintext, RSAParameters _key, bool _isPadding)
        {
            try
            {
                string _encrypted;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(_key);
                    var _combineKey = _privateKey + "+" + _plaintext;
                    byte[] _bytePlaintext = Encoding.UTF8.GetBytes(_combineKey);
                    var _encryptedData = RSA.Encrypt(_bytePlaintext, _isPadding);
                    _encrypted = Encoding.UTF8.GetString(_encryptedData);
                }
                return _encrypted;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string DecryptionString(string _encrypted, RSAParameters _key, bool _isPadding)
        {
            try
            {
                var _decrypted = string.Empty;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(_key);
                    var _byteEncrypted = Convert.FromBase64String(_encrypted); ;
                    var _decryptedData = RSA.Decrypt(_byteEncrypted, _isPadding);
                    var _stringEncrypted = Encoding.UTF8.GetString(_decryptedData);
                    _decrypted = _stringEncrypted.Split("+")[1].ToString();
                }
                return _decrypted;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
