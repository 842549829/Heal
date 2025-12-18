using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Identity;
using Volo.Abp.Mapperly;

namespace Heal.Net.Application.Bases.Users;

/// <summary>
/// Auto mapper profile for user
/// </summary>
[Mapper]
[MapExtraProperties]
public partial class UserAutoMapper : MapperBase<IdentityUser, IdentityUserDetailDto>
{
    public override partial IdentityUserDetailDto Map(IdentityUser source);


    public override partial void Map(IdentityUser source, IdentityUserDetailDto destination);
}