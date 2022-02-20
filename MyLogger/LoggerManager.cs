using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    /// <summary>
    /// Logger 调度器
    /// </summary>


    public static class LoggerManager
    {
        /// <summary>
        /// 存储各种BaseLogger的容器List-Loggers
        /// </summary>
        static List<BaseLogger> Loggers = new List<BaseLogger>();

        // TODO: 09-B 注册Logger
        /// <summary>
        /// 向容器List-Loggers中注册 Logger 信息
        /// </summary>
        /// <param name="type">需要开启的Logger类型,type判断logger是否合法</param>
        /// <param name="level">判断logger的级别,根据level判断加入哪种BaseLogger</param>
        public static void Enabled(LoggerType type, LoggerLevel level)
        {
            //现实开发者信息
            StringExtensions.EnableLogger(); 

            if (type.HasFlag(LoggerType.Console))
            {
                Loggers.Add(new ConsoleLogger(level));
            }
            if (type.HasFlag(LoggerType.Debug))
            {
                Loggers.Add(new DebugLogger(level));
            }
            if (type.HasFlag(LoggerType.File))
            {
                // TODO: 增加FileLogger的实现
                Loggers.Add(new FileLogger(level:level));
            }
        }

        // TODO: 09-C 销毁 Logger
        public static void Disabled()
        {
            Loggers.Clear();  // 清空List<BaseLogger>
        }

        // TODO: 09-D 打印日志 WriteDebug WriteInfo  WriteError  WriteFatal 
        /// <summary>
        /// 打印一条新的日志消息
        /// [Attention] 无需直接调用,每次需要输入type等信息,由对应type调用:
        /// </summary>
        /// <param
        /// <returns>是否输出成功</returns>
        private static bool WriteLine(
                                        MessageLevel type,
                                        string message,
                                        bool isDetailMode,
                                        string callerName,
                                        string file,
                                        int line)
        {
            // 通过BaseLogger.FormatMessage获取Logger的公共输出信息
            string msg = BaseLogger.FormatMessage(type, message, isDetailMode, callerName, file, line);

            // 使用BaseLogger.WriteLine()返回值,记录List中所有的Logger是否成功输出
            bool isWrited = true;

            ///<see cref="DebugLogger.WriteLine(string, MessageLevel)"/>
            foreach (BaseLogger logger in Loggers)
            {
                isWrited &= logger.WriteLine(msg, type);
            }

            return isWrited;
        }

        /// <summary>
        /// 不同类型Logger调用WriteLine的入口方法
        /// </summary>
        /// <returns></returns>
        public static bool WriteDebug(
                                        string message,
                                        bool isDetailMode = true,
                                        [CallerMemberName] string callerName = null,
                                        [CallerFilePath] string file = null,
                                        [CallerLineNumber] int line = 0)
            => WriteLine(MessageLevel.Debug, message, isDetailMode, callerName, file, line);

        public static bool WriteInfo(
                                        string message,
                                        bool isDetailMode = true,
                                        [CallerMemberName] string callerName = null,
                                        [CallerFilePath] string file = null,
                                        [CallerLineNumber] int line = 0)
            => WriteLine(MessageLevel.Info, message, isDetailMode, callerName, file, line);

        public static bool WriteError(
                                        string message,
                                        bool isDetailMode = true,
                                        [CallerMemberName] string callerName = null,
                                        [CallerFilePath] string file = null,
                                        [CallerLineNumber] int line = 0)
            => WriteLine(MessageLevel.Error, message, isDetailMode, callerName, file, line);
        public static bool WriteFatal(
                                string message,
                                bool isDetailMode = true,
                                [CallerMemberName] string callerName = null,
                                [CallerFilePath] string file = null,
                                [CallerLineNumber] int line = 0)
            => WriteLine(MessageLevel.Fatal, message, isDetailMode, callerName, file, line);
    }
}
