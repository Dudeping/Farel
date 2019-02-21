using FAR.EL.DAL;
using FAR.EL.IDAL;
using FAR.EL.TDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace FAR.EL.DALFactory
{
    /// <summary>
    /// DAL 层静态工厂
    /// 用于获取 DAL
    /// </summary>
    public class DALStaticFactory
    {
        /// <summary>
        /// 获取 UserDal
        /// </summary>
        /// <returns></returns>
        public static IUserDal GetUserDal() => new UserDal(); // TODO:切换DAL

        /// 获取 OrderDal
        /// </summary>
        /// <returns></returns>
        public static IOrderDal GetOrderDal() => new OrderDal();

        /// <summary>
        /// 获取 DbSession
        /// </summary>
        /// <returns></returns>
        public static IDbSession GetDbSession() => new DbSession();
    }
}