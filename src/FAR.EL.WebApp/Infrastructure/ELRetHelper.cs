using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAR.EL.WebApp.Infrastructure
{
    /// <summary>
    /// Action返回帮助类
    /// </summary>
    public class ELRetHelper
    {
        /// <summary>
        /// 获取JavaScript代码
        /// </summary>
        /// <param name="text"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetText(string text, string url)
        {
            return $"<script>alert('{text}'); location.href='{url}';</script>";
        }
    }
}