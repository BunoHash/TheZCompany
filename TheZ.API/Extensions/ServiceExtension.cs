using Microsoft.EntityFrameworkCore;
using TheZ.Contracts.Interfaces;
using TheZ.LoggerService;
using TheZ.Repository;
using TheZ.Service;
using TheZ.Service.Contracts;

namespace TheZ.API.Extensions
{
    public static class ServiceExtension
    {

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

        public static void ConfigureIISIntergation(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });


        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection service) => 
            service.AddScoped<IServiceManager,ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
    }
}
