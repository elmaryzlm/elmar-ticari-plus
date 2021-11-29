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
    public partial class frmCariEkstresi : Form
    {

        long seciliCariid = 0;
        rapor rpr;
        int seciliSubeid = 0;
        public frmCariEkstresi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(pnlTarih);
            NesneGorselleri.kontrolEkle(this);
            cariListesiniYenile();
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

        private void frmCariEkstresi_Load(object sender, EventArgs e)
        {

        }
        private void btnOnizleme_Click(object sender, EventArgs e)
        {
            if (raporOlustur())
            { rpr.onizleme(); }
        }
        bool raporOlustur()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 10;
            rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(10, y, rpr._kagitGenisligi - 20, rpr._kagitYuksekligi -  y * 3/2));
            Image img =Selahattin.logoGetir();
            int resimGenişlik = 0;
            if (img != null)
            {
                //290-50-10
                resimGenişlik = img.Height;
                rpr.ekleSabitResim(new rapor.sabitResim(img, new Rectangle(rpr._kagitGenisligi / 2 - 20, 12, img.Width, resimGenişlik)));
                y += resimGenişlik+5;
            }
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Hesap Ekstresi",new Font("Arial", 12, FontStyle.Bold), new Point(80,y)));
            y += 10;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih", new Font("Arial", 9, FontStyle.Underline), new Point(10, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Borç", new Font("Arial", 9, FontStyle.Underline), new Rectangle(30,y,19,4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Alacak", new Font("Arial", 9, FontStyle.Underline), new Rectangle(50, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Doviz", new Font("Arial", 9, FontStyle.Underline), new Point(70, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Bakiye", new Font("Arial", 9, FontStyle.Underline), new Rectangle(90, y, 24, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Türü", new Font("Arial", 9, FontStyle.Underline), new Point(115, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Açıklama", new Font("Arial", 9, FontStyle.Underline), new Point(150, y)));
            string sorgu = "";
            seciliCariid = 0;
            seciliSubeid = 0;
            if (cmbCariadi.SelectedIndex >= 0)
            {
                seciliCariid = listeler.getCariid()[cmbCariadi.SelectedIndex];
                sorgu = sorgu + " and cariid = " + seciliCariid + "";
            }
            else {
                MessageBox.Show("Lütfen bir cari seçin", firma.programAdi);
                return false;
            }
            if (cmbSubeler.SelectedIndex > 0)
            {
                seciliSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbSubeler));
                sorgu = sorgu + " and subeid = " + seciliSubeid + "";
            }
            if (rdTariharaligi.Checked) sorgu = sorgu + " and (kayitTarihi between '" + dtTarih1.Value + "' and '" + dtTarih2.Value + "') ";
            if (rdArtanSiralama.Checked) sorgu = sorgu + " order by kayitTarihi asc, acikHesapid asc ";
            else if (rdAzalanSiralama.Checked) sorgu = sorgu + " order by kayitTarihi desc, acikHesapid desc ";
            SqlDataReader dr = veri.getDatareader("Select kayitTarihi, borc, alacak, dovizTuru, bakiye,islemTuru+' ' +islemTuru2 as islemTuru,aciklama from sorAcikHesapEkstresi Where firmaid = " + firma.firmaid + " and cariid = " + seciliCariid + "");
            while (dr.Read())
            {
                y += 4;
                rpr.ekleYazi(new rapor.yazi(string.Format("{0:d}",Convert.ToDateTime(dr["kayitTarihi"])), new Rectangle(10, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr["borc"].ToString(), new Rectangle(30, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["alacak"].ToString(), new Rectangle(50, y, 19, 3), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["dovizTuru"].ToString(), new Rectangle(70, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr["bakiye"].ToString(), new Rectangle(90, y, 24, 3),StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(dr["islemTuru"].ToString(), new Rectangle(115, y, 34, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr["aciklama"].ToString(), new Rectangle(150, y, 59, 3), false));
                rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y + 4, y + 4));
            }
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y)); y += 2;
            rpr.ekleYazi(new rapor.yazi("Cari Adı Soyadı: " + cmbCariadi.Text, new Point(10, y)));
            return true;
        }

        private void cmbCariadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void rdTumtarihler_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTumtarihler.Checked) pnlTarih.Enabled = false;
            else pnlTarih.Enabled = true;
        }
    }
}
