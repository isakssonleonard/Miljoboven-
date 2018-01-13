using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Uppgift1Layout.Models
{
    public static class IdentitySeedData
    {
        // skapar en hårdkodad användare för test som sedan inte kommer att fungera på grund att authorize roles läggs till 
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret12345$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices.
                GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            // kollar om user är null om det är så skapas en Identity
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
            }

            // testar om coordinator finns
            bool roleExists = await roleManager.RoleExistsAsync("coordinator");

            if (!roleExists)
            {
                var role = new IdentityRole();
                role.Name = "coordinator";
                await roleManager.CreateAsync(role);
            }


            // testar om investigator finns
            roleExists = await roleManager.RoleExistsAsync("investigator");

            if (!roleExists)
            {
                var role = new IdentityRole();
                role.Name = "investigator";
                await roleManager.CreateAsync(role);
            }

            // testar om manager finns
            roleExists = await roleManager.RoleExistsAsync("manager");

            if (!roleExists)
            {
                var role = new IdentityRole();
                role.Name = "manager";
                await roleManager.CreateAsync(role);
            }

            var users = userManager.Users;

            if (!users.Any())
            {
                // lägger till en coordinator
                user = new IdentityUser("E001");
                await userManager.CreateAsync(user,"Pass01?");
                await userManager.AddToRoleAsync(user, "coordinator");

                // lägger till en manager
                user = new IdentityUser("E100");
                await userManager.CreateAsync(user, "Pass02?");
                await userManager.AddToRoleAsync(user, "manager");

                // lägger till en investigator
                user = new IdentityUser("E101");
                await userManager.CreateAsync(user, "Pass03?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E102");
                await userManager.CreateAsync(user, "Pass04?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E103");
                await userManager.CreateAsync(user, "Pass05?");
                await userManager.AddToRoleAsync(user, "investigator");
                
                // lägger till en manager
                user = new IdentityUser("E200");
                await userManager.CreateAsync(user, "Pass06?");
                await userManager.AddToRoleAsync(user, "manager");

                // lägger till en investigator
                user = new IdentityUser("E201");
                await userManager.CreateAsync(user, "Pass07?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E202");
                await userManager.CreateAsync(user, "Pass08?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E203");
                await userManager.CreateAsync(user, "Pass09?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en manager
                user = new IdentityUser("E300");
                await userManager.CreateAsync(user, "Pass10?");
                await userManager.AddToRoleAsync(user, "manager");

                // lägger till en investigator
                user = new IdentityUser("E301");
                await userManager.CreateAsync(user, "Pass11?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E302");
                await userManager.CreateAsync(user, "Pass12?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E303");
                await userManager.CreateAsync(user, "Pass13?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en manager
                user = new IdentityUser("E400");
                await userManager.CreateAsync(user, "Pass14?");
                await userManager.AddToRoleAsync(user, "manager");

                // lägger till en investigator
                user = new IdentityUser("E401");
                await userManager.CreateAsync(user, "Pass15?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E402");
                await userManager.CreateAsync(user, "Pass16?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E403");
                await userManager.CreateAsync(user, "Pass17?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en manager
                user = new IdentityUser("E500");
                await userManager.CreateAsync(user, "Pass18?");
                await userManager.AddToRoleAsync(user, "manager");

                // lägger till en investigator
                user = new IdentityUser("E501");
                await userManager.CreateAsync(user, "Pass19?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E502");
                await userManager.CreateAsync(user, "Pass20?");
                await userManager.AddToRoleAsync(user, "investigator");

                // lägger till en investigator
                user = new IdentityUser("E503");
                await userManager.CreateAsync(user, "Pass21?");
                await userManager.AddToRoleAsync(user, "investigator");
            }
        }
    }
}
