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
    public partial class frmMesajGonder : Form
    {
        public frmMesajGonder(string tel)
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            NesneGorselleri.kontrolEkle(panel1);
            mesajListele();
            txtTel.Text = tel;
            bakiyeGetir();
            txtMesaj.MaxLength = 155;
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

            if (txtTel.Text.Length != 14)
            {
                MessageBox.Show("Telefon No Girin!");
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

            string mesaj = txtMesaj.Text.Trim();
            string tel = txtTel.Text;
            tel = tel.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            tel = "0" + tel;
            string value = SMSPaketi.SendSms(cmbBaslik.Text, mesaj, tel);
            if (value != "20" && value != "30" && value != "40" && value != "70")
            {
                veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-1 where firmaid=" + firma.firmaid);
                MessageBox.Show("SMS Gönderildi.");
                Close();
            }
            else MessageBox.Show("Gönderilemedi!");
        }
    }
}