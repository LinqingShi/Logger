using MyLogger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogTool
{
    class Program
    {
        static void Main(string[] args)
        {
            //10.
            //string msg = "This is a easy Logger tool develement by 712";
            //Console.WriteLine(msg);
            //Console.WriteLine(msg.ToHeader(120));

            //09.
            LoggerManagerTest();
            
            //08.
            //ConsoleLoggerCompleted();

            //07.
            //DebugOutPutLoggerCompleted();

            //06.
            //InterfaceEachTest();

            //05.
            //DebugOutput();

            //02.03.04.
            //ConsoleLoggerTest();

            // 01.
            //ColorfullConsoleAndTimeFormat();

            Console.ReadKey();  //暂停

        }
        /// <summary>
        /// 控制台输出
        /// </summary>
        static void ColorfullConsoleAndTimeFormat(){
            // TODO：01-A 彩色控制台输出
            var oldColor = Console.ForegroundColor;   // 保存之前的颜色

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("this is red ...");

            Console.ForegroundColor = oldColor;
            Console.WriteLine("this is default...");

            // TODO：01-B 时间控制台输出
            var now = DateTime.Now;

            Console.WriteLine($"Default time is : {now.ToString("yyyy-MM-dd hh-mm-ss")}");
        }

        //TODO: 02, 03, 04
        static void ConsoleLoggerTest()
        {
            ConsoleLogger logger = new ConsoleLogger();
            // 04.使用pragma warning disable/restore 警告代码编号，屏蔽过期代码
#pragma warning disable 0618
            logger.WriteLine();
#pragma warning restore 0618
        }

        // TODO: 05 彩色Debug输出
        static void DebugOutput()
        {
            Trace.WriteLine(" Debug ");
            Trace.WriteLine(" Error ");
            System.Diagnostics.Debug.WriteLine(" Fatal ");
            Debug.WriteLine(" Info ");
        }

        // TODO: 06. 接口与Linq ForEach()
        static void InterfaceEachTest()
        {
            Console.WriteLine();
            ConsoleLogger console = new ConsoleLogger();
            DebugLogger debug = new DebugLogger();

            // 不使用接口，强制转型，迭代输出log信息
            //List<object> loggers = new List<object>();
            //loggers.Add(console);
            //loggers.Add(debug);
            //loggers.ForEach(
            //    logger =>
            //    {
            //        // ? 判断logger类型，正确执行，错误跳过
            //        (logger as ConsoleLogger)?.WriteLine(MessageType.Debug, "this is a Console message");
            //        (logger as DebugOutputLogger)?.WriteLine(MessageType.Debug, "this is a Debug message");
            //    });

            // 使用接口
            List<ILogger> iloggers = new List<ILogger>
            {
                debug,
                console
            };
            foreach (ILogger ilogger in iloggers)
            {
                ilogger.WriteLine(MessageLevel.Debug, "this is a Console message", "Method", "FileName.cs", 113);
            }


        }

        // TODO: 07-D 完整DebugOutputLogger的使用
        static void DebugOutPutLoggerCompleted()
        {
            DebugLogger logger = new DebugLogger(LoggerLevel.Error);
            logger.WriteLine($"this is a {MessageLevel.Debug}...", MessageLevel.Debug);
            logger.WriteLine($"this is a {MessageLevel.Error}...", MessageLevel.Error);
            logger.WriteLine($"this is a {MessageLevel.Info}...", MessageLevel.Info);
            logger.WriteLine($"this is a {MessageLevel.Fatal}...", MessageLevel.Fatal);
        }

        // TODO: 08-C 完整的使用ConsoleLogger功能
        static void ConsoleLoggerCompleted()
        {
            ConsoleLogger logger = new ConsoleLogger(LoggerLevel.Fatal);

            logger.WriteLine($"this is a Debug message", MessageLevel.Debug);
            logger.WriteLine($"this is a Info message", MessageLevel.Info);
            logger.WriteLine($"this is a Error message", MessageLevel.Error);
            logger.WriteLine($"this is a Fatal message", MessageLevel.Fatal);
        }

        // TODO: 09-C Logger调度器的使用
        /// <summary>
        /// 在其他项目中使用本LogTool时的操作方法
        /// </summary>
        static void LoggerManagerTest()
        {
            // 分别输出Console、Debug、File三种不同类型的logger
            LoggerManager.Enabled(LoggerType.Console | LoggerType.File | LoggerType.Debug, LoggerLevel.Debug);
            LoggerManager.WriteDebug("this is a Debug.");
            LoggerManager.WriteInfo("this is a Info.");
            LoggerManager.WriteError("this is a Error.");
            LoggerManager.WriteFatal("this is a Fatal.");
        }
    }
}
