using FAR.EL.Models;
using FAR.EL.WinApp.OrderServiceReference;
using FAR.EL.WinApp.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAR.EL.WinApp
{
    /// <summary>
    /// 当前登录信息
    /// </summary>
    public static class LoginInfo
    {
        /// <summary>
        /// 是否登录
        /// </summary>
        public static bool IsLogin { get; set; } = false;

        /// <summary>
        /// 体检者/医生Id
        /// </summary>
        public static string Id { get; set; }

        /// <summary>
        /// 登录类型
        /// </summary>
        public static RoleType LoginType { get; set; }

        /// <summary>
        /// 获取体检 Id
        /// </summary>
        public static string PId { get; set; }

        /// <summary>
        /// 获取报告 Id
        /// </summary>
        public static string RId { get; set; }

        /// <summary>
        /// 主窗体
        /// </summary>
        public static Form MainFrm;

        /// <summary>
        /// 用户服务
        /// </summary>
        /// <returns></returns>
        public static IUserService UserService { get; set; } = new UserServiceClient();

        /// <summary>
        /// Order 服务
        /// </summary>
        /// <returns></returns>
        public static IOrderService OrderService { get; set; } = new OrderServiceClient();
    }
}
