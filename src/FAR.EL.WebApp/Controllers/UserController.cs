using FAR.EL.Models;
using FAR.EL.WebApp.Infrastructure;
using FAR.EL.WebApp.OrderServiceReference;
using FAR.EL.WebApp.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAR.EL.WebApp.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Authorize]
    public class UserController : Controller
    {
        /// <summary>
        /// 用户服务
        /// </summary>
        private IUserService UserService { get; set; } = ServiceStaticFactory.GetUserService();
        /// <summary>
        /// Order服务
        /// </summary>
        private IOrderService OrderService { get; set; } = ServiceStaticFactory.GetOrderService();

        /// <summary>
        /// 用户首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() => RedirectToAction(User.IsInRole(RoleType.User.ToString()) ? "Logs" : "Tasks");

        /// <summary>
        /// 任务列表
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Dr")]
        public ActionResult Tasks() => View(OrderService.Getasks(User.Identity.Name));

        /// <summary>
        /// 记录
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "User")]
        public ActionResult Logs() => View(OrderService.GetLogs(User.Identity.Name));

        /// <summary>
        /// 预约
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult Order()
        {
            ViewBag.DrList = UserService.GetDr();
            return View();
        }

        /// <summary>
        /// 处理预约
        /// </summary>
        /// <param name="model">预约提交信息</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Order(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var result = OrderService.Order(model);
                if (result.Success) return Content(ELRetHelper.GetText("预约成功!", Url.Action("Logs", "User")));
                ModelState.AddModelError("", result.Message);
            }
            ViewBag.DrList = UserService.GetDr();
            return View();
        }

        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="pid">当前体检任务</param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Dr")]
        public ActionResult Pet(int id)
        {
            ViewBag.PId = id;
            var pet = OrderService.GetPe(id.ToString());
            return pet == null ? Content(ELRetHelper.GetText("获取体检单失败!", Url.Action("Tasks", "User"))) : View(pet) as ActionResult;
        }

        /// <summary>
        /// 处理体检
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Dr")]
        [ValidateAntiForgeryToken]
        public ActionResult Pet(string id)
        {
            var result = OrderService.Pet(id);
            if (result.Success) return Content(ELRetHelper.GetText("体检成功!", Url.Action("Tasks", "User")));
            return Content(ELRetHelper.GetText(result.Message, Url.Action("Pet", new { id = id })));
        }

        /// <summary>
        /// 显示报告
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowRep(string id)
        {
            var rep = OrderService.GetRep(id);
            return rep == null ? Content(ELRetHelper.GetText("获取报告失败!", "/User")) : View(rep) as ActionResult;
        }
    }
}