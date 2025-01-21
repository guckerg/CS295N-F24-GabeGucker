using Microsoft.AspNetCore.Identity;
using System;

namespace GGinfoSite.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime SignupDate { get; set; }
    }
}
