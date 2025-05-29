using Heal.Core.Domain.Bases.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Identity;

namespace Heal.Core.Domain.Bases.Users.Managers;

/// <summary>
/// 医生管理
/// </summary>
public class DoctorManager(HealUserManager userManager) : HealCoreDomainManager, IDoctorManager
{
    /// <summary>
    ///  创建医生
    /// </summary>
    /// <param name="doctor">doctor</param>
    /// <returns>Task</returns>
    public async Task<Doctor> CreateAsync(Doctor doctor)
    {
        // 创建医生



        // 是否开通登录
        if (doctor.IsOpenLogin)
        {
            var user = new IdentityUser(
                GuidGenerator.Create(),
                doctor.Code,
                doctor.Email,
                CurrentTenant.Id
            );
            (await userManager.CreateAsync(user, "")).CheckErrors();
            if (!string.Equals(user.Email, doctor.Email, StringComparison.InvariantCultureIgnoreCase))
            {
                (await userManager.SetEmailAsync(user, doctor.Email)).CheckErrors();
            }

            if (!string.Equals(user.PhoneNumber, doctor.Phone, StringComparison.InvariantCultureIgnoreCase))
            {
                (await userManager.SetPhoneNumberAsync(user, doctor.Phone)).CheckErrors();
            }

            //var organizationRelationshipList = input.OrganizationRelationship.GetRelationshipsByType(OrganizationType.Organization);
            //foreach (var relationship in organizationRelationshipList)
            //{
            //    await userManager.AddToOrganizationUnitAsync(user.Id, relationship.Id);
            //}
        }
        throw new NotImplementedException();
    }
}