using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProvider.Abstract.GeneratorEngine
{
    public interface IAESGeneratorEngine
    {
        string Encrypt(string _plaintext, int _keySize);
        string Decrypt(string _cipherText, int _keySize);
    }
}
