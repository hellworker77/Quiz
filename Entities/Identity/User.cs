using Entities.Entity;
using Microsoft.AspNetCore.Identity;

namespace Entities.Identity;

public class User : IdentityUser<Guid>
{
    public virtual ICollection<TestResult>? TestResults { get; set; }
    public int Rating { get; set; }
    public virtual MediaUser? Photo { get; set; }
    public Guid PhotoId { get; set; }
}