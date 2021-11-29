using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmKasaKarZararAnalizi : Form
    {
        public frmKasaKarZararAnalizi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(groupBox9);
            listeler.doldurSube(cmbFSubeler);
        }
        rapor rpr;
        private void btnRaporla_Click(object sender, EventArgs e)
        {
            raporHazirla();
            rpr.onizleme();
        }

        void raporHazirla()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = 295;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Firma Kâr - Zarar Analizi", new Font("Arial", 15, FontStyle.Bold), new Point(80, 5)));

            rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih-Saat", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 29, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Adı", new Font("Arial", 10, FontStyle.Underline), new Rectangle(35, 15, 49, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Türü", new Font("Arial", 10, FontStyle.Underline), new Rectangle(85, 15, 34, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Tutar", new Font("Arial", 10, FontStyle.Underline), new Rectangle(120, 15, 24, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Maliyet", new Font("Arial", 10, FontStyle.Underline), new Rectangle(145, 15, 24, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kâr-Zarar", new Font("Arial", 10, FontStyle.Underline), new Rectangle(170, 15, 24, 4), StringFormatFlags.DirectionRightToLeft, false));

            string sorgu = " ";
            string altSorgu = " ";
            if (chkFAlisİade.Checked == false && chkFFaturaliAlis.Checked == false && chkFFaturaliSatis.Checked == false && chkFFaturasizAlis.Checked == false && chkFFaturasizSatis.Checked == false && chkFSatisİade.Checked == false) altSorgu = " and islemTuru = 'hiçbirinigetirme' ";
            else if (chkFAlisİade.Checked == true && chkFFaturaliAlis.Checked == true && chkFFaturaliSatis.Checked == true && chkFFaturasizAlis.Checked == true && chkFFaturasizSatis.Checked == true && chkFSatisİade.Checked == true) altSorgu = "";
            else
            {
                if (chkFAlisİade.Checked == true) altSorgu = altSorgu + " or islemTuru = 'Alış İade'";
                if (chkFFaturaliAlis.Checked == true) altSorgu = altSorgu + " or islemTuru = 'Faturalı Alış'";
                if (chkFFaturaliSatis.Checked == true) altSorgu = altSorgu + " or islemTuru = 'Faturalı Satış'";
                if (chkFFaturasizAlis.Checked == true) altSorgu = altSorgu + " or islemTuru = 'Faturasız Alış'";
                if (chkFFaturasizSatis.Checked == true) altSorgu = altSorgu + " or islemTuru = 'Faturasız Satış'";
                if (chkFSatisİade.Checked == true) altSorgu = altSorgu + " or islemTuru like 'Satış İade'";
                altSorgu = "  and (" + altSorgu.Substring(4) + ")";
            }
            sorgu = sorgu + altSorgu;
            sorgu = sorgu + " and islemTuru not in ('Gelen Transfer','Giden Transfer')";
            if (chkFİslemTarihi.Checked == true) sorgu = sorgu + " and (islemTarihi between '" + dtFİslemTarihi1.Value + "' and '" + dtFİslemTarihi2.Value + "') ";
            if (cmbFSubeler.Text != "") sorgu = sorgu + " and subeid =" + ComboboxItem.getSelectedValue(cmbFSubeler);
            if (cmbFKullanicilar.Text != "") sorgu = sorgu + " and kullaniciid =" + ComboboxItem.getSelectedValue(cmbFKullanicilar);
            if (chkSilinenKayitlariGoster.Checked == true) sorgu = sorgu + " and silindimi='1' ";
            if (chkSilinenKayitlariGoster.Checked == false) sorgu = sorgu + " and silindimi='0' ";
            //if (chkWebKayitlariniGoster.Checked == true) sorgu = sorgu + " and ortam like '%web%' ";
            //if (chkWebKayitlariniGoster.Checked == false) sorgu = sorgu + " and ortam not like '%web%' ";
            if (chkHesabaİslenmeyenKayitlariGoster.Checked == true) sorgu = sorgu + " and hesabaislendimi='0' ";
            if (chkHesabaİslenmeyenKayitlariGoster.Checked == false) sorgu = sorgu + " and hesabaislendimi='1' ";

            double toplamTutar = 0;
            double toplamMaliyet = 0;
            double toplamKar = 0;
            int i = 0;
            double karZarar = 0;
            SqlDataReader dr = veri.getDatareader("select adiSoyadi, islemTarihi, islemSaati, islemTuru, genelTop, maliyet, karZarar from sorkarzarar where firmaid = " + firma.firmaid + sorgu + "");
            while (dr.Read())
            {
                try
                {
                    rpr.ekleYazi(new rapor.yazi(String.Format("{0:d}", Convert.ToDateTime(dr["islemTarihi"])) + " " + dr["islemSaati"].ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(5, 20 + i * 4, 29, 4), false));
                    rpr.ekleYazi(new rapor.yazi(dr["adiSoyadi"].ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(35, 20 + i * 4, 49, 4), false));
                    rpr.ekleYazi(new rapor.yazi(dr["islemTuru"].ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(85, 20 + i * 4, 34, 4), false));
                    rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", Convert.ToDouble(dr["genelTop"])), new Font("Arial", 9, FontStyle.Regular), new Rectangle(120, 20 + i * 4, 24, 4), StringFormatFlags.DirectionRightToLeft, true));
                    rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", Convert.ToDouble(dr["maliyet"])), new Font("Arial", 9, FontStyle.Regular), new Rectangle(145, 20 + i * 4, 24, 4), StringFormatFlags.DirectionRightToLeft, true));
                    karZarar = Convert.ToDouble(dr["genelTop"]) - Convert.ToDouble(dr["maliyet"]);
                    if (Convert.ToDouble(dr["genelTop"]) < 0)
                        karZarar = Convert.ToDouble(dr["genelTop"]) + Convert.ToDouble(dr["maliyet"]);
                    rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", karZarar), new Font("Arial", 9, FontStyle.Regular), new Rectangle(170, 20 + i * 4, 24, 4), StringFormatFlags.DirectionRightToLeft, true));
                    i++;
                    rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, 20 + i * 4, 20 + i * 4));
                    toplamTutar += Convert.ToDouble(dr["genelTop"]);
                    toplamMaliyet += Convert.ToDouble(dr["maliyet"]);
                    if(!dr["islemTuru"].ToString().Contains("İade"))
                    toplamKar += karZarar;
                }
                catch
                {
                }
            }
            int yukseklik = 25 + i * 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik += 3;
            rpr.ekleYazi(new rapor.yazi("Genel Top: " + string.Format("{0:n2}", toplamTutar) + "     Toplam Maliyet: " + string.Format("{0:n2}", toplamMaliyet) + "     Toplam Kâr: " + string.Format("{0:n2}", toplamKar), new Point(5, yukseklik)));
            yukseklik += 3;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + i.ToString() + "       Yazdırma Tarihi: " + DateTime.Now.ToString() + "       www.elmaryazilim.com", new Point(5, yukseklik)));

        }

        private void cmbFSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbFKullanicilar, ComboboxItem.getSelectedValue(cmbFSubeler));
        }
    }
}
