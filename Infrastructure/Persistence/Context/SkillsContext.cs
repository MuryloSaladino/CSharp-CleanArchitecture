using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class SkillsContext(DbContextOptions<SkillsContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkillsContext).Assembly);
    }
}