using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SHJ.Identity.Entities;
using SHJ.Identity.Services;

namespace SHJ.Identity.Sample.Controllers;


public class UserController : UserService
{
    public UserController(UserManager<User> userManager, RoleManager<Role> roleManager) : base(userManager, roleManager)
    {
    }
}
