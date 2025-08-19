using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class F1_Kayit : Form
    {
        public F1_Kayit()
        {
            InitializeComponent();
        }

        sqlbaglantısı bgl = new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Kullanicilar (KullaniciAdi, KullaniciSifresi) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);

            string sorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi=@kadi";
            SqlCommand komut2 = new SqlCommand(sorgu, bgl.baglanti());
            komut2.Parameters.AddWithValue("@kadi", txtKullaniciAdi.Text);
            int sorgu2 = (int)komut2.ExecuteScalar();

            if (sorgu2 > 0)
            {
                MessageBox.Show("Bu kullanıcı adı zaten alınmış!","HATA", MessageBoxButtons.OK);
            }
            else
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt başarılı!", "Bilgi", MessageBoxButtons.OK);
                this.Hide();
            }
            bgl.baglanti().Close();
        }
    }
}
