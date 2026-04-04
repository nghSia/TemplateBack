using TemplateBack.TemplateBack.Core.Interfaces;
using TemplateBack.TemplateBack.Core.Interfaces.Repositories;
using TemplateBack.TemplateBack.Infrastrucutre.Context;

namespace TemplateBack.TemplateBack.Infrastrucutre;

/* Aggregates all repositories — one SaveChangesAsync() per transaction */
public class UnitOfWork : IUnitOfWork
{
    private readonly BaseContext m_Context;
    public IExampleRepository Examples { get; }

    public UnitOfWork(BaseContext p_Context, IExampleRepository p_Examples)
    {
        m_Context = p_Context;
        Examples = p_Examples;
    }

    public async Task<int> SaveChangesAsync()
        => await m_Context.SaveChangesAsync();

    public void Dispose()
        => m_Context.Dispose();
}