using Business.UserManagement;
using Common.Models;

namespace IdentityPortal.Helper;

public static class AddUserRoleManager
{
    public static async Task Run(WebApplicationBuilder builder)
    {
        if (Boolean.TryParse(builder.Configuration.GetSection("AppSettings:AddUserRole").Value, out var addRole) && addRole)
        {
            using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
            {
                if (serviceProvider.GetRequiredService<ICustomUserManager>() is ICustomUserManager customUserManager)
                {
                    await customUserManager.AddRole(new string[2] { Constants.Role.Administrator, Constants.Role.Member });
                    await customUserManager.AddRoleToUser("Administrator", Constants.Role.Administrator);
                    await customUserManager.AddRoleToUser("Member", Constants.Role.Member);
                }
            }
        }

    }
}
