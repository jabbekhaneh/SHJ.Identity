using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Shared;

public class EditRoleDto
{
    [Required]
    public Guid Id { get; set; }

    [Required, MaxLength(256)]
    public string Name { get; set; } = string.Empty;
}