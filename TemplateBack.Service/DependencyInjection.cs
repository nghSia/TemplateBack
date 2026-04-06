using TemplateBack.TemplateBack.Core.Interfaces.Services;
using TemplateBack.TemplateBack.Service.Services;

namespace TemplateBack.TemplateBack.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IExampleService, ExampleService>();
        return services;
    }
}