using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazlabProje1_
{
    public partial class Form5 : System.Windows.Forms.Form
    {
        Bitmap yedek;
        HistogramForm frm = new HistogramForm();
        Anasayfa giris = new Anasayfa();
        int kontrol = 0,x,y;
        public Form5()
        {
            InitializeComponent();
        }
        private void DosyaAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosyaac = new OpenFileDialog();
            dosyaac.Filter = "Photos|*.jpg|All Files|*.*";
            if (dosyaac.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            this.pictureBox1.Image = new Bitmap(dosyaac.OpenFile());
            if(pictureBox1.Image.Height > 550)
            {
                Bitmap yeniyukseklik = new Bitmap(pictureBox1.Image, pictureBox1.Image.Width, 550);
                pictureBox1.Image = yeniyukseklik;
            }
            if(pictureBox1.Image.Width >600)
            {
                Bitmap yenigenislik = new Bitmap(pictureBox1.Image, 600, pictureBox1.Image.Height);
                pictureBox1.Image = yenigenislik;
            }
            yedek = new Bitmap(pictureBox1.Image);
            kontrol = 1;
        }
        private void Sifirla_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null || kontrol == 0)
            {
                MessageBox.Show("Önce Bir resim Seçin");
            }
            else if(kontrol == 1)
            {
                pictureBox1.Image = yedek;
            }
        }
        private void Kaydet_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null || kontrol == 0)
            {
                MessageBox.Show("Kayıt Edilecek Resim Yok!");
            }
            else if(kontrol ==1)
            {
                SaveFileDialog dosyakaydet = new SaveFileDialog();
                dosyakaydet.Filter = "JPG|*.jpg|BMP|*.bmp";
                if (DialogResult.OK == dosyakaydet.ShowDialog())
                {
                    this.pictureBox1.Image.Save(dosyakaydet.FileName);
                }
            }
        }
        private void SolaDondume_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Bir resim Seçin");
            }
            else
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap sol = SolaDondur(image);
                pictureBox1.Image = sol;
            }
        }
        private void SagaDondurme_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Bir resim Seçin");
            }
            else
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap sag = SagaDondur(image);
                pictureBox1.Image = sag;
            }
        }
        private void DikeyAyna_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Bir resim Seçin");
            }
            else
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap sol = DikeyAynalama(image);
                pictureBox1.Image = sol;
            }
        }
        private void YatayAyna_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Bir resim Seçin");
            }
            else
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap yatay = YatayAynalama(image);
                pictureBox1.Image = yatay;
            }
        }        
        private void Grileme_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Bir resim Seçin");
            }
            else
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap gri = griYap(image);
                pictureBox1.Image = gri;
            }
        }
        private void Tersleme_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Önce Bir resim Seçin");
            }
            else
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap negative = Negative(image);
                pictureBox1.Image = negative;
            }
        }        
        private Bitmap griYap(Bitmap bmp)  // Gri Tonlama
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                    Color renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }
        private Bitmap Negative(Bitmap bmp) // Negative Yapma
        {
            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < bmp.Height - 1; j++)
                {
                    Color renk = bmp.GetPixel(i, j);
                    renk = Color.FromArgb(renk.A, (byte)~renk.R, (byte)~renk.G, (byte)~renk.B);
                    bmp.SetPixel(i, j, renk);
                }
            }
            return bmp;
        }
        private Bitmap KirmiziYap(Bitmap bmp) // RGB renklerden kırmızı
        {
            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < bmp.Height - 1; j++)
                {
                    Color renk = bmp.GetPixel(i, j);
                    renk = Color.FromArgb(renk.R, 0, 0);
                    bmp.SetPixel(i, j, renk);
                }
            }
            return bmp;
        }
        private Bitmap YesilYap(Bitmap bmp) // RGB renklerden yeşil
        {
            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < bmp.Height - 1; j++)
                {
                    Color renk = bmp.GetPixel(i, j);
                    renk = Color.FromArgb(0, renk.G, 0);
                    bmp.SetPixel(i, j, renk);
                }
            }
            return bmp;
        }
        private Bitmap MaviYap(Bitmap bmp) // RGB renklerden mavi
        {
            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < bmp.Height - 1; j++)
                {
                    Color renk = bmp.GetPixel(i, j);
                    renk = Color.FromArgb(0, 0, renk.B);
                    bmp.SetPixel(i, j, renk);
                }
            }
            return bmp;
        }
        private Bitmap SolaDondur(Bitmap bmp) //Sola Döndürür
        {
            Bitmap b = new Bitmap(bmp.Height, bmp.Width);
            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < bmp.Height - 1; j++)
                {
                    b.SetPixel(j, b.Height - 1 - i, bmp.GetPixel(i, j));
                }
            }
            return b;
        }
        private Bitmap SagaDondur(Bitmap bmp) // Sağa Döndürür
        {
            Bitmap b = new Bitmap(bmp.Height, bmp.Width);
            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int j = 0; j < bmp.Height - 1; j++)
                {
                    b.SetPixel(b.Width - j - 1, i, bmp.GetPixel(i, j));
                }
            }
            return b;
        }
        private Bitmap YatayAynalama(Bitmap bmp) //  Aynalama
        {

            Bitmap b = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    b.SetPixel(b.Width - i - 1, j, bmp.GetPixel(i, j));
                }
            }
            return b;
        }
        private Bitmap DikeyAynalama(Bitmap bmp) //  Aynalama
        {
            Bitmap b = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    b.SetPixel(j, b.Height - i - 1, bmp.GetPixel(j, i));
                }
            }
            return b;
        }
        private Bitmap histogramMavi(Bitmap bmp) // Histogram
        {
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];
            frm.chart1.Series["Kirmizi"].Points.Clear();
            frm.chart1.Series["Yesil"].Points.Clear();
            frm.chart1.Series["Mavi"].Points.Clear();
            frm.chart1.Series["Gri"].Points.Clear();
            Array.Clear(mavi, 0, 256);
            for (int i = 0; i < bmp.Size.Height; i++)
            {
                for (int j = 0; j < bmp.Size.Width; j++)
                {
                    Color renk = bmp.GetPixel(j, i);
                    mavi[renk.B]++;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                frm.chart1.Series["Mavi"].Points.AddY(mavi[i]);
            }
            return bmp;
        }
        private Bitmap histogramKirmizi(Bitmap bmp) // Histogram
        {
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];
            frm.chart1.Series["Kirmizi"].Points.Clear();
            frm.chart1.Series["Yesil"].Points.Clear();
            frm.chart1.Series["Mavi"].Points.Clear();
            frm.chart1.Series["Gri"].Points.Clear();
            Array.Clear(kirmizi, 0, 256);
            for (int i = 0; i < bmp.Size.Height; i++)
            {
                for (int j = 0; j < bmp.Size.Width; j++)
                {
                    Color renk = bmp.GetPixel(j, i);
                    kirmizi[renk.B]++;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                frm.chart1.Series["Kirmizi"].Points.AddY(kirmizi[i]);
            }
            return bmp;
        }
        private Bitmap histogramYesil(Bitmap bmp) // Histogram
        {
            int[] kirmizi = new int[256];
            int[] yesil = new int[256];
            int[] mavi = new int[256];
            int[] gri = new int[256];
            frm.chart1.Series["Kirmizi"].Points.Clear();
            frm.chart1.Series["Yesil"].Points.Clear();
            frm.chart1.Series["Mavi"].Points.Clear();
            frm.chart1.Series["Gri"].Points.Clear();
            Array.Clear(yesil, 0, 256);
            for (int i = 0; i < bmp.Size.Height; i++)
            {
                for (int j = 0; j < bmp.Size.Width; j++)
                {
                    Color renk = bmp.GetPixel(j, i);
                    yesil[renk.G]++;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                frm.chart1.Series["Yesil"].Points.AddY(yesil[i]);
            }
            return bmp;
        }
        private Bitmap histogramGri(Bitmap bmp) // Histogram
        {
            int[] gri = new int[256];
            frm.chart1.Series["Kirmizi"].Points.Clear();
            frm.chart1.Series["Yesil"].Points.Clear();
            frm.chart1.Series["Mavi"].Points.Clear();
            frm.chart1.Series["Gri"].Points.Clear();
            Array.Clear(gri, 0, 256);
            for (int i = 0; i < bmp.Size.Height; i++)
            {
                for (int j = 0; j < bmp.Size.Width; j++)
                {
                    int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                    gri[deger]++;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                frm.chart1.Series["Gri"].Points.AddY(gri[i]);
            }
            return bmp;
        }
        private void OlceklendirmeUygula_Click(object sender, EventArgs e)
        {            
            int yukseklik = Convert.ToInt32(Yukseklik.Value);
            int genislik = Convert.ToInt32(Genislik.Value);
            Bitmap yeniboyut = new Bitmap(pictureBox1.Image, genislik, yukseklik);
            pictureBox1.Image = yeniboyut;
        }       
        private void MenuKontrol_Click(object sender, EventArgs e)
        {
            if(panel1.Visible == true)
            {
                panel1.Visible = false;
            }            
            else if(panel1.Visible == false)
            {
                panel1.Visible = true;
            }
                
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.Width == 625)
            {
                pictureBox2.Location = new Point(1010, 3);
                this.Width = 1050;
                RenkKanallari.Visible = true;
                histogramgroup.Visible = true;
                Aynalamagroup.Visible = true;
                Dondurmegroup.Visible = true;
                Olceklendirmegroup.Visible = true;
                Tersleme.Visible = true;
                Grileme.Visible = true;
            }
            else if(this.Width == 1050)
            {
                pictureBox2.Location = new Point(585, 3);
                this.Width = 625;
                RenkKanallari.Visible = false;
                histogramgroup.Visible = false;
                Aynalamagroup.Visible = false;
                Dondurmegroup.Visible = false;
                Olceklendirmegroup.Visible = false;
                Tersleme.Visible = false;
                Grileme.Visible = false;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void renkKanallarıUygu_Click(object sender, EventArgs e)
        {
            if (radioMavi.Checked == true)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Önce Bir resim Seçin");
                }
                else
                {
                    Bitmap image = new Bitmap(pictureBox1.Image);
                    Bitmap mavi = MaviYap(image);
                    pictureBox1.Image = mavi;
                }
            }
            if (radioKirmizi.Checked == true)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Önce Bir resim Seçin");
                }
                else
                {
                    Bitmap image = new Bitmap(pictureBox1.Image);
                    Bitmap kirmizi = KirmiziYap(image);
                    pictureBox1.Image = kirmizi;
                }
            }
            if (radioYesil.Checked == true)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Önce Bir resim Seçin");
                }
                else
                {
                    Bitmap image = new Bitmap(pictureBox1.Image);
                    Bitmap yesil = YesilYap(image);
                    pictureBox1.Image = yesil;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioMaviHistogram.Checked == true)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Önce Bir resim Seçin");
                }
                else
                {
                    Bitmap image = new Bitmap(pictureBox1.Image);
                    Bitmap histogram = histogramMavi(image);
                    pictureBox1.Image = histogram;
                    frm.ShowDialog();
                }
            }
            if (radioKirmiziHistogram.Checked == true)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Önce Bir resim Seçin");
                }
                else
                {
                    Bitmap image = new Bitmap(pictureBox1.Image);
                    Bitmap histogram = histogramKirmizi(image);
                    pictureBox1.Image = histogram;
                    frm.ShowDialog();
                }
            }
            if (radioYesilHistogram.Checked == true)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Önce Bir resim Seçin");
                }
                else
                {
                    Bitmap image = new Bitmap(pictureBox1.Image);
                    Bitmap histogram = histogramYesil(image);
                    pictureBox1.Image = histogram;
                    frm.ShowDialog();
                }
            }
            if (radioGriHistogram.Checked == true)
            {
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Önce Bir resim Seçin");
                }
                else
                {
                    Bitmap image = new Bitmap(pictureBox1.Image);
                    Bitmap histogram = histogramGri(image);
                    pictureBox1.Image = histogram;
                    frm.ShowDialog();
                }
            }
        }
        private void anasayfa_Click(object sender, EventArgs e)
        {
            giris.Visible = true;
            this.Visible = false;            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(kontrol == 0)
            {
                OpenFileDialog dosyaac = new OpenFileDialog();
                dosyaac.Filter = "Photos|*.jpg|All Files|*.*";
                if (dosyaac.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                this.pictureBox1.Image = new Bitmap(dosyaac.OpenFile());
                if (pictureBox1.Image.Height > 550)
                {
                    Bitmap yeniyukseklik = new Bitmap(pictureBox1.Image, pictureBox1.Image.Width, 550);
                    pictureBox1.Image = yeniyukseklik;
                }
                if (pictureBox1.Image.Width > 600)
                {
                    Bitmap yenigenislik = new Bitmap(pictureBox1.Image, 600, pictureBox1.Image.Height);
                    pictureBox1.Image = yenigenislik;
                }
                yedek = new Bitmap(pictureBox1.Image);
                kontrol = 1;
            }
            else
            {

            }
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                return;
            }
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            this.Left += e.X - x;
            this.Top += e.Y - y;
        } 
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
