namespace Entities.Entity;

public class Test
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Question>? Questions { get; set; }
}