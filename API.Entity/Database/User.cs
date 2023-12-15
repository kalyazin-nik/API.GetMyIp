namespace API.Entity.Database;

public class User(string guid) : BaseEntity
{
    public string Guid { get; private set; } = guid;
    public virtual IpInfo? IpInfo { get; set; }
    public DateTime CreatedAt { get; set; }
}
