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
using election_thesis.Properties;

namespace election_thesis
{
    public partial class setContractAddress : Form
    {
        MySqlConnection conn;
        public setContractAddress()
        {
            conn = new MySqlConnection(Settings.Default.connstring);
            InitializeComponent();
        }

        private void setContractAddress_Load(object sender, EventArgs e)
        {
            loadContracts();
        }

        private void loadContracts()
        {
            DataTable dt = new DataTable();

            string contractQuery = "SELECT contractName as 'Contract Name', deployDate as 'Date and Time Deployed', replace(replace(active,0,'Inactive'),1,'Set Active') as 'Status', contractID from smartcontracts order by deploydate desc";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(contractQuery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            adp.Fill(dt);

            dt_smartContractList.DataSource = dt;

            try
            {
                dt_smartContractList.CurrentRow.Selected = false;
            }
            catch
            {
                //do nothing
            }

            dt_smartContractList.Columns["contractID"].Visible = false;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dt_smartContractList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_address.Text = dt_smartContractList.Rows[e.RowIndex].Cells["Contract Name"].Value.ToString();
                index = e.RowIndex;
            }
               
        }

        int index = -1;
        private void btn_setAddress_Click(object sender, EventArgs e)
        {
            if(txt_address.TextLength > 0)
            {
                string setActive = "UPDATE `electiondb`.`smartcontracts` SET `active` = 0 WHERE (`active` = 1);" +
                "UPDATE `electiondb`.`smartcontracts` SET `active` = '1' WHERE (`contractID` = "+ dt_smartContractList.Rows[index].Cells["contractID"].Value.ToString() + ");";
                conn.Open();
                MySqlCommand comm = new MySqlCommand(setActive, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                loadContracts();

                MessageBox.Show("Active contract set.", "Set", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a contract address in the textbox provided, or click on one of the saved smart contracts.", "Please enter a contract address...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dt_smartContractList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dt_smartContractList.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "Inactive")
            {
                dt_smartContractList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PowderBlue;
                dt_smartContractList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            else if (dt_smartContractList.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "Set Active")
            {
                dt_smartContractList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                dt_smartContractList.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
    }
}
