using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class EditeRole
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Please Enter Name of Role")]
        public string RoleName { get; set; }
    }
}
