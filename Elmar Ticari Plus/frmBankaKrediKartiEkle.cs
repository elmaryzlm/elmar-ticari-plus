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
    public partial class frmBankaKrediKartiEkle : Form
    {
        
        private void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(groupBox9);
            NesneGorselleri.kontrolEkle(this);
        }

        public frmBankaKrediKartiEkle()
        {
            baslangic();
        }

        private string krediKartid="0";
        public frmBankaKrediKartiEkle(string krediKartid, string hesapAdi, string hesapKesim, string sonOdeme, string kartLimiti, string ayrinti)
        {
            //Düzenle
            baslangic();
            this.Text = "Kredi Kartı Düzenle";
            this.krediKartid = krediKartid;
            this.txtAyrinti.Text = ayrinti;
            this.txtHesapKesim.Value = Convert.ToInt32(hesapKesim);
            this.txtSonOdemeGunu.Value = Convert.ToInt32(sonOdeme);
            this.txtKartLimiti.Text = kartLimiti;
            this.cmbBankaHesabi.Text = hesapAdi;
        }
        public frmBankaKrediKarti _frmBankaKrediKarti = null;
        private void frmBankaKrediKartiEkle_Load(object sender, EventArgs e)
        {
            getHesapAdi();
        }
        List<int> listBankaHesapid = new List<int>();
        public void getHesapAdi()
        {
            listBankaHesapid.Clear();
            cmbBankaHesabi.Items.Clear();
            SqlDataReader dr = veri.getDatareader("select bankaHesapid, hesapAdi from sorBankaHesaplari where silindimi = '0' and firmaid = " + firma.firmaid + " and hesapTuru like '%Kendi%' order by hesapAdi asc");
            while (dr.Read())
            {
                cmbBankaHesabi.Items.Add(dr["hesapAdi"].ToString());
                listBankaHesapid.Add(Convert.ToInt32(dr["bankaHesapid"]));
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankaHesabi.Items.Contains(cmbBankaHesabi.Text) == false)
                {
                    MessageBox.Show("Geçerli bir Banka Hesabı Seçin", firma.programAdi);
                    cmbBankaHesabi.Select();
                    return;
                }
                string eklenenKrediKartiid = veri.getdatacell("exec spSetBankaKrediKarti "+krediKartid+", " + listBankaHesapid[cmbBankaHesabi.SelectedIndex] + ", " + txtHesapKesim.Value.ToString() + ", " + txtSonOdemeGunu.Value.ToString() + ",'" + txtKartLimiti.Text.Replace(".", "").Replace(",", ".") + "', '" + txtAyrinti.Text + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");
                if (_frmBankaKrediKarti != null) _frmBankaKrediKarti.bankaListele();
                this.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt İşleminde Hata Oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnBankaHesabiEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Banka_Hesabı_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaHesapEkle frm = new frmBankaHesapEkle(this);
            frm.Show();
        }
    }
}
