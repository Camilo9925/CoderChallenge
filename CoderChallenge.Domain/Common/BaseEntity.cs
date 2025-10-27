namespace CoderChallenge.Domain.Common;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
}
