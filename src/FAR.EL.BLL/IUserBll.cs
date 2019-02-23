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
    /// IUserBll 用于约束 UserBll 和降低与 Service 层之间的耦合
    /// </summary>
    public interface IUserBll
    {
        /// <summary>
        /// 登录
        /// 登录成功后用户/医生Id在Message中
        /// </summary>
        /// <param name="model">登录数据</param>
        /// <returns></returns>
        ELResult Login(LoginModel model);

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">注册提交数据模型</param>
        /// <returns></returns>
        ELResult Register(RegisterModel model);

        /// <summary>
        /// 获取医生
        /// </summary>
        /// <param name="drs">获取到的医生列表</param>
        /// <returns></returns>
        ELResult GetDr(out List<GetDrModel> drs);
    }
}
