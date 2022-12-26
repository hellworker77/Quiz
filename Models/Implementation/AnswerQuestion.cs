using Models.Abstraction;

namespace Models.Implementation;

public class AnswerQuestion : AbstractQuestionDto
{
    public string? ActualAnswer { get; set; }
    public Guid TestId { get; set; }
}