using System.Reflection;
using Entities.Entity;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data;

public class ApplicationContext : IdentityDbContext<User,
    IdentityRole<Guid>,
    Guid,
    IdentityUserClaim<Guid>,
    IdentityUserRole<Guid>,
    IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>,
    IdentityUserToken<Guid>>
{
    public DbSet<Question>? Questions { get; set; }
    public DbSet<Test>? Tests { get; set; }
    public DbSet<QuestionResult>? QuestionResults { get; set; }
    public DbSet<TestResult>? TestResults { get; set; }
    public DbSet<MediaUser>? MediaUsers { get; set; }
    public DbSet<MediaTest>? MediaTests { get; set; }
    public DbSet<MediaQuestion>? MediaQuestions { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}