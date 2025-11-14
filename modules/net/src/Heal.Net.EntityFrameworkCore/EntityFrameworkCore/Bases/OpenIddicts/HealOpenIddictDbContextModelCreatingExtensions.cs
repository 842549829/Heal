using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.OpenIddict.Applications;
using Volo.Abp.OpenIddict.Authorizations;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.OpenIddict.Scopes;
using Volo.Abp.OpenIddict.Tokens;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.OpenIddicts;

/// <summary>
/// OpenIddict数据库模型创建扩展
/// </summary>
public static class HealOpenIddictDbContextModelCreatingExtensions
{
    /// <summary>
    /// 配置OpenIddict数据库模型
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealOpenIddict(this ModelBuilder builder)
    {
        builder.ConfigureOpenIddict();

        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<OpenIddictApplication>(b =>
        {
            b.ToTable(x => { x.HasComment("OpenIddict-应用程序"); });

            b.Property(x => x.ApplicationType).HasComment("与应用程序关联的应用程序类型");
            b.Property(x => x.ClientId).HasComment("与当前应用程序关联的客户端标识符");
            b.Property(x => x.ClientSecret).HasComment("与当前应用程序关联的客户端密钥。注意：根据创建此实例的应用程序管理器，该属性可能出于安全原因被哈希或加密");
            b.Property(x => x.ClientType).HasComment("与应用程序关联的客户端类型");
            b.Property(x => x.ConsentType).HasComment("与当前应用程序关联的同意类型");
            b.Property(x => x.DisplayName).HasComment("与当前应用程序关联的显示名称");
            b.Property(x => x.DisplayNames).HasComment("与当前应用程序关联的本地化显示名称，序列化为 JSON 对象");
            b.Property(x => x.JsonWebKeySet).HasComment("与应用程序关联的 JSON Web Key Set，序列化为 JSON 对象");
            b.Property(x => x.Permissions).HasComment("与当前应用程序关联的权限，序列化为 JSON 数组");
            b.Property(x => x.PostLogoutRedirectUris).HasComment("与当前应用程序关联的登出回调 URL，序列化为 JSON 数组");
            b.Property(x => x.Properties).HasComment("附加属性，序列化为 JSON 对象；如果未与当前应用程序关联任何属性，则为 null");
            b.Property(x => x.RedirectUris).HasComment("与当前应用程序关联的回调 URL，序列化为 JSON 数组");
            b.Property(x => x.Requirements).HasComment("与当前应用程序关联的要求，序列化为 JSON 数组");
            b.Property(x => x.Settings).HasComment("设置，序列化为 JSON 对象");
            b.Property(x => x.ClientUri).HasComment("指向客户端更多信息的 URI");
            b.Property(x => x.LogoUri).HasComment("指向客户端标志的 URI");
            b.Property(x => x.FrontChannelLogoutUri).HasComment("前通道注销Uri");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<OpenIddictAuthorization>(b =>
        {
            b.ToTable(x => { x.HasComment("OpenIddict-授权信息"); });

            b.Property(x => x.ApplicationId).HasComment("与当前授权关联的应用程序的唯一标识符");
            b.Property(x => x.CreationDate).HasComment("当前授权的 UTC 创建日期");
            b.Property(x => x.Properties).HasComment("附加属性，序列化为 JSON 对象；如果未与当前授权关联任何属性，则为 null");
            b.Property(x => x.Scopes).HasComment("与当前授权关联的作用域，序列化为 JSON 数组");
            b.Property(x => x.Status).HasComment("当前授权的状态");
            b.Property(x => x.Subject).HasComment("与当前授权关联的主体");
            b.Property(x => x.Type).HasComment("当前授权的类型");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<OpenIddictScope>(b =>
        {
            b.ToTable(x => { x.HasComment("OpenIddict-授权范围");});
            b.Property(x => x.Description).HasComment("与当前作用域关联的公开描述");
            b.Property(x => x.Descriptions).HasComment("与当前作用域关联的本地化公开描述，序列化为 JSON 对象");
            b.Property(x => x.DisplayName).HasComment("与当前作用域关联的显示名称");
            b.Property(x => x.DisplayNames).HasComment("与当前作用域关联的本地化显示名称，序列化为 JSON 对象");
            b.Property(x => x.Name).HasComment("与当前作用域关联的唯一名称");
            b.Property(x => x.Properties).HasComment("附加属性，序列化为 JSON 对象；如果未与当前作用域关联任何属性，则为 null");
            b.Property(x => x.Resources).HasComment("与当前作用域关联的资源，序列化为 JSON 数组");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<OpenIddictToken>(b =>
        {
            b.ToTable(x => { x.HasComment("OpenIddict-颁发的Token"); });
            b.Property(x => x.ApplicationId).HasComment("与当前令牌关联的应用程序的唯一标识符");
            b.Property(x => x.AuthorizationId).HasComment("与当前令牌关联的授权的唯一标识符");
            b.Property(x => x.CreationDate).HasComment("当前令牌的 UTC 创建日期");
            b.Property(x => x.ExpirationDate).HasComment("当前令牌的 UTC 过期日期");
            b.Property(x => x.Payload).HasComment("当前令牌的有效载荷（如果适用）。注意：此属性仅用于引用令牌，可能出于安全原因被加密");
            b.Property(x => x.Properties).HasComment("附加属性，序列化为 JSON 对象；如果未与当前令牌关联任何属性，则为 null");
            b.Property(x => x.RedemptionDate).HasComment("当前令牌的 UTC 兑换日期");
            b.Property(x => x.ReferenceId).HasComment("与当前令牌关联的引用标识符（如果适用）。注意：此属性仅用于引用令牌，可能出于安全原因被哈希或加密");
            b.Property(x => x.Status).HasComment("当前令牌的状态");
            b.Property(x => x.Subject).HasComment("与当前令牌关联的主体");
            b.Property(x => x.Type).HasComment("当前令牌的类型");
            b.ConfigureByConventionBase<Guid>();
        });
    }
}