using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SMISrival.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AuthUser class
    public class AuthUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public String Name { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public String Surname { get; set; }
    }
}
