using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SweetsTreats.Models
{
    public class ToDoListContextFactory : IDesignTimeDbContextFactory<SweetsTreatsContext>
    {

        SweetsTreatsContext IDesignTimeDbContextFactory<SweetsTreatsContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SweetsTreatsContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new SweetsTreatsContext(builder.Options);
        }
    }
}