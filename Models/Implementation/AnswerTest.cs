using Models.Abstraction;

namespace Models.Implementation;

public class AnswerTest : AbstractTestDto
{
    public virtual IList<AnswerQuestion>? AnswerQuestionsDto { get; set; }
}