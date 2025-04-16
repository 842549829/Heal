using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Identities;

/// <summary>
/// IdentityDbContextModelBuilderExtensions
/// </summary>
public static class HealIdentityDbContextModelBuilderExtensions
{
    /// <summary>
    /// ConfigureHealIdentity
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealIdentity(this ModelBuilder builder)
    {
        builder.ConfigureIdentity();

        builder.Entity<IdentityUser>(b =>
        {
            b.ToTable(x => { x.HasComment("用户表"); });
            b.Property(u => u.UserName).HasComment("用户名");
            b.Property(u => u.Name).HasComment("名");
            b.Property(u => u.NormalizedUserName).HasComment("用户名标准名");
            b.Property(u => u.NormalizedEmail).HasComment("邮箱标准名称");
            b.Property(u => u.PasswordHash).HasComment("密码散列");
            b.Property(u => u.SecurityStamp).HasComment("安全票据");
            b.Property(u => u.LockoutEnabled).HasComment("锁定");
            b.Property(u => u.IsExternal).HasComment("是否外部");
            b.Property(u => u.AccessFailedCount).HasComment("错误登录次数");
            b.Property(u => u.EmailConfirmed).HasComment("邮箱确认");
            b.Property(u => u.Email).HasComment("邮箱");
            b.Property(u => u.PhoneNumber).HasComment("手机号码");
            b.Property(u => u.PhoneNumberConfirmed).HasComment("手机号码确认");
            b.Property(u => u.TwoFactorEnabled).HasComment("双因素认证");
            b.Property(u => u.LockoutEnd).HasComment("锁定到期时间");
            b.Property(u => u.IsActive).HasComment("是否活跃");
            b.Property(u => u.Surname).HasComment("姓");
            b.Property(u => u.ShouldChangePasswordOnNextLogin).HasComment("是否需要更改密码");
            b.Property(u => u.EntityVersion).HasComment("版本");
            b.Property(u => u.LastPasswordChangeTime).HasComment("最后修改密码时间");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentityUserClaim>(b =>
        {
            b.ToTable(x => x.HasComment("用户声明表"));
            b.Property(uc => uc.ClaimType).HasComment("声明类型");
            b.Property(uc => uc.ClaimValue).HasComment("声明值");
            b.Property(uc => uc.UserId).HasComment("用户Id");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentityUserRole>(b =>
        {
            b.ToTable(x => x.HasComment("用户角色关系表"));
            b.Property(x => x.UserId).HasComment("用户Id");
            b.Property(x => x.RoleId).HasComment("角色Id");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentityUserLogin>(b =>
        {
            b.ToTable(x => { x.HasComment("外部登录"); });
            b.Property(ul => ul.UserId).HasComment("用户Id");
            b.Property(ul => ul.LoginProvider).HasComment("登录提供者");
            b.Property(ul => ul.ProviderKey).HasComment("登录提供者Key");
            b.Property(ul => ul.ProviderDisplayName).HasComment("登录提供者显示名称");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentityUserToken>(b =>
        {
            b.ToTable(x => { x.HasComment("外部服务生成的令牌"); });
            b.Property(ul => ul.UserId).HasComment("用户Id");
            b.Property(ul => ul.LoginProvider).HasComment("登录提供者");
            b.Property(ul => ul.Name).HasComment("名称");
            b.Property(ul => ul.Value).HasComment("值");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentityRole>(b =>
        {
            b.ToTable(x => { x.HasComment("角色表"); });
            b.Property(r => r.Name).HasComment("名称");
            b.Property(r => r.NormalizedName).HasComment("标准名称");
            b.Property(r => r.IsDefault).HasComment("是否默认");
            b.Property(r => r.IsStatic).HasComment("是否静态");
            b.Property(r => r.IsPublic).HasComment("是否公共");
            b.Property(r => r.EntityVersion).HasComment("版本");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentityRoleClaim>(b =>
        {
            b.ToTable(x => { x.HasComment("角色声明表"); });
            b.Property(uc => uc.ClaimType).HasComment("声明类型");
            b.Property(uc => uc.ClaimValue).HasComment("声明值");
            b.Property(uc => uc.RoleId).HasComment("角色Id");
            b.ConfigureByConventionBase<Guid>();
        });

        if (builder.IsHostDatabase())
        {
            builder.Entity<IdentityClaimType>(b =>
            {
                b.ToTable(x => { x.HasComment("声明类型表"); });
                b.Property(uc => uc.Name).HasComment("名称");
                b.Property(uc => uc.Regex).HasComment("正则表达式");
                b.Property(uc => uc.RegexDescription).HasComment("正则表达式描述");
                b.Property(uc => uc.Description).HasComment("描述");
                b.Property(uc => uc.IsStatic).HasComment("是否静态");
                b.Property(uc => uc.Required).HasComment("是否必填");
                b.Property(uc => uc.ValueType).HasComment("值类型");
                b.ConfigureByConventionBase<Guid>();
            });
        }

        builder.Entity<OrganizationUnit>(b =>
        {
            b.ToTable(x => { x.HasComment("组织机构"); });
            b.Property(ou => ou.Code).HasComment("编码");
            b.Property(ou => ou.DisplayName).HasComment("显示名称");
            b.Property(ou => ou.ParentId).HasComment("父级Id");
            b.Property(ou => ou.EntityVersion).HasComment("版本");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<OrganizationUnitRole>(b =>
        {
            b.ToTable(x => { x.HasComment("组织机构角色"); });
            b.Property(uc => uc.RoleId).HasComment("角色Id");
            b.Property(uc => uc.OrganizationUnitId).HasComment("组织机构Id");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentityUserOrganizationUnit>(b =>
        {
            b.ToTable(x => { x.HasComment("用户组织机构关系表"); });
            b.Property(uc => uc.UserId).HasComment("用户Id");
            b.Property(uc => uc.OrganizationUnitId).HasComment("组织机构Id");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentitySecurityLog>(b =>
        {
            b.ToTable(x => { x.HasComment("身份安全日志"); });
            b.Property(x => x.TenantName).HasComment("租户名称");
            b.Property(uc => uc.BrowserInfo).HasComment("浏览器信息");
            b.Property(uc => uc.ClientIpAddress).HasComment("客户端IP地址");
            b.Property(uc => uc.ClientId).HasComment("客户端Id");
            b.Property(uc => uc.Action).HasComment("操作Action");
            b.Property(uc => uc.CorrelationId).HasComment("相关Id");
            b.Property(uc => uc.ApplicationName).HasComment("应用模块名称");
            b.Property(uc => uc.Identity).HasComment("身份信息");
            b.Property(uc => uc.UserId).HasComment("用户Id");
            b.Property(uc => uc.UserName).HasComment("用户名");
            b.ConfigureByConventionBase<Guid>();
        });

        if (builder.IsHostDatabase())
        {
            builder.Entity<IdentityLinkUser>(b =>
            {
                b.ToTable(x => { x.HasComment("管理用户之间的关联关系"); });
                b.Property(x => x.SourceTenantId).HasComment("源租户");
                b.Property(x => x.SourceUserId).HasComment("源用户Id");
                b.Property(x => x.TargetUserId).HasComment("目标用户Id");
                b.Property(x => x.TargetTenantId).HasComment("目标租户");
                b.ConfigureByConventionBase<Guid>();
            });
        }

        builder.Entity<IdentityUserDelegation>(b =>
        {
            b.ToTable(x => { x.HasComment("管理用户之间的委托关系"); });
            b.Property(x => x.SourceUserId).HasComment("源用户Id");
            b.Property(x => x.TargetUserId).HasComment("目标用户Id");
            b.Property(x => x.StartTime).HasComment("开始时间");
            b.Property(x => x.EndTime).HasComment("结束时间");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<IdentitySession>(b =>
        {
            b.ToTable(x => { x.HasComment("会话信息"); });
            b.Property(x => x.TenantId).HasComment("租户Id");
            b.Property(x => x.UserId).HasComment("用户Id");
            b.Property(x => x.SessionId).HasComment("会话Id");
            b.Property(x => x.ClientId).HasComment("客户端Id");
            b.Property(x => x.Device).HasComment("设备");
            b.Property(x => x.DeviceInfo).HasComment("设备信息");
            b.Property(x => x.IpAddresses).HasComment("Ip地址");
            b.Property(x => x.LastAccessed).HasComment("用户最近一次访问系统的时间");
            b.Property(x => x.SignedIn).HasComment("用户登录的时间");
            b.ConfigureByConventionBase<Guid>();
        });
    }
}