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
    public partial class frmFirmaBilgileri : Form
    {
        public frmFirmaBilgileri()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(this);
        }

        private void frmFirmaBilgileri_Load(object sender, EventArgs e)
        {
            listele();
        }

        void listele()
        {
            SqlDataReader dr = veri.getDatareader("SELECT [adi],[soyadi],[webSitesi],[siteBasligi],[aciklama],[demomu],[maxSubeSayisi],[maxKullaniciSayisi],[maxDosyaBoyutu],[eklenmeTarihi] FROM [ElmarTicariPlus].[dbo].[tblFirmaBilgileri] where firmaid = "+firma.firmaid+"");
            while (dr.Read())
            {
                txtFirmaAdi.Text = dr["adi"].ToString();
                txtFirmaSoyadi.Text = dr["soyadi"].ToString();
                txtWebSitesi.Text = dr["webSitesi"].ToString();
                txtSiteBasligi.Text = dr["siteBasligi"].ToString();
                txtAciklama.Text = dr["aciklama"].ToString();
                txtDemomu.Text = "Hayır";
                if(dr["demomu"].ToString() == "1") txtDemomu.Text = "Evet";
                txtMaxSubeSayisi.Text = dr["maxSubeSayisi"].ToString();
                txtMaxKullaniciSayisi.Text = dr["maxKullaniciSayisi"].ToString();
                txtMaxDosyaBoyutu.Text = dr["maxDosyaBoyutu"].ToString();
                txtEklenmeTarihi.Text = dr["eklenmeTarihi"].ToString();
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("exec spSetFirmaBilgileri " + firma.firmaid + ",'" + txtFirmaAdi.Text + "','" + txtFirmaSoyadi.Text + "','" + txtWebSitesi.Text + "','" + txtSiteBasligi.Text + "','" + txtAciklama.Text + "'");
                MessageBox.Show("Güncelleme Başarıyla Yapıldı");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde bir hata oluştu.\nHata Metni: "+hata.Message);
            }
        }
    }
}
