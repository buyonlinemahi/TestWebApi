using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Demo.Core.Data.SQLServer;

namespace Demo.UnitTest
{
    public class DbConnection
    {
        public DbContextOptionsBuilder<DemoDbContext> InitConfiguration()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
             .Build();

            var builder = new DbContextOptionsBuilder<DemoDbContext>();
            builder.UseSqlServer(config["ConnectionStrings"])
                    .UseInternalServiceProvider(serviceProvider);

            return builder;
        }
    }
}
