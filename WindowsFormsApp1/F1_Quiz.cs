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
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class F1_Quiz : Form
    {
        public F1_Quiz()
        {
            InitializeComponent();
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        sqlbaglantısı bgl = new sqlbaglantısı();
        public string kullaniciadi;
        int soruno=0, 
            dogru =0,
            yanlis = 0,
            bos = 0,
            puan=0;

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            if (soruno == 1 && radioButton1.Checked) // Lewis Hamilton
            {
                dogru++;
                puan += 10;
            }

            else if(soruno ==1 && !radioButton1.Checked)
            {
                radioButton1.BackColor = Color.Green;
            }

            if (soruno == 2 && radioButton2.Checked) // Red Bull
            {
                dogru++;
                puan += 10;
            }
            else if (soruno == 2 && !radioButton2.Checked)
            {
                radioButton2.BackColor = Color.Green;
            }

            if (soruno == 3 && radioButton3.Checked) // Max Verstappen
            {
                dogru++;
                puan += 10;
            }

            else if (soruno == 3 && !radioButton3.Checked)
            {
                radioButton3.BackColor = Color.Green;
            }

            if (soruno == 4 && radioButton3.Checked) // Max Verstappen
            {
                dogru++;
                puan += 10;
            }

            else if (soruno == 4 && !radioButton3.Checked)
            {
                radioButton3.BackColor = Color.Green;
            }

            if (soruno == 5 && radioButton2.Checked) // Red Bull
            {
                dogru++;
                puan += 10;
            }

            else if (soruno == 5 && !radioButton3.Checked)
            {
                radioButton2.BackColor = Color.Green;
            }

            if (soruno == 6 && radioButton1.Checked) // Romain Grosjean
            {
                dogru++;
                puan += 10;
            }

            else if (soruno == 6 && !radioButton3.Checked)
            {
                radioButton1.BackColor = Color.Green;
            }

            if (soruno == 7 && radioButton2.Checked) // Mercedes
            {
                dogru++;
                puan += 10;
            }

            else if (soruno == 7 && !radioButton3.Checked)
            {
                radioButton2.BackColor = Color.Green;
            }

            if (soruno == 8 && radioButton2.Checked) // 2013
            {
                dogru++;
                puan += 10;
            }

            else if (soruno == 8 && !radioButton3.Checked)
            {
                radioButton2.BackColor = Color.Green;
            }

            if (soruno == 9 && radioButton1.Checked) // Le Mans
            {
                dogru++;
                puan += 10;
            }

            else if (soruno == 9 && !radioButton3.Checked)
            {
                radioButton1.BackColor = Color.Green;
            }

            if (soruno == 10 && radioButton1.Checked) // 1993
            {
                dogru++;
                puan += 10;
            }

            else if (soruno == 10 && !radioButton3.Checked)
            {
                radioButton1.BackColor = Color.Green;
   
            }

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                bos++;
                lblBos.Text = bos.ToString();
            }
            else if (
                !( (soruno == 1 && radioButton1.Checked) ||
                   (soruno == 2 && radioButton2.Checked) ||
                   (soruno == 3 && radioButton3.Checked) ||
                   (soruno == 4 && radioButton3.Checked) ||
                   (soruno == 5 && radioButton2.Checked) ||
                   (soruno == 6 && radioButton1.Checked) ||
                   (soruno == 7 && radioButton2.Checked) ||
                   (soruno == 8 && radioButton2.Checked) ||
                   (soruno == 9 && radioButton1.Checked) ||
                   (soruno == 10 && radioButton1.Checked)
                )
            )
            {
                yanlis++;
                lblYanlis.Text = yanlis.ToString();
            }

            // Cevap kontrolünden sonra butonları devre dışı bırak
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            btnKontrol.Enabled = false;

            // Sonuçları labellara yaz
            lblDogru.Text = dogru.ToString();
            lblYanlis.Text = yanlis.ToString();
            lblBos.Text = bos.ToString();
            lblPuan.Text = puan.ToString();

        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quiz Bitti!\n\nDoğru Cevap Sayısı: " + dogru + "\nYanlış Cevap Sayısı: " + yanlis + "\nBoş Bırakılan Soru Sayısı: " + bos + "\nToplam Puan: " + puan, "Quiz Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Quiz sonuçlarını veritabanına kaydet
            SqlCommand komut = new SqlCommand("insert into Denemeler (KullaniciAdi,DogruSayisi,YanlisSayisi,Puan,DenemeTarihi) values (@kad,@p1,@p2,@p3,@p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@kad", kullaniciadi);
            komut.Parameters.AddWithValue("@p1", dogru);
            komut.Parameters.AddWithValue("@p2", yanlis);
            komut.Parameters.AddWithValue("@p3", puan);
            komut.Parameters.AddWithValue("@p4", DateTime.Now);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {

            btnBaslat.Text = "Sonraki Soru";
            soruno++;
            btnKontrol.Enabled = true;
            btnBitir.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;

            if (soruno == 1)
            {
                richTextBox1.Text = "Schmaucher ile birlikte 7 kez dünya şampiyonu olan efsane pilot aşağıdakilerden hangisidir?";
                radioButton1.Text = "Lewis Hamilton";
                radioButton2.Text = "Sebastian Vettel";
                radioButton3.Text = "Max Verstappen";
                radioButton4.Text = "Ayrton Senna";

            }

            if (soruno == 2)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "2024 Formula 1 sezonunun şampiyonu hangi takımdır?";
                radioButton1.Text = "Ferrari";
                radioButton2.Text = "Red Bull";
                radioButton3.Text = "Alfa Romeo";
                radioButton4.Text = "McLaren";
            }

            if (soruno == 3)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "2024 Formula 1 sezonunun en çok pole pozisyonu alan pilotu kimdir?";
                radioButton1.Text = "Lewis Hamilton";
                radioButton2.Text = "Charles Leclerc";
                radioButton3.Text = "Max Verstappen";
                radioButton4.Text = "Sergio Perez";
            }

            if (soruno == 4)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "2024 Formula 1 sezonunun en çok yarış kazanan pilotu kimdir?";
                radioButton1.Text = "Lewis Hamilton";
                radioButton2.Text = "Charles Leclerc";
                radioButton3.Text = "Max Verstappen";
                radioButton4.Text = "Sergio Perez";
            }

            if (soruno == 5)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "2024 Formula 1 sezonunun en çok yarış kazanan takımı kimdir?";
                radioButton1.Text = "Ferrari";
                radioButton2.Text = "Red Bull";
                radioButton3.Text = "Alfa Romeo";
                radioButton4.Text = "McLaren";
            }

            if (soruno == 6)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "Geçirdiği kaza ile yangınların arasından çıkan ve bir süre yarışlardan uzak kaldıktan sonra geri dönen F1 pilotu kimdir?";
                radioButton1.Text = "Romain Grosjean";
                radioButton2.Text = "Kevin Magnussen";
                radioButton3.Text = "Daniel Ricciardo";
                radioButton4.Text = "Lando Norris";
            }

            if (soruno == 7)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "Gümüş oklar adıyla da anılan takım hangisidir?";
                radioButton1.Text = "Ferrari";
                radioButton2.Text = "Mercedes";
                radioButton3.Text = "Alfa Romeo";
                radioButton4.Text = "McLaren";
            }

            if (soruno == 8)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "Formula 1’de “DRS” (Drag Reduction System) hangi yıl resmi olarak kullanılmaya başlandı?";
                radioButton1.Text = "2005";
                radioButton2.Text = "2013";
                radioButton3.Text = "1984";
                radioButton4.Text = "1999";
            }

            if (soruno == 9)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "Aşağıdaki pistlerden hangisinde F1 yarışı hiç düzenlenmemiştir?";
                radioButton1.Text = "Le Mans";
                radioButton2.Text = "Silverstone";
                radioButton3.Text = "Monaco";
                radioButton4.Text = "İmola";
            }

            if (soruno == 10)
            {
                radioButton1.BackColor = Color.Transparent;
                radioButton2.BackColor = Color.Transparent;
                radioButton3.BackColor = Color.Transparent;
                radioButton4.BackColor = Color.Transparent;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                richTextBox1.Text = "Formula 1’de “Safety Car” (Güvenlik Aracı) ilk kez hangi yıl kullanıldı?";
                radioButton1.Text = "1993";
                radioButton2.Text = "2000";
                radioButton3.Text = "1985";
                radioButton4.Text = "1996";

                btnBaslat.Enabled = false; // Son soru için butonu devre dışı bırak
            }  
            lblSoruSayisi.Text = soruno.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void F1_Quiz_Load(object sender, EventArgs e)
        {
            lblAdSoyad.Text = kullaniciadi;
            MessageBox.Show("Quiz'e Hoş Geldiniz " + kullaniciadi + "!\n\nQuiz sonunda doğru cevap sayınız, yanlış cevap sayınız, boş bıraktığınız soru sayınız ve toplam puanınız gösterilecektir. Soruları kontrol tuşuna basmadan geçmeyiniz.", "Hoş Geldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //AD SOYAD ÇEKME
            SqlCommand komut = new SqlCommand("Select KullaniciAdi from Kullanicilar where KullaniciAdi=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblAdSoyad.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) 
            {
                lblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

        }
        
    }
}
