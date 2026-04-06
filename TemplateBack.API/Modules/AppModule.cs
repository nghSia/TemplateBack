using TemplateBack.TemplateBack.Core;
using TemplateBack.TemplateBack.Service;

namespace TemplateBack.TemplateBack.API.Modules;

/* Groups all application-layer DI registrations */
public static class AppModule
{
    public static IServiceCollection AddAppModule(this IServiceCollection services)
    {
        services.AddCore();
        services.AddService();
        return services;
    }
}