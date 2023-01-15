using Entities.Entity.Abstraction;

namespace Entities.Entity;

public class QuestionResult : AbstractQuestion
{
    public string? ActualAnswer { get; set; }
    public bool IsCorrect { get; set; }
    public virtual TestResult? TestResult { get; set; }
    public Guid TestResultId { get; set; }
    public virtual MediaQuestion? Photo { get; set; }
    public Guid PhotoId { get; set; }
}