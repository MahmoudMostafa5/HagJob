using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DB
{
    public class Department
    { 
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string Department_Name { get; set; }
        public virtual ICollection<jobs> Jobs { get; set; }
    }
}
