using FAR.EL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.DAL
{
    /// <summary>
    /// IBaseDal 用于约束 BaseDal，保证 BaseDal 实现了其他 Dal 共用的方法
    /// </summary>
    public interface IBaseDal
    {
        /// <summary>
        /// 请求数据
        /// 成功后数据在Message中
        /// </summary>
        /// <param name="sendData">UTF8 的字节数组列表，UTF8 字节数组使用 Encoding.UTF8.GetBytes 获取</param>
        /// <returns></returns>
        ELResult Request(params byte[][] sendData);
    }
}
