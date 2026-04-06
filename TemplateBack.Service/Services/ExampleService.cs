using AutoMapper;
using TemplateBack.TemplateBack.Core.DTOs;
using TemplateBack.TemplateBack.Core.Interfaces;
using TemplateBack.TemplateBack.Core.Interfaces.Services;
using TemplateBack.TemplateBack.Core.Models;
using TemplateBack.TemplateBack.Infrastrucutre.Entities;

namespace TemplateBack.TemplateBack.Service.Services;

/* Business logic implementation — uses IUnitOfWork, works exclusively with Models */
public class ExampleService : IExampleService
{
    private readonly IUnitOfWork m_UnitOfWork;
    private readonly IMapper m_Mapper;

    public ExampleService(IUnitOfWork p_UnitOfWork, IMapper p_Mapper)
    {
        m_UnitOfWork = p_UnitOfWork;
        m_Mapper = p_Mapper;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ExampleResponseDTO>> GetAllAsync()
    {
        IEnumerable<Example> v_Entities = await m_UnitOfWork.Examples.GetAllAsync();
        IEnumerable<ExampleModel> v_Models = m_Mapper.Map<IEnumerable<ExampleModel>>(v_Entities);
        return m_Mapper.Map<IEnumerable<ExampleResponseDTO>>(v_Models);
    }

    /// <inheritdoc/>
    public async Task<ExampleResponseDTO?> GetByIdAsync(int p_Id)
    {
        Example? v_Entity = await m_UnitOfWork.Examples.GetByIdAsync(p_Id);
        if (v_Entity is null) return null;

        ExampleModel v_Model = m_Mapper.Map<ExampleModel>(v_Entity);
        return m_Mapper.Map<ExampleResponseDTO>(v_Model);
    }

    /// <inheritdoc/>
    public async Task<ExampleSummaryResponse> GetSummaryAsync(int p_Id)
        => await m_UnitOfWork.Examples.GetSummaryAsync(p_Id);

    /// <inheritdoc/>
    public async Task<ExampleResponseDTO> CreateAsync(ExampleRequestDTO p_Request)
    {
        /* 1. DTO → Model */
        ExampleModel v_Model = m_Mapper.Map<ExampleModel>(p_Request);

        /* 2. Apply business rules if needed */

        /* 3. Model → Entity, persist */
        Example v_Entity = m_Mapper.Map<Example>(v_Model);
        await m_UnitOfWork.Examples.CreateAsync(v_Entity);
        await m_UnitOfWork.SaveChangesAsync();

        /* 4. Entity → Model → DTO */
        ExampleModel v_Created = m_Mapper.Map<ExampleModel>(v_Entity);
        return m_Mapper.Map<ExampleResponseDTO>(v_Created);
    }

    /// <inheritdoc/>
    public async Task<ExampleResponseDTO> UpdateAsync(int p_Id, ExampleRequestDTO p_Request)
    {
        Example v_Entity = await m_UnitOfWork.Examples.GetByIdAsync(p_Id)
            ?? throw new KeyNotFoundException($"Example {p_Id} not found.");

        /* Entity → Model, apply changes from DTO */
        ExampleModel v_Model = m_Mapper.Map<ExampleModel>(v_Entity);
        m_Mapper.Map(p_Request, v_Model);

        /* Model → Entity, persist */
        m_Mapper.Map(v_Model, v_Entity);
        v_Entity.UpdatedAt = DateTime.UtcNow;

        await m_UnitOfWork.Examples.UpdateAsync(v_Entity);
        await m_UnitOfWork.SaveChangesAsync();

        return m_Mapper.Map<ExampleResponseDTO>(v_Model);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(int p_Id)
    {
        if (!await m_UnitOfWork.Examples.ExistsAsync(p_Id))
            throw new KeyNotFoundException($"Example {p_Id} not found.");

        await m_UnitOfWork.Examples.DeleteAsync(p_Id);
        await m_UnitOfWork.SaveChangesAsync();
    }
}