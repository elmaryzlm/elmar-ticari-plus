using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace Elmar_Ticari_Plus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
                NesneGorselleri.form(this, false);
                this.WindowState = FormWindowState.Maximized;
                this.Text = firma.programAdi;
                pnlSol.Size = new Size(127, 524);
                if (firma.hastane == "1")
                {
                    btnSatis.Visible = false;
                    btnStokCikis.Visible = true;
                }
                if (firma.personel == "0")
                {
                    btnPersonel.Visible = false;
                }
                lblSube.Text = "Şube: " + subeBilgileri.subeAdi;
                lblKullanici.Text = "Kullanıcı: " + firma.kullaniciAdi;
                lblFirma.Text = firmaBilgileri.adi + " " + firmaBilgileri.soyadi;
                if (firmaBilgileri.demomu == "1")
                {
                    lblDemo.Visible = true;
                    lblDemo.Text = "Demo Versiyon Kalan Gün: " + firmaBilgileri.demoKalanGun.ToString();
                }
            }
            catch (Exception hata)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDovizyenile_Click(sender, e);
            menuSec(pnlStok);
            alarm.kontrolMotorunuCalistir();
            Thread kanal = new Thread(new ThreadStart(logoGetir));
            kanal.Start();
            try
            {
                richTextBox1.Text = veri.getdatacell("Select top 1 uyariMetni from tblUyarilar where firmaid = " + firma.firmaid + " and aktifmi = 1 order by uyariid desc");
                if (richTextBox1.Text.Length > 1) pnlUyari.Visible = true;
                pnlUyari.BringToFront();
                this.Refresh();
            }
            catch
            { }
        }

        public void logoGetir()
        {
            try
            {
                this.BackgroundImage = null;
                Stream s = File.Open(Application.StartupPath + "\\KullanıcıResimleri\\logo\\logo" + firma.firmaid + ".png", FileMode.Open);
                Image temp = Image.FromStream(s);
                s.Close();
                this.BackgroundImage = temp;

            }
            catch
            {
                try
                {
                    Image img = elmarDosyaislemleri.resimindir("logo/logo" + firma.firmaid + ".png");
                    if (img != null) this.BackgroundImage = img;
                    else if (img == null && firma.programAdi.Contains("BMS")) this.BackgroundImage = Properties.Resources.arkaplan1;
                    else this.BackgroundImage = Properties.Resources.arkaplan;
                    //this.BackgroundImage.Save(Application.StartupPath + "\\KullanıcıResimleri\\logo\\logo" + firma.firmaid + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception hata)
                {
                }
            }
        }

        private void pnlStok_Paint(object sender, PaintEventArgs e)
        {
        }

        void menuSec(FlowLayoutPanel panel)
        {
            pnlSol.Visible = true;
            foreach (FlowLayoutPanel item in pnlSol.Controls)
            {
                item.Visible = false;
            }
            panel.Visible = true;
            pnlDovizkuru.Visible = true;
            panel.BringToFront();
        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alarm.programiKapat == true)
            {
                try { Application.OpenForms["frmGiris"].Close(); }
                catch { }
                try { Application.OpenForms["frmYukle"].Close(); }
                catch { }
                return;
            }
            DialogResult d = MessageBox.Show("Program Tamamen Kapatılsın mı?", "Program Kullanımı Süresi=" + firma.sw.Elapsed.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                try { veri.cmd("update tblFirmaKullanicilari set onlinemi='0' where kullaniciid = " + firma.kullaniciid + ""); }
                catch { }
                try { Application.OpenForms["frmGiris"].Close(); }
                catch { }
                try { Application.OpenForms["frmYukle"].Close(); }
                catch { }
                alarm.programiKapat = false;
                alarm.kontrolMotorunuDurdur();
                Application.ExitThread();
                Environment.Exit(0);
            }
            else if (d == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnStokGiris_Click(object sender, EventArgs e)
        {

            if (!yetkiler.Faturasız_Alış)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.faturasizAlis);
            frm.Show();
        }

        private void btnSatisalt_Click(object sender, EventArgs e)
        {

            if (!yetkiler.Faturasız_Satış)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.faturasizSatis);
            frm.Show();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {

            if (!yetkiler.Satış_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            menuSec(pnlSatis);
        }

        private void btnStok_Click(object sender, EventArgs e)
        {

            if (!yetkiler.Stok_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            menuSec(pnlStok);
        }

        private void btnCariislemleri_Click(object sender, EventArgs e)
        {
            frmCariKartislemleri frm = new frmCariKartislemleri();
            frm.Show();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {

            if (!yetkiler.Cari_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            menuSec(pnlCari);
        }

        private void btnStokkartListesi_Click(object sender, EventArgs e)
        {
            frmStokKartlari frm = new frmStokKartlari();
            frm.Show();
        }

        private void btnStokRaporlari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Raporu_Görüntüle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaretRaporlari frm = new frmTicaretRaporlari(frmTicaretRaporlari.formTipi.alis);
            frm.Show();
        }

        private void btnStokkartEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Kart_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmStokKartEkle frm = new frmStokKartEkle();
            frm.Show();
        }

        private void btnCariKartEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCariKartEkle frm = new frmCariKartEkle();
            frm.Show();
        }

        private void btnCekSenet_Click(object sender, EventArgs e)
        {

            if (!yetkiler.Çek_Senet_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            menuSec(pnlCekSenet);
        }

        private void btnKendiCekim_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kendi_Çekim)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCekSenetListele frm = new frmCekSenetListele(frmCekSenetListele.formTipi.kendiCekim);
            frm.Show();
        }

        private void btnKendiSenedim_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kendi_Senedim)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCekSenetListele frm = new frmCekSenetListele(frmCekSenetListele.formTipi.kendiSenedim);
            frm.Show();
        }

        private void btnMusteriCeki_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Müşteri_Çeki)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCekSenetListele frm = new frmCekSenetListele(frmCekSenetListele.formTipi.musteriCeki);
            frm.Show();
        }

        private void btnMusteriSenedi_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Müşteri_Senedi)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCekSenetListele frm = new frmCekSenetListele(frmCekSenetListele.formTipi.musteriSenedi);
            frm.Show();
        }

        private void btnTeklifSiparis_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Teklif_Sipariş_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            menuSec(pnlTeklifSiparis);
        }

        private void btnAyrintiliStokkartEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Kart_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmYeniAyrintiliStokkartEkle frm = new frmYeniAyrintiliStokkartEkle();
            frm.Show();
        }

        private void btnFaturaliSatis_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Faturalı_Satış)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.faturaliSatis);
            frm.Show();
        }

        private void pnlSol_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTeklifOlustur_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Teklif_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.teklifOlustur);
            frm.Show();
        }

        private void btnSiparisOlustur_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Sipariş_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.siparisOlustur);
            frm.Show();
        }

        private void btnFaturaliAlis_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Faturalı_Alış)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.faturaliAlis);
            frm.Show();
        }

        private void btnUrunTransferi_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Ürün_Transferi)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.stokTransferi);
            frm.Show();
        }

        private void btniade_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Satış_İade)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.satisiade);
            frm.Show();
        }

        private void btnAlisiade_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Alış_İade)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.alisiade);
            frm.Show();
        }

        private void btnSatisRaporlari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Satış_Raporu_Görüntüle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaretRaporlari frm = new frmTicaretRaporlari(frmTicaretRaporlari.formTipi.satis);
            frm.Show();
        }

        private void btnTeklifSiparisRapor_Click(object sender, EventArgs e)
        {
            frmTicaretRaporlari frm = new frmTicaretRaporlari(frmTicaretRaporlari.formTipi.siparisTeklif);
            frm.Show();
        }

        private void btnSatisUrunRaporlari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Satış_Raporu_Görüntüle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaretUrunRaporlari frm = new frmTicaretUrunRaporlari(frmTicaretUrunRaporlari.formTipi.satis);
            frm.Show();
        }

        private void btnAlisUrunRaporlari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Raporu_Görüntüle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaretUrunRaporlari frm = new frmTicaretUrunRaporlari(frmTicaretUrunRaporlari.formTipi.alis);
            frm.Show();
        }
        private void btnProgramikapat_Click(object sender, EventArgs e)
        {

        }

        private void btnKullanicidegis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oturumu Kapatmak istiyormusunuz? Açık Formlar kapatılacak", firma.programAdi, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void btnHesapmakinesi_Click(object sender, EventArgs e)
        {

        }

        private void btnBanka_Click(object sender, EventArgs e)
        {

            if (!yetkiler.Banka_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            menuSec(pnlBanka);
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Personel_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            frmPersonelAna frm = new frmPersonelAna();
            frm.Show();
        }

        private void btnBankalarListesi_Click(object sender, EventArgs e)
        {
            frmBankalar frm = new frmBankalar();
            frm.Show();
        }

        private void btnBankaHesaplarim_Click(object sender, EventArgs e)
        {
            frmBankaHesaplari frm = new frmBankaHesaplari();
            frm.Show();
        }

        private void btnPosTanimlamalari_Click(object sender, EventArgs e)
        {
            frmBankaPos frm = new frmBankaPos();
            frm.Show();
        }

        private void btnKrediKartlarim_Click(object sender, EventArgs e)
        {
            frmBankaKrediKarti frm = new frmBankaKrediKarti();
            frm.Show();
        }

        private void btnTeklifSiparisUrunRaporlari_Click(object sender, EventArgs e)
        {
            frmTicaretUrunRaporlari frm = new frmTicaretUrunRaporlari(frmTicaretUrunRaporlari.formTipi.siparisTeklif);
            frm.Show();
        }

        private void btnCanliStok_Click(object sender, EventArgs e)
        {

            if (!yetkiler.Canlı_Stok_Görüntüle)
            {
                yetkiler.mesajVer();
                return;
            }

            frmCanliStok frm = new frmCanliStok(false);
            frm.Show();
        }

        private void btnTanımlar_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Tanımlar_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimlamalar frm = new frmTanimlamalar();
            frm.Show();
        }

        private void btnYardim_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\Yardım.exe", "0é" + firma.kullaniciid.ToString());
            }
            catch (Exception hata)
            {
                MessageBox.Show("Yardım Programı Çalıştırılırken bir hata oluştu.\n Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnCariListesi_Click(object sender, EventArgs e)
        {
            frmAyrintiliCariListele frm = new frmAyrintiliCariListele(null);
            frm.Show();
        }

        private void btnBankaislemleri_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Pos_ile_Tahsilat)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaPosTaksitleriGoruntule frm = new frmBankaPosTaksitleriGoruntule();
            frm.Show();
        }

        private void btnYetkiler_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Yetkiler_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            frmFirmaKullaniciYetkileri frm = new frmFirmaKullaniciYetkileri();
            frm.Show();
        }

        private void btnGiderlerveMasraflar_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Masraf_Kartı_Görüntüle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmMasraflar frm = new frmMasraflar();
            frm.Show();
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kasa_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            menuSec(pnlKasa);
        }

        private void btnGelirler_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kasa_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            frmGelirler frm = new frmGelirler();
            frm.Show();
        }

        private void btnGelirGiderRaporlari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Masraf_Kartı_Görüntüle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmGelirGiderRaporlari frm = new frmGelirGiderRaporlari();
            frm.Show();
        }

        private void btnGunlukKasa_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Günlük_Kasa)
            {
                yetkiler.mesajVer();
                return;
            }
            frmGunlukKasa frm = new frmGunlukKasa();
            frm.Show();
        }

        private void btnDovizyenile_Click(object sender, EventArgs e)
        {
            try
            {
                //    DialogResult result = MessageBox.Show("Döviz Bilgilerini Elle Girmek İster Misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (result == DialogResult.Yes)
                //    {
                //        if (new frmDoviz().ShowDialog() != System.Windows.Forms.DialogResult.OK) bilgiler.dovizVerileri.dovizVerileriniguncelle();
                //    }
                bilgiler.dovizVerileri.dovizVerileriniguncelle();

                dovizBilgileriniLabellereAl();
            }
            catch (Exception hata)
            {

            }
        }

        private void dovizBilgileriniLabellereAl()
        {
            lblEUROalis.Text = bilgiler.dovizVerileri.dEuroalis.ToString();
            lblEUROsatis.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
            lblUSDalis.Text = bilgiler.dovizVerileri.dDolaralis.ToString();
            lblUSDsatis.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
        }

        private void programıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc");
            }
            catch
            {
                MessageBox.Show("Hesap Makinesi Bulunamadı", firma.programAdi);
            }
        }

        private void btnStokCikis_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Faturasız_Satış)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTicaret frm = new frmTicaret(frmTicaret.formTipi.stokCikis);
            frm.Show();
        }

        private void btnCariEkstresi_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Diğer_Cari_Raporlarına_Erişim)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCariEkstresi frm = new frmCariEkstresi();
            frm.Show();
        }

        private void btnTahsilatOdemeRaporlari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Tahsilat_Ödeme_Raporları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCariTahsilatOdemeRaporlari frm = new frmCariTahsilatOdemeRaporlari();
            frm.Show();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Yetkiler_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            frmLog frm = new frmLog();
            frm.Show();
        }

        private void btnAlacakBorcRaporlari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Alacak_Borç_Raporlari)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCariAlacakBorcRaporlari frm = new frmCariAlacakBorcRaporlari();
            frm.Show();
        }

        private void btnDetayliCariEkstreRaporu_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Ürün_Raporları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCariDetayliEkstreRaporu frm = new frmCariDetayliEkstreRaporu();
            frm.Show();
        }

        private void btnAyrintiliKasa_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Ayrıntılı_Kasa)
            {
                yetkiler.mesajVer();
                return;
            }
            frmAyrintiliKasa frm = new frmAyrintiliKasa();
            frm.Show();
        }

        private void btnUyariyiKapat_Click(object sender, EventArgs e)
        {
            pnlUyari.Visible = false;
            this.Refresh();
        }

        private void btnMesajlar_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\Elmar Mesaj Paneli.exe", firma.parametreGegerleriniOlustur());
            }
            catch (Exception hata)
            {
                MessageBox.Show("Mesaj Paneli Programı Çalıştırılırken bir hata oluştu.\n Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnKarZararAnalizi_Click(object sender, EventArgs e)
        {
            frmKasaKarZararAnalizi frm = new frmKasaKarZararAnalizi();
            frm.Show();
        }

        private void btnBankaRaporlari_Click(object sender, EventArgs e)
        {
            frmBankaRaporlari frm = new frmBankaRaporlari();
            frm.Show();
        }

        private void btnParaYatirParaCek_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Para_Yatır___Para_Çek)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaParaYatirParaCek frm = new frmBankaParaYatirParaCek();
            frm.Show();
        }

        private void btnBankaKasaParaTransferi_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Para_Transferi)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaKasaParaTransferi frm = new frmBankaKasaParaTransferi();
            frm.Show();
        }

        private void btnHavaleEftislemi_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Gelen_Havale)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaHavaleEft2 frm = new frmBankaHavaleEft2();
            frm.Show();
        }

        private void btnKrediKartiileOdeme_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kredi_Kartı_ile_Ödeme)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaKrediKartiileOdeme frm = new frmBankaKrediKartiileOdeme();
            frm.Show();
        }

        private void sıcakSatışAktarımModülüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSicakSatisAktarimModulu frm = new frmSicakSatisAktarimModulu();
            frm.Show();
        }

        private void etiketYazdırmaModülüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokkartBarkodYazdir frm = new frmStokkartBarkodYazdir();
            frm.Show();
        }

        private void elTerminaliFaturaDizaynModülüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPDAFaturaDuzenle frm = new frmPDAFaturaDuzenle();
            frm.Show();
        }

        private void btnPesinSatis_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Faturasız_Satış)
            {
                yetkiler.mesajVer();
                return;
            }
            //frmTicaret frm = new frmTicaret(frmTicaret.formTipi.pesinSatis);
            //frm.Show();
            frmPesinSatis frm = new frmPesinSatis(frmPesinSatis.formTipi.pesinSatis);
            frm.Show();
        }

        private void btnParaTransferi_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kasa_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            frmKasaParaTransferi frm = new frmKasaParaTransferi();
            frm.Show();
        }

        private void btnCekSenetCirola_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Çek_Senet_Cirola)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCekSenetileTahsilatveOdeme frm = new frmCekSenetileTahsilatveOdeme(0, "", "Ciro");
            frm.Show();
        }

        private void lblFirma_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lblSube_DoubleClick(object sender, EventArgs e)
        {
        }

        private void teraziyeÜrünAktarımModülüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTeraziyeStokGonder frm = new frmTeraziyeStokGonder();
            frm.Show();
        }

        private void btnTerazi_Click(object sender, EventArgs e)
        {
            frmOtopark frm = new frmOtopark();
            frm.Show();
        }

        private void stokSayımModülüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCanliStok frm = new frmCanliStok(true);
            frm.Show();
        }

        private void btnMizanRaporu_Click(object sender, EventArgs e)
        {
            frmMizanRaporu frm = new frmMizanRaporu();
            frm.Show();
        }

        private void btnTerazi_Click_1(object sender, EventArgs e)
        {
            frmTeraziyeStokGonder frm = new frmTeraziyeStokGonder();
            frm.Show();
        }

        private void btnTopluFiyatGuncelle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Faturasız_Satış)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTopluFiyatGuncelle frm = new frmTopluFiyatGuncelle();
            frm.Show();
        }

        private void btnSms_Click(object sender, EventArgs e)
        {
            menuSec(pnlSMS);
        }

        private void btnGunlukIzleme_Click(object sender, EventArgs e)
        {
            frmGunlukIzlemeEkrani frm = new frmGunlukIzlemeEkrani();
            frm.Show();
        }

        private void btntopluFiyatGuncelleStokKarti_Click(object sender, EventArgs e)
        {
            frmTopluFiyatGuncelleStokKarti frm = new frmTopluFiyatGuncelleStokKarti();
            frm.Show();
        }

        private void btnUretim_Click(object sender, EventArgs e)
        {

        }

        private void btnSmsGonder_Click(object sender, EventArgs e)
        {
            FrmSms frm = new FrmSms();
            frm.Show();
        }

        private void btnTopluSms_Click(object sender, EventArgs e)
        {
            FrmTopluSms frm = new FrmTopluSms();
            frm.ShowDialog();
        }

        private void lblKullanici_Click(object sender, EventArgs e)
        {
            var frm = new frmSilinenSatislar();
            frm.ShowDialog();
        }

        private void btnGelenTransferler_Click(object sender, EventArgs e)
        {
            var frm = new frmSonKullanmaTarihiGecenUrunler();
            frm.Show();
        }
    }
}