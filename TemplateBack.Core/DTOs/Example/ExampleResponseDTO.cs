namespace TemplateBack.TemplateBack.Core.DTOs;

/* Outbound DTO — data sent to the client */
public class ExampleResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}