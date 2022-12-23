namespace Entities.Entity;

public class Question
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public virtual List<Answer>? Answers { get; set; }
    public virtual Answer? CorrectAnswer { get; set; }
    public virtual Guid CorrectAnswerId { get; set; }
    public virtual Test? Test { get; set; }
    public Guid TestId { get; set; }
}