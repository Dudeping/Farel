using FAR.EL.Common;
using FAR.EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.BLL
{
    /// <summary>
    /// IOrderBll 用于约束 OrderBll 和降低与 Service 层之间的耦合
    /// </summary>
    public interface IOrderBll
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
        /// <param name="logs">获取到的记录列表</param>
        /// <returns></returns>
        ELResult GetLogs(string uid, out List<LogAndTaskModel> logs);

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="did">医生Id</param>
        /// <param name="tasks">获取到的任务列表</param>
        /// <returns></returns>
        ELResult Getasks(string did, out List<LogAndTaskModel> tasks);

        /// <summary>
        /// 获取报告
        /// </summary>
        /// <param name="rid">报告Id</param>
        /// <param name="reps">获取到的报告列表</param>
        /// <returns></returns>
        ELResult GetRep(string rid, out GetRepModel rep);

        /// <summary>
        /// 获取体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <param name="pe">获取到的体检信息</param>
        /// <returns></returns>
        ELResult GetPe(string pid, out GetPeModel pe);

        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <returns></returns>
        ELResult Pet(string pid);
    }
}
