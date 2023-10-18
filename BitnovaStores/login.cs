using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitnovaStores
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (lblStart.Text == "stopped")
            {
                Bunifu.MySQL.Stop();
                lblStart.Text = "Connection Stopped";
            }
            else
            {
                Bunifu.MySQL.Start();
                lblStart.Text = "started";
            }
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int i;
            i = 0;
           
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from users where username='" + txtUsername.Text + "' and password= MD5('" + txtPassword.Text + "')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Invalid Username or Password");
                con.Close();
                return;
            }
            else if (i == 1)
            {
                switch (dt.Rows[0]["role"] as string)
                {
                    case "Admin":
                        {
                           
                            Form1 f = new Form1();
                            f.lblUser.Text = txtUsername.Text;
                            f.Show();
                            con.Close();
                            this.Hide();
                            break;
                        }
                
                    default:
                        {
                            // ... handle unexpected roles here...
                            break;
                        }
                }

            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            if (lblStart.Text == "Database Connected")
            {
                Bunifu.MySQL.Stop();
                lblStart.Text = "Connection Stopped";
            }
            else
            {
                Bunifu.MySQL.Start();
                lblStart.Text = "Database Connected on Port 3306";
            }
        }
    }
}
