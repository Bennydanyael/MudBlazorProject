using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract.Organization
{
    public interface IPosition
    {
        string Code { get; set; }
        string Name { get; set; }
        string JobDescription { get; set; }
        string Responsibilities { get; set; }
    }
}
