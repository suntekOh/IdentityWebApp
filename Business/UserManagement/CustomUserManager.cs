using Common.Entities.Identity;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UserManagement;

public interface ICustomUserManager
{
    Task AddRole(IEnumerable<string> roleNameList);
    Task AddRoleToUser(string userName, string roleName);
}


public class CustomUserManager : ICustomUserManager
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public CustomUserManager(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task AddRole(IEnumerable<string> roleNameList)
    {
        var utcNow = DateTimeOffset.UtcNow;
        IdentityResult roleResult;

        foreach (var roleName in roleNameList)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (roleExist == false)
            {
                //create the roles and seed them to the database: Question 1
                roleResult = await _roleManager.CreateAsync(new Role { 
                    Name = roleName,
                    NormalizedName = roleName.ToUpper(),
                    RowCreatedBy = "dev",
                    RowCreatedDateTimeUtc = utcNow
                });
            }
        }
    }

    public async Task AddRoleToUser(string userName, string roleName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        var roleNameList = await _userManager.GetRolesAsync(user);
        var found = roleNameList.FirstOrDefault(p => p.Equals(roleName));
        if(found == default)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }
    }
}
