﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Module.Abstractions;

namespace Web.Framework.Module.AspNetCore
{
    public class ModuleDescriptor : IModuleDescriptor
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 说明介绍
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 程序集
        /// </summary>
        public IModuleAssemblyDescriptor AssemblyDescriptor { get; set; }

        /// <summary>
        /// 初始化类型
        /// </summary>
        public IModuleInitializer Initializer { get; set; }
    }
}
