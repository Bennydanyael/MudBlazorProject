using SecurityProvider.EnumEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProvider.Abstract.EncryptDecrypt
{
    public interface IAccessSecurity
    {
        string Encryption(EnumSymmetric _algo, string _plaintext);
        string DecryptionWithState(EnumSymmetric _algo, string _password);
    }
}
