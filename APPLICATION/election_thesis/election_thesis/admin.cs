using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
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
    public partial class admin : Form
    {
        MySqlConnection conn;
        string adminID = "";
        Form loginForm;

        public admin(string adminID, Form loginForm)
        {
            InitializeComponent();
            conn = new MySqlConnection(Settings.Default.connstring);

            this.adminID = adminID;
            this.loginForm = loginForm;

        }

        /*-----------------------------------------------------------------------------
         Info when deploying and interacting with the blockchain
      ------------------------------------------------------------------------------*/
        static string url = "https://ropsten.infura.io/v3/ad6031e24d4d47f48077ab7d2ede7c67";
        static string privateKey;
        static Account account;
        Web3 web3;

        private void admin_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string getKey = "select cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(ek.key, ':', -1)), CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(ek.key, ':', 1))) as char) from ethkey ek where ek.owner = " + this.adminID + ";";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(getKey, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            adp.Fill(dt);

            Settings.Default.privateKey = dt.Rows[0][0].ToString();
            privateKey = "0x" + Settings.Default.privateKey;

            account = new Account(privateKey);
            web3 = new Web3(account, url);
        }

        //-------------------add candidate form-------------------
        private void btn_addCandidate_Click(object sender, EventArgs e)
        {
            panel_side.Hide();           
            panel_gasStation.Hide();
            panel_main.Show();
            addCandidate frm_addCandidate = new addCandidate(this,adminID);
            frm_addCandidate.TopLevel = false;
            frm_addCandidate.TopMost = true;
            frm_addCandidate.FormClosed += frm_addCandidateClosed;
            panel_main.Controls.Add(frm_addCandidate);
            lbl_page.Text = "Add Candidate";
            frm_addCandidate.Show();
        }

        private void frm_addCandidateClosed(object sender, FormClosedEventArgs e)
        {
            panel_side.Show();
            panel_gasStation.Show();
            panel_main.Hide();
            lbl_page.Text = "Home";
        }

        //-------------------register voter form-------------------
        private void btn_registerVoter_Click(object sender, EventArgs e)
        {
            panel_side.Hide();
            panel_gasStation.Hide();
            panel_main.Show();
            registerVoter rv = new registerVoter(adminID, this);
            rv.TopLevel = false;
            rv.TopMost = true;
            rv.FormClosed += rvClosed;
            panel_main.Controls.Add(rv);
            lbl_page.Text = "Register Voter";
            rv.Show();
        }

        private void rvClosed(object sender, FormClosedEventArgs e)
        {
            panel_side.Show();
            panel_gasStation.Show();
            panel_main.Hide();
            lbl_page.Text = "Home";
        }

        //-------------------deploy contract form-------------------
        private void btn_contract_Click(object sender, EventArgs e)
        {
            panel_side.Hide();
            panel_gasStation.Hide();
            panel_main.Show();
            DeployContract dc = new DeployContract(adminID, this);
            dc.TopLevel = false;
            dc.TopMost = true;
            dc.FormClosed += dcClosed;
            panel_main.Controls.Add(dc);
            lbl_page.Text = "Deploy Smart Contracts";
            dc.Show();
        }        

        private void dcClosed(object sender, FormClosedEventArgs e)
        {
            panel_side.Show();
            panel_gasStation.Show();
            panel_main.Hide();
            lbl_page.Text = "Home";
        }

        //-------------------select active smart contract form-------------------
        private void btn_selectContract_Click(object sender, EventArgs e)
        {
            panel_side.Hide();
            panel_gasStation.Hide();
            panel_main.Show();
            setContractAddress sca = new setContractAddress();
            sca.TopLevel = false;
            sca.TopMost = true;
            sca.FormClosed += scaClosed;
            panel_main.Controls.Add(sca);
            lbl_page.Text = "Select Active Smart Contract";
            sca.Show();
        }

        private void scaClosed(object sender, FormClosedEventArgs e)
        {
            panel_side.Show();
            panel_gasStation.Show();
            panel_main.Hide();
            lbl_page.Text = "Home";
        }

        //-------------------select active smart contract form-------------------
        private void btn_results_Click(object sender, EventArgs e)
        {
            panel_side.Hide();
            panel_gasStation.Hide();
            panel_main.Show();
            ResultsForm rf = new ResultsForm(this);
            rf.TopLevel = false;
            rf.TopMost = true;
            rf.FormClosed += rfClosed;
            panel_main.Controls.Add(rf);
            lbl_page.Text = "Election Results";
            rf.Show();
        }

        private void rfClosed(object sender, FormClosedEventArgs e)
        {
            panel_side.Show();
            panel_gasStation.Show();
            panel_main.Hide();
            lbl_page.Text = "Home";
        }

        //-------------------select active smart contract form-------------------
        private void btn_createDistrict_Click(object sender, EventArgs e)
        {
            panel_side.Hide();
            panel_gasStation.Hide();
            panel_main.Show();
            addDistrict ad = new addDistrict(this);
            ad.TopLevel = false;
            ad.TopMost = true;
            ad.FormClosed += adClosed;
            panel_main.Controls.Add(ad);
            lbl_page.Text = "Add District Contract";
            ad.Show();
        }

        private void adClosed(object sender, FormClosedEventArgs e)
        {
            panel_side.Show();
            panel_gasStation.Show();
            panel_main.Hide();
            lbl_page.Text = "Home";
        }

        //eth gas station controls
        int timer = 60;
        private void btn_getPrices_Click(object sender, EventArgs e)
        {
            lbl_gasStation.Text = "Refreshing...";
            browser_gasStation.Refresh();
            lbl_gasStation.Text = "Ethereum Gas Station";
            timer = 60;
            lbl_timer.ForeColor = Color.Black;
        }

        private void browser_gasStation_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            lbl_gasStation.Text = "Ethereum Gas Station";
            refresh_timer.Start();
        }


        private void refresh_timer_Tick(object sender, EventArgs e)
        {
            timer--;
            lbl_timer.Text = "Refreshing in " + timer.ToString() + "s";

            if (timer == 10)
            {
                lbl_timer.ForeColor = Color.Red;
            }

            if (timer == 0)
            {
                lbl_gasStation.Text = "Refreshing...";
                browser_gasStation.Refresh();
                lbl_gasStation.Text = "Ethereum Gas Station";
                lbl_timer.Text = "Refreshing in 60s";
                timer = 60;
                lbl_timer.ForeColor = Color.Black;
            }

        }
        
        //-------------------close admin -------------------
        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Show();
        }

        /*================================================================================
         * 
         * 
         *                      BLOCKCHAIN INTERACTIONS
         * 
         * 
         * =============================================================================*/


       

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

        //test count -------------------------------
        //byte converter sources: https://github.com/Nethereum/Nethereum/blob/master/src/Nethereum.ABI/Encoders/Bytes32TypeEncoder.cs
        //                        https://stackoverflow.com/questions/1003275/how-to-convert-utf-8-byte-to-string
        //                        https://stackoverflow.com/questions/16999604/convert-string-to-hex-string-in-c-sharp
     
    


        //hashtable/dictionary entry source: https://docs.microsoft.com/en-us/dotnet/api/system.collections.dictionaryentry?view=netframework-4.8
      

        //sync voters ------------------------
        SyncingForm sf;
        private void btn_syncVoters_Click(object sender, EventArgs e)
        {           

            sf = new SyncingForm();
            sf.Show();

            syncVotersWorker.RunWorkerAsync();            

        }        

        private void syncVotersWorker_DoWork(object sender, DoWorkEventArgs e)
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
            string countVoters = "SELECT count(*) FROM electiondb.voter;";
            conn.Open();
            comm = new MySqlCommand(countVoters, conn);
            adp = new MySqlDataAdapter(comm);
            adp.Fill(voterCount);
            conn.Close();

            int votercount = int.Parse(voterCount.Rows[0][0].ToString());
            double votercountPercent = 0;

            foreach (DataRow dr in districtTable.Rows)
            {
                DataTable voterTable = new DataTable();

                conn.Open();
                string selectVoters = "SELECT voterID, districtID, precinctID from voter where districtID = " + dr.ItemArray[0].ToString();
                comm = new MySqlCommand(selectVoters, conn);
                adp = new MySqlDataAdapter(comm);
                adp.Fill(voterTable);
                conn.Close();

                foreach (DataRow dr2 in voterTable.Rows)
                {
                    contractAddress = dr.ItemArray[1].ToString();
                    voterID = dr2.ItemArray[0].ToString();

                    syncVoters(contractAddress, voterID).Wait();

                    votercountPercent += (1.0 / votercount) * 100;

                    if(votercountPercent > 100)
                    {
                        votercountPercent = 100;
                    }

                    sf.progressBar1.Invoke(new MethodInvoker(delegate { sf.progressBar1.Value = int.Parse(Math.Truncate(votercountPercent).ToString()); }));                   
                                                   
                }
            }

        }

        public async Task<bool> syncVoters(string contractAddress, string voterID)
        {
            bool exists = false;

            accessTime = 0;
            
            System.Timers.Timer t = new System.Timers.Timer();
            t.Enabled = true;
            t.Interval = 1;
            t.Elapsed += T_Elapsed;
            t.Start();

            string status = "Retrieved";

            MySqlCommand comm;           

            try
            {
                var ballotABI = @"[{""inputs"":[{""internalType"":""bytes32"",""name"":""_main_key"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_sub_key"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_district"",""type"":""bytes32""}],""stateMutability"":""nonpayable"",""type"":""constructor""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""Vote_Details"",""outputs"":[{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""}],""name"":""checkVoterExists"",""outputs"":[{""internalType"":""uint8"",""name"":"""",""type"":""uint8""},{""internalType"":""bytes32"",""name"":"""",""type"":""bytes32""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_precint_no"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""registerVoter"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""bytes32"",""name"":""_voteStringA"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_voteStringB"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_voter_id"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_vote_date"",""type"":""bytes32""},{""internalType"":""bytes32"",""name"":""_key"",""type"":""bytes32""}],""name"":""vote"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""}]";
                var theContract = web3.Eth.GetContract(ballotABI, contractAddress);
                var checkVoterExists = theContract.GetFunction("checkVoterExists");

                Bytes32TypeEncoder encoder = new Bytes32TypeEncoder();
                byte[] theByte = encoder.Encode(voterID.ToString());
                
                var check = await checkVoterExists.CallDeserializingToObjectAsync<VoterDetailsDTO.VoterDetailsOutputDTO>(theByte); 

                if (check.Exists.ToString() != "1")
                {                    
                    DataTable otherDistricts = new DataTable();

                    conn.Open();
                    string selectOtherDistricts = "SELECT districtID, CAST(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(districtContractAddress, ':', - 1)), CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(districtContractAddress, ':', 1)))AS CHAR) FROM district WHERE cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(districtContractAddress, ':', -1)), CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(districtContractAddress, ':', 1))) as char) != '" + contractAddress + "'";
                    comm = new MySqlCommand(selectOtherDistricts, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                    adp.Fill(otherDistricts);
                    conn.Close();

                    int otherDistrictCount = 0;

                    foreach (DataRow dr in otherDistricts.Rows)
                    {
                        otherDistrictCount++;

                        theContract = web3.Eth.GetContract(ballotABI, dr.ItemArray[1].ToString());
                        checkVoterExists = theContract.GetFunction("checkVoterExists");
                        check = await checkVoterExists.CallDeserializingToObjectAsync<VoterDetailsDTO.VoterDetailsOutputDTO>(theByte);
                            
                        if (check.Exists.ToString() == "1")
                        {
                            status = "REVERTED";

                            string syncQuery = "INSERT INTO `electiondb`.`voterarchive` " +
                                "(`voterID`, `firstname`, `lastname`, `middlename`, `addedBy`, `districtID`, `precinctID`, `voterStatus`, `voterPassword`, `salt`)" +
                                "SELECT voterID, firstname, lastname, middlename, addedBy, districtID, precinctID, voterStatus, voterPassword, salt " +
                                "FROM electiondb.voter where voterID = '" + voterID + "';" +
                                "UPDATE `electiondb`.`voter` SET `districtID` = '" + dr.ItemArray[0].ToString() + "' WHERE (`voterID` = '" + voterID + "');";
                            conn.Open();
                            comm = new MySqlCommand(syncQuery, conn);
                            comm.ExecuteNonQuery();
                            conn.Close();

                            exists = true;
                        }
                        
                        if(check.Exists.ToString() != "1" && otherDistrictCount == otherDistricts.Rows.Count)
                        {
                            DataTable dt = new DataTable();

                            string checkVote = "Select * from electiondb.vote where voterID = " + voterID + ";";                             
                            conn.Open();
                            comm = new MySqlCommand(checkVote, conn);
                            adp = new MySqlDataAdapter(comm);
                            adp.Fill(dt);
                            conn.Close();

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dtr in dt.Rows)
                                {
                                    string moveVote = "INSERT INTO `electiondb`.`votearchive` (`voteID`, `voterID`, `presidentVote`, `vicePresidentVote`, `senatorVote`, `datetimevoted`, `voteString`) " +
                                        "select `voteID`, `voterID`, `presidentVote`, `vicePresidentVote`, `senatorVote`, `datetimevoted`, `voteString` FROM `electiondb`.`vote` " +
                                        "WHERE voteID = " + dtr.ItemArray[0].ToString() + ";"+
                                        "DELETE from `electiondb`.`timekeeper` where voteID = " + dtr.ItemArray[0].ToString() + ";" +
                                        "DELETE from `electiondb`.`vote` where voteID = " + dtr.ItemArray[0].ToString() + ";";
                                    conn.Open();
                                    comm = new MySqlCommand(moveVote, conn);
                                    comm.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }

                            string moveVoter = "INSERT INTO `electiondb`.`voterarchive` " +
                                "(`voterID`, `firstname`, `lastname`, `middlename`, `addedBy`, `districtID`, `precinctID`, `voterStatus`, `voterPassword`, `salt`)" +
                                "SELECT voterID, firstname,lastname,middlename,addedBy,districtID,precinctID,voterStatus,voterPassword,salt FROM electiondb.voter where voterID = '" + voterID + "';" +
                                "Delete from electiondb.voter where voterID = '" + voterID + "';";

                            conn.Open();
                            comm = new MySqlCommand(moveVoter, conn);
                            comm.ExecuteNonQuery();
                            conn.Close();


                            MessageBox.Show("Voter No." + voterID + " archived");
                        }

                    }                    

                }
                else if (check.Exists.ToString() == "1")
                {
                    exists = true;
                }

                string precinctID = Encoding.Default.GetString(check.precinctID);
                int precinctIDint = int.Parse(precinctID);

                string updatePrecinct = "UPDATE `electiondb`.`voter` SET `precinctID` = " + precinctIDint.ToString() + " WHERE (`voterID` = '" + voterID + "');";
                conn.Open();
                comm = new MySqlCommand(updatePrecinct, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string accessTimeInsert = "INSERT INTO `electiondb`.`accesstime` (`accessTime`, `accessName`, `accessDate`) VALUES ('" + accessTime.ToString() + "', '"+status+" voter information for voter: " + voterID + "', now());";
            conn.Open();
            comm = new MySqlCommand(accessTimeInsert, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            t.Stop();
            
            return exists;
        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            accessTime++;
            //throw new NotImplementedException();
        }

        private void syncVotersWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            MessageBox.Show("Voters checked and synced.", "Synced",MessageBoxButtons.OK, MessageBoxIcon.Information);
            sf.Close();
        }

        //sync votes ------------------------
        private void btn_syncVotes_Click(object sender, EventArgs e)
        {            
            sf = new SyncingForm();
            sf.Show();

            syncVotesWorker.RunWorkerAsync();
        }

        int accessTime = 0;
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

        public async Task<bool> syncVotes(string districtAddress, string voterID)
        {
            accessTime = 0;
            System.Timers.Timer t = new System.Timers.Timer();
            t.Enabled = true;
            t.Interval = 1;
            t.Elapsed += T_Elapsed;
            t.Start();

            bool success = false;
            string status = "Counted";

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
                string selectVotes = "SELECT voteID, voterID, presidentVote, vicePresidentVote, senatorVote, voteString FROM electiondb.vote where voterID = "+voterID+";";
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
                        "select `voteID`, `voterID`, `presidentVote`, `vicePresidentVote`, `senatorVote`, `datetimevoted`, `voteString` FROM `electiondb`.`vote` " +
                        "WHERE voteID = " + voteDetails.Rows[0][0].ToString() + ";" +
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
                        string updateVote = "UPDATE `electiondb`.`vote` SET `presidentVote` = '"+ c.Value.Substring(2) + "' WHERE (`voteID` = '" + voteDetails.Rows[0][0].ToString() + "');";
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

                /*string updateDate = "UPDATE `electiondb`.`vote` SET `datetimevoted` = STR_TO_DATE('"+dateVoted+"','%d/%m/%Y %H:%i:%s') WHERE (`voteID` = '" + voteDetails.Rows[0][0].ToString() + "');";
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

            string accessTimeInsert = "INSERT INTO `electiondb`.`accesstime` (`accessTime`, `accessName`, `accessDate`) VALUES ('"+accessTime.ToString()+"', '"+status+" votes for voter: "+voterID+"', now());";
            conn.Open();
            comm = new MySqlCommand(accessTimeInsert, conn);
            comm.ExecuteNonQuery();
            conn.Close();


            t.Stop();

            return success;
        }

        private void syncVotesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Votes checked and synced.", "Synced", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sf.Close();
        }

        private void btn_testSpeed_Click(object sender, EventArgs e)
        {
            sf = new SyncingForm();
            sf.Show();

            int i = 0;

            testReadSpeedWorker.RunWorkerAsync();
            i++;

        }

        int totalAccessTime = 0;

        System.Timers.Timer ti;
        private void testReadSpeedWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            totalAccessTime = 0;

            ti = new System.Timers.Timer(1000);
            ti.Enabled = true;
            //ti.Interval = 1000;
            ti.Elapsed += T_Elapsed1;
            ti.Start();            

            DataTable districts = new DataTable();
            string getDistrict = "SELECT districtID, cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(districtContractAddress, ':', -1)), CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(districtContractAddress, ':', 1))) as char) FROM electiondb.district;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(getDistrict, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(districts);
            conn.Close();

            DataTable voterCount = new DataTable();
            string countVoters = "SELECT count(*) FROM electiondb.vote;";
            conn.Open();
            comm = new MySqlCommand(countVoters, conn);
            adp = new MySqlDataAdapter(comm);
            adp.Fill(voterCount);
            conn.Close();

            foreach (DataRow districtRow in districts.Rows)
            {
                DataTable voters = new DataTable();
                string getVoters = "SELECT voterID FROM electiondb.voter where districtID = "+districtRow.ItemArray[0].ToString()+";";
                conn.Open();
                comm = new MySqlCommand(getVoters, conn);
                adp = new MySqlDataAdapter(comm);
                adp.Fill(voters);
                conn.Close();

                int votercount = int.Parse(voterCount.Rows[0][0].ToString());
                double votercountPercent = 0;

                foreach (DataRow voterRow in voters.Rows)
                {
                    testReadSpeed(voterRow.ItemArray[0].ToString(), districtRow.ItemArray[1].ToString()).Wait();

                    votercountPercent += (1.0 / votercount) * 100;

                    if (votercountPercent > 100)
                    {
                        votercountPercent = 100;
                    }

                    sf.progressBar1.Invoke(new MethodInvoker(delegate { sf.progressBar1.Value = int.Parse(Math.Truncate(votercountPercent).ToString()); }));                    
                }
            }
        }

        private void T_Elapsed1(object sender, System.Timers.ElapsedEventArgs e)
        {
            totalAccessTime++;
            //throw new NotImplementedException();
        }

        
        private async Task testReadSpeed(string voterID, string districtContractAddress)
        {
            accessTime = 0;                 

            string status = "Reading";

            string keyString = privateKey.Substring(2, 4) + privateKey.Substring(privateKey.Length - 4, 4);
            var theContract = web3.Eth.GetContract(getContractABI(), getContractAddress());
            var getVotesFunction = theContract.GetFunction("VoteDetails_district");

            Bytes32TypeEncoder encoder = new Bytes32TypeEncoder();
            var byte_voter = encoder.Encode(voterID.ToString());
            byte[] byte_key = encoder.Encode(keyString);

            System.Timers.Timer t = new System.Timers.Timer();
            t.Enabled = true;
            t.Interval = 1;
            t.Elapsed += T_Elapsed;
            t.Start();            

            var syncVotes = await getVotesFunction.CallDeserializingToObjectAsync<VoteDetailsDTO.VoteDetailsOutputDTO>(districtContractAddress, byte_voter, byte_key);

            t.Stop();

            string accessTimeInsert = "INSERT INTO `electiondb`.`accesstime` (`accessTime`, `accessName`, `accessDate`) VALUES ('" + accessTime.ToString() + "', '" + status + " votes for voter: " + voterID + "', now());";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(accessTimeInsert, conn);
            comm.ExecuteNonQuery();
            conn.Close();

        }

        private void testReadSpeedWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ti.Stop();

            DataTable voterCount = new DataTable();
            string countVoters = "SELECT count(*) FROM electiondb.vote;";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(countVoters, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(voterCount);
            conn.Close();

            string accessTimeInsert = "INSERT INTO `electiondb`.`accesstime` (`accessTime`, `accessName`, `accessDate`) VALUES ('" + totalAccessTime.ToString() + "', 'TOTAL ACCESS TIME (seconds) for reading " + voterCount.Rows[0][0].ToString() + " votes', now());";
            conn.Open();
            comm = new MySqlCommand(accessTimeInsert, conn);
            comm.ExecuteNonQuery();
            conn.Close();

            sf.Close();
        }
    }
}
