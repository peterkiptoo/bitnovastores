using KimToo;
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
    public partial class users : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public users()
        {
            InitializeComponent();
        }

        private void users_Load(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("select email from users where email='" + txtEmail.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Field cannot be Empty!");
                return;
            }
            else if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("User Already Exists!");
                return;
            }
            else
                ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into users(username,email,role,password) VALUES('" + txtName.Text + "','" + txtEmail.Text + "','" + drpRole.Text + "','" + Program.CalculateMD5Hash(txtPassword.Text) + "')", con);
            adapter.Fill(ds, "users");
            MessageBox.Show("Added Successfully!");
            txtName.Text = txtEmail.Text = drpRole.Text = txtPassword.Text = "";
            GetRecords();
            con.Close();
        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select id,username,email,role from users", con);
            adapter.Fill(ds, "users");
            dataGridViewUsers.DataSource = ds;
            dataGridViewUsers.DataMember = "users";
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("update users set username = '" + txtName.Text + "' where id =" + lblId.Text, con);
            adapter.Fill(ds, "users");
            txtName.Text=txtEmail.Text=drpRole.Text=txtPassword.Text="";
            lblId.Text = "";
            GetRecords();
            con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i = dataGridViewUsers.CurrentRow.Index;
            lblId.Text = dataGridViewUsers[0, i].Value.ToString();
            txtName.Text = dataGridViewUsers[1, i].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = dataGridViewUsers.CurrentRow.Index;
            ds = new DataSet();
            adapter = new MySqlDataAdapter("delete from users where id=" + dataGridViewUsers[0, 0].Value.ToString(), con);
            adapter.Fill(ds, "users");
            txtName.Clear();
            lblId.Text = "";
            GetRecords();
            con.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            EasyHTMLReports print = new EasyHTMLReports();
            print.AddLineBreak();
            print.HeaderBackgroundColor = Color.Maroon;
            print.AddString("<h2>Bitnova Stores</h2>");
            print.AddLineBreak();
            print.AddString("<h3>Users</h3>");
            print.AddHorizontalRule();
            print.AddDatagridView(dataGridViewUsers);
            print.ShowPrintPreviewDialog();
        }
    }
}
