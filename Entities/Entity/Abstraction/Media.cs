namespace Entities.Entity.Abstraction;

public abstract class Media
{
    public Guid Id { get; set; }
    public virtual byte[]? Data { get; set; }
    public string? FileName { get; set; }
    public string? Name { get; set; }

}