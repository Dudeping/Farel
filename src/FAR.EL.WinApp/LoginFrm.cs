using FAR.EL.Common;
using FAR.EL.WinApp.OrderServiceReference;
using FAR.EL.WinApp.UserServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAR.EL.WinApp
{
    public partial class LoginFrm : Form
    {
        /// <summary>
        /// 是否跳转到注册
        /// </summary>
        private bool IsToSignin = false;

        public LoginFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // 校验账号
            if (string.IsNullOrWhiteSpace(TxtAccount.Text) || TxtAccount.TextLength > 10)
            {
                MessageBox.Show("账号长度应该在1-10位之内!", "用户名格式错误");
                return;
            }

            // 校验密码
            if (string.IsNullOrWhiteSpace(TxtPassword.Text) || TxtPassword.TextLength > 10)
            {
                MessageBox.Show("密码长度应该在1-10位之内!", "密码格式错误");
                return;
            }

            // 登录
            var result = LoginInfo.UserService.Login(new Models.LoginModel { Type = RdBtnUser.Checked ? Models.LoginType.User : Models.LoginType.Dr, Account = TxtAccount.Text, Password = TxtPassword.Text });

            if (!result.Success)
            {
                MessageBox.Show(result.Message, "登录失败");
                return;
            }

            MessageBox.Show("登录成功!", "成功");

            // 登录成功
            LoginInfo.IsLogin = true;
            LoginInfo.LoginType = RdBtnUser.Checked ? Models.RoleType.User : Models.RoleType.Dr;
            LoginInfo.Id = result.Message;
            Close();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // 关闭程序
            LoginInfo.MainFrm.Close();
        }

        /// <summary>
        /// 去注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabToSignin_Click(object sender, EventArgs e)
        {
            IsToSignin = true;
            Close();
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (LoginInfo.IsLogin)
            {
                // 已登录
                if (LoginInfo.LoginType == Models.RoleType.Dr)
                {
                    // 任务
                    TasksFrm tasksFrm = new TasksFrm();
                    tasksFrm.Show();
                    return;
                }
                else
                {
                    // 记录
                    LogsFrm logsFrm = new LogsFrm();
                    logsFrm.Show();
                    return;
                }
            }

            if (IsToSignin)
            {
                // 去注册
                SigninFrm signinFrm = new SigninFrm();
                signinFrm.Show();
                return;
            }

            // 退出程序
            LoginInfo.MainFrm.Close();
        }
    }
}
