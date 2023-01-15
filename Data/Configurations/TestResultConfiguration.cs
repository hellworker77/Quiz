using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class TestResultConfiguration : IEntityTypeConfiguration<TestResult>
{
    public void Configure(EntityTypeBuilder<TestResult> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.QuestionResults)
            .WithOne(x => x.TestResult)
            .HasForeignKey(x => x.TestResultId);

        builder.HasOne(x => x.User)
            .WithMany(x => x.TestResults)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Photo).WithMany(x => x.TestResults).HasForeignKey(x => x.PhotoId);
    }
}