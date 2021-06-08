using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [Area("Sys")]
    [Description("测试接口")]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 测试Get
        /// </summary>
        /// <returns></returns>
        [Description("测试方法")]
        [HttpGet]
        public async Task<IActionResult> GetName()
        {
            UInt64 i = 5394703153207343904;
            return await Task.FromResult(Ok(i));
        }


        /// <summary>
        /// 测试Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetName2([BindRequired] int id)
        {
            return await Task.FromResult(Ok("goofwefewfwf"));
        }
    }
}
