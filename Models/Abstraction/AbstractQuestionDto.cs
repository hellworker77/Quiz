namespace Models.Abstraction;

public class AbstractQuestionDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public List<string>? Answers { get; set; }
    public string? CorrectAnswer { get; set; }
}