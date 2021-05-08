﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Framework.Module.Abstractions
{
    /// <summary>
    /// 模块描述
    /// </summary>
    public interface IModuleDescriptor
    {
        /// <summary>
        /// 编号
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        string Icon { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// 说明介绍
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 程序集信息
        /// </summary>
        IModuleAssemblyDescriptor AssemblyDescriptor { get; set; }
    }
}