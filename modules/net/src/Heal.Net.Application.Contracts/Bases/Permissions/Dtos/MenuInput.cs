﻿using Heal.Application.Contracts.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 菜单输入
/// </summary>
public class MenuInput : FilterInput
{
    /// <summary>
    /// 模块Code
    /// </summary>
    public required string ModuleCode { get; set; }
}