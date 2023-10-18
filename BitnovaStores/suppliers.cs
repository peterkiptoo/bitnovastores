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
    public partial class suppliers : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public suppliers()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("select email from suppliers where email='" + txtEmail.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (txtEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("Field cannot be Empty!");
                return;
            }
            else if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Supplier Already Exists!");
                return;
            }
            else
                ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into suppliers(name,email,commodity,phone) VALUES('" + txtName.Text + "','" + txtEmail.Text + "','" + txtCommodity.Text + "','" + txtPhone.Text + "')", con);
            adapter.Fill(ds, "suppliers");
            MessageBox.Show("Added Successfully!");
            //txtEmail.Clear();
            GetRecords();
            con.Close();
        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from suppliers", con);
            adapter.Fill(ds, "suppliers");
            dataGridViewSupp.DataSource = ds;
            dataGridViewSupp.DataMember = "suppliers";
            con.Close();
        }

        private void suppliers_Load(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i = dataGridViewSupp.CurrentRow.Index;
            lblId.Text = dataGridViewSupp[0, i].Value.ToString();
            txtCommodity.Text = dataGridViewSupp[3, i].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("update suppliers set commodity = '" + txtCommodity.Text + "' where id =" + lblId.Text, con);
            adapter.Fill(ds, "suppliers");
            txtCommodity.Clear();
            lblId.Text = "";
            GetRecords();
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = dataGridViewSupp.CurrentRow.Index;
            ds = new DataSet();
            adapter = new MySqlDataAdapter("delete from suppliers where id=" + dataGridViewSupp[0, 0].Value.ToString(), con);
            adapter.Fill(ds, "suppliers");
            txtCommodity.Clear();
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
            print.AddString("<h3>Suppliers</h3>");
            print.AddHorizontalRule();
            print.AddDatagridView(dataGridViewSupp);
            print.ShowPrintPreviewDialog();
        }
    }
}
