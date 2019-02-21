using FAR.EL.Common;
using FAR.EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FAR.EL.Service
{
    /// <summary>
    /// 账户服务
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// 登录成功后用户/医生Id在Message中
        /// </summary>
        /// <param name="model">登录数据</param>
        /// <returns></returns>
        [OperationContract]
        ELResult Login(LoginModel model);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">注册提交数据模型</param>
        /// <returns></returns>
        [OperationContract]
        ELResult Register(RegisterModel model);

        /// <summary>
        /// 获取医生
        /// </summary>
        /// <param name="drs">获取到的医生列表</param>
        /// <returns></returns>
        [OperationContract]
        List<GetDrModel> GetDr();
    }
}
