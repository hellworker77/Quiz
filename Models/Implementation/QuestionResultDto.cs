using Models.Abstraction;

namespace Models.Implementation;

public class QuestionResultDto : AbstractQuestionDto
{
    public Guid TestResultId { get; set; }
    public string? ActualAnswer { get; set; }
    public bool IsCorrect { get; set; }
    public MediaDto? Photo { get; set; }
}