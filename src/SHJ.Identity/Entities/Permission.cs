namespace SHJ.Identity.Entities;

public class Permission
{
    public Permission()
    {

    }
    public Permission(string name, Guid parentId = default)
    {
        this.Name = name;
        this.ParentId = parentId;
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? ParentId { get; set; }

}
