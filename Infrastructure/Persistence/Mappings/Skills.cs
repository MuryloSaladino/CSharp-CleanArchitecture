using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Mappings;

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