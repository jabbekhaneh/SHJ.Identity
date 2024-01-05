using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Shared;

public class RegisterWithEmailUsernameDto
{
    [Required, MaxLength(255), EmailAddress]
    public string Email { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? FirstName { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? LastName { get; set; } = string.Empty;

    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Compare("Password"), DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
}
