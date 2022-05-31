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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Form1 F1 = new Form1();
        private void FormOrtala() { this.CenterToScreen(); }
        private void IlanListele()
        {
            try
            {
                F1.Baglanti.Open();
                OleDbDataAdapter Yaz = new OleDbDataAdapter("SELECT * FROM Ilan",F1.Baglanti);
                DataTable Tablo = new DataTable();
                Yaz.Fill(Tablo);
                dataGridView1.DataSource = Tablo;
                F1.Baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message);
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            FormOrtala();
            IlanListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                F1.Baglanti.Open();
                OleDbCommand Komut = new OleDbCommand("DELETE * FROM Ilan WHERE Adi=@Adi", F1.Baglanti);
                Komut.Parameters.AddWithValue("@Adi", dataGridView1.CurrentRow.Cells[0].Value);
                Komut.ExecuteNonQuery();
                F1.Baglanti.Close();
                IlanListele();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message);
            }
        }
    }
}
