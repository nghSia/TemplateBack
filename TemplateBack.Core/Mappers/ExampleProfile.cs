using AutoMapper;
using TemplateBack.TemplateBack.Core.DTOs;
using TemplateBack.TemplateBack.Infrastrucutre.Entities;

namespace TemplateBack.TemplateBack.Core.Mappers;

/* AutoMapper profile — one profile per entity */
public class ExampleProfile : Profile
{
    public ExampleProfile()
    {
        // Entité → DTO sortant (lecture)
        CreateMap<Example, ExampleResponseDTO>();

        // DTO entrant → Entité (création)
        CreateMap<ExampleRequestDTO, Example>();
    }
}