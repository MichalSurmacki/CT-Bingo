using Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connBuilder = new SqlConnectionStringBuilder();
            connBuilder.ConnectionString = configuration.GetConnectionString("CtBingoConnection");
            connBuilder.UserID = configuration["UserID"];
            connBuilder.Password = configuration["Password"];
            connBuilder.DataSource = configuration["Datasource"] ?? "localhost";
            connBuilder.InitialCatalog = configuration["InitialCatalog"] ?? "ctBingoDb";

            services.AddDbContext<BingoContext>(opt => opt.UseSqlServer(connBuilder.ConnectionString));
            services.AddScoped<IBingoContext>(provider => provider.GetService<BingoContext>());

            return services;
        }
    }
}