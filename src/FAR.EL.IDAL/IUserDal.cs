using FAR.EL.Common;
using FAR.EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.IDAL
{
    /// <summary>
    /// IUserDal
    /// 用于约束 UserDal，和降低与 BLL 层之间的耦合
    /// </summary>
    public interface IUserDal
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
        /// <returns></returns>
        ELResult GetDr();
    }
}
