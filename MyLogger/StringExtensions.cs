using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger
{
    public static class StringExtensions
    {
        /// <summary>
        /// 激活Logger，使其现实开发者信息
        /// </summary>
        public static void EnableLogger()
        {
            string msg = "This is a easy Logger tool develement by 712";
            Console.WriteLine(msg.ToHeader(120));
        }


        /// <summary>
        /// 在字符型两侧加上***直到指定的总长度
        /// </summary>
        /// <param name="self">字符串本身</param>
        /// <param name="width">指定的总长度</param>
        /// <returns></returns>
        public static string ToHeader(this string self, int width)
        {
            if (self.Length >= width)
            {
                return self;
            }
            else
            {
                StringBuilder msg = new StringBuilder(self);
                bool isOdd;

                // 判断指定长度的奇偶
                isOdd = (width % 2) != 0;

                // 调整长度为偶数
                if (isOdd) width += 1;

                // 判断原字符串长度
                // TODO 10 原字符串 this string self是哪里来的？？
                isOdd = (self.Length % 2 != 0);

                int startCount;
                if (isOdd)
                {
                    startCount = (width - self.Length - 1) / 2;
                    msg.Append(" ");
                }
                else
                {
                    startCount = (width - self.Length) / 2;
                }
                msg.Append('*', startCount);
                msg.Append(Environment.NewLine);   // 换行
                return msg.ToString().PadLeft(width, '*');
            }
        }
    }
}
