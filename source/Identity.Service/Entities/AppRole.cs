using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Identity.Service.Entities
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}