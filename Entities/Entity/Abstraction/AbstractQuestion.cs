namespace Entities.Entity.Abstraction;

public abstract class AbstractQuestion
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? AnswersAsJson { get; set; }
    public string? CorrectAnswer { get; set; }
}