using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityProvider.EnumEncryption
{
    public enum EnumSymmetric
    {
        [Display(Name ="192")]
        AES192 = 1,
        [Display(Name = "256")]
        AES256 = 2,
        RSA = 3,
    }
}
