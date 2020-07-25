namespace election_thesis
{
    partial class VotingConfig
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
            this.cmb_districts = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_precinct = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_saveConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_districts
            // 
            this.cmb_districts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_districts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_districts.FormattingEnabled = true;
            this.cmb_districts.Location = new System.Drawing.Point(95, 33);
            this.cmb_districts.Name = "cmb_districts";
            this.cmb_districts.Size = new System.Drawing.Size(253, 32);
            this.cmb_districts.TabIndex = 9;
            this.cmb_districts.SelectedIndexChanged += new System.EventHandler(this.cmb_districts_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "District:";
            // 
            // cmb_precinct
            // 
            this.cmb_precinct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_precinct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_precinct.Enabled = false;
            this.cmb_precinct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_precinct.FormattingEnabled = true;
            this.cmb_precinct.Location = new System.Drawing.Point(95, 103);
            this.cmb_precinct.Name = "cmb_precinct";
            this.cmb_precinct.Size = new System.Drawing.Size(253, 32);
            this.cmb_precinct.TabIndex = 11;
            this.cmb_precinct.SelectedIndexChanged += new System.EventHandler(this.cmb_precinct_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Precinct:";
            // 
            // btn_saveConfig
            // 
            this.btn_saveConfig.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_saveConfig.Enabled = false;
            this.btn_saveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveConfig.ForeColor = System.Drawing.Color.White;
            this.btn_saveConfig.Location = new System.Drawing.Point(127, 193);
            this.btn_saveConfig.Name = "btn_saveConfig";
            this.btn_saveConfig.Size = new System.Drawing.Size(148, 44);
            this.btn_saveConfig.TabIndex = 12;
            this.btn_saveConfig.Text = "Save";
            this.btn_saveConfig.UseVisualStyleBackColor = false;
            this.btn_saveConfig.Click += new System.EventHandler(this.btn_saveConfig_Click);
            // 
            // VotingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 289);
            this.Controls.Add(this.btn_saveConfig);
            this.Controls.Add(this.cmb_precinct);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_districts);
            this.Controls.Add(this.label5);
            this.Name = "VotingConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "votingConfig";
            this.Load += new System.EventHandler(this.votingConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_districts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_precinct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_saveConfig;
    }
}