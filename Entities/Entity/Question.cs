using Entities.Entity.Abstraction;

namespace Entities.Entity;

public class Question : AbstractQuestion
{
    public virtual Test? Test { get; set; }
    public Guid TestId { get; set; }
}