using FAR.EL.Common;
using FAR.EL.DAL;
using FAR.EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.BLL
{
    internal class OrderBll : IOrderBll
    {
        /// <summary>
        /// DbSession
        /// </summary>
        private IDbSession DbSession { get; set; } = DALStaticFactory.GetDbSession();

        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="model">预约数据模型</param>
        /// <returns></returns>
        public ELResult Order(OrderModel model)
        {
            // 校验预约数据
            if (!model.IsChckeHtBt && !model.IsChckeTmp) return new ELResult { Success = false, Message = "必须选择一项体检任务！" };
            // 预约
            var result = DbSession.OrderDal.Order(model);
            if (!result.Success) return result;
            return new ELResult { Success = result.Message.ToLower().Contains(SocktRecType.RecOK) ? true : false, Message = result.Message };
        }

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="uid">用户Id</param>
        /// <param name="logs">获取到的记录列表</param>
        /// <returns></returns>
        public ELResult GetLogs(string uid, out List<LogAndTaskModel> logs)
        {
            var result = DbSession.OrderDal.GetLogs(uid);
            return GetLogTask(result, "记录", out logs);
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="did">医生Id</param>
        /// <param name="tasks">获取到的任务列表</param>
        /// <returns></returns>
        public ELResult Getasks(string did, out List<LogAndTaskModel> tasks)
        {
            var result = DbSession.OrderDal.Getasks(did);
            return GetLogTask(result, "任务", out tasks);
        }

        /// <summary>
        /// 获取记录或任务列表
        /// </summary>
        /// <param name="type">请求类型</param>
        /// <param name="text">提示文字</param>
        /// <param name="lts">获取到的任务或记录列表</param>
        /// <returns></returns>
        private ELResult GetLogTask(ELResult result, string lrtext, out List<LogAndTaskModel> lts)
        {
            // 请求失败
            if (!result.Success) { lts = null; return result; }

            // 没有数据
            if (result.Message.Length <= 0)
            {
                lts = new List<LogAndTaskModel>();
                return result;
            }

            // 数据格式错误
            if (!result.Message.Contains("{") || !result.Message.Contains("}"))
            {
                lts = new List<LogAndTaskModel>();
                return result;
            }

            // 解析数据
            try
            {
                List<LogAndTaskModel> getlrs = new List<LogAndTaskModel>();
                foreach (var row in result.Message.Split(new string[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var item = row.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (item.Count() != 5) continue; // 数据格式错误则丢弃该条数据
                    getlrs.Add(new LogAndTaskModel { Id = item[0], IsCheckTmp = item[1].ToBool(), IsCheckHtBt = item[2].ToBool(), Name = item[3], IsFilsh = item[4].ToBool() });
                }
                lts = getlrs;
                return new ELResult();
            }
            catch (Exception exception)
            {
                lts = null;
                return new ELResult { Success = false, Message = $"解析{lrtext}信息失败!" + exception.Message };
            }
        }

        /// <summary>
        /// 获取报告
        /// </summary>
        /// <param name="rid">报告Id</param>
        /// <param name="reps">获取到的报告</param>
        /// <returns></returns>
        public ELResult GetRep(string rid, out GetRepModel rep)
        {
            var result = DbSession.OrderDal.GetRep(rid);
            // 请求失败
            if (!result.Success) { rep = null; return result; }
            // 解析数据
            var item = result.Message.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (item.Count() == 0) { rep = null; return new ELResult { Success = false, Message = "没有该报告!" }; }
            if (item.Count() != 6) { rep = null; return new ELResult { Success = false, Message = "获取报告信息失败!请重试." }; } // 数据格式错误
            rep = new GetRepModel { UName = item[0], Sex = item[1], Age = item[2], DName = item[3], Tmp = item[4], HtBt = item[5] };
            return new ELResult();
        }

        /// <summary>
        /// 获取体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <param name="pe">获取到的体检信息</param>
        /// <returns></returns>
        public ELResult GetPe(string pid, out GetPeModel pe)
        {
            var result = DbSession.OrderDal.GetPe(pid);
            if (!result.Success) { pe = null; return result; }
            var item = result.Message.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (item.Count() == 0) { pe = null; return new ELResult { Success = false, Message = "没有该体检任务!" }; }
            if (item.Count() != 6) { pe = null; return new ELResult { Success = false, Message = "获取体检信息失败!请重试." }; } // 数据格式错误
            pe = new GetPeModel { UName = item[0], Sex = item[1], Age = item[2], DName = item[3], IsCheckTmp = item[4].ToBool(), IsCheckHtBt = item[5].ToBool() };
            return new ELResult();
        }

        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="pid">体检Id</param>
        /// <returns></returns>
        public ELResult Pet(string pid)
        {
            var result = DbSession.OrderDal.Pet(pid);
            if (!result.Success) return result;
            return new ELResult { Success = result.Message.ToLower().Contains(SocktRecType.RecOK) ? true : false, Message = result.Message };
        }
    }
}
