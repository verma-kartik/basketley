using Contracts;
using LoggerService;

namespace Customer.API.Extensions;

public static class ServiceExtension
{
    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();
}
