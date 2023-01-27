using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class RoleVm
    {
        [Required(ErrorMessage = "Plessa Enter The Role Name")]
        public string RoleName { get; set; }
    }
}
