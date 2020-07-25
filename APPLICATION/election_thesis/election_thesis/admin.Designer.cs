namespace election_thesis
{
    partial class admin
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
            this.components = new System.ComponentModel.Container();
            this.btn_addCandidate = new System.Windows.Forms.Button();
            this.btn_registerVoter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_page = new System.Windows.Forms.Label();
            this.panel_side = new System.Windows.Forms.Panel();
            this.btn_results = new System.Windows.Forms.Button();
            this.btn_createDistrict = new System.Windows.Forms.Button();
            this.btn_selectContract = new System.Windows.Forms.Button();
            this.btn_contract = new System.Windows.Forms.Button();
            this.btn_syncVoters = new System.Windows.Forms.Button();
            this.btn_syncVotes = new System.Windows.Forms.Button();
            this.panel_main = new System.Windows.Forms.Panel();
            this.btn_getPrices = new System.Windows.Forms.Button();
            this.browser_gasStation = new System.Windows.Forms.WebBrowser();
            this.lbl_gasStation = new System.Windows.Forms.Label();
            this.refresh_timer = new System.Windows.Forms.Timer(this.components);
            this.lbl_timer = new System.Windows.Forms.Label();
            this.panel_gasStation = new System.Windows.Forms.Panel();
            this.syncVotersWorker = new System.ComponentModel.BackgroundWorker();
            this.syncVotesWorker = new System.ComponentModel.BackgroundWorker();
            this.btn_testSpeed = new System.Windows.Forms.Button();
            this.testReadSpeedWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel_side.SuspendLayout();
            this.panel_gasStation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addCandidate
            // 
            this.btn_addCandidate.FlatAppearance.BorderSize = 0;
            this.btn_addCandidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_addCandidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addCandidate.ForeColor = System.Drawing.Color.White;
            this.btn_addCandidate.Location = new System.Drawing.Point(3, -2);
            this.btn_addCandidate.Name = "btn_addCandidate";
            this.btn_addCandidate.Size = new System.Drawing.Size(273, 97);
            this.btn_addCandidate.TabIndex = 0;
            this.btn_addCandidate.Text = "Add Candidate";
            this.btn_addCandidate.UseVisualStyleBackColor = true;
            this.btn_addCandidate.Click += new System.EventHandler(this.btn_addCandidate_Click);
            // 
            // btn_registerVoter
            // 
            this.btn_registerVoter.FlatAppearance.BorderSize = 0;
            this.btn_registerVoter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_registerVoter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_registerVoter.ForeColor = System.Drawing.Color.White;
            this.btn_registerVoter.Location = new System.Drawing.Point(3, 103);
            this.btn_registerVoter.Name = "btn_registerVoter";
            this.btn_registerVoter.Size = new System.Drawing.Size(273, 97);
            this.btn_registerVoter.TabIndex = 1;
            this.btn_registerVoter.Text = "Register Voter";
            this.btn_registerVoter.UseVisualStyleBackColor = true;
            this.btn_registerVoter.Click += new System.EventHandler(this.btn_registerVoter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Administrator   |";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.lbl_page);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 72);
            this.panel1.TabIndex = 3;
            // 
            // lbl_page
            // 
            this.lbl_page.AutoSize = true;
            this.lbl_page.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_page.ForeColor = System.Drawing.Color.White;
            this.lbl_page.Location = new System.Drawing.Point(241, 24);
            this.lbl_page.Name = "lbl_page";
            this.lbl_page.Size = new System.Drawing.Size(68, 25);
            this.lbl_page.TabIndex = 3;
            this.lbl_page.Text = "Home";
            // 
            // panel_side
            // 
            this.panel_side.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_side.BackColor = System.Drawing.Color.SteelBlue;
            this.panel_side.Controls.Add(this.btn_results);
            this.panel_side.Controls.Add(this.btn_createDistrict);
            this.panel_side.Controls.Add(this.btn_selectContract);
            this.panel_side.Controls.Add(this.btn_contract);
            this.panel_side.Controls.Add(this.btn_registerVoter);
            this.panel_side.Controls.Add(this.btn_addCandidate);
            this.panel_side.Controls.Add(this.btn_syncVoters);
            this.panel_side.Controls.Add(this.btn_syncVotes);
            this.panel_side.Location = new System.Drawing.Point(0, 70);
            this.panel_side.Name = "panel_side";
            this.panel_side.Size = new System.Drawing.Size(276, 675);
            this.panel_side.TabIndex = 4;
            // 
            // btn_results
            // 
            this.btn_results.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_results.FlatAppearance.BorderSize = 0;
            this.btn_results.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_results.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_results.ForeColor = System.Drawing.Color.White;
            this.btn_results.Location = new System.Drawing.Point(-1, 513);
            this.btn_results.Name = "btn_results";
            this.btn_results.Size = new System.Drawing.Size(278, 97);
            this.btn_results.TabIndex = 10;
            this.btn_results.Text = "View Election Results";
            this.btn_results.UseVisualStyleBackColor = false;
            this.btn_results.Click += new System.EventHandler(this.btn_results_Click);
            // 
            // btn_createDistrict
            // 
            this.btn_createDistrict.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_createDistrict.FlatAppearance.BorderSize = 0;
            this.btn_createDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_createDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_createDistrict.ForeColor = System.Drawing.Color.White;
            this.btn_createDistrict.Location = new System.Drawing.Point(-1, 410);
            this.btn_createDistrict.Name = "btn_createDistrict";
            this.btn_createDistrict.Size = new System.Drawing.Size(278, 97);
            this.btn_createDistrict.TabIndex = 7;
            this.btn_createDistrict.Text = "Deploy District Contracts";
            this.btn_createDistrict.UseVisualStyleBackColor = false;
            this.btn_createDistrict.Click += new System.EventHandler(this.btn_createDistrict_Click);
            // 
            // btn_selectContract
            // 
            this.btn_selectContract.FlatAppearance.BorderSize = 0;
            this.btn_selectContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_selectContract.ForeColor = System.Drawing.Color.White;
            this.btn_selectContract.Location = new System.Drawing.Point(3, 309);
            this.btn_selectContract.Name = "btn_selectContract";
            this.btn_selectContract.Size = new System.Drawing.Size(273, 97);
            this.btn_selectContract.TabIndex = 6;
            this.btn_selectContract.Text = "Select Active Smart Contract";
            this.btn_selectContract.UseVisualStyleBackColor = true;
            this.btn_selectContract.Click += new System.EventHandler(this.btn_selectContract_Click);
            // 
            // btn_contract
            // 
            this.btn_contract.FlatAppearance.BorderSize = 0;
            this.btn_contract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_contract.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_contract.ForeColor = System.Drawing.Color.White;
            this.btn_contract.Location = new System.Drawing.Point(3, 210);
            this.btn_contract.Name = "btn_contract";
            this.btn_contract.Size = new System.Drawing.Size(273, 97);
            this.btn_contract.TabIndex = 2;
            this.btn_contract.Text = "Deploy Smart Contracts";
            this.btn_contract.UseVisualStyleBackColor = true;
            this.btn_contract.Click += new System.EventHandler(this.btn_contract_Click);
            // 
            // btn_syncVoters
            // 
            this.btn_syncVoters.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_syncVoters.FlatAppearance.BorderSize = 0;
            this.btn_syncVoters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_syncVoters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_syncVoters.ForeColor = System.Drawing.Color.White;
            this.btn_syncVoters.Location = new System.Drawing.Point(8, 606);
            this.btn_syncVoters.Name = "btn_syncVoters";
            this.btn_syncVoters.Size = new System.Drawing.Size(131, 50);
            this.btn_syncVoters.TabIndex = 8;
            this.btn_syncVoters.Text = "Sync Voters";
            this.btn_syncVoters.UseVisualStyleBackColor = false;
            this.btn_syncVoters.Click += new System.EventHandler(this.btn_syncVoters_Click);
            // 
            // btn_syncVotes
            // 
            this.btn_syncVotes.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_syncVotes.FlatAppearance.BorderSize = 0;
            this.btn_syncVotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_syncVotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_syncVotes.ForeColor = System.Drawing.Color.White;
            this.btn_syncVotes.Location = new System.Drawing.Point(145, 606);
            this.btn_syncVotes.Name = "btn_syncVotes";
            this.btn_syncVotes.Size = new System.Drawing.Size(120, 50);
            this.btn_syncVotes.TabIndex = 9;
            this.btn_syncVotes.Text = "Sync Votes";
            this.btn_syncVotes.UseVisualStyleBackColor = false;
            this.btn_syncVotes.Click += new System.EventHandler(this.btn_syncVotes_Click);
            // 
            // panel_main
            // 
            this.panel_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_main.Location = new System.Drawing.Point(8, 77);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(970, 654);
            this.panel_main.TabIndex = 11;
            // 
            // btn_getPrices
            // 
            this.btn_getPrices.Location = new System.Drawing.Point(14, 32);
            this.btn_getPrices.Name = "btn_getPrices";
            this.btn_getPrices.Size = new System.Drawing.Size(171, 23);
            this.btn_getPrices.TabIndex = 6;
            this.btn_getPrices.Text = "Refresh Gas Station";
            this.btn_getPrices.UseVisualStyleBackColor = true;
            this.btn_getPrices.Click += new System.EventHandler(this.btn_getPrices_Click);
            // 
            // browser_gasStation
            // 
            this.browser_gasStation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browser_gasStation.Location = new System.Drawing.Point(14, 59);
            this.browser_gasStation.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser_gasStation.Name = "browser_gasStation";
            this.browser_gasStation.Size = new System.Drawing.Size(674, 584);
            this.browser_gasStation.TabIndex = 7;
            this.browser_gasStation.Url = new System.Uri("https://ethgasstation.info/calculatorTxV.php", System.UriKind.Absolute);
            this.browser_gasStation.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_gasStation_DocumentCompleted);
            // 
            // lbl_gasStation
            // 
            this.lbl_gasStation.AutoSize = true;
            this.lbl_gasStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_gasStation.Location = new System.Drawing.Point(9, 1);
            this.lbl_gasStation.Name = "lbl_gasStation";
            this.lbl_gasStation.Size = new System.Drawing.Size(357, 29);
            this.lbl_gasStation.TabIndex = 8;
            this.lbl_gasStation.Text = "Loading Ethereum Gas Station...";
            // 
            // refresh_timer
            // 
            this.refresh_timer.Interval = 1000;
            this.refresh_timer.Tick += new System.EventHandler(this.refresh_timer_Tick);
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Location = new System.Drawing.Point(191, 38);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(89, 13);
            this.lbl_timer.TabIndex = 9;
            this.lbl_timer.Text = "Refreshing in 60s";
            // 
            // panel_gasStation
            // 
            this.panel_gasStation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_gasStation.Controls.Add(this.btn_testSpeed);
            this.panel_gasStation.Controls.Add(this.browser_gasStation);
            this.panel_gasStation.Controls.Add(this.lbl_timer);
            this.panel_gasStation.Controls.Add(this.btn_getPrices);
            this.panel_gasStation.Controls.Add(this.lbl_gasStation);
            this.panel_gasStation.Location = new System.Drawing.Point(285, 74);
            this.panel_gasStation.Name = "panel_gasStation";
            this.panel_gasStation.Size = new System.Drawing.Size(697, 646);
            this.panel_gasStation.TabIndex = 10;
            // 
            // syncVotersWorker
            // 
            this.syncVotersWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.syncVotersWorker_DoWork);
            this.syncVotersWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.syncVotersWorker_RunWorkerCompleted);
            // 
            // syncVotesWorker
            // 
            this.syncVotesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.syncVotesWorker_DoWork);
            this.syncVotesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.syncVotesWorker_RunWorkerCompleted);
            // 
            // btn_testSpeed
            // 
            this.btn_testSpeed.BackColor = System.Drawing.Color.Khaki;
            this.btn_testSpeed.FlatAppearance.BorderSize = 0;
            this.btn_testSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_testSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_testSpeed.Location = new System.Drawing.Point(415, 7);
            this.btn_testSpeed.Name = "btn_testSpeed";
            this.btn_testSpeed.Size = new System.Drawing.Size(273, 46);
            this.btn_testSpeed.TabIndex = 10;
            this.btn_testSpeed.Text = "Test Read Speed";
            this.btn_testSpeed.UseVisualStyleBackColor = false;
            this.btn_testSpeed.Click += new System.EventHandler(this.btn_testSpeed_Click);
            // 
            // testReadSpeedWorker
            // 
            this.testReadSpeedWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.testReadSpeedWorker_DoWork);
            this.testReadSpeedWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.testReadSpeedWorker_RunWorkerCompleted);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 737);
            this.Controls.Add(this.panel_gasStation);
            this.Controls.Add(this.panel_side);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_main);
            this.Name = "admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.admin_FormClosed);
            this.Load += new System.EventHandler(this.admin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_side.ResumeLayout(false);
            this.panel_gasStation.ResumeLayout(false);
            this.panel_gasStation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btn_addCandidate;
        public System.Windows.Forms.Button btn_registerVoter;
        private System.Windows.Forms.Label lbl_page;
        public System.Windows.Forms.Button btn_contract;
        public System.Windows.Forms.Panel panel_side;
        private System.Windows.Forms.Button btn_getPrices;
        private System.Windows.Forms.WebBrowser browser_gasStation;
        private System.Windows.Forms.Label lbl_gasStation;
        private System.Windows.Forms.Timer refresh_timer;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Panel panel_gasStation;
        public System.Windows.Forms.Panel panel_main;
        public System.Windows.Forms.Button btn_selectContract;
        public System.Windows.Forms.Button btn_createDistrict;
        public System.Windows.Forms.Button btn_syncVoters;
        public System.Windows.Forms.Button btn_syncVotes;
        private System.ComponentModel.BackgroundWorker syncVotersWorker;
        private System.ComponentModel.BackgroundWorker syncVotesWorker;
        public System.Windows.Forms.Button btn_results;
        private System.Windows.Forms.Button btn_testSpeed;
        private System.ComponentModel.BackgroundWorker testReadSpeedWorker;
    }
}

