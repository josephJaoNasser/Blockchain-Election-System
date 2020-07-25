namespace election_thesis
{
    partial class ResultsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dt_presidentCount = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dt_senatorsCount = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dt_vPresCount = new System.Windows.Forms.DataGridView();
            this.btn_syncAndCount = new System.Windows.Forms.Button();
            this.btn_quickCount = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.syncVotesWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dt_presidentCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_senatorsCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_vPresCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_presidentCount
            // 
            this.dt_presidentCount.AllowUserToAddRows = false;
            this.dt_presidentCount.AllowUserToDeleteRows = false;
            this.dt_presidentCount.AllowUserToResizeColumns = false;
            this.dt_presidentCount.AllowUserToResizeRows = false;
            this.dt_presidentCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_presidentCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_presidentCount.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_presidentCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_presidentCount.DefaultCellStyle = dataGridViewCellStyle7;
            this.dt_presidentCount.Location = new System.Drawing.Point(15, 28);
            this.dt_presidentCount.MultiSelect = false;
            this.dt_presidentCount.Name = "dt_presidentCount";
            this.dt_presidentCount.ReadOnly = true;
            this.dt_presidentCount.RowHeadersVisible = false;
            this.dt_presidentCount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_presidentCount.Size = new System.Drawing.Size(453, 275);
            this.dt_presidentCount.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dt_presidentCount);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 315);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "President";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dt_senatorsCount);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(504, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 449);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Senators";
            // 
            // dt_senatorsCount
            // 
            this.dt_senatorsCount.AllowUserToAddRows = false;
            this.dt_senatorsCount.AllowUserToDeleteRows = false;
            this.dt_senatorsCount.AllowUserToResizeColumns = false;
            this.dt_senatorsCount.AllowUserToResizeRows = false;
            this.dt_senatorsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_senatorsCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_senatorsCount.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_senatorsCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_senatorsCount.DefaultCellStyle = dataGridViewCellStyle8;
            this.dt_senatorsCount.Location = new System.Drawing.Point(15, 28);
            this.dt_senatorsCount.MultiSelect = false;
            this.dt_senatorsCount.Name = "dt_senatorsCount";
            this.dt_senatorsCount.ReadOnly = true;
            this.dt_senatorsCount.RowHeadersVisible = false;
            this.dt_senatorsCount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_senatorsCount.Size = new System.Drawing.Size(513, 409);
            this.dt_senatorsCount.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dt_vPresCount);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 337);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vice President";
            // 
            // dt_vPresCount
            // 
            this.dt_vPresCount.AllowUserToAddRows = false;
            this.dt_vPresCount.AllowUserToDeleteRows = false;
            this.dt_vPresCount.AllowUserToResizeColumns = false;
            this.dt_vPresCount.AllowUserToResizeRows = false;
            this.dt_vPresCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_vPresCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_vPresCount.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_vPresCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_vPresCount.DefaultCellStyle = dataGridViewCellStyle9;
            this.dt_vPresCount.Location = new System.Drawing.Point(15, 28);
            this.dt_vPresCount.MultiSelect = false;
            this.dt_vPresCount.Name = "dt_vPresCount";
            this.dt_vPresCount.ReadOnly = true;
            this.dt_vPresCount.RowHeadersVisible = false;
            this.dt_vPresCount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_vPresCount.Size = new System.Drawing.Size(453, 297);
            this.dt_vPresCount.TabIndex = 11;
            // 
            // btn_syncAndCount
            // 
            this.btn_syncAndCount.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_syncAndCount.FlatAppearance.BorderSize = 0;
            this.btn_syncAndCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_syncAndCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_syncAndCount.ForeColor = System.Drawing.Color.White;
            this.btn_syncAndCount.Location = new System.Drawing.Point(3, 71);
            this.btn_syncAndCount.Name = "btn_syncAndCount";
            this.btn_syncAndCount.Size = new System.Drawing.Size(546, 88);
            this.btn_syncAndCount.TabIndex = 17;
            this.btn_syncAndCount.Text = "Sync and Count";
            this.btn_syncAndCount.UseVisualStyleBackColor = false;
            this.btn_syncAndCount.Click += new System.EventHandler(this.btn_syncAndCount_Click);
            // 
            // btn_quickCount
            // 
            this.btn_quickCount.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_quickCount.FlatAppearance.BorderSize = 0;
            this.btn_quickCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quickCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quickCount.ForeColor = System.Drawing.Color.White;
            this.btn_quickCount.Location = new System.Drawing.Point(3, 3);
            this.btn_quickCount.Name = "btn_quickCount";
            this.btn_quickCount.Size = new System.Drawing.Size(546, 62);
            this.btn_quickCount.TabIndex = 18;
            this.btn_quickCount.Text = "Quick Count";
            this.btn_quickCount.UseVisualStyleBackColor = false;
            this.btn_quickCount.Click += new System.EventHandler(this.btn_quickCount_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.Black;
            this.btn_back.Location = new System.Drawing.Point(3, 165);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(546, 41);
            this.btn_back.TabIndex = 19;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Controls.Add(this.btn_quickCount);
            this.panel1.Controls.Add(this.btn_syncAndCount);
            this.panel1.Location = new System.Drawing.Point(504, 467);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 212);
            this.panel1.TabIndex = 20;
            // 
            // syncVotesWorker
            // 
            this.syncVotesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.syncVotesWorker_DoWork);
            this.syncVotesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.syncVotesWorker_RunWorkerCompleted);
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResultsForm";
            this.Text = "CountingForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CountingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_presidentCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_senatorsCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_vPresCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_presidentCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dt_senatorsCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dt_vPresCount;
        public System.Windows.Forms.Button btn_syncAndCount;
        public System.Windows.Forms.Button btn_quickCount;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker syncVotesWorker;
    }
}