using FirstApplication.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class FeelingVm
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Your Felling")]
        public string YourFeeling { get; set; }
        [ForeignKey("Post")]
        //public int PostId { get; set; }
        public virtual ICollection<Post> post { get; set; }
    }
}
