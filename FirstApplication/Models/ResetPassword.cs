using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class ResetPassword
    {
        public string Email { get; set; }
        [Required (ErrorMessage ="Please enter Yor New Password")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Please enter Yor New Password")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

    }
}
