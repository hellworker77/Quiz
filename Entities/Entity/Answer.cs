namespace Entities.Entity;

public class Answer
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public virtual Question? Question { get; set; }
    public virtual Guid QuestionId { get; set; }
}