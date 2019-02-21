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
    public partial class OrderFrm : Form
    {
        /// <summary>
        /// 医生列表
        /// </summary>
        Dictionary<string, string> Drs = new Dictionary<string, string>();

        public OrderFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderFrm_Load(object sender, EventArgs e)
        {
            // 获取医生
            var drs = LoginInfo.UserService.GetDr();
            if (drs.Count() == 0)
            {
                MessageBox.Show("获取医生失败!", "失败");
                Close();
                return;
            }

            foreach (var dr in drs)
            {
                Drs.Add(dr.Id, dr.Name);
                ComBoxDr.Items.Add(dr.Name);
            }
        }

        /// <summary>
        /// 预约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ComBoxDr.Text))
            {
                MessageBox.Show("未选择医生!", "失败");
                return;
            }

            var drs = Drs.Where(p => p.Value == ComBoxDr.Text);
            if (!drs.Any())
            {
                MessageBox.Show("获取选择的医生失败!请重试.", "失败");
                return;
            }

            var result = LoginInfo.OrderService.Order(new Models.OrderModel { UId = LoginInfo.Id, DId = drs.FirstOrDefault().Key, IsChckeHtBt = ChCkHtBt.Checked, IsChckeTmp = ChCkTmp.Checked });
            if (result.Success)
            {
                MessageBox.Show("预约成功!", "成功");
                Close();
                return;
            }

            MessageBox.Show(result.Message, "成功");
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
    }
}
