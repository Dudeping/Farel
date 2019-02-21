using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FAR.EL.Common
{
    /// <summary>
    /// 字符串扩展方法
    /// </summary>
    public static class ELStringHelper
    {
        /// <summary>
        /// 字符数组的扩展方法
        /// 填充数据，转换为 UTF8 的字节数组，不够以'\0'填充，多余的截掉
        /// </summary>
        /// <param name="str">原字符数组</param>
        /// <param name="size">要填充到的长度</param>
        /// <returns></returns>
        public static byte[] FillUTF8(this Char[] src, int size)
        {
            // 转化为 UTF8 的字节数组
            var utf8Byte = Encoding.UTF8.GetBytes(src);
            // 一个 '\0' 的 UTF8 字节
            byte endByte = Encoding.UTF8.GetBytes(new char[] { '\0' })[0];

            byte[] buf = new byte[size];
            int srcSize = utf8Byte.Count();
            for (int i = 0; i < size; i++)
            {
                if (i < srcSize) buf[i] = utf8Byte[i];
                else buf[i] = endByte;
            }
            return buf;
        }

        /// <summary>
        /// 字符串扩展方法
        /// 填充数据，转换为 UTF8 的字节数组，不够以'\0'填充，多余截掉
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="size">要填充到的长度</param>
        /// <returns></returns>
        public static byte[] FillUTF8(this string src, int size)
        {
            return FillUTF8(src.ToArray(), size);
        }
        /// <summary>
        /// 字符串扩展方法
        /// "0":false, 其它为true
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool ToBool(this string src)
        {
            return src != "0";
        }

        /// <summary>
        /// 字符串扩展方法
        /// 检查是否包含汉字 true:包含, false:不包含
        /// </summary>
        /// <param name="src">原字符串</param>
        /// <returns></returns>
        public static bool IsContainsCH(this string src)
        {
            return Regex.IsMatch(src, "[\u4e00-\u9fa5]+") ? true : false;
        }

        /// <summary>
        /// 字符串扩展方法
        /// 测试 src 转化为 UTF8 字节数组之后总长度是否小于 size
        /// true:小于等于，false:大于
        /// </summary>
        /// <param name="src">原字符串</param>
        /// <param name="size">要比较的长度</param>
        /// <returns></returns>
        public static bool CheckTotalCount(this string src, int size)
        {
            return Encoding.UTF8.GetBytes(src).Count() <= size ? true : false;
        }
    }
}
