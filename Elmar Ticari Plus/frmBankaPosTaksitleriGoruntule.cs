using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmBankaPosTaksitleriGoruntule : Form
    {
        private long cariid = 0;
        private int grupid = 0;
        private long ticaretAyrintiid = 0;
        public frmTicaret _frmTicaret = null;
        public frmPesinSatis _frmPesinSatis = null;
        private string aciklama = "";
        private double tutar = 0;
        private int seciliPosid = 0;
        private int seciliBankaHesapid = 0;
        private string islemTipi = "";
        Button btn = null;
        private double genelTutar = 0;
        void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgTaksitOranlari);
            NesneGorselleri.kontrolEkle(panel3);
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
            listeler.doldurSube(cmbESubeler);

            //aktif pos listesi getiriliyor
            SqlDataReader dr = veri.getDatareader("Select distinct posid, posAdi from sorBankaPosTaksit_silinenler where silindimi = '0' and firmaid = " + firma.firmaid + " and aylikOran != -1 order by posid asc");
            while (dr.Read())
            {
                foreach (Button btn in pnlAna.Controls)
                {
                    if (btn.Tag.ToString() == dr["posAdi"].ToString())
                    {
                        btn.Visible = true;
                        btn.Tag = dr["posid"].ToString();
                        break;
                    }
                }
            }
        }


        public frmBankaPosTaksitleriGoruntule()
        {
            baslangic();
            txtTutar.Text = string.Format("{0:N}", 0);
        }


        public frmBankaPosTaksitleriGoruntule(long cariid, string cariAdiSoyadi, string tutar, string islemTipi, DateTime islemTarihi, int grupid, long ticaretAyrintiid, string aciklama)
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
            genelTutar = Convert.ToDouble(tutar);
            txtTutar.Text = string.Format("{0:n2}", Convert.ToDouble(tutar));
            txtNakit.Enabled = true;
            //txtTutar.Enabled = false;

            this.aciklama = aciklama;
        }

        void hesapla()
        {
            txtAcikHesapTutari.Text = (genelTutar - Convert.ToDouble(txtTutar.Text) - Convert.ToDouble(txtNakit.Text)).ToString();
        }
        public frmBankaPosTaksitleriGoruntule(long cariid, string cariAdiSoyadi)
        {
            baslangic();
            this.cariid = cariid;

            cmbCariler.Text = cariAdiSoyadi;
            cmbCariler.Enabled = false;
        }

        private void frmBankaPosTaksitleriGoruntule_Load(object sender, EventArgs e)
        {
            hesapla_AcikHesap(true);
        }

        private void btnBonusCard_Click(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(TextBox)) btn = (Button)sender;
            if (btn == null) return;
            picSeciliPos.Image = btn.Image;
            dgTaksitOranlari.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Exec spGetBankaPosTaksitleri " + btn.Tag.ToString() + ", '" + tutar.ToString().Replace(",", ".") + "', " + firma.firmaid);
            while (dr.Read())
            {
                lblBaslik.Text = dr["posAdi"].ToString() + " (" + dr["adi"].ToString() + ") Taksit Oranları";
                seciliPosid = Convert.ToInt32(dr["posid"]);
                seciliBankaHesapid = Convert.ToInt32(dr["bankaHesapid"]);
                dgTaksitOranlari.Rows.Add(dr["posTaksitid"].ToString(), dr["taksitSayisi"], dr["taksitTutari"], Convert.ToDouble(dr["toplamTutar"]));
            }
        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(true);
            btnBonusCard_Click(sender, e);
            hesapla();
        }
        void hesapla_AcikHesap(bool dovizKuruOtomatikGetirilsinmi)
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
                if (txtDovizDegeri.Text != "") pb = Convert.ToDouble(txtDovizDegeri.Text);
            }
            try { tutar = Convert.ToDouble(txtTutar.Text); }
            catch { }
            try
            {
                txtDovizliTutar.Text = (pb * (Convert.ToDouble(txtTutar.Text))).ToString();
            }
            catch (Exception)
            {
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTutar.Text == "0")
                {
                    MessageBox.Show("Tutarı girmediniz", firma.programAdi);
                    txtTutar.Select();
                    return;
                }
                if (dgTaksitOranlari.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Listeden bir taksit seçin", firma.programAdi);
                    return;
                }

                //if (cariid == 0)
                //{
                //    MessageBox.Show("Cari Seçmediniz", firma.programAdi);
                //    cmbCariler.Select();
                //    return;
                //}
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
                string eklenenBankaislemid = veri.getdatacell("Exec spSetBankaislemleri 0, " + seciliBankaHesapid + ", 0, " + seciliPosid + "," + dgTaksitOranlari.CurrentRow.Cells["taksitSayisi"].Value.ToString() + ",'" + dgTaksitOranlari.CurrentRow.Cells["taksitTutari"].Value.ToString().Replace(",", ".") + "', 0,0," + cariid + ", '" + tutar.ToString().Replace(',', '.') + "', '" + txtDovizKuru.Text + "', " + Convert.ToDouble(txtDovizDegeri.Text) + ", '" + txtAcklama.Text + "', 'Postan Tahsilat', '" + dtİslemTarihi.Value + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");
                if (grupid != 0)
                {
                    acikHesap.ekle(0, ticaretAyrintiid, 0, 0, Convert.ToInt32(eklenenBankaislemid), cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), 0, genelTutar, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Postan", islemTipi, "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, duzenlemeBakiyesi);
                    acikHesap.ekle(0, ticaretAyrintiid, 0, 0, Convert.ToInt32(eklenenBankaislemid), cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), tutar, 0, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Postan", "Tahsilat", "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, duzenlemeBakiyesi);
                }
                else
                {
                    acikHesap.ekle(0, ticaretAyrintiid, 0, 0, Convert.ToInt32(eklenenBankaislemid), cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), tutar, 0, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Postan", "Tahsilat", "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, duzenlemeBakiyesi);
                }
                if (_frmTicaret != null)
                {
                    _frmTicaret.yeniKayit();
                    ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
                    _frmTicaret.Select();
                    _frmTicaret.Focus();
                    _frmTicaret.Activate();
                    _frmTicaret.BringToFront();
                    //   SMSGonder();
                }
                if (_frmPesinSatis != null)
                {
                    _frmPesinSatis.yeniKayit();
                    ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
                    _frmPesinSatis.Select();
                    _frmPesinSatis.Focus();
                    _frmPesinSatis.Activate();
                    _frmPesinSatis.BringToFront();
                    //  SMSGonder();
                }
                if (Convert.ToDouble(txtNakit.Text) != 0)
                {
                    double borc = 0;
                    double alacak = 0;
                    //Açık Hesap Aktarılıyor

                    borc = Convert.ToDouble(txtNakit.Text);
                   string islemTuruMetni = "Tahsilat";
                   string aciklama1 = genelTutar.ToString() + " TL lik satıştan " + txtTutar.Text +" TL si postan çekildi " + txtNakit.Text + " TL nakit ödendi ";
                   if (Convert.ToDouble(txtAcikHesapTutari.Text) != 0)
                       aciklama1 = aciklama1 + txtAcikHesapTutari.Text + " TL açık hesaba aktarıldı.";
                        acikHesap.ekle(0, ticaretAyrintiid, 0, 0, 0, cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, dtİslemTarihi.Value, borc, alacak, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Açık Hesap", islemTuruMetni, "Kasa", aciklama1, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, 0);
                }
                this.Close();
            }
            catch (Exception hata)
            {
                //lblDurum.Text = 
                MessageBox.Show("Kaydedilirken hata oluştu. Hata Metni: " + hata.Message);

            }
        }
        double duzenlemeBakiyesi = 0;

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

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
                    string value = SMSPaketi.SendSms(baslik, mesaj, telefon);
                    if (value != "20" && value != "30" && value != "40" && value != "70")
                    {
                        veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-1 where firmaid=" + firma.firmaid);
                        MessageBox.Show("SMS Gönderildi.");
                        veri.cmd("insert into tblMesajlar (mesajMetni,Baslik,cariid,firmaid,subeid,kullaniciid)values('" + mesaj + "','" + baslik + "'," + cariid + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                        //FİRMA
                        dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%tahsilat%' and FirmaID=" + firma.firmaid);
                        mesaj = cmbCariler.Text + " " + dtMesaj.Rows[0]["Mesaj"].ToString();
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

        private void txtDovizKuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(true);
        }

        private void txtDovizDegeri_TextChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(false);
            btnBonusCard_Click(sender, e);
        }

        private void txtDovizliTutar_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cariid = listeler.getCariid()[cmbCariler.SelectedIndex];
        }

        private void cmbESubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar, ComboboxItem.getSelectedValue(cmbESubeler));
        }

        private void txtNakit_TextChanged(object sender, EventArgs e)
        {
            hesapla();
        }
    }
}