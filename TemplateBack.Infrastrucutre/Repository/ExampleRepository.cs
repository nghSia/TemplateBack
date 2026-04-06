using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TemplateBack.TemplateBack.Core.DTOs;
using TemplateBack.TemplateBack.Core.Interfaces.Repositories;
using TemplateBack.TemplateBack.Infrastrucutre.Context;
using TemplateBack.TemplateBack.Infrastrucutre.Entities;

namespace TemplateBack.TemplateBack.Infrastrucutre.Repository;

/* Example repository — EF Core for CRUD, Dapper for complex reads */
public class ExampleRepository : BaseRepository<Example>, IExampleRepository
{
    public ExampleRepository(BaseContext p_Context, IDbConnection p_Db)
        : base(p_Context, p_Db) { }

    /// <inheritdoc/>
    public async Task<IEnumerable<Example>> GetByNameAsync(string p_Name)
        => await DbSet.AsNoTracking()
            .Where(e => e.Name.Contains(p_Name))
            .ToListAsync();

    /// <inheritdoc/>
    public async Task<ExampleSummaryResponse> GetSummaryAsync(int p_Id)
    {
        string v_Sql = @"SELECT e.Id, e.Name,
                           COUNT(r.Id)      AS TotalItems,
                           AVG(r.Score)     AS AverageScore
                    FROM Examples e
                    LEFT JOIN ExampleRelated r ON r.ExampleId = e.Id
                    WHERE e.Id = @p_Id
                    GROUP BY e.Id, e.Name";

        return await m_DbConnection.QueryFirstOrDefaultAsync<ExampleSummaryResponse>(v_Sql, new { p_Id });
    }
}