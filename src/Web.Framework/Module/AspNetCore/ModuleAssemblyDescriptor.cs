using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Module.Abstractions;

namespace Web.Framework.Module.AspNetCore
{
    public class ModuleAssemblyDescriptor : IModuleAssemblyDescriptor
    {
        public Assembly Web { get; set; }

        //public Assembly Api { get; set; }

        //public Assembly Application { get; set; }

        //public Assembly Domain { get; set; }

        //public Assembly Infrastructure { get; set; }

        //public Assembly Quartz { get; set; }
    }
}
