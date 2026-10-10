
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentOperations.Infrastructure.Data;

public class StudentOperationsDbContextFactory
    : IDesignTimeDbContextFactory<StudentOperationsDbContext>
{
    public StudentOperationsDbContext CreateDbContext(
        string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<StudentOperationsDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=LAPTOP-MHRETQLO;" +
            "Database=StudentOperationsDb;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;");

        return new StudentOperationsDbContext(
            optionsBuilder.Options);
    }
}
