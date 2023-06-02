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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-76I04D2\\SQLEXPRESS;Database=StokTakip;Integrated Security=true");

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Kullanici where KullaniciAd=@KullaniciAd and Sifre=@Sifre", conn);
            
            cmd.Parameters.AddWithValue("@KullaniciAd", textBox1.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox2.Text);
            
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                AnaMenu go = new AnaMenu();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("başarısız");
                textBox1.Clear();
                textBox2.Clear();
            }
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Kullanici (KullaniciAd, Sifre) values (@KullaniciAd, @Sifre)", conn);
            cmd.Parameters.AddWithValue("@KullaniciAd", textBox4.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
