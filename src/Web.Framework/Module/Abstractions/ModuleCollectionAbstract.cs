using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Util;

namespace Web.Framework.Module.Abstractions
{
    public abstract class ModuleCollectionAbstract : CollectionAbstract<IModuleDescriptor>, IModuleCollection
    {

        /// <summary>
        /// 加载模块
        /// </summary>
        /// <param name="moduleDir"></param>
        /// <param name="jsonReader"></param>
        protected abstract void LoadDescriptor(DirectoryInfo moduleDir, StreamReader jsonReader);

        public void Load()
        {
            Collection.Clear();

            var modulesRootDirPath = Path.Combine(AppContext.BaseDirectory, "_modules");
            if (!Directory.Exists(modulesRootDirPath))
                return;

            var modulesRootDir = new DirectoryInfo(modulesRootDirPath);
            var moduleDirs = modulesRootDir.GetDirectories();
            if (!moduleDirs.Any())
                return;

            foreach (var moduleDir in moduleDirs)
            {
                //从_module.json文件中读取模块信息
                var jsonPath = Path.Combine(moduleDir.FullName, "_module.json");
                if (!File.Exists(jsonPath))
                    continue;

                using var jsonReader = new StreamReader(jsonPath);
                LoadDescriptor(moduleDir, jsonReader);
            }
        }
    }
}
