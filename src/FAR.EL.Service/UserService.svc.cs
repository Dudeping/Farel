using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FAR.EL.BLL;
using FAR.EL.Common;
using FAR.EL.Models;

namespace FAR.EL.Service
{
    /// <summary>
    /// 用户服务
    /// 在 UserService.svc 上点击调试调试该服务
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// UserBll
        /// </summary>
        public IUserBll UserBll { get; set; } = BllStaticFactory.GetUserBll();

        /// <summary>
        /// 获取医生
        /// </summary>
        /// <returns></returns>
        public List<GetDrModel> GetDr() => UserBll.GetDr(out List<GetDrModel> drs).Success ? drs : new List<GetDrModel>();

        /// <summary>
        /// 登录
        /// 登录成功后用户/医生Id在Message中
        /// </summary>
        /// <param name="model">登录数据模型</param>
        /// <returns></returns>
        public ELResult Login(LoginModel model) => UserBll.Login(model);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">注册数据模型</param>
        /// <returns></returns>
        public ELResult Register(RegisterModel model) => UserBll.Register(model);
    }
}
