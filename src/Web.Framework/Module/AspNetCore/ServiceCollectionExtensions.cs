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
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IModuleCollection AddModules(this IServiceCollection services)
        {
            var modules = new ModuleCollection();
            modules.Load();

            services.AddSingleton<IModuleCollection>(modules);

            foreach (var module in modules)
            {
                if (module == null)
                    continue;              

                services.AddSingleton(module);
            }

            return modules;
        }



        /// <summary>
        /// 添加模块初始化服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules"></param>
        /// <param name="env"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static IServiceCollection AddModuleInitializerServices(this IServiceCollection services, IModuleCollection modules, IHostEnvironment env)
        {
            foreach (var module in modules)
            {
                //加载模块初始化器
                ((ModuleDescriptor)module).Initializer?.ConfigureServices(services, modules, env);
            }

            return services;
        }


    }
}
