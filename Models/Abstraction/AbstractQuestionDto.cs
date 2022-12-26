namespace Models.Abstraction;

public class AbstractQuestionDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? AnswersAsJson { get; set; }
    public string? CorrectAnswer { get; set; }
}