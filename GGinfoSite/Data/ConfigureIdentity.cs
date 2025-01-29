using GGinfoSite.Models;
using Microsoft.AspNetCore.Identity;

namespace GGinfoSite.Data
{
    public class ConfigureIdentity
    {
        private static RoleManager<IdentityRole> roleManager;
        private static UserManager<AppUser> userManager;

        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            userManager = provider.GetRequiredService<UserManager<AppUser>>();

            const string MEMBER = "Member";
            await CreateRole(MEMBER);
            const string ADMIN = "Admin";
            await CreateRole(ADMIN);
            const string PASSWORD = "password";
            await CreateUser("admin", "", PASSWORD, ADMIN);
        }

        private static async Task CreateRole(string roleName)
        {
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        private static async Task CreateUser(string firstName, string lastName, string password, string role)
        {
            AppUser user = new AppUser { UserName = firstName + lastName, Name = firstName + " " + lastName };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
