using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.Common
{
    /// <summary>
    /// 字节帮助类
    /// </summary>
    public static class ELByteHelper
    {
        /// <summary>
        /// 将字节数组列表加入从 index 为 0 处复制到 src 中, 不够则将 src 后面补 '\0' 的 UTF8 字节，多余的截断
        /// </summary>
        /// <param name="src">元字符数组</param>
        /// <param name="bytes">UTF8 的字节数组列表</param>
        public static void AddFillUTF8(this byte[] src, params byte[][] bytes)
        {
            int index = 0;
            int srcCount = src.Count();
            foreach (var item in bytes)
            {
                foreach (var byt in item)
                {
                    if (index < srcCount) src[index++] = byt;
                    else return;
                }
            }

            // 补齐
            // 一个 '\0' 的 UTF8 字节
            byte endByte = Encoding.UTF8.GetBytes(new char[] { '\0' })[0];
            for (int i = 0; i < srcCount - index - 1; i++)
            {
                src[index++] = endByte;
            }
        }
    }
}
