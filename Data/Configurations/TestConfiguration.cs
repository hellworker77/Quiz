using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Questions).WithOne(x => x.Test).HasForeignKey(x => x.TestId);

        builder.HasOne(x => x.Photo).WithMany(x => x.Tests).HasForeignKey(x => x.PhotoId);
    }
}