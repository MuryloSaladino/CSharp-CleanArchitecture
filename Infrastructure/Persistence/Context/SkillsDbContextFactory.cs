using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.IdentityModel.Protocols.Configuration;

namespace Infrastructure.Persistence.Context;

public class SkillsDbContextFactory : IDesignTimeDbContextFactory<SkillsContext>
{
    public SkillsContext CreateDbContext(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["../.env"]));

        var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
            ?? throw new InvalidConfigurationException("Missing \"DATABASE_URL\" environment variable");
        var optionsBuilder = new DbContextOptionsBuilder<SkillsContext>();

        optionsBuilder.UseNpgsql(dbUrl);

        return new SkillsContext(optionsBuilder.Options);
    }
}