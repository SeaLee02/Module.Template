using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Module.Abstractions;
using Web.Framework.Module.AspNetCore;

namespace Web.Framework.Swagger
{
    public static class ModuleDescriptorExtensions
    {
        public static Dictionary<string, string> GetGroups(this IModuleDescriptor descriptor)
        {
            var dictionary = new Dictionary<string, string>
            {
                {
                    descriptor.Code,
                    descriptor.Name
                }
            };
            var moduleAssemblyDescriptor = (ModuleAssemblyDescriptor)descriptor.AssemblyDescriptor;
            var controllerTypes = (moduleAssemblyDescriptor.Web).GetTypes()
                .Where(m => m.Name.EndsWith("Controller"));

            foreach (var type in controllerTypes)
            {
                var array = type.FullName.Split('.');
                if (array.Length == 7)
                {
                    string text = array[5];
                    var key = descriptor.Code + "_" + text;
                    if (text != "Controllers" && !dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, descriptor.Name + "_" + text);
                    }
                }
            }

            return dictionary;
        }
    }
}
