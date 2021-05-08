using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Module.Abstractions;
using Web.Framework.Module.AspNetCore;

namespace Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services, IModuleCollection modules, IHostEnvironment env)
        {
            Console.WriteLine("模块里面的ConfigureServices");
        }


    }
}
