using TemplateBack.TemplateBack.Core.Interfaces.Repositories;

namespace TemplateBack.TemplateBack.Core.Interfaces;

/* Single entry point for all repositories */
public interface IUnitOfWork : IDisposable
{
    IExampleRepository Examples { get; }
    Task<int> SaveChangesAsync();
}