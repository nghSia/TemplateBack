using TemplateBack.TemplateBack.Core.DTOs;

namespace TemplateBack.TemplateBack.Core.Interfaces.Services;

/* Business logic contract exposed to controllers — DTOs only, no entities */
public interface IExampleService
{
    Task<IEnumerable<ExampleResponseDTO>> GetAllAsync();
    Task<ExampleResponseDTO?> GetByIdAsync(int id);
    Task<ExampleResponseDTO> CreateAsync(ExampleRequestDTO request);
    Task<ExampleResponseDTO> UpdateAsync(int id, ExampleRequestDTO request);
    Task DeleteAsync(int id);
}