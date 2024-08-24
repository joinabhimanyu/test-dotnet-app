using System;
using AutoMapper;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;
using test_dotnet_app.Repositories.DepartmentFeature;

namespace test_dotnet_app.Services.DepartmentFeature;

public class DepartmentService: IDepartmentService
{
    private readonly ILogger<DepartmentService> _logger;
    // private readonly IMapper _mapper;
    private readonly IDepartmentRepository _repository;
    public DepartmentService(ILogger<DepartmentService> logger, IDepartmentRepository repository) //IMapper mapper
    {
        _logger = logger;
        // _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync(bool include)
    {
        var departments = await _repository.GetAllAsync(include);
        return departments.MapTo();
        // var departmentsDto=_mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }

    public async Task<DepartmentDto?> GetByIdAsync(int id, bool include)
    {
        var department = await _repository.GetByIdAsync(id, include);
        return department.MapTo();
        // var result=_mapper.Map<DepartmentDto>(department);
    }

    public async Task<IEnumerable<DepartmentDto>?> SearchAsync(List<SearchParam>? searchParams, bool include)
    {
        var departments = await _repository.SearchAsync(searchParams, include);
        return departments!.MapTo();
        // var results=_mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }

    public async Task AddAsync(DepartmentDto department)
    {
        var departmentEntity=department.MapFrom();
        // var departmentEntity=_mapper.Map<Department>(department);
        await _repository.AddAsync(departmentEntity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task UpdateAsync(DepartmentDto department)
    {
        var departmentEntity=department.MapFrom();
        // var departmentEntity=_mapper.Map<Department>(department);
        await _repository.UpdateAsync(departmentEntity);
    }
}
