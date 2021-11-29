using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class FrmSms : Form
    {
        public FrmSms()
        {
            InitializeComponent();
            BakiyeGetir();
            MesajlariListele();
            txtMesaj.MaxLength = 155;
            cariListesiniYenile();
            cmbCariler.Select();
            cmbBaslik.Text = firma.firmaAdi;
            NesneGorselleri.dataGridView(dataGridViewRapor);
            IzinGetir();
            cmbCariler.SelectedIndex = 0;
            GridDoldur();
        }
        void GridDoldur()
        {
            SqlDataReader dr = veri.getDatareader(" Select * from ViewMesajRaporlari Where firmaid=" + firma.firmaid);
            while (dr.Read())
            {
                dataGridViewRapor.Rows.Add(dr["mesajTarihi"].ToString(), dr["Baslik"].ToString(), dr["mesajMetni"].ToString(), dr["AdiSoyadi"].ToString(), dr["FİRMA"].ToString(), dr["subeAdi"].ToString(), dr["kAdi"].ToString(), dr["firmaid"].ToString());
            }
        }
        private int BakiyeGetir()
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
        private void MesajlariListele()
        {
            try
            {
                cmbMesajAdi.DataSource = veri.getdatatable("Select hazirMesajID, Adi from tblHazirMesaj Where FirmaID="+firma.firmaid+" and silindimi = '0'");
                cmbMesajAdi.ValueMember = "hazirMesajID";
                cmbMesajAdi.DisplayMember = "Adi";
            }
            catch
            {
            }
        }

        private void cmbMesajAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string mesaj= veri.getdatacell("Select Mesaj from tblHazirMesaj Where hazirMesajID=" + Convert.ToInt32(cmbMesajAdi.SelectedValue));
                txtMesaj.Text = "Sayın " + cmbCariler.Text + " " + mesaj;             
            }
            catch (Exception)
            {
            }
        }

        private void IzinGetir()
        {
            try
            {
                SqlDataReader dr = veri.getDatareader(" Select * from tblSmsYetkileri Where firmaid="+firma.firmaid);              
                while (dr.Read())
                {
                    foreach (CheckBox chk in groupBox1.Controls)
                    {
                        if (chk.Text == dr["YetkiAdi"].ToString())
                        {
                            chk.Checked = Convert.ToBoolean(Convert.ToByte(dr["yetkiDegeri"]));
                            break;
                        }
                    }
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        public void cariListesiniYenile()
        {
            try
            {
                cmbCariler.Items.Clear();
                cmbCariler.Items.AddRange(listeler.getCariAdi());
            }
            catch { }
        }

        public Int64 cariid = 0;

        void CariBilgileriGetir()
        {
            txtTel.Text = "";
            cariid = listeler.getCariid()[cmbCariler.SelectedIndex];
            var l = cariBilgileri.bul_cariid(cariid);

            var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid);
            foreach (var adresKaydi in adresListesi)
            {
                txtTel.Text = adresKaydi.gsm;
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

            //if (cmbBaslik.Text.Length ==0)
            //{
            //    MessageBox.Show("Başlık Seçin!");
            //    return;
            //}

            int smsAdet = BakiyeGetir();

            if (smsAdet == 0)
            {
                MessageBox.Show("SMS Bakiyeniz Yoktur!");
                return;
            }
            string mesaj = txtMesaj.Text.Trim();
            string tel = txtTel.Text;
            tel = tel.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            tel = "0" + tel;
            // string value = SMSPaketi.SendSms(cmbBaslik.Text,mesaj,tel);
            string value = Utility.SendSMS(tel,mesaj);
            if (value != "20" && value != "30" && value != "40" && value != "70")
            {
                veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-1 where firmaid=" + firma.firmaid);
                MessageBox.Show("SMS Gönderildi.");
                veri.cmd("insert into tblMesajlar (mersajMetni,Baslik,kime,firmaid,subeid,kullaniciid)values('"+mesaj+"','"+firma.firmaAdi+"',"+cariid+","+firma.firmaid+","+firma.subeid+","+firma.kullaniciid+")");
                Close();
            }
            else MessageBox.Show("Gönderilemedi!");
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            CariBilgileriGetir();
        }

        private void chbFaturaliSatis_Click(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            veri.cmd("update tblSmsYetkileri set YetkiDegeri='"+Convert.ToByte(chk.Checked)+"' where YetkiAdi='"+chk.Text+"' and firmaid="+firma.firmaid);
            SmsYetkileri.SmsYetkiGuncelle();
        }      
    }
}
