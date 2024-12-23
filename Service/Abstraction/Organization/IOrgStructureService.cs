using Service.ViewModels.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.Organization
{
    public interface IOrgStructureService
    {
        Task<OrgStructureViewModel> GetOrgStructureList(OrgStructureViewModel _vm);
    }
}
