using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Service.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity.Service.Areas.Identity.Data
{
    public class Seed
    {
        public static async Task InitSeed(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync())
                return;

            var roles = new List<AppRole>
            {
                new AppRole{ Id = Guid.NewGuid().ToString(), Name = "Admin" },
                new AppRole{ Id = Guid.NewGuid().ToString(), Name = "Moderator" },
                new AppRole{ Id = Guid.NewGuid().ToString(), Name = "Member" }
            };

            foreach (var role in roles)
                await roleManager.CreateAsync(role);

            var adminUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@mock.com",
                UserName = "admin@mock.com"
            };

            await userManager.CreateAsync(adminUser, "P@ssw0rd");
            await userManager.AddToRolesAsync(adminUser, new[] { "Admin", "Moderator" });

            var moderatorUser = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "moderator@mock.com",
                UserName = "moderator@mock.com"
            };

            await userManager.CreateAsync(moderatorUser, "P@ssw0rd");
            await userManager.AddToRoleAsync(moderatorUser, "Moderator");
        }
    }
}