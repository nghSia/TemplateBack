using System.Data;
using Microsoft.EntityFrameworkCore;
using TemplateBack.TemplateBack.Core.Interfaces.Repositories;
using TemplateBack.TemplateBack.Infrastrucutre.Context;

namespace TemplateBack.TemplateBack.Infrastrucutre.Repository;

/* Generic CRUD implementation — inherited by all repositories */
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly BaseContext m_Context;
    protected readonly IDbConnection m_DbConnection;

    public BaseRepository(BaseContext p_Context, IDbConnection p_Db)
    {
        m_Context = p_Context;
        m_DbConnection = p_Db;
    }

    /* Resolves the correct DbSet dynamically from the entity type */
    protected DbSet<T> DbSet => m_Context.Set<T>();

    /// <inheritdoc/>
    public async Task<IEnumerable<T>> GetAllAsync()
        => await DbSet.AsNoTracking().ToListAsync();

    /// <inheritdoc/>
    public async Task<T?> GetByIdAsync(int p_Id)
        => await DbSet.FindAsync(p_Id);

    /// <inheritdoc/>
    public async Task<T> CreateAsync(T p_Entity)
    {
        await DbSet.AddAsync(p_Entity);
        return p_Entity;
    }

    /// <inheritdoc/>
    public async Task<T> UpdateAsync(T p_Entity)
    {
        DbSet.Update(p_Entity);
        return p_Entity;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(int p_Id)
    {
        T? v_Entity = await DbSet.FindAsync(p_Id);
        if (v_Entity is not null) DbSet.Remove(v_Entity);
    }

    /// <inheritdoc/>
    public async Task<bool> ExistsAsync(int p_Id)
        => await DbSet.FindAsync(p_Id) is not null;
}