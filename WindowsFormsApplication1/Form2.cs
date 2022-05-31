using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string kullaniciadi, string sifre)
        {
            InitializeComponent();
            KullaniciAdi = kullaniciadi;
            Sifre = sifre;
        }
        Form1 F1 = new Form1();
        string KullaniciAdi, Sifre;
        private void KullaniciBilgileriListele()
        {
            try
            {
                F1.Baglanti.Open();
                OleDbCommand Komut = new OleDbCommand("SELECT * FROM KullaniciHesaplari WHERE KullaniciAdi='" + KullaniciAdi + "' AND Sifre='" + Sifre + "'",F1.Baglanti);
                OleDbDataReader Oku = Komut.ExecuteReader();
                while (Oku.Read())
                {
                    label1.Text = Oku["Adi"].ToString();
                    label2.Text = Oku["Soyadi"].ToString();
                }
                F1.Baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message);
            }         
        }
        private void FormOrtala() { this.CenterToScreen(); }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5(label1.Text, label2.Text);
            F5.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 F6 = new Form6();
            F6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 F7 = new Form7();
            F7.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 F8 = new Form8(label1.Text, label2.Text);
            F8.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FormOrtala();
            KullaniciBilgileriListele();
        }
    }
}
