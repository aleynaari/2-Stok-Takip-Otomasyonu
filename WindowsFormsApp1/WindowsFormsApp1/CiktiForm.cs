using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CiktiForm : Form
    {
        public CiktiForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-76I04D2\\SQLEXPRESS;Database=StokTakip;Integrated Security=true");
        public void Listele(string baglan)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(baglan, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into CiktiUrun (BarkodNo, Cins, CiktiAdet, CiktiTarih) values (@BarkodNo, @Cins, @CiktiAdet, @CiktiTarih)", conn);
            cmd.Parameters.AddWithValue("@BarkodNo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox2.Text);
            cmd.Parameters.AddWithValue("@CiktiAdet", textBox2.Text);
            cmd.Parameters.AddWithValue("@CiktiTarih", Convert.ToDateTime(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from CiktiUrun");
        }

        private void CiktiForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select*From Urun", conn);
            conn.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["BarkodNo"]);
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from CiktiUrun where CIslemNo=@CIslemNo", conn);
            cmd.Parameters.AddWithValue("@CIslemNo", comboBox1.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from CiktiUrun");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update CiktiUrun set BarkodNo=@BarkodNo, Cins=@Cins, CiktiAdet=@CiktiAdet, CiktiTarih=@CiktiTarih where CIslemNo=@CIslemNo", conn);
            cmd.Parameters.AddWithValue("@CIslemNo", comboBox1.Tag);
            cmd.Parameters.AddWithValue("@BarkodNo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox2.Text);
            cmd.Parameters.AddWithValue("@CiktiAdet", textBox2.Text);
            cmd.Parameters.AddWithValue("@CiktiTarih", Convert.ToDateTime(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from CiktiUrun");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from CiktiUrun where BarkodNo like'%" + comboBox1.Text + "%'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            comboBox1.Tag = row.Cells["CIslemNo"].Value.ToString();
            comboBox1.Text = row.Cells["BarkodNo"].Value.ToString();
            comboBox2.Text = row.Cells["Cins"].Value.ToString();
            textBox2.Text = row.Cells["CiktiAdet"].Value.ToString();
            dateTimePicker1.Text = row.Cells["CiktiTarih"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Listele("select * from CiktiUrun");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaMenu menu = new AnaMenu();
            menu.Show();
            this.Hide();
        }
    }
}
