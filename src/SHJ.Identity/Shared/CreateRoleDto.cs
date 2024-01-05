using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Shared;

public class CreateRoleDto
{
    [Required,MaxLength(256)]
    public string Name { get; set; } = string.Empty;
}
