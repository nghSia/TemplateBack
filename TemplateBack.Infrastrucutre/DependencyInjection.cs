using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TemplateBack.TemplateBack.Core.Interfaces;
using TemplateBack.TemplateBack.Core.Interfaces.Repositories;
using TemplateBack.TemplateBack.Infrastrucutre.Context;
using TemplateBack.TemplateBack.Infrastrucutre.Repository;

namespace TemplateBack.TemplateBack.Infrastrucutre;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        /* DbContext — SQL Server */
        services.AddDbContext<BaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));

        /* Dapper connection — same connection string */
        services.AddScoped<IDbConnection>(_ =>
            new SqlConnection(configuration.GetConnectionString("Default")));

        /* Repositories */
        services.AddScoped<IExampleRepository, ExampleRepository>();

        /* Unit of Work */
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}