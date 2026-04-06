using TemplateBack.TemplateBack.Infrastrucutre;

namespace TemplateBack.TemplateBack.API.Modules;

/* Groups all infrastructure-related DI registrations */
public static class InfraModule
{
    public static IServiceCollection AddInfraModule(
        this IServiceCollection services,
        IConfiguration p_configuration)
    {
        services.AddInfrastructure(p_configuration);
        return services;
    }
}