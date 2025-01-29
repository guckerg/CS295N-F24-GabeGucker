using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GGinfoSite.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignupDate { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}
