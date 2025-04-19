namespace Heal.Net.Application.Contracts.Permissions;

/// <summary>
/// Defines application permissions.
/// </summary>
public static class HealNetPermissions
{
    public const string GroupName = "Heal";


    /// <summary>
    /// 院区
    /// </summary>
    public static class Campuses
    {
        /// <summary>
        /// 默认权限
        /// </summary>
        public const string Default = GroupName + ".Campuses";

        /// <summary>
        /// 新增
        /// </summary>
        public const string Create = Default + ".Create";

        /// <summary>
        /// 修改
        /// </summary>
        public const string Update = Default + ".Update";

        /// <summary>
        /// 删除
        /// </summary>
        public const string Delete = Default + ".Delete";

        /// <summary>
        /// 获取
        /// </summary>
        public const string Get = Default + ".Get";
    }
}