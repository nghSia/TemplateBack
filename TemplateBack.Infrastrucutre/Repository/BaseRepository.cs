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

    public async Task<IEnumerable<T>> GetAllAsync()
        => await DbSet.AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
        => await DbSet.FindAsync(id);

    public async Task<T> CreateAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity is not null) DbSet.Remove(entity);
    }

    public async Task<bool> ExistsAsync(int id)
        => await DbSet.FindAsync(id) is not null;
}