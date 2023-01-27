using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DB
{
    public class Feeling
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Your Felling")]
        public string YourFeeling { get; set; }
        //[foreignkey("post")]
        //public int PostId { get; set; }
        public virtual ICollection<Post> post { get; set; }
    }
}
