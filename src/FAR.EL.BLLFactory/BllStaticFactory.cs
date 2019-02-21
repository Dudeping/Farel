using FAR.EL.BLL;
using FAR.EL.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.BLLFactory
{
    /// <summary>
    /// BLL 层静态工厂
    /// 用于获取BLL
    /// </summary>
    public class BllStaticFactory
    {
        /// <summary>
        /// 获取 UserBll
        /// </summary>
        /// <returns></returns>
        public static IUserBll GetUserBll() => new UserBll();

        /// <summary>
        /// 获取 OrderBll
        /// </summary>
        /// <returns></returns>
        public static IOrderBll GetOrderBll() => new OrderBll();
    }
}
