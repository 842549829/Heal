using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Heal.Domain.Entities;

/// <summary>
/// 实体扩展
/// </summary>
public static class EntityExtension
{
    /// <summary>
    /// 设置实体的编码
    /// </summary>
    /// <param name="entity">entity</param>
    /// <param name="code">编码</param>
    public static void TrySeCode(IEntity entity, string code)
    {
        if (entity is not IHasCode hasCodeEntity)
        {
            return;
        }

        ObjectHelper.TrySetProperty(
            hasCodeEntity,
            x => x.Code,
            () => code
        );
    }

    /// <summary>
    /// 设置实体的编码
    /// </summary>
    /// <param name="entity">entity</param>
    /// <param name="code">编码</param>
    public static void TrySetOrganizationCode(OrganizationUnit entity, string code)
    {
        ObjectHelper.TrySetProperty(
            entity,
            x => x.Code,
            () => code
        );
    }
}