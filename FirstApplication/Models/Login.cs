using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class Login
    {

        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This filed is requried")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public bool RemmemberMe { get; set; }
    }
}
