using Heal.Net.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers;

/// <summary>
/// TestController
/// </summary>
[AllowAnonymous]
[Route("api/net/basics/test")]
[ApiController]
public class TestController(ITestAppService testAppService) : HealNetController
{
    /// <summary>
    /// 获取下一个序列
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>序列</returns>
    [HttpGet("{name}")]
    public Task<long> GetNextSequenceAsync(string name, CancellationToken cancellationToken = default)
    {
        return testAppService.GetNextSequenceAsync(name, cancellationToken);
    }

    /// <summary>
    /// 生成 GUID
    /// </summary>
    /// <returns>GUID</returns>
    [HttpGet("guid")]
    public Guid Guid()
    {
        return testAppService.Guid();
    }
}