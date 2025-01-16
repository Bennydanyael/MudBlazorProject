using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract.Organization
{
    public interface ICompanyProfile
    {
        string Code { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        string Zip { get; set; }
        string Address { get; set; }
        string Logo { get; set; }
    }
}
