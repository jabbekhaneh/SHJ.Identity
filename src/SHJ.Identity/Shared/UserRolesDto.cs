namespace SHJ.Identity.Shared;

public class UserRolesDto
{
    public string Name { get; set; } = string.Empty;
    public UserRolesDto()
    {
        
    }
    public UserRolesDto(string name)
    {
        Name = name;
    }
}