namespace FAR.EL.WinApp
{
    partial class PetFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PetFrm));
            this.PetList = new System.Windows.Forms.DataGridView();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Des = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnPet = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PetList)).BeginInit();
            this.SuspendLayout();
            // 
            // PetList
            // 
            this.PetList.AllowUserToAddRows = false;
            this.PetList.AllowUserToDeleteRows = false;
            this.PetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PetList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PName,
            this.Des});
            this.PetList.Location = new System.Drawing.Point(0, 0);
            this.PetList.Name = "PetList";
            this.PetList.ReadOnly = true;
            this.PetList.RowTemplate.Height = 23;
            this.PetList.Size = new System.Drawing.Size(243, 160);
            this.PetList.TabIndex = 0;
            // 
            // PName
            // 
            this.PName.HeaderText = "名称";
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            // 
            // Des
            // 
            this.Des.HeaderText = "描述";
            this.Des.Name = "Des";
            this.Des.ReadOnly = true;
            // 
            // BtnPet
            // 
            this.BtnPet.Location = new System.Drawing.Point(12, 173);
            this.BtnPet.Name = "BtnPet";
            this.BtnPet.Size = new System.Drawing.Size(61, 23);
            this.BtnPet.TabIndex = 1;
            this.BtnPet.Text = "体检";
            this.BtnPet.UseVisualStyleBackColor = true;
            this.BtnPet.Click += new System.EventHandler(this.BtnPet_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(97, 173);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(65, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "返回";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // PetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 209);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnPet);
            this.Controls.Add(this.PetList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PetFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "体检 - 智能医疗平台";
            this.Load += new System.EventHandler(this.PetFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PetList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PetList;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Des;
        private System.Windows.Forms.Button BtnPet;
        private System.Windows.Forms.Button BtnCancel;
    }
}