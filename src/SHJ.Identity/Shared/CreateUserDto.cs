using SHJ.Identity.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Shared;
public class EditUserDto
{
    [Required]
    public Guid Id { get; set; }
    public bool EmailConfirmed { get; set; }
    [MaxLength(20)]
    public string? PhoneNumber { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    [MaxLength(256)]
    public string? FirstName { get; set; } = string.Empty;

    [MaxLength(256)]
    public string? LastName { get; set; } = string.Empty;

    public Address? Address { get; set; }

    [MaxLength(256)]
    public string? Job { get; set; } = string.Empty;

    public int? Age { get; set; }

    [MaxLength(25)]
    public string? Mobile { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    [MaxLength(256)]
    public string? CompanyName { get; set; } = string.Empty;
    public string? Avatar { get; set; }
}
public class CreateUserDto
{
    [EmailAddress, Required]
    public string Email { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    [MaxLength(20)]
    public string? PhoneNumber { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;

    [MaxLength(256)]
    public string? FirstName { get; set; } = string.Empty;

    [MaxLength(256)]
    public string? LastName { get; set; } = string.Empty;

    public Address? Address { get; set; }

    [MaxLength(256)]
    public string? Job { get; set; } = string.Empty;

    public int? Age { get; set; }

    [MaxLength(25)]
    public string? Mobile { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    [MaxLength(256)]
    public string? CompanyName { get; set; } = string.Empty;
    public string? Avatar  { get; set; }
}
