namespace SHJ.Identity.Shared;

public class RolesDto
{
    public RolesDto()
    {
        Roles = new List<RoleDto>();
    }

    public List<RoleDto> Roles { get; set; }
    public int PageSize { get; set; }
}
