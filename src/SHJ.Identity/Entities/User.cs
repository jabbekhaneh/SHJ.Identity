using Microsoft.AspNetCore.Identity;
using SHJ.Identity.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace SHJ.Identity.Entities;

public class User : IdentityUser<Guid>
{
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
    public bool MobileNumberConfirmed { get; set; }

    public decimal Wallet { get; set; } = 0;

    public DateTime? DateOfBirth { get; set; }

    [MaxLength(256)]
    public string? CompanyName { get; set; } = string.Empty;
    public string? Avatar { get; set; } = string.Empty;

}