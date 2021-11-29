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
    public partial class frmBankaRaporlari : Form
    {
        public frmBankaRaporlari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgBankaislemleri);
            NesneGorselleri.kontrolEkle(panel12);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(groupBox9);
            listeler.doldurSube(cmbSubeler);
        }

        private void frmBankaRaporlari_Load(object sender, EventArgs e)
        {
            chkİslemTarihi.Checked = true;
            cmbCariler.Items.Clear();
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
            bankaHesapListele();
            btnSorgula.PerformClick();
        }
        void bankaHesapListele()
        {
            cmbHesapAdi.Items.Clear();
            listBankaHesapid.Clear();
            SqlDataReader dr = veri.getDatareader("Select bankaHesapid, (bankaAdi+' '+hesapAdi) as bankaHesapAdi from sorBankaHesaplari where firmaid = " + firma.firmaid + " and silindimi = '0' order by bankaHesapAdi ");
            while (dr.Read())
            {
                listBankaHesapid.Add(dr["bankaHesapid"].ToString());
                cmbHesapAdi.Items.Add(dr["bankaHesapAdi"].ToString());
            }
        }
        List<string> listBankaHesapid = new List<string>();
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            string sorgu = " ";
            string altSorgu = " ";
            
            //Ödeme Türü Sorguları Oluşturuluyor----------------------
            if (chkPos.Checked == false && chkGidenEft.Checked == false && chkGelenEft.Checked == false && chkGelenHavale.Checked == false && chkKrediKarti.Checked == false && chkGidenHavale.Checked == false && chkParaYatirildi.Checked == false && chkParaCekildi.Checked == false && chkKasadanGelen.Checked == false && chkKasayaGiden.Checked == false && chkCek.Checked == false && chkSenet.Checked == false) altSorgu = " and islemTuru = '' ";
            else if (chkPos.Checked == true && chkGidenEft.Checked == true && chkGelenEft.Checked == true && chkGelenHavale.Checked == true && chkKrediKarti.Checked == true && chkGidenHavale.Checked == true && chkParaYatirildi.Checked == true && chkParaCekildi.Checked == true && chkKasadanGelen.Checked == true && chkKasayaGiden.Checked == true && chkCek.Checked == true && chkSenet.Checked == true) altSorgu = " ";
            else
            {
                if (chkPos.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Pos%'";
                if (chkKrediKarti.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Kredi Kartı%'";
                if (chkGidenEft.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Giden Eft%'";
                if (chkGelenEft.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Gelen Eft%'";
                if (chkGidenHavale.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Giden Havale%'";
                if (chkGelenHavale.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Gelen Havale%'";
                if (chkKasayaGiden.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Kasaya Giden%'";
                if (chkKasadanGelen.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Kasadan Gelen%'";
                if (chkParaYatirildi.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Para Yatırıldı%'";
                if (chkParaCekildi.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Para Çekildi%'";
                altSorgu = "  and (" + altSorgu.Substring(4) + ")";
            }
            sorgu = sorgu + altSorgu;               
            //diğer filtreler uygulanıyor
            if (cmbCariler.Text != "") sorgu = sorgu + " and cariid =" + listeler.getCariid()[cmbCariler.SelectedIndex];
            if (cmbHesapAdi.Text != "") sorgu = sorgu + " and bankaHesapid =" + listBankaHesapid[cmbHesapAdi.SelectedIndex];
            if (chkİslemTarihi.Checked == true) sorgu = sorgu + " and (islemTarihi between '" + dtİslemTarihi1.Value + "' and '" + dtİslemTarihi2.Value + "') ";
            if (cmbSubeler.Text != "") sorgu = sorgu + " and subeid =" + ComboboxItem.getSelectedValue(cmbSubeler);
            if (cmbKullanicilar.Text != "") sorgu = sorgu + " and kullaniciid =" + ComboboxItem.getSelectedValue(cmbKullanicilar);
            if (chkSilinenKayitlariGoster.Checked == true) sorgu = sorgu + " and silindimi='1' ";
            if (chkSilinenKayitlariGoster.Checked == false) sorgu = sorgu + " and silindimi='0' ";
            double toplamTutar = 0;
            dgBankaislemleri.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("SELECT [bankaislemid], [bankaHesapid], [hesapAdi], [krediKartid], [posid], [posAdi], [cekSenetid], [cariBankaHesapid], [cariKrediKartid], [cariid], [cariAdiSoyadi], [tutar], [doviz], [dovizKuru], [ayrinti], [islemTuru], [islemTarihi], [eklenmeTarihi], [silindimi], [subeid], [kullaniciid] FROM [sorBankaislemleri] where firmaid = " + firma.firmaid + sorgu + " order by islemTarihi, bankaislemid desc");
            while (dr.Read())
            {
                dgBankaislemleri.Rows.Add(dr["bankaislemid"].ToString(), dr["bankaHesapid"].ToString(), dr["hesapAdi"].ToString(), dr["krediKartid"].ToString(), dr["posid"].ToString(), dr["posAdi"].ToString(), dr["cekSenetid"].ToString(), dr["cariBankaHesapid"].ToString(), dr["cariKrediKartid"].ToString(), dr["cariid"].ToString(), dr["cariAdiSoyadi"].ToString(), String.Format("{0:n2}", Convert.ToDouble(dr["tutar"])),  dr["doviz"].ToString(), String.Format("{0:n2}", Convert.ToDouble(dr["dovizKuru"])), dr["islemTuru"].ToString(), String.Format("{0:d}", Convert.ToDateTime(dr["islemTarihi"])), dr["ayrinti"].ToString(), dr["eklenmeTarihi"].ToString(), dr["silindimi"].ToString(), dr["subeid"].ToString(), dr["kullaniciid"].ToString());
                toplamTutar += (Convert.ToDouble(dr["tutar"]) * Convert.ToDouble(dr["dovizKuru"]));
            }
            lblKayitSayisiF.Text = dgBankaislemleri.Rows.Count.ToString();
            lblBakiyeF.Text = String.Format("{0:n2}", toplamTutar);
        }

        private void işlemiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Banka_Hesabı_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            if (MessageBox.Show("Seçili kaydı silmek istiyor musunuz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                veri.cmd("Exec [spSilBankaislemi] " + firma.firmaid + "," + dgBankaislemleri.CurrentRow.Cells["bankaislemid"].Value + ", '1'");
                dgBankaislemleri.Rows.Remove(dgBankaislemleri.CurrentRow);
            }
        }

        private void silmeİşleminiGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("Exec [spSilBankaislemi] " + firma.firmaid + "," + dgBankaislemleri.CurrentRow.Cells["bankaislemid"].Value + ", '0'");
            btnSorgula.PerformClick();
        }

        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {

        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
        }

        private void cnsStokkart_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
