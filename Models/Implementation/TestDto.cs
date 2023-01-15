using Models.Abstraction;

namespace Models.Implementation;

public class TestDto : AbstractTestDto
{
    public virtual IList<QuestionDto>? QuestionsDto { get; set; }
    public MediaDto? Photo { get; set; }
}