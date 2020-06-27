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
    public partial class Anasayfa : Form
    {
        int x, y;
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 baslat = new Form5();
            baslat.Visible = true;
            baslat.Width = 625;
            baslat.pictureBox2.Location = new Point(585, 3);
            this.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Kılavuz ac = new Kılavuz();
            ac.ShowDialog();
        }
        private void hakkimda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("150201127-Mehmet Emin Arslan" + "\n"+ "150201177-Oğuz Koçak", "HAZIRLAYANLAR");
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
    }
}
