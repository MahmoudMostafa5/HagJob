using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class ApplyJobVm
    {
        [Required(ErrorMessage ="Please enter the id of job")]
        [Display(Name = "Job Id")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter user Id")]
        [Display(Name ="User Id")]
        public string UserId { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Question4 { get; set; }
        public string Question5 { get; set; }

    }
}
