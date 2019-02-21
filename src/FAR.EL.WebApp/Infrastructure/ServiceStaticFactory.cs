using FAR.EL.WebApp.OrderServiceReference;
using FAR.EL.WebApp.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAR.EL.WebApp.Infrastructure
{
    /// <summary>
    /// Service 层静态工厂
    /// 用于获取 Service
    /// </summary>
    public class ServiceStaticFactory
    {
        /// <summary>
        /// 获取用户服务
        /// </summary>
        /// <returns></returns>
        public static IUserService GetUserService()
        {
            return new UserServiceClient();
        }

        /// <summary>
        /// 获取Order服务
        /// </summary>
        /// <returns></returns>
        public static IOrderService GetOrderService()
        {
            return new OrderServiceClient();
        }
    }
}