using TemplateBack.TemplateBack.Core.DTOs;
using TemplateBack.TemplateBack.Infrastrucutre.Entities;

namespace TemplateBack.TemplateBack.Core.Interfaces.Repositories;

/* Extends IBaseRepository with Example-specific queries (EF Core + Dapper) */
public interface IExampleRepository : IBaseRepository<Example>
{
    /* EF Core */
    Task<IEnumerable<Example>> GetByNameAsync(string name);

    /* Dapper — complex queries */
    Task<ExampleSummaryResponse> GetSummaryAsync(int id);
}