using Heal.Net.Application.Contracts.Bases.Organizations;
using Heal.Net.Application.Contracts.Bases.Organizations.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.HttpApi.Controllers.Bases
{
    /// <summary>
    /// 组织管理
    /// </summary>
    /// <param name="organizationAppService">组织机构服务接口</param>
    [Route("api/net/basics/organizations")]
    [ApiController]
    public class OrganizationController(IOrganizationAppService organizationAppService) : HealNetController
    {
        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>组织列表</returns>
        [HttpGet]
        public Task<PagedResultDto<OrganizationTreeDto>> GetListAsync([FromQuery] GetOrganizationsInput input)
        {
            return organizationAppService.GetListAsync(input);
        }

        /// <summary>
        /// 获取组织详情
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>组织详情</returns>
        [HttpGet]
        [Route("{id:guid}")]
        public virtual Task<OrganizationDto> GetAsync(Guid id)
        {
            return organizationAppService.GetAsync(id);
        }

        /// <summary>
        /// 获取组织下拉列表
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <param name="recursive">是否查询所有下级</param>
        /// <returns>组织下拉列表</returns>
        [HttpGet("select")]
        public virtual Task<List<OrganizationDto>> GetSelectAsync([FromQuery] Guid? parentId,
            [FromQuery] bool recursive = false)
        {
            return organizationAppService.GetSelectAsync(parentId, recursive);
        }

        /// <summary>
        /// 获取组织树形结构
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>组织树形结构</returns>
        [HttpGet("tree")]
        public Task<List<OrganizationTreeDto>> GetTreeAsync([FromQuery] Guid? parentId, CancellationToken cancellationToken)
        {
            return organizationAppService.GetTreeAsync(parentId, cancellationToken);
        }

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="input">创建信息</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>组织</returns>
        [HttpPost]
        public virtual Task<OrganizationDto> CreateAsync(OrganizationCreateDto input, CancellationToken cancellationToken)
        {
            ValidateModel();
            return organizationAppService.CreateAsync(input, cancellationToken);
        }

        /// <summary>
        /// 更新组织
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="input">更新信息</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>组织</returns>
        [HttpPut]
        [Route("{id:guid}")]
        public virtual Task<OrganizationDto> UpdateAsync(Guid id, OrganizationUpdateDto input, CancellationToken cancellationToken)
        {
            return organizationAppService.UpdateAsync(id, input, cancellationToken);
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>Task</returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return organizationAppService.DeleteAsync(id, cancellationToken);
        }
        
        // 测试取消令牌
        /*
        [AllowAnonymous]
        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> TestAsync(CancellationToken cancellationToken)
        {

            Console.WriteLine($"Cancellation Requested: {cancellationToken.IsCancellationRequested}");

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    await Task.Delay(500, cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                }

                return Ok("Request completed successfully.");
            }
            catch (OperationCanceledException)
            {
                return StatusCode(StatusCodes.Status499ClientClosedRequest, "Request was canceled.");
            }
        }
        */
        //前端代码
        /*
         <!DOCTYPE html>
           <html lang="en">
           <head>
               <meta charset="UTF-8">
               <meta name="viewport" content="width=device-width, initial-scale=1.0">
               <title>Test Cancellation</title>
               <style>
                   body {
                       font-family: Arial, sans-serif;
                       margin: 20px;
                   }
                   button {
                       padding: 10px 20px;
                       font-size: 16px;
                       margin-right: 10px;
                   }
                   pre {
                       background-color: #f4f4f4;
                       padding: 10px;
                       border-radius: 5px;
                       white-space: pre-wrap;
                   }
               </style>
           </head>
           <body>
               <h1>Test Cancellation</h1>
               <p>Click the buttons below to test sending a request and canceling it.</p>
           
               <button id="startRequest">Start Request</button>
               <button id="cancelRequest" disabled>Cancel Request</button>
           
               <h2>Response:</h2>
               <pre id="response"></pre>
           
               <script>
                   let controller = null;
           
                   // Start a new request
                   document.getElementById('startRequest').addEventListener('click', () => {
                       // Create a new AbortController
                       controller = new AbortController();
                       const signal = controller.signal;
           
                       // Enable the Cancel button
                       document.getElementById('cancelRequest').disabled = false;
           
                       // Clear previous response
                       document.getElementById('response').textContent = 'Request started...';
           
                       // Send the request
                       fetch('https://localhost:62513/api/net/basics/organizations/test', { signal })
                           .then(response => {
                               if (!response.ok) {
                                   throw new Error(`HTTP error! Status: ${response.status}`);
                               }
                               return response.text();
                           })
                           .then(data => {
                               document.getElementById('response').textContent = `Response: ${data}`;
                           })
                           .catch(err => {
                               if (err.name === 'AbortError') {
                                   document.getElementById('response').textContent = 'Request was aborted by the user.';
                               } else {
                                   document.getElementById('response').textContent = `Error: ${err.message}`;
                               }
                           })
                           .finally(() => {
                               // Disable the Cancel button after the request completes
                               document.getElementById('cancelRequest').disabled = true;
                           });
                   });
           
                   // Cancel the ongoing request
                   document.getElementById('cancelRequest').addEventListener('click', () => {
                       if (controller) {
                           controller.abort(); // Abort the request
                           document.getElementById('cancelRequest').disabled = true; // Disable the Cancel button
                       }
                   });
               </script>
           </body>
           </html>
         */
    }
}
