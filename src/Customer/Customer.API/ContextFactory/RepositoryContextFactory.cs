using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace Customer.API.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[]? args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            var connectionString = configuration.GetConnectionString("sqlConnection");
            //configuration.GetValue<string>("ConnectionStrings:sqlConnection");
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), 
                b => b.MigrationsAssembly("Customer.API"));

            return new RepositoryContext(builder.Options);
        }
    }
}
