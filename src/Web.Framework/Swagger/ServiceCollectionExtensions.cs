using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Module.Abstractions;
using Web.Framework.Module.AspNetCore;
using Web.Framework.Swagger.Filters;

namespace Web.Framework.Swagger
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules">模块集合</param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services, IModuleCollection modules)
        {
            services.AddSwaggerGen(c =>
            {
                if (modules != null)
                {
                    foreach (var module in modules)
                    {
                        if (((ModuleDescriptor)module).Initializer == null)
                            continue;

                        foreach (var g in module.GetGroups())
                        {
                            c.SwaggerDoc(g.Key, new OpenApiInfo
                            {
                                Title = g.Value,
                                Version = module.Version
                            });
                        }
                    }
                }

                // Jwt Bearer 认证，必须是 oauth2
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });

                //链接转小写过滤器
                c.DocumentFilter<LowercaseDocumentFilter>();
                ////描述信息处理
                //c.DocumentFilter<DescriptionDocumentFilter>();

                // 开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

            });

            //services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }
    }
}
