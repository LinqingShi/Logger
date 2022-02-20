# Logger
A simple logger tool by C#
+ abstract BaseLogger
      所有logger的基类,提供Logger的基本使用方法
  		属性:Level,默认LoggerLevel.Debug,用于判断调用WriteLine的logger实例是否达到输出级别;判断输出logger颜色
          abstract WriteLine(string fullMessage, MessageType type)
              logger输出的抽象接口,实现类:
  				ConsoleLogger 
  				DebugLogger
  				FileLogger
  		static string FormatMessage
  			构造logger的信息,生成msg用于WriteLine输出使用;



+ 区分LoggerType/MessageType(对应) 和 LoggerLevel, 
  	LoggerType: Debug Console File       :决定输出的Logger需要包含什么信息,不同类型使用不同的颜色
  	LoggerLevel/MessageLevel: Debug  Info  Error Fatal    :Logger对不级别的信息,区别对待

​      

+ 使用

  将MyLogger/bin/Debug/MyLogger.dll文件，添加到需要使用本Log工具的项目中；

  激活Logger工具：测试请见 LoggerTest

  ```C#
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
  ```

  
