namespace SHJ.Identity.Shared;
public class RoleDto
{

    public RoleDto()
    {

    }
    public RoleDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
