using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Skills.Application.Config;

namespace Skills.Persistence.Context;

public class XpricefyDbContextFactory : IDesignTimeDbContextFactory<SkillsContext>
{
    public SkillsContext CreateDbContext(string[] args)
    {
        DotEnv.Load();

        var optionsBuilder = new DbContextOptionsBuilder<SkillsContext>();
        optionsBuilder.UseNpgsql(DotEnv.Get("DATABASE_URL"));

        return new SkillsContext(optionsBuilder.Options);
    }
}