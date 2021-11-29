using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Elmar_Ticari_Plus
{
    public partial class frmTanimlamalar : Form
    {
        public frmTanimlamalar()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
        }

        private void frmTanimlamalar_Load(object sender, EventArgs e)
        {

        }

        private void btnKategoriTanimla_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmKategoriSecimi frm = new frmKategoriSecimi();
            frm.Show();
        }

        private void btnFiyatTanimla_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimFiyatAdi frm = new frmTanimFiyatAdi();
            frm.Show();
        }

        private void btnMarkaTanimla_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimMarkalar frm = new frmTanimMarkalar();
            frm.Show();
        }

        private void btnBirimTanimlamala_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimBirim frm = new frmTanimBirim();
            frm.Show();
        }

        private void btnStokKartiTanimla_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları && !yetkiler.Stok_Kart_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmStokKartEkle frm = new frmStokKartEkle();
            frm.Show();
        }

        private void btnAyrintiliStokKartiTanimla_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları && !yetkiler.Stok_Kart_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmYeniAyrintiliStokkartEkle frm = new frmYeniAyrintiliStokkartEkle();
            frm.Show();
        }

        private void frmFirmaBilgileriniDegistir_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Firma_ve_Şube_Tanıml_)
            {
                yetkiler.mesajVer();
                return;
            }
            if (firma.kullaniciAdi == "demo")
            {
                yetkiler.mesajVer();
                return;
            }
            frmFirmaBilgileri frm = new frmFirmaBilgileri();
            frm.Show();
        }

        private void frmSubeTanimlamalari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Firma_ve_Şube_Tanıml_)
            {
                yetkiler.mesajVer();
                return;
            }
            if (firma.kullaniciAdi == "demo")
            {
                yetkiler.mesajVer();
                return;
            }
            frmFirmaSubeBilgileri frm = new frmFirmaSubeBilgileri();
            frm.Show();
        }

        private void frmKullaniciTanimlamalariveYetkilendirme_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Firma_ve_Şube_Tanıml_)
            {
                yetkiler.mesajVer();
                return;
            }
            if (firma.kullaniciAdi == "demo")
            {
                yetkiler.mesajVer();
                return;
            }
            frmFirmaKullanicilari frm = new frmFirmaKullanicilari();
            frm.Show();
        }

        private void btnKullaniciYetkilendirmeleri_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Firma_ve_Şube_Tanıml_ && !yetkiler.Yetkiler_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            if (firma.kullaniciAdi == "demo")
            {
                yetkiler.mesajVer();
                return;
            }
            frmFirmaKullaniciYetkileri frm = new frmFirmaKullaniciYetkileri();
            frm.Show();
        }

        private void btnMasrafkartiTanimlamalari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kasa_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimMasrafKartlari frm = new frmTanimMasrafKartlari();
            frm.Show();
        }

        private void btnSurumYenilikleriniGoster_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\Yardım.exe", "2é" + firma.kullaniciid.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Sürüm yenilikleri görüntülenirken bir hata oluştu.", firma.programAdi);
            }
        }

        private void btnFaturaveCiktiDuzenle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Fatura_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmFaturaolustur frm = new frmFaturaolustur();
            frm.Show();
        }

        private void btnArkaPlanLogosu_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Firma_ve_Şube_Tanıml_)
            {
                yetkiler.mesajVer();
                return;
            }
            frmLogoDegistir frm = new frmLogoDegistir();
            frm.Show();
        }

        private void btnFisDuzenle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Fatura_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmFisOlustur frm = new frmFisOlustur();
            frm.Show();
        }

        private void btnCariGrubuTanimlamalari_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimCariGrubu frm = new frmTanimCariGrubu();
            frm.Show();
        }

        private void btnHazirMesajTanimla_Click(object sender, EventArgs e)
        {
            frmTanimHazirMesaj frm = new frmTanimHazirMesaj();
            frm.Show();
        }

        private void btnEFatura_Click(object sender, EventArgs e)
        {
            frmTanimEFaturabilgileri eFaturabilgileri = new frmTanimEFaturabilgileri();
            eFaturabilgileri.Show();
        }

        private void btnCiktiLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Resim Seçimi";
            o.Filter = "Resim Dosyaları|*.png;*.bmp;*.gif;*.jpg";
            o.ShowDialog();
            if (o.SafeFileName == "")
            {
            }
            else
            {
                PictureBox picLogo = new PictureBox();
                picLogo.Image = Image.FromFile(o.FileName);
                logoKaydet(picLogo.Image, 80, 60);
            }
        }

        public void logoKaydet(System.Drawing.Image img, int istenenEn, int istenenBoy)
        {

            Bitmap yeniimg = new Bitmap(istenenEn, istenenBoy);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)yeniimg))
                g.DrawImage(img, 0, 0, istenenEn, istenenBoy);
            yeniimg.Save(Application.StartupPath + "\\KullanıcıResimleri\\logo\\logoCikti" + firma.firmaid + ".png", System.Drawing.Imaging.ImageFormat.Png);
            elmarDosyaislemleri.resimYukle(yeniimg, "logo/logoCikti" + firma.firmaid + ".png");
            MessageBox.Show("", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
