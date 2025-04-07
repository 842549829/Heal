using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Net.Domain.Bases.Permissions.Managers;
using System.Security.Claims;
using System.Security.Principal;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;

namespace Heal.Net.AuthServer.ExtensionGrantTypes;

/// <summary>
/// UnifiedClaimsPrincipalContributor
/// </summary>
public class UnifiedClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
{
    /// <summary>
    /// ContributeAsync
    /// </summary>
    /// <param name="context">context</param>
    /// <returns>Task</returns>
    public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
    {
        var identity = context.ClaimsPrincipal.Identities.FirstOrDefault();
        var userId = identity?.FindUserId();
        var userManager = context.ServiceProvider.GetRequiredService<IdentityUserManager>();
        var user = await userManager.GetUserAsync(context.ClaimsPrincipal);
        if (user != null && identity != null && userId.HasValue)
        {
            // 获取数据权限
            var (dataPermission, dataPermissionCode) = await GetDataPermission(context);
            identity.AddClaim(new Claim(HealClaimTypesConsts.DataPermission, dataPermission.GetHashCode().ToString()));
            foreach (var code in dataPermissionCode)
            {
                if (!string.IsNullOrEmpty(code))
                {
                    identity.AddClaim(new Claim(HealClaimTypesConsts.CustomDataPermission, code));
                }
            }
        }
    }

    /// <summary>
    /// GetDataPermission
    /// </summary>
    /// <param name="context">context</param>
    /// <returns>dataPermission, dataPermissionCode</returns>
    private static async Task<(DataPermission, string[])> GetDataPermission(AbpClaimsPrincipalContributorContext context)
    {
        var roles = context.ClaimsPrincipal.Claims.Where(a => a.Type == AbpClaimTypes.Role).Select(a => a.Value).ToArray();
        var dataPermissionManager = context.ServiceProvider.GetRequiredService<INetDataPermissionManager>();
        var(dataPermission, dataPermissionCode) = await dataPermissionManager.GetDataPermissionsAsync(roles);
        return (dataPermission, dataPermissionCode);
    }
}