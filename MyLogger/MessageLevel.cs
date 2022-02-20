using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    /// <summary>
    /// 消息级别
    /// </summary>
    public enum MessageLevel
    {
        /// <summary>
        /// 调试信息
        /// </summary>
        Debug,

        /// <summary>
        /// 一般信息
        /// </summary>
        Info,

        /// <summary>
        /// 错误
        /// </summary>
        Error,

        /// <summary>
        /// 崩溃
        /// </summary>
        Fatal,
    }
}
