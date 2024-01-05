using SHJ.Identity.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Shared;
public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public string? PhoneNumber { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public Address? Address { get; set; }
    public string? Job { get; set; } = string.Empty;
    public int? Age { get; set; }
    public string? Mobile { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string? CompanyName { get; set; } = string.Empty;
    public string? Avatar { get; set; } = string.Empty;
}
