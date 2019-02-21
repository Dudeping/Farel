using FAR.EL.WinApp.OrderServiceReference;
using FAR.EL.WinApp.UserServiceReference;
using FAR.EL.Common;
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
    public partial class SigninFrm : Form
    {
        /// <summary>
        /// 是否跳转到登录
        /// </summary>
        private bool IsToLogin = false;

        public SigninFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSignin_Click(object sender, EventArgs e)
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

            // 校验年龄
            if (!Int32.TryParse(TxtAge.Text, out int age))
            {
                MessageBox.Show("年龄应该是填写数字!", "年龄格式错误");
                return;
            }

            // 校验年龄
            if (age > 100 || age <= 0)
            {
                MessageBox.Show("年龄应该在0-100之间!", "年龄格式错误");
                return;
            }

            // 登录
            var result = LoginInfo.UserService.Register(new Models.RegisterModel { Account = TxtAccount.Text, Password = TxtPassword.Text, Name = TxtName.Text, Age = age, Sex = RdBtnMan.Checked ? true : false });
            if (!result.Success)
            {
                MessageBox.Show(result.Message, "注册失败");
                return;
            }

            // 登录成功
            MessageBox.Show("注册成功！", "成功");
            IsToLogin = true;
            Close();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 去登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabToLogin_Click(object sender, EventArgs e)
        {
            IsToLogin = true;
            Close();
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SigninFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsToLogin)
            {
                // 去登录
                LoginFrm loginFrm = new LoginFrm();
                loginFrm.Show();
                return;
            }

            // 退出程序
            LoginInfo.MainFrm.Close();
        }
    }
}
