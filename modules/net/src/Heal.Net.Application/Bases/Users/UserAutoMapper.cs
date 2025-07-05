using AutoMapper;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using Volo.Abp.Identity;

namespace Heal.Net.Application.Bases.Users;

/// <summary>
/// Auto mapper profile for user
/// </summary>
public class UserAutoMapper : Profile
{
    /// <summary>
    /// Auto mapper profile for user
    /// </summary>
    public UserAutoMapper()
    {
        CreateMap<IdentityUser, IdentityUserDetailDto>();
    }
}