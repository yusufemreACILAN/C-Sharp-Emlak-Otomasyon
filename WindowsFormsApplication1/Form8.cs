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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public Form8(string adi, string soyadi)
        {
            InitializeComponent();
            Adi = adi;
            Soyadi = soyadi;
        }
        Form1 F1 = new Form1();
        string Adi, Soyadi;
        private void FormOrtala() { this.CenterToScreen(); }
        private void KullaniciBilgisiListele()
        {
            try
            {
                F1.Baglanti.Open();
                OleDbCommand Komut = new OleDbCommand("SELECT * FROM KullaniciHesaplari WHERE Adi='" + Adi + "' AND Soyadi='" + Soyadi + "'",F1.Baglanti);
                OleDbDataReader Oku = Komut.ExecuteReader();
                while (Oku.Read())
                {
                    textBox1.Text = Oku["KullaniciAdi"].ToString();
                    textBox2.Text = Oku["Adi"].ToString();
                    textBox3.Text = Oku["Soyadi"].ToString();
                    maskedTextBox1.Text = Oku["DogumTarihi"].ToString();
                    comboBox1.Text = Oku["Cinsiyet"].ToString();
                }
                F1.Baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message);
            }
        }
        private void BilgileriDuzenle()
        {
            try
            {
                F1.Baglanti.Open();
                OleDbCommand Komut = new OleDbCommand("UPDATE KullaniciHesaplari SET KullaniciAdi=@KullaniciAdi,Adi=@Adi,Soyadi=@Soyadi,DogumTarihi=@DogumTarihi,Cinsiyet=@Cinsiyet,Sifre=@Sifre WHERE Adi='" + Adi + "' AND Soyadi='" + Soyadi + "'", F1.Baglanti);
                Komut.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
                Komut.Parameters.AddWithValue("@Adi", textBox2.Text);
                Komut.Parameters.AddWithValue("@Soyadi", textBox3.Text);
                Komut.Parameters.AddWithValue("@DogumTarihi", maskedTextBox1.Text);
                Komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
                Komut.Parameters.AddWithValue("@Sifre", textBox5.Text);
                Komut.ExecuteNonQuery();
                MessageBox.Show("Başarıyla bilgileriniz düzenlendi.");
                F1.Baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && maskedTextBox1.Text == "" && comboBox1.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Bilgileriniz eksiktir lütfen tekrar deneyin.");
            }
            else
            {
                BilgileriDuzenle();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox5.PasswordChar = '\0';
            }
            else
            {
                textBox5.PasswordChar = '*';
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Visible = true;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            FormOrtala();
            KullaniciBilgisiListele();
        }
    }
}
