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
    public partial class frmBankaHavaleEft2 : Form
    {
        private long bankaislemid = 0;
        private long cariid = 0;
        private int grupid = 0;
        private long ticaretAyrintiid = 0;
        public frmTicaret _frmTicaret = null;
        private string aciklama = "";
        private string islemTipi = "";
        private double tutar = 0;
        public frmBankaHavaleEft2()
        {
            baslangic();
        }
        void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(this);
            NesneGorselleri.kontrolEkle(panel1);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.dataGridView(dgAlanHesap);
            cmbCariler.Items.Clear();
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
            listeler.doldurSube(cmbESubeler);
            alanHesabiListele();
        }

         public frmBankaHavaleEft2(long cariid, string cariAdiSoyadi, string tutar, string islemTipi, DateTime islemTarihi, int grupid, long ticaretAyrintiid, string aciklama)
        {
            baslangic();
            this.cariid = cariid;
            this.grupid = grupid;
            this.ticaretAyrintiid = ticaretAyrintiid;
            this.islemTipi = islemTipi;

            cmbCariler.Text = cariAdiSoyadi;
            cmbCariler.Enabled = false;

            dtİslemTarihi.Value = islemTarihi;

            dtİslemTarihi.Enabled = false;
            //cmbEKullanicilar.Enabled = false;
            //cmbESubeler.Enabled = false;

            txtTutar.Text = string.Format("{0:n2}", Convert.ToDouble(tutar));
            txtTutar.Enabled = false;

            this.aciklama = aciklama;
        }

        public frmBankaHavaleEft2(long cariid, string cariAdiSoyadi)
        {
            baslangic();
            this.cariid = cariid;

            cmbCariler.Text = cariAdiSoyadi;
            cmbCariler.Enabled = false;
        }

        public void alanHesabiListele()
        {
            dgAlanHesap.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select bankaHesapid, bankaid, bankaAdi, subeNo, hesapAdi, hesapNo from sorBankaHesaplari where firmaid = " + firma.firmaid + " and silindimi = '0' order by hesapAdi asc");
            while (dr.Read())
            {
                dgAlanHesap.Rows.Add(dr["bankaHesapid"].ToString(), dr["bankaid"].ToString(), dr["bankaAdi"].ToString(), dr["subeNo"].ToString(), dr["hesapAdi"].ToString(), dr["hesapNo"].ToString());
            }
            dgAlanHesap.ClearSelection();
        }

        private void btnBankahesabiEkle_Click(object sender, EventArgs e)
        {
            frmBankaHesapEkle frm = new frmBankaHesapEkle();
            frm.Show();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (dgAlanHesap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Banka Hesabı Seçmediniz.", firma.programAdi);
                dgAlanHesap.Select();
                return;
            }
            if (txtTutar.Text == "0")
            {
                MessageBox.Show("Tutar Girin", firma.programAdi);
                txtTutar.Select();
                return;
            }
            if(cmbCariler.SelectedIndex==-1)
            {
                MessageBox.Show("Cari Seçin", firma.programAdi);
                cmbCariler.Select();
                return;
            }

            if (ComboboxItem.seciliMetinKontrolu(cmbESubeler) == false)
            {
                MessageBox.Show("Şubeyi listeden seçin", firma.programAdi);
                cmbESubeler.Select();
                return;
            }
            if (ComboboxItem.seciliMetinKontrolu(cmbEKullanicilar) == false)
            {
                MessageBox.Show("Kullanıcıyı listeden seçin", firma.programAdi);
                cmbEKullanicilar.Select();
                return;
            }
            cariid = Convert.ToInt32(listeler.getCariid()[cmbCariler.SelectedIndex]);
            string eklenenBankaislemid = veri.getdatacell("Exec spSetBankaislemleri " + bankaislemid + "," + dgAlanHesap.CurrentRow.Cells["bankaHesapid"].Value + ",0,0,'0',0,0,0," + cariid + "," + txtTutar.Text.Replace(".", "").Replace(",", ".") + ",'" + txtDovizKuru.Text + "'," + txtDovizDegeri.Text.Replace(".", "").Replace(",", ".") + ",'" + txtAcklama.Text + "','" + cmbislemTipi.Text + "','" + dtİslemTarihi.Value + "'," + firma.firmaid + "," + Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)) + "," + Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)) + "");

            double borc = 0; double alacak = 0;
            //Açık Hesap Aktarılıyor
            borc = 0; alacak = 0;
            if (this.cmbislemTipi.Text.Contains("Gelen"))
            {
                borc = Convert.ToDouble(txtTutar.Text);
            }
            else if (this.cmbislemTipi.Text.Contains("Giden"))
            {
                alacak = Convert.ToDouble(txtTutar.Text);
            }
            if (grupid != 0)
            {
                acikHesap.ekle(0, ticaretAyrintiid, 0, 0, 0, cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), alacak, borc, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Açık Hesap", islemTipi, "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, 0);
                acikHesap.ekle(0, ticaretAyrintiid, 0, 0, Convert.ToInt32(eklenenBankaislemid), cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), borc, alacak, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Banka", cmbislemTipi.Text, "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, 0);
            }
            else
            {
                acikHesap.ekle(0, ticaretAyrintiid, 0, 0, Convert.ToInt32(eklenenBankaislemid), cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), borc, alacak, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Peşin", cmbislemTipi.Text, "Banka", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, duzenlemeBakiyesi);
            }
            if (_frmTicaret != null)
            {
                _frmTicaret.yeniKayit();
                ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
            }
            this.Close();
        }
        double duzenlemeBakiyesi = 0;
        private void cmbESubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar, ComboboxItem.getSelectedValue(cmbESubeler));
        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDovizliTutar.Text = (Convert.ToDouble(txtTutar.Text) * Convert.ToDouble(txtDovizDegeri.Text)).ToString();
            }
            catch (Exception) { }
        }

        private void txtDovizKuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDovizDegeri.Text = "1";
                if (txtDovizKuru.SelectedIndex == 1) txtDovizDegeri.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
                else if (txtDovizKuru.SelectedIndex == 2) txtDovizDegeri.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
            }
            catch { }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            //if (_frmTicaret != null)
            //{
            //    _frmTicaret._pesinat = Convert.ToDouble(txtPesinat.Text);
            //    _frmTicaret.yeniKayit();
            //    ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
            //    this.Close();
            //}
            txtAcklama.Clear();
            txtTutar.Text = "0";
            txtDovizliTutar.Text = "0";
            txtTutar.Select();
            dgAlanHesap.ClearSelection();
            lblDurum.Text = "Temizlendi";
        }

        private void frmBankaHavaleEft2_Load(object sender, EventArgs e)
        {

        }
    }
}
