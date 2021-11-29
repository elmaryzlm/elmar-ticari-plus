using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.Data.SqlClient;
namespace Elmar_Ticari_Plus
{
    public partial class frmBankaHesapEkle : Form
    {
        public frmBankaHesapEkle()
        {
            baslangic();
        }
        public frmBankaHesapEkle(string bankaHesapid, string bankaid, string bankaAdi, string hesapAdi, string subeNo, string hesapNo, string iban, string ayrinti, string cariid, string cariAdiSoyadi, string hesapTuru)
        {
            //Düzenle
            baslangic();
            this.Text = "Banka Hesabı Düzenle";
            this.bankaHesapid = Convert.ToInt32(bankaHesapid);
            this.txtAyrinti.Text = ayrinti;
            this.txtHesapAdi.Text = hesapAdi;
            this.txtHesapNo.Text = hesapNo;
            this.txtIban.Text = iban;
            if (hesapTuru.Contains("Kendi")) rdKendiHesabim.Checked = true;
            else if (hesapTuru.Contains("Cari")) rdCariHesabi.Checked = true;
            this.txtSubeNo.Text = subeNo;
            this.cmbBankalar.Text = bankaAdi;
            this.seciliCariid = Convert.ToInt32(cariid);
            this.cmbCariler.Text = cariAdiSoyadi;
        }

        private void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(this);
            NesneGorselleri.kontrolEkle(grpHesapTuru);
        }


        public frmBankaHesapEkle(frmBankaKrediKartiEkle _frmBankaKrediKartiEkle)
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            this._frmBankaKrediKartiEkle = _frmBankaKrediKartiEkle;
            txtHesapAdi.Text = "Kredi Kartı Hesabı";
            islemTuru2 = "Kredi Kartı Hesabı";
            rdCariHesabi.Enabled = false;
            cmbCariler.Enabled = false;
        }
        string islemTuru1="Kendi", islemTuru2 = "Banka Hesabı";
        int bankaHesapid = 0;
        public frmBankaHesaplari _frmBankaHesaplari = null;
        public frmBankaKrediKartiEkle _frmBankaKrediKartiEkle = null;
        private void frmBankaHesapEkle_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
        }
        List<int> listBankaid = new List<int>();
        void listeleriDoldur()
        {
            cmbCariler.Items.Clear();
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
            cmbBankalar.Items.Clear();
            listBankaid.Clear();
            SqlDataReader dr = veri.getDatareader("select bankaid, bankaAdi from tblBankaisimleri where bankaid > 1 order by bankaAdi");
            while (dr.Read())
            {
                listBankaid.Add(Convert.ToInt32(dr["bankaid"]));
                cmbBankalar.Items.Add(dr["bankaAdi"].ToString());
            }
        }
        private long seciliCariid = 0;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string hesapTuru = islemTuru1 + " " + islemTuru2;
                if (islemTuru1 == "Kendi") hesapTuru = hesapTuru + "m";
                string eklenenBankaHesapid = veri.getdatacell("exec spSetBankaHesap " + bankaHesapid + ", " + listBankaid[cmbBankalar.SelectedIndex] + ", '" + txtHesapAdi.Text + "', '" + txtSubeNo.Text + "', '" + txtHesapNo.Text + "', '" + txtIban.Text + "', '" + txtAyrinti.Text + "'," + seciliCariid + ",'" + hesapTuru + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + " ");
                
                if (_frmBankaHesaplari != null)
                {
                    _frmBankaHesaplari.dgBankaHesaplari.Rows.Add(eklenenBankaHesapid, listBankaid[cmbBankalar.SelectedIndex], cmbBankalar.Text, txtHesapAdi.Text,txtSubeNo.Text, txtHesapNo.Text, txtIban.Text, seciliCariid, cmbCariler.Text, hesapTuru, txtAyrinti.Text);
                    _frmBankaHesaplari.dgBankaHesaplari.Rows[_frmBankaHesaplari.dgBankaHesaplari.Rows.Count - 1].Cells["bankaAdi"].Selected = true;
                }
                if (_frmBankaKrediKartiEkle != null)
                {
                    _frmBankaKrediKartiEkle.getHesapAdi();
                    _frmBankaKrediKartiEkle.cmbBankaHesabi.Text = txtHesapAdi.Text;
                }
                this.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnBankaSec_Click(object sender, EventArgs e)
        {
            frmBankalar frm = new frmBankalar();
            frm._frmBankaHesapEkle = this;
            frm.Show();
        }

        private void rdCariHesabi_Click(object sender, EventArgs e)
        {
            cmbCariler.Enabled = true;
            islemTuru1 = "Cari";
        }

        private void rdKendiHesabim_Click(object sender, EventArgs e)
        {
            cmbCariler.Enabled = false;
            seciliCariid = 0;
            cmbCariler.SelectedIndex = -1;
            islemTuru1 = "Kendi";
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciliCariid = listeler.getCariid()[cmbCariler.SelectedIndex];
        }
    }
}
