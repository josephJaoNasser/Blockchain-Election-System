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
    public partial class loginForm : Form
    {
        MySqlConnection conn;
        public loginForm()
        {
            InitializeComponent();
            conn = new MySqlConnection(Settings.Default.connstring);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            conn.Open();
            string loginQuery = "SELECT * FROM electiondb.admin as ad where ad.username = '"+ txt_username.Text + "' and ad.password = sha2(concat('"+txt_password.Text+"',(select salt from electiondb.admin where username = '"+txt_username.Text+"')),512);";
            MySqlCommand comm = new MySqlCommand(loginQuery,conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
           adp.Fill(dt);
            conn.Close();

            if(dt.Rows.Count == 1)
            {
                MessageBox.Show("Welcome " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString() + "!");
                admin ad = new admin(dt.Rows[0][0].ToString(),this);
                txt_username.Clear();
                txt_password.Clear();
                ad.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect...");
            }
        }

        private void txt_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txt_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
    }
}
