using Service.Abstraction.Organization;
using Service.ViewModels.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Organization
{
    public class OrgStructureService : IOrgStructureService
    {
        public OrgStructureService() { }

        public async Task<OrgStructureViewModel> GetOrgStructureList(OrgStructureViewModel _vm)
        {
            _vm._reportListData = new List<OrgStructureViewModel>();
            _vm._reportListData.AddRange(
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 0, Code = "1", Name = "CompanyName", Description="PT. Company Name" },

                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "CEO", Description= "Chief Executive Officer" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "C0O", Description= "Chief Operating Officer" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "CFO", Description= "Chief Financial Officer" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "CTO", Description= "Chief Technology Officer" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "CMO", Description= "Chief Marketing Officer" },

                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 2, Code = "Manager", Name = "Manager A" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 2, Code = "Manager", Name = "Manager B" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 2, Code = "Manager", Name = "Manager C" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 2, Code = "Manager", Name = "Manager D" },

                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 3, Code = "Supervisor", Name = "Supervisor A" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 3, Code = "Supervisor", Name = "Supervisor B" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 3, Code = "Supervisor", Name = "Supervisor C" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 3, Code = "Supervisor", Name = "Supervisor D" },

                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff A" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff B" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff C" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff D" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff F" }
                );
            return _vm;
        }
    }
}
