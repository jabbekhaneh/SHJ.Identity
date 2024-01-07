using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Shared;

public class CreateRoleDto
{
    public CreateRoleDto()
    {
        Permissions = new();
        if(Permissions.Count <= 0 )
            throw new ArgumentNullException(nameof(Permissions));
    }

    [Required, MaxLength(256)]
    public string Name { get; set; } = string.Empty;

    public List<Guid> Permissions { get; set; }
}
