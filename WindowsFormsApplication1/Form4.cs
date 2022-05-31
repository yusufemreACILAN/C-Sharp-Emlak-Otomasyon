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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        Form1 F1 = new Form1();
        private void FormOrtala() { this.CenterToScreen(); }
        private void KullaniciKayitEt()
        {
            try
            {
                F1.Baglanti.Open();
                OleDbCommand Komut = new OleDbCommand("INSERT INTO KullaniciHesaplari(KullaniciAdi,Adi,Soyadi,DogumTarihi,Cinsiyet,Sifre) VALUES (@KullaniciAdi,@Adi,@Soyadi,@DogumTarihi,@Cinsiyet,@Sifre)", F1.Baglanti);
                Komut.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
                Komut.Parameters.AddWithValue("@Adi", textBox2.Text);
                Komut.Parameters.AddWithValue("@Soyadi", textBox3.Text);
                Komut.Parameters.AddWithValue("@DogumTarihi", maskedTextBox1.Text);
                Komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
                Komut.Parameters.AddWithValue("@Sifre", textBox5.Text);
                Komut.ExecuteNonQuery();
                MessageBox.Show(textBox2.Text + "" + textBox3.Text + " İsimli kaydınız başarıyla oluşturuldu.", "Emlak", MessageBoxButtons.OK, MessageBoxIcon.Information);
                F1.Baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Hata: Bilgileri eksik doldurnuz lütfen kontrol edin.");
            }
            else
            {
                KullaniciKayitEt();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            FormOrtala();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Visible = true;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
