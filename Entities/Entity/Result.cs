namespace Entities.Entity;

public class Result
{
    public Guid Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public Test? Test { get; set; }
    public Guid TestId { get; set; }
}