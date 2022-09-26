using DBMS_WebApI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBMS_WebApI.Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static async Task<IServiceCollection> AddDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["Db:DefaultConnectionString"];
            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
