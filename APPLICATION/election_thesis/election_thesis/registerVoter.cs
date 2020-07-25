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
    public partial class registerVoter : Form
    {
        MySqlConnection conn;
        admin mainAdmin;
        string adminID;
        public registerVoter(string id, admin a)
        {
            conn = new MySqlConnection(Settings.Default.connstring);

            mainAdmin = a;
            adminID = id;
            InitializeComponent();
        }

        private void registerVoter_Load(object sender, EventArgs e)
        {
            loadDistricts();
        }

        DataTable districts;       
        private void loadDistricts()
        {
            string loadDistrictsQuery = "Select districtID, districtName as 'District', address as 'District Adress' from district where districtContractAddress is not null";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(loadDistrictsQuery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            districts = new DataTable();
            adp.Fill(districts);  

            for (int i = 0; i < districts.Rows.Count; i++)
            {
                cmb_districts.Items.Add(districts.Rows[i][1] + " | " + districts.Rows[i][2]);
            }

            
        }

        DataTable precincts;
        private void loadPrecinct()
        {
            conn.Open();
            string loadPrecinctsQuery = "select p.precinctID, p.precinctName, p.address, p.districtID from precinct p join district d on p.districtID = d.districtID where d.districtID = "+ districts.Rows[cmb_districts.SelectedIndex][0].ToString() + ";";
            MySqlCommand comm = new MySqlCommand(loadPrecinctsQuery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            precincts = new DataTable();
            adp.Fill(precincts);

            for (int i = 0; i < precincts.Rows.Count; i++)
            {
                cmb_precinct.Items.Add(precincts.Rows[i][1] + " | " + precincts.Rows[i][2]);
            }
        }

        private void cmb_districts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmb_precinct.Enabled)
            {
                cmb_precinct.Enabled = true;
            }
            cmb_precinct.Items.Clear();
            loadPrecinct();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_clearAll_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Clear all fields? This action cannot be undone.", "Confirm Clear fields", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(dr.Equals(DialogResult.OK))
            {
                txt_code.Clear();
                txt_firstname.Clear();
                txt_lastname.Clear();
                txt_middlename.Clear();
                txt_voterPassword.Clear();
            }
            
        }

        /*================================================================================
        * 
        * 
        *                      BLOCKCHAIN INTERACTIONS
        * 
        * 
        * =============================================================================*/


        /*-----------------------------------------------------------------------------
          Info when deploying and interacting with the blockchain
       ------------------------------------------------------------------------------*/
        static string url = "https://ropsten.infura.io/v3/ad6031e24d4d47f48077ab7d2ede7c67";
        static string privateKey = "";
        static Account account;
        Web3 web3;
        static Nethereum.Hex.HexTypes.HexBigInteger gasLimit = new Nethereum.Hex.HexTypes.HexBigInteger(1000000);
        static Nethereum.Hex.HexTypes.HexBigInteger gasPrice = new Nethereum.Hex.HexTypes.HexBigInteger(8000000000);

        //the loading screen
        ProcessingTransaction pt;

        private string getContractAddress(string districtID)
        {
            DataTable contract = new DataTable();

            conn.Open();
            string selectContract = "select cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(districtContractAddress, ':', -1)), " +
                "CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(districtContractAddress, ':', 1))) as char) from district where districtID = " + districtID;
            MySqlCommand comm = new MySqlCommand(selectContract, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(contract);
            conn.Close();
            
            string contractAddress = contract.Rows[0][0].ToString();

            return contractAddress;
        }

        private void setDistrictAccount(string districtID)
        {
            DataTable key = new DataTable();

            conn.Open();
            string selectKey = "select cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(districtAccountKey, ':', -1)), C" +
                "ONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(districtAccountKey, ':', 1))) as char) from district where districtID = " + districtID;
            MySqlCommand comm = new MySqlCommand(selectKey, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(key);
            conn.Close();

            privateKey = "0x" + key.Rows[0][0].ToString();
            account = new Account(privateKey);
            web3 = new Web3(account, url);

        }

        private void ptClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btn_registerVoter_Click(object sender, EventArgs e)
        {

            if(cmb_districts.SelectedIndex < 0 || cmb_precinct.SelectedIndex < 0)
            {
                MessageBox.Show("Please input a precinct/district","Input a district/precinct", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Voter will be added to both database and the blockchain. Clik OK to proceed.", "Confirm Register Voter", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dr.Equals(DialogResult.OK))
                {
                    pt = new ProcessingTransaction();
                    pt.TopLevel = false;
                    pt.TopMost = true;
                    pt.FormClosed += ptClosed;
                    mainAdmin.panel_main.Controls.Add(pt);
                    this.Hide();
                    pt.Show();
                    registerVoterWorker.RunWorkerAsync();
                }
            }           
        }

        private void registerVoterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = blockchain_registerVoter().Result;
        }

        string voterCode;
        public async Task<bool> blockchain_registerVoter()
        {
            bool success = false;
            MySqlCommand comm;
            DataTable voterTable = new DataTable();
            DataTable key = new DataTable();

            //access ui elements from Task. Source of code: https://stackoverflow.com/questions/11109042/getting-the-text-in-a-richtextbox-thats-on-another-thread
            var firstname = (string)txt_firstname.Invoke(new Func<string>(() => txt_firstname.Text));
            var middlename = (string)txt_middlename.Invoke(new Func<string>(() => txt_middlename.Text));
            var lastname = (string)txt_lastname.Invoke(new Func<string>(() => txt_lastname.Text));
            var district = (int)cmb_districts.Invoke(new Func<int>(() => cmb_districts.SelectedIndex));
            var precinct = (int)cmb_districts.Invoke(new Func<int>(() => cmb_precinct.SelectedIndex));
            var password = (string)txt_voterPassword.Invoke(new Func<string>(() => txt_voterPassword.Text));

            setDistrictAccount(districts.Rows[district][0].ToString());

            try
            {
                //Add voters to the database
                string salt = RandomString.GetRandomString();
                string passwordVal = "sha2(concat('" + txt_voterPassword.Text + "','" + salt + "'),512)";

                string insertVoter = "INSERT INTO `electiondb`.`voter` (`firstname`, `lastname`, `middlename`, `addedBy`, `districtID`, `precinctID`,`voterPassword`,`salt`)" +
                    " VALUES ('" + txt_firstname.Text + "', '" + txt_lastname.Text + "', '" + txt_middlename.Text + "', '" + adminID + "', " + districts.Rows[district][0].ToString() + ", "
                    + precincts.Rows[precinct][0].ToString() + ", "+ passwordVal + ", '"+salt+"');";

                conn.Open();
                comm = new MySqlCommand(insertVoter, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                string readVoter = "select voterID, districtContractAddress, middlename, precinctID from electiondb.voter c join electiondb.district d on c.districtID = d.districtID where c.firstname = '"
                    +firstname+"' and c.lastname = '"+lastname+"' and c.middlename = '"+middlename+"' and c.districtID = "+ districts.Rows[district][0].ToString() + ";";
                comm = new MySqlCommand(readVoter, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                adp.Fill(voterTable);
                conn.Close();

                //add voters to the blockchain
                var ballotABI = @"[{""inputs"":[{""internalType"":""bytes32"",""name"":""_main_key"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_sub_key"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_district"",""type"":""bytes32""}],""stateMutability"":""nonpayable"",""type"":""constructor""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""Vote_Details"",""outputs"":[{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""}],""name"":""checkVoterExists"",""outputs"":[{""internalType"":""uint8"",""name"":"""",""type"":""uint8""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_precint_no"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""registerVoter"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voteStringA"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_voteStringB"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_vote_date"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""vote"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""}]";
                var theContract = web3.Eth.GetContract(ballotABI, getContractAddress(districts.Rows[district][0].ToString()));
                var addVoterFunction = theContract.GetFunction("registerVoter");

                string keyString = privateKey.Substring(2, 4) + privateKey.Substring(privateKey.Length - 4, 4);

                Bytes32TypeEncoder encoder = new Bytes32TypeEncoder();
                byte[] voterID = encoder.Encode(voterTable.Rows[0][0].ToString());
                byte[] precinctID = encoder.Encode(voterTable.Rows[0][3].ToString());
                byte[] byte_keyString = encoder.Encode(keyString);
                var addVoter = await addVoterFunction.SendTransactionAndWaitForReceiptAsync(account.Address, gasLimit, gasPrice, null, null, voterID,precinctID, byte_keyString);

                success = true;

                MessageBox.Show("Voter successfully registered!");

                byte[] ba = Encoding.Default.GetBytes(voterTable.Rows[0][0].ToString()+txt_middlename.Text.Substring(0,1));
                string hexString = BitConverter.ToString(ba);
                voterCode = hexString.Replace("-", "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error has occured: " + ex.Message, "An error has occured...", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                string deleteCandidate = "Delete from  `electiondb`.`voter` where voterID = " + voterTable.Rows[0][0].ToString() + ";";
                conn.Open();
                comm = new MySqlCommand(deleteCandidate, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                success = false;
            }

            return success;
        }

        

        private void registerVoterWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.Equals(true))
            {
                txt_code.Text = voterCode;
            }
            pt.timer1.Stop();
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

        private void txt_voterPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
