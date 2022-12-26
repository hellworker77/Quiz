namespace Models.Implementation;

public class TestDto 
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public virtual IList<QuestionDto>? Questions { get; set; }
}