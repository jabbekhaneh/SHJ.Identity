using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SHJ.Identity.Entities;
using SHJ.Identity.Mvc;
using SHJ.Identity.Shared;

namespace SHJ.Identity.Services;


public abstract class AccountService : IdentityControllerBase
{
    protected readonly SignInManager<User> _signInManager;
    protected readonly UserManager<User> _userManager;

    public AccountService(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost, ActionName("SignUp")]
    public virtual async Task<IActionResult> SignUp(RegisterWithEmailUsernameDto input)
    {

        var newUser = new User()
        {
            Email = input.Email,
            EmailConfirmed = false,
            FirstName = input.FirstName,
            LastName = input.LastName,
            UserName = input.Email,
        };

        return Ok(await _userManager.CreateAsync(newUser));
    }

    [HttpPost, ActionName("SignIn")]
    public virtual async Task<IActionResult> SignIn(SignInDto input)
    {
        if(_signInManager.IsSignedIn(User))
            throw new IdentityException(GlobalErrorIdentity.AccessDenied, "Access Denied");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _signInManager
            .PasswordSignInAsync(input.UserName, input.Password, input.IsPersistent, true);

        if (result.IsLockedOut)
            throw new IdentityException(GlobalErrorIdentity.IsLockedOut, "User Is LockedOut");
        if (result.IsNotAllowed)
            throw new IdentityException(GlobalErrorIdentity.IsNotAllowed, "User Is NotAllowed");
        if (!result.Succeeded)
            throw new IdentityException(GlobalErrorIdentity.NotFoundUser, "Notfound user");

        return Ok();
    }

    [HttpPost,ActionName("SignOut")]
    public virtual async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }
}
