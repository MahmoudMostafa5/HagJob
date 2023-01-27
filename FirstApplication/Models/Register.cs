using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="This filed is requried")]
        public int UserType { get; set; }
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Compare("PassWord", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}
