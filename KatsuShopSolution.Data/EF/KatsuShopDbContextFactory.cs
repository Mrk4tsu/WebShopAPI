using KatsuShopSolution.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace KatsuShopSolution.Data.EF
{
    public class KatsuShopDbContextFactory : IDesignTimeDbContextFactory<KatsuShopDbContext>
    {
        //Cài đặt Microsoft.Extensions.Configuration.FileExtensions
        //và Microsoft.Extensions.Configuration.Json để đọc file appsettings.json
        public KatsuShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString(SystemConstants.MainConnectionString);
            var optionBuilder = new DbContextOptionsBuilder<KatsuShopDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new KatsuShopDbContext(optionBuilder.Options);
        }
    }
}
