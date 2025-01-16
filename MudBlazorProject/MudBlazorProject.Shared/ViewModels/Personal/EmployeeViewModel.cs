using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorProject.Shared.ViewModels.Personal
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(string name, string role, string imgUrl = null)
        {
            Name = name;
            Role = role;
            ImgUrl = imgUrl;
            Children = new List<EmployeeViewModel>();
        }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Position { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public List<EmployeeViewModel> Children { get; set; }
    }
}
