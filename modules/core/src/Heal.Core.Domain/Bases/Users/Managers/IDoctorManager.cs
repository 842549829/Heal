using Heal.Core.Domain.Bases.Users.Entities;

namespace Heal.Core.Domain.Bases.Users.Managers;

/// <summary>
/// 医生管理
/// </summary>
public interface IDoctorManager : IHealCoreDomainManager
{
    /// <summary>
    ///  创建医生
    /// </summary>
    /// <param name="doctor">doctor</param>
    /// <returns>Task</returns>
    Task<Doctor> CreateAsync(Doctor doctor);
}