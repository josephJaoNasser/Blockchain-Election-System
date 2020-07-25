namespace election_thesis
{
    partial class VoteConfirm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_pres = new System.Windows.Forms.Label();
            this.lbl_vPres = new System.Windows.Forms.Label();
            this.dt_senators = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sendVotesWorker = new System.ComponentModel.BackgroundWorker();
            this.panel_processing = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dt_senators)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_submit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location = new System.Drawing.Point(0, 504);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(1071, 129);
            this.btn_submit.TabIndex = 6;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_back
            // 
            this.btn_back.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(0, 460);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(1071, 44);
            this.btn_back.TabIndex = 7;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Review of selected candidates";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(18, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 33);
            this.label2.TabIndex = 9;
            this.label2.Text = "President:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(18, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 33);
            this.label3.TabIndex = 10;
            this.label3.Text = "Vice President:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(599, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 33);
            this.label4.TabIndex = 11;
            this.label4.Text = "Senators:";
            // 
            // lbl_pres
            // 
            this.lbl_pres.AutoSize = true;
            this.lbl_pres.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pres.Location = new System.Drawing.Point(18, 141);
            this.lbl_pres.Name = "lbl_pres";
            this.lbl_pres.Size = new System.Drawing.Size(299, 42);
            this.lbl_pres.TabIndex = 12;
            this.lbl_pres.Text = "(president name)";
            // 
            // lbl_vPres
            // 
            this.lbl_vPres.AutoSize = true;
            this.lbl_vPres.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_vPres.Location = new System.Drawing.Point(18, 310);
            this.lbl_vPres.Name = "lbl_vPres";
            this.lbl_vPres.Size = new System.Drawing.Size(361, 39);
            this.lbl_vPres.TabIndex = 13;
            this.lbl_vPres.Text = "(Vice President name)";
            // 
            // dt_senators
            // 
            this.dt_senators.AllowUserToAddRows = false;
            this.dt_senators.AllowUserToDeleteRows = false;
            this.dt_senators.AllowUserToResizeColumns = false;
            this.dt_senators.AllowUserToResizeRows = false;
            this.dt_senators.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_senators.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_senators.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dt_senators.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dt_senators.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dt_senators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_senators.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_senators.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_senators.Location = new System.Drawing.Point(605, 141);
            this.dt_senators.MultiSelect = false;
            this.dt_senators.Name = "dt_senators";
            this.dt_senators.ReadOnly = true;
            this.dt_senators.RowHeadersVisible = false;
            this.dt_senators.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_senators.Size = new System.Drawing.Size(454, 313);
            this.dt_senators.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel_processing);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 66);
            this.panel1.TabIndex = 15;
            // 
            // sendVotesWorker
            // 
            this.sendVotesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendVotesWorker_DoWork);
            this.sendVotesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.sendVotesWorker_RunWorkerCompleted);
            // 
            // panel_processing
            // 
            this.panel_processing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_processing.Location = new System.Drawing.Point(0, 0);
            this.panel_processing.Name = "panel_processing";
            this.panel_processing.Size = new System.Drawing.Size(1071, 66);
            this.panel_processing.TabIndex = 16;
            // 
            // VoteConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 633);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dt_senators);
            this.Controls.Add(this.lbl_vPres);
            this.Controls.Add(this.lbl_pres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VoteConfirm";
            this.Text = "VoteConfirm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VoteConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_senators)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_pres;
        private System.Windows.Forms.Label lbl_vPres;
        private System.Windows.Forms.DataGridView dt_senators;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker sendVotesWorker;
        private System.Windows.Forms.Panel panel_processing;
    }
}