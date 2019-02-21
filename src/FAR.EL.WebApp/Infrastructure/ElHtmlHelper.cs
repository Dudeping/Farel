using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FAR.EL.WebApp.Infrastructure
{
    /// <summary>
    /// Html帮助类
    /// </summary>
    public static class ElHtmlHelper
    {
        /// <summary>
        /// 获取表格Css
        /// </summary>
        /// <param name="html"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static HtmlString GetTableCss(this HtmlHelper html, int color)
        {
            int css = color % 9;
            return new MvcHtmlString(
                css == 0 ? "active" :
                css == 2 ? "success" :
                css == 4 ? "info" :
                css == 6 ? "warning" :
                css == 8 ? "danger" : ""
                );
        }
    }
}