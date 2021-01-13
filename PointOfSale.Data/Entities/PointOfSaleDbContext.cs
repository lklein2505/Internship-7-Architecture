using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PointOfSale.Data.Entities
{
    public class PointOfSaleDbContext : DbContext
    {
        public PointOfSaleDbContext(DbContextOptions options) : base(options)
        {
        }

        public class PointOfSaleContextFactory : IDesignTimeDbContextFactory<PointOfSaleDbContext>
        {
            public PointOfSaleDbContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddXmlFile("App.config")
                    .Build();
                configuration
                    .Providers
                    .First()
                    .TryGet("connectionStrings:add:PointOfSale:connectionString", out var connectionString);

                var options = new DbContextOptionsBuilder<PointOfSaleDbContext>().UseSqlServer(connectionString).Options;
                return new PointOfSaleDbContext(options);
            }

        }
    }
}
