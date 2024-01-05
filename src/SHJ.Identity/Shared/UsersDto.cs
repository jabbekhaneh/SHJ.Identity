namespace SHJ.Identity.Shared;

public class UsersDto
{
    public UsersDto()
    {
        Users = new();
    }
    public List<UserDto> Users { get; set; }
    public int PageSize { get; set; }
}
