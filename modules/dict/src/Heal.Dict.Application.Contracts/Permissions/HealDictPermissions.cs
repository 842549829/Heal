namespace Heal.Dict.Application.Contracts.Permissions;

/// <summary>
/// 权限
/// </summary>
public static class HealDictPermissions
{
    /// <summary>
    /// 模块名称
    /// </summary>
    public const string GroupName = "Dict";

    /// <summary>
    /// ICD管理
    /// </summary>
    public static class Icd
    {
        /// <summary>
        /// 默认权限
        /// </summary>
        public const string Defaults = GroupName + ".Icd";

        /// <summary>
        /// ICD10
        /// </summary>
        public static class Icd10
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Icd10";

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
        /// ICD9
        /// </summary>
        public static class Icd9
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Icd9";

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
    /// 普通字段
    /// </summary>
    public static class Dicts
    {
        /// <summary>
        /// 默认权限
        /// </summary>
        public const string Defaults = GroupName + ".Dicts";

        /// <summary>
        /// 字典
        /// </summary>
        public static class Dict
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Dict";

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
        /// 字典类型
        /// </summary>
        public static class DictType
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".DictType";

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
    /// 区划
    /// </summary>
    public static class Regions
    {
        /// <summary>
        /// 默认权限
        /// </summary>
        public const string Defaults = GroupName + ".Regions";

        /// <summary>
        /// 国家
        /// </summary>
        public static class Country
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Country";

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
        /// 省
        /// </summary>
        public static class Province
        {
            /// <summary>
            /// 默认权限
            /// </summary>
            public const string Default = Defaults + ".Provinces";

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
        /// 市
        /// </summary>
        public static class City
        {
            /// <summary>
            /// 默认
            /// </summary>
            public const string Default = Defaults + ".Cities";

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
        /// 区
        /// </summary>
        public static class District
        { 
            /// <summary>
            /// 默认
            /// </summary>
            public const string Default = Defaults + ".Districts";

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
        /// 镇/乡/村/社区/街道
        /// </summary>
        public static class Town
        {
            /// <summary>
            /// 默认
            /// </summary>
            public const string Default = Defaults + ".Towns";

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
    }
}