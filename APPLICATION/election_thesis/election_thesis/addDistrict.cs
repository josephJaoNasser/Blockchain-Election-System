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
using System.Numerics;
using Nethereum.ABI.Encoders;
using election_thesis.Properties;

namespace election_thesis
{
    public partial class addDistrict : Form
    {
        MySqlConnection conn;
        admin mainAdmin;
        public addDistrict(admin a)
        {
            InitializeComponent();
            conn = new MySqlConnection(Settings.Default.connstring);
            mainAdmin = a;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addDistrict_Load(object sender, EventArgs e)
        {
            privateKey = "0x" + Settings.Default.privateKey;

            account = new Account(privateKey);
            web3 = new Web3(account, url);
            
            loadTables();
        }

        private void loadTables()
        {
            DataTable nullDistrict = new DataTable();
            DataTable notNullDistrict = new DataTable();

            string nullDistrictQuery = "SELECT districtID, districtName as 'District Name', address as 'District Address' " +
                "FROM electiondb.district where districtContractAddress is null";

            string notNullDistrictQuery = "SELECT districtID, districtName as 'District Name', address as 'District Address' " +
                "FROM electiondb.district where districtContractAddress is not null";

            conn.Open();

            MySqlCommand comm = new MySqlCommand(nullDistrictQuery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(nullDistrict);

            comm = new MySqlCommand(notNullDistrictQuery, conn);
            adp = new MySqlDataAdapter(comm);
            adp.Fill(notNullDistrict);

            conn.Close();

            dt_notNullDistrict.DataSource = notNullDistrict;
            dt_nullDistrict.DataSource = nullDistrict;

            dt_notNullDistrict.Columns["districtID"].Visible = false;
            dt_nullDistrict.Columns["districtID"].Visible = false;
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
        static Nethereum.Hex.HexTypes.HexBigInteger gasLimit = new Nethereum.Hex.HexTypes.HexBigInteger(1000000);
        static Nethereum.Hex.HexTypes.HexBigInteger gasPrice = new Nethereum.Hex.HexTypes.HexBigInteger(8000000000);

        //the loading screen
        ProcessingTransaction pt;

        //Get the address of the active election contract
        private string getContractAddress()
        {
            DataTable contract = new DataTable();

            conn.Open();
            string selectContract = "select cast(AES_DECRYPT(UNHEX(SUBSTRING_INDEX(contractAddress, ':', -1)), " +
                "CONCAT('XwncLQ=dbd#qLB3p', SUBSTRING_INDEX(contractAddress, ':', 1))) as char) from smartcontracts where active=1";
            MySqlCommand comm = new MySqlCommand(selectContract, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            adp.Fill(contract);
            conn.Close();

            string contractAddress = contract.Rows[0][0].ToString();

            return contractAddress;
        }
        //Get the ABI of the active election contract
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

        public async Task<bool> deployDistrictBallot()
        {
            bool success = false;

            try
            {
                MySqlCommand comm;

                //access ui elements from Task. Source of code: https://stackoverflow.com/questions/11109042/getting-the-text-in-a-richtextbox-thats-on-another-thread
                var districtID = (string)dt_nullDistrict.Invoke(new Func<string>(() => dt_nullDistrict.Rows[selectedIndex].Cells["districtID"].Value.ToString()));
                var districtName = (string)dt_nullDistrict.Invoke(new Func<string>(() => dt_nullDistrict.Rows[selectedIndex].Cells["District Name"].Value.ToString()));                

                //blockchain interactions 
                string districtKey = "0x" + txt_districtKey.Text;
                Account sub_account = new Account(districtKey);
                string districtKeyString = districtKey.Substring(2, 4) + districtKey.Substring(districtKey.Length - 4, 4);
                string keyString = privateKey.Substring(2, 4) + privateKey.Substring(privateKey.Length - 4, 4);

                Bytes32TypeEncoder encoder = new Bytes32TypeEncoder();
                byte[] districtIDbyte = encoder.Encode(districtID);
                byte[] byte_keyString = encoder.Encode(keyString);
                byte[] byte_districtKeyString = encoder.Encode(districtKeyString);

                var theContract = web3.Eth.GetContract(getContractABI(), getContractAddress());
                var spawnBallotFunction = theContract.GetFunction("spawn_ballot");
                var getChildContract = theContract.GetFunction("getDeployedChildContracts");

                var spawnBallot = await spawnBallotFunction.SendTransactionAndWaitForReceiptAsync(account.Address, gasLimit, 
                    gasPrice,null, null,districtID, byte_districtKeyString, byte_keyString);

                var ballotAddress = await getChildContract.CallAsync<string>(byte_keyString);

                MessageBox.Show("Contract for "+ districtName + " has been deployed successfully!");

                //store into the database
                //random string for the salt source:https://www.dotnetperls.com/random-string
                string salt = RandomString.GetRandomString();
                string contractAddressEncryption = "CONCAT('" + salt + "', ':', HEX(AES_ENCRYPT('" + ballotAddress + "', CONCAT('XwncLQ=dbd#qLB3p', '" + salt + "'))))";
                string contractKeyEncryption = "CONCAT('" + salt + "', ':', HEX(AES_ENCRYPT('" + txt_districtKey.Text + "', CONCAT('XwncLQ=dbd#qLB3p', '" + salt + "'))))";

                string listContract = "UPDATE `electiondb`.`district` SET `districtContractAddress` = "+ contractAddressEncryption + ", `salt` ='"+ salt +"'," +
                    "`deploymentcost` = '"+ spawnBallot.GasUsed.ToString() + " wei', `districtAccountKey` = "+ contractKeyEncryption + "  WHERE (`districtID` = '" + districtID+"');";
                conn.Open();
                comm = new MySqlCommand(listContract, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                success = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("The following error has occured: " + ex.Message, "An error has occured...", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                success = false;
            }


            return success;
        }

        private void btn_setAddress_Click(object sender, EventArgs e)
        {
            if(txt_districtKey.Text.Length < 1)
            {
                MessageBox.Show("Please enter the pravate key for this district's account");
            }
            else
            {
                DialogResult dr = MessageBox.Show("A ballot that will gather all the votes from this district will be deployed. Continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr.Equals(DialogResult.Yes))
                {
                    pt = new ProcessingTransaction();
                    pt.TopLevel = false;
                    pt.TopMost = true;
                    pt.FormClosed += ptClosed;
                    mainAdmin.panel_main.Controls.Add(pt);
                    this.Hide();
                    pt.Show();
                    deployDistrict.RunWorkerAsync();
                }
            }
            
        }

        private void ptClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        int selectedIndex = -1;
        private void dt_nullDistrict_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_deployDistrict.Text = "Deploy ballot contract for "+dt_nullDistrict.Rows[e.RowIndex].Cells["District Name"].Value.ToString();
            selectedIndex = e.RowIndex;

            if(!btn_deployDistrict.Enabled)
                btn_deployDistrict.Enabled = true;
        }

        private void deployDistrict_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = deployDistrictBallot().Result;
        }

        private void deployDistrict_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.Equals(true))
            {
                btn_deployDistrict.Enabled = false;
                txt_districtKey.Clear();
                loadTables();
            }

            pt.Close();
        }
    }
}
