using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Module.Abstractions;

namespace Web.Framework.Module.AspNetCore
{
    public interface IModuleInitializer
    {
        /// <summary>
        /// 注入服务
        /// <para>此方法用于注入与Web相关的服务，否则请通过IModuleServicesConfigurator接口注册</para>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules">模块集合</param>
        /// <param name="env">环境变量</param>
        /// <param name="cfg">配置</param>
        void ConfigureServices(IServiceCollection services, IModuleCollection modules, IHostEnvironment env);

        ///// <summary>
        ///// 配置中间件
        ///// </summary>
        ///// <param name="app"></param>
        ///// <param name="env"></param>
        //void Configure(IApplicationBuilder app, IHostEnvironment env);

        ///// <summary>
        ///// 配置MVC
        ///// </summary>
        ///// <param name="mvcOptions"></param>
        //void ConfigureMvc(MvcOptions mvcOptions);
    }
}
