using AutoMapper;
using TemplateBack.TemplateBack.Core.DTOs;
using TemplateBack.TemplateBack.Core.Models;
using TemplateBack.TemplateBack.Infrastrucutre.Entities;

namespace TemplateBack.TemplateBack.Core.Mappers;

/* AutoMapper profile */
public class ExampleProfile : Profile
{
    public ExampleProfile()
    {
        CreateMap<Example, ExampleModel>();
        CreateMap<ExampleModel, Example>();

        CreateMap<ExampleModel, ExampleResponseDTO>();
        CreateMap<ExampleRequestDTO, ExampleModel>();
    }
}
