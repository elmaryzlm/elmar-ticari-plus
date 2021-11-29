using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmMesajGonderGrup : Form
    {
        public frmMesajGonderGrup()
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            NesneGorselleri.kontrolEkle(panel1);
            mesajListele();
            bakiyeGetir();
            txtMesaj.MaxLength = 155;
            SetGrid();
            GetCariGrup();
        }

        private void GetCariGrup()
        {
            try
            {
                string sql = @"Select cariGrupid, grupAdi from tblCariGruplari Where firmaid = " + firma.firmaid + " and silindimi = '0'";
                cmbCariGruplari.DataSource = veri.getdatatable(sql);
                cmbCariGruplari.DisplayMember = "grupAdi";
                cmbCariGruplari.ValueMember = "cariGrupid";
            }
            catch
            {
            }
        }

        private void GetCariFromGrup()
        {
            try
            {
                string sql = @"Select sorCariBilgileri.adiSoyadi, sorAdresBilgileri.gsm from sorCariBilgileri 
                               LEFT JOIN sorAdresBilgileri on sorCariBilgileri.cariid=sorAdresBilgileri.cariid
                               Where grupid=" + Convert.ToInt32(cmbCariGruplari.SelectedValue.ToString()) + " and silindimi = '0' and sorCariBilgileri.firmaid=" + firma.firmaid;
                dataGridView1.DataSource = veri.getdatatable(sql);
            }
            catch
            {
            }
        }

        private void mesajListele()
        {
            try
            {
                cmbMesajAdi.DataSource = veri.getdatatable("Select hazirMesajID, Adi from tblHazirMesaj Where firmaId = " + firma.firmaid + " and silindimi = '0'");
                cmbMesajAdi.ValueMember = "hazirMesajID";
                cmbMesajAdi.DisplayMember = "Adi";
            }
            catch
            {
            }
        }

        private void SetGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private int bakiyeGetir()
        {
            try
            {

                int bakiye = Convert.ToInt32(veri.getdatacell("Select smsAdet from tblFirmaBilgileri Where firmaid = " + firma.firmaid + " and silindimi = '0'"));
                lblBakiye.Text = bakiye.ToString() + " Adet";
                return bakiye;
            }
            catch
            {
                return 0;
            }
        }

        private void cmbMesajAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMesaj.Text = veri.getdatacell("Select Mesaj from tblHazirMesaj Where hazirMesajID=" + Convert.ToInt32(cmbMesajAdi.SelectedValue));
                txtMesaj.Text += firma.firmaAdi;
            }
            catch (Exception)
            {
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (txtMesaj.Text.Length == 0)
            {
                MessageBox.Show("Mesaj Girin!");
                return;
            }

            if (cmbBaslik.SelectedIndex == -1)
            {
                MessageBox.Show("Başlık Seçin!");
                return;
            }

            int smsAdet = bakiyeGetir();

            if (smsAdet == 0)
            {
                MessageBox.Show("SMS Bakiyeniz Yoktur!");
                return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool isCheck = Convert.ToBoolean(dataGridView1.Rows[i].Cells["colCheck"].Value);
                string phone = "0" + dataGridView1.Rows[i].Cells["gsm"].Value.ToString();
                string cari = dataGridView1.Rows[i].Cells["adisoyadi"].Value.ToString();
                phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                if (isCheck)
                {
                    if (phone.Length != 11)
                    {
                        MessageBox.Show(cari + " İsimli Carinin Telefon Nosunu Düzgün Bir Şekilde Girin!");
                        return;
                    }
                }
            }


            string numbers = "";
            int messageCount = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool isCheck = Convert.ToBoolean(dataGridView1.Rows[i].Cells["colCheck"].Value);
                string phone = "0" + dataGridView1.Rows[i].Cells["gsm"].Value.ToString();
                phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                if (isCheck)
                {
                    numbers += "<no>" + phone + "</no>";
                    messageCount++;
                }
            }

            if (messageCount > smsAdet)
            {
                MessageBox.Show("Yeteri Kadar Mesaj Hakkınız Yok. Paket Alınız.");
                return;
            }

            string mesaj = txtMesaj.Text.Trim();
            string value = SMSPaketi.SendSmsCoklu(cmbBaslik.Text, mesaj, numbers);
            if (value != "20" && value != "30" && value != "40" && value != "70")
            {
                veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-" + messageCount + " where firmaid=" + firma.firmaid);
                MessageBox.Show("SMS Gönderildi.");
                Close();
            }
            else MessageBox.Show("Gönderilemedi!");
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["colCheck"].Value = true;
            }
        }

        private void btnAllUnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["colCheck"].Value = false;
            }
        }

        private void cmbCariGruplari_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCariFromGrup();
        }
    }
}