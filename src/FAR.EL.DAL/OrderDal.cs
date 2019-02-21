using FAR.EL.Common;
using FAR.EL.DAL.Common;
using FAR.EL.IDAL;
using FAR.EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.DAL
{
    /// <summary>
    /// OrderDal
    /// </summary>
    public class OrderDal : BaseDal, IOrderDal
    {
        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="model">预约数据模型</param>
        /// <returns></returns>
        public ELResult Order(OrderModel model)
        {
            return Request(ELReqType.order.To8Bytes(), model.UId.FillUTF8(2), model.DId.FillUTF8(2), model.IsChckeTmp.ToChars(), model.IsChckeHtBt.ToChars());
        }

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <returns></returns>
        public ELResult GetLogs(string uid) => Request(ELReqType.getlog.To8Bytes(), uid.FillUTF8(2));

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="did">医生Id</param>
        /// <returns></returns>
        public ELResult Getasks(string did) => Request(ELReqType.getask.To8Bytes().ToArray(), did.FillUTF8(2));

        /// <summary>
        /// 获取报告
        /// </summary>
        /// <param name="rid">报告Id</param>
        /// <returns></returns>
        public ELResult GetRep(string rid) => Request(ELReqType.getrep.To8Bytes(), rid.FillUTF8(2));

        /// <summary>
        /// 获取体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <returns></returns>
        public ELResult GetPe(string pid) => Request(ELReqType.getpe.To8Bytes(), pid.FillUTF8(2));

        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <returns></returns>
        public ELResult Pet(string pid) => Request(ELReqType.pet.To8Bytes(), pid.FillUTF8(2));
    }
}
