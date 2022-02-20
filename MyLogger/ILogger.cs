using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    public interface ILogger
    {
        /// <summary>
        /// 规范MessageType中所有类型的Logger
        /// 用接口统一：List<object> loggers = new List<object>();中的数据类型
        /// </summary>
        /// 接口中的参数不能使用[] 方法参数标注
        void WriteLine(
                        MessageLevel type,
                        string message,
                        string callerName,
                        string path,
                        int line);
    }
}
