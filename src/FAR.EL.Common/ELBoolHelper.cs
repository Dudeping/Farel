using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.Common
{
    /// <summary>
    /// bool帮助类
    /// </summary>
    public static class ELBoolHelper
    {
        /// <summary>
        /// bool扩展方法
        /// 将bool转化为字符数组
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] ToChars(this bool src)
        {
            return Encoding.UTF8.GetBytes(new char[] { src ? '1' : '0' });
        }
    }
}
