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
    public partial class ShowRepFrm : Form
    {
        public ShowRepFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowRepFrm_Load(object sender, EventArgs e)
        {
            // 获取报告
            var rep = LoginInfo.OrderService.GetRep(LoginInfo.RId);
            if (rep == null)
            {
                MessageBox.Show("获取报告失败!", "失败");
                Close();
                return;
            }

            var uname = new DataGridViewRow();
            uname.CreateCells(RepList);
            uname.Cells[0].Value = "姓名";
            uname.Cells[1].Value = rep.UName;
            RepList.Rows.Add(uname);

            var sex = new DataGridViewRow();
            sex.CreateCells(RepList);
            sex.Cells[0].Value = "性别";
            sex.Cells[1].Value = rep.Sex == "1" ? "男" : "女";
            RepList.Rows.Add(sex);

            var age = new DataGridViewRow();
            age.CreateCells(RepList);
            age.Cells[0].Value = "年龄";
            age.Cells[1].Value = rep.Age;
            RepList.Rows.Add(age);

            var dname = new DataGridViewRow();
            dname.CreateCells(RepList);
            dname.Cells[0].Value = "医生姓名";
            dname.Cells[1].Value = rep.DName;
            RepList.Rows.Add(dname);

            var tmp = new DataGridViewRow();
            tmp.CreateCells(RepList);
            tmp.Cells[0].Value = "体温";
            tmp.Cells[1].Value = rep.Tmp == "0" ? "未体检" : rep.Tmp + " ℃";
            RepList.Rows.Add(tmp);

            var htbt = new DataGridViewRow();
            htbt.CreateCells(RepList);
            htbt.Cells[0].Value = "心跳";
            htbt.Cells[1].Value = rep.HtBt == "0" ? "未体检" : rep.HtBt + " / m";
            RepList.Rows.Add(htbt);
        }
    }
}
