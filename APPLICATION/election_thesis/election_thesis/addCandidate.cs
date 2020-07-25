using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Nethereum.Web3;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts.CQS;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using Nethereum.ABI.Encoders;
using election_thesis.Properties;

namespace election_thesis
{
    public partial class addCandidate : Form
    {
        MySqlConnection conn;
        string adminID;
        admin mainAdmin;
        public addCandidate(admin a,string adminID)
        {
            InitializeComponent();
            conn = new MySqlConnection(Settings.Default.connstring);

            this.adminID = adminID;
            mainAdmin = a;
        }

        DataTable partyList;
        DataTable positionList;

        private void addCandidate_Load(object sender, EventArgs e)
        {
            partyList = new DataTable();
            positionList = new DataTable();


            conn.Open();
            string readParty = "SELECT * FROM party;";
            MySqlCommand comm = new MySqlCommand(readParty,conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(partyList);

            string readPosition = "SELECT * FROM position;";
            comm = new MySqlCommand(readPosition, conn);
            adp = new MySqlDataAdapter(comm);
            adp.Fill(positionList);
            conn.Close();

            for(int i = 0; i < partyList.Rows.Count; i++)
            {
                cmb_polPar.Items.Add(partyList.Rows[i][1]);
            }

            for (int i = 0; i < positionList.Rows.Count; i++)
            {
                cmb_position.Items.Add(positionList.Rows[i][1]);
            }

            loadCandidates();
        }

        private void loadCandidates()
        {
            DataTable candidateList = new DataTable();

            conn.Open();
            string readCand = "select concat(cand.lastname,', ',cand.firstname,' ',cand.middlename)  as 'Candidate Name', " +
                "positionTitle as 'Position', " +
                "partyName as 'Party', " +
                "concat(ad.firstname, ' ', ad.lastname) as 'Added By' " +
                "from candidate cand join `position` pos on cand.position = pos.positionID join party par on cand.party = par.partyID " +
                "join `admin` ad on cand.addedBy = ad.adminID; ";
            MySqlCommand comm = new MySqlCommand(readCand, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(candidateList);
            conn.Close();

            dt_candidates.DataSource = candidateList;
        }

        private void btn_cancelCandidate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addCandidate(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Candidate will be added to both database and the blockchain. Clik OK to proceed.", "Confirm Add Candidate", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr.Equals(DialogResult.OK))
            {
                pt = new ProcessingTransaction();
                pt.TopLevel = false;
                pt.TopMost = true;
                pt.FormClosed += ptClosed;
                mainAdmin.panel_main.Controls.Add(pt);
                this.Hide();
                pt.Show();
                addCanidateWorker.RunWorkerAsync();
            }

        }
        
        //the loading screen
        ProcessingTransaction pt;               

        private void ptClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        public async Task<bool> blockchain_addCandidate()
        {
            bool success = false;
            MySqlCommand comm;
            DataTable candidateTable = new DataTable();

            //access ui elements from Task. Source of code: https://stackoverflow.com/questions/11109042/getting-the-text-in-a-richtextbox-thats-on-another-thread
            var firstname = (string)txt_firstname.Invoke(new Func<string>(() => txt_firstname.Text));
            var middlename = (string)txt_middlename.Invoke(new Func<string>(() => txt_middlename.Text));
            var lastname = (string)txt_lastname.Invoke(new Func<string>(() => txt_lastname.Text));
            var position = (int)cmb_position.Invoke(new Func<int>(() => cmb_position.SelectedIndex));
            var party = (int)cmb_polPar.Invoke(new Func<int>(() => cmb_polPar.SelectedIndex));

            try
            {
                //Add candidates to the database
                string insertCandidate = "INSERT INTO `electiondb`.`candidate` (`firstname`, `lastname`, `middlename`, `position`, `party`, `addedBy`) " +
                     "VALUES ('" + firstname + "', '" + lastname + "', '" + middlename + "', '" +
                     positionList.Rows[position][0] + "', '" + partyList.Rows[party][0] + "'," + adminID + ");";

                conn.Open();
                comm = new MySqlCommand(insertCandidate, conn);
                comm.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                string readCand = "select candidateID, position, party from `electiondb`.`candidate` where firstname = '" + firstname + "' and lastname = '" + lastname + "' and middlename = '" + middlename + "' and position = " + positionList.Rows[position][0] + " and party = " + partyList.Rows[party][0] + ";";
                comm = new MySqlCommand(readCand, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                adp.Fill(candidateTable);
                conn.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error has occured: " + ex.Message, "An error has occured...", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                string deleteCandidate = "Delete from  `electiondb`.`candidate` where candidateID = " + candidateTable.Rows[0][0].ToString() + ";";
                conn.Open();
                comm = new MySqlCommand(deleteCandidate, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                success = false;
            }

            return success;

        }            
        private void addCanidateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = blockchain_addCandidate().Result;
        }

        private void addCanidateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.Equals(true))
            {
                txt_firstname.Clear();
                txt_lastname.Clear();
                txt_middlename.Clear();
                cmb_position.SelectedIndex = -1;
                cmb_polPar.SelectedIndex = -1;
            }
            pt.timer1.Stop();
            loadCandidates();
            pt.Close();
        }

        private void txt_firstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txt_middlename_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txt_lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
