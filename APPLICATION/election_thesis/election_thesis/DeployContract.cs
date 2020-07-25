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
using Nethereum.ABI.Encoders;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Extensions;
using System.Numerics;
using System.IO;
using MySql.Data.MySqlClient;
using election_thesis.Properties;

namespace election_thesis
{
    public partial class DeployContract : Form
    {
        string adminID;
        admin mainAdmin;
        MySqlConnection conn;


        public DeployContract(string adminID, admin a)
        {
            InitializeComponent();
            conn = new MySqlConnection(Settings.Default.connstring);

            this.adminID = adminID;
            mainAdmin = a;
        }

        //blockchain account information
        static string url = "https://ropsten.infura.io/v3/ad6031e24d4d47f48077ab7d2ede7c67";
        static string privateKey;
        static Account account;
        Web3 web3;
        string contractAddress;

        private void DeployContract_Load(object sender, EventArgs e)
        {
            privateKey = "0x" + Settings.Default.privateKey;

            account = new Account(privateKey);
            web3 = new Web3(account, url);
        }
        

        //the loading screen
        ProcessingTransaction pt;

        private void btn_deployContract_Click(object sender, EventArgs e)
        {           
           
            if(txt_contractBytecode.TextLength < 1)
            {
                MessageBox.Show("Please enter a bytecode value!","Enter Bytecode", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else if (txt_contractName.TextLength < 1)
            {
                MessageBox.Show("Please enter the contract name!", "Enter Contract Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Contract will be deployed. Click OK to continue.", "Confirm Contract Deployment", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dr.Equals(DialogResult.OK))
                {
                    pt = new ProcessingTransaction();
                    pt.TopLevel = false;
                    pt.TopMost = true;
                    pt.FormClosed += ptClosed;
                    mainAdmin.panel_main.Controls.Add(pt);
                    this.Hide();
                    pt.Show();
                    backgroundWorker1.RunWorkerAsync();
                }               
            }
        }

        private void ptClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //async task that deploys the contract

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = deployContractTask().Result;
        }

        public async Task<bool> deployContractTask()
        {            
            string contractBytecode = txt_contractBytecode.Text;
            string contractABI = txt_contractABI.Text;

            string keyString = privateKey.Substring(2,4) + privateKey.Substring(privateKey.Length-4, 4);
            Bytes32TypeEncoder encoder = new Bytes32TypeEncoder();
            byte[] byte_key = encoder.Encode(keyString);

            bool success = false;

            try
            {               

                var contractDeployment = new ContractDeployer(txt_contractBytecode.Text)
                {                    
                    _key = byte_key
                };

                var deploymentHandler = web3.Eth.GetContractDeploymentHandler<ContractDeployer>();
                var deploy = await deploymentHandler.SendRequestAndWaitForReceiptAsync(contractDeployment);
                contractAddress = deploy.ContractAddress;

                MessageBox.Show("Contract deployed successfully!", "Contract Deployed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //random string for the salt source:https://www.dotnetperls.com/random-string
                string salt = RandomString.GetRandomString();
                string contractAddressEncryption = "CONCAT('" + salt + "', ':', HEX(AES_ENCRYPT('"+contractAddress+"', CONCAT('XwncLQ=dbd#qLB3p', '" + salt + "'))))";

                 
                //Store contract address into the database
                string listContract = "INSERT INTO `electiondb`.`smartcontracts` (`contractAddress`, `contractABI`, `contractName`, `deployedBy`,`deployDate`,`salt`,`deploymentcost`) VALUES" +
                " ("+contractAddressEncryption+", '" + contractABI + "' , '" + txt_contractName.Text + "', '" + adminID + "', now(),'"+salt+"','"+ deploy.GasUsed.ToString() + " wei');";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(listContract, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error has occured: " + ex.Message, "An error has occured...", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);

                success = false;

            }

            return success;
        }

      

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.Equals(true))
            {
                txt_contractABI.Clear();
                txt_contractBytecode.Clear();
                txt_contractName.Clear();
            }

            pt.timer1.Stop();
            pt.Close();
        }

        private void txt_contractName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txt_contractBytecode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

       
    }
}
