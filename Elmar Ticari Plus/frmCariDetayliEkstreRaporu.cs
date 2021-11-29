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
using System.IO;

namespace Elmar_Ticari_Plus
{
    public partial class frmCariDetayliEkstreRaporu : Form
    {
        rapor rpr;
        public frmCariDetayliEkstreRaporu()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(panel2);
            cariListesiniYenile();
            cariGrubuListesiniYenile();
            listeler.doldurSube(cmbSubeler);
        }

        public void cariListesiniYenile()
        {
            cmbCariadi.Items.Clear();
            try
            {
                cmbCariadi.Items.AddRange(listeler.getCariAdi());
            }
            catch { }
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
            if (chbSayfaYonu.Checked)
            {
                rpr.sayfayiDikeyYap();
                return dikey();
            }

            else
                rpr.sayfayiYatayYap();
            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 10;
            rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(5, y, rpr._kagitGenisligi - 10, rpr._kagitYuksekligi - y * 3 / 2));
            string baslikMetni = "";
            if (chkETahsilat.Checked) baslikMetni = baslikMetni + " ,Tahsilat";
            if (chkEOdeme.Checked) baslikMetni = baslikMetni + " ,Ödeme";
            if (chkEAlacak.Checked) baslikMetni = baslikMetni + " ,Alacak";
            if (chkEBorc.Checked) baslikMetni = baslikMetni + " ,Borç";
            if (chkESatis.Checked) baslikMetni = baslikMetni + " ,Satış";
            if (chkEAlis.Checked) baslikMetni = baslikMetni + " ,Alış";
            if (chkESatisiade.Checked) baslikMetni = baslikMetni + " ,Satış İade";
            if (chkEAlisiade.Checked) baslikMetni = baslikMetni + " ,Alış İade";
            if (baslikMetni == "") baslikMetni = "  Tahsilat - Ödeme";
            rpr.ekleSabitYazi(new rapor.sabitYazi("Detaylı Cari " + baslikMetni.Substring(2) + " Raporu", new Font("Arial", 14, FontStyle.Bold), new Point(10, y)));
            y += 10;

            string sorgu = " ";
            string altSorgu = " ";
            //işlemturu-1 sorgusu yapılıyor
            if (chkEAcikHesap.Checked == false && chkECek.Checked == false && chkEPos.Checked == false && chkEKrediKarti.Checked == false && chkEPesin.Checked == false && chkESenet.Checked == false && chkETaksit.Checked == false) altSorgu = " and islemTuru like '%hiçbirinigetirme%' ";
            else if (chkEAcikHesap.Checked == true && chkECek.Checked == true && chkEPos.Checked == false && chkEKrediKarti.Checked == true && chkEPesin.Checked == true && chkESenet.Checked == true && chkETaksit.Checked == true) altSorgu = " ";
            else
            {
                if (chkEAcikHesap.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Açık Hesap%'";
                if (chkECek.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Çek%'";
                if (chkEKrediKarti.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Kredi Kartı%'";
                if (chkEPos.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Pos%'";
                if (chkEPesin.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Peşin%'";
                if (chkESenet.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Senet%'";
                if (chkETaksit.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Taksit%'";
                altSorgu = " and (" + altSorgu.Substring(4) + ") ";
            }
            sorgu = sorgu + altSorgu;

            //işlemturu-2 sorgusu yapılıyor
            altSorgu = " ";
            if (chkESatis.Checked == false && chkEAlis.Checked == false && chkEAlisiade.Checked == true && chkESatisiade.Checked == false && chkETahsilat.Checked == false && chkEOdeme.Checked == false && chkEAlacak.Checked == false && chkEBorc.Checked == false && chkEHavale.Checked == false && chkEEFT.Checked == false) altSorgu = " and islemTuru2 like '%hiçbirinigetirme%' ";
            else if (chkESatis.Checked == true && chkEAlis.Checked == true && chkEAlisiade.Checked == true && chkESatisiade.Checked == true && chkETahsilat.Checked == true && chkEOdeme.Checked == true && chkEAlacak.Checked == true && chkEBorc.Checked == true && chkEHavale.Checked == true && chkEEFT.Checked == true) altSorgu = " ";
            else
            {
                if (chkESatis.Checked == true) altSorgu = altSorgu + " or islemTuru2 = 'Satış'";
                if (chkEAlis.Checked == true) altSorgu = altSorgu + " or islemTuru2 = 'Alış'";
                if (chkESatisiade.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Satış İade%'";
                if (chkEAlisiade.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Alış İade%'";
                if (chkETahsilat.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Tahsilat%'";
                if (chkEOdeme.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Ödeme%'";
                if (chkEAlacak.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Alacak%'";
                if (chkEBorc.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Borç%'";
                if (chkEHavale.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Havale%'";
                if (chkEEFT.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%EFT%'";
                altSorgu = " and (" + altSorgu.Substring(4) + ") ";
            }
            sorgu = sorgu + altSorgu;

            long seciliCariid = 0;
            long seciliGrupid = 0;
            int seciliSubeid = 0;
            if (cmbCariadi.SelectedIndex >= 0)
            {
                seciliCariid = listeler.getCariid()[cmbCariadi.SelectedIndex];
                sorgu = sorgu + " and cariid = " + seciliCariid + "";
            }
            else if (cmbCarigrubu.SelectedIndex >= 0)
            {
                seciliGrupid = listeler.getCariGrupid()[cmbCarigrubu.SelectedIndex];
                sorgu = sorgu + " and grupid = " + seciliGrupid + "";
            }
            if (cmbSubeler.SelectedIndex > 0)
            {
                seciliSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbSubeler));
                sorgu = sorgu + " and subeid = " + seciliSubeid + "";
            }
            if (rdTariharaligi.Checked) sorgu = sorgu + " and (kayitTarihi between '" + dtTarih1.Value + "' and '" + dtTarih2.Value + "') ";
            if (rdArtanSiralama.Checked) sorgu = sorgu + " order by acikHesapid asc ";
            else if (rdAzalanSiralama.Checked) sorgu = sorgu + " order by acikHesapid desc ";
            int kayitSayisi = 0;
            double tahsilatT = 0, odemeT = 0, alisT = 0, satisT = 0, iadeT = 0, alacakT = 0, borcT = 0;
            SqlDataReader dr = veri.getDatareader("Select ticaretAyrintiid, kayitTarihi, odemeTarihi, vadeTarihi,borc, alacak, bakiye as toplam, isnull((Select bakiye from sorAcikHesapEkstresi where acikHesapid = sorAcikHesap.acikHesapid),0) as bakiye, islemTuru + ' ' + islemTuru2 as islemTuru, aciklama, faturaNo, irsaliyeNo, belgeNo from sorAcikHesap Where firmaid = " + firma.firmaid + sorgu);
            while (dr.Read())
            {
                //rpr.ekleYazi(new rapor.yazi("Cari Adı: " + dr["cariAdi"].ToString(), new Rectangle(5, y, 80, 3), false));
                //y += 3;
                rpr.ekleYazi(new rapor.yazi("Kayıt T. " + string.Format("{0:d}", Convert.ToDateTime(dr["kayitTarihi"])), new Font("Arial", 8, FontStyle.Regular), new Rectangle(5, y, 28, 3), false));
                if (dr["odemeTarihi"] != DBNull.Value && dr["odemeTarihi"] != null && !dr["odemeTarihi"].ToString().Contains("1900"))
                    rpr.ekleYazi(new rapor.yazi("  Ödeme T. " + string.Format("{0:d}", Convert.ToDateTime(dr["odemeTarihi"])), new Font("Arial", 8, FontStyle.Regular), new Rectangle(33, y, 32, 3), false));
                else if (dr["vadeTarihi"] != DBNull.Value && dr["vadeTarihi"] != null && !dr["vadeTarihi"].ToString().Contains("1900"))
                    rpr.ekleYazi(new rapor.yazi("  Vâde T. " + string.Format("{0:d}", Convert.ToDateTime(dr["vadeTarihi"])), new Font("Arial", 8, FontStyle.Regular), new Rectangle(33, y, 32, 3), false));
                double net = Convert.ToDouble(dr["toplam"]);
                double bakiye = Convert.ToDouble(dr["bakiye"]);
                if (dr["islemTuru"].ToString().Contains("Peşin")) net = Convert.ToDouble(dr["alacak"]);
                rpr.ekleYazi(new rapor.yazi("  Tutar: " + string.Format("{0:n2}", net) + " TL", new Font("Arial", 8, FontStyle.Regular), new Rectangle(65, y, 35, 3), false));
                rpr.ekleYazi(new rapor.yazi("  Bakiye: " + string.Format("{0:n2}", bakiye) + " TL", new Font("Arial", 8, FontStyle.Regular), new Rectangle(90, y, 35, 3), false));
                rpr.ekleYazi(new rapor.yazi("  İşlem: " + dr["islemTuru"].ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(125, y, 40, 3), false));
                rpr.ekleYazi(new rapor.yazi("  Fat.No: " + dr["faturaNo"].ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(165, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(" İrs.No: " + dr["irsaliyeNo"].ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(185, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(" Bel.No: " + dr["belgeNo"].ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(205, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi("  Açıklama: " + dr["aciklama"].ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(225, y, 80, 3), false));
                y += 4;
                if (dr["ticaretAyrintiid"].ToString() != "0")
                {
                    rpr.ekleYazi(new rapor.yazi("Barkod", new Font("Arial", 8, FontStyle.Underline), new Point(5, y)));
                    rpr.ekleYazi(new rapor.yazi("Ürün Adı", new Font("Arial", 8, FontStyle.Underline), new Point(35, y)));
                    rpr.ekleYazi(new rapor.yazi("B.Fiyat X Miktar", new Font("Arial", 8, FontStyle.Underline), new Point(100, y)));
                    rpr.ekleYazi(new rapor.yazi("        KDV", new Font("Arial", 8, FontStyle.Underline), new Point(135, y)));
                    rpr.ekleYazi(new rapor.yazi("        İsk1", new Font("Arial", 8, FontStyle.Underline), new Point(155, y)));
                    rpr.ekleYazi(new rapor.yazi("        İsk2", new Font("Arial", 8, FontStyle.Underline), new Point(170, y)));
                    rpr.ekleYazi(new rapor.yazi("        İsk3", new Font("Arial", 8, FontStyle.Underline), new Point(185, y)));
                    rpr.ekleYazi(new rapor.yazi("Doviz", new Font("Arial", 8, FontStyle.Underline), new Point(200, y)));
                    rpr.ekleYazi(new rapor.yazi("           ARATOP", new Font("Arial", 8, FontStyle.Underline), new Point(210, y)));
                    rpr.ekleYazi(new rapor.yazi("           KDVTOP", new Font("Arial", 8, FontStyle.Underline), new Point(235, y)));
                    rpr.ekleYazi(new rapor.yazi("           TOPLAM", new Font("Arial", 8, FontStyle.Underline), new Point(260, y)));
                    y += 4;
                    SqlDataReader dr2 = veri.getDatareader("Select barkod, seriNo, urunAdi, miktar, birim, birimFiyat, kdv, kdvTipi, isk1, isk2, isk3, dovizTuru, dovizDegeri, araTop, kdvTop, toplam from sorTicaret where firmaid = " + firma.firmaid + " and ticaretayrintiid = " + dr["ticaretAyrintiid"].ToString() + "");
                    while (dr2.Read())
                    {
                        rpr.ekleYazi(new rapor.yazi(dr2["barkod"].ToString() + " " + dr2["seriNo"].ToString(), new Rectangle(5, y, 34, 3), false));
                        rpr.ekleYazi(new rapor.yazi(dr2["urunAdi"].ToString(), new Rectangle(35, y, 64, 3), false));
                        rpr.ekleYazi(new rapor.yazi(string.Format("{0:n2}", Convert.ToDouble(dr2["birimFiyat"])) + " X " + dr2["miktar"].ToString() + " " + dr2["birim"].ToString(), new Rectangle(100, y, 34, 3), false));
                        rpr.ekleYazi(new rapor.yazi(dr2["kdv"].ToString() + "% " + dr2["kdvTipi"].ToString(), new Rectangle(135, y, 19, 3), false));
                        rpr.ekleYazi(new rapor.yazi(dr2["isk1"].ToString() + "%", new Rectangle(155, y, 14, 3), StringFormatFlags.DirectionRightToLeft, false));
                        rpr.ekleYazi(new rapor.yazi(dr2["isk2"].ToString() + "%", new Rectangle(170, y, 14, 3), StringFormatFlags.DirectionRightToLeft, false));
                        rpr.ekleYazi(new rapor.yazi(dr2["isk3"].ToString() + "%", new Rectangle(185, y, 14, 3), StringFormatFlags.DirectionRightToLeft, false));
                        rpr.ekleYazi(new rapor.yazi(dr2["dovizTuru"].ToString(), new Rectangle(200, y, 9, 3), false));
                        rpr.ekleYazi(new rapor.yazi(dr2["araTop"].ToString(), new Rectangle(210, y, 24, 3), StringFormatFlags.DirectionRightToLeft, true));
                        rpr.ekleYazi(new rapor.yazi(dr2["kdvtop"].ToString(), new Rectangle(235, y, 24, 3), StringFormatFlags.DirectionRightToLeft, true));
                        rpr.ekleYazi(new rapor.yazi(dr2["toplam"].ToString(), new Rectangle(260, y, 24, 3), StringFormatFlags.DirectionRightToLeft, true));
                        y += 3;
                    }
                }
                y += 2;
                rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y));
                y += 2;


                //Toplamlar Hesaplanıyor
                kayitSayisi += 1;
                if (dr["islemTuru"].ToString().Contains("Alış")) alisT += Convert.ToDouble(dr["borc"]);
                if (dr["islemTuru"].ToString().Contains("Satış")) satisT += Convert.ToDouble(dr["alacak"]);
                if (dr["islemTuru"].ToString().Contains("Alış İade")) iadeT += Convert.ToDouble(dr["borc"]);
                if (dr["islemTuru"].ToString().Contains("Satış İade")) iadeT -= Convert.ToDouble(dr["borc"]);
                if (dr["islemTuru"].ToString().Contains("Tahsilat") || dr["islemTuru"].ToString().Contains("Peşin Satış")) tahsilatT += Convert.ToDouble(dr["borc"]);
                if (dr["islemTuru"].ToString().Contains("Ödeme") || dr["islemTuru"].ToString().Contains("Peşin Alış")) odemeT += Convert.ToDouble(dr["alacak"]);
                if (dr["islemTuru"].ToString().Contains("Alacak")) alacakT += Convert.ToDouble(dr["alacak"]);
                if (dr["islemTuru"].ToString().Contains("Borç")) borcT += Convert.ToDouble(dr["borc"]);
            }
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y)); y += 2;
            rpr.ekleYazi(new rapor.yazi(firmaBilgileri.adi + " " + firmaBilgileri.soyadi + "  " + firmaBilgileri.webSitesi + "  " + subeBilgileri.tel + "  " + subeBilgileri.adres + "  " + subeBilgileri.altBilgiNotu, new Rectangle(10, y, rpr._kagitGenisligi - 20, 5), false));
            y += 5;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y));
            y++;
            rpr.ekleYazi(new rapor.yazi("Toplam Alacak: " + string.Format("{0:n2}", alacakT) + " TL", new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Borç: " + string.Format("{0:n2}", borcT) + " TL", new Point(55, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Tahsilat: " + string.Format("{0:n2}", tahsilatT) + " TL", new Point(110, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Ödeme: " + string.Format("{0:n2}", odemeT) + " TL", new Point(160, y)));
            y += 3;
            rpr.ekleYazi(new rapor.yazi("Toplam Satış: " + string.Format("{0:n2}", satisT) + " TL", new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Alış: " + string.Format("{0:n2}", alisT) + " TL", new Point(55, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam İade: " + string.Format("{0:n2}", iadeT) + " TL", new Point(110, y)));

            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y));
            y += 3;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + kayitSayisi.ToString() + "  Çıktı Tarihi: " + DateTime.Now.ToString() + "  www.elmaryazilim.com", new Point(5, y)));
            return true;
        }

        bool dikey()
        {
            rpr = new rapor();
            rpr.sayfayiDikeyYap();

            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 10;
            rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(5, y, rpr._kagitGenisligi - 10, rpr._kagitYuksekligi - y * 3 / 2));
           // string baslikMetni = "Extre Raporu";
            //if (chkETahsilat.Checked) baslikMetni = baslikMetni + " ,Tahsilat";
            //if (chkEOdeme.Checked) baslikMetni = baslikMetni + " ,Ödeme";
            //if (chkEAlacak.Checked) baslikMetni = baslikMetni + " ,Alacak";
            //if (chkEBorc.Checked) baslikMetni = baslikMetni + " ,Borç";
            //if (chkESatis.Checked) baslikMetni = baslikMetni + " ,Satış";
            //if (chkEAlis.Checked) baslikMetni = baslikMetni + " ,Alış";
            //if (chkESatisiade.Checked) baslikMetni = baslikMetni + " ,Satış İade";
            //if (chkEAlisiade.Checked) baslikMetni = baslikMetni + " ,Alış İade";
            //if (baslikMetni == "") baslikMetni = "  Tahsilat - Ödeme";
            rpr.ekleSabitYazi(new rapor.sabitYazi("Detaylı Cari Extre Raporu", new Font("Arial", 14, FontStyle.Bold), new Point(10, y)));
            y += 10;

            string sorgu = " ";
            string altSorgu = " ";
            //işlemturu-1 sorgusu yapılıyor
            if (chkEAcikHesap.Checked == false && chkECek.Checked == false && chkEPos.Checked == false && chkEKrediKarti.Checked == false && chkEPesin.Checked == false && chkESenet.Checked == false && chkETaksit.Checked == false) altSorgu = " and islemTuru like '%hiçbirinigetirme%' ";
            else if (chkEAcikHesap.Checked == true && chkECek.Checked == true && chkEPos.Checked == false && chkEKrediKarti.Checked == true && chkEPesin.Checked == true && chkESenet.Checked == true && chkETaksit.Checked == true) altSorgu = " ";
            else
            {
                if (chkEAcikHesap.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Açık Hesap%'";
                if (chkECek.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Çek%'";
                if (chkEKrediKarti.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Kredi Kartı%'";
                if (chkEPos.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Pos%'";
                if (chkEPesin.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Peşin%'";
                if (chkESenet.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Senet%'";
                if (chkETaksit.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Taksit%'";
                altSorgu = " and (" + altSorgu.Substring(4) + ") ";
            }
            sorgu = sorgu + altSorgu;

            //işlemturu-2 sorgusu yapılıyor
            altSorgu = " ";
            if (chkESatis.Checked == false && chkEAlis.Checked == false && chkEAlisiade.Checked == true && chkESatisiade.Checked == false && chkETahsilat.Checked == false && chkEOdeme.Checked == false && chkEAlacak.Checked == false && chkEBorc.Checked == false && chkEHavale.Checked == false && chkEEFT.Checked == false) altSorgu = " and islemTuru2 like '%hiçbirinigetirme%' ";
            else if (chkESatis.Checked == true && chkEAlis.Checked == true && chkEAlisiade.Checked == true && chkESatisiade.Checked == true && chkETahsilat.Checked == true && chkEOdeme.Checked == true && chkEAlacak.Checked == true && chkEBorc.Checked == true && chkEHavale.Checked == true && chkEEFT.Checked == true) altSorgu = " ";
            else
            {
                if (chkESatis.Checked == true) altSorgu = altSorgu + " or islemTuru2 = 'Satış'";
                if (chkEAlis.Checked == true) altSorgu = altSorgu + " or islemTuru2 = 'Alış'";
                if (chkESatisiade.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Satış İade%'";
                if (chkEAlisiade.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Alış İade%'";
                if (chkETahsilat.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Tahsilat%'";
                if (chkEOdeme.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Ödeme%'";
                if (chkEAlacak.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Alacak%'";
                if (chkEBorc.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Borç%'";
                if (chkEHavale.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Havale%'";
                if (chkEEFT.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%EFT%'";
                altSorgu = " and (" + altSorgu.Substring(4) + ") ";
            }
            sorgu = sorgu + altSorgu;

            long seciliCariid = 0;
            long seciliGrupid = 0;
            int seciliSubeid = 0;
            if (cmbCariadi.SelectedIndex >= 0)
            {
                seciliCariid = listeler.getCariid()[cmbCariadi.SelectedIndex];
                sorgu = sorgu + " and cariid = " + seciliCariid + "";
            }
            else if (cmbCarigrubu.SelectedIndex >= 0)
            {
                seciliGrupid = listeler.getCariGrupid()[cmbCarigrubu.SelectedIndex];
                sorgu = sorgu + " and grupid = " + seciliGrupid + "";
            }
            if (cmbSubeler.SelectedIndex > 0)
            {
                seciliSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbSubeler));
                sorgu = sorgu + " and subeid = " + seciliSubeid + "";
            }
            if (rdTariharaligi.Checked) sorgu = sorgu + " and (kayitTarihi between '" + dtTarih1.Value + "' and '" + dtTarih2.Value + "') ";
            if (rdArtanSiralama.Checked) sorgu = sorgu + " order by acikHesapid asc ";
            else if (rdAzalanSiralama.Checked) sorgu = sorgu + " order by acikHesapid desc ";
            int kayitSayisi = 0;
            double tahsilatT = 0, odemeT = 0, alisT = 0, satisT = 0, iadeT = 0, alacakT = 0, borcT = 0;
            SqlDataReader dr = veri.getDatareader("Select ticaretAyrintiid, kayitTarihi, odemeTarihi, vadeTarihi,borc, alacak, bakiye as toplam, isnull((Select bakiye from sorAcikHesapEkstresi where acikHesapid = sorAcikHesap.acikHesapid),0) as bakiye, islemTuru + ' ' + islemTuru2 as islemTuru, aciklama, faturaNo, irsaliyeNo, belgeNo from sorAcikHesap Where firmaid = " + firma.firmaid + sorgu);
            while (dr.Read())
            {
                //rpr.ekleYazi(new rapor.yazi("Cari Adı: " + dr["cariAdi"].ToString(), new Rectangle(5, y, 80, 3), false));
                //y += 3;
                rpr.ekleYazi(new rapor.yazi("Kayıt T. " + string.Format("{0:d}", Convert.ToDateTime(dr["kayitTarihi"])), new Font("Arial", 8, FontStyle.Regular), new Rectangle(5, y, 28, 3), false));
                if (dr["odemeTarihi"] != DBNull.Value && dr["odemeTarihi"] != null && !dr["odemeTarihi"].ToString().Contains("1900"))
                    rpr.ekleYazi(new rapor.yazi("  Ödeme T. " + string.Format("{0:d}", Convert.ToDateTime(dr["odemeTarihi"])), new Font("Arial", 8, FontStyle.Regular), new Rectangle(30, y, 32, 3), false));
                else if (dr["vadeTarihi"] != DBNull.Value && dr["vadeTarihi"] != null && !dr["vadeTarihi"].ToString().Contains("1900"))
                    rpr.ekleYazi(new rapor.yazi("  Vâde T. " + string.Format("{0:d}", Convert.ToDateTime(dr["vadeTarihi"])), new Font("Arial", 8, FontStyle.Regular), new Rectangle(30, y, 32, 3), false));
                double net = Convert.ToDouble(dr["toplam"]);
                double bakiye = Convert.ToDouble(dr["bakiye"]);
                if (dr["islemTuru"].ToString().Contains("Peşin")) net = Convert.ToDouble(dr["alacak"]);
                rpr.ekleYazi(new rapor.yazi("  Tutar: " + string.Format("{0:n2}", net) + " TL", new Font("Arial", 8, FontStyle.Regular), new Rectangle(62, y, 35, 3), false));
                rpr.ekleYazi(new rapor.yazi("  Bakiye: " + string.Format("{0:n2}", bakiye) + " TL", new Font("Arial", 8, FontStyle.Regular), new Rectangle(87, y, 35, 3), false));
                rpr.ekleYazi(new rapor.yazi("  İşlem: " + dr["islemTuru"].ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(112, y, 40, 3), false));
                rpr.ekleYazi(new rapor.yazi("  Fat.No: " + dr["faturaNo"].ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(148, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi("  Açıklama: " + dr["aciklama"].ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(170, y, 80, 3), false));
                y += 4;
                if (dr["ticaretAyrintiid"].ToString() != "0")
                {
                  //  rpr.ekleYazi(new rapor.yazi("Barkod", new Font("Arial", 8, FontStyle.Underline), new Point(5, y)));
                    rpr.ekleYazi(new rapor.yazi("Ürün Adı", new Font("Arial", 8, FontStyle.Underline), new Point(5, y)));
                    rpr.ekleYazi(new rapor.yazi("B.Fiyat x Miktar", new Font("Arial", 8, FontStyle.Underline), new Point(70, y)));
                    rpr.ekleYazi(new rapor.yazi("  Kdv", new Font("Arial", 8, FontStyle.Underline), new Point(100, y)));
                    rpr.ekleYazi(new rapor.yazi("        İsk1", new Font("Arial", 8, FontStyle.Underline), new Point(110, y)));
                     rpr.ekleYazi(new rapor.yazi("           AraTop", new Font("Arial", 8, FontStyle.Underline), new Point(120, y)));
                    rpr.ekleYazi(new rapor.yazi("           KdvTop", new Font("Arial", 8, FontStyle.Underline), new Point(140, y)));
                    rpr.ekleYazi(new rapor.yazi("           Toplam", new Font("Arial", 8, FontStyle.Underline), new Point(160, y)));
                    y += 4;
                    SqlDataReader dr2 = veri.getDatareader("Select barkod, seriNo, urunAdi, miktar, birim, birimFiyat, kdv, kdvTipi, isk1, isk2, isk3, dovizTuru, dovizDegeri, abs(araTop) as araTop, abs(kdvTop) as kdvTop, abs(toplam) as toplam from sorTicaret where firmaid = " + firma.firmaid + " and ticaretayrintiid = " + dr["ticaretAyrintiid"].ToString() + "");
                    while (dr2.Read())
                    {
                       // rpr.ekleYazi(new rapor.yazi(dr2["barkod"].ToString() + " " + dr2["seriNo"].ToString(), new Rectangle(5, y, 34, 3), false));
                        rpr.ekleYazi(new rapor.yazi(dr2["urunAdi"].ToString(), new Rectangle(5, y, 64, 3), false));
                        rpr.ekleYazi(new rapor.yazi(string.Format("{0:n2}", Convert.ToDouble(dr2["birimFiyat"])) + " x " + dr2["miktar"].ToString() + " " + dr2["birim"].ToString(), new Rectangle(70, y, 34, 3), false));
                        rpr.ekleYazi(new rapor.yazi("% "+dr2["kdv"].ToString(), new Rectangle(100, y, 19, 3), false));
                        rpr.ekleYazi(new rapor.yazi(dr2["isk1"].ToString() + "%", new Rectangle(110, y, 14, 3), StringFormatFlags.DirectionRightToLeft, false));
                        rpr.ekleYazi(new rapor.yazi(dr2["araTop"].ToString(), new Rectangle(112, y, 24, 3), StringFormatFlags.DirectionRightToLeft, true));
                        rpr.ekleYazi(new rapor.yazi(dr2["kdvtop"].ToString(), new Rectangle(132, y, 24, 3), StringFormatFlags.DirectionRightToLeft, true));
                        rpr.ekleYazi(new rapor.yazi(dr2["toplam"].ToString(), new Rectangle(153, y, 24, 3), StringFormatFlags.DirectionRightToLeft, true));
                        y += 3;
                    }
                }
                y += 2;
                rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y));
                y += 2;


                //Toplamlar Hesaplanıyor
                kayitSayisi += 1;
                if (dr["islemTuru"].ToString().Contains("Alış")) alisT += Convert.ToDouble(dr["borc"]);
                if (dr["islemTuru"].ToString().Contains("Satış")) satisT += Convert.ToDouble(dr["alacak"]);
                if (dr["islemTuru"].ToString().Contains("Alış İade")) iadeT += Convert.ToDouble(dr["borc"]);
                if (dr["islemTuru"].ToString().Contains("Satış İade")) iadeT -= Convert.ToDouble(dr["borc"]);
                if (dr["islemTuru"].ToString().Contains("Tahsilat") || dr["islemTuru"].ToString().Contains("Peşin Satış")) tahsilatT += Convert.ToDouble(dr["borc"]);
                if (dr["islemTuru"].ToString().Contains("Ödeme") || dr["islemTuru"].ToString().Contains("Peşin Alış")) odemeT += Convert.ToDouble(dr["alacak"]);
                if (dr["islemTuru"].ToString().Contains("Alacak")) alacakT += Convert.ToDouble(dr["alacak"]);
                if (dr["islemTuru"].ToString().Contains("Borç")) borcT += Convert.ToDouble(dr["borc"]);
            }
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y)); y += 2;
            rpr.ekleYazi(new rapor.yazi(firmaBilgileri.adi + " " + firmaBilgileri.soyadi + "  " + firmaBilgileri.webSitesi + "  " + subeBilgileri.tel + "  " + subeBilgileri.adres + "  " + subeBilgileri.altBilgiNotu, new Rectangle(10, y, rpr._kagitGenisligi - 20, 5), false));
            y += 5;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y));
            y++;
            rpr.ekleYazi(new rapor.yazi("Toplam Alacak: " + string.Format("{0:n2}", alacakT) + " TL", new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Borç: " + string.Format("{0:n2}", borcT) + " TL", new Point(55, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Tahsilat: " + string.Format("{0:n2}", tahsilatT) + " TL", new Point(110, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Ödeme: " + string.Format("{0:n2}", odemeT) + " TL", new Point(160, y)));
            y += 3;
            rpr.ekleYazi(new rapor.yazi("Toplam Satış: " + string.Format("{0:n2}", satisT) + " TL", new Point(10, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Alış: " + string.Format("{0:n2}", alisT) + " TL", new Point(55, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam İade: " + string.Format("{0:n2}", iadeT) + " TL", new Point(110, y)));

            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y));
            y += 3;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + kayitSayisi.ToString() + "  Çıktı Tarihi: " + DateTime.Now.ToString() + "  www.elmaryazilim.com", new Point(5, y)));
            return true;
        }

        private void rdCaritumu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCaritumu.Checked)
            {
                cmbCarigrubu.Enabled = false;
                cmbCariadi.Enabled = false;
                cmbCarigrubu.SelectedIndex = -1;
                cmbCariadi.SelectedIndex = -1;
            }
            else if (rdCariadi.Checked)
            {
                cmbCarigrubu.Enabled = false;
                cmbCariadi.Enabled = true;
                cmbCarigrubu.SelectedIndex = -1;
                cmbCariadi.SelectedIndex = -1;
            }
            else if (rdCarigrup.Checked)
            {
                cmbCarigrubu.Enabled = true;
                cmbCariadi.Enabled = false;
                cmbCarigrubu.SelectedIndex = -1;
                cmbCariadi.SelectedIndex = -1;
            }
        }

        private void rdTumtarihler_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTumtarihler.Checked) pnlTarih.Enabled = false;
            else pnlTarih.Enabled = true;
        }
    }
}
