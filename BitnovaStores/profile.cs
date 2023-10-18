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
    public partial class profile : Form
    {
        public profile()
        {
            InitializeComponent();
        }

        private void profile_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            using (MySqlConnection AR = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false"))
            {
                AR.Open();
                String query = "SELECT email,role FROM users WHERE username='" + txtUser.Text + "'";
                using (MySqlCommand SDA = new MySqlCommand(query, AR))
                {
                    MySqlDataReader data = SDA.ExecuteReader();
                    if (data.Read())
                    {
                        txtEmail.Text = data.GetValue(0).ToString();
                        txtPassword.Text = data.GetValue(1).ToString();
                       
                    }
                }
                AR.Close();
            }
        }
    }
}
