﻿using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        Form1 F1 = new Form1();
        private void FormOrtala() { this.CenterToScreen(); }
        private void button1_Click(object sender, EventArgs e)
        {
            string Tercih = "";
            if (radioButton1.Checked == true)
                Tercih = "Satilik Ev";
            if (radioButton2.Checked == true)
                Tercih = "Kiralik Ev";
            try
            {
                F1.Baglanti.Open();
                OleDbDataAdapter Yaz = new OleDbDataAdapter("SELECT * FROM Ilan WHERE EvTercihi='" + Tercih + "'",F1.Baglanti);
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

        private void Form7_Load(object sender, EventArgs e)
        {
            FormOrtala();
        }
    }
}
