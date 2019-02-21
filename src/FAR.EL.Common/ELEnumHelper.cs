using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.Common
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class ELEnumHelper
    {
        /// <summary>
        /// 枚举扩展方法
        /// 将枚举转换为长度为 8 的 UTF8 字节数组
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] To8Bytes(this Enum src)
        {
            return src.ToString().FillUTF8(8);
        }
    }
}
