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
    public partial class frmPersonelMaasListele : Form
    {
        public frmPersonelMaasListele()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgMaaslar);
            NesneGorselleri.kontrolEkle(grpİslemTarihi);
        }
        void listeleriDoldur()
        {
            cmbPersonelAdlari.Items.Clear();
            try { cmbPersonelAdlari.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
            listeler.doldurSube(cmbSubeler);
        }
        private void frmPersonelMaasListele_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
            maasListele();
        }

        public void maasListele()
        {
            string sorgu = " ";
            if (cmbPersonelAdlari.SelectedIndex >= 0) sorgu = sorgu + " and personelid = " + listeler.getPersonelid()[cmbPersonelAdlari.SelectedIndex] + " ";
            if (cmbislemTuru.SelectedIndex >= 0) sorgu = sorgu + " and turu = '" + cmbislemTuru.Text + "' ";
            if (txtTutar.Text != "") sorgu = sorgu + " and tutar " + cmbKalanGun.Text + " " + txtTutar.Text + " ";
            if (cmbSubeler.SelectedIndex >= 0) sorgu = sorgu + " and subeid = " + ComboboxItem.getSelectedValue(cmbSubeler) + " ";
            if (cmbKullanicilar.SelectedIndex >= 0) sorgu = sorgu + " and kullaniciid = " + ComboboxItem.getSelectedValue(cmbKullanicilar) + " ";
            if (chkKayitTarihi.Checked == true) sorgu = sorgu + " and kayitTarihi = '" + dtKayitTarihi.Value + "' ";
            if (chkSilinenKayitlariGoster.Checked == true) sorgu = sorgu + " and silindimi = '1' ";
            else sorgu = sorgu + " and silindimi = '0' ";
            dgMaaslar.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("select maasid, personelid, personelAdi, tutar, turu, kayitTarihi, kayitSaati, aciklama from sorPersonelMaas where firmaid = "+firma.firmaid+" "+sorgu+" order by kayitTarihi desc, kayitSaati desc");
            double toplamTutar = 0;
            while (dr.Read())
            {
                dgMaaslar.Rows.Add(dr["maasid"].ToString(), dr["personelid"].ToString(), dr["personelAdi"].ToString(), dr["turu"].ToString(), dr["tutar"].ToString(), dr["kayitTarihi"].ToString(), dr["kayitSaati"].ToString(), dr["kayitTarihi"].ToString().Substring(0,10) + " " + dr["kayitSaati"].ToString(), dr["aciklama"].ToString());
                if (dr["turu"].ToString() == "Maaş Girişi") toplamTutar += Convert.ToDouble(dr["tutar"]);
                else if (dr["turu"].ToString() == "Prim Girişi") toplamTutar += Convert.ToDouble(dr["tutar"]);
                else if (dr["turu"].ToString() == "Maaş Ödemesi") toplamTutar -= Convert.ToDouble(dr["tutar"]);
                else if (dr["turu"].ToString() == "Prim Ödemesi") toplamTutar -= Convert.ToDouble(dr["tutar"]);
                else if (dr["turu"].ToString() == "Avans") toplamTutar -= Convert.ToDouble(dr["tutar"]);
                else if (dr["turu"].ToString() == "Kesinti") toplamTutar -= Convert.ToDouble(dr["tutar"]);
                else if (dr["turu"].ToString() == "Yemek Ödemesi") toplamTutar -= Convert.ToDouble(dr["tutar"]);
                else if (dr["turu"].ToString() == "Yol Ödemesi") toplamTutar -= Convert.ToDouble(dr["tutar"]); 
            }
            lblBakiye.Text = String.Format("{0:n2}", toplamTutar)+" TL"; 
            lblKayitSayisi.Text = dgMaaslar.Rows.Count.ToString();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            maasListele();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(dgMaaslar.CurrentRow.Cells["personelAdi"].Value.ToString()+ " adi kaydı silmek istediğinizden emin misiniz ? ", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                veri.cmd("update tblPersonelMaas set silindimi = '1' where maasid = " + dgMaaslar.CurrentRow.Cells["maasid"].Value.ToString() + " ");
                dgMaaslar.Rows.Remove(dgMaaslar.CurrentRow);
            }
        }

        private void silmeİşleminiGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("update tblPersonelMaas set silindimi = '0' where maasid = " + dgMaaslar.CurrentRow.Cells["maasid"].Value.ToString() + " ");
            maasListele();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow rw = dgMaaslar.CurrentRow;
            frmPersonelMaasGirisi frm = new frmPersonelMaasGirisi(rw.Cells["maasid"].Value.ToString(), Convert.ToInt64(rw.Cells["personelid"].Value), rw.Cells["personelAdi"].Value.ToString(), rw.Cells["tutar"].Value.ToString(), rw.Cells["islemTuru"].Value.ToString(), Convert.ToDateTime(rw.Cells["kayitTarihiDegisken"].Value), rw.Cells["kayitSaatiDegisken"].Value.ToString(), rw.Cells["aciklama"].Value.ToString());
            frm.Show();
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
            maasListele();
        }
        rapor rpr3;
        void raporHazirla3()
        {
            rpr3 = new rapor();
            rpr3.yaziYazdirmaSiniri = 287;
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Personel Maaş Raporları", new Font("Arial", 15, FontStyle.Bold), new Point(80, 5)));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Personel Adı", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 39, 4), false));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("İşlem Tipi", new Font("Arial", 10, FontStyle.Underline), new Rectangle(45, 15, 29, 4), false));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Tutar", new Font("Arial", 10, FontStyle.Underline), new Rectangle(75, 15, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Tarih", new Font("Arial", 10, FontStyle.Underline), new Rectangle(95, 15, 19, 4), false));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Açıklama", new Font("Arial", 10, FontStyle.Underline), new Rectangle(115, 15, 90, 4), false));
            for (int i = 0; i < dgMaaslar.Rows.Count; i++)
            {
                DataGridViewRow r = dgMaaslar.Rows[i];
                rpr3.ekleYazi(new rapor.yazi(r.Cells["personelAdi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(5, 20 + i * 4, 39, 4), false));
                rpr3.ekleYazi(new rapor.yazi(r.Cells["islemTuru"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(45, 20 + i * 4, 29, 4), false));
                rpr3.ekleYazi(new rapor.yazi(r.Cells["tutar"].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), new Rectangle(75, 20 + i * 4, 19, 4), StringFormatFlags.DirectionRightToLeft, true));
                rpr3.ekleYazi(new rapor.yazi(r.Cells["kayitTarihi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(95, 20 + i * 4, 19, 4), false));
                rpr3.ekleYazi(new rapor.yazi(r.Cells["aciklama"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(115, 20 + i * 4, 90, 4), false));
                //rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, 20 + i * 4, 20 + i * 4));
            }
            int yukseklik = 25 + dgMaaslar.Rows.Count * 4;
            rpr3.ekleCizgi(new rapor.cizgi(5, rpr3._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik += 3;
            rpr3.ekleYazi(new rapor.yazi("Toplam Bakiye: " + lblBakiye.Text + "             Kayıt Sayısı: " + lblKayitSayisi.Text + "            Yazdırma Tarihi: " + DateTime.Now.ToString() + "            www.elmaryazilim.com", new Point(5, yukseklik)));

        }
        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {
            raporHazirla3();
            rpr3.onizleme();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            raporHazirla3();
            rpr3.yazdir();
        }
    }
}
