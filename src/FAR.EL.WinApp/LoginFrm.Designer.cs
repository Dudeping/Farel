namespace FAR.EL.WinApp
{
    partial class LoginFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.TxtAccount = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.labAccount = new System.Windows.Forms.Label();
            this.labPasswd = new System.Windows.Forms.Label();
            this.RdBtnUser = new System.Windows.Forms.RadioButton();
            this.RdBtnDr = new System.Windows.Forms.RadioButton();
            this.LabToSignin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtAccount
            // 
            this.TxtAccount.Location = new System.Drawing.Point(163, 36);
            this.TxtAccount.Name = "TxtAccount";
            this.TxtAccount.Size = new System.Drawing.Size(127, 21);
            this.TxtAccount.TabIndex = 0;
            // 
            // BtnLogin
            // 
            this.BtnLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnLogin.Location = new System.Drawing.Point(101, 168);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 23);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "登录";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(217, 166);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "退出";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtPassword
            // 
            this.TxtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TxtPassword.Location = new System.Drawing.Point(163, 81);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(127, 21);
            this.TxtPassword.TabIndex = 1;
            // 
            // labAccount
            // 
            this.labAccount.AutoSize = true;
            this.labAccount.Location = new System.Drawing.Point(90, 41);
            this.labAccount.Name = "labAccount";
            this.labAccount.Size = new System.Drawing.Size(53, 12);
            this.labAccount.TabIndex = 7;
            this.labAccount.Text = "用户名：";
            // 
            // labPasswd
            // 
            this.labPasswd.AutoSize = true;
            this.labPasswd.Location = new System.Drawing.Point(99, 88);
            this.labPasswd.Name = "labPasswd";
            this.labPasswd.Size = new System.Drawing.Size(41, 12);
            this.labPasswd.TabIndex = 8;
            this.labPasswd.Text = "密码：";
            // 
            // RdBtnUser
            // 
            this.RdBtnUser.AutoSize = true;
            this.RdBtnUser.Checked = true;
            this.RdBtnUser.Location = new System.Drawing.Point(132, 131);
            this.RdBtnUser.Name = "RdBtnUser";
            this.RdBtnUser.Size = new System.Drawing.Size(59, 16);
            this.RdBtnUser.TabIndex = 2;
            this.RdBtnUser.TabStop = true;
            this.RdBtnUser.Text = "体检者";
            this.RdBtnUser.UseVisualStyleBackColor = true;
            // 
            // RdBtnDr
            // 
            this.RdBtnDr.AutoSize = true;
            this.RdBtnDr.Location = new System.Drawing.Point(217, 131);
            this.RdBtnDr.Name = "RdBtnDr";
            this.RdBtnDr.Size = new System.Drawing.Size(47, 16);
            this.RdBtnDr.TabIndex = 3;
            this.RdBtnDr.Text = "医生";
            this.RdBtnDr.UseVisualStyleBackColor = true;
            // 
            // LabToSignin
            // 
            this.LabToSignin.AutoSize = true;
            this.LabToSignin.Location = new System.Drawing.Point(231, 212);
            this.LabToSignin.Name = "LabToSignin";
            this.LabToSignin.Size = new System.Drawing.Size(59, 12);
            this.LabToSignin.TabIndex = 6;
            this.LabToSignin.Text = "去注册 >>";
            this.LabToSignin.Click += new System.EventHandler(this.LabToSignin_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(402, 243);
            this.Controls.Add(this.LabToSignin);
            this.Controls.Add(this.RdBtnDr);
            this.Controls.Add(this.RdBtnUser);
            this.Controls.Add(this.labPasswd);
            this.Controls.Add(this.labAccount);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.TxtAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录 - 智能医疗平台";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginFrm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtAccount;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label labAccount;
        private System.Windows.Forms.Label labPasswd;
        private System.Windows.Forms.RadioButton RdBtnUser;
        private System.Windows.Forms.RadioButton RdBtnDr;
        private System.Windows.Forms.Label LabToSignin;
    }
}