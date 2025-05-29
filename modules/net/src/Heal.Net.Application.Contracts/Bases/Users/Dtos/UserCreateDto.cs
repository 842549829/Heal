using Volo.Abp.Identity;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 创建用户
/// </summary>
public class UserCreateDto : IdentityUserCreateDto
{

    /* 用户和组织没有关系(医护人员和患者和组织有关系)
     * 患者只和机构有关系
     * 医护人员和机构关系 n-m
     * 医护人员和院区关系 n-m
     * 医护人员和科室关系 n-m
     * 用户和角色关系 n-m
     * 用户和医护人员关系 1-1
     * 用户和患者关系 1-1
     */

    ///// <summary>
    ///// 组织关系
    ///// </summary>
    //public required List<OrganizationRelationship> OrganizationRelationship { get; init; }
}