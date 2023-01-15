using Entities.Entity.Abstraction;

namespace Entities.Entity;

public class MediaTest : Media
{
    public virtual ICollection<Test>? Tests { get; set; }
    public virtual ICollection<TestResult>? TestResults { get; set; }
}