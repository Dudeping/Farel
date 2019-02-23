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
    /// <summary>
    /// UserBll
    /// </summary>
    internal class UserBll : IUserBll
    {
        /// <summary>
        /// 当前 Session
        /// </summary>
        private IDbSession DbSession { get; set; } = DALStaticFactory.GetDbSession();

        /// <summary>
        /// 登录
        /// 登录成功后用户/医生Id在Message中
        /// </summary>
        /// <param name="model">登录数据</param>
        /// <returns></returns>
        public ELResult Login(LoginModel model)
        {
            // 校验数据
            if (model.Account.IsContainsCH()) return new ELResult { Success = false, Message = "用户名中不能含中文!" };
            // 登录
            var result = DbSession.UserDal.Login(model);
            if (!result.Success) return result;
            return new ELResult { Success = result.Message.Length > 2 ? false : true, Message = result.Message };
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model">注册提交数据模型</param>
        /// <returns></returns>
        public ELResult Register(RegisterModel model)
        {
            // 校验数据
            if (model.Account.IsContainsCH()) return new ELResult { Success = false, Message = "用户名中不能含中文!" };
            if (!model.Name.CheckTotalCount(10)) return new ELResult { Success = false, Message = "用户中文姓名不能超过3个字!"};

            // 注册
            var result = DbSession.UserDal.Register(model);
            if (!result.Success) return result;
            return new ELResult { Success = result.Message.ToLower().Contains(SocktRecType.RecOK) ? true: false, Message = result.Message };
        }

        /// <summary>
        /// 获取医生
        /// </summary>
        /// <param name="drs">获取到的医生列表</param>
        /// <returns></returns>
        public ELResult GetDr(out List<GetDrModel> drs)
        {
            var result = DbSession.UserDal.GetDr();

            // 失败
            if (!result.Success)
            {
                drs = null;
                return result;
            }

            // 没有数据
            if (result.Message.Length <= 0)
            {
                drs = new List<GetDrModel>();
                return result;
            }

            // 数据格式错误
            if (!result.Message.Contains("{") || !result.Message.Contains("}"))
            {
                drs = new List<GetDrModel>();
                return result;
            }

            try
            {
                List<GetDrModel> getDrs = new List<GetDrModel>();
                foreach (var row in result.Message.Split(new string[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var item = row.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (item.Count() != 2) continue; // 数据格式错误则丢弃该条数据
                    getDrs.Add(new GetDrModel { Id = item[0], Name = item[1] });
                }
                drs = getDrs;
                return new ELResult();
            }
            catch (Exception exception)
            {
                drs = null;
                return new ELResult { Success = false, Message = "解析医生信息失败!" + exception.Message };
            }
        }
    }
}
