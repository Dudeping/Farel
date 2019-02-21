namespace FAR.EL.WinApp
{
    partial class SigninFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SigninFrm));
            this.LabToLogin = new System.Windows.Forms.Label();
            this.RdBtnFemale = new System.Windows.Forms.RadioButton();
            this.RdBtnMan = new System.Windows.Forms.RadioButton();
            this.labPasswd = new System.Windows.Forms.Label();
            this.labAccount = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSignin = new System.Windows.Forms.Button();
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.LabName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LabAge = new System.Windows.Forms.Label();
            this.TxtAge = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabToLogin
            // 
            this.LabToLogin.AutoSize = true;
            this.LabToLogin.Location = new System.Drawing.Point(96, 308);
            this.LabToLogin.Name = "LabToLogin";
            this.LabToLogin.Size = new System.Drawing.Size(59, 12);
            this.LabToLogin.TabIndex = 8;
            this.LabToLogin.Text = "<< 去登录";
            this.LabToLogin.Click += new System.EventHandler(this.LabToLogin_Click);
            // 
            // RdBtnFemale
            // 
            this.RdBtnFemale.AutoSize = true;
            this.RdBtnFemale.Location = new System.Drawing.Point(226, 217);
            this.RdBtnFemale.Name = "RdBtnFemale";
            this.RdBtnFemale.Size = new System.Drawing.Size(35, 16);
            this.RdBtnFemale.TabIndex = 5;
            this.RdBtnFemale.Text = "女";
            this.RdBtnFemale.UseVisualStyleBackColor = true;
            // 
            // RdBtnMan
            // 
            this.RdBtnMan.AutoSize = true;
            this.RdBtnMan.Checked = true;
            this.RdBtnMan.Location = new System.Drawing.Point(141, 217);
            this.RdBtnMan.Name = "RdBtnMan";
            this.RdBtnMan.Size = new System.Drawing.Size(35, 16);
            this.RdBtnMan.TabIndex = 4;
            this.RdBtnMan.TabStop = true;
            this.RdBtnMan.Text = "男";
            this.RdBtnMan.UseVisualStyleBackColor = true;
            // 
            // labPasswd
            // 
            this.labPasswd.AutoSize = true;
            this.labPasswd.Location = new System.Drawing.Point(108, 83);
            this.labPasswd.Name = "labPasswd";
            this.labPasswd.Size = new System.Drawing.Size(41, 12);
            this.labPasswd.TabIndex = 10;
            this.labPasswd.Text = "密码：";
            // 
            // labAccount
            // 
            this.labAccount.AutoSize = true;
            this.labAccount.Location = new System.Drawing.Point(96, 41);
            this.labAccount.Name = "labAccount";
            this.labAccount.Size = new System.Drawing.Size(53, 12);
            this.labAccount.TabIndex = 9;
            this.labAccount.Text = "用户名：";
            // 
            // TxtPassword
            // 
            this.TxtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TxtPassword.Location = new System.Drawing.Point(172, 80);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(127, 21);
            this.TxtPassword.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(226, 253);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "退出";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSignin
            // 
            this.BtnSignin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSignin.Location = new System.Drawing.Point(110, 254);
            this.BtnSignin.Name = "BtnSignin";
            this.BtnSignin.Size = new System.Drawing.Size(75, 23);
            this.BtnSignin.TabIndex = 6;
            this.BtnSignin.Text = "注册";
            this.BtnSignin.UseVisualStyleBackColor = true;
            this.BtnSignin.Click += new System.EventHandler(this.BtnSignin_Click);
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(172, 38);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(127, 21);
            this.TxtAccount.TabIndex = 0;
            // 
            // LabName
            // 
            this.LabName.AutoSize = true;
            this.LabName.Location = new System.Drawing.Point(108, 129);
            this.LabName.Name = "LabName";
            this.LabName.Size = new System.Drawing.Size(41, 12);
            this.LabName.TabIndex = 11;
            this.LabName.Text = "姓名：";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(172, 126);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(127, 21);
            this.TxtName.TabIndex = 2;
            // 
            // LabAge
            // 
            this.LabAge.AutoSize = true;
            this.LabAge.Location = new System.Drawing.Point(108, 176);
            this.LabAge.Name = "LabAge";
            this.LabAge.Size = new System.Drawing.Size(41, 12);
            this.LabAge.TabIndex = 12;
            this.LabAge.Text = "年龄：";
            // 
            // TxtAge
            // 
            this.TxtAge.Location = new System.Drawing.Point(172, 172);
            this.TxtAge.Name = "TxtAge";
            this.TxtAge.Size = new System.Drawing.Size(127, 21);
            this.TxtAge.TabIndex = 3;
            // 
            // SigninFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 351);
            this.Controls.Add(this.LabAge);
            this.Controls.Add(this.TxtAge);
            this.Controls.Add(this.LabName);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LabToLogin);
            this.Controls.Add(this.RdBtnFemale);
            this.Controls.Add(this.RdBtnMan);
            this.Controls.Add(this.labPasswd);
            this.Controls.Add(this.labAccount);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSignin);
            this.Controls.Add(this.TxtAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SigninFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册 - 智能医疗平台";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SigninFrm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabToLogin;
        private System.Windows.Forms.RadioButton RdBtnFemale;
        private System.Windows.Forms.RadioButton RdBtnMan;
        private System.Windows.Forms.Label labPasswd;
        private System.Windows.Forms.Label labAccount;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSignin;
        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Label LabName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LabAge;
        private System.Windows.Forms.TextBox TxtAge;
    }
}