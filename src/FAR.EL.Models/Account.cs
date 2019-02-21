using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.Models
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 登录类型
        /// </summary>
        public LoginType Type { get; set; }

        /// <summary>
        /// 账号 1-10位
        /// </summary>
        [DisplayName("用户名")]
        [Required(ErrorMessage = "{0}为必填项！")]
        [StringLength(10, ErrorMessage = "{0}应该在{2}-{1}位之间！", MinimumLength = 1)]
        public string Account { get; set; }

        /// <summary>
        /// 密码 1-10位
        /// </summary>
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}为必填项！")]
        [StringLength(10, ErrorMessage = "{0}应该在{2}-{1}位之间！", MinimumLength = 1)]
        public string Password { get; set; }
    }

    /// <summary>
    /// 注册模型
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// 账号 1-10位
        /// </summary>
        [DisplayName("用户名")]
        [Required(ErrorMessage = "{0}为必填项！")]
        [StringLength(10, ErrorMessage = "{0}应该在{2}-{1}位之间！", MinimumLength = 1)]
        public string Account { get; set; }

        /// <summary>
        /// 密码 1-10位
        /// </summary>
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}为必填项！")]
        [StringLength(10, ErrorMessage = "{0}应该在{2}-{1}位之间！", MinimumLength = 1)]
        public string Password { get; set; }

        /// <summary>
        /// 姓名 1-10位
        /// </summary>
        [DisplayName("姓名")]
        [Required(ErrorMessage = "{0}为必填项！")]
        [StringLength(10, ErrorMessage = "{0}应该在{2}-{1}位之间！", MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// 性别 true:男， false:女
        /// </summary>
        public bool Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [DisplayName("年龄")]
        [Required(ErrorMessage = "{0}为必填项！")]
        [Range(1, 99, ErrorMessage = "{0}应该在{1}-{2}之间")]
        public int Age { get; set; }
    }

    /// <summary>
    /// 登录类型
    /// </summary>
    public enum LoginType
    {
        /// <summary>
        /// 体检者
        /// </summary>
        User,
        /// <summary>
        /// 医生
        /// </summary>
        Dr
    }

    /// <summary>
    /// 角色类型
    /// </summary>
    public enum RoleType
    {
        /// <summary>
        /// 体检者
        /// </summary>
        User,
        /// <summary>
        /// 医生
        /// </summary>
        Dr
    }
}
