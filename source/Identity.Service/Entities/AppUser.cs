using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Identity.Service.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}