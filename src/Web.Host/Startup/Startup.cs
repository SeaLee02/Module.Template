using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Framework.Module.AspNetCore;
using Web.Framework.Swagger;

namespace Web
{
    public class Startup
    {

        protected readonly IHostEnvironment _env;
     

        public IConfiguration _configuration { get; }
        public Startup(IHostEnvironment env, IConfiguration configuration)
        {
            this._env = env;
            this._configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
          

            //初始化模块数据
            var module = services.AddModules();
            //添加模块ConfigureServices 
            services.AddModuleInitializerServices(module, _env);

            //添加控制器
            services.AddControllers();

            //添加Swagger
            services.AddSwagger(module);



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //配置Swagger
            app.UseCustomSwagger();




            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
