using FAR.EL.BLLFactory;
using FAR.EL.Common;
using FAR.EL.IBLL;
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
    /// 在 UserService.svc 上点击调试调试该服务 
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// OrderBll
        /// </summary>
        public IOrderBll OrderBll { get; set; } = BllStaticFactory.GetOrderBll();

        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="model">预约数据模型</param>
        /// <returns></returns>
        public ELResult Order(OrderModel model) => OrderBll.Order(model);

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="logs">获取到的记录列表</param>
        /// <returns></returns>
        public List<LogAndTaskModel> GetLogs(string uid) => OrderBll.GetLogs(uid, out List<LogAndTaskModel> logs).Success ? logs : new List<LogAndTaskModel>();

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="did">医生Id</param>
        /// <param name="reps">获取到的任务列表</param>
        /// <returns></returns>
        public List<LogAndTaskModel> Getasks(string did) => OrderBll.Getasks(did, out List<LogAndTaskModel> logs).Success ? logs : new List<LogAndTaskModel>();

        /// <summary>
        /// 获取报告
        /// </summary>
        /// <param name="rid">报告Id</param>
        /// <param name="reps">获取到的报告列表</param>
        /// <returns></returns>
        public GetRepModel GetRep(string rid) => OrderBll.GetRep(rid, out GetRepModel rep).Success ? rep : null;

        /// <summary>
        /// 获取体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <param name="pe">获取到的体检信息</param>
        /// <returns></returns>
        public GetPeModel GetPe(string pid) => OrderBll.GetPe(pid, out GetPeModel pe).Success ? pe : null;

        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <returns></returns>
        public ELResult Pet(string pid) => OrderBll.Pet(pid);
    }
}
