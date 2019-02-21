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
    public partial class TasksFrm : Form
    {
        /// <summary>
        /// 是否跳转到登录
        /// </summary>
        private bool IsToLogin = false;

        public TasksFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void LoadTaskData()
        {
            DataTasks.Rows.Clear();
            foreach (var task in LoginInfo.OrderService.Getasks(LoginInfo.Id))
            {
                var row = new DataGridViewRow();
                row.CreateCells(DataTasks);
                row.Cells[0].Value = task.Id;
                row.Cells[1].Value = task.Name;
                row.Cells[2].Value = task.IsCheckTmp;
                row.Cells[3].Value = task.IsCheckHtBt;
                row.Cells[4].Value = task.IsFilsh ? "已完成" : "未完成";
                DataTasks.Rows.Add(row);
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TasksFrm_Load(object sender, EventArgs e)
        {
            // 校验是否登录
            if (!LoginInfo.IsLogin)
            {
                IsToLogin = true;
                Close();
                return;
            }
            // 加载数据
            LoadTaskData();
        }

        /// <summary>
        /// 单元格点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (DataTasks.CurrentCell.Value.ToString() == "已完成")
                {
                    // 报告 Id
                    LoginInfo.RId = DataTasks.CurrentRow.Cells[0].Value.ToString();
                    // 打开报告
                    ShowRepFrm showRepFrm = new ShowRepFrm();
                    showRepFrm.ShowDialog();
                    // 刷新
                    LoadTaskData();
                }
                else
                {
                    // 体检 Id
                    LoginInfo.PId = DataTasks.CurrentRow.Cells[0].Value.ToString();
                    // 体检
                    PetFrm petFrm = new PetFrm();
                    petFrm.ShowDialog();
                    // 刷新
                    LoadTaskData();
                }
            }
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TasksFrm_FormClosed(object sender, FormClosedEventArgs e)
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
