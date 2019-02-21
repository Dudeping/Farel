using FAR.EL.Common;
using FAR.EL.Models;
using FAR.EL.WebApp.Infrastructure;
using FAR.EL.WebApp.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FAR.EL.WebApp.Controllers
{
    /// <summary>
    /// 账户控制器
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// 用户服务
        /// </summary>
        private IUserService UserService { get; set; } = ServiceStaticFactory.GetUserService();

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Login() => View();

        /// <summary>
        /// 处理登录
        /// </summary>
        /// <param name="model">提交登录数据</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = UserService.Login(model);
                if (result.Success)
                {
                    var ticket = new FormsAuthenticationTicket(1, result.Message, DateTime.Now, DateTime.Now.AddMinutes(30), false, model.Type == LoginType.User ? RoleType.User.ToString() : RoleType.Dr.ToString());
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "User");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register() => View();

        /// <summary>
        /// 处理注册
        /// </summary>
        /// <param name="model">提交的注册数据</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = UserService.Register(model);
                if (result.Success) return Content(ELRetHelper.GetText("注册成功!", Url.Action("Index", "Home")));
                ModelState.AddModelError("", result.Message);
            }
            return View();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}