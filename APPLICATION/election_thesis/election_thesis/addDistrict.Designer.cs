namespace election_thesis
{
    partial class addDistrict
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dt_notNullDistrict = new System.Windows.Forms.DataGridView();
            this.btn_deployDistrict = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dt_nullDistrict = new System.Windows.Forms.DataGridView();
            this.deployDistrict = new System.ComponentModel.BackgroundWorker();
            this.txt_districtKey = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt_notNullDistrict)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_nullDistrict)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_notNullDistrict
            // 
            this.dt_notNullDistrict.AllowUserToAddRows = false;
            this.dt_notNullDistrict.AllowUserToDeleteRows = false;
            this.dt_notNullDistrict.AllowUserToResizeColumns = false;
            this.dt_notNullDistrict.AllowUserToResizeRows = false;
            this.dt_notNullDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_notNullDistrict.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_notNullDistrict.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_notNullDistrict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_notNullDistrict.DefaultCellStyle = dataGridViewCellStyle1;
            this.dt_notNullDistrict.Location = new System.Drawing.Point(6, 28);
            this.dt_notNullDistrict.MultiSelect = false;
            this.dt_notNullDistrict.Name = "dt_notNullDistrict";
            this.dt_notNullDistrict.ReadOnly = true;
            this.dt_notNullDistrict.RowHeadersVisible = false;
            this.dt_notNullDistrict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_notNullDistrict.Size = new System.Drawing.Size(276, 227);
            this.dt_notNullDistrict.TabIndex = 1;
            // 
            // btn_deployDistrict
            // 
            this.btn_deployDistrict.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_deployDistrict.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_deployDistrict.Enabled = false;
            this.btn_deployDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deployDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deployDistrict.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_deployDistrict.Location = new System.Drawing.Point(0, 353);
            this.btn_deployDistrict.Name = "btn_deployDistrict";
            this.btn_deployDistrict.Size = new System.Drawing.Size(683, 69);
            this.btn_deployDistrict.TabIndex = 6;
            this.btn_deployDistrict.Text = "Deploy ballot contract for";
            this.btn_deployDistrict.UseVisualStyleBackColor = false;
            this.btn_deployDistrict.Click += new System.EventHandler(this.btn_setAddress_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.Black;
            this.btn_cancel.Location = new System.Drawing.Point(0, 422);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(683, 44);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "Back";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.PowderBlue;
            this.groupBox1.Controls.Add(this.dt_notNullDistrict);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(376, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 273);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Districts With Contracts";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.groupBox2.Controls.Add(this.dt_nullDistrict);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 343);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Districts Without Contracts";
            // 
            // dt_nullDistrict
            // 
            this.dt_nullDistrict.AllowUserToAddRows = false;
            this.dt_nullDistrict.AllowUserToDeleteRows = false;
            this.dt_nullDistrict.AllowUserToResizeColumns = false;
            this.dt_nullDistrict.AllowUserToResizeRows = false;
            this.dt_nullDistrict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_nullDistrict.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_nullDistrict.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_nullDistrict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_nullDistrict.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_nullDistrict.Location = new System.Drawing.Point(17, 30);
            this.dt_nullDistrict.MultiSelect = false;
            this.dt_nullDistrict.Name = "dt_nullDistrict";
            this.dt_nullDistrict.ReadOnly = true;
            this.dt_nullDistrict.RowHeadersVisible = false;
            this.dt_nullDistrict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_nullDistrict.Size = new System.Drawing.Size(331, 297);
            this.dt_nullDistrict.TabIndex = 1;
            this.dt_nullDistrict.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_nullDistrict_CellContentClick);
            // 
            // deployDistrict
            // 
            this.deployDistrict.DoWork += new System.ComponentModel.DoWorkEventHandler(this.deployDistrict_DoWork);
            this.deployDistrict.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.deployDistrict_RunWorkerCompleted);
            // 
            // txt_districtKey
            // 
            this.txt_districtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_districtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_districtKey.Location = new System.Drawing.Point(6, 25);
            this.txt_districtKey.Name = "txt_districtKey";
            this.txt_districtKey.PasswordChar = '*';
            this.txt_districtKey.Size = new System.Drawing.Size(281, 29);
            this.txt_districtKey.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txt_districtKey);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(376, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(293, 64);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "District Private Key";
            // 
            // addDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 466);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_deployDistrict);
            this.Controls.Add(this.btn_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addDistrict";
            this.Text = "addDistrict";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.addDistrict_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_notNullDistrict)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_nullDistrict)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_notNullDistrict;
        private System.Windows.Forms.Button btn_deployDistrict;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dt_nullDistrict;
        private System.ComponentModel.BackgroundWorker deployDistrict;
        private System.Windows.Forms.TextBox txt_districtKey;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}