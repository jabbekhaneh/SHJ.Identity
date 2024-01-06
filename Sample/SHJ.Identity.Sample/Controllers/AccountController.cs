using Microsoft.AspNetCore.Identity;
using SHJ.Identity.Entities;
using SHJ.Identity.Services;

namespace SHJ.Identity.Sample.Controllers;


public class AccountController : AccountService
{
    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager) : base(signInManager, userManager)
    {
    }
}
