using MyLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "Test Logger Tool";
            Console.WriteLine(msg.ToHeader(120));
            Logger();
        }
        public static void Logger()
        {
            // 注册Logger类型和级别
            LoggerManager.Enabled(
                                    LoggerType.Console |
                                    LoggerType.Debug |
                                    LoggerType.File,
                                    LoggerLevel.Error);
            LoggerManager.WriteDebug("This is a Debug logger");
            LoggerManager.WriteError("This is a Error logger");

        }
    }
}
