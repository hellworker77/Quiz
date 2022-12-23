namespace Entities.Entity;

public class Question
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? AnswersAsJson { get; set; }
    public string? CorrectAnswer { get; set; }
    public virtual Test? Test { get; set; }
    public Guid TestId { get; set; }
}