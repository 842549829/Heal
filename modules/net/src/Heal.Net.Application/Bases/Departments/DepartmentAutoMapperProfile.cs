using Heal.Core.Domain.Bases.Departments.Entities;
using Heal.Net.Application.Contracts.Bases.Departments.Dto;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Mapperly;

namespace Heal.Net.Application.Bases.Departments;

/// <summary>
/// AutoMapper配置
/// </summary>
public partial class DepartmentAutoMapperProfile : IAbpMapperlyMapper<Department, DepartmentDto>, IAbpMapperlyMapper<Department, DepartmentListDto>, ITransientDependency
{
    DepartmentDto IAbpMapperlyMapper<Department, DepartmentDto>.Map(Department source)
    {
        throw new NotImplementedException();
    }

    public void Map(Department source, DepartmentListDto destination)
    {
        throw new NotImplementedException();
    }

    void IAbpMapperlyMapper<Department, DepartmentListDto>.BeforeMap(Department source)
    {
        throw new NotImplementedException();
    }

    public void AfterMap(Department source, DepartmentListDto destination)
    {
        throw new NotImplementedException();
    }

    public void Map(Department source, DepartmentDto destination)
    {
        throw new NotImplementedException();
    }

    DepartmentListDto IAbpMapperlyMapper<Department, DepartmentListDto>.Map(Department source)
    {
        throw new NotImplementedException();
    }

    void IAbpMapperlyMapper<Department, DepartmentDto>.BeforeMap(Department source)
    {
        throw new NotImplementedException();
    }

    public void AfterMap(Department source, DepartmentDto destination)
    {
        throw new NotImplementedException();
    }
}