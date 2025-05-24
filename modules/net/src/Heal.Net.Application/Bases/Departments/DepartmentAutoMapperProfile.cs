using AutoMapper;
using Heal.Core.Domain.Bases.Departments.Entities;
using Heal.Net.Application.Contracts.Bases.Departments.Dto;

namespace Heal.Net.Application.Bases.Departments;

/// <summary>
/// AutoMapper配置
/// </summary>
public class DepartmentAutoMapperProfile : Profile
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public DepartmentAutoMapperProfile()
    {
        CreateMap<Department, DepartmentDto>();
        CreateMap<Department, DepartmentListDto>();
    }
}