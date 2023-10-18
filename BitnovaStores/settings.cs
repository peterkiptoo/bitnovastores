using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitnovaStores
{
    public partial class settings : Form
    {
        MySqlConnection cn = new MySqlConnection("datasource=localhost;port=3306;username=root;Initial Catalog=bitnovastores;Integrated Security=false");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand cm = new MySqlCommand();
        DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public settings()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.png)|*.png|(*.jpg)|*.jpg*";
            openFileDialog1.ShowDialog();
            picIcon.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                picIcon.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arrImage = ms.GetBuffer();
                cn.Open();
                cm = new MySqlCommand("insert into company(name,email,regno,icon)values(@name,@email,@regno,@icon)", cn);
                cm.Parameters.AddWithValue("@name", txtName.Text);
                cm.Parameters.AddWithValue("@email", txtEmail.Text);
                cm.Parameters.AddWithValue("@regno", txtReg.Text);             
                cm.Parameters.AddWithValue("@icon", arrImage);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Saved Successfully");
                GetRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fields should not be Empty!" + ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void GetRecords()
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from company", cn);
            adapter.Fill(ds, "company");
            dataGridViewCompany.DataSource = ds;
            dataGridViewCompany.DataMember = "company";
            cn.Close();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridViewCompany.CurrentRow.Index;
            ds = new DataSet();
            adapter = new MySqlDataAdapter("delete from company where id=" + dataGridViewCompany[0, 0].Value.ToString(), cn);
            adapter.Fill(ds, "company");
            lblId.Text = "";
            GetRecords();
            cn.Close();
        }
    }
}
