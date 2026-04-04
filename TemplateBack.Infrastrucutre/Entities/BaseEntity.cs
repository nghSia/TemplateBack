namespace TemplateBack.TemplateBack.Infrastrucutre.Entities;

/* Base entity inherited by all domain entities */
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}