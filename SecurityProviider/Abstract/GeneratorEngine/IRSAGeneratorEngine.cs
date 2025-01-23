using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProvider.Abstract.GeneratorEngine
{
    public interface IRSAGeneratorEngine
    {
        byte[] Encryption(byte[] _plaintext, RSAParameters _key, bool _isPadding);
        byte[] Decryption(byte[] _encrypted, RSAParameters _key, bool _isPadding);
    }
}
