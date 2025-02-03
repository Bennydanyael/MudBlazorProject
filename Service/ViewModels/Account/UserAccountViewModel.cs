using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels.Account
{
    public class UserAccountViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? GroupId { get; set; }
    }
}
