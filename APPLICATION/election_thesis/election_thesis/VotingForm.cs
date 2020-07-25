using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System.Numerics;
using MySql.Data.MySqlClient;
using election_thesis.Properties;

namespace election_thesis
{
    public partial class VotingForm : Form
    {
        MySqlConnection conn;

        string voterID;
        string voterName;
        string districtID;

        VoteConfirm vc;
        public VotingForm(string voterID, string voterName, string districtID)
        {
            InitializeComponent();
            conn = new MySqlConnection(Settings.Default.connstring);

            this.voterID = voterID;
            this.voterName = voterName;
            this.districtID = districtID;
        }

        private void VotingForm_Load(object sender, EventArgs e)
        {
            loadCandidates();
        }

        DataTable pres;
        DataTable VPres;
        private void loadCandidates()
        {
            lbl_voterName.Text = voterName;

            DataTable senator = new DataTable();

            string loadPresidents = "SELECT * FROM electiondb.candidate where position = 1;";
            string loadVicePresidents = "SELECT * FROM electiondb.candidate where position = 2;";
            string loadSenators = "SELECT candidateID, concat(lastname,', ', firstname, ' ',middlename) as Candidate FROM electiondb.candidate where position = 3 order by lastname asc;";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(loadPresidents, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            pres = new DataTable();
            adp.Fill(pres);

            conn.Open();
            comm = new MySqlCommand(loadVicePresidents, conn);
            adp = new MySqlDataAdapter(comm);
            conn.Close();

            VPres = new DataTable();
            adp.Fill(VPres);

            conn.Open();
            comm = new MySqlCommand(loadSenators, conn);
            adp = new MySqlDataAdapter(comm);
            conn.Close();

            //checkbox column source: https://www.c-sharpcorner.com/UploadFile/deveshomar/adding-checkbox-column-in-datagridview-in-C-Sharp-window-forms/
            senator.Columns.Add("Select", typeof(bool));
            adp.Fill(senator);

            for (int i = 0; i < pres.Rows.Count; i++)
            {
                cmb_president.Items.Add(pres.Rows[i][2] +", " + pres.Rows[i][1] + " " + pres.Rows[i][3]);
            }

            for (int i = 0; i < VPres.Rows.Count; i++)
            {
                cmb_vicePresident.Items.Add(VPres.Rows[i][2] + ", " + VPres.Rows[i][1] + " " + VPres.Rows[i][3]);
            }


            dt_senators.DataSource = senator;

            dt_senators.Columns["Select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dt_senators.Columns["candidateID"].Visible = false;
            dt_senators.Columns["Candidate"].ReadOnly = true;

        }

        int senatorCount = 0;
        int selectedRowIndex = -1;       
        //get checkbox value source: https://stackoverflow.com/questions/23084438/show-message-box-when-the-check-box-in-the-datagridview-is-checked?rq=1
        private void dt_senators_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dt_senators.IsCurrentCellDirty)
            {
                dt_senators.CommitEdit(DataGridViewDataErrorContexts.Commit);                
            }
        }

        private void dt_senators_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dt_senators.IsCurrentCellDirty)
            {
                var value = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                selectedRowIndex = e.RowIndex;

                if (value.ToString().Equals("True"))
                {
                    senatorCount++;
                }
                else
                {
                    senatorCount--;
                }

                

                if (senatorCount >= 12)
                {
                    dt_senators.Columns["Select"].ReadOnly = true;
                }                
                
            }
        }

        private void btn_undoLast_Click(object sender, EventArgs e)
        {
            if (senatorCount > 0)
            {
                dt_senators.Rows[selectedRowIndex].Cells["Select"].Value = false;
                senatorCount--;
            }
            if (senatorCount < 12)
            {
                dt_senators.Columns["Select"].ReadOnly = false;
            }
        }

        private void btn_undoAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dgvr in dt_senators.Rows)
            {
                if (dgvr.Cells["Select"].Value.ToString().Equals("True"))
                {
                    dgvr.Cells["Select"].Value = false;
                }
            }
            senatorCount = 0;
            dt_senators.Columns["Select"].ReadOnly = false;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            int presID;
            int VPresID;

            List<int> senatorVotes = new List<int>();

            if (cmb_president.SelectedIndex == -1)
            {
                presID = -1;
            }
            else
            {
                presID = int.Parse(pres.Rows[cmb_president.SelectedIndex]["candidateID"].ToString());
            }

            if (cmb_vicePresident.SelectedIndex == -1)
            {
                VPresID = -1;
            }
            else
            {
                VPresID = int.Parse(VPres.Rows[cmb_vicePresident.SelectedIndex]["candidateID"].ToString());
            }    
            
            for (int i = 0; i < dt_senators.Rows.Count; i++)
            {
                if (dt_senators.Rows[i].Cells["Select"].Value.ToString().Equals("True"))
                {
                    senatorVotes.Add(int.Parse(dt_senators.Rows[i].Cells["candidateID"].Value.ToString()));
                }
            }

            vc = new VoteConfirm(presID, VPresID, senatorVotes, districtID, voterID);
            vc.FormClosed += vcClosed;
            vc.Show();
            
            
        }

        private void vcClosed(Object sender, EventArgs e)
        {
            if (vc.voteCompleted())
            {
                this.Close();
            }
            
        }
    }
}
