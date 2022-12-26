namespace Models.Implementation;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? AnswersAsJson { get; set; }
    public string? CorrectAnswer { get; set; }
    public Guid TestId { get; set; }
}