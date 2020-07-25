using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Nethereum.ABI.Encoders;
using election_thesis.Properties;

namespace election_thesis
{
    public partial class VoteConfirm : Form
    {
        int p;
        int vp;
        List<int> sen;
        string districtID;
        string voterID;
        bool voted = false;
        MySqlConnection conn;
        public VoteConfirm(int presidentVote, int vicePresidentVote, List<int> senators, string districtID, string voterID)
        {
            InitializeComponent();
            p = presidentVote;
            vp = vicePresidentVote;
            sen = senators;
            this.districtID = districtID;
            this.voterID = voterID;
            conn = new MySqlConnection(Settings.Default.connstring);
        }

        private void VoteConfirm_Load(object sender, EventArgs e)
        {
            
            loadVotedCandidates();
        }

        private void loadVotedCandidates()
        {
            DataTable dt = new DataTable();
            DataTable selectedSenators = new DataTable();
            string selectVotedPresident = "SELECT concat(lastname,', ',firstname,' ',middlename) as Candidate FROM electiondb.candidate where candidateID = "+ p.ToString() +";";
            string selectVotedVicePresident = "SELECT concat(lastname,', ',firstname,' ',middlename) as Candidate FROM electiondb.candidate where candidateID = " + vp.ToString() + ";";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(selectVotedPresident, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            adp.Fill(dt);

            try
            {
                lbl_pres.Text = dt.Rows[0][0].ToString();
            }
            catch
            {
                lbl_pres.Text = "(Abstain)";
            }

            conn.Open();
            comm = new MySqlCommand(selectVotedVicePresident, conn);
            adp = new MySqlDataAdapter(comm);
            conn.Close();

            dt.Clear();
            adp.Fill(dt);

            try
            {
                lbl_vPres.Text = dt.Rows[0][0].ToString();
            }
            catch
            {
                lbl_vPres.Text = "(Abstain)";
            }

            dt.Clear();
            foreach(int item in sen)//(int i=0; i < sen.Count; i++)
            {
                string selectVotedSenator = "SELECT concat(lastname,', ',firstname,' ',middlename) as Candidate FROM electiondb.candidate where candidateID = " + item.ToString() + ";";
                conn.Open();
                comm = new MySqlCommand(selectVotedSenator, conn);
                adp = new MySqlDataAdapter(comm);
                conn.Close();
                adp.Fill(dt);
            }

            dt_senators.DataSource = dt;
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

        //Get the address of the district contract
        private string getContractAddress()
        {
            DataTable contract = new DataTable();

            conn.Open();
            string selectContract = "select cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(districtContractAddress, ':', -1)), " +
                "CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(districtContractAddress, ':', 1))) as char)," +
                " cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(districtAccountKey, ':', -1)), " +
                "CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(districtAccountKey, ':', 1))) as char) from district where districtID = " + districtID;
            MySqlCommand comm = new MySqlCommand(selectContract, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(contract);
            conn.Close();

            string contractAddress = contract.Rows[0][0].ToString();

            privateKey = contract.Rows[0][1].ToString();
            account = new Account(privateKey);
            web3 = new Web3(account, url);

            return contractAddress;
        }

        string gasUsed = "";
        public async Task<bool> vote()
        {
            bool success = false;
            var ballotABI = @"[{""inputs"":[{""internalType"":""bytes32"",""name"":""_main_key"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_sub_key"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_district"",""type"":""bytes32""}],""stateMutability"":""nonpayable"",""type"":""constructor""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""Vote_Details"",""outputs"":[{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""}],""name"":""checkVoterExists"",""outputs"":[{""internalType"":""uint8"",""name"":"""",""type"":""uint8""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_precint_no"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""registerVoter"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voteStringA"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_voteStringB"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_vote_date"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""vote"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""}]";

            try
            {
                var contractAddress = getContractAddress();
                var theContract = web3.Eth.GetContract(ballotABI, contractAddress);
                var voteFunction = theContract.GetFunction("vote");

                string voteString = getVoteString();

                string voteStringA = "";
                string voteStringB = "";

                if (voteString.Length > 32)
                {
                    voteStringA = voteString.Substring(0, 32);
                    voteStringB = voteString.Substring(32);
                }
                else
                {
                    voteStringA = voteString;
                }

                string keyString = privateKey.Substring(0, 4) + privateKey.Substring(privateKey.Length - 4, 4);

                Bytes32TypeEncoder encoder = new Bytes32TypeEncoder();
                byte[] byte_voteStringA = encoder.Encode(voteStringA);
                byte[] byte_voteStringB = encoder.Encode(voteStringB);
                byte[] byte_voterID = encoder.Encode(voterID);
                byte[] byte_dateTime = encoder.Encode(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                byte[] byte_key = encoder.Encode(keyString);

                var vote = await voteFunction.SendTransactionAndWaitForReceiptAsync(account.Address, gasLimit, gasPrice, null,null, 
                    byte_voteStringA, byte_voteStringB, byte_voterID, byte_dateTime, byte_key);

                if (vote.HasErrors().Value)
                {
                    MessageBox.Show("An error on the blockchain has occurred. Voting was not successfull", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    success = false;
                }
                else
                {
                    string senatorArray = String.Join(", ", sen.ConvertAll(i => i.ToString()).ToArray());
                    string addVote = "INSERT INTO `electiondb`.`vote` (`voterID`, `presidentVote`, `vicePresidentVote`, `senatorVote`, `datetimevoted`, `voteString`) " +
                        "VALUES ('" + voterID + "', '" + p.ToString() + "', '" + vp.ToString() + "', '" + senatorArray + "', current_timestamp(), '"+ voteString + "');";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(addVote, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();                   

                    success = true; 
                }

                gasUsed = vote.GasUsed.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                success = false;
            }

            return success;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Click OK to confirm.", "Confirm Vote", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr.Equals(DialogResult.OK))
            {
                pt = new ProcessingTransaction();
                pt.FormClosed += ptClosed;
                this.Hide();
                pt.Show();
                sendVotesWorker.RunWorkerAsync();
            }
        }

        private void ptClosed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendVotesWorker_DoWork(object sender, DoWorkEventArgs e)
        {          
            e.Result = vote().Result;
        }       

        private void sendVotesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.Equals(true))
            {
                string updateVoter = "UPDATE `electiondb`.`voter` SET `voterStatus` = 1 WHERE (`voterID` = '" + voterID + "');";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(updateVoter, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Voted Successfully!");
                voted = true;

                int transactionTime = pt.getTime();
                string trackTime = "INSERT INTO `electiondb`.`timekeeper` (`transactionTime`,`gasUsed`,`voteID`) VALUES ('" + transactionTime.ToString() + "','"+ gasUsed + "',(select voteID from vote where voterID = '"+voterID+"'));";
                conn.Open();
                comm = new MySqlCommand(trackTime, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            pt.timer1.Stop();
            pt.Close();
        }        

        public string getVoteString()
        {
            string voteString = "";

            if (!p.ToString().Equals("-1"))
            {
                voteString += "1:" + p.ToString() + "&";
            }

            if (!vp.ToString().Equals("-1"))
            {
                voteString += "2:" + vp.ToString() + "&";
            }

            if (sen.Count != 0)
            {
                int counter = 0;
                voteString += "3:";
                foreach (int item in sen)
                {
                    counter++;

                    voteString += item.ToString();

                    if (counter < sen.Count)
                    {
                        voteString += ",";
                    }
                }
            }

            return voteString;
        }

        public bool voteCompleted()
        {
            return voted;
        }
    }
}
