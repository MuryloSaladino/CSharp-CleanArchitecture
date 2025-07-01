using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Mappings;

public class UserSkillsConfiguration : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder.ToTable("user_skills");

        builder.HasKey(us => new { us.UserId, us.SkillId });

        builder.Property(us => us.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(us => us.SkillId)
            .HasColumnName("skill_id")
            .IsRequired();
        builder.HasOne(us => us.Skill)
            .WithMany()
            .HasForeignKey(us => us.SkillId);

        builder.Property(us => us.Level)
            .HasColumnName("level")
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(us => us.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .IsRequired();
    }
}
