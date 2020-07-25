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
    public partial class VotingConfig : Form
    {
        MySqlConnection conn;
        
        public VotingConfig()
        {            
            conn = new MySqlConnection(Settings.Default.connstring);
            InitializeComponent();
        }

        private void votingConfig_Load(object sender, EventArgs e)
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
            string loadPrecinctsQuery = "select p.precinctID, p.precinctName, p.address, p.districtID from precinct p join district d on p.districtID = d.districtID where d.districtID = " + districts.Rows[cmb_districts.SelectedIndex][0].ToString() + ";";
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
            cmb_precinct.Items.Clear();
            loadPrecinct();            
            cmb_precinct.Enabled = true;
        }

        private void btn_saveConfig_Click(object sender, EventArgs e)
        {
            Settings.Default.precinctID = int.Parse(precincts.Rows[cmb_precinct.SelectedIndex][0].ToString());
            Settings.Default.districtID = int.Parse(districts.Rows[cmb_districts.SelectedIndex][0].ToString());
            Settings.Default.configured = true;
            Settings.Default.Save();
            
            VoterLogin vl = new VoterLogin();
            vl.Show();
            this.Hide();
        }

        private void cmb_precinct_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_saveConfig.Enabled = true;
        }
    }
}
