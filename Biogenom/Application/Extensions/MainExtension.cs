using System.Reflection;
using Biogenom.Repository.UnitOfWork;
using Biogenum.Application.Mapping;
using Biogenum.Application.Services;
using Biogenum.Domain.Services;
using Biogenum.SqlServer.DbContext;
using Biogenum.SqlServer.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Biogenum.Application.Extensions;

public static class MainExtension
{
    public static void AddMainExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

        services.Configure<ConnectionStringOption>(configuration.GetSection(ConnectionStringOption.Key));

        services.AddDbContext<BiogenomDbContext>((options) =>
        {
            var connectionString = configuration.GetSection(ConnectionStringOption.Key)
                .Get<ConnectionStringOption>();

            options.UseNpgsql(connectionString?.DefaultConnection,
                npgsqlOptionsAction =>
                {
                    npgsqlOptionsAction.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
        });
    }
}