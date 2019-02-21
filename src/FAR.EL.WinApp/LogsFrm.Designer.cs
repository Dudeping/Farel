namespace FAR.EL.WinApp
{
    partial class LogsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogsFrm));
            this.DataLogs = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCheckTmp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsCheckHtBt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFilish = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // DataLogs
            // 
            this.DataLogs.AllowUserToAddRows = false;
            this.DataLogs.AllowUserToDeleteRows = false;
            this.DataLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IsCheckTmp,
            this.IsCheckHtBt,
            this.DName,
            this.IsFilish});
            this.DataLogs.Location = new System.Drawing.Point(0, 0);
            this.DataLogs.Name = "DataLogs";
            this.DataLogs.ReadOnly = true;
            this.DataLogs.RowTemplate.Height = 23;
            this.DataLogs.Size = new System.Drawing.Size(493, 328);
            this.DataLogs.TabIndex = 1;
            this.DataLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataLogs_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "#";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // IsCheckTmp
            // 
            this.IsCheckTmp.HeaderText = "体检体温";
            this.IsCheckTmp.Name = "IsCheckTmp";
            this.IsCheckTmp.ReadOnly = true;
            this.IsCheckTmp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCheckTmp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsCheckHtBt
            // 
            this.IsCheckHtBt.HeaderText = "体检心率";
            this.IsCheckHtBt.Name = "IsCheckHtBt";
            this.IsCheckHtBt.ReadOnly = true;
            this.IsCheckHtBt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCheckHtBt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DName
            // 
            this.DName.HeaderText = "医生姓名";
            this.DName.Name = "DName";
            this.DName.ReadOnly = true;
            // 
            // IsFilish
            // 
            this.IsFilish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IsFilish.HeaderText = "是否完成";
            this.IsFilish.Name = "IsFilish";
            this.IsFilish.ReadOnly = true;
            this.IsFilish.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsFilish.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BtnOrder
            // 
            this.BtnOrder.Location = new System.Drawing.Point(13, 334);
            this.BtnOrder.Name = "BtnOrder";
            this.BtnOrder.Size = new System.Drawing.Size(75, 23);
            this.BtnOrder.TabIndex = 2;
            this.BtnOrder.Text = "预约";
            this.BtnOrder.UseVisualStyleBackColor = true;
            this.BtnOrder.Click += new System.EventHandler(this.BtnOrder_Click);
            // 
            // LogsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 369);
            this.Controls.Add(this.BtnOrder);
            this.Controls.Add(this.DataLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预约记录 - 智能医疗平台";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogsFrm_FormClosed);
            this.Load += new System.EventHandler(this.LogsFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCheckTmp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCheckHtBt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DName;
        private System.Windows.Forms.DataGridViewButtonColumn IsFilish;
        private System.Windows.Forms.Button BtnOrder;
    }
}