using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    /// <summary>
    /// Debug版 logger定义，打印一条新的信息
    /// <para name="type">消息类型</para>
    /// <para name="message">消息内容</para>
    /// <para name="callerName">调用的方法名字</para>
    /// <para name="path">调用方法所在路径</para>
    /// <para name="line">调用代码所在行</para>
    /// </summary>
    public class DebugLogger : BaseLogger, ILogger
    {
        // TODO:07-C Debug版的Logger完成
        // 父类 BaseLogger中有带参构造器
        // Debug默认级别为:LoggerLevel.Debug
        public DebugLogger(LoggerLevel level = LoggerLevel.Debug) : base(level) { }

        /// <summary>
        /// <see cref="BaseLogger.WriteLine(string, MessageType)"/>
        /// </summary>
        public override bool WriteLine(string fullMessage, MessageLevel type)
        {
            // 如果实例的Level>默认级别,输出日志信息
            if ((int) type >= (int)Level)
            {
                // 实现Debug日志信息独有的功能:这里就是用了Debug.WriteLine()
                Console.WriteLine("[Debug~]" + fullMessage);
                return true; 
            }
            return false;
        }

        #region 历是过期代码
        public void WriteLine(
                                MessageLevel type,
                                string message,
                                [CallerMemberName] string callerName = null,
                                [CallerFilePath] string path = null,
                                [CallerLineNumber] int line = 0)
        {
            string msg =
                DateTime.Now.ToString()
                + $"[ {type.ToString()}] ->"
                + $"{Path.GetFileName(path)} > {callerName}() > in line [{line.ToString().PadLeft(3, ' ')}]"
                + message;
            //Debug.WriteLine(msg);  //Debug输出有问题,先用Console.WriteLine代替
            Console.WriteLine("[Debug~] " + msg);
        }
        #endregion
    }
}
