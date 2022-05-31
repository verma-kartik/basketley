using Contracts;
using LoggerService;
using Repository;
using Services;
using Services.Contracts;
using MongoDB.Driver;
using Product.API.ContextFactory;

namespace Product.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositryManager(this IServiceCollection services)
    {
        services.AddScoped<IProductContext, ProductContextFactory>();
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

}
