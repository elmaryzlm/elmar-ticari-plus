using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmTaksitOde : Form
    {
        public frmTaksitOde(long cariid, string cariAdi)
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["Form1"]);
            NesneGorselleri.dataGridView(dgTaksitGor);
            NesneGorselleri.kontrolEkle(panel1);
            cmbCariler.Text = cariAdi;
            seciiliCariid = cariid;
        }

        void listeleriDoldur()
        {
            cmbCariler.Items.Clear();
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
        }
        private long seciiliCariid = 0;
        private void frmTaksitOde_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
            dgDoldur();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }
        private int BakiyeGetir()
        {
            try
            {

                int bakiye = Convert.ToInt32(veri.getdatacell("Select smsAdet from tblFirmaBilgileri Where firmaid = " + firma.firmaid + " and silindimi = '0'"));
                return bakiye;
            }
            catch
            {
                return 0;
            }
        }
        void SMSGonder()
        {
            if (SmsYetkileri.Faturalı_Satıs)
            {
                int smsAdet = BakiyeGetir();
                if (smsAdet == 0) { MessageBox.Show("SMS Bakiyeniz Olmadığı İçin SMS Gönderilmedi Lütfen ELMAR YAZILIM İle İletişime Geçiniz!"); return; }
                else
                {
                    var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == seciiliCariid);
                    string telefon = "";
                    foreach (var adresKaydi in adresListesi)
                    {
                        telefon = adresKaydi.gsm;
                    }
                    if (telefon.Equals("")) { MessageBox.Show("Cariye Ait Telefon Numarası Bulunamadı!"); return; }
                    string baslik = "ELMAR YZLM";
                    telefon = "0" + telefon;
                    DataTable dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%satış%' and FirmaID=" + firma.firmaid);
                    string mesaj = dtMesaj.Rows[0]["Mesaj"].ToString() + " " + (Convert.ToDouble(txtDovizliTutar.Text) * isaret).ToString().Replace(".", "").Replace(",", ".") + " TL";
                    //string value = SMSPaketi.SendSms(baslik,mesaj,telefon);
                    string value = Utility.SendSMS(telefon, mesaj);
                    if (value != "20" && value != "30" && value != "40" && value != "70")
                    {
                        veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-1 where firmaid=" + firma.firmaid);
                        MessageBox.Show("SMS Gönderildi.");
                        veri.cmd("insert into tblMesajlar (mesajMetni,Baslik,cariid,firmaid,subeid,kullaniciid)values('" + mesaj + "','" + baslik + "'," + seciiliCariid + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                        Close();
                    }
                    else MessageBox.Show("Gönderilemedi!");
                }
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbCariler.Text == "")
            {
                MessageBox.Show("Geçerli bir cari seçin", firma.programAdi);
                cmbCariler.Select();
                return;
            }
            try
            {
                veri.cmd("exec [spTaksitHesapla] " + seciiliCariid + ", '" + dtİslemTarihi.Value + "', " + (Convert.ToDouble(txtDovizliTutar.Text) * isaret).ToString().Replace(".", "").Replace(",", ".") + ",'" + txtAcklama.Text + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");
                MessageBox.Show("Taksit ödeme işlemi başarıyla gerçekleştirildi.", firma.programAdi);
                SMSGonder();
                this.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Taksit ödeme işleminde bir hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciiliCariid = listeler.getCariid()[cmbCariler.SelectedIndex];
            dgDoldur();
        }

        void dgDoldur()
        {
            dgTaksitGor.DataSource = veri.getdatatable("select taksitid, odemeTarihi as 'Ödeme T.', vadeTarihi as 'Vâde T.',  tutari as 'Tutar', odeme as 'Ödeme', bakiye as 'Kalan', dovizTuru as 'Doviz', odemeBilgisi as 'Ö.Bilgi' from sorTaksit where odemeBilgisi !='Taksite Bölündü' and cariid = " + seciiliCariid + " and firmaid = " + firma.firmaid + " and silindimi = '0' order by taksitid desc");
            dgTaksitGor.Columns["taksitid"].Visible = false;
        }
        private void txtDovizKuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDovizDegeri.Text = "1";
                if (txtDovizKuru.SelectedIndex == 1) txtDovizDegeri.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
                else if (txtDovizKuru.SelectedIndex == 2) txtDovizDegeri.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
            }
            catch
            {
            }
        }
        int isaret = 1;
        private void cmbislemTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbislemTipi.Text == "Ödeme") isaret = -1;
        }

        private void txtDovizliTutar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDovizDegeri_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDovizliTutar.Text = (Convert.ToDouble(txtTutar.Text) * Convert.ToDouble(txtDovizDegeri.Text)).ToString();
            }
            catch (Exception)
            {

            }
        }
        rapor rpr;
        bool raporOlustur()
        {
            rpr = new rapor();
            rpr.setKagitboyutu(rpr._kagitGenisligi, (int)(rpr._kagitYuksekligi / 2));
            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 10;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Taksit Bilgileri", new Font("Arial", 13, FontStyle.Bold), new Point(10, y)));
            y += 8;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 2;
            rpr.ekleYazi(new rapor.yazi("Cari Adı: " + cmbCariler.Text, new Rectangle(10, y, rpr._kagitGenisligi - 20, 4), false));
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            //y += 2;
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Tutar: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(txtTutar.Text, new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, true)); y += 5;            
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Döviz: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(txtDovizKuru.Text, new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 5;
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Döviz Kuru: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(txtDovizDegeri.Text, new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, true)); y += 5;
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Dövizli Tutar(TL): ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(txtDovizliTutar.Text, new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, true)); y += 5;
            //rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Tipi: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(cmbislemTipi.Text, new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 5;
            //rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Tarihi: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(dtİslemTarihi.Value.ToShortDateString(), new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 5;
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Açıklama: ", new Font("Arial", 9, FontStyle.Regular), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(txtAcklama.Text, new Rectangle(40, y, 150, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 7;
            //rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 3;
            //
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ödeme T.", new Font("Arial", 9, FontStyle.Bold), new Point(10, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Vâde T.", new Font("Arial", 9, FontStyle.Bold), new Point(40, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Tutar", new Font("Arial", 9, FontStyle.Bold), new Point(70, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ödeme", new Font("Arial", 9, FontStyle.Bold), new Point(100, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kalan", new Font("Arial", 9, FontStyle.Bold), new Point(130, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ö.Bilgi", new Font("Arial", 9, FontStyle.Bold), new Point(160, y)));
            y += 4;
            for (int i = 0; i < dgTaksitGor.Rows.Count; i++)
            {
                if (dgTaksitGor.Rows[i].Cells[1].Value != DBNull.Value) rpr.ekleYazi(new rapor.yazi(String.Format("{0:d}", Convert.ToDateTime(dgTaksitGor.Rows[i].Cells[1].Value)), new Rectangle(10, y, 30, 3), false));
                if (dgTaksitGor.Rows[i].Cells[2].Value != DBNull.Value) rpr.ekleYazi(new rapor.yazi(String.Format("{0:d}", Convert.ToDateTime(dgTaksitGor.Rows[i].Cells[2].Value)), new Rectangle(40, y, 30, 3), false));
                rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", Convert.ToDouble(dgTaksitGor.Rows[i].Cells[3].Value)) + " " + dgTaksitGor.Rows[i].Cells[6].Value.ToString(), new Rectangle(70, y, 30, 3), false));
                rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", Convert.ToDouble(dgTaksitGor.Rows[i].Cells[4].Value)) + " " + dgTaksitGor.Rows[i].Cells[6].Value.ToString(), new Rectangle(100, y, 30, 3), false));
                rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", Convert.ToDouble(dgTaksitGor.Rows[i].Cells[5].Value)) + " " + dgTaksitGor.Rows[i].Cells[6].Value.ToString(), new Rectangle(130, y, 30, 3), false));
                rpr.ekleYazi(new rapor.yazi(dgTaksitGor.Rows[i].Cells[7].Value.ToString(), new Rectangle(160, y, 40, 3), false));
                y += 4;
            }
            //
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Eski Bakiye: ", new Font("Arial", 9, FontStyle.Bold), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(txtEskiBakiye.Text + "TL ", new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 6;
            //rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Tutarı: ", new Font("Arial", 9, FontStyle.Bold), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(txtİslemTutarı.Text + " TL ", new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 6;
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Yeni Bakiye: ", new Font("Arial", 9, FontStyle.Bold), new Point(10, y)));
            //rpr.ekleYazi(new rapor.yazi(txtYeniBakiye.Text + " TL ", new Rectangle(40, y, 30, 3), StringFormatFlags.DirectionRightToLeft, false)); y += 8;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 2;
            rpr.ekleYazi(new rapor.yazi(firmaBilgileri.adi + " " + firmaBilgileri.soyadi + "  " + firmaBilgileri.webSitesi + "  " + subeBilgileri.tel + "  " + subeBilgileri.adres + "  " + subeBilgileri.altBilgiNotu, new Rectangle(10, y, rpr._kagitGenisligi - 20, 7), false));
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, y, y));
            y += 2;
            rpr.ekleYazi(new rapor.yazi(DateTime.Now.ToString() + "  www.elmaryazilim.com", new Point(10, y)));
            return true;
        }

        private void btnCiktiOnizleme_Click(object sender, EventArgs e)
        {
            raporOlustur();
            rpr.onizleme();
        }
    }
}
