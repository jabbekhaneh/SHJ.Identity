using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SHJ.Identity.Entities;
using SHJ.Identity.Services;
using SHJ.Identity.Shared;

namespace SHJ.Identity.Sample.Controllers;


public class RoleController : RoleServices
{
    public RoleController(RoleManager<Role> roleManager) : base(roleManager)
    {

    }
    
}
