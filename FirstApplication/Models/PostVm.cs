using FirstApplication.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class PostVm
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Mention")]
        public string Mention { get; set; }

        public string UserId { get; set; }

        public int FeelingId { get; set; }
    }
}
