using Heal.Domain.Shared.Constants;
using OpenIddict.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.OpenIddict;

namespace Heal.Net.AuthServer.ExtensionGrantTypes
{
    /// <summary>
    /// 自定义Claims
    /// </summary>
    public class UnifiedClaimsPrincipalExtension : IAbpOpenIddictClaimsPrincipalHandler, ITransientDependency
    {
        /// <summary>
        /// 自定义Claims
        /// </summary>
        /// <param name="context">context</param>
        /// <returns>Task</returns>
        public Task HandleAsync(AbpOpenIddictClaimsPrincipalHandlerContext context)
        {
            foreach (var claim in context.Principal.Claims)
            {
                if (claim.Type == HealClaimTypesConsts.DataPermission)
                {
                    claim.SetDestinations(OpenIddictConstants.Destinations.AccessToken, OpenIddictConstants.Destinations.IdentityToken);
                }

                if (claim.Type == HealClaimTypesConsts.CustomDataPermission)
                {
                    claim.SetDestinations(OpenIddictConstants.Destinations.AccessToken, OpenIddictConstants.Destinations.IdentityToken);
                }
            }

            return Task.CompletedTask;
        }
    }
}
