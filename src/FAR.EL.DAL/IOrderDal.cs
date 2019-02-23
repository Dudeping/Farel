using FAR.EL.Common;
using FAR.EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.DAL
{
    /// <summary>
    /// IOrderDal
    /// 用于约束 OrderDal，和降低与 BLL 层之间的耦合
    /// </summary>
    public interface IOrderDal
    {
        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="model">预约数据模型</param>
        /// <returns></returns>
        ELResult Order(OrderModel model);

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <returns></returns>
        ELResult GetLogs(string uid);

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="did">医生Id</param>
        /// <returns></returns>
        ELResult Getasks(string did);

        /// <summary>
        /// 获取报告
        /// </summary>
        /// <param name="rid">报告Id</param>
        /// <returns></returns>
        ELResult GetRep(string rid);

        /// <summary>
        /// 获取体检
        /// </summary>
        /// <param name="pid">体检Id</param
        /// <param name="pe">获取到的体检信息</param>
        /// <returns></returns>
        ELResult GetPe(string pid);

        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <returns></returns>
        ELResult Pet(string pid);
    }
}
