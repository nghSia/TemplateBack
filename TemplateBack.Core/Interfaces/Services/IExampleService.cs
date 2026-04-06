using TemplateBack.TemplateBack.Core.DTOs;

namespace TemplateBack.TemplateBack.Core.Interfaces.Services;

/* Business logic contract exposed to controllers */
public interface IExampleService
{
    /// <summary> Returns all examples mapped to response DTOs. </summary>
    Task<IEnumerable<ExampleResponseDTO>> GetAllAsync();

    /// <summary> Returns a single example by ID, or null if not found. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    Task<ExampleResponseDTO?> GetByIdAsync(int p_Id);

    /// <summary> Creates a new example and returns the persisted result as a DTO. </summary>
    /// <param name="p_Request"> The data for the example to create. </param>
    Task<ExampleResponseDTO> CreateAsync(ExampleRequestDTO p_Request);

    /// <summary> Updates an existing example and returns the updated result as a DTO. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    /// <param name="p_Request"> The updated data. </param>
    Task<ExampleResponseDTO> UpdateAsync(int p_Id, ExampleRequestDTO p_Request);

    /// <summary> Returns an aggregated summary for an example using a raw SQL query. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    Task<ExampleSummaryResponse> GetSummaryAsync(int p_Id);

    /// <summary> Deletes an example by ID. Throws if not found. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    Task DeleteAsync(int p_Id);
}