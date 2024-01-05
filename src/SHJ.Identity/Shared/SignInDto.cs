using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Shared;

public class SignInDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    public bool IsPersistent { get; set; } = false;
}