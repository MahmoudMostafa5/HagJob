using FirstApplication.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Models
{
    public class QuestionJobVm
    {
        public int Job_Id { get; set; }
        public virtual jobs jobs { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Question4 { get; set; }
        public string Question5 { get; set; }
    }
}
