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
    public partial class frmCariTahsilatOdemeRaporlari : Form
    {
        rapor rpr;
        public frmCariTahsilatOdemeRaporlari()
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

        private void frmCariTahsilatOdemeRaporlari_Load(object sender, EventArgs e)
        {

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
            int y = 10;
            rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(5, y, rpr._kagitGenisligi - 10, rpr._kagitYuksekligi - y * 3 / 2));
            Image img = Selahattin.logoGetir();
            int resimGenişlik = 0;
            if (img != null)
            {
                //290-50-10
                resimGenişlik = img.Height;
                rpr.ekleResim(new rapor.resim(img, new Rectangle(rpr._kagitGenisligi / 2 - 20, 10, img.Width, resimGenişlik)));
                y += resimGenişlik + 5;
            }
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
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari "+baslikMetni.Substring(2)+" Raporu", new Font("Arial", 14, FontStyle.Bold), new Point(10, y)));
            y += 10;
            
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Adı", new Font("Arial", 9, FontStyle.Underline), new Point(5, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih", new Font("Arial", 9, FontStyle.Underline), new Point(95, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Borç", new Font("Arial", 9, FontStyle.Underline), new Rectangle(115, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Alacak", new Font("Arial", 9, FontStyle.Underline), new Rectangle(135, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Doviz", new Font("Arial", 9, FontStyle.Underline), new Point(155, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Bakiye", new Font("Arial", 9, FontStyle.Underline), new Rectangle(175, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Türü", new Font("Arial", 9, FontStyle.Underline), new Point(195, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Açıklama", new Font("Arial", 9, FontStyle.Underline), new Point(230, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Fat.No", new Font("Arial", 9, FontStyle.Underline), new Point(275, y)));
            
            
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
            if (chkESatis.Checked == false && chkEAlis.Checked == false && chkESatisiade.Checked == false && chkEAlisiade.Checked == true && chkETahsilat.Checked == false && chkEOdeme.Checked == false && chkEAlacak.Checked == false && chkEBorc.Checked == false && chkEHavale.Checked == false && chkEEFT.Checked == false) altSorgu = " and islemTuru2 like '%hiçbirinigetirme%' ";
            else if (chkESatis.Checked == true && chkEAlis.Checked == true && chkESatisiade.Checked == true && chkEAlisiade.Checked == true && chkETahsilat.Checked == true && chkEOdeme.Checked == true && chkEAlacak.Checked == true && chkEBorc.Checked == true && chkEHavale.Checked == true && chkEEFT.Checked == true) altSorgu = " ";
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
            if (rdArtanSiralama.Checked) sorgu = sorgu + " order by kayitTarihi asc, acikHesapid asc ";
            else if (rdAzalanSiralama.Checked) sorgu = sorgu + " order by kayitTarihi desc, acikHesapid desc ";
            int kayitSayisi = 0;
            double tahsilatT = 0, odemeT = 0, alisT = 0, satisT = 0, iadeT = 0, alacakT = 0, borcT = 0;
            SqlDataReader dr = veri.getDatareader("Select kayitTarihi, borc, alacak, dovizTuru, bakiye,islemTuru + ' ' + islemTuru2 as islemTuru,aciklama, faturaNo, cariAdi from sorAcikHesapEkstresi Where firmaid = " + firma.firmaid + sorgu);
            while (dr.Read())
            {
                y += 4;
                rpr.ekleYazi(new rapor.yazi(dr["cariAdi"].ToString(), new Rectangle(5, y, 89, 3), false));
                rpr.ekleYazi(new rapor.yazi(string.Format("{0:d}", Convert.ToDateTime(dr["kayitTarihi"])), new Rectangle(95, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr["borc"].ToString(), new Rectangle(115, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["alacak"].ToString(), new Rectangle(135, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["dovizTuru"].ToString(), new Rectangle(155, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr["bakiye"].ToString(), new Rectangle(175, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["islemTuru"].ToString(), new Rectangle(195, y, 34, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr["aciklama"].ToString(), new Rectangle(230, y, 44, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr["faturaNo"].ToString(), new Rectangle(275, y, 19, 3), false));
                rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y+4, y+4));
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
            rpr.ekleYazi(new rapor.yazi(firmaBilgileri.adi+" "+firmaBilgileri.soyadi+ "  "+firmaBilgileri.webSitesi+"  "+subeBilgileri.tel+"  "+subeBilgileri.adres+"  "+subeBilgileri.altBilgiNotu,new Rectangle(5,y,rpr._kagitGenisligi-10,5),false));
            y += 5;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y));
            y++;
            rpr.ekleYazi(new rapor.yazi("Toplam Alacak: " + string.Format("{0:n2}", alacakT) + " TL", new Point(5, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Borç: " + string.Format("{0:n2}", borcT) + " TL", new Point(55, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Tahsilat: " + string.Format("{0:n2}", tahsilatT) + " TL", new Point(110, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Ödeme: " + string.Format("{0:n2}", odemeT) + " TL", new Point(160, y)));
            y += 3;
            rpr.ekleYazi(new rapor.yazi("Toplam Satış: " + string.Format("{0:n2}", satisT) + " TL", new Point(5, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam Alış: " + string.Format("{0:n2}", alisT) + " TL", new Point(55, y)));
            rpr.ekleYazi(new rapor.yazi("Toplam İade: " + string.Format("{0:n2}", iadeT) + " TL", new Point(110, y)));
            
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 5, y, y));
            y += 3;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + kayitSayisi.ToString()+ "  Çıktı Tarihi: "+ DateTime.Now.ToString()+"  www.elmaryazilim.com", new Point(5, y)));
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
