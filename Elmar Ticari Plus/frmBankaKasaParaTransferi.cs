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
    public partial class frmBankaKasaParaTransferi : Form
    {
        private long bankaislemid = 0;
        public frmBankaKasaParaTransferi()
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
            listeler.doldurSube(cmbESubeler);
            listeler.doldurSube(cmbESubeler2);
            bankaHesabiListele();
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
            string eklenenBankaislemid = veri.getdatacell("Exec spSetBankaislemleri " + bankaislemid + "," + dgAlanHesap.CurrentRow.Cells["bankaHesapid"].Value + ",0,0,'0',0,0,0,0," + txtTutar.Text.Replace(".", "").Replace(",", ".") + ",'" + txtDovizKuru.Text + "'," + txtDovizDegeri.Text.Replace(".", "").Replace(",", ".") + ",'" + txtAcklama.Text + "','" + cmbislemTipi.Text + "','" + dtİslemTarihi.Value + "'," + firma.firmaid + "," + Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)) + "," + Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)) + "");
            if (cmbislemTipi.Text == "Kasaya Giden")
            {
                //Gelir Ekleniyor
                try
                {
                    veri.cmd("Exec [spSetGelirler2] " + gelirid + ", 'Banka Hesabımdan Aktarılan', '" + txtTutar.Text.Replace(".", "").Replace(",", ".") + "', '" + dtİslemTarihi.Value + "', '" + txtAcklama.Text + "'," + eklenenBankaislemid + ", " + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbESubeler2) + ", " + ComboboxItem.getSelectedValue(cmbEKullanicilar2) + "");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Kaydetme işleminde bir hata oluştu.\nHata Metni: " + hata.Message, firma.programAdi);
                }
            }
            else
            {
                try
                {
                    //Gider Ekleniyor
                    veri.cmd("Exec [spSetMasraflar2] " + masrafid + ", " + masrafKartid + ", '" + dtİslemTarihi.Value + "', '" + txtTutar.Text.Replace(".", "").Replace(",", ".") + "','0' , '" + txtAcklama.Text + "','Firma Gideri', 0, 0, 0,'" + eklenenBankaislemid + "', " + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbESubeler2) + ", " + ComboboxItem.getSelectedValue(cmbEKullanicilar2) + "");
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Kaydetme işleminde bir hata oluştu.\nHata Metni: " + hata.Message, firma.programAdi);
                }
            }
            
            this.Close();
        }
        int gelirid = 0, masrafid = 0, masrafKartid=0;
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
            txtAcklama.Clear();
            txtTutar.Text = "0";
            txtDovizliTutar.Text = "0";
            txtTutar.Select();
            dgAlanHesap.ClearSelection();
            lblDurum.Text = "Temizlendi";
        }

        private void btnBankahesabiEkle_Click(object sender, EventArgs e)
        {
            frmBankaHesapEkle frm = new frmBankaHesapEkle();
            frm.Show();
        }
        public void bankaHesabiListele()
        {
            dgAlanHesap.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select bankaHesapid, bankaid, bankaAdi, subeNo, hesapAdi, hesapNo from sorBankaHesaplari where firmaid = " + firma.firmaid + " and silindimi = '0' order by hesapAdi asc");
            while (dr.Read())
            {
                dgAlanHesap.Rows.Add(dr["bankaHesapid"].ToString(), dr["bankaid"].ToString(), dr["bankaAdi"].ToString(), dr["subeNo"].ToString(), dr["hesapAdi"].ToString(), dr["hesapNo"].ToString());
            }
            dgAlanHesap.ClearSelection();
        }
        private void frmBankaKasaParaTransferi_Load(object sender, EventArgs e)
        {

        }

        private void cmbESubeler2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar2, ComboboxItem.getSelectedValue(cmbESubeler2));
        }
    }
}
