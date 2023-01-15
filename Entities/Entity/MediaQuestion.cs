using Entities.Entity.Abstraction;

namespace Entities.Entity;

public class MediaQuestion : Media
{
    public virtual ICollection<Question>? Questions { get; set; }
    public virtual ICollection<QuestionResult>? QuestionResults { get; set; }
}