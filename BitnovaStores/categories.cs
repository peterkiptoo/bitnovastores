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
    public partial class categories : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
       
        public categories()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("select name from categories where name='" + txtCatName.Text + "'", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (txtCatName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Field cannot be Empty!");
                return;
            }
            else if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Category Already Exists!");
                return;
            }
            else
                ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into categories(name) VALUES('" + txtCatName.Text + "')", con);
            adapter.Fill(ds, "categories");
            MessageBox.Show("Added Successfully!");
            txtCatName.Clear();
            GetRecords();
            con.Close();
        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from categories", con);
            adapter.Fill(ds, "categories");
            dataGridViewCat.DataSource = ds;
            dataGridViewCat.DataMember = "categories";
            con.Close();
        }

        private void categories_Load(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i = dataGridViewCat.CurrentRow.Index;
            lblId.Text = dataGridViewCat[0, i].Value.ToString();
            txtCatName.Text = dataGridViewCat[1, i].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("update categories set name = '" + txtCatName.Text + "' where id =" + lblId.Text, con);
            adapter.Fill(ds, "categories");
            txtCatName.Clear();
            lblId.Text = "";
            GetRecords();
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = dataGridViewCat.CurrentRow.Index;
            ds = new DataSet();
            adapter = new MySqlDataAdapter("delete from categories where id=" + dataGridViewCat[0, 0].Value.ToString(), con);
            adapter.Fill(ds, "categories");
            txtCatName.Clear();
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
            print.AddString("<h3>Categories</h3>");
            print.AddHorizontalRule();
            print.AddDatagridView(dataGridViewCat);
            print.ShowPrintPreviewDialog();
        }
    }
}
