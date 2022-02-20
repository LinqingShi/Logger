using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    // TODO: 07-B BaseLogger
    /// <summary> 所有Logger的基类,提供了格式化输出log日志的基本方法
    public abstract class BaseLogger
    {
        // Level属性,set方法只能类内设置,默认Debug
        public LoggerLevel Level { get; protected set; } = LoggerLevel.Debug;

        public BaseLogger(LoggerLevel level)
        {
            Level = level;
        }

        /// <summary>
        /// 格式化并返回日志消息
        /// </summary>
        /// <param name="type">消息类型</param>
        /// <param name="message">消息具体内容</param>
        /// <param name="isDetailMode">是否详细模式</param>
        /// <param name="callerName">调用方法的名字</param>
        /// <param name="file">调用的文件名</param>
        /// <param name="line">调用代码所在行</param>
        /// <returns></returns>
        
        // 静态方法,子类无需实现,日志消息的固定内容
        public static string FormatMessage(
                                            MessageLevel type,
                                            string message,
                                            bool isDetailMode,
                                            string callerName,
                                            string file,
                                            int line)
        {

            StringBuilder msg = new StringBuilder();
            msg.Append(DateTime.Now.ToString() + " ");
            msg.Append($"[({type.ToString()})] ->");

            if (isDetailMode)
            {
                msg.Append($"{Path.GetFileName(file)} > {callerName} > in line [{line}]");
            }

            msg.Append(message);

            return msg.ToString();
        }

        /// <summary>
        /// 抽象方法
        /// </summary>
        /// <param name="fullMessage">
        /// <see cref="BaseLogger.FormatMessage(MessageType, string, bool, string, string, int)"/>
        /// 通过FormatMessage方法生成fullMessage,避免每次writeline手动拼接正则表达式
        /// </param>
        /// <param name="type">信息类型</param>
        /// <returns>打印成功</returns>
        public abstract bool WriteLine(string fullMessage, MessageLevel type); 
    }
}
