using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete.Identity
{
    public static class SeedIdentity
    {
        public static async Task CreateIdentityUsers(IServiceProvider serviceProvider,IConfiguration configuration)
        {
            var usermanager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if (await usermanager.FindByNameAsync(username)==null)
            {
                if (await roleManager.FindByNameAsync(role)==null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = username,
                    Email = email,
                    Name = "Ümit",
                    Surname = "Çelebi"
                };
                IdentityResult result = await usermanager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await usermanager.AddToRoleAsync(user, role);
                }
            }
            


        }
    }
}
