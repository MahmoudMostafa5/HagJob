using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class ForgetPassword
    {
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        [Required(ErrorMessage ="This can't Be Invalid")]
        public string Email { get; set; }
    }
}
