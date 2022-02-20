using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    public class FileLogger : BaseLogger
    {
        // 属性， 文件地址
        public string FilePath { get; private set; }

        /// <summary>
        /// TODO： 09-A 构造器 创建log目录和log文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="level"></param>
        public FileLogger(string filePath = null, LoggerLevel level = LoggerLevel.Debug) : base(level)
        {
            if(filePath == null)
            {
                // 获取程序运行的根目录
                string root = Environment.CurrentDirectory;
                // 创建文件夹
                // 正则表达式判断是否有logXXX文件夹，如果没有再创建
                if( !Directory.Exists( root + @"/log"))
                {
                    Directory.CreateDirectory(root + @"/log");
                }
                // 创建log文件
                this.FilePath = root +@"/log" +@"/log" + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + ".log";
            }
            else
            {
                this.FilePath = filePath;
            }
            // using 类似 try...catch...
            using (StreamWriter writer = new StreamWriter(this.FilePath))
            {
                writer.WriteLineAsync(BaseLogger.FormatMessage(MessageLevel.Info, "Logger File is Created ...", true, nameof(FileLogger), "Created by MyLogTool", 37));
            }
        }


        /// <summary>
        /// TODO：09-B 将Logger信息写入log file中
        /// </summary>
        /// <param name="fullMessage">编辑好的logger信息</param>
        /// <param name="type">消息的级别</param>
        /// <returns></returns>
        public override bool WriteLine(string fullMessage, MessageLevel type)
        {
            using (StreamWriter writer = new StreamWriter(this.FilePath, true)) 
            {
                writer.WriteLineAsync(fullMessage);
            }
            return true;
        }
    }
}
