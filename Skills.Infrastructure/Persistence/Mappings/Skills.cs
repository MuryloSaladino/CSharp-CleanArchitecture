using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.Domain.Entities;

namespace Skills.Infrastructure.Persistence.Mappings;

public class SkillsConfiguration : BaseEntityConfiguration<Skill>
{
    public override void Configure(EntityTypeBuilder<Skill> builder)
    {
        base.Configure(builder);

        builder.ToTable("skills");

        builder.Property(s => s.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(35)");
    }
}