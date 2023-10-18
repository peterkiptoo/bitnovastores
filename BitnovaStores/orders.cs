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
    public partial class orders : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public orders()
        {
            InitializeComponent();
        }

        private void orders_Load(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                            
                ds = new DataSet();
                adapter = new MySqlDataAdapter("insert into orders(name,qty,category,supplier,tdate,status) VALUES('" + txtName.Text + "','" + txtQty.Text + "','" +txtCat.Text + "','" + txtSupplier.Text + "','" + DateTime.Now.ToString("yyyyMMdd") + "','live')", con);
                adapter.Fill(ds, "receivedstock");
                con.Close();
                GetRecords();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from orders", con);
            adapter.Fill(ds, "orders");
            dataGridViewProduct.DataSource = ds;
            dataGridViewProduct.DataMember = "orders";
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("update orders set status = '" + drpStatus.Text + "' where id =" + lblId.Text, con);
            adapter.Fill(ds, "orders");
            //txtCommodity.Clear();
            lblId.Text = "";
            GetRecords();
            con.Close();
        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridViewProduct.CurrentRow.Index;
            lblId.Text = dataGridViewProduct[0, i].Value.ToString();
        }
    }
}
