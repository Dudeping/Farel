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
    public partial class PetFrm : Form
    {
        public PetFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PetFrm_Load(object sender, EventArgs e)
        {
            var pet = LoginInfo.OrderService.GetPe(LoginInfo.PId);
            if (pet == null)
            {
                MessageBox.Show("获取该体检信息失败！", "失败");
                Close();
                return;
            }

            var uname = new DataGridViewRow();
            uname.CreateCells(PetList);
            uname.Cells[0].Value = "姓名";
            uname.Cells[1].Value = pet.UName;
            PetList.Rows.Add(uname);

            var sex = new DataGridViewRow();
            sex.CreateCells(PetList);
            sex.Cells[0].Value = "性别";
            sex.Cells[1].Value = pet.Sex;
            PetList.Rows.Add(sex);

            var age = new DataGridViewRow();
            age.CreateCells(PetList);
            age.Cells[0].Value = "年龄";
            age.Cells[1].Value = pet.Age;
            PetList.Rows.Add(age);

            var dname = new DataGridViewRow();
            dname.CreateCells(PetList);
            dname.Cells[0].Value = "医生";
            dname.Cells[1].Value = pet.DName;
            PetList.Rows.Add(dname);

            var tmp = new DataGridViewRow();
            tmp.CreateCells(PetList);
            tmp.Cells[0].Value = "体检体温";
            tmp.Cells[1].Value = pet.IsCheckTmp ? "是" : "否";
            PetList.Rows.Add(tmp);

            var htbt = new DataGridViewRow();
            htbt.CreateCells(PetList);
            htbt.Cells[0].Value = "体检心跳";
            htbt.Cells[1].Value = pet.IsCheckTmp ? "是" : "否";
            PetList.Rows.Add(htbt);
        }

        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPet_Click(object sender, EventArgs e)
        {
            var result = LoginInfo.OrderService.Pet(LoginInfo.PId);
            if (result.Success)
            {
                MessageBox.Show("体检成功!", "成功");
                Close();
                return;
            }

            MessageBox.Show(result.Message, "失败");
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
