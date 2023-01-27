using FirstApplication.DB;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class JobVm
    {
        public JobVm()
        {
            this.Statues = true;
            this.Education = "";
        }
        public int Job_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name of job")]
        [Display(Name = "Job Name ")]
        public string Name { get; set; }
        [Display(Name = "Job Image ")]
        //[Required(ErrorMessage = "Please select a PNG image smaller than 1MB")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Please ENter Requriments of job")]
        [Display(Name = "Job Requriments ")]
        public string Requriments { get; set; }
        [Required(ErrorMessage = "Please enter Skills for this Job")]
        [Display(Name = "Job Skills ")]
        public string Skills { get; set; }
        [Required(ErrorMessage = "Please enter Education for this Job")]
        [Display(Name = "Job Education ")]
        [DefaultValue("")]
        public string Education { get; set; }
        [Required(ErrorMessage = "Please enter Description of job")]
        [Display(Name = "Job Dexcription ")]
        public string JobDescription { get; set; }
        [Required(ErrorMessage = "Please enter Name of Company")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter Location of job")]
        [Display(Name = "Job Location ")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Please ENter Experience of job")]
        [Display(Name = "Job Experience ")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Please Choose Type Of Work Time")]
        [Display(Name = "Type Of Time")]
        public string Time { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        [Display(Name = "Date Time")]
        public DateTime Date { get; set; }
        [Display(Name = "Salary")]
        public string Salary { get; set; }

        [Required(ErrorMessage = "Please Enter Statues")]
        [Display(Name = "Statues")]
        [DefaultValue("true")]
        public bool Statues { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public int DepId { get; set; }
    }
}
