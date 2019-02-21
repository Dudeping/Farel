using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.Common
{
    /// <summary>
    /// 系统方法返回类型
    /// </summary>
    [DataContract]
    public class ELResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [DataMember]
        public bool Success { get; set; } = true;

        /// <summary>
        /// 处理结果信息
        /// </summary>
        [DataMember]
        public string Message { get; set; } = "OK";
    }

    /// <summary>
    /// Socket请求类型
    /// </summary>
    public enum ELReqType
    {
        /// <summary>
        /// 注册
        /// </summary>
        signin,
        /// <summary>
        /// 体检者的登录
        /// </summary>
        ulogin,
        /// <summary>
        /// 获取医生
        /// </summary>
        getdr,
        /// <summary>
        /// 预约
        /// </summary>
        order,
        /// <summary>
        /// 获取记录
        /// </summary>
        getlog,
        /// <summary>
        /// 获取报告
        /// </summary>
        getrep,
        /// <summary>
        /// 医生登录
        /// </summary>
        dlogin,
        /// <summary>
        /// 获取任务
        /// </summary>
        getask,
        /// <summary>
        /// 获取体检
        /// </summary>
        getpe,
        /// <summary>
        /// 体检
        /// </summary>
        pet
    }

    /// <summary>
    /// Socket 返回类型
    /// </summary>
    public struct SocktRecType
    {
        /// <summary>
        /// Socket 服务器返回正确
        /// </summary>
        public static string RecOK = "ok";

        /// <summary>
        /// Socket 服务器返回正确
        /// </summary>
        public static string RecNO = "no";
    }
}
