namespace SHJ.Identity.Shared;

public abstract class BaseIdentity
{
    public DateTime? CreatedTime { get; private set; }
    public string? CreatedBy { get; private set; }
    public DateTime? DeletedTime { get; private set; }
    public string? DeletedBy { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public DateTime? UpdateTime { get; private set; }
    public string? UpdateBy { get; private set; }
}
