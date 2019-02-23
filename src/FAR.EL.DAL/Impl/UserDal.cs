using FAR.EL.Common;
using FAR.EL.DAL.Common;
using FAR.EL.DAL;
using FAR.EL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.DAL
{
    /// <summary>
    /// UserDal
    /// </summary>
    public class UserDal: BaseDal, IUserDal
    {
        /// <summary>
        /// 登录
        /// 登录成功后用户/医生Id在Message中
        /// </summary>
        /// <param name="model">登录数据</param>
        /// <returns></returns>
        public ELResult Login(LoginModel model)
        {
            return Request(model.Type == LoginType.User ? ELReqType.ulogin.To8Bytes() : ELReqType.dlogin.To8Bytes(), model.Account.FillUTF8(10), model.Password.FillUTF8(10));
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">注册提交数据模型</param>
        /// <returns></returns>
        public ELResult Register(RegisterModel model)
        {
            return Request(ELReqType.signin.To8Bytes(), model.Account.FillUTF8(10), model.Password.FillUTF8(10), model.Name.FillUTF8(10), model.Sex.ToChars(), model.Age.ToString().FillUTF8(2));
        }

        /// <summary>
        /// 获取医生
        /// </summary>
        /// <returns></returns>
        public ELResult GetDr() => Request(ELReqType.getdr.To8Bytes());
    }
}
