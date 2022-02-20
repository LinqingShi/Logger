using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{

    public class ConsoleLogger : BaseLogger, ILogger
    {

        // TODO: 08-A 实现BaseLogger构造函数
        public ConsoleLogger(LoggerLevel level=LoggerLevel.Debug):base(level) {}

        // TODO: 08-B 实现WriteLine方法
        /// <summary> 
        /// 实现WriteLine方法:
        /// type低于构造函数传进来的Level,不进行输出 
        /// 仅输出type高于Level的信息,通过switch判断颜色
        /// </summary>
        /// <see cref="BaseLogger.WriteLine(string, MessageType)"/>
        /// <param name="fullMessage">FormatMessage方法拼接好的Logger</param>
        /// <param name="type">通过logger等级判断:logger是否达到输出级别,logger信息颜色</param>
        public override bool WriteLine(string fullMessage, MessageLevel type)
        {
            
            // type低于构造函数传进来的,不进行输出
            if((int) type < (int)Level)
            {
                return false;
            }

            var oldColor = Console.ForegroundColor;
            
            // 通过类型type判断logger颜色
            switch (type)
            {
                case MessageLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case MessageLevel.Info:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case MessageLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageLevel.Fatal:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                // MessageType是enume类型,不用default

            }
            Console.WriteLine(fullMessage);
            Console.ForegroundColor = oldColor;
            return true;
        }

        #region 历史过期代码
        // TODO:04 过期代码警告,加false-警告，加true-错误
        [Obsolete("ConsoleLogger.WriteLine 是一个演示方法，不要乱用", false)]

        // TODO: 02 获取调用者文件名、方法名和代码所在行
        public bool WriteLine(
                                [CallerMemberName] string callerName = null,
                                [CallerFilePath] string path = null,
                                [CallerLineNumber] int line = 0)
        {
            string sth = $"{callerName} > {path} > {line}";

            Console.WriteLine(sth);

            // TODO: 03 精简文件名
            // Path.GetFileName(path)
            string msg = $"{Path.GetFileName(path)} > {callerName} > in code line" + line.ToString().PadLeft(3, ' ');
            Console.WriteLine(msg);

            return true;
        }

        /// <summary>
        /// 输出logger信息：类型，提醒，调用方法的信息
        /// </summary>
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
            Console.WriteLine(msg);
        }
        #endregion

    }

}
