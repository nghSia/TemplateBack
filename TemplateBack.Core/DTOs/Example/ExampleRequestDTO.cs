using System.ComponentModel.DataAnnotations;

namespace TemplateBack.TemplateBack.Core.DTOs;

/* Inbound DTO — data sent by the client */
public class ExampleRequestDTO
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }
}