using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract.Organization
{
    public interface ICompanyPolicy
    {
        string PolicyNo { get; set; }
        string About { get; set; }
        DateTime EffectiveDate { get; set; }
        bool Display { get; set; }
        bool TrackAcceptance { get; set; }
    }
}
