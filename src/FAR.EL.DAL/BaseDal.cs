using FAR.EL.Common;
using FAR.EL.DAL.Common;
using FAR.EL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.DAL
{
    /// <summary>
    /// 所有 Dal 的基类，实现 IBaseDal
    /// 包含所有 Dal 共用的方法
    /// </summary>
    public class BaseDal:IBaseDal
    {
        /// <summary>
        /// 当前Socket
        /// </summary>
        protected ELSocketHelper CurrenSocekt { get; set; } = new ELSocketHelper();

        /// <summary>
        /// 请求数据
        /// 成功后数据在Message中
        /// </summary>
        /// <param name="sendData">UTF8 的字节数组列表，UTF8 字节数组使用 Encoding.UTF8.GetBytes 获取</param>
        /// <returns></returns>
        public ELResult Request(params byte[][] sendData)
        {
            // 请求数据
            byte[] reqData = new byte[CurrenSocekt.ReqDataSize];
            reqData.AddFillUTF8(sendData);

            return CurrenSocekt.Request(reqData);
        }

        ~BaseDal()
        {
            // 关闭连接
            CurrenSocekt.Colse();
        }
    }
}
