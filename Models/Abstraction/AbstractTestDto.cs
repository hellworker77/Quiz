namespace Models.Abstraction;

public class AbstractTestDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset Date { get; set; }
    public string? Stamp { get; set; }

}