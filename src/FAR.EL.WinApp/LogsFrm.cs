using FAR.EL.Models;
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
    public partial class LogsFrm : Form
    {
        /// <summary>
        /// 是否跳转到登录
        /// </summary>
        private bool IsToLogin = false;

        public LogsFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void LoadLogsData()
        {
            DataLogs.Rows.Clear();
            foreach (var log in LoginInfo.OrderService.GetLogs(LoginInfo.Id))
            {
                var row = new DataGridViewRow();
                row.CreateCells(DataLogs);
                row.Cells[0].Value = log.Id;
                row.Cells[1].Value = log.IsCheckTmp;
                row.Cells[2].Value = log.IsCheckHtBt;
                row.Cells[3].Value = log.Name;
                row.Cells[4].Value = log.IsFilsh ? "已完成" : "未完成";
                DataLogs.Rows.Add(row);
            }
        }

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogsFrm_Load(object sender, EventArgs e)
        {
            // 校验是否登录
            if (!LoginInfo.IsLogin)
            {
                IsToLogin = true;
                Close();
                return;
            }
            // 加载数据
            LoadLogsData();
        }

        /// <summary>
        /// 单元格点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (DataLogs.CurrentCell.Value.ToString() == "已完成")
                {
                    // 报告 Id
                    LoginInfo.RId = DataLogs.CurrentRow.Cells[0].Value.ToString();
                    // 打开报告
                    ShowRepFrm showRepFrm = new ShowRepFrm();
                    showRepFrm.ShowDialog();
                    // 刷新
                    LoadLogsData();
                }
            }
        }

        /// <summary>
        /// 去预约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOrder_Click(object sender, EventArgs e)
        {
            OrderFrm orderFrm = new OrderFrm();
            orderFrm.ShowDialog();
            // 刷新
            LoadLogsData();
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogsFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsToLogin)
            {
                LoginFrm loginFrm = new LoginFrm();
                loginFrm.Show();
                return;
            }

            // 退出程序
            LoginInfo.MainFrm.Close();
        }
    }
}
