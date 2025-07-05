using Heal.Core.Domain.Bases.Roles.Managers;
using Heal.Core.Domain.Bases.Users.Managers;
using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Heal.Net.Application.Contracts.Bases.Users;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;

namespace Heal.Net.Application.Bases.Users;

/// <summary>
/// 用户服务
/// </summary>
/// <param name="userManager">用户管理</param>
/// <param name="roleManager">角色管理</param>
/// <param name="identityOptions">配置</param>
public class UserAppService(
    HealUserManager userManager,
    HealRoleManager roleManager,
    IOptions<IdentityOptions> identityOptions)
    : HealNetAppService, IUserAppService
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户创建信息</param>
    /// <returns>用户</returns>
    public async Task<IdentityUserDto> CreateAsync(UserCreateDto input)
    {
        await identityOptions.SetAsync();
        var user = new IdentityUser(
            GuidGenerator.Create(),
            input.UserName,
            input.Email,
            CurrentTenant.Id
        );
        input.MapExtraPropertiesTo(user);
        (await userManager.CreateAsync(user, input.Password)).CheckErrors();
        await UpdateUserByInput(user, input);
        await userManager.SetRolesAsync(user, input.RoleNames);
        await CurrentUnitOfWork?.SaveChangesAsync()!;
        return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input"></param>
    /// <returns>用户</returns>
    public virtual async Task<IdentityUserDto> UpdateAsync(Guid id, UserUpdateDto input)
    {
        await identityOptions.SetAsync();

        var user = await userManager.GetByIdAsync(id);

        user.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

        (await userManager.SetUserNameAsync(user, input.UserName)).CheckErrors();

        await UpdateUserByInput(user, input);
        input.MapExtraPropertiesTo(user);

        (await userManager.UpdateAsync(user)).CheckErrors();

        if (!input.Password.IsNullOrEmpty())
        {
            (await userManager.RemovePasswordAsync(user)).CheckErrors();
            (await userManager.AddPasswordAsync(user, input.Password)).CheckErrors();
        }

        await userManager.SetRolesAsync(user, input.RoleNames);

        await CurrentUnitOfWork?.SaveChangesAsync()!;

        return ObjectMapper.Map<IdentityUser, IdentityUserDto>(user);
    }

    /// <summary>
    /// 获取用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>用户</returns>
    public async Task<IdentityUserDto> GetAsync(Guid id)
    {
        return ObjectMapper.Map<IdentityUser, IdentityUserDto>(
            await userManager.GetByIdAsync(id)
        );
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>用户列表</returns>
    public async Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
    {
        var count = await userManager.GetCountAsync(input.Filter);
        var list = await userManager.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
            input.Filter);
        return new PagedResultDto<IdentityUserDto>(
            count,
            ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(list)
        );
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>Task</returns>
    public async Task DeleteAsync(Guid id)
    {
        if (CurrentUser.Id == id)
        {
            throw new BusinessException(code: IdentityErrorCodes.UserSelfDeletion);
        }

        var user = await userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return;
        }

        (await userManager.DeleteAsync(user)).CheckErrors();
    }

    /// <summary>
    /// 获取用户角色
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>用户角色</returns>
    public async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
    {
        var roles = await userManager.GetRolesAsync(id);
        return new ListResultDto<IdentityRoleDto>(
            ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(roles));
    }

    /// <summary>
    /// 获取可分配角色
    /// </summary>
    /// <returns>用户角色</returns>
    public async Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
    {
        var list = await roleManager.GetListAsync();
        return new ListResultDto<IdentityRoleDto>(
            ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(list));
    }

    /// <summary>
    /// 更新用户角色
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input">更新信息</param>
    /// <returns>用户角色</returns>
    public async Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
    {
        var user = await userManager.GetByIdAsync(id);
        (await userManager.SetRolesAsync(user, input.RoleNames)).CheckErrors();
        await userManager.UpdateAsync(user);
    }

    /// <summary>
    /// 根据用户名查找用户
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <returns>用户</returns>
    public async Task<IdentityUserDto?> FindByUsernameAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        return user != null ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(user) : null;
    }

    /// <summary>
    /// 根据邮箱查找用户
    /// </summary>
    /// <param name="email">邮箱</param>
    /// <returns>用户</returns>
    public async Task<IdentityUserDto?> FindByEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        //var xxx = user!.GetProperty<string>("xxx"); // 获取值
        //user!.SetProperty("xxx", "xx"); // 设置值
        return user != null ? ObjectMapper.Map<IdentityUser, IdentityUserDto>(user) : null;
    }

    /// <summary>
    /// 获取用户详情
    /// </summary>
    /// <param name="id">用户id</param>
    public async Task<IdentityUserDetailDto> GetAsyncDetail(Guid id)
    {
        var identityUser = await userManager.GetAsync(id);
        var detail = ObjectMapper.Map<IdentityUser, IdentityUserDetailDto>(identityUser);
        //var organization = await userManager.GetOrganizationUnitsAsync(identityUser);
        //detail.OrganizationId = organization.FirstOrDefault()?.Id;
        var roles = await userManager.GetRolesAsync(identityUser);
        detail.RoleNames = roles.ToArray();
        return detail;
    }

    /// <summary>
    /// 更新用户头像
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input">更新信息</param>
    /// <returns>Task</returns>
    public async Task UpdateAvatarAsync(Guid id, UserAvatarUpdateDto input)
    {
        await identityOptions.SetAsync();

        var user = await userManager.GetByIdAsync(id);

        user.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

        input.MapExtraPropertiesTo(user);

        (await userManager.UpdateAsync(user)).CheckErrors();

        await CurrentUnitOfWork?.SaveChangesAsync()!;
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>用户列表</returns>
    public async Task<IEnumerable<SearchUserOutputDto>> GetUsersAsync(SearchUserListInputDto input)
    {
        var list = await userManager.GetListAsync(input.Sorting, input.MaxResultCount, 0,
            input.Filter);
        var users = list.Select(u => new SearchUserOutputDto()
        {
            Id = u.Id,
            UserName = u.UserName,
            FullName = $"{u.UserName}{u.Surname}"
        });
        return users;
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <returns>角色列表</returns>
    public async Task<IEnumerable<RoleDto>> GetRoleAsync()
    {
        var list = await roleManager.GetListAsync(null, 999);
        return ObjectMapper.Map<List<IdentityRole>, IEnumerable<RoleDto>>(list);
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="user">user</param>
    /// <param name="input">input</param>
    /// <returns>Task</returns>
    private async Task UpdateUserByInput(IdentityUser user, IdentityUserCreateOrUpdateDtoBase input)
    {
        if (!string.Equals(user.Email, input.Email, StringComparison.InvariantCultureIgnoreCase))
        {
            (await userManager.SetEmailAsync(user, input.Email)).CheckErrors();
        }

        if (!string.Equals(user.PhoneNumber, input.PhoneNumber, StringComparison.InvariantCultureIgnoreCase))
        {
            (await userManager.SetPhoneNumberAsync(user, input.PhoneNumber)).CheckErrors();
        }

        if (user.Id != CurrentUser.Id)
        {
            (await userManager.SetLockoutEnabledAsync(user, input.LockoutEnabled)).CheckErrors();
        }

        user.Name = input.Name;
        user.Surname = input.Surname;
        (await userManager.UpdateAsync(user)).CheckErrors();
        user.SetIsActive(input.IsActive);
        if (input.RoleNames != null)
        {
            (await userManager.SetRolesAsync(user, input.RoleNames)).CheckErrors();
        }
    }
}