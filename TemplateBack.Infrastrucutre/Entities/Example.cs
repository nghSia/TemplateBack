namespace TemplateBack.TemplateBack.Infrastrucutre.Entities;

/* Domain entity — maps to the Examples table */
public class Example : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}