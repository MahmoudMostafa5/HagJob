using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DB
{
    public class UserInformation
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        public string UserId { get; set; }
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="Please Enter Your First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Your Phone")]
        [Required(ErrorMessage = "Please Enter Your Phone")]
        public string Phone { get; set; }
        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Please Enter Your Job Title")]
        public string JobTitle { get; set; }
        [Display(Name = "Photo")]
        [Required(ErrorMessage = "Please Upload Your Photo")]
        public string Photo { get; set; }
        [Display(Name = "Resume / CV")]
        [Required(ErrorMessage = "Please Upload Your Resume/CV")]
        public string CV { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
