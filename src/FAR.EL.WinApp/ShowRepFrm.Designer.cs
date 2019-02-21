namespace FAR.EL.WinApp
{
    partial class ShowRepFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowRepFrm));
            this.RepList = new System.Windows.Forms.DataGridView();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Des = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RepList)).BeginInit();
            this.SuspendLayout();
            // 
            // RepList
            // 
            this.RepList.AllowUserToAddRows = false;
            this.RepList.AllowUserToDeleteRows = false;
            this.RepList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RepList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PName,
            this.Des});
            this.RepList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RepList.Location = new System.Drawing.Point(0, 0);
            this.RepList.Name = "RepList";
            this.RepList.ReadOnly = true;
            this.RepList.RowTemplate.Height = 23;
            this.RepList.Size = new System.Drawing.Size(243, 160);
            this.RepList.TabIndex = 1;
            // 
            // PName
            // 
            this.PName.HeaderText = "名称";
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            this.PName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Des
            // 
            this.Des.HeaderText = "描述";
            this.Des.Name = "Des";
            this.Des.ReadOnly = true;
            // 
            // ShowRepFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 160);
            this.Controls.Add(this.RepList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowRepFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体检报告 - 智能医疗平台";
            this.Load += new System.EventHandler(this.ShowRepFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RepList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RepList;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Des;
    }
}