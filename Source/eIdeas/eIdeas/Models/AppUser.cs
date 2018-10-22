using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eIdeas.Models
{
    public class AppUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PictureURL { get; set; }
        public string Phonenumber { get; set; }
        public string Team { get; set; }
        public string Role { get; set; }

    }
}
