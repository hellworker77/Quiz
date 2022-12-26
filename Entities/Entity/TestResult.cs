using Entities.Entity.Abstraction;
using Entities.Identity;

namespace Entities.Entity;

public class TestResult : AbstractTest
{
    public virtual ICollection<QuestionResult>? QuestionResults { get; set; }
    public virtual User? User { get; set; }
    public Guid UserId { get; set; }
}