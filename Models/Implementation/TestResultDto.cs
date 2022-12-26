using Models.Abstraction;

namespace Models.Implementation;

public class TestResultDto : AbstractTestDto
{
    public virtual ICollection<QuestionResultDto>? QuestionResultsDto { get; set; }
    public Guid UserId { get; set; }
}