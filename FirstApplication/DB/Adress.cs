using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DB
{
    public class Adresss
    {
        [Key] 
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        [Required(ErrorMessage ="Please Enter Your Country / State")]
        [Display(Name ="Country / State")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter Your City")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Your Street")]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Required(ErrorMessage ="Please Enter Your ZipCode For Your City")]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
