namespace SHJ.Identity.Shared;

public class IdentityFilterDto
{
    public string? Search { get; set; } = string.Empty;
    public int PageId { get; set; } = 1;
    public int Take { get; set; } = 40;
}
