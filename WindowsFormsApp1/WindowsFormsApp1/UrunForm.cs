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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class UrunForm : Form
    {
        public UrunForm()
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
            SqlCommand cmd = new SqlCommand("insert into Urun (UrunAd, Depo, Cins, Fiyat) values (@UrunAd, @Depo, @Cins, @Fiyat)", conn);
            cmd.Parameters.AddWithValue("@UrunAd", textBox2.Text);
            cmd.Parameters.AddWithValue("@Depo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Fiyat", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Urun");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Listele("select * from Urun");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Urun set UrunAd=@UrunAd, Depo=@Depo, Cins=@Cins, Fiyat=@Fiyat where BarkodNo=@BarkodNo", conn);
            cmd.Parameters.AddWithValue("@BarkodNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@UrunAd", textBox2.Text);
            cmd.Parameters.AddWithValue("@Depo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Fiyat", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Urun");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Urun where BarkodNo=@BarkodNo", conn);
            cmd.Parameters.AddWithValue("@BarkodNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Urun");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Urun where UrunAd like'%" + textBox2.Text + "%'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["BarkodNo"].Value.ToString();
            textBox2.Text = row.Cells["UrunAd"].Value.ToString();
            comboBox1.Text = row.Cells["Depo"].Value.ToString();
            comboBox2.Text = row.Cells["Cins"].Value.ToString();
            textBox3.Text = row.Cells["Fiyat"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaMenu menu = new AnaMenu();
            menu.Show();
            this.Hide();
        }

        private void UrunForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
