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
    public partial class frmOdemeVeTahsilat : Form
    {
        private long cariid = 0;
        private int grupid = 0;
        private long acikHesapid = 0, ticaretAyrintiid = 0;

        public frmTicaret _frmTicaret = null;
        public frmPesinSatis _frmTicaret1 = null;
        string aciklama = "";
        public frmOdemeVeTahsilat(long cariid, string cariAdiSoyadi)
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
        }
        public frmOdemeVeTahsilat(long cariid, string cariAdiSoyadi, string tutari, string islemTipi, DateTime islemTarihi, int grupid, long ticaretAyrintiid, string aciklama, double duzenlemeBakiyesi)
        {
            baslangic();
            this.cariid = cariid;
            this.grupid = grupid;
            this.ticaretAyrintiid = ticaretAyrintiid;
            this.duzenlemeBakiyesi = duzenlemeBakiyesi;
            cmbCariler.Text = cariAdiSoyadi;
            if (cariid != 0)
            {
                cmbCariler.Enabled = false;
                btnCariAra.Enabled = false;
                btnCariEkle.Enabled = false;
            }


            cmbislemTipi.Items.Add("Alış");
            cmbislemTipi.Items.Add("Satış");
            this.Text = "Ödeme, Tahsilat, Alış, Satış Oluştur";
            this.cmbislemTipi.Text = islemTipi;
            dtİslemTarihi.Value = islemTarihi;

            cmbislemTipi.Enabled = false;
            dtİslemTarihi.Enabled = false;
            cmbEKullanicilar.Enabled = false;
            cmbESubeler.Enabled = false;

            txtTutar.Text = tutari;
            txtTutar.Enabled = false;

            txtPesinat.Visible = true;
            lblPesinat.Visible = true;
            txtPesinat.Select();

            this.aciklama = aciklama;
        }
        public frmOdemeVeTahsilat(long acikHesapid, long ticaretAyrintiid, long cariid, string cariAdiSoyadi, string belgeNo, double tutar, string doviz, double dovizDegeri, string islemTipi, DateTime islemTarihi, string aciklama, double eskiBakiye)
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
            cmbislemTipi.Items.Add("Alış");
            cmbislemTipi.Items.Add("Satış");
            if (islemTipi.Contains("Tahsilat")) cmbislemTipi.Text = "Tahsilat";
            else if (islemTipi.Contains("Ödeme")) cmbislemTipi.Text = "Ödeme";
            else if (islemTipi.Contains("Satış")) cmbislemTipi.Text = "Satış";
            else if (islemTipi.Contains("Alış")) cmbislemTipi.Text = "Alış";
            dtİslemTarihi.Value = islemTarihi;
            txtAcklama.Text = aciklama;
            txtEskiBakiye.Text = String.Format("{0:n2}", eskiBakiye);
            this.Text = "Ödeme, Tahsilat, Alış, Satış Düzenle";
        }
        void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            NesneGorselleri.kontrolEkle(this);
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
            listeler.doldurSube(cmbESubeler);

        }
        private void frmOdemeVeTahsilat_Load(object sender, EventArgs e)
        {
            cmbCariler.Select();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

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

                double borc = 0; double alacak = 0; string islemTuruMetni = "";
                //Açık Hesap Aktarılıyor
                borc = 0; alacak = 0;
                DateTime odemeTarihi = Convert.ToDateTime(null);
                if (this.cmbislemTipi.Text == "Tahsilat")
                {
                    borc = Convert.ToDouble(txtTutar.Text);
                    islemTuruMetni = "Tahsilat";
                    odemeTarihi = dtİslemTarihi.Value;
                }
                else if (this.cmbislemTipi.Text == "Ödeme")
                {
                    alacak = Convert.ToDouble(txtTutar.Text);
                    islemTuruMetni = "Ödeme";
                    odemeTarihi = dtİslemTarihi.Value;
                }
                else if (this.cmbislemTipi.Text == "Satış")
                {
                    alacak = Convert.ToDouble(txtTutar.Text);
                    islemTuruMetni = "Satış";
                }
                else if (this.cmbislemTipi.Text == "Alış")
                {
                    borc = Convert.ToDouble(txtTutar.Text);
                    islemTuruMetni = "Alış";
                }
                acikHesap.ekle(acikHesapid, ticaretAyrintiid, 0, 0, 0, cariid, dtİslemTarihi.Value, odemeTarihi, vadeTarihi.Value, borc, alacak, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Açık Hesap", islemTuruMetni, "Kasa", txtAcklama.Text, "", txtBelgeNo.Text, "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, duzenlemeBakiyesi);

                if (Convert.ToDouble(txtPesinat.Text) != 0)
                {
                    borc = 0;
                    alacak = 0;
                    //Açık Hesap Aktarılıyor
                    if (this.cmbislemTipi.Text == "Satış")
                    {
                        borc = Convert.ToDouble(txtPesinat.Text);
                        islemTuruMetni = "Tahsilat";
                    }
                    else if (this.cmbislemTipi.Text == "Alış")
                    {
                        alacak = Convert.ToDouble(txtPesinat.Text);
                        islemTuruMetni = "Ödeme";
                    }
                    acikHesap.ekle(acikHesapid, ticaretAyrintiid, 0, 0, 0, cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, vadeTarihi.Value, borc, alacak, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Açık Hesap", islemTuruMetni, "Kasa", txtAcklama.Text, "", txtBelgeNo.Text, "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, 0);
                }
                //SMSGonder();
                btnTemizle2.PerformClick();
                lblDurum.Text = "Kaydedildi";
                DialogResult = DialogResult.OK;
                if (acikHesapid != 0) this.Close();
                return true;
            }
            catch (Exception hata)
            {
                lblDurum.Text = "kaydedilirken hata oluştu. Hata Metni: " + hata.Message;
                return false;
            }
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

        //TAHSİLAT
        //ÖDEME
        //BORÇ
        //SATIŞ
        //İNDİRİM
        //void SMSGonder()
        //  {
        //      if (SmsYetkileri.Faturalı_Satıs)
        //      {
        //          int smsAdet = BakiyeGetir();
        //          if (smsAdet == 0) { MessageBox.Show("SMS Bakiyeniz Olmadığı İçin SMS Gönderilmedi Lütfen ELMAR YAZILIM İle İletişime Geçiniz!"); }
        //          else
        //          {
        //              var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid);
        //              string telefon = "";
        //              foreach (var adresKaydi in adresListesi)
        //              {
        //                  telefon = adresKaydi.gsm;
        //              }
        //              if (telefon.Equals("")) { MessageBox.Show("Cariye Ait Telefon Numarası Bulunamadı!"); }
        //              string baslik = "ELMAR YZLM";
        //              telefon = "0" + telefon;
        //              DataTable dtMesaj;
        //              if (cmbislemTipi.SelectedIndex == 0)
        //              {
        //                  dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%ödeme%' and FirmaID=" + firma.firmaid);
        //              }
        //              else if (cmbislemTipi.SelectedIndex == 1)
        //              {
        //                  dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%tahsilat%' and FirmaID=" + firma.firmaid);
        //              }
        //              else
        //              {
        //                  dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%satış%' and FirmaID=" + firma.firmaid);
        //              }

        //              string mesaj = dtMesaj.Rows[0]["Mesaj"].ToString() + " Toplam tutar:" + txtTutar.Text + " TL";
        //              //string value = SMSPaketi.SendSms(baslik,mesaj,telefon);
        //              string value = Utility.SendSMS(telefon, mesaj);
        //              if (value != "20" && value != "30" && value != "40" && value != "70")
        //              {
        //                  veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-1 where firmaid=" + firma.firmaid);
        //                  veri.cmd("insert into tblMesajlar (mesajMetni,Baslik,cariid,firmaid,subeid,kullaniciid)values('" + mesaj + "','" + baslik + "'," + cariid + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
        //                  dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%tahsilat%' and FirmaID=" + firma.firmaid);
        //                  mesaj = cmbCariler.Text + " " + dtMesaj.Rows[0]["Mesaj"].ToString();
        //                  dtMesaj = veri.getdatatable("select gsm, firmaid, subeAdi, subeid from tblFirmaSubeleri where subeid=" + firma.subeid + " and firmaid=" + firma.firmaid);
        //                  telefon = dtMesaj.Rows[0]["gsm"].ToString();
        //                  telefon = "0" + telefon;
        //                  value = Utility.SendSMS(telefon, mesaj);
        //                  if (value != "20" && value != "30" && value != "40" && value != "70")
        //                  {
        //                      veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-1 where firmaid=" + firma.firmaid);
        //                  }

        //                  Close();
        //              }
        //              else MessageBox.Show("Gönderilemedi!");
        //          }
        //      }
        //  }

        double duzenlemeBakiyesi = 0;

        private void cmbESubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar, ComboboxItem.getSelectedValue(cmbESubeler));
        }

        private void txtEskiBakiye_TextChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(true);
        }

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
                txtDovizliTutar.Text = String.Format("{0:n2}", (pb * Convert.ToDouble(txtTutar.Text)));
                bakiyeHesapla();
            }
            catch (Exception hata)
            {
                lblDurum.Text = hata.Message;
            }
        }

        void bakiyeHesapla()
        {
            try
            {
                short isaret = 1;
                short isaret2 = 1;
                if (lblDurumEskiBakiye.Text == "Alacaklı") isaret2 = -1;
                if (cmbislemTipi.Text == "Tahsilat" || cmbislemTipi.Text == "Alış") isaret = 1;
                else if (cmbislemTipi.Text == "Ödeme" || cmbislemTipi.Text == "Satış") isaret = -1;
                txtİslemTutarı.Text = String.Format("{0:n2}", (isaret * (Convert.ToDouble(txtDovizliTutar.Text) - Convert.ToDouble(txtPesinat.Text))));
                txtYeniBakiye.Text = String.Format("{0:n2}", (Convert.ToDouble(txtEskiBakiye.Text) - Convert.ToDouble(txtİslemTutarı.Text) * isaret2));
                if (lblDurumEskiBakiye.Text == "Alacaklı")
                {
                    if (Convert.ToDouble(txtYeniBakiye.Text) < 0) lblDurumYeniBakiye.Text = "Borçlu";
                    else if (Convert.ToDouble(txtYeniBakiye.Text) > 0) lblDurumYeniBakiye.Text = "Alacaklı";
                    else lblDurumYeniBakiye.Text = "-";
                }
                else
                {
                    if (Convert.ToDouble(txtYeniBakiye.Text) < 0) lblDurumYeniBakiye.Text = "Alacaklı";
                    else if (Convert.ToDouble(txtYeniBakiye.Text) > 0) lblDurumYeniBakiye.Text = "Borçlu";
                    else lblDurumYeniBakiye.Text = "-";
                }
                txtYeniBakiye.Text = txtYeniBakiye.Text.Replace("-", "");
            }
            catch (Exception hata)
            {
                lblDurum.Text = hata.Message;
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

        private void btnCariAra_Click(object sender, EventArgs e)
        {
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCari();
        }

        void getCari()
        {
            try
            {
                cariid = listeler.getCariid()[cmbCariler.SelectedIndex];
            }
            catch
            {

                if (cmbCariler.Text.Trim().Length == 0 && cmbCariler.Text.Length < 12) return;
                var c = cariBilgileri.bul_RIFDNo(cmbCariler.Text);
                if (c == null) return;
                cmbCariler.Text = "";
                cariid = c.cariid;
                cmbCariler.Text = c.adiSoyadi;
            }

            try
            {
                string sql = "select sum(bakiye) from sorCariBakiye where firmaid = " + firma.firmaid + " and cariid = " + cariid;
                if (this.ticaretAyrintiid > 0) sql = "select sum(bakiye) from sorCariBakiye where firmaid = " + firma.firmaid + " and cariid = " + cariid;
                txtEskiBakiye.Text = String.Format("{0:n2}", -1 * Convert.ToDouble(veri.getdatacell(sql)) + duzenlemeBakiyesi);
                if (Convert.ToDouble(txtEskiBakiye.Text) < 0) lblDurumEskiBakiye.Text = "Alacaklı";
                else if (Convert.ToDouble(txtEskiBakiye.Text) > 0) lblDurumEskiBakiye.Text = "Borçlu";
                else lblDurumEskiBakiye.Text = "-";
                txtEskiBakiye.Text = txtEskiBakiye.Text.Replace("-", "");
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

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            kaydet();
            this.Close();
            // SMSGonder();
        }
        rapor rpr;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            raporOlustur();
            rpr.onizleme();
            kaydet();
            //   SMSGonder();

        }
        bool raporOlustur()
        {
            rpr = new rapor();
            rpr.setKagitboyutu(rpr._kagitGenisligi, (int)(rpr._kagitYuksekligi / 2));
            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 10;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari " + cmbislemTipi.Text + " Fişi", new Font("Arial", 13, FontStyle.Bold), new Point(10, y)));
            y += 8;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 2;
            rpr.ekleYazi(new rapor.yazi("Cari Adı: " + cmbCariler.Text, new Rectangle(10, y, rpr._kagitGenisligi - 20, 4), false));
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 2;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Tutar: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(txtTutar.Text, new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, true)); y += 5;
            if (Convert.ToDouble(txtPesinat.Text) != 0)
            {
                rpr.ekleSabitYazi(new rapor.sabitYazi("Peşinat: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
                rpr.ekleYazi(new rapor.yazi(txtPesinat.Text, new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, true)); y += 5;
            }
            rpr.ekleSabitYazi(new rapor.sabitYazi("Döviz: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(txtDovizKuru.Text, new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 5;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Döviz Kuru: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(txtDovizDegeri.Text, new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, true)); y += 5;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Dövizli Tutar(TL): ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(txtDovizliTutar.Text, new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, true)); y += 5;
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Tipi: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(cmbislemTipi.Text, new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 5;
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Tarihi: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(dtİslemTarihi.Value.ToShortDateString(), new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 5;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Açıklama: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(txtAcklama.Text, new Rectangle(160, y, 150, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 7;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 2;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Eski Bakiye: ", new Font("Arial", 9, FontStyle.Bold), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(txtEskiBakiye.Text + " " + lblDurumEskiBakiye.Text + " TL ", new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 6;
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Tutarı: ", new Font("Arial", 9, FontStyle.Bold), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(txtİslemTutarı.Text + " TL ", new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 6;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Yeni Bakiye: ", new Font("Arial", 9, FontStyle.Bold), new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi(txtYeniBakiye.Text + " " + lblDurumYeniBakiye.Text + " TL ", new Rectangle(160, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 8;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 2;
            rpr.ekleYazi(new rapor.yazi(firmaBilgileri.adi + " " + firmaBilgileri.soyadi + "  " + firmaBilgileri.webSitesi + "  " + subeBilgileri.tel + "  " + subeBilgileri.adres + "  " + subeBilgileri.altBilgiNotu, new Rectangle(10, y, rpr._kagitGenisligi - 20, 7), false));
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 4;
            if (chbSenet.Checked)
            {
                rpr.ekleYazi(new rapor.yazi("Ödeme Tarihi", new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi("Türk Lirası", new Rectangle(55, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi("Kuruş", new Rectangle(70, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi("No", new Rectangle(95, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false));
                y += 3;
                rpr.ekleYazi(new rapor.yazi(vadeTarihi.Value.ToShortDateString(), new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi("#" + txtTutar.Text + "#", new Rectangle(55, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false));
                y += 4;
                rpr.ekleYazi(new rapor.yazi("İs bu Muharrer senedim__" + vadeTarihi.Value.ToShortDateString() + "__Tarihinde" + " Sayın__" + cmbCariler.Text + "__vayahut emruhavale___", new Point(30, y)));
                y += 4;
                rpr.ekleYazi(new rapor.yazi("Yukarıda yazılı yalnız________________Türk Lirası _________ Kuruş ödeyeceği Bedeli_______________Ahzolmuştur.", new Point(30, y)));
                y += 4;
                rpr.ekleYazi(new rapor.yazi("İş Bu bono Vadersine ödenmediği taktirde müteakip bonolarında muacceliyet kesbedeceiğin, İhtilaf", new Point(30, y)));
                y += 3;
                rpr.ekleYazi(new rapor.yazi("Vukuunda____________" + "____Mahkemelerinin selahiyetini şimdiden kabul eyleri____", new Point(30, y)));
                y += 5;
                rpr.ekleYazi(new rapor.yazi("İsim/Ünvanı:__________________________________________" + "\t   Düzenlenme Tar. ___/___/20___", new Point(30, y)));
                y += 4;
                rpr.ekleYazi(new rapor.yazi("Adres            :__________________________________________" + "\t\t   İmza          İmza", new Point(30, y)));
                y += 4;
                rpr.ekleYazi(new rapor.yazi("_______________________________________________________", new Point(30, y)));
                y += 4;
                rpr.ekleYazi(new rapor.yazi("V.D;No su/T.C.Kimlik No:_______________________________", new Point(30, y)));
                y += 4;
                rpr.ekleYazi(new rapor.yazi("Kefil            :_______________________________", new Point(30, y)));
                y += 4;
                rpr.ekleYazi(new rapor.yazi("V.D;No su/T.C.Kimlik No:_______________________________", new Point(30, y)));
            }
            return true;
        }

        private void btnKaydet2_Click(object sender, EventArgs e)
        {
            if (firma.firmaid == 16571 && lblDurumYeniBakiye.Text.Equals("Borçlu"))
            {
                MessageBox.Show("Öğrencinin kartında yeterli bakiye bulunmamaktadır ..!\n Lütfen bakiye yükleyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            kaydet();
            this.Close();
        }

        private void btnKaydetveYazdir2_Click(object sender, EventArgs e)
        {
            if (cariid == 0)
            {
                MessageBox.Show("Cari Seçmediniz", firma.programAdi);
                cmbCariler.Select();
                return;
            }
            raporOlustur();
            rpr.onizleme();
            kaydet();
            this.Close();
        }

        private void cmbCariler_TextChanged(object sender, EventArgs e)
        {
            getCari();
        }

        private void frmOdemeVeTahsilat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4) kaydet();
            else if (e.KeyCode == Keys.F9) btnTemizle2.PerformClick();
        }

        private void frmOdemeVeTahsilat_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnTemizle2_Click(object sender, EventArgs e)
        {
            if (_frmTicaret != null)
            {
                _frmTicaret._pesinat = Convert.ToDouble(txtPesinat.Text);
                _frmTicaret.yeniKayit();
                ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
                this.Close();
            }
            if (_frmTicaret1 != null)
            {
                _frmTicaret1.cariid = cariid;
                try
                {
                    var l1 = ticaretAyrinti2.listTicaretAyrinti.Where(u => u.servereYuklendimi == false && u.islemTamamlandimi == false).OrderBy(u => u.grupid).First();
                    if (l1 != null) l1.cariid = cariid;
                }
                catch
                { }
                _frmTicaret1.yeniKayit();
                ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            duzenlemeBakiyesi = 0;
            txtAcklama.Clear();
            txtTutar.Text = "0";
            txtDovizliTutar.Text = "0";
            txtEskiBakiye.Text = txtYeniBakiye.Text;
            txtİslemTutarı.Text = "0";
            txtTutar.Select();
            lblDurum.Text = "Temizlendi";
        }
    }
}