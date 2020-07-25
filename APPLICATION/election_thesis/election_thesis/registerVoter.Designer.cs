namespace election_thesis
{
    partial class registerVoter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_voterPassword = new System.Windows.Forms.TextBox();
            this.cmb_precinct = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_districts = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_lastname = new System.Windows.Forms.TextBox();
            this.txt_firstname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_middlename = new System.Windows.Forms.TextBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_registerVoter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.btn_clearAll = new System.Windows.Forms.Button();
            this.registerVoterWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_voterPassword);
            this.groupBox1.Controls.Add(this.cmb_precinct);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmb_districts);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_lastname);
            this.groupBox1.Controls.Add(this.txt_firstname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_middlename);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(994, 257);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Voter Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Password:";
            // 
            // txt_voterPassword
            // 
            this.txt_voterPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_voterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_voterPassword.Location = new System.Drawing.Point(143, 157);
            this.txt_voterPassword.Name = "txt_voterPassword";
            this.txt_voterPassword.PasswordChar = '*';
            this.txt_voterPassword.Size = new System.Drawing.Size(840, 29);
            this.txt_voterPassword.TabIndex = 10;
            this.txt_voterPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_voterPassword_KeyPress);
            // 
            // cmb_precinct
            // 
            this.cmb_precinct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_precinct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_precinct.Enabled = false;
            this.cmb_precinct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_precinct.FormattingEnabled = true;
            this.cmb_precinct.Location = new System.Drawing.Point(521, 205);
            this.cmb_precinct.Name = "cmb_precinct";
            this.cmb_precinct.Size = new System.Drawing.Size(462, 32);
            this.cmb_precinct.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(432, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Precinct:";
            // 
            // cmb_districts
            // 
            this.cmb_districts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_districts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_districts.FormattingEnabled = true;
            this.cmb_districts.Location = new System.Drawing.Point(88, 205);
            this.cmb_districts.Name = "cmb_districts";
            this.cmb_districts.Size = new System.Drawing.Size(320, 32);
            this.cmb_districts.TabIndex = 7;
            this.cmb_districts.SelectedIndexChanged += new System.EventHandler(this.cmb_districts_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "District:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // txt_lastname
            // 
            this.txt_lastname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_lastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lastname.Location = new System.Drawing.Point(143, 113);
            this.txt_lastname.Name = "txt_lastname";
            this.txt_lastname.Size = new System.Drawing.Size(840, 29);
            this.txt_lastname.TabIndex = 5;
            this.txt_lastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_lastname_KeyPress);
            // 
            // txt_firstname
            // 
            this.txt_firstname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_firstname.Location = new System.Drawing.Point(143, 26);
            this.txt_firstname.Name = "txt_firstname";
            this.txt_firstname.Size = new System.Drawing.Size(841, 29);
            this.txt_firstname.TabIndex = 0;
            this.txt_firstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_firstname_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Middle Name:";
            // 
            // txt_middlename
            // 
            this.txt_middlename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_middlename.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_middlename.Location = new System.Drawing.Point(143, 70);
            this.txt_middlename.Name = "txt_middlename";
            this.txt_middlename.Size = new System.Drawing.Size(840, 29);
            this.txt_middlename.TabIndex = 3;
            this.txt_middlename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_middlename_KeyPress);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.Black;
            this.btn_back.Location = new System.Drawing.Point(12, 275);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(148, 44);
            this.btn_back.TabIndex = 11;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_registerVoter
            // 
            this.btn_registerVoter.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_registerVoter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_registerVoter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_registerVoter.ForeColor = System.Drawing.Color.White;
            this.btn_registerVoter.Location = new System.Drawing.Point(166, 275);
            this.btn_registerVoter.Name = "btn_registerVoter";
            this.btn_registerVoter.Size = new System.Drawing.Size(148, 44);
            this.btn_registerVoter.TabIndex = 10;
            this.btn_registerVoter.Text = "Register Voter";
            this.btn_registerVoter.UseVisualStyleBackColor = false;
            this.btn_registerVoter.Click += new System.EventHandler(this.btn_registerVoter_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(445, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 33);
            this.label4.TabIndex = 12;
            this.label4.Text = "Login Code";
            // 
            // txt_code
            // 
            this.txt_code.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_code.Enabled = false;
            this.txt_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code.Location = new System.Drawing.Point(200, 379);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(612, 116);
            this.txt_code.TabIndex = 13;
            this.txt_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_clearAll
            // 
            this.btn_clearAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_clearAll.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_clearAll.FlatAppearance.BorderSize = 0;
            this.btn_clearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearAll.ForeColor = System.Drawing.Color.Black;
            this.btn_clearAll.Location = new System.Drawing.Point(451, 501);
            this.btn_clearAll.Name = "btn_clearAll";
            this.btn_clearAll.Size = new System.Drawing.Size(157, 44);
            this.btn_clearAll.TabIndex = 14;
            this.btn_clearAll.Text = "Clear All";
            this.btn_clearAll.UseVisualStyleBackColor = false;
            this.btn_clearAll.Click += new System.EventHandler(this.btn_clearAll_Click);
            // 
            // registerVoterWorker
            // 
            this.registerVoterWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.registerVoterWorker_DoWork);
            this.registerVoterWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.registerVoterWorker_RunWorkerCompleted);
            // 
            // registerVoter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 608);
            this.Controls.Add(this.btn_clearAll);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_registerVoter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "registerVoter";
            this.Text = "registerVoter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.registerVoter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_lastname;
        private System.Windows.Forms.TextBox txt_firstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_middlename;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_registerVoter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Button btn_clearAll;
        private System.Windows.Forms.ComboBox cmb_districts;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker registerVoterWorker;
        private System.Windows.Forms.ComboBox cmb_precinct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_voterPassword;
    }
}