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
    public partial class frmTaksitlendirme : Form
    {
        public frmTaksitlendirme(long cariid, string cariAdi)
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["Form1"]);
            NesneGorselleri.dataGridView(dgTaksitGor);
            NesneGorselleri.kontrolEkle(groupBox3);
            NesneGorselleri.kontrolEkle(pnlCari);
            cmbCariler.Text = cariAdi;
            seciiliCariid = cariid;
        }

        private int grupid = 0;
        private long seciiliCariid = 0;
        public long ticaretAyrintiid = 0;
        public frmTicaret _frmTicaret = null;
        string aciklama = "";
        public frmTaksitlendirme(long cariid, string cariAdiSoyadi, string tutari, string islemTipi, DateTime islemTarihi, int grupid, long ticaretAyrintiid, string aciklama)
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["Form1"]);
            NesneGorselleri.dataGridView(dgTaksitGor);
            this.seciiliCariid = cariid;
            this.grupid = grupid;
            this.ticaretAyrintiid = ticaretAyrintiid;

            cmbCariler.Text = cariAdiSoyadi;
            cmbCariler.Enabled = false;

            if (islemTipi == "Alış") rdBorc.Checked = true;
            else if (islemTipi == "Satış") rdAlacak.Checked = true;

            dtTaksitBaslangicTarihi.Value = islemTarihi.AddMonths(1);

            rdAlacak.Enabled = false;
            rdBorc.Enabled = false;

            txtTaksitTutari.Text = tutari;
            txtTaksitTutari.Enabled = false;
            txtDovizDegeri.Enabled = false;
            txtDovizKuru.Enabled = false;
            txtDovizliTutar.Enabled = false;

            this.aciklama = aciklama;
        }

        void listeleriDoldur()
        {
            cmbCariler.Items.Clear();
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            p1.Visible = true;
            p1.Value = 0;
            p1.Maximum = dgTaksitGor.Rows.Count + 1;
            this.Refresh();
            if (cmbCariler.Text == "")
            {
                MessageBox.Show("Geçerli bir cari seçin", firma.programAdi);
                cmbCariler.Select();
                return;
            }
            try
            {
                try
                {
                    string odemeBilgisi = "Alacak";
                    if (rdBorc.Checked) odemeBilgisi = "Borç";
                    string eklenenTaksitid = veri.getdatacell("exec spSetTaksit2 0," + seciiliCariid + "," + ticaretAyrintiid + ",'" + txtTaksitTutari.Text.Replace(".", "").Replace(",", ".") + "','" + txtTaksitPesinat.Text.Replace(".", "").Replace(",", ".") + "','" + txtDovizKuru.Text + "','" + txtDovizDegeri.Text.Replace(".", "").Replace(",", ".") + "','" + txtTaksitSayisi.Text + "','" + odemeBilgisi + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + "");
                    SMSGonder();
                    p1.Value++;
                    this.Refresh();
                    for (int i = 0; i < dgTaksitGor.Rows.Count; i++)
                    {
                        int isaret = 1;
                        if (rdBorc.Checked) isaret = -1;
                        veri.cmd("exec spSetTaksit 0," + eklenenTaksitid + ", " + seciiliCariid + ", " + ticaretAyrintiid + ", '" + Convert.ToDateTime(dgTaksitGor.Rows[i].Cells["tarih"].Value).ToString("dd-MM-yyyy") + "', '" + (Convert.ToDouble(dgTaksitGor.Rows[i].Cells["tutar"].Value) * isaret).ToString().Replace(".", "").Replace(",", ".") + "', '" + txtDovizKuru.Text + "', '" + txtDovizDegeri.Text.Replace(".", "").Replace(",", ".") + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + " ");
                        p1.Value++;
                        this.Refresh();
                    }
                    p1.Visible = false;
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Kaydetme başarısız.İnternet hızınızı kontrol ederek tekrar deneyin.\n\n\n" + hata.Message, firma.programAdi);
                    //veri.cmd("delete from  tblAcikhesap where id='" + acikHesapid + "' and firmaNo='" + Form1.firmaid + "'");
                    return;
                }
                if (_frmTicaret != null)
                {
                    ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
                    _frmTicaret.yeniKayit();
                }
                this.Close();
            }
            catch { }
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
                    string mesaj = dtMesaj.Rows[0]["Mesaj"].ToString();
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

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciiliCariid = listeler.getCariid()[cmbCariler.SelectedIndex];
        }
        private void frmTaksitlendirme_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
            dtTaksitBaslangicTarihi.Value = dtTaksitBaslangicTarihi.Value.AddMonths(1);
        }
        void taksitHesapla()
        {
            try
            {
                dgTaksitGor.Rows.Clear();
                string TaksitTutari = ((Convert.ToDouble(txtKalanTutar.Text) / Convert.ToDouble((txtTaksitSayisi.Text))).ToString());
                DateTime _tarih = dtTaksitBaslangicTarihi.Value;
                for (int i = 0; i < Convert.ToByte(txtTaksitSayisi.Text); i++)
                {
                    dgTaksitGor.Rows.Add(_tarih.ToShortDateString(), (TaksitTutari));
                    if (rdAylikTaksit.Checked) _tarih = _tarih.AddMonths(1);
                    else _tarih = _tarih.AddDays(Convert.ToInt32(txtTaksitAraligi.Value));
                }
            }
            catch (Exception hata)
            {
            }
        }

        private void dgTaksitGor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double oncekiToplamlar = 0;
            byte taksitSayisi = 0;
            for (int i = 0; i <= dgTaksitGor.CurrentRow.Index; i++)
            {
                taksitSayisi++;
                oncekiToplamlar = oncekiToplamlar + Convert.ToDouble(dgTaksitGor.Rows[i].Cells["tutar"].Value);
            }

            double sonrakiToplam = Convert.ToDouble(txtKalanTutar.Text) - oncekiToplamlar;
            for (int i = dgTaksitGor.CurrentRow.Index + 1; i < dgTaksitGor.Rows.Count; i++)
            {
                dgTaksitGor.Rows[i].Cells["tutar"].Value = ((sonrakiToplam / ((Convert.ToInt32(txtTaksitSayisi.Text) - taksitSayisi))).ToString());
            }

        }

        void hesaplariYap()
        {
            try
            {
                txtDovizliTutar.Text = (Convert.ToDouble(txtTaksitTutari.Text) * Convert.ToDouble(txtDovizDegeri.Text)).ToString();
                txtKalanTutar.Text = (Convert.ToDouble(txtTaksitTutari.Text) - Convert.ToDouble(txtTaksitPesinat.Text)).ToString();
            }
            catch (Exception)
            {

            }

        }
        private void txtTaksitTutari_TextChanged(object sender, EventArgs e)
        {
            hesaplariYap();
        }

        private void txtDovizKuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                txtDovizDegeri.Text = "1";
                if (txtDovizKuru.SelectedIndex == 1) txtDovizDegeri.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
                else if (txtDovizKuru.SelectedIndex == 2) txtDovizDegeri.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
                lblPesinatDoviz.Text = txtDovizKuru.Text;
                lblKalanTutarDoviz.Text = txtDovizKuru.Text;
            }
            catch
            {
            }

        }

        private void txtTaksitSayisi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTaksitSayisi.Text == "") txtTaksitSayisi.Text = "1";
                if (Convert.ToDouble(txtTaksitSayisi.Text) > 99 || Convert.ToDouble(txtTaksitSayisi.Text) < 0)
                {
                    MessageBox.Show("Taksit sayısı [1-99] aralığında olabilir.");
                    txtTaksitSayisi.Undo();
                    txtTaksitSayisi.Select();
                    txtTaksitSayisi.SelectAll();
                    return;
                }
                taksitHesapla();
            }
            catch (Exception hata)
            {
                txtTaksitSayisi.Text = "1";
            }
        }

        private void rdAylikTaksit_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAylikTaksit.Checked) txtTaksitAraligi.Enabled = false;
            else
            {
                txtTaksitAraligi.Enabled = true;
                txtTaksitAraligi.Select();
            }
        }

    }
}
