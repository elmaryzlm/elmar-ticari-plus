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
    public partial class frmCariAlacakBorcRaporlari : Form
    {
        rapor rpr;
        public frmCariAlacakBorcRaporlari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(panel2);
            cariGrubuListesiniYenile();
            listeler.doldurSube(cmbSubeler);
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanici, ComboboxItem.getSelectedValue(cmbSubeler));
        }

        public void cariGrubuListesiniYenile()
        {
            cmbCarigrubu.Items.Clear();
            try
            {
                cmbCarigrubu.Items.AddRange(listeler.getCariGrupAdi());
            }
            catch { }
        }

        private void btnRaporla_Click(object sender, EventArgs e)
        {
            if (raporOlustur())
            { rpr.onizleme(); }
        }

        bool raporOlustur()
        {
            rpr = new rapor();
            rpr.sayfayiYatayYap();
            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 5;

            rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(4, y, rpr._kagitGenisligi - 8, rpr._kagitYuksekligi - y * 3 / 2));
            Image img =Selahattin.logoGetir();
            int resimGenişlik = 0;
            if (img != null)
            {
                //290-50-10
                resimGenişlik = img.Height;//yükseklik-genişlik
                rpr.ekleResim(new rapor.resim(img, new Rectangle(rpr._kagitGenisligi / 2 - 20, 10, img.Width, resimGenişlik)));
                y += resimGenişlik+5;
            }

            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Alacak - Borç Raporu", new Font("Arial", 14, FontStyle.Bold), new Point(115, y)));
            y += 10;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Adı", new Font("Arial", 9, FontStyle.Underline), new Point(4, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Açık Hsp", new Font("Arial", 9, FontStyle.Underline), new Rectangle(45, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Durum", new Font("Arial", 9, FontStyle.Underline), new Point(65, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kredi Kartı", new Font("Arial", 9, FontStyle.Underline), new Rectangle(77, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Durum", new Font("Arial", 9, FontStyle.Underline), new Point(97, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Pos Çekim", new Font("Arial", 9, FontStyle.Underline), new Rectangle(109, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Durum", new Font("Arial", 9, FontStyle.Underline), new Point(129, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Taksit", new Font("Arial", 9, FontStyle.Underline), new Rectangle(141, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Durum", new Font("Arial", 9, FontStyle.Underline), new Point(161, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Çek", new Font("Arial", 9, FontStyle.Underline), new Rectangle(173, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Durum", new Font("Arial", 9, FontStyle.Underline), new Point(193, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Senet", new Font("Arial", 9, FontStyle.Underline), new Rectangle(205, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Durum", new Font("Arial", 9, FontStyle.Underline), new Point(225, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Net Bakiye", new Font("Arial", 9, FontStyle.Underline), new Rectangle(237, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Durum", new Font("Arial", 9, FontStyle.Underline), new Point(257, y)));

            string sorgu = " ";
            long seciliGrupid = 0;
            int seciliSubeid = 0;
            int seciliKullaniciid = 0;
            Int16 hesabaislensinmi = 1;
            Int16 silindinmi = 0;
            string durum = "''";
            string sorguTuru = "0";
            if (cmbCarigrubu.SelectedIndex >= 0) seciliGrupid = listeler.getCariGrupid()[cmbCarigrubu.SelectedIndex];
            if (cmbSubeler.SelectedIndex > 0) seciliSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbSubeler));
            if (cmbKullanici.SelectedIndex > 0) seciliKullaniciid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbKullanici));
            if (chkPasifCariler.Checked) hesabaislensinmi = 0;
            if (chkSilinenCariler.Checked) silindinmi = 1;
            if (chkAlacak.Checked) durum = durum + ",'Alacaklı'";
            if (chkBorc.Checked) durum = durum + ",'Borçlu'";
            if (chkBakiyesiSifirOlanlar.Checked) durum = durum + ",'-'";
            if (rdVadesiGecenler.Checked)sorguTuru = "1";
            if (rdTarihAraligi.Checked)sorguTuru = "2";
            if (rdArtanSiralama.Checked) sorgu = sorgu + " Where durumNet in ("+durum+") order by cariAdi asc ";
            else if (rdAzalanSiralama.Checked) sorgu = sorgu + " order by cariAdi desc ";
            int kayitSayisi = 0;
            double alacakToplam = 0, borcToplam = 0;
            string netDurum = "";

            SqlDataReader dr = veri.getDatareader("Select cariAdi, acikHesap, durum1, krediKarti, durum2, postan, durum3, taksit, durum4, cek, durum5, senet, durum6, net, durumNet From dbo.fonkAlacakBorcRaporlari2("+seciliGrupid+", "+firma.firmaid+", "+seciliSubeid+", "+seciliKullaniciid+", '"+hesabaislensinmi+"', '"+silindinmi+"', '"+sorguTuru+"','"+dtTarih1.Value+"', '"+dtTarih2.Value+"', '"+txtBolge.Tag.ToString()+"') "+ sorgu);
            while (dr.Read())
            {
                y += 4;
                rpr.ekleYazi(new rapor.yazi(dr["cariAdi"].ToString(), new Rectangle(4, y, 40, 3), false));

                rpr.ekleYazi(new rapor.yazi(dr["acikHesap"].ToString(), new Rectangle(45, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["durum1"].ToString(), new Rectangle(65, y, 12, 3), false));

                rpr.ekleYazi(new rapor.yazi(dr["krediKarti"].ToString(), new Rectangle(77, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["durum2"].ToString(), new Rectangle(97, y, 12, 3), false));

                rpr.ekleYazi(new rapor.yazi(dr["postan"].ToString(), new Rectangle(109, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["durum3"].ToString(), new Rectangle(129, y, 12, 3), false));

                rpr.ekleYazi(new rapor.yazi(dr["taksit"].ToString(), new Rectangle(141, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["durum4"].ToString(), new Rectangle(161, y, 12, 3), false));

                rpr.ekleYazi(new rapor.yazi(dr["cek"].ToString(), new Rectangle(173, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["durum5"].ToString(), new Rectangle(193, y, 12, 3), false));

                rpr.ekleYazi(new rapor.yazi(dr["senet"].ToString(), new Rectangle(205, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["durum6"].ToString(), new Rectangle(225, y, 12, 3), false));

                rpr.ekleYazi(new rapor.yazi(dr["net"].ToString(), new Rectangle(237, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["durumNet"].ToString(), new Rectangle(257, y, 12, 3), false));
                rpr.ekleCizgi(new rapor.cizgi(4, rpr._kagitGenisligi - 4, y, y));
                kayitSayisi += 1;
                if (dr["durumNet"].ToString() == "Borçlu") alacakToplam += Convert.ToDouble(dr["net"]);
                else if (dr["durumNet"].ToString() == "Alacaklı") borcToplam += Convert.ToDouble(dr["net"]);
            }
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(4, rpr._kagitGenisligi - 4, y, y)); y += 2;
            rpr.ekleYazi(new rapor.yazi(firmaBilgileri.adi + " " + firmaBilgileri.soyadi + "  " + firmaBilgileri.webSitesi + "  " + subeBilgileri.tel + "  " + subeBilgileri.adres + "  " + subeBilgileri.altBilgiNotu, new Rectangle(10, y, rpr._kagitGenisligi - 20, 5), false));
            y += 5;
            rpr.ekleCizgi(new rapor.cizgi(4, rpr._kagitGenisligi - 4, y, y));
            y += 3;
            if (alacakToplam > borcToplam) netDurum = "  Alacaklısınız";
            else if (alacakToplam < borcToplam) netDurum = "  Borçlusunuz";
            else netDurum = "-";
            rpr.ekleYazi(new rapor.yazi("Genel Alacak Toplamı: " + String.Format("{0:n2}", alacakToplam) + " TL", new Font("Arial", 9,FontStyle.Bold), new Point(4, y)));
            rpr.ekleYazi(new rapor.yazi("Genel Borç Toplamı: " + String.Format("{0:n2}", borcToplam) + " TL", new Font("Arial", 9, FontStyle.Bold), new Point(60, y)));
            rpr.ekleYazi(new rapor.yazi("Genel Bakiye Toplamı: " + String.Format("{0:n2}", Math.Abs(alacakToplam - borcToplam)) + " TL" + netDurum, new Font("Arial", 9, FontStyle.Bold), new Point(115, y)));
            y += 5;
            rpr.ekleYazi(new rapor.yazi("Toplam Kayıt Sayısı: " + kayitSayisi.ToString() + "  Çıktı Tarihi: " + DateTime.Now.ToString() + "  www.elmaryazilim.com", new Point(4, y)));
            return true;
        }

        private void rdTumu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTumu.Checked) pnlTarih.Enabled = false;
            else pnlTarih.Enabled = true;
        }

        private void rdCaritumu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCaritumu.Checked)
            {
                cmbCarigrubu.Enabled = false;
                cmbCarigrubu.SelectedIndex = -1;
            }
            else if (rdCarigrup.Checked)
            {
                cmbCarigrubu.Enabled = true;
                cmbCarigrubu.SelectedIndex = -1;
            }
        }

        private void frmCariAlacakBorcRaporlari_Load(object sender, EventArgs e)
        {

        }

        private void btnBolgeSec_Click(object sender, EventArgs e)
        {
            frmBolgeSecimi frm = new frmBolgeSecimi();
            frm._frmCariAlacakBorcRaporlari = this;
            frm.Show();
        }

        private void btnBolgeTemizle_Click(object sender, EventArgs e)
        {
            txtBolge.Text = "";
            txtBolge.Tag = "00";
        }
    }
}
