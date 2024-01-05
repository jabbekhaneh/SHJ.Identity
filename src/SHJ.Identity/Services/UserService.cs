﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHJ.Identity.Entities;
using SHJ.Identity.Mvc;
using SHJ.Identity.Shared;

namespace SHJ.Identity.Services;

public abstract class UserService : IdentityControllerBase
{
    protected readonly UserManager<User> _userManager;

    protected UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get(IdentityFilterDto input)
    {
        var result = new UsersDto();
        var query = _userManager.Users;

        if (!string.IsNullOrEmpty(input.Search))
            query = query.Where(_ => _.UserName.Contains(input.Search) ||
                                 _.Email.Contains(input.Search) ||
                                 _.Mobile.Contains(input.Search) ||
                                 _.PhoneNumber.Contains(input.Search) ||
                                 _.LastName.Contains(input.Search) ||
                                 _.FirstName.Contains(input.Search));

        var paging = query.ToPagination<User>();

        result.Users = await paging.Query.Select(_ => new UserDto()
        {
            Id = _.Id,
            Job = _.Job,
            PhoneNumber = _.PhoneNumber,
            Email = _.Email,
            Mobile = _.Mobile,
            EmailConfirmed = _.EmailConfirmed,
            FirstName = _.FirstName,
            LastName = _.LastName,
            CompanyName = _.CompanyName,
            DateOfBirth = _.DateOfBirth,
            Address = _.Address,
            Age = _.Age,
            Avatar = _.Avatar,

        }).ToListAsync();
        return Ok();
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user == null) return NotFound();
        UserDto userInfo = MapUserDto(user);
        return Ok(userInfo);
    }



    [HttpPut]
    public virtual async Task<IActionResult> Edit(EditUserDto input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = MapEditUserDto(input);

        var result = await _userManager.UpdateAsync(user);

        return Ok(result);
    }
    [HttpPost]
    public virtual async Task<IActionResult> CreateUser(CreateUserDto input)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var query = _userManager.Users;

        if (await query.AnyAsync(_ => _.Email.Equals(input.Email.Trim().ToLower())))
            throw new IdentityException(GlobalErrorIdentity.DublicateEmail);

        User newUser = MapCreateUserDto(input);

        var result = await _userManager.CreateAsync(newUser, input.Password);

        return Ok(result);
    }



    #region PrivateMethods
    private static User MapCreateUserDto(CreateUserDto input)
    {
        return new User
        {
            UserName = input.Email.Trim().ToLower(),
            Email = input.Email.Trim().ToLower(),
            EmailConfirmed = input.EmailConfirmed,
            Mobile = input.Mobile,
            Avatar = input.Avatar,
            Address = input.Address,
            Age = input.Age,
            Job = input.Job,
            PhoneNumber = input.PhoneNumber,
            FirstName = input.FirstName,
            LastName = input.LastName,
            DateOfBirth = input.DateOfBirth,
            CompanyName = input.CompanyName,
        };
    }

    private static User MapEditUserDto(EditUserDto input)
    {
        return new User
        {
            EmailConfirmed = input.EmailConfirmed,
            Mobile = input.Mobile,
            Avatar = input.Avatar,
            Address = input.Address,
            Age = input.Age,
            Job = input.Job,
            PhoneNumber = input.PhoneNumber,
            FirstName = input.FirstName,
            LastName = input.LastName,
            DateOfBirth = input.DateOfBirth,
            CompanyName = input.CompanyName,
        };
    }

    private static UserDto MapUserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Address = user.Address,
            Age = user.Age,
            CompanyName = user.CompanyName,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            EmailConfirmed = user.EmailConfirmed,
            FirstName = user.FirstName,
            Job = user.Job,
            LastName = user.LastName,
            Mobile = user.Mobile,
            PhoneNumber = user.PhoneNumber,
            Avatar = user.Avatar,
        };
    }
    #endregion

}