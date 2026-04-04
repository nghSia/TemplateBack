namespace TemplateBack.TemplateBack.Core.DTOs;

/* Outbound DTO for Dapper reads — computed fields and aggregates */
public class ExampleSummaryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TotalItems { get; set; }
    public decimal AverageScore { get; set; }
}