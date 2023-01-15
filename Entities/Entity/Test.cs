using Entities.Entity.Abstraction;

namespace Entities.Entity;

public class Test : AbstractTest
{
    public virtual ICollection<Question>? Questions { get; set; }
    public virtual MediaTest? Photo { get; set; }
    public Guid PhotoId { get; set; }
}