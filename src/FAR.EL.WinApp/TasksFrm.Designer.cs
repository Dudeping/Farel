namespace FAR.EL.WinApp
{
    partial class TasksFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksFrm));
            this.DataTasks = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCheckTmp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsCheckHtBt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsFinish = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTasks
            // 
            this.DataTasks.AllowUserToAddRows = false;
            this.DataTasks.AllowUserToDeleteRows = false;
            this.DataTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.UName,
            this.IsCheckTmp,
            this.IsCheckHtBt,
            this.IsFinish});
            this.DataTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTasks.Location = new System.Drawing.Point(0, 0);
            this.DataTasks.Name = "DataTasks";
            this.DataTasks.ReadOnly = true;
            this.DataTasks.RowTemplate.Height = 23;
            this.DataTasks.Size = new System.Drawing.Size(494, 317);
            this.DataTasks.TabIndex = 1;
            this.DataTasks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataTasks_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "#";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // UName
            // 
            this.UName.HeaderText = "用户姓名";
            this.UName.Name = "UName";
            this.UName.ReadOnly = true;
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
            // IsFinish
            // 
            this.IsFinish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IsFinish.HeaderText = "是否完成";
            this.IsFinish.Name = "IsFinish";
            this.IsFinish.ReadOnly = true;
            this.IsFinish.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsFinish.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TasksFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 317);
            this.Controls.Add(this.DataTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TasksFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体检任务 - 智能医疗平台";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TasksFrm_FormClosed);
            this.Load += new System.EventHandler(this.TasksFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCheckTmp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCheckHtBt;
        private System.Windows.Forms.DataGridViewButtonColumn IsFinish;
    }
}