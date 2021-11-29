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
using BarcodeLib;
using System.IO;
using System.Net;

namespace Elmar_Ticari_Plus
{
    public partial class frmStokkartBarkodYazdir : Form
    {
        public frmStokkartBarkodYazdir()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgUrunler);
            NesneGorselleri.kontrolEkle(grpBarkod);
            NesneGorselleri.kontrolEkle(grpBarkodYazisi);
            NesneGorselleri.kontrolEkle(grpBaskiAdedi);
            NesneGorselleri.kontrolEkle(grpEkBilgi);
            NesneGorselleri.kontrolEkle(grpKagitBoyutlari);
            NesneGorselleri.kontrolEkle(grpSatisFiyati);
            NesneGorselleri.kontrolEkle(grpUrunAdi);
        }

        private void frmStokkartBarkodYazdir_Load(object sender, EventArgs e)
        {
            bilgileriGetir();
            satisFiyatiListele();
            urunListele("");
            if (txtEkBilgi_Metin.Text == "")
            {
                txtEkBilgi_Metin.Text = firmaBilgileri.adi + " " + firmaBilgileri.soyadi;
            }
            for (int i = 0; i < dgUrunler.Rows.Count; i++)
            {
                dgUrunler.Rows[i].Cells["yazdirma"].Value = false;
            }
        }

        void bilgileriGetir()
        {
            string sql = "SELECT [kagitBoyutu_Genislik] ,[kagitBoyutu_Yukseklik] ,[baskiAdedi] ,[barkod] ,[barkod_Genislik] ,[barkod_Yukseklik] ,[barkod_X] ,[barkod_Y] ,[barkodYazisi] ,[barkodYazisi_Genislik] ,[barkodYazisi_Yukseklik] ,[barkodYazisi_X] ,[barkodYazisi_Y] ,[barkodYazisi_YaziBuyuklugu] ,[urunAdi] ,[urunAdi_Genislik] ,[urunAdi_Yukseklik] ,[urunAdi_X] ,[urunAdi_Y] ,[urunAdi_YaziBuyuklugu] ,[urunAdi_Baslik] ,[urunAdi_Kalin] ,[satisFiyat] ,[satisFiyat_Genislik] ,[satisFiyat_Yukseklik] ,[satisFiyat_X] ,[satisFiyat_Y] ,[satisFiyat_YaziBuyuklugu] ,[satisFiyat_Baslik] ,[satisFiyat_Kalin] ,[ekBilgi] ,[ekBilgi_Metin] ,[ekBilgi_Genislik] ,[ekBilgi_Yukseklik] ,[ekBilgi_X],[ekBilgi_Y] ,[ekBilgi_YaziBuyuklugu] ,[ekBilgi_Kalin] FROM [dbo].[tblEtiketKoordinatlari] where kullaniciid = " + firma.kullaniciid + "";
            SqlDataReader dr = veri.getDatareader(sql);
            while (dr.Read())
            {
                txtKagitGenisligi.Text = dr["kagitBoyutu_Genislik"].ToString();
                txtKagitYuksekligi.Text = dr["kagitBoyutu_Yukseklik"].ToString();
                txtBaskiAdedi.Text = dr["baskiAdedi"].ToString();
                chkBarkod.Checked = Convert.ToBoolean(Convert.ToByte(dr["barkod"]));
                txtBarkod_Genislik.Text = dr["barkod_Genislik"].ToString();
                txtBarkod_Yukseklik.Text = dr["barkod_Yukseklik"].ToString();
                txtBarkod_X.Text = dr["barkod_X"].ToString();
                txtBarkod_Y.Text = dr["barkod_Y"].ToString();
                chkBarkodYazisi.Checked = Convert.ToBoolean(Convert.ToByte(dr["barkodYazisi"]));
                txtBarkodYazisi_Genislik.Text = dr["barkodYazisi_Genislik"].ToString();
                txtBarkodYazisi_Yukseklik.Text = dr["barkodYazisi_Yukseklik"].ToString();
                txtBarkodYazisi_X.Text = dr["barkodYazisi_X"].ToString();
                txtBarkodYazisi_Y.Text = dr["barkodYazisi_Y"].ToString();
                txtBarkodYazisi_YaziBuyuklugu.Text = dr["barkodYazisi_YaziBuyuklugu"].ToString();
                chkUrunAdi.Checked = Convert.ToBoolean(Convert.ToByte(dr["urunAdi"]));
                txtUrunAdi_Genislik.Text = dr["urunAdi_Genislik"].ToString();
                txtUrunAdi_Yukseklik.Text = dr["urunAdi_Yukseklik"].ToString();
                txtUrunAdi_X.Text = dr["urunAdi_X"].ToString();
                txtUrunAdi_Y.Text = dr["urunAdi_Y"].ToString();
                txtUrunAdi_YaziBuyuklugu.Text = dr["urunAdi_YaziBuyuklugu"].ToString();
                txtUrunAdi_Baslik.Text = dr["urunAdi_Baslik"].ToString();
                chkUrunAdi_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["urunAdi_Kalin"]));
                chkSatisFiyat.Checked = Convert.ToBoolean(Convert.ToByte(dr["satisFiyat"]));
                txtSatisFiyat_Genislik.Text = dr["satisFiyat_Genislik"].ToString();
                txtSatisFiyat_Yukseklik.Text = dr["satisFiyat_Yukseklik"].ToString();
                txtSatisFiyat_X.Text = dr["satisFiyat_X"].ToString();
                txtSatisFiyat_Y.Text = dr["satisFiyat_Y"].ToString();
                txtSatisFiyat_YaziBuyuklugu.Text = dr["satisFiyat_YaziBuyuklugu"].ToString();
                txtSatisFiyat_Baslik.Text = dr["satisFiyat_Baslik"].ToString();
                chkSatisFiyat_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["satisFiyat_Kalin"]));
                chkEkBilgiNot.Checked = Convert.ToBoolean(Convert.ToByte(dr["ekBilgi"]));
                txtEkBilgi_Metin.Text = dr["ekBilgi_Metin"].ToString();
                txtEkBilgi_Genislik.Text = dr["ekBilgi_Genislik"].ToString();
                txtEkBilgi_Yukseklik.Text = dr["ekBilgi_Yukseklik"].ToString();
                txtEkBilgi_X.Text = dr["ekBilgi_X"].ToString();
                txtEkBilgi_Y.Text = dr["ekBilgi_Y"].ToString();
                txtEkBilgi_YaziBuyuklugu.Text = dr["ekBilgi_YaziBuyuklugu"].ToString();
                chkEkNot_Kalin.Checked = Convert.ToBoolean(Convert.ToByte(dr["ekBilgi_Kalin"]));
            }
        }

        DataTable dt;
        void urunListele(string sorgu)
        {
            dgUrunler.Rows.Clear();
            string sql = "select s.stokid, b.barkod, s.urunAdi, isnull(f.fiyatTutari,0) fiyatTutari, isnull(f.indirim,0) indirim, isnull(f.indirimTipi,'') indirimTipi, isnull(f.indirimliFiyat,0)indirimliFiyat  from tblStokkart s  left join sorStokkartFiyatlari f on s.stokid = f.stokid left join tblStokkartBirimleri b on s.stokid = b.stokid Where s.silindimi = 0 and s.firmaid = '" + firma.firmaid + "'" + sorgu + " order by s.stokid desc";
            SqlDataReader dr = veri.getDatareader(sql);

            while (dr.Read())
            {
                dgUrunler.Rows.Add(dr["stokid"].ToString(), true, dr["barkod"].ToString(), dr["urunAdi"].ToString(), Convert.ToDouble(dr["fiyatTutari"]), Convert.ToDouble(dr["indirim"]), dr["indirimTipi"].ToString(), Convert.ToDouble(dr["indirimliFiyat"]));
            }
        }

        rapor rpr;
        private void btnBarkodYazdir_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgUrunler.Rows)
            {
                if (Convert.ToBoolean(r.Cells["yazdirma"].Value))
                {
                    raporHazirla(r);
                    for (int i = 0; i < Convert.ToInt32(txtBaskiAdedi.Text); i++)
                    {
                        rpr.yazdir();
                    }
                }
            }
        }

        int s(string cevrilecekMetin)
        {
            return (Convert.ToInt32(cevrilecekMetin));
        }

        int s2(string cevrilecekMetin)
        {
            //pixel to mm işlemi yapar.
            return rpr.olcuHesapla(Convert.ToDouble(cevrilecekMetin));
        }

        void raporHazirla(DataGridViewRow r)
        {
            rpr = new rapor(Convert.ToInt32(txtKagitGenisligi.Text), Convert.ToInt32(txtKagitYuksekligi.Text));
            rpr.yaziYazdirmaSiniri = Convert.ToInt32(txtKagitYuksekligi.Text) - 2;
            if (checkBox1.Checked)
                rpr.sayfayiYatayYap();
            //Barkod Oluşturuluyor
            if (chkBarkod.Checked)
            {
                try
                {
                    Barcode b = new Barcode();
                    b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
                    Image img = b.Encode(BarcodeLib.TYPE.EAN13, r.Cells["barkod"].Value.ToString(), s2(txtBarkod_Genislik.Text), s2(txtBarkod_Yukseklik.Text));
                    //pictureBox1.Image = img;
                    rpr.ekleSabitResim(new rapor.sabitResim(img, new Rectangle(s(txtBarkod_X.Text), s(txtBarkod_Y.Text), s(txtBarkod_Genislik.Text), s(txtBarkod_Yukseklik.Text))));
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Barkod Formatı Hatalı. Hata Kodu: " + hata.Message, firma.programAdi);
                }
            }
            //Barkod Yazısı Oluşturuluyor
            if (chkBarkodYazisi.Checked)
            {
                rpr.ekleSabitYazi(new rapor.sabitYazi(r.Cells["barkod"].Value.ToString(), new Font("Arial", Convert.ToInt32(txtBarkodYazisi_YaziBuyuklugu.Text), FontStyle.Regular), new Rectangle(s(txtBarkodYazisi_X.Text), s(txtBarkodYazisi_Y.Text), s(txtBarkodYazisi_Genislik.Text), s(txtBarkodYazisi_Yukseklik.Text)), false));
            }
            //tarih yazdır
            if (chbTarih.Checked)
            {
                FontStyle fs1 = FontStyle.Regular;
                fs1 = FontStyle.Bold;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih:" + DateTime.Now.ToShortDateString(),
                    new Font("Arial", Convert.ToInt32(10), fs1),
                    new Rectangle(s("1"), s("21"), s("30"), s("2")), false));
            }
            //yerli üretim 
            var barkod = r.Cells["barkod"].Value.ToString();
            if (!string.IsNullOrEmpty(barkod) && (barkod.StartsWith("869") || barkod.StartsWith("868")))
            {
                if (IsThereReport("yerli"))
                {
                    var image = Image.FromFile(Application.StartupPath + "\\resimler\\yerli.png");
                    rpr.ekleSabitResim(new rapor.sabitResim(image, new Rectangle(3, 27, 24, 9)));
                }

            }
            //Ürün Adı Yazısı Oluşturuluyor
            if (chkUrunAdi.Checked)
            {
                FontStyle fs = FontStyle.Regular;
                if (chkUrunAdi_Kalin.Checked) fs = FontStyle.Bold;
                rpr.ekleSabitYazi(new rapor.sabitYazi(txtUrunAdi_Baslik.Text + r.Cells["urunAdi"].Value.ToString(), new Font("Arial", Convert.ToInt32(txtUrunAdi_YaziBuyuklugu.Text), fs), new Rectangle(s(txtUrunAdi_X.Text), s(txtUrunAdi_Y.Text), s(txtUrunAdi_Genislik.Text), s(txtUrunAdi_Yukseklik.Text)), false));
            }

            //Ek Yazı Oluşturuluyor
            if (chkEkBilgiNot.Checked)
            {
                FontStyle fs = FontStyle.Regular;
                if (chkEkNot_Kalin.Checked) fs = FontStyle.Bold;
                rpr.ekleSabitYazi(new rapor.sabitYazi(txtEkBilgi_Metin.Text, new Font("Arial", Convert.ToInt32(txtEkBilgi_YaziBuyuklugu.Text), fs), new Rectangle(s(txtEkBilgi_X.Text), s(txtEkBilgi_Y.Text), s(txtEkBilgi_Genislik.Text), s(txtEkBilgi_Yukseklik.Text)), false));
            }

            //Satış Fiyat Oluşturuluyor
            if (chkSatisFiyat.Checked)
            {
                FontStyle fs = FontStyle.Regular;
                if (chkSatisFiyat_Kalin.Checked) fs = FontStyle.Bold;
                rpr.ekleSabitYazi(new rapor.sabitYazi(txtSatisFiyat_Baslik.Text + string.Format("{0:n2}", Convert.ToDouble(r.Cells["indirimliFiyat"].Value)) + " TL", new Font("Arial", Convert.ToInt32(txtSatisFiyat_YaziBuyuklugu.Text), fs), new Rectangle(s(txtSatisFiyat_X.Text), s(txtSatisFiyat_Y.Text), s(txtSatisFiyat_Genislik.Text), s(txtSatisFiyat_Yukseklik.Text)), false));
            }
            if (!txtIkincifiyatTutar.Text.Equals(""))
            {
                string y = (Convert.ToInt32(txtSatisFiyat_Y.Text) + 5).ToString();
                FontStyle fs = FontStyle.Regular;
                if (chkSatisFiyat_Kalin.Checked) fs = FontStyle.Bold;
                rpr.ekleSabitYazi(new rapor.sabitYazi(txtIkinciFiyatBaslik.Text + string.Format("{0:n2}", Convert.ToDouble(txtIkincifiyatTutar.Text)) + " TL", new Font("Arial", Convert.ToInt32(txtSatisFiyat_YaziBuyuklugu.Text), fs), new Rectangle(s(txtSatisFiyat_X.Text), s(y), s(txtSatisFiyat_Genislik.Text), s(txtSatisFiyat_Yukseklik.Text)), false));
            }
        }

        public bool IsThereReport(string reportName)
        {
            string path = Application.StartupPath + "\\resimler\\" + reportName + ".png";
            if (!File.Exists(path))
            {
                DialogResult result = MessageBox.Show("Yerli Üretim Logosu Bulunamadı. İndirilmesini Bekleyin.");
                return DownloadReport(reportName);
            }
            return true;
        }

        public bool DownloadReport(string reportName)
        {
            string downloadPath = Application.StartupPath + "\\resimler\\";
            string address = "http://elazigyoreselmarket.com/yerli.png";
            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }
            int downloadBytes = DownloadFile(address, downloadPath + reportName + ".png");
            return false;
        }

        private static int DownloadFile(string url, string localFile)
        {
            // Function will return the number of bytes processed
            // to the caller. Initialize to 0 here.
            int bytesProcessed = 0;

            // Assign values to these objects here so that they can
            // be referenced in the finally block
            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;

            // Use a try/catch/finally block as both the WebRequest and Stream
            // classes throw exceptions upon error
            try
            {
                // Create a request for the specified remote file name
                WebRequest request = WebRequest.Create(url);
                if (request != null)
                {
                    // Send the request to the server and retrieve the
                    // WebResponse object 
                    response = request.GetResponse();
                    if (response != null)
                    {
                        // Once the WebResponse object has been retrieved,
                        // get the stream object associated with the response's data
                        remoteStream = response.GetResponseStream();

                        // Create the local file
                        localStream = File.Create(localFile);

                        // Allocate a 1k buffer
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        // Simple do/while loop to read from stream until
                        // no bytes are returned
                        do
                        {
                            // Read data (up to 1k) from the stream
                            bytesRead = remoteStream.Read(buffer, 0, buffer.Length);

                            // Write the data to the local file
                            localStream.Write(buffer, 0, bytesRead);

                            // Increment total bytes processed
                            bytesProcessed += bytesRead;
                        } while (bytesRead > 0);
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                // Close the response and streams objects here 
                // to make sure they're closed even if an exception
                // is thrown at some point
                if (response != null) response.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }

            // Return total bytes processed to caller.
            return bytesProcessed;
        }

        private void btnBaskiOnizle_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgUrunler.Rows)
            {
                if (Convert.ToBoolean(r.Cells["yazdirma"].Value))
                {
                    raporHazirla(r);
                }
            }
            rpr.onizleme();
        }

        private void btnİsaretle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgUrunler.Rows.Count; i++)
            {
                dgUrunler.Rows[i].Cells["yazdirma"].Value = true;
            }
        }

        private void btnisaretleriKaldir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgUrunler.Rows.Count; i++)
            {
                dgUrunler.Rows[i].Cells["yazdirma"].Value = false;
            }
        }

        private void grpUrunAdi_Enter(object sender, EventArgs e)
        {

        }

        private void btnTumunuListele_Click(object sender, EventArgs e)
        {
            urunListele("");
        }

        private void btnFiyatTipineGoreListele_Click(object sender, EventArgs e)
        {
            if (cmbFiyatTipi.SelectedIndex == -1)
            {
                MessageBox.Show("Listeden fiyat seçin", firma.programAdi);
                return;
            }

            urunListele(" and f.fiyatid = " + listFiyatTipi[cmbFiyatTipi.SelectedIndex] + "");

        }

        List<string> listFiyatTipi = new List<string>();

        void satisFiyatiListele()
        {
            cmbFiyatTipi.Items.Clear();
            listFiyatTipi.Clear();
            SqlDataReader dr = veri.getDatareader("Select fiyatid, fiyatAdi From tblFiyatTaslak Where firmaid = " + firma.firmaid + " and silindimi = '0' order by fiyatAdi asc");
            while (dr.Read())
            {
                listFiyatTipi.Add(dr["fiyatid"].ToString());
                cmbFiyatTipi.Items.Add(dr["fiyatAdi"].ToString());
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("Update tblEtiketKoordinatlari set  [kagitBoyutu_Genislik]='" + txtKagitGenisligi.Text + "' ,[kagitBoyutu_Yukseklik]='" + txtKagitYuksekligi.Text + "' ,[baskiAdedi]='" + txtBaskiAdedi.Text + "' ,[barkod]='" + Convert.ToByte(chkBarkod.Checked) + "' ,[barkod_Genislik]='" + txtBarkod_Genislik.Text + "' ,[barkod_Yukseklik]='" + txtBarkod_Yukseklik.Text + "' ,[barkod_X]='" + txtBarkod_X.Text + "' ,[barkod_Y]='" + txtBarkod_Y.Text + "' ,[barkodYazisi]='" + Convert.ToByte(chkBarkodYazisi.Checked) + "' ,[barkodYazisi_Genislik]='" + txtBarkodYazisi_Genislik.Text + "' ,[barkodYazisi_Yukseklik]='" + txtBarkodYazisi_Yukseklik.Text + "' ,[barkodYazisi_X]='" + txtBarkodYazisi_X.Text + "' ,[barkodYazisi_Y]='" + txtBarkodYazisi_Y.Text + "' ,[barkodYazisi_YaziBuyuklugu]='" + txtBarkodYazisi_YaziBuyuklugu.Text + "' ,[urunAdi]='" + Convert.ToByte(chkUrunAdi.Checked) + "' ,[urunAdi_Genislik]='" + txtUrunAdi_Genislik.Text + "' ,[urunAdi_Yukseklik]='" + txtUrunAdi_Yukseklik.Text + "' ,[urunAdi_X]='" + txtUrunAdi_X.Text + "' ,[urunAdi_Y]='" + txtUrunAdi_Y.Text + "' ,[urunAdi_YaziBuyuklugu]='" + txtUrunAdi_YaziBuyuklugu.Text + "' ,[urunAdi_Baslik]='" + txtUrunAdi_Baslik.Text + "' ,[urunAdi_Kalin]='" + Convert.ToByte(chkUrunAdi_Kalin.Checked) + "' ,[satisFiyat]='" + Convert.ToByte(chkSatisFiyat.Checked) + "' ,[satisFiyat_Genislik]='" + txtSatisFiyat_Genislik.Text + "' ,[satisFiyat_Yukseklik]='" + txtSatisFiyat_Yukseklik.Text + "' ,[satisFiyat_X]='" + txtSatisFiyat_X.Text + "' ,[satisFiyat_Y]='" + txtSatisFiyat_Y.Text + "' ,[satisFiyat_YaziBuyuklugu]='" + txtSatisFiyat_YaziBuyuklugu.Text + "' ,[satisFiyat_Baslik]='" + txtSatisFiyat_Baslik.Text + "' ,[satisFiyat_Kalin]='" + Convert.ToByte(chkSatisFiyat_Kalin.Checked) + "' ,[ekBilgi]='" + Convert.ToByte(chkEkBilgiNot.Checked) + "' ,[ekBilgi_Metin]='" + txtEkBilgi_Metin.Text + "' ,[ekBilgi_Genislik]='" + txtEkBilgi_Genislik.Text + "' ,[ekBilgi_Yukseklik]='" + txtEkBilgi_Yukseklik.Text + "' ,[ekBilgi_X]='" + txtEkBilgi_X.Text + "',[ekBilgi_Y]='" + txtEkBilgi_Y.Text + "' ,[ekBilgi_YaziBuyuklugu]='" + txtEkBilgi_YaziBuyuklugu.Text + "' ,[ekBilgi_Kalin]='" + Convert.ToByte(chkEkBilgiNot.Checked) + "' where kullaniciid = " + firma.kullaniciid + "");
                MessageBox.Show("Değişiklikler Kaydedildi", firma.programAdi);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydedilirken bir hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                urunListele(" and b.barkod = '" + txtBarkod.Text + "'");
            }
        }

        private void txtUrunAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                urunListele(" and s.urunAdi like '%" + txtUrunAdi.Text + "%'");
            }
        }

    }
}