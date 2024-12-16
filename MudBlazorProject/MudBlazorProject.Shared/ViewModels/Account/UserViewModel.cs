using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorProject.Shared.ViewModels.Account
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
