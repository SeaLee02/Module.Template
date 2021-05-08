using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Module.Abstractions;
using Web.Framework.Module.AspNetCore;

namespace Web.Framework.Swagger
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 自定义Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <param name="pathBase"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, string pathBase = null)
        {

            var modules = app.ApplicationServices.GetService<IModuleCollection>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                if (modules == null) return;

                foreach (var module in modules)
                {
                    if (((ModuleDescriptor)module).Initializer == null)
                        continue;

                    foreach (var g in module.GetGroups())
                    {
                        var url = $"/swagger/{g.Key}/swagger.json";
                        c.SwaggerEndpoint(url,g.Value);
                    }
                }
            });

            return app;
        }
    }
}
