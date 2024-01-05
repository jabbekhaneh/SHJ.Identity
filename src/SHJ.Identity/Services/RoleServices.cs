using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHJ.Identity.Entities;
using SHJ.Identity.Mvc;
using SHJ.Identity.Shared;

namespace SHJ.Identity.Services;

public abstract class RoleServices : IdentityControllerBase
{
    protected readonly RoleManager<Role> _roleManager;
    protected RoleServices(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get(IdentityFilterDto input)
    {
        var result = new RolesDto();
        var query = _roleManager.Roles;
        if (!string.IsNullOrEmpty(input.Search))
            query = query.Where(_ => _.Name.Contains(input.Search) ||
                                     _.NormalizedName.Contains(input.Search));

        var paging = query.ToPagination<Role>(input.Take, input.PageId);
        result.PageSize = paging.pageSize;
        result.Roles = await paging.Query.Select(_ => new RoleDto
        {
            Name = _.Name,
            Id = _.Id,
        }).ToListAsync();
        return Ok(result);
    }


    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(Guid id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());

        if (role == null) return NotFound();

        return Ok(role);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Edit(EditRoleDto input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var role = await _roleManager.FindByIdAsync(input.Id.ToString());

        if (role == null) return NotFound();

        role.Name = input.Name;

        var result = await _roleManager.UpdateAsync(role);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());

        if (role == null) return NotFound();

        var result = await _roleManager.DeleteAsync(role);

        return Ok(result);

    }

    [HttpPost]
    public virtual async Task<IActionResult> Create(CreateRoleDto input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _roleManager.CreateAsync(new Role
        {
            Name = input.Name,
        });

        return Ok(result);
    }
}
