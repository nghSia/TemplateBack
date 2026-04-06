namespace TemplateBack.TemplateBack.Core.Interfaces.Repositories;

/* Generic CRUD contract — inherited by all repositories */
public interface IBaseRepository<T> where T : class
{
    /// <summary> Returns all entities. </summary>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary> Returns a single entity by ID, or null if not found. </summary>
    /// <param name="p_Id"> The entity identifier. </param>
    Task<T?> GetByIdAsync(int p_Id);

    /// <summary> Adds a new entity to the context. </summary>
    /// <param name="p_Entity"> The entity to create. </param>
    Task<T> CreateAsync(T p_Entity);

    /// <summary> Marks an existing entity as modified. </summary>
    /// <param name="p_Entity"> The entity to update. </param>
    Task<T> UpdateAsync(T p_Entity);

    /// <summary> Removes an entity by ID. </summary>
    /// <param name="p_Id"> The entity identifier. </param>
    Task DeleteAsync(int p_Id);

    /// <summary> Returns true if an entity with the given ID exists. </summary>
    /// <param name="p_Id"> The entity identifier. </param>
    Task<bool> ExistsAsync(int p_Id);
}