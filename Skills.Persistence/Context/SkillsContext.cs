using Microsoft.EntityFrameworkCore;
using Skills.Domain.Entities;

namespace Skills.Persistence.Context;

public class SkillsContext(DbContextOptions<SkillsContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        
        modelBuilder.Entity<Skill>()
            .HasKey(s => s.Id);
    }
}