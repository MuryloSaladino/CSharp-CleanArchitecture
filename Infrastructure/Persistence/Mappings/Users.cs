using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Mappings;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("users");
        
        builder.HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(us => us.UserId);
        builder.Navigation(u => u.Skills)
            .AutoInclude();

        builder.Property(u => u.Username)
            .HasColumnName("username")
            .HasColumnType("varchar(255)")
            .IsRequired();
        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.Property(u => u.Password)
            .HasColumnName("password")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(u => u.IsAdmin)
            .HasColumnName("is_admin")
            .HasColumnType("boolean");
    }
}