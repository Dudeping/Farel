using FAR.EL.Common;
using FAR.EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FAR.EL.Service
{
    /// <summary>
    /// Order 服务
    /// </summary>
    [ServiceContract]
    public interface IOrderService
    {
        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="model">预约数据模型</param>
        /// <returns></returns>
        [OperationContract]
        ELResult Order(OrderModel model);

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="logs">获取到的记录列表</param>
        /// <returns></returns>
        [OperationContract]
        List<LogAndTaskModel> GetLogs(string uid);

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="did">医生Id</param>
        /// <param name="reps">获取到的任务列表</param>
        /// <returns></returns>
        [OperationContract]
        List<LogAndTaskModel> Getasks(string did);

        /// <summary>
        /// 获取报告
        /// </summary>
        /// <param name="rid">报告Id</param>
        /// <param name="reps">获取到的报告列表</param>
        /// <returns></returns>
        [OperationContract]
        GetRepModel GetRep(string rid);

        /// <summary>
        /// 获取体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <param name="pe">获取到的体检信息</param>
        /// <returns></returns>
        [OperationContract]
        GetPeModel GetPe(string pid);

        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <returns></returns>
        [OperationContract]
        ELResult Pet(string pid);
    }
}
