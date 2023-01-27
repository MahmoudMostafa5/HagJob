using FirstApplication.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class DepartmentVM
    {
        public int DepartmentId { get; set; }
        [Required]
        public string Department_Name { get; set; }

    }
}
