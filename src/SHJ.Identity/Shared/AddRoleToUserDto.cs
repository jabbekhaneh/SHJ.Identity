using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Shared;


public class DeleteRoleToUserDto
{
    public DeleteRoleToUserDto()
    {
        RoleIds = new List<Guid>();
        if (RoleIds.Count <= 0)
            throw new ArgumentNullException(nameof(RoleIds));
    }

    [Required]

    public Guid UserId { get; set; }
    public List<Guid> RoleIds { get; set; }
}

public class AddRoleToUserDto
{
    public AddRoleToUserDto()
    {
        RoleIds = new List<Guid>();
    }

    [Required]

    public Guid UserId { get; set; }
    public List<Guid> RoleIds { get; set; }
}
