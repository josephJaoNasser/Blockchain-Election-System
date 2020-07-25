namespace election_thesis
{
    partial class VoterLogin
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
            this.txt_loginCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_district = new System.Windows.Forms.Label();
            this.lbl_precinct = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_loginCode
            // 
            this.txt_loginCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_loginCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_loginCode.Location = new System.Drawing.Point(116, 164);
            this.txt_loginCode.Name = "txt_loginCode";
            this.txt_loginCode.Size = new System.Drawing.Size(586, 80);
            this.txt_loginCode.TabIndex = 0;
            this.txt_loginCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_loginCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_loginCode_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(325, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login code:";
            // 
            // btn_start
            // 
            this.btn_start.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_start.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(307, 499);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(207, 83);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lbl_district
            // 
            this.lbl_district.AutoSize = true;
            this.lbl_district.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_district.Location = new System.Drawing.Point(12, 9);
            this.lbl_district.Name = "lbl_district";
            this.lbl_district.Size = new System.Drawing.Size(51, 20);
            this.lbl_district.TabIndex = 3;
            this.lbl_district.Text = "label2";
            // 
            // lbl_precinct
            // 
            this.lbl_precinct.AutoSize = true;
            this.lbl_precinct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_precinct.Location = new System.Drawing.Point(12, 42);
            this.lbl_precinct.Name = "lbl_precinct";
            this.lbl_precinct.Size = new System.Drawing.Size(51, 20);
            this.lbl_precinct.TabIndex = 4;
            this.lbl_precinct.Text = "label3";
            // 
            // txt_password
            // 
            this.txt_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(116, 348);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(586, 80);
            this.txt_password.TabIndex = 5;
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(301, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Login Password:";
            // 
            // VoterLogin
            // 
            this.AcceptButton = this.btn_start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 635);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.lbl_precinct);
            this.Controls.Add(this.lbl_district);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_loginCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VoterLogin";
            this.Text = "VoterLogin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VoterLogin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VoterLogin_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_loginCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lbl_district;
        private System.Windows.Forms.Label lbl_precinct;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label2;
    }
}