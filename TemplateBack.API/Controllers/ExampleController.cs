using Microsoft.AspNetCore.Mvc;
using TemplateBack.TemplateBack.Core.DTOs;
using TemplateBack.TemplateBack.Core.Interfaces.Services;

namespace TemplateBack.TemplateBack.API.Controllers;

/* REST controller */
[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IExampleService m_ExampleService;

    public ExampleController(IExampleService p_ExampleService)
    {
        m_ExampleService = p_ExampleService;
    }

    /// <summary> Returns all examples. </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await m_ExampleService.GetAllAsync());

    /// <summary> Returns a single example by ID. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    [HttpGet("{p_Id}")]
    public async Task<IActionResult> GetById(int p_Id)
    {
        ExampleResponseDTO v_Result = await m_ExampleService.GetByIdAsync(p_Id);
        return v_Result is null ? NotFound() : Ok(v_Result);
    }

    /// <summary> Returns an aggregated summary of an example using a Dapper query. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    [HttpGet("{p_Id}/summary")]
    public async Task<IActionResult> GetSummary(int p_Id)
        => Ok(await m_ExampleService.GetSummaryAsync(p_Id));

    /// <summary> Creates a new example and returns it with its generated ID. </summary>
    /// <param name="p_Request"> The data for the example to create. </param>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ExampleRequestDTO p_Request)
    {
        ExampleResponseDTO v_Created = await m_ExampleService.CreateAsync(p_Request);
        return CreatedAtAction(nameof(GetById), new { p_Id = v_Created.Id }, v_Created);
    }

    /// <summary> Updates an existing example and returns the updated result. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    /// <param name="p_Request"> The updated data. </param>
    [HttpPut("{p_Id}")]
    public async Task<IActionResult> Update(int p_Id, [FromBody] ExampleRequestDTO p_Request)
        => Ok(await m_ExampleService.UpdateAsync(p_Id, p_Request));

    /// <summary> Deletes an example by ID. </summary>
    /// <param name="p_Id"> The example identifier. </param>
    [HttpDelete("{p_Id}")]
    public async Task<IActionResult> Delete(int p_Id)
    {
        await m_ExampleService.DeleteAsync(p_Id);
        return NoContent();
    }
}