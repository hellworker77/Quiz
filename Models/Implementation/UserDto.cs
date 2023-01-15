using Microsoft.AspNetCore.Http;

namespace Models.Implementation;

public class UserDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? RepeatPassword { get; set; }
    public int Rating { get; set; }
    public MediaDto? Photo { get; set; }
}