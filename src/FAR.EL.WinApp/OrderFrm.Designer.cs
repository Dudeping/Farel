namespace FAR.EL.WinApp
{
    partial class OrderFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderFrm));
            this.ChCkHtBt = new System.Windows.Forms.CheckBox();
            this.ChCkTmp = new System.Windows.Forms.CheckBox();
            this.BtnOrder = new System.Windows.Forms.Button();
            this.ComBoxDr = new System.Windows.Forms.ComboBox();
            this.LabSelectDr = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChCkHtBt
            // 
            this.ChCkHtBt.AutoSize = true;
            this.ChCkHtBt.Location = new System.Drawing.Point(31, 108);
            this.ChCkHtBt.Name = "ChCkHtBt";
            this.ChCkHtBt.Size = new System.Drawing.Size(102, 16);
            this.ChCkHtBt.TabIndex = 0;
            this.ChCkHtBt.Text = " 是否体检心率";
            this.ChCkHtBt.UseVisualStyleBackColor = true;
            // 
            // ChCkTmp
            // 
            this.ChCkTmp.AutoSize = true;
            this.ChCkTmp.Location = new System.Drawing.Point(31, 69);
            this.ChCkTmp.Name = "ChCkTmp";
            this.ChCkTmp.Size = new System.Drawing.Size(102, 16);
            this.ChCkTmp.TabIndex = 1;
            this.ChCkTmp.Text = " 是否体检体温";
            this.ChCkTmp.UseVisualStyleBackColor = true;
            // 
            // BtnOrder
            // 
            this.BtnOrder.Location = new System.Drawing.Point(31, 153);
            this.BtnOrder.Name = "BtnOrder";
            this.BtnOrder.Size = new System.Drawing.Size(75, 23);
            this.BtnOrder.TabIndex = 2;
            this.BtnOrder.Text = "预约";
            this.BtnOrder.UseVisualStyleBackColor = true;
            this.BtnOrder.Click += new System.EventHandler(this.BtnOrder_Click);
            // 
            // ComBoxDr
            // 
            this.ComBoxDr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBoxDr.FormattingEnabled = true;
            this.ComBoxDr.Location = new System.Drawing.Point(100, 24);
            this.ComBoxDr.Name = "ComBoxDr";
            this.ComBoxDr.Size = new System.Drawing.Size(105, 20);
            this.ComBoxDr.TabIndex = 3;
            // 
            // LabSelectDr
            // 
            this.LabSelectDr.AutoSize = true;
            this.LabSelectDr.Location = new System.Drawing.Point(29, 27);
            this.LabSelectDr.Name = "LabSelectDr";
            this.LabSelectDr.Size = new System.Drawing.Size(65, 12);
            this.LabSelectDr.TabIndex = 4;
            this.LabSelectDr.Text = "选择医生：";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(130, 153);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // OrderFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 199);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LabSelectDr);
            this.Controls.Add(this.ComBoxDr);
            this.Controls.Add(this.BtnOrder);
            this.Controls.Add(this.ChCkTmp);
            this.Controls.Add(this.ChCkHtBt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预约 - 智能医疗平台";
            this.Load += new System.EventHandler(this.OrderFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ChCkHtBt;
        private System.Windows.Forms.CheckBox ChCkTmp;
        private System.Windows.Forms.Button BtnOrder;
        private System.Windows.Forms.ComboBox ComBoxDr;
        private System.Windows.Forms.Label LabSelectDr;
        private System.Windows.Forms.Button BtnCancel;
    }
}