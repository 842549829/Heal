namespace Heal.Net.Application.Contracts.Permissions;

/// <summary>
/// Defines application permissions.
/// </summary>
public static class HealNetPermissions
{
    /// <summary>
    /// 模块名称
    /// </summary>
    public const string GroupName = "Net";

    /// <summary>
    /// 权限管理
    /// </summary>
    public static class Authorizations
    {
        /// <summary>
        /// 默认权限
        /// </summary>
        public const string Defaults = GroupName + ".Authorizations";

        /// <summary>
        /// 用户
        /// </summary>
        public static class Users
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Users";

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
        }

        /// <summary>
        /// 角色
        /// </summary>
        public static class Roles
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Roles";

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
        }

        /// <summary>
        /// 菜单
        /// </summary>
        public static class Menus
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Menus";

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
        }

        /// <summary>
        /// 租户
        /// </summary>
        public static class Tenants
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Tenants";

            /// <summary>
            /// 新增
            /// </summary>
            public const string Create = Default + ".Create";

            /// <summary>
            /// 修改
            /// </summary>
            public const string Update = Default + ".Update";

            /// <summary>
            /// 
            /// </summary>
            public const string Delete = Default + ".Delete";
        }

        /// <summary>
        /// 菜单按钮管理
        /// </summary>
        public static class MenuButtons
        { 
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".MenuButtons";

            /// <summary>
            /// 新增
            /// </summary>
            public const string Create = Default + ".Create";

            /// <summary>
            /// 修改
            /// </summary>
            public const string Update = Default + ".Update";

            /// <summary>
            /// 
            /// </summary>
            public const string Delete = Default + ".Delete";
        }

        /// <summary>
        /// 模块管理
        /// </summary>
        public static class Modules
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Modules";

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
        }
    }

    /// <summary>
    /// 组织管理
    /// </summary>
    public static class Organizations
    {
        /// <summary>
        /// 默认权限
        /// </summary>
        public const string Defaults = GroupName + ".Basics";

        /// <summary>
        /// 院区
        /// </summary>
        public static class Campuses
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Campuses";

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
        }

        /// <summary>
        /// 组织
        /// </summary>
        public static class Organization
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Organizations";

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
        }

        /// <summary>
        /// 科室
        /// </summary>
        public static class Department
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Departments";

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
        }
    }

    /// <summary>
    /// 人员管理
    /// </summary>
    public static class Personnel
    {
        /// <summary>
        /// 默认权限
        /// </summary>
        public const string Defaults = GroupName + ".Personnel";

        /// <summary>
        /// 医生
        /// </summary>
        public static class Doctors
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Doctors";

            /// <summary>
            /// 新增
            /// </summary>
            public const string Create = Default + ".Create";

            /// <summary>
            /// 删除
            /// </summary>
            public const string Delete = Default + ".Delete";

            /// <summary>
            /// 修改
            /// </summary>
            public const string Update = Default + ".Update";
        }

        /// <summary>
        /// 患者
        /// </summary>
        public static class Patients
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Patients";

            /// <summary>
            /// 新增
            /// </summary>
            public const string Create = Default + ".Create";

            /// <summary>
            /// 删除
            /// </summary>
            public const string Delete = Default + ".Delete";

            /// <summary>
            /// 
            /// </summary>
            public const string Update = Default + ".Update";
        }
    }
}