using System.Reflection;
using Application.Models;
using Application.Services;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IBingoSentenceService, BingoSentenceService>();
            services.AddScoped<IGamesService, GamesService>();

            services.AddSingleton(new GamesStorage());

            return services;
        }
    }
}