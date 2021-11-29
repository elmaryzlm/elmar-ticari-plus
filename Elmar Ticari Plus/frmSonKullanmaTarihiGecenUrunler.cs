using elmarLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmSonKullanmaTarihiGecenUrunler : Form
    {
        public frmSonKullanmaTarihiGecenUrunler()
        {
            InitializeComponent();
            this.Text = "Son Kullanma Tarihine Göre Raporlama";
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgTicaretUrunler);
            NesneGorselleri.kontrolEkle(panel12);
            NesneGorselleri.kontrolEkle(groupBox9);
            listeler.doldurSube(cmbSubeler);
            cmbKategori.Items.Clear();
            try
            {
                cmbKategori.Items.AddRange(listeler.getKategoriadi());
                cmbUrunİsmi.Items.AddRange(listeler.getUrunisim());
            }
            catch
            {

            }
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = " ";
                if (txtBarkod.Text != "") sorgu = sorgu + " and barkod = '" + txtBarkod.Text + "' ";
                if (cmbUrunİsmi.Text != "") sorgu = sorgu + " and urunAdi = '" + cmbUrunİsmi.Text + "' ";
                if (txtSeriNo.Text != "") sorgu = sorgu + " and seriNo = '" + txtSeriNo.Text + "' ";
                if (txtStokKodu.Text != "") sorgu = sorgu + " and stokkodu = '" + txtStokKodu.Text + "' ";
                if (cmbKategori.Text != "") sorgu = sorgu + " and kategoriAdi= '" + cmbKategori.Text + "' ";

                //diğer filtreler uygulanıyor
                if(chbSonKT.Checked==true) sorgu = sorgu + " and (skt between '" + dtSonKTBaslangic.Value + "' and '" + dtSonKTBitis.Value + "') ";
                if (chkİslemTarihi.Checked == true) sorgu = sorgu + " and (islemTarihi between '" + dtİslemTarihi1.Value + "' and '" + dtİslemTarihi2.Value + "') ";
                if (cmbSubeler.Text != "") sorgu = sorgu + " and subeid =" + ComboboxItem.getSelectedValue(cmbSubeler);
                if (cmbKullanicilar.Text != "") sorgu = sorgu + " and kullaniciid =" + ComboboxItem.getSelectedValue(cmbKullanicilar);
                string form_sorgu = " and (islemTuru like '%Alış%' ) ";
                sorgu = sorgu + form_sorgu;
                dgTicaretUrunler.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("SELECT [ticaretid],[ticaretAyrintiid],[stokid],[barkod],[urunAdi],[miktar] miktar,[satilanMiktar],[birim],[katsayi],[birimFiyat],[alisFiyat],[kdv],[kdvTipi],[isk1],[isk2],[isk3],abs([AraTop]) AraTop,abs([KdvTop])KdvTop,abs([Toplam])Toplam,[dovizTuru],[dovizDegeri],[kargoUcreti],[seriNo],[eklenmeTarihi],[subeid],[kullaniciid], [cariid], [adiSoyadi],[islemTarihi],[islemSaati],[islemTuru],[hesabaislendimi], [onay],[skt] FROM sorTicaret where skt is not null and firmaid = " + firma.firmaid + sorgu + " order by ticaretid desc");
                double toplamMiktar = 0, toplamBakiye = 0;
                double iskonto = 0;
                double tutarKar = 0;
                while (dr.Read())
                {

                    dgTicaretUrunler.Rows.Add(dr["ticaretid"].ToString(), dr["ticaretAyrintiid"].ToString(), dr["stokid"].ToString(), dr["barkod"].ToString(), dr["urunAdi"].ToString(), dr["miktar"].ToString(), dr["satilanMiktar"].ToString(), dr["birim"].ToString(), dr["katsayi"].ToString(), dr["birimFiyat"].ToString(), tutarKar, dr["kdv"].ToString(), dr["kdvTipi"].ToString(), dr["isk1"].ToString(), dr["isk2"].ToString(), dr["isk3"].ToString(), (Convert.ToDouble(dr["AraTop"]) * (1)).ToString(), dr["KdvTop"].ToString(), dr["Toplam"].ToString(), dr["dovizTuru"].ToString(), dr["dovizDegeri"].ToString(), dr["kargoUcreti"].ToString(), dr["seriNo"].ToString(),Convert.ToDateTime(dr["skt"].ToString()).ToString("dd.MM.yyyy"), dr["eklenmeTarihi"].ToString(), dr["subeid"].ToString(), dr["kullaniciid"].ToString(), dr["cariid"].ToString(), dr["adiSoyadi"].ToString(), dr["islemTarihi"].ToString().Substring(0, 10) + " " + dr["islemSaati"].ToString(), dr["islemTuru"].ToString());
                    toplamMiktar += (Convert.ToDouble(dr["miktar"]) * Convert.ToDouble(dr["katsayi"]));
                    toplamBakiye += (Convert.ToDouble(dr["Toplam"]) * Convert.ToDouble(dr["dovizDegeri"]));
                }
                lblKayitSayisi.Text = dgTicaretUrunler.Rows.Count.ToString();
                lblToplamMiktar.Text = toplamMiktar.ToString();
                lblBakiye.Text = String.Format("{0:n}", toplamBakiye + iskonto) + " TL";
            }
            catch (Exception hata)
            {
                // MessageBox.Show(hata.Message);
            }
        }

        private void frmSonKullanmaTarihiGecenUrunler_Load(object sender, EventArgs e)
        {
            btnSorgula.PerformClick();
        }

        rapor rpr;

        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {
            raporHazirla();
            rpr.onizleme();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            raporHazirla();
            rpr.yazdir();
        }

        void raporHazirla()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = 205;
            rpr.sayfayiYatayYap();
            Image img = Selahattin.logoGetir();
            int resimGenişlik = 0;
            rpr.ekleSabitYazi(new rapor.sabitYazi(this.Text, new Font("Arial", 15, FontStyle.Bold), new Point(100, 5)));
            rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(2, 4, rpr._kagitGenisligi - 4, rpr._kagitYuksekligi - 4 * 3 / 2));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari", new Font("Arial", 10, FontStyle.Underline), new Rectangle(2, 15 + resimGenişlik, 24, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Barkod", new Font("Arial", 10, FontStyle.Underline), new Rectangle(27, 15 + resimGenişlik, 22, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ürün Adı", new Font("Arial", 10, FontStyle.Underline), new Rectangle(50, 15 + resimGenişlik, 39, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Mik. x Birim F.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(90, 15 + resimGenişlik, 24, 4), false));

            rpr.ekleSabitYazi(new rapor.sabitYazi("KDV%", new Font("Arial", 10, FontStyle.Underline), new Rectangle(115, 15 + resimGenişlik, 16, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Isk1", new Font("Arial", 10, FontStyle.Underline), new Rectangle(132, 15 + resimGenişlik, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Isk2", new Font("Arial", 10, FontStyle.Underline), new Rectangle(144, 15 + resimGenişlik, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Isk3", new Font("Arial", 10, FontStyle.Underline), new Rectangle(156, 15 + resimGenişlik, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("ARATOP", new Font("Arial", 9, FontStyle.Underline), new Rectangle(168, 15 + resimGenişlik, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("KDVTOP", new Font("Arial", 9, FontStyle.Underline), new Rectangle(186, 15 + resimGenişlik, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("TOPLAM", new Font("Arial", 9, FontStyle.Underline), new Rectangle(204, 15 + resimGenişlik, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Doviz", new Font("Arial", 10, FontStyle.Underline), new Rectangle(222, 15 + resimGenişlik, 19, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih", new Font("Arial", 10, FontStyle.Underline), new Rectangle(242, 15 + resimGenişlik, 19, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Türü", new Font("Arial", 10, FontStyle.Underline), new Rectangle(262, 15 + resimGenişlik, 30, 4), false));

            double toplamTutar = 0, toplamMiktar = 0;
            for (int i = 0; i < dgTicaretUrunler.Rows.Count; i++)
            {
                DataGridViewRow r = dgTicaretUrunler.Rows[i];
                rpr.ekleYazi(new rapor.yazi(r.Cells["adiSoyadi"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(2, (20 + resimGenişlik) + i * 4, 24, 3), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["barkod"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(27, (20 + resimGenişlik) + i * 4, 22, 3), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["urunAdi"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(50, (20 + resimGenişlik) + i * 4, 39, 3), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["miktar"].Value.ToString() + " " + r.Cells["birim"].Value.ToString() + " x " + r.Cells["birimFiyat"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(90, (20 + resimGenişlik) + i * 4, 24, 3), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["kdv2"].Value.ToString() + " " + r.Cells["kdvTipi2"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(115, 20 + i * 4, 16, 3), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["isk1"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(132, (20 + resimGenişlik) + i * 4, 11, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["isk2"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(144, (20 + resimGenişlik) + i * 4, 11, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["isk3"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(156, (20 + resimGenişlik) + i * 4, 11, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["AraTop"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(168, (20 + resimGenişlik) + i * 4, 17, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(r.Cells["KdvTop"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(186, (20 + resimGenişlik) + i * 4, 17, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(r.Cells["Toplam"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(204, (20 + resimGenişlik) + i * 4, 17, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(r.Cells["dovizTuru2"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(222, (20 + resimGenişlik) + i * 4, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(string.Format("{0:d}", Convert.ToDateTime(r.Cells["islemTarihi2"].Value)), new Font("Arial", 8, FontStyle.Regular), new Rectangle(242, (20 + resimGenişlik) + i * 4, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["islemTuru2"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(262, (20 + resimGenişlik) + i * 4, 30, 3), false));
                rpr.ekleCizgi(new rapor.cizgi(2, rpr._kagitGenisligi - 2, 20 + i * 4 + 4, 20 + i * 4 + 4));
                toplamMiktar += (Convert.ToDouble(r.Cells["miktar"].Value) * Convert.ToDouble(r.Cells["katsayi"].Value));
                toplamTutar += (Convert.ToDouble(r.Cells["Toplam"].Value) * Convert.ToDouble(r.Cells["dovizDegeri2"].Value));
            }
            int yukseklik = (25 + resimGenişlik) + dgTicaretUrunler.Rows.Count * 4;
            rpr.ekleCizgi(new rapor.cizgi(2, rpr._kagitGenisligi - 5, yukseklik, yukseklik));
            yukseklik += 1;
            rpr.ekleYazi(new rapor.yazi("Toplam Miktar: " + toplamMiktar.ToString() + "                   Toplam Tutar: " + string.Format("{0:n2}", toplamTutar) + " TL", new Point(2, yukseklik)));
            yukseklik += 4;
            rpr.ekleCizgi(new rapor.cizgi(2, rpr._kagitGenisligi - 5, yukseklik, yukseklik));
            yukseklik += 1;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + dgTicaretUrunler.Rows.Count.ToString() + "       Yazdırma Tarihi: " + DateTime.Now.ToString() + "       www.elmaryazilim.com", new Point(2, yukseklik)));
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
        }
    }
}
