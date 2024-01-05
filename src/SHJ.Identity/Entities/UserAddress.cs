using SHJ.Identity.Entities.ValueObjects;

namespace SHJ.Identity.Entities;

public class UserAddress
{
    public UserAddress(Address address, Guid userId)
    {
        Address = address;
        UserId = userId;
    }
    public Guid Id { get; set; }
    public Address Address { get; set; }
    public Guid UserId { get; set; }

}
