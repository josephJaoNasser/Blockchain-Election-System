using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Numerics;
using Nethereum.ABI.Encoders;
using election_thesis.Properties;

namespace election_thesis
{
    public partial class ResultsForm : Form
    {
        MySqlConnection conn;
        admin mainAdmin;
        Timer t;
        public ResultsForm(admin a)
        {
            conn = new MySqlConnection(Settings.Default.connstring);
            InitializeComponent();
            mainAdmin = a;
        }

        private void CountingForm_Load(object sender, EventArgs e)
        {
            privateKey = "0x" + Settings.Default.privateKey;

            account = new Account(privateKey);
            web3 = new Web3(account, url);

            loadPresCount();
            loadVPressCount();
            loadSenatorCount();
        }

        private void loadPresCount()
        {
            DataTable candidateList = new DataTable();
            
            string initQuery = "select candidateID from electiondb.candidate where position = 1";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(initQuery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            adp.Fill(candidateList);

            DataTable candidateCountList = new DataTable();

            foreach(DataRow dr in candidateList.Rows)
            {
                string query = "SELECT (select concat(lastname,', ',firstname,' ',middlename) from electiondb.candidate where candidateID =" + dr.ItemArray[0].ToString() + " and position = 1) as 'Candidate Name', count(*) as 'Votes' FROM electiondb.vote where voteString REGEXP CONCAT('1:',(select candidateID from electiondb.candidate where candidateID =" + dr.ItemArray[0].ToString() + " and position = 1))";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                adp = new MySqlDataAdapter(comm);
                conn.Close();
                adp.Fill(candidateCountList);
            }

            dt_presidentCount.DataSource = candidateCountList;
            dt_presidentCount.Sort(dt_presidentCount.Columns[1],ListSortDirection.Descending);
        }

        private void loadVPressCount()
        {
            DataTable candidateList = new DataTable();

            string initQuery = "select candidateID from electiondb.candidate where position = 2";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(initQuery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            adp.Fill(candidateList);

            DataTable candidateCountList = new DataTable();

            foreach (DataRow dr in candidateList.Rows)
            {
                string query = "SELECT (select concat(lastname,', ',firstname,' ',middlename) from electiondb.candidate where candidateID =" + dr.ItemArray[0].ToString() + " and position = 2) as 'Candidate Name', count(*) as 'Votes' FROM electiondb.vote where voteString REGEXP CONCAT('2:',(select candidateID from electiondb.candidate where candidateID =" + dr.ItemArray[0].ToString() + " and position = 2))";
                conn.Open();
                comm = new MySqlCommand(query, conn);
                adp = new MySqlDataAdapter(comm);
                conn.Close();
                adp.Fill(candidateCountList);
            }

            dt_vPresCount.DataSource = candidateCountList;
            dt_vPresCount.Sort(dt_vPresCount.Columns[1], ListSortDirection.Descending);
        }

        private void loadSenatorCount()
        {
            try
            {
                Hashtable votesList = new Hashtable();
                DataTable candidateList = new DataTable();

                string getSenators = "SELECT candidateID FROM electiondb.candidate where position = 3;";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(getSenators, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                adp.Fill(candidateList);

                foreach (DataRow dr in candidateList.Rows)
                {
                    votesList.Add(dr.ItemArray[0].ToString(), 0);
                }

                DataTable dt = new DataTable();

                string getVoteString = "SELECT voteID, voteString FROM electiondb.vote;";
                conn.Open();
                comm = new MySqlCommand(getVoteString, conn);
                adp = new MySqlDataAdapter(comm);
                conn.Close();
                adp.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {                    
                    MatchCollection sen_match = Regex.Matches(dr.ItemArray[1].ToString(), @"[3]:(\d*(,)?){12}");

                    string[] senators = new string[12];

                    foreach (Match m in sen_match)
                    {
                        foreach (Capture c in m.Captures)
                        {
                            senators = c.Value.Substring(2).Split(',');

                            //update hashtable values source: https://stackoverflow.com/questions/619044/how-can-i-increase-the-value-in-a-h 
                            foreach (string s in senators)
                            {                                
                                votesList[s] = (int)votesList[s] + 1;
                            }
                        }
                    }
                }

                DataTable candidateCountList = new DataTable();

                foreach (DictionaryEntry de in votesList)
                {
                    string query = "SELECT concat(lastname,', ',firstname,' ',lastname) as 'Candidate Name', " + de.Value + " as 'Votes' from electiondb.candidate where candidateID = " + de.Key + " and position = 3";
                    conn.Open();
                    comm = new MySqlCommand(query, conn);
                    adp = new MySqlDataAdapter(comm);
                    conn.Close();
                    adp.Fill(candidateCountList);                    
                }

                dt_senatorsCount.DataSource = candidateCountList;
                dt_senatorsCount.Sort(dt_senatorsCount.Columns[1], ListSortDirection.Descending);
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_quickCount_Click(object sender, EventArgs e)
        {
            loadPresCount();
            loadVPressCount();
            loadSenatorCount();
            MessageBox.Show("Votes counted.", "Counted", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        static string privateKey;
        static Account account;
        Web3 web3;

        //sql functions
        private string getContractAddress()
        {
            DataTable contract = new DataTable();

            conn.Open();
            string selectContract = "select cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(contractAddress, ':', -1)), CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(contractAddress, ':', 1))) as char) from smartcontracts where active=1";
            MySqlCommand comm = new MySqlCommand(selectContract, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(contract);
            conn.Close();

            string contractAddress = contract.Rows[0][0].ToString();

            return contractAddress;
        }

        private string getContractABI()
        {
            DataTable contract = new DataTable();

            conn.Open();
            string selectContract = "select contractAbi FROM electiondb.smartcontracts where active=1";
            MySqlCommand comm = new MySqlCommand(selectContract, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(contract);
            conn.Close();

            string contractABI = contract.Rows[0][0].ToString();

            return contractABI;
        }

        SyncingForm sf;
        private void btn_syncAndCount_Click(object sender, EventArgs e)
        {          

            sf = new SyncingForm();
            sf.Show();

            syncVotesWorker.RunWorkerAsync();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void syncVotesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable districtTable = new DataTable();

            conn.Open();
            string selectDistrict = "SELECT districtID, cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(districtContractAddress, ':', -1)), CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(districtContractAddress, ':', 1))) as char) from district";
            MySqlCommand comm = new MySqlCommand(selectDistrict, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(districtTable);
            conn.Close();

            string contractAddress = "";
            string voterID = "";

            DataTable voterCount = new DataTable();
            string countVoters = "SELECT count(*) FROM electiondb.vote;";
            conn.Open();
            comm = new MySqlCommand(countVoters, conn);
            adp = new MySqlDataAdapter(comm);
            adp.Fill(voterCount);
            conn.Close();

            int votercount = int.Parse(voterCount.Rows[0][0].ToString());
            double votercountPercent = 0;

            foreach (DataRow dr in districtTable.Rows)
            {
                DataTable voteTable = new DataTable();

                conn.Open();
                string selectVotes = "SELECT vt.voterID, vr.districtID FROM vote vt join voter vr on vt.voterID = vr.voterID where districtID = " + dr.ItemArray[0].ToString();
                comm = new MySqlCommand(selectVotes, conn);
                adp = new MySqlDataAdapter(comm);
                adp.Fill(voteTable);
                conn.Close();

                foreach (DataRow dr2 in voteTable.Rows)
                {
                    contractAddress = dr.ItemArray[1].ToString();
                    voterID = dr2.ItemArray[0].ToString();

                    syncVotes(contractAddress, voterID).Wait();

                    votercountPercent += (1.0 / votercount) * 100;

                    if (votercountPercent > 100)
                    {
                        votercountPercent = 100;
                    }

                    sf.progressBar1.Invoke(new MethodInvoker(delegate { sf.progressBar1.Value = int.Parse(Math.Truncate(votercountPercent).ToString()); }));

                }
            }
        }

        int accessTime = 0;
        public async Task<bool> syncVotes(string districtAddress, string voterID)
        {
            accessTime = 0;
            System.Timers.Timer t = new System.Timers.Timer();
            t.Enabled = true;
            t.Interval = 1;
            t.Elapsed += T_Elapsed; ;
            t.Start();

            string status = "Counted";
            bool success = false;

            MySqlCommand comm;
            MySqlDataAdapter adp;

            string keyString = privateKey.Substring(2, 4) + privateKey.Substring(privateKey.Length - 4, 4);

            try
            {
                var theContract = web3.Eth.GetContract(getContractABI(), getContractAddress());
                var getVotesFunction = theContract.GetFunction("VoteDetails_district");

                Bytes32TypeEncoder encoder = new Bytes32TypeEncoder();
                var byte_voter = encoder.Encode(voterID.ToString());
                byte[] byte_key = encoder.Encode(keyString);

                var syncVotes = await getVotesFunction.CallDeserializingToObjectAsync<VoteDetailsDTO.VoteDetailsOutputDTO>(districtAddress, byte_voter, byte_key);

                DataTable voteDetails = new DataTable();

                conn.Open();
                string selectVotes = "SELECT voteID, voterID, presidentVote, vicePresidentVote, senatorVote, voteString FROM electiondb.vote where voterID = " + voterID + ";";
                comm = new MySqlCommand(selectVotes, conn);
                adp = new MySqlDataAdapter(comm);
                adp.Fill(voteDetails);
                conn.Close();

                string voteStringA = System.Text.Encoding.UTF8.GetString(syncVotes.voteStringA);
                string voteStringB = System.Text.Encoding.UTF8.GetString(syncVotes.voteStringB);
                string dateVoted = System.Text.Encoding.UTF8.GetString(syncVotes.VoteTime);

                string voteString = voteStringA + voteStringB;

                if (!voteString.Equals(voteDetails.Rows[0][5].ToString()))
                {                    
                   string updateVote = "INSERT INTO `electiondb`.`votearchive` (`voteID`, `voterID`, `presidentVote`, `vicePresidentVote`, `senatorVote`, `datetimevoted`, `voteString`) " +
                        "select `voteID`, `voterID`, `presidentVote`, `vicePresidentVote`, `senatorVote`, `datetimevoted`, `voteString` FROM `electiondb`.`vote` WHERE voteID = " + voteDetails.Rows[0][0].ToString() + ";"+
                    "UPDATE `electiondb`.`vote` SET `voteString` = '" + voteString + "' WHERE (`voteID` = '" + voteDetails.Rows[0][0].ToString() + "');";
                    conn.Open();
                    comm = new MySqlCommand(updateVote, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();

                    status = "REVERTED";
                }

                //regular expressions source: https://www.dotnetperls.com/regex-matches
                MatchCollection pres_match = Regex.Matches(voteString, @"[1]:\d*");
                MatchCollection vpres_match = Regex.Matches(voteString, @"[2]:\d*");
                MatchCollection sen_match = Regex.Matches(voteString, @"[3]:(\d*(,)?){12}");

                foreach (Match m in pres_match)
                {
                    foreach (Capture c in m.Captures)
                    {
                        string updateVote = "UPDATE `electiondb`.`vote` SET `presidentVote` = '" + c.Value.Substring(2) + "' WHERE (`voteID` = '" + voteDetails.Rows[0][0].ToString() + "');";
                        conn.Open();
                        comm = new MySqlCommand(updateVote, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                foreach (Match m in vpres_match)
                {
                    foreach (Capture c in m.Captures)
                    {
                        string updateVote = "UPDATE `electiondb`.`vote` SET `vicePresidentVote` = '" + c.Value.Substring(2) + "' WHERE (`voteID` = '" + voteDetails.Rows[0][0].ToString() + "');";
                        conn.Open();
                        comm = new MySqlCommand(updateVote, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                foreach (Match m in sen_match)
                {
                    foreach (Capture c in m.Captures)
                    {
                        string updateVote = "UPDATE `electiondb`.`vote` SET `senatorVote` = '" + c.Value.Substring(2) + "' WHERE (`voteID` = '" + voteDetails.Rows[0][0].ToString() + "');";
                        conn.Open();
                        comm = new MySqlCommand(updateVote, conn);
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                /*string updateDate = "UPDATE `electiondb`.`vote` SET `datetimevoted` = `datetimevoted` = STR_TO_DATE('" + dateVoted + "','%Y%m%d %h%i') WHERE (`voteID` = '"+ voteDetails.Rows[0][0].ToString() + "');";
                conn.Open();
                comm = new MySqlCommand(updateDate, conn);
                comm.ExecuteNonQuery();
                conn.Close();*/

                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message);
                success = false;
            }

            string accessTimeInsert = "INSERT INTO `electiondb`.`accesstime` (`accessTime`, `accessName`, `accessDate`) VALUES ('" + accessTime.ToString() + "', '"+status+" votes for voter: " + voterID + "', now());";
            conn.Open();
            comm = new MySqlCommand(accessTimeInsert, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            t.Stop();            

            return success;
        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            accessTime++;
            //throw new NotImplementedException();
        }


        private void syncVotesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadPresCount();
            loadVPressCount();
            loadSenatorCount();
            MessageBox.Show("Votes checked and synced.", "Synced", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sf.Close();
        }
    }
}
