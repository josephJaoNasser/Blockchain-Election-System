namespace election_thesis
{
    partial class VotingForm
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
            this.cmb_president = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_vicePresident = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_undoAll = new System.Windows.Forms.Button();
            this.btn_undoLast = new System.Windows.Forms.Button();
            this.dt_senators = new System.Windows.Forms.DataGridView();
            this.btn_next = new System.Windows.Forms.Button();
            this.lbl_voterName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_senators)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_president
            // 
            this.cmb_president.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_president.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_president.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_president.FormattingEnabled = true;
            this.cmb_president.Location = new System.Drawing.Point(152, 224);
            this.cmb_president.Name = "cmb_president";
            this.cmb_president.Size = new System.Drawing.Size(238, 41);
            this.cmb_president.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "President";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vice-President";
            // 
            // cmb_vicePresident
            // 
            this.cmb_vicePresident.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_vicePresident.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_vicePresident.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_vicePresident.FormattingEnabled = true;
            this.cmb_vicePresident.Location = new System.Drawing.Point(209, 334);
            this.cmb_vicePresident.Name = "cmb_vicePresident";
            this.cmb_vicePresident.Size = new System.Drawing.Size(181, 41);
            this.cmb_vicePresident.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_undoAll);
            this.groupBox1.Controls.Add(this.btn_undoLast);
            this.groupBox1.Controls.Add(this.dt_senators);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(411, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 495);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Senators";
            // 
            // btn_undoAll
            // 
            this.btn_undoAll.Location = new System.Drawing.Point(217, 56);
            this.btn_undoAll.Name = "btn_undoAll";
            this.btn_undoAll.Size = new System.Drawing.Size(168, 43);
            this.btn_undoAll.TabIndex = 13;
            this.btn_undoAll.Text = "Undo All";
            this.btn_undoAll.UseVisualStyleBackColor = true;
            this.btn_undoAll.Click += new System.EventHandler(this.btn_undoAll_Click);
            // 
            // btn_undoLast
            // 
            this.btn_undoLast.Location = new System.Drawing.Point(23, 56);
            this.btn_undoLast.Name = "btn_undoLast";
            this.btn_undoLast.Size = new System.Drawing.Size(168, 43);
            this.btn_undoLast.TabIndex = 12;
            this.btn_undoLast.Text = "Undo Last";
            this.btn_undoLast.UseVisualStyleBackColor = true;
            this.btn_undoLast.Click += new System.EventHandler(this.btn_undoLast_Click);
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
            this.dt_senators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_senators.DefaultCellStyle = dataGridViewCellStyle1;
            this.dt_senators.Location = new System.Drawing.Point(23, 117);
            this.dt_senators.MultiSelect = false;
            this.dt_senators.Name = "dt_senators";
            this.dt_senators.RowHeadersVisible = false;
            this.dt_senators.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dt_senators.Size = new System.Drawing.Size(747, 358);
            this.dt_senators.TabIndex = 11;
            this.dt_senators.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_senators_CellValueChanged);
            this.dt_senators.CurrentCellDirtyStateChanged += new System.EventHandler(this.dt_senators_CurrentCellDirtyStateChanged);
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_next.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.Color.White;
            this.btn_next.Location = new System.Drawing.Point(0, 529);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(1208, 149);
            this.btn_next.TabIndex = 5;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // lbl_voterName
            // 
            this.lbl_voterName.AutoSize = true;
            this.lbl_voterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_voterName.Location = new System.Drawing.Point(12, 16);
            this.lbl_voterName.Name = "lbl_voterName";
            this.lbl_voterName.Size = new System.Drawing.Size(92, 18);
            this.lbl_voterName.TabIndex = 7;
            this.lbl_voterName.Text = "(voter name)";
            // 
            // VotingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 678);
            this.Controls.Add(this.lbl_voterName);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmb_vicePresident);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_president);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VotingForm";
            this.Text = "VotingForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VotingForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_senators)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_president;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_vicePresident;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dt_senators;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_undoAll;
        private System.Windows.Forms.Button btn_undoLast;
        private System.Windows.Forms.Label lbl_voterName;
    }
}