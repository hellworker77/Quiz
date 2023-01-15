using Entities.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Configurations;

public class QuestionResultConfiguration : IEntityTypeConfiguration<QuestionResult>
{
    public void Configure(EntityTypeBuilder<QuestionResult> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Photo).WithMany(x => x.QuestionResults).HasForeignKey(x => x.PhotoId);
    }
}