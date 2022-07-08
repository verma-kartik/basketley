using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using Services.Contracts;

namespace Customer.API.Extensions;

public static class ServiceExtension
{
	public static void ConfigureCors(this IServiceCollection services) =>
		services.AddCors(options =>
		{
			options.AddPolicy("CorsPolicy", builder =>
			builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());
		});

	public static void ConfigureIISIntegration(this IServiceCollection services) =>
		services.Configure<IISOptions>(options =>
		{
		});

	public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddScoped<ILoggerManager, LoggerManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

	public static void ConfigureServiceManager(this IServiceCollection services) =>
	   services.AddScoped<IServiceManager, ServiceManager>();

	//public static void ConfigureSqlContext(this IServiceCollection services)
	//{
	//	string? connectionString = "server=db;port=28002;database=CustomerDb;userid=root;password=gossipgirl";

	//	services.AddDbContext<RepositoryContext>(opts =>
	//		opts.UseMySql(connectionString,
	//			ServerVersion.AutoDetect(connectionString)));
	//}
}
