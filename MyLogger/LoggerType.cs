using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    // TODO: 09-A Logger实例的类型
    /// <summary>
    /// </summary>
    [Flags]   
    //TODO：不理解!!Flags 表示可以将enum作为位域处理,使用HasFlag()方法，保证每个元素1位不同
    public enum LoggerType
    {
        Debug = 0x0001,

        Console = 0x0010,

        File = 0x0100,
    }
}
