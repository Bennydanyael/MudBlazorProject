using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Organization
{
    public class OrgStructureViewModel
    {
        public Guid Id { get; set; }
        public int LevelId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string Responsibilities { get; set; }

        public List<OrgStructureViewModel> _reportListData { get; set; }
    }
}
