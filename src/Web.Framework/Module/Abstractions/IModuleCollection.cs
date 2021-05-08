using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Framework.Module.Abstractions
{
    /// <summary>
    /// 模块集合
    /// </summary>
    public interface IModuleCollection : IList<IModuleDescriptor>
    {
        /// <summary>
        /// 加载
        /// </summary>
        void Load();
    }
}