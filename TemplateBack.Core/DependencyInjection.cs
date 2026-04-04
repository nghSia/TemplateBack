using System.Reflection;
using TemplateBack.TemplateBack.Core.Mappers;

namespace TemplateBack.TemplateBack.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        /* Registers all AutoMapper profiles from this assembly */
        services.AddAutoMapper(cfg => { }, typeof(ExampleProfile));
        return services;
    }
}