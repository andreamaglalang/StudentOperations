
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace StudentOperations.Infrastructure.Data;

public class StudentOperationsDbContextFactory
    : IDesignTimeDbContextFactory<StudentOperationsDbContext>
{
    public StudentOperationsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                "StudentOperations.Console/appsettings.json",
                optional: true)
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString =
            configuration.GetConnectionString("StudentDatabase")
            ?? throw new InvalidOperationException(
                "StudentDatabase connection string is missing.");

        var optionsBuilder =
            new DbContextOptionsBuilder<StudentOperationsDbContext>();

        optionsBuilder.UseSqlServer(connectionString);

        return new StudentOperationsDbContext(optionsBuilder.Options);
    }
}
