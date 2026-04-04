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
    public ExampleRepository(BaseContext context, IDbConnection db)
        : base(context, db) { }

    /* EF Core — filtered query */
    public async Task<IEnumerable<Example>> GetByNameAsync(string name)
        => await DbSet.AsNoTracking()
            .Where(e => e.Name.Contains(name))
            .ToListAsync();
    
    /* Dapper — complex query with aggregates */
    public async Task<ExampleSummaryResponse> GetSummaryAsync(int id)
    {
        var sql = @"SELECT e.Id, e.Name,
                           COUNT(r.Id)      AS TotalItems,
                           AVG(r.Score)     AS AverageScore
                    FROM Examples e
                    LEFT JOIN ExampleRelated r ON r.ExampleId = e.Id
                    WHERE e.Id = @id
                    GROUP BY e.Id, e.Name";

        return await m_DbConnection.QueryFirstOrDefaultAsync<ExampleSummaryResponse>(sql, new { id });
    }
}