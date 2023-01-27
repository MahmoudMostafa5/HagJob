using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DB
{
    public class ApplicationUser : IdentityUser
    {
        public int UserTypeId { get; set; }
        public virtual UserType userType { get; set; }
        public virtual UserInformation UserInformation { get; set; }
        public virtual Adresss Adresss { get; set; }
        public virtual ICollection<jobs> Jobs { get; set; }
        public virtual ICollection<ApplyJobs> ApplyJobs { get; set; }

        public virtual Post Post { get; set; }
    }
}
