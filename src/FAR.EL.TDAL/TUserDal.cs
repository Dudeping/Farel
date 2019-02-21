using FAR.EL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAR.EL.Common;
using FAR.EL.Models;

namespace FAR.EL.TDAL
{
    /// <summary>
    /// 测试用 UserDal
    /// </summary>
    public class TUserDal : IUserDal
    {
        public ELResult GetDr() => new ELResult { Success = true, Message = "{1,张三三}{2,李武}{3,刘莉莉}" };
        public ELResult Login(LoginModel model)
        {
            var isok = (model.Account == "user" && model.Type == LoginType.User) || (model.Account == "dr" && model.Type == LoginType.Dr);
            return new ELResult { Success = true, Message = isok ? "1" : "NO" };
        }
        public ELResult Register(RegisterModel model) => new ELResult { Success = true, Message = "OK" };
    }
}
