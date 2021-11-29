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
    public partial class frmPDAFaturaDuzenle : Form
    {
        public frmPDAFaturaDuzenle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(grpAciklama);
            NesneGorselleri.kontrolEkle(grpCariBilgileri);
            NesneGorselleri.kontrolEkle(grpFirmaBilgilerim);
            NesneGorselleri.kontrolEkle(grpKagitBoyutlari);
            NesneGorselleri.kontrolEkle(grpTarih);
            NesneGorselleri.kontrolEkle(grpToplamlar);
            NesneGorselleri.kontrolEkle(grpUrunBilgileri);
            NesneGorselleri.kontrolEkle(grpUrunBilgileri2);
            NesneGorselleri.kontrolEkle(grpVD);
            NesneGorselleri.kontrolEkle(grpVN);
        }

        private void frmPDAFaturaDuzenle_Load(object sender, EventArgs e)
        {
            cmbKagitTipi.SelectedIndex = 0;
            bilgileriGetir();
        }

        void bilgileriGetir()
        {
            if (cmbKagitTipi.Text == "" || cmbKagitTipi.Items.Contains(cmbKagitTipi.Text) == false)
            {
                MessageBox.Show("Kağıt Tipini listeden seçin.", firma.programAdi);
                cmbKagitTipi.Select();
                return;
            }
            SqlDataReader dr = veri.getDatareader("SELECT [ayarid] ,[kullaniciid],[subeid],[firmaid],[kagitTipi],[kagitBoyutu_Genislik],[kagitBoyutu_Yukseklik],[firmaBilgileri],[firmaBilgileri_Genislik],[firmaBilgileri_Yukseklik],[firmaBilgileri_X],[firmaBilgileri_Y],[firmaBilgileri_YaziBuyuklugu],[firmaBilgileri_Baslik],[firmaBilgileri_Kalin],[cariBilgileri],[cariBilgileri_Genislik],[cariBilgileri_Yukseklik],[cariBilgileri_X],[cariBilgileri_Y],[cariBilgileri_YaziBuyuklugu],[cariBilgileri_Baslik],[cariBilgileri_Kalin],[VD],[VD_Genislik],[VD_Yukseklik],[VD_X],[VD_Y],[VD_YaziBuyuklugu],[VD_Baslik],[VD_Kalin],[VN],[VN_Genislik],[VN_Yukseklik],[VN_X],[VN_Y],[VN_YaziBuyuklugu],[VN_Baslik] ,[VN_Kalin] ,[tarih] ,[tarih_Genislik] ,[tarih_Yukseklik] ,[tarih_X] ,[tarih_Y] ,[tarih_YaziBuyuklugu] ,[tarih_Baslik] ,[tarih_Kalin] ,[urunBilgileri] ,[urunBilgileri_Genislik] ,[urunBilgileri_Yukseklik] ,[urunBilgileri_X] ,[urunBilgileri_Y] ,[urunBilgileri_YaziBuyuklugu] ,[urunBilgileri_Basliklar] ,[urunBilgileri_BaslikUstBoslugu] ,[urunBilgileri_UrunAdi_Genislik] ,[urunBilgileri_UrunAdi_X] ,[urunBilgileri_Adet_Genislik] ,[urunBilgileri_Adet_X] ,[urunBilgileri_Fiyat_Genislik] ,[urunBilgileri_Fiyat_X] ,[urunBilgileri_Tutar_Genislik] ,[urunBilgileri_Tutar_X] ,[toplamlar] ,[toplamlar_Genislik] ,[toplamlar_Yukseklik] ,[toplamlar_X] ,[toplamlar_Y] ,[toplamlar_YaziBuyuklugu] ,[toplamlar_Baslik] ,[toplamlar_Kalin] ,[aciklama] ,[aciklama_Metin] ,[aciklama_Genislik] ,[aciklama_Yukseklik] ,[aciklama_X] ,[aciklama_Y] ,[aciklama_YaziBuyuklugu] ,[aciklama_Kalin] FROM [ElmarTicariPlus].[dbo].[tblSicakSatisFaturaOlustur] where kullaniciid = " + firma.kullaniciid + " and kagitTipi = '" + cmbKagitTipi.Text + "'");
            while (dr.Read())
            {           
                txtKagitGenisligi.Text = dr["kagitBoyutu_Genislik"].ToString();
                txtKagitYuksekligi.Text = dr["kagitBoyutu_Yukseklik"].ToString();

                chkFirmaBilgilerim.Checked = Convert.ToBoolean(Convert.ToByte(dr["firmaBilgileri"]));
                txtFirmaBilgilerim_Genislik.Text = dr["firmaBilgileri_Genislik"].ToString();
                txtFirmaBilgilerim_Yukseklik.Text = dr["firmaBilgileri_Yukseklik"].ToString();
                txtFirmaBilgilerim_X.Text = dr["firmaBilgileri_X"].ToString();
                txtFirmaBilgilerim_Y.Text = dr["firmaBilgileri_Y"].ToString();
                txtFirmaBilgilerim_YaziBuyuklugu.Text = dr["firmaBilgileri_YaziBuyuklugu"].ToString();
                txtFirmaBilgilerim_Baslik.Text = dr["firmaBilgileri_Baslik"].ToString();
                chkFirmaBilgilerim_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["firmaBilgileri_Kalin"]));

                chkCariBilgileri.Checked = Convert.ToBoolean(Convert.ToByte(dr["cariBilgileri"]));
                txtCariBilgileri_Genislik.Text = dr["cariBilgileri_Genislik"].ToString();
                txtCariBilgileri_Yukseklik.Text = dr["cariBilgileri_Yukseklik"].ToString();
                txtCariBilgileri_X.Text = dr["cariBilgileri_X"].ToString();
                txtCariBilgileri_Y.Text = dr["cariBilgileri_Y"].ToString();
                txtCariBilgileri_YaziBuyuklugu.Text = dr["cariBilgileri_YaziBuyuklugu"].ToString();
                txtCariBilgileri_Baslik.Text = dr["cariBilgileri_Baslik"].ToString();
                chkCariBilgileri_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["cariBilgileri_Kalin"]));

                chkVD.Checked = Convert.ToBoolean(Convert.ToByte(dr["VD"]));
                txtVD_Genislik.Text = dr["VD_Genislik"].ToString();
                txtVD_Yukseklik.Text = dr["VD_Yukseklik"].ToString();
                txtVD_X.Text = dr["VD_X"].ToString();
                txtVD_Y.Text = dr["VD_Y"].ToString();
                txtVD_YaziBuyuklugu.Text = dr["VD_YaziBuyuklugu"].ToString();
                txtVD_Baslik.Text = dr["VD_Baslik"].ToString();
                chkVD_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["VD_Kalin"]));

                chkVN.Checked = Convert.ToBoolean(Convert.ToByte(dr["VN"]));
                txtVN_Genislik.Text = dr["VN_Genislik"].ToString();
                txtVN_Yukseklik.Text = dr["VN_Yukseklik"].ToString();
                txtVN_X.Text = dr["VN_X"].ToString();
                txtVN_Y.Text = dr["VN_Y"].ToString();
                txtVN_YaziBuyuklugu.Text = dr["VN_YaziBuyuklugu"].ToString();
                txtVN_Baslik.Text = dr["VN_Baslik"].ToString();
                chkVN.Checked = Convert.ToBoolean(Convert.ToByte(dr["VN_Kalin"]));

                chkTarih.Checked = Convert.ToBoolean(Convert.ToByte(dr["tarih"]));
                txtTarih_Genislik.Text = dr["tarih_Genislik"].ToString();
                txtTarih_Yukseklik.Text = dr["tarih_Yukseklik"].ToString();
                txtTarih_X.Text = dr["tarih_X"].ToString();
                txtTarih_Y.Text = dr["tarih_Y"].ToString();
                txtTarih_YaziBuyuklugu.Text = dr["tarih_YaziBuyuklugu"].ToString();
                txtTarih_Baslik.Text = dr["tarih_Baslik"].ToString();
                chkTarih_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["tarih_Kalin"]));

                chkUrunBilgileri.Checked = Convert.ToBoolean(Convert.ToByte(dr["urunBilgileri"]));
                txtUrunBilgileri_Genislik.Text = dr["urunBilgileri_Genislik"].ToString();
                txtUrunBilgileri_Yukseklik.Text = dr["urunBilgileri_Yukseklik"].ToString();
                txtUrunBilgileri_X.Text = dr["urunBilgileri_X"].ToString();
                txtUrunBilgileri_Y.Text = dr["urunBilgileri_Y"].ToString();
                txtUrunBilgileri_YaziBuyuklugu.Text = dr["urunBilgileri_YaziBuyuklugu"].ToString();
                chkUrunBilgileri_Basliklar.Checked = Convert.ToBoolean(Convert.ToByte(dr["urunBilgileri_Basliklar"]));
                txtUrunBilgileri_BaslikUstBoslugu.Text = dr["urunBilgileri_BaslikUstBoslugu"].ToString();

                txtUrunBilgileri_UrunAdi_Genislik.Text = dr["urunBilgileri_UrunAdi_Genislik"].ToString();
                txtUrunBilgileri_UrunAdi_X.Text = dr["urunBilgileri_UrunAdi_X"].ToString();
                txtUrunBilgileri_Adet_Genislik.Text = dr["urunBilgileri_Adet_Genislik"].ToString();
                txtUrunBilgileri_Adet_X.Text = dr["urunBilgileri_Adet_X"].ToString();
                txtUrunBilgileri_Fiyat_Genislik.Text = dr["urunBilgileri_Fiyat_Genislik"].ToString();
                txtUrunBilgileri_Fiyat_X.Text = dr["urunBilgileri_Fiyat_X"].ToString();
                txtUrunBilgileri_Tutar_Genislik.Text = dr["urunBilgileri_Tutar_Genislik"].ToString();
                txtUrunBilgileri_Tutar_X.Text = dr["urunBilgileri_Tutar_X"].ToString();

                chkToplamlar.Checked = Convert.ToBoolean(Convert.ToByte(dr["toplamlar"]));
                txtToplamlar_Genislik.Text = dr["toplamlar_Genislik"].ToString();
                txtToplamlar_Yukseklik.Text = dr["toplamlar_Yukseklik"].ToString();
                txtToplamlar_X.Text = dr["toplamlar_X"].ToString();
                txtToplamlar_Y.Text = dr["toplamlar_Y"].ToString();
                txtToplamlar_YaziBuyuklugu.Text = dr["toplamlar_YaziBuyuklugu"].ToString();
                txtToplamlar_Baslik.Text = dr["toplamlar_Baslik"].ToString();
                chkToplamlar_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["toplamlar_Kalin"]));

                chkAciklama.Checked = Convert.ToBoolean(Convert.ToByte(dr["aciklama"]));
                txtAciklama_Metin.Text = dr["aciklama_Metin"].ToString();
                txtAciklama_Genislik.Text = dr["aciklama_Genislik"].ToString();
                txtAciklama_Yukseklik.Text = dr["aciklama_Yukseklik"].ToString();
                txtAciklama_X.Text = dr["aciklama_X"].ToString();
                txtAciklama_Y.Text = dr["aciklama_Y"].ToString();
                txtAciklama_YaziBuyuklugu.Text = dr["aciklama_YaziBuyuklugu"].ToString();
                chkAciklama_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["aciklama_Kalin"]));
            }
        }


        private void btnDeğişiklikleriKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("Update [tblSicakSatisFaturaOlustur] Set [kagitBoyutu_Genislik]='" + txtKagitGenisligi.Text + "',[kagitBoyutu_Yukseklik]='" + txtKagitYuksekligi.Text + "',[firmaBilgileri]='" + Convert.ToByte(chkFirmaBilgilerim.Checked) + "',[firmaBilgileri_Genislik]='" + txtFirmaBilgilerim_Genislik.Text + "',[firmaBilgileri_Yukseklik]='" + txtFirmaBilgilerim_Yukseklik.Text + "',[firmaBilgileri_X]='" + txtFirmaBilgilerim_X.Text + "',[firmaBilgileri_Y]='" + txtFirmaBilgilerim_Y.Text + "',[firmaBilgileri_YaziBuyuklugu]='" + txtFirmaBilgilerim_YaziBuyuklugu.Text + "',[firmaBilgileri_Baslik]='" + txtFirmaBilgilerim_Baslik.Text + "',[firmaBilgileri_Kalin]='" + Convert.ToByte(chkFirmaBilgilerim_Kalin.Checked) + "',[cariBilgileri]='" + Convert.ToByte(chkCariBilgileri.Checked) + "',[cariBilgileri_Genislik]='" + txtCariBilgileri_Genislik.Text + "',[cariBilgileri_Yukseklik]='" + txtCariBilgileri_Yukseklik.Text + "',[cariBilgileri_X]='" + txtCariBilgileri_X.Text + "',[cariBilgileri_Y]='" + txtCariBilgileri_Y.Text + "',[cariBilgileri_YaziBuyuklugu]='" + txtCariBilgileri_YaziBuyuklugu.Text + "',[cariBilgileri_Baslik]='" + txtCariBilgileri_Baslik.Text + "',[cariBilgileri_Kalin]='" + Convert.ToByte(chkCariBilgileri_Kalin.Checked) + "',[VD]='" + Convert.ToByte(chkVD.Checked) + "',[VD_Genislik]='" + txtVD_Genislik.Text + "',[VD_Yukseklik]='" + txtVD_Yukseklik.Text + "',[VD_X]='" + txtVD_X.Text + "',[VD_Y]='" + txtVD_Y.Text + "',[VD_YaziBuyuklugu]='" + txtVD_YaziBuyuklugu.Text + "',[VD_Baslik]='" + txtVD_Baslik.Text + "',[VD_Kalin]='" + Convert.ToByte(chkVD_Kalin.Checked) + "',[VN]='" + Convert.ToByte(chkVN.Checked) + "',[VN_Genislik]='" + txtVN_Genislik.Text + "',[VN_Yukseklik]='" + txtVN_Yukseklik.Text + "',[VN_X]='" + txtVN_X.Text + "',[VN_Y]='" + txtVN_Y.Text + "',[VN_YaziBuyuklugu]='" + txtVN_YaziBuyuklugu.Text + "',[VN_Baslik]='" + txtVN_Baslik.Text + "' ,[VN_Kalin]='" + Convert.ToByte(chkVN_Kalin.Checked) + "' ,[tarih]='" + Convert.ToByte(chkTarih.Checked) + "' ,[tarih_Genislik]='" + txtTarih_Genislik.Text + "' ,[tarih_Yukseklik]='" + txtTarih_Yukseklik.Text + "' ,[tarih_X]='" + txtTarih_X.Text + "' ,[tarih_Y]='" + txtTarih_Y.Text + "' ,[tarih_YaziBuyuklugu]='" + txtTarih_YaziBuyuklugu.Text + "' ,[tarih_Baslik]='" + txtTarih_Baslik.Text + "' ,[tarih_Kalin]='" + Convert.ToByte(chkTarih_Kalin.Checked) + "' ,[urunBilgileri]='" + Convert.ToByte(chkUrunBilgileri.Checked) + "' ,[urunBilgileri_Genislik]='" + txtUrunBilgileri_Genislik.Text + "' ,[urunBilgileri_Yukseklik]='" + txtUrunBilgileri_Yukseklik.Text + "' ,[urunBilgileri_X]='" + txtUrunBilgileri_X.Text + "' ,[urunBilgileri_Y]='" + txtUrunBilgileri_Y.Text + "' ,[urunBilgileri_YaziBuyuklugu]='" + txtUrunBilgileri_YaziBuyuklugu.Text + "' ,[urunBilgileri_Basliklar]='" + Convert.ToByte(chkUrunBilgileri_Basliklar.Checked) + "' ,[urunBilgileri_BaslikUstBoslugu]='" + txtUrunBilgileri_BaslikUstBoslugu.Text + "' ,[urunBilgileri_UrunAdi_Genislik]='" + txtUrunBilgileri_UrunAdi_Genislik.Text + "' ,[urunBilgileri_UrunAdi_X]='" + txtUrunBilgileri_UrunAdi_X.Text + "' ,[urunBilgileri_Adet_Genislik]='" + txtUrunBilgileri_Adet_Genislik.Text + "' ,[urunBilgileri_Adet_X]='" + txtUrunBilgileri_Adet_X.Text + "' ,[urunBilgileri_Fiyat_Genislik]='" + txtUrunBilgileri_Fiyat_Genislik.Text + "' ,[urunBilgileri_Fiyat_X]='" + txtUrunBilgileri_Fiyat_X.Text + "' ,[urunBilgileri_Tutar_Genislik]='" + txtUrunBilgileri_Tutar_Genislik.Text + "' ,[urunBilgileri_Tutar_X]='" + txtUrunBilgileri_Tutar_X.Text + "' ,[toplamlar]='" + Convert.ToByte(chkToplamlar.Checked) + "' ,[toplamlar_Genislik]='" + txtToplamlar_Genislik.Text + "' ,[toplamlar_Yukseklik]='" + txtToplamlar_Yukseklik.Text + "' ,[toplamlar_X]='" + txtToplamlar_X.Text + "' ,[toplamlar_Y]='" + txtToplamlar_Y.Text + "' ,[toplamlar_YaziBuyuklugu]='" + txtToplamlar_YaziBuyuklugu.Text + "' ,[toplamlar_Baslik]='" + txtToplamlar_Baslik.Text + "' ,[toplamlar_Kalin]='" + Convert.ToByte(chkToplamlar_Kalin.Checked) + "' ,[aciklama]='" + Convert.ToByte(chkAciklama.Checked) + "' ,[aciklama_Metin]='" + txtAciklama_Metin.Text + "' ,[aciklama_Genislik]='" + txtAciklama_Genislik.Text + "' ,[aciklama_Yukseklik]='" + txtAciklama_Yukseklik.Text + "' ,[aciklama_X]='" + txtAciklama_X.Text + "' ,[aciklama_Y]='" + txtAciklama_Y.Text + "' ,[aciklama_YaziBuyuklugu]='" +txtAciklama_YaziBuyuklugu.Text+ "' ,[aciklama_Kalin]='" + Convert.ToByte(chkAciklama_Kalin.Checked) + "' where kullaniciid = " + firma.kullaniciid + " and [kagitTipi] = '" + cmbKagitTipi.Text + "'");
                MessageBox.Show("Değişiklikler Kaydedildi", firma.programAdi);
                
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydedilirken bir hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void cmbKagitTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            bilgileriGetir();
        }
    }
}
