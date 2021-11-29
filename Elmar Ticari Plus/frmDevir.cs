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
    public partial class frmDevir : Form
    {

        public frmDevir(long cariid, string cariAdiSoyadi, double eskiBakiye)
        {
            baslangic();
            if (cariid != 0)
            {
                this.cariid = cariid;
                cmbCariler.Text = cariAdiSoyadi;
            }
            else
            {
                cmbCariler.Select();
            }
            //txtEskiBakiye.Text = String.Format("{0:n2}", eskiBakiye);
        }
        long acikHesapid = 0, ticaretAyrintiid = 0;
        public frmDevir(long acikHesapid, long ticaretAyrintiid, long cariid, string cariAdiSoyadi, string belgeNo, double tutar, string doviz, double dovizDegeri, string islemTipi, DateTime islemTarihi, DateTime vadeTarihi, string aciklama, double eskiBakiye)
        {
            baslangic();
            this.cariid = cariid;
            txtBelgeNo.Text = belgeNo;
            this.acikHesapid = acikHesapid;
            this.ticaretAyrintiid = ticaretAyrintiid;
            cmbCariler.Text = cariAdiSoyadi;
            txtTutar.Text = String.Format("{0:n2}", tutar);
            txtDovizKuru.Text = doviz;
            txtDovizDegeri.Text = String.Format("{0:n2}", dovizDegeri);
            cmbislemTipi.Text = islemTipi;
            dtİslemTarihi.Value = islemTarihi;
            dtVadeTarihi.Value = vadeTarihi;
            txtAcklama.Text = aciklama;
            //txtEskiBakiye.Text = String.Format("{0:n2}", eskiBakiye);
            this.Text = "Devir Düzenle";
        }
        void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(this);
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
            listeler.doldurSube(cmbESubeler);
        }
        private long cariid = 0;
        private void frmDevir_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (kaydet() == false) return;
            frmYaziciSecimi frm = new frmYaziciSecimi();
            frm.Show();
            if (frm.yazdirilacakmi) {//yazdırma işlemi 
            }
        }

        

        bool kaydet()
        { 
         try
            {
                if (txtTutar.Text == "0")
                {
                    MessageBox.Show("Tutarı Girmediniz", firma.programAdi);
                    txtTutar.Select();
                    return false;
                }
                if (cariid == 0)
                {
                    MessageBox.Show("Cari Seçmediniz", firma.programAdi);
                    cmbCariler.Select();
                    return false;
                }
                if (cmbislemTipi.Items.Contains(cmbislemTipi.Text) == false)
                {
                    MessageBox.Show("İşlem Tipini listeden seçin", firma.programAdi);
                    cmbislemTipi.Select();
                    return false;
                }
                if (ComboboxItem.seciliMetinKontrolu(cmbESubeler) == false)
                {
                    MessageBox.Show("Şubeyi listeden seçin", firma.programAdi);
                    cmbESubeler.Select();
                    return false;
                }
                if (ComboboxItem.seciliMetinKontrolu(cmbEKullanicilar) == false)
                {
                    MessageBox.Show("Kullanıcıyı listeden seçin", firma.programAdi);
                    cmbEKullanicilar.Select();
                    return false;
                }

                double borc = 0; double alacak = 0;
                //Açık Hesap Aktarılıyor
                if (this.cmbislemTipi.Text == "Borç")
                {
                    borc = Convert.ToDouble(txtTutar.Text);
                }
                else if (this.cmbislemTipi.Text == "Alacak")
                {
                    alacak = Convert.ToDouble(txtTutar.Text);
                }
                else
                {
                    MessageBox.Show("Gerçerli bir işlem tipi seçmediniz.",firma.programAdi);
                    cmbislemTipi.Select();
                    return false;
                }

                acikHesap.ekle(acikHesapid, ticaretAyrintiid, 0, 0, 0, cariid, dtİslemTarihi.Value, Convert.ToDateTime(null), dtVadeTarihi.Value, borc, alacak, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Açık Hesap", cmbislemTipi.Text, "Kasa", txtAcklama.Text, "", txtBelgeNo.Text, "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), 0, duzenlemeBakiyesi);
                btnTemizle.PerformClick();
                lblDurum.Text = "Kaydedildi";
                return true;
            }
            catch (Exception hata)
            {
                lblDurum.Text = "Kaydedilirken hata oluştu. Hata Metni: " + hata.Message;
                return false;
            }
        }
        double duzenlemeBakiyesi = 0;
        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(true);
        }
        void hesapla_AcikHesap(bool dovizKuruOtomatikGetirilsinmi)
        {
            try
            {
                double pb = 1.0;
                if (dovizKuruOtomatikGetirilsinmi)
                {
                    if (txtDovizKuru.Text == "USD") pb = Convert.ToDouble(bilgiler.dovizVerileri.dDolarsatis);
                    else if (txtDovizKuru.Text == "EURO") pb = Convert.ToDouble(bilgiler.dovizVerileri.dEurosatis);
                    txtDovizDegeri.Text = pb.ToString();
                }
                else
                {
                    pb = Convert.ToDouble(txtDovizDegeri.Text);
                }
                txtDovizliTutar.Text = String.Format("{0:n2}",(pb * Convert.ToDouble(txtTutar.Text)));
            }
            catch
            {
                
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDovizDegeri_TextChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(false);
        }

        private void txtDovizKuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(true);
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cariid = listeler.getCariid()[cmbCariler.SelectedIndex];
            }
            catch (Exception)
            {
            }
        }

        private void btnCariEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
        }

        private void cmbESubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar, ComboboxItem.getSelectedValue(cmbESubeler));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            txtAcklama.Clear();
            txtTutar.Text = "0";
            txtDovizliTutar.Text = "0";
            txtTutar.Select();
            lblDurum.Text = "Temizlendi";
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            kaydet();
        }

        private void btnCariAra_Click(object sender, EventArgs e)
        {

        }
    }
}
