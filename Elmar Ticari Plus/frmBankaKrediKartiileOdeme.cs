using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.Data.SqlClient;
namespace Elmar_Ticari_Plus
{
    public partial class frmBankaKrediKartiileOdeme : Form
    {
        private long bankaislemid = 0;
        private long cariid = 0;
        private int grupid = 0;
        private long ticaretAyrintiid = 0;
        public frmTicaret _frmTicaret = null;
        private string aciklama = "";
        private string islemTipi = "";
        public frmBankaKrediKartiileOdeme()
        {
            baslangic();
        }
        void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(this);
            NesneGorselleri.kontrolEkle(panel1);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.dataGridView(dgAlanHesap);
            cmbCariler.Items.Clear();
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
            listeler.doldurSube(cmbESubeler);
            krediKartiListele();
        }

        public frmBankaKrediKartiileOdeme(long cariid, string cariAdiSoyadi, string tutar, string islemTipi, DateTime islemTarihi, int grupid, long ticaretAyrintiid, string aciklama)
        {
            baslangic();
            this.cariid = cariid;
            this.grupid = grupid;
            this.ticaretAyrintiid = ticaretAyrintiid;
            this.islemTipi = islemTipi;

            cmbCariler.Text = cariAdiSoyadi;
            cmbCariler.Enabled = false;

            dtİslemTarihi.Value = islemTarihi;

            dtİslemTarihi.Enabled = false;
            //cmbEKullanicilar.Enabled = false;
            //cmbESubeler.Enabled = false;

            txtTutar.Text = string.Format("{0:n2}", Convert.ToDouble(tutar));
            txtTutar.Enabled = false;

            this.aciklama = aciklama;
        }

        public frmBankaKrediKartiileOdeme(long cariid, string cariAdiSoyadi)
        {
            baslangic();
            this.cariid = cariid;

            cmbCariler.Text = cariAdiSoyadi;
            cmbCariler.Enabled = false;
        }

        public void krediKartiListele()
        {
            dgAlanHesap.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select krediKartid, bankaHesapid, bankaAdi, hesapKesim, sonOdeme, kartLimit from sorBankaKrediKarti  where firmaid = " + firma.firmaid + " and silindimi = '0' order by bankaAdi asc");
            while (dr.Read())
            {
                dgAlanHesap.Rows.Add(dr["krediKartid"].ToString(), dr["bankaHesapid"].ToString(), dr["bankaAdi"].ToString(), dr["hesapKesim"].ToString(), dr["sonOdeme"].ToString(), dr["kartLimit"].ToString());
            }
            dgAlanHesap.ClearSelection();
        }
        private void frmBankaKrediKartiileOdeme_Load(object sender, EventArgs e)
        {

        }

        private void btnKrediKartihesabiTanimla_Click(object sender, EventArgs e)
        {
            frmBankaKrediKartiEkle frm = new frmBankaKrediKartiEkle();
            frm.Show();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (dgAlanHesap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Kredi Kartı Hesabı Seçmediniz.", firma.programAdi);
                dgAlanHesap.Select();
                return;
            }
            if (txtTutar.Text == "0")
            {
                MessageBox.Show("Tutar Girin", firma.programAdi);
                txtTutar.Select();
                return;
            }

            if (ComboboxItem.seciliMetinKontrolu(cmbESubeler) == false)
            {
                MessageBox.Show("Şubeyi listeden seçin", firma.programAdi);
                cmbESubeler.Select();
                return;
            }
            if (ComboboxItem.seciliMetinKontrolu(cmbEKullanicilar) == false)
            {
                MessageBox.Show("Kullanıcıyı listeden seçin", firma.programAdi);
                cmbEKullanicilar.Select();
                return;
            }
            if (cmbCariler.SelectedIndex >= 0) cariid = Convert.ToInt32(listeler.getCariid()[cmbCariler.SelectedIndex]);
            string eklenenBankaislemid = veri.getdatacell("Exec spSetBankaislemleri " + bankaislemid + "," + dgAlanHesap.CurrentRow.Cells["bankaHesapid"].Value + "," + dgAlanHesap.CurrentRow.Cells["krediKartid"].Value + ",0,'" + txtTaksitSayisi.Text + "',0,0,0," + cariid + "," + txtTutar.Text.Replace(".", "").Replace(",", ".") + ",'" + txtDovizKuru.Text + "'," + txtDovizDegeri.Text.Replace(".", "").Replace(",", ".") + ",'" + txtAcklama.Text + "','Kredi Kartı ile Ödeme','" + dtİslemTarihi.Value + "'," + firma.firmaid + "," + Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)) + "," + Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)) + "");
            if (grupid != 0)
            {
                acikHesap.ekle(0, ticaretAyrintiid, 0, 0, Convert.ToInt32(eklenenBankaislemid), cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), Convert.ToDouble(txtTutar.Text), 0, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Kredi Kartı", islemTipi, "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, 0);
                acikHesap.ekle(0, ticaretAyrintiid, 0, 0, Convert.ToInt32(eklenenBankaislemid), cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), 0, Convert.ToDouble(txtTutar.Text), txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Kredi Kartı", "Ödeme", "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, 0);
            }
            else
            {
                acikHesap.ekle(0, ticaretAyrintiid, 0, 0, Convert.ToInt32(eklenenBankaislemid), cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), 0, Convert.ToDouble(txtTutar.Text), txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Kredi Kartı", "Ödeme", "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, duzenlemeBakiyesi);
            }
            if (_frmTicaret != null)
            {
                _frmTicaret.yeniKayit();
                ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
                SMSGonder();
            }
            this.Close();
        }
        double duzenlemeBakiyesi = 0;

        bool SMSGonder()
        {
            if (SmsYetkileri.Faturalı_Satıs)
            {
                int smsAdet = BakiyeGetir();
                if (smsAdet == 0) { MessageBox.Show("SMS Bakiyeniz Olmadığı İçin SMS Gönderilmedi Lütfen ELMAR YAZILIM İle İletişime Geçiniz!"); return false; }
                else
                {
                    var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid);
                    string telefon = "";
                    foreach (var adresKaydi in adresListesi)
                    {
                        telefon = adresKaydi.gsm;
                    }
                    if (telefon.Equals("")) { MessageBox.Show("Cariye Ait Telefon Numarası Bulunamadı!"); return false; }
                    string baslik = "ELMAR YZLM";
                    telefon = "0" + telefon;
                    DataTable dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%satış%' and FirmaID=" + firma.firmaid);
                    string mesaj = dtMesaj.Rows[0]["Mesaj"].ToString();
                    string value = SMSPaketi.SendSms(baslik,mesaj,telefon);
                    if (value != "20" && value != "30" && value != "40" && value != "70")
                    {
                        veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-1 where firmaid=" + firma.firmaid);
                        MessageBox.Show("SMS Gönderildi.");
                        veri.cmd("insert into tblMesajlar (mesajMetni,Baslik,cariid,firmaid,subeid,kullaniciid)values('" + mesaj + "','" + baslik + "'," + cariid + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                        //FİRMA
                        dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%tahsilat%' and FirmaID=" + firma.firmaid);
                        mesaj =cmbCariler.Text+" "+ dtMesaj.Rows[0]["Mesaj"].ToString();
                        dtMesaj = veri.getdatatable("select gsm, firmaid, subeAdi, subeid from tblFirmaSubeleri where subeid=" + firma.subeid + " and firmaid=" + firma.firmaid);
                        telefon = dtMesaj.Rows[0]["gsm"].ToString();
                        telefon = "0" + telefon;
                        value = Utility.SendSMS(telefon, mesaj);
                        if (value != "20" && value != "30" && value != "40" && value != "70")
                        {
                            veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-1 where firmaid=" + firma.firmaid);
                        }
                        Close();
                        return true;
                    }
                    else MessageBox.Show("Gönderilemedi!");
                }
            }
            return true;
        }

        private int BakiyeGetir()
        {
            try
            {

                int bakiye = Convert.ToInt32(veri.getdatacell("Select smsAdet from tblFirmaBilgileri Where firmaid = " + firma.firmaid + " and silindimi = '0'"));
                return bakiye;
            }
            catch
            {
                return 0;
            }
        }

        private void cmbESubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar, ComboboxItem.getSelectedValue(cmbESubeler));
        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDovizliTutar.Text = (Convert.ToDouble(txtTutar.Text) * Convert.ToDouble(txtDovizDegeri.Text)).ToString();
            }
            catch (Exception) { }
        }

        private void txtDovizKuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDovizDegeri.Text = "1";
                if (txtDovizKuru.SelectedIndex == 1) txtDovizDegeri.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
                else if (txtDovizKuru.SelectedIndex == 2) txtDovizDegeri.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
            }
            catch { }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            //if (_frmTicaret != null)
            //{
            //    _frmTicaret._pesinat = Convert.ToDouble(txtPesinat.Text);
            //    _frmTicaret.yeniKayit();
            //    ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
            //    this.Close();
            //}
            txtAcklama.Clear();
            txtTutar.Text = "0";
            txtDovizliTutar.Text = "0";
            txtTutar.Select();
            dgAlanHesap.ClearSelection();
            lblDurum.Text = "Temizlendi";
        }
    }
}