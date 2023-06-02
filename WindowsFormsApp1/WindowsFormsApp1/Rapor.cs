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
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-76I04D2\\SQLEXPRESS;Database=StokTakip;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                SqlCommand cmd = new SqlCommand("select * from Urun where Cins='Süpürge' order by Fiyat asc", conn);
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (radioButton2.Checked==true)
            {
                SqlCommand cmd = new SqlCommand("select * from Urun where Cins='Televizyon' order by Fiyat asc", conn);
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select u.BarkodNo,u.UrunAd, u.Cins, " +
                " ISNULL (sum(g.GirdiAdet),0) as 'Girdi Adedi',  " +
                " ISNULL (sum(c.CiktiAdet),0) as 'Çıktı Adedi', " +
                " (ISNULL(g.GirdiAdet,0)- ISNULL(c.CiktiAdet,0)) as 'Güncel Stok'" +
                " from Urun u " +
                " left join GirdiUrun g on g.BarkodNo=u.BarkodNo" +
                " left join CiktiUrun c on g.BarkodNo=c.BarkodNo " +
                " group by u.BarkodNo,u.Cins, u.UrunAd, g.GirdiAdet, c.CiktiAdet ", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            dataGridView1.DataSource= ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaMenu menu = new AnaMenu();
            menu.Show();
            this.Hide();
        }
    }
}
