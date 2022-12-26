using Entities.Entity.Abstraction;

namespace Entities.Entity;

public class Test : AbstractTest
{
    public virtual ICollection<Question>? Questions { get; set; }
}