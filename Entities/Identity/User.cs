using Entities.Entity;
using Microsoft.AspNetCore.Identity;

namespace Entities.Identity;

public class User : IdentityUser<Guid>
{
    public virtual ICollection<TestResult>? TestResults { get; set; }
}