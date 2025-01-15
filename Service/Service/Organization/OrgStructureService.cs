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
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 0, Code = "1", Name = "CompanyName", Position="PT. Company Name" },

                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "CEO", Position = "Chief Executive Officer" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "C0O", Position = "Chief Operating Officer" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "CFO", Position = "Chief Financial Officer" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "CTO", Position = "Chief Technology Officer" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 1, Code = "Director", Name = "CMO", Position = "Chief Marketing Officer" },

                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 2, Code = "Manager", Name = "Manager A", Position = "Manager A" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 2, Code = "Manager", Name = "Manager B", Position = "Manager B" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 2, Code = "Manager", Name = "Manager C", Position = "Manager C" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 2, Code = "Manager", Name = "Manager D", Position = "Manager D" },

                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 3, Code = "Supervisor", Name = "Supervisor A", Position = "Supervisor A" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 3, Code = "Supervisor", Name = "Supervisor B", Position = "Supervisor B" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 3, Code = "Supervisor", Name = "Supervisor C", Position = "Supervisor C" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 3, Code = "Supervisor", Name = "Supervisor D", Position = "Supervisor D" },

                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff A", Position = "Staff A" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff B", Position = "Staff B" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff C", Position = "Staff C" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff D", Position = "Staff D" },
                new OrgStructureViewModel { Id = Guid.NewGuid(), LevelId = 4, Code = "Staff", Name = "Staff F", Position = "Staff E" }
                );
            return _vm;
        }
    }
}
