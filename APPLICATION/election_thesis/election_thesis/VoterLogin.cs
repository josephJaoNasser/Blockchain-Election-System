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
    public partial class VoterLogin : Form
    {    
        string precinctID = Settings.Default.precinctID.ToString();
        string districtID = Settings.Default.districtID.ToString();

        MySqlConnection conn;
        public VoterLogin()
        {
            InitializeComponent();
            conn = new MySqlConnection(Settings.Default.connstring);
        }

        private void VoterLogin_Load(object sender, EventArgs e)
        {
            string loadDistrictQuery = "Select districtID, districtName as 'District', address as 'District Adress' from district where districtID = " + districtID;
            conn.Open();
            MySqlCommand comm = new MySqlCommand(loadDistrictQuery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            DataTable dt = new DataTable();
            adp.Fill(dt);

            lbl_district.Text = dt.Rows[0][1].ToString() + ", " + dt.Rows[0][2].ToString();

            conn.Open();
            string loadPrecinctQuery = "select precinctID, precinctName, address from precinct where precinctID = " +precinctID+";";
            comm = new MySqlCommand(loadPrecinctQuery, conn);
            adp = new MySqlDataAdapter(comm);
            conn.Close();

            dt = new DataTable();
            adp.Fill(dt);

            lbl_precinct.Text = dt.Rows[0][1].ToString() + ", " + dt.Rows[0][2].ToString();
            
        }

        private void btn_start_Click(object sender, EventArgs e)
        {     
            DataTable dt = new DataTable();
            string selectVoter = "SELECT voterID, districtID, precinctID, concat(firstname, ' ',middlename,' ',lastname), " +
                "voterStatus FROM electiondb.voter where concat(voterid,substring(middlename,1,1)) ='"+FromHexString(txt_loginCode.Text)+"' and " +
                "voterPassword = sha2(concat('"+txt_password.Text+"',(SELECT salt FROM electiondb.voter where concat(voterid,substring(middlename,1,1)) ='"+ 
                FromHexString(txt_loginCode.Text) + "')),512)";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(selectVoter,conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();

            adp.Fill(dt);

            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Voter does not exist! Please check your code or password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dt.Rows[0][4].ToString() == "1")
                {
                    MessageBox.Show("Sorry, you have already casted your vote", "Already voted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_loginCode.Clear();
                    txt_password.Clear();
                }
                else if((dt.Rows[0][1].ToString() == districtID) && (dt.Rows[0][2].ToString() == precinctID))
                {
                    string voterName = dt.Rows[0][3].ToString();
                    string voterID = dt.Rows[0][0].ToString();
                    VotingForm vf = new VotingForm(voterID, voterName, districtID);
                    vf.FormClosed += vfClosed;
                    vf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You are voting in the wrong precinct. Please vote at a precinct that you are " +
                        "registered in!", "Wrong precinct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void vfClosed(object sender, EventArgs e)
        {
            this.Show();
            txt_loginCode.Clear();
            txt_password.Clear();
        }

        //convert hex string back to byte array source: https://stackoverflow.com/questions/311165/how-do-you-convert-a-byte-array-to-a-hexadecimal-string-and-vice-versa
        //convert byte array to text: https://stackoverflow.com/questions/1003275/how-to-convert-utf-8-byte-to-string
        public static string FromHexString(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            if(NumberChars % 2 == 0)
            {
                for (int i = 0; i < NumberChars; i += 2)
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            else
            {
                MessageBox.Show("Invalid login code. Check your code and try again.", "Invalid code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            return System.Text.Encoding.UTF8.GetString(bytes); ;
        }

        private void txt_loginCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void VoterLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
