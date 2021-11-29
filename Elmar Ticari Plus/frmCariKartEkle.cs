using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmCariKartEkle : Form
    {
        public frmCariKartEkle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(panel1);
            NesneGorselleri.kontrolEkle(panel6);
        }
        public void guncellemeModu()
        {
            lblBaslik.Text = "Cari Kartı Güncelle";
            temizle();
            var l = cariBilgileri.bul_cariid(cariid);
            txtCariKodu.Text = l.cariKodu;
            txtCariAdi.Text = l.adi;
            txtCariUnvani.Text = l.soyadi;
            string cariGrubuAdi = "", cariFiyatAdi = "";
            try
            {
                var cariGrubu = cariBilgileri.cariGruplari.listCariGruplari.Where(u => u.cariGrupid == l.grupid).First();
                cariGrubuAdi = cariGrubu.grupAdi;
            }
            catch { }

            try
            {
                var cariFiyati = cariBilgileri.listCariBilgileri.FirstOrDefault(u => u.cariid == l.cariid);
                cariFiyatAdi = Elmar_Ticari_Plus.stokkart.fiyatlar.listFiyatlar.FirstOrDefault(u => u.fiyatid == cariFiyati.fiyatid).fiyatAdi;
            }
            catch { }
            cmbCariGrubu.Text = cariGrubuAdi;
            cmbFiyatAdi.Text = cariFiyatAdi;
            txtCariLimiti.Text = l.limit.ToString();
            txtWebSitesi.Text = l.webSitesi;
            txtHatirlatmaGunu.Value = l.hatirlatmaGunu;
            cmbParaBirimi.Text = l.paraBirimi;
            txtVergiDairesi.Text = l.vergiDaire;
            txtVergiNo.Text = l.vergiNo;
            txtCariAciklamasi.Text = l.cariAciklamasi;

            //adresler getiriliyor            
            var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid);
            foreach (var adresKaydi in adresListesi)
            {
                txtAdresAdi.Text = adresKaydi.adresAdi;
                txtBolge.Text = adresKaydi.boldeAdi;
                txtAdres.Text = adresKaydi.adres;
                txtTel.Text = adresKaydi.tel;
                txtFax.Text = adresKaydi.fax;
                txtGsm.Text = adresKaydi.gsm;
                txtEmail.Text = adresKaydi.email;
                if (adresKaydi.varsayilanmi == "0") chkVarsayilanAdresmi.Checked = false;
                else chkVarsayilanAdresmi.Checked = true;
                adresid = adresKaydi.adresid;
            }
        }
        public frmCariKartislemleri _frmCariKartislemleri = null;
        public frmCekSenetEkle _frmCekSenetEkle = null;
        private void frmCariKartEkle_Load(object sender, EventArgs e)
        {
            listeleriYukle();
            if (cariid != 0) guncellemeModu();
        }
        void listeleriYukle()
        {
            try
            {
                cmbCariGrubu.Items.Clear();
                cmbCariGrubu.Items.AddRange(listeler.getCariGrupAdi());
                listeler.doldurKullanici(cmbPlasiyer, "");
            }
            catch { }
            try
            {
                cmbFiyatAdi.Items.Clear();
                cmbFiyatAdi.Items.AddRange(listeler.getFiyatAdi());
            }
            catch { }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCariAdi.Text == "")
                {
                    MessageBox.Show("Cari Adını Girmediniz", firma.programAdi);
                    txtCariAdi.Select();
                    return;
                }
                if (txtRIFDNo.Text != "")
                {
                    var Checked = cariBilgileri.bul_RIFDNo(txtRIFDNo.Text);
                    if (Checked != null)
                    {
                        MessageBox.Show("Bu Kart Numarası Daha Önce Tanımlanmıştır ", firma.programAdi);
                        txtRIFDNo.Select();
                        return;
                    }
                }
                if (txtCariLimiti.Text == "") txtCariLimiti.Text = "0";
                if (txtAdresAdi.Text == "") txtAdresAdi.Text = "İletişim Adresi";
                string varsayilanAdresmi = "0";
                if (chkVarsayilanAdresmi.Checked == true) varsayilanAdresmi = "1";
                int grupid = 0;
                int plasiyerID = 0;
                if (cmbCariGrubu.SelectedIndex >= 0) grupid = listeler.getCariGrupid()[cmbCariGrubu.SelectedIndex];
                if (cmbPlasiyer.SelectedIndex >= 0) plasiyerID = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbPlasiyer));
                int guzergahid = 0;
                string bolgeid = txtBolge.Tag.ToString();
                int fiyatid = 0;
                if (cmbFiyatAdi.SelectedIndex > -1) fiyatid = listeler.getFiyatid()[cmbFiyatAdi.SelectedIndex];
                //cari ekleniyor, güncelleniyor.
                Int64 eklenenCariid = Convert.ToInt64(veri.getdatacell("exec spCariEkle " + cariid + ", 0 ,'" + txtCariKodu.Text + "', '" + txtCariAdi.Text + "','" + txtCariUnvani.Text + "', '" + txtVergiDairesi.Text + "','" + txtVergiNo.Text + "', '','" + grupid + "', '" + guzergahid + "','" + cmbParaBirimi.Text + "', '" + txtCariLimiti.Text.Replace(".", "").Replace(",", ".") + "','" + txtHatirlatmaGunu.Value + "', '" + txtCariAciklamasi.Text + "','" + txtWebSitesi.Text + "', '','" + txtRIFDNo.Text + "', '','0', '" + fiyatid + "','" + plasiyerID + "','" + firma.firmaid + "','" + firma.subeid + "', '" + firma.kullaniciid + "'"));
                if (cariid != 0) cariBilgileri.listCariBilgileri.Remove(cariBilgileri.listCariBilgileri.Where(u => u.cariid == cariid).First());
                cariBilgileri.ekle(eklenenCariid, 0, txtCariKodu.Text, txtCariAdi.Text, txtCariUnvani.Text, txtCariAdi.Text + " " + txtCariUnvani.Text, "", "", txtVergiDairesi.Text, txtVergiNo.Text, "", grupid, guzergahid, txtRIFDNo.Text, cmbParaBirimi.Text, Convert.ToDouble(txtCariLimiti.Text), Convert.ToInt16(txtHatirlatmaGunu.Value), txtCariAciklamasi.Text, txtWebSitesi.Text, "", "", "", "1", "0", "1", "0", fiyatid, DateTime.Now, "0", firma.subeid, firma.kullaniciid, 0, "-");
                listeler.yukleCariadi();


                //string sql = (veri.getdatacell("insert into  tblCariKartPuani(cariid,rfidKartNo,aciklama,miktar,firmaid,subeid,kullaniciid) values('" + eklenenCariid + "','" + txtKartNo.Text + "','" + txtCariAciklamasi.Text + "','" + TxtBakiye.Text + "','" + firma.firmaid + "','" + firma.subeid + "', '" + firma.kullaniciid + "') "));
                //veri.getDatareader(sql);

                //Int64 eklenenKartPuanid = Convert.ToInt64(veri.getdatacell("exec spKartPuaniEkle " + eklenenCariid + ", 0 ,'" + txtKartNo.Text + "', '" + txtCariAciklamasi.Text + "','" + TxtBakiye.Text + "','" + firma.firmaid + "','" + firma.subeid + "', '" + firma.kullaniciid + "'"));
                //cariBilgileri.KartPuaniEkle.ekle(eklenenKartPuanid, eklenenCariid, txtKartNo.Text, txtCariAciklamasi.Text, Convert.ToDouble(TxtBakiye.Text), DateTime.Now, firma.firmaid, firma.subeid, firma.kullaniciid);

                //adres ekleniyor, güncelleniyor.
                if (adresid != 0)
                    cariBilgileri.adresBilgileri.listAdresBilgileri.Remove(cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.adresid == adresid).First());
                Int64 eklenenAdresid = Convert.ToInt64(veri.getdatacell("exec spAdresEkle '" + adresid + "', '" + eklenenCariid + "', '" + txtAdresAdi.Text + "', '" + txtCariAdi.Text + "', '" + txtCariUnvani.Text + "', '" + txtEmail.Text + "', '" + txtTel.Text + "', '" + txtGsm.Text + "', '" + txtFax.Text + "', '" + bolgeid + "', '" + txtAdres.Text + "', '" + txtPostaKodu.Text + "', '', '" + txtVergiDairesi.Text + "', '" + txtVergiNo.Text + "', '', '" + varsayilanAdresmi + "', '" + firma.firmaid + "', '" + firma.subeid + "', '" + firma.kullaniciid + "'"));
                cariBilgileri.adresBilgileri.ekle(eklenenAdresid, eklenenCariid, txtCariAdi.Text + " " + txtCariUnvani.Text, txtAdresAdi.Text, txtCariAdi.Text, txtCariUnvani.Text, txtEmail.Text, txtTel.Text, txtGsm.Text, txtFax.Text, bolgeid, "", txtAdres.Text, txtPostaKodu.Text, "", txtVergiDairesi.Text, txtVergiNo.Text, "", varsayilanAdresmi, DateTime.Now, firma.subeid, firma.kullaniciid);
                listeler.yukleAdresler();

                cariid = 0;
                temizle();

                if (_frmCariKartislemleri != null) _frmCariKartislemleri.cariListesiniYenile();
                if (_frmCekSenetEkle != null) _frmCekSenetEkle.cariListesiniYenile();
                MessageBox.Show("İşlem Başarılı", firma.programAdi);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Cari Eklemede Hata Oluştu\nHata: " + hata.Message);
            }
        }
        public Int64 cariid = 0;
        Int64 adresid = 0;
        int kartPuanid = 0;
        void temizle()
        {
            txtBolge.Clear();
            txtBolge.Tag = "00";
            txtCariKodu.Select();
            txtCariKodu.Clear();
            txtCariAdi.Clear();
            txtCariUnvani.Clear();
            cmbCariGrubu.Text = "";
            txtCariLimiti.Text = "0";
            txtWebSitesi.Clear();
            txtVergiDairesi.Clear();
            txtVergiNo.Clear();
            txtCariAciklamasi.Clear();
            txtAdresAdi.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            txtGsm.Clear();
            txtFax.Clear();
            txtAdres.Clear();
            txtPostaKodu.Clear();
            cmbCariGrubu.Text = "";
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            cariid = 0;
            temizle();
        }

        private void txtBolgeSec_Click(object sender, EventArgs e)
        {
            frmBolgeSecimi frm = new frmBolgeSecimi();
            frm._frmCariKartEkle = this;
            frm.Show();
        }

        private void txtBolge_TextChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKartOkuma frm = new FrmKartOkuma();
            frm.Show();
        }
    }
}
