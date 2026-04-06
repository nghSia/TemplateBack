using TemplateBack.TemplateBack.Core.DTOs;
using TemplateBack.TemplateBack.Infrastrucutre.Entities;

namespace TemplateBack.TemplateBack.Core.Interfaces.Repositories;

/* Extends IBaseRepository with Example-specific queries (EF Core + Dapper) */
public interface IExampleRepository : IBaseRepository<Example>
{
    /// <summary> Returns all examples whose name contains the given string. </summary>
    /// <param name="p_Name"> The substring to search for in the name. </param>
    Task<IEnumerable<Example>> GetByNameAsync(string p_Name);

    /// <summary> Returns an aggregated summary for an example using a raw SQL query. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    Task<ExampleSummaryResponse> GetSummaryAsync(int p_Id);
}