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
    public partial class frmStokKartEkle : Form
    {
        public frmStokKartEkle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(panel1);
            baslangic();
        }
        public frmStokKartEkle(Int64 stokid)
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(panel1);
            baslangic();
            this.stokid = stokid;
            duzenlemeModu();
        }
        string _stokkodu = "", _marka = "", _markaid = "0", _rafAdi = "", _garanti = "24", _urunkodu = "", _ayrinti = "", _urunSirasi = "999", _detayliBilgi = "", _gAnahtarKelime = "", _gAciklama = "", _asgariSiparisMiktari = "1", _urunPuani = "1", _gosterimAnaSayfa = "0", _gosterimSagSol = "0", _gosterimVitrin = "0", _kargoDesi = "1", _kargoBedavami = "0", _dovizi = "TL", _indirimTipi = "TL", _indirim = "0";

        private void btnBarkodUret_Click(object sender, EventArgs e)
        {
            RandomBarcode barcode = new RandomBarcode();
            //bu kod barkodun ilk 2 hanesi -ülke kodu
            barcode.CountryCode = "869";
            Random rastgele = new Random();
            int sayi = rastgele.Next(10, 50);
            int sayi2 = rastgele.Next(50, 100);
            int sayi3 = rastgele.Next(1000, 9999);
            barcode.ManufacturerCode = sayi.ToString() + sayi2.ToString();
            barcode.ProductCode = "0" + sayi3;
            barcode.CalculateChecksumDigit();
            txtBarkod.Text = barcode.CountryCode + barcode.ManufacturerCode + barcode.ProductCode + barcode.ChecksumDigit;
        }

        void duzenlemeModu()
        {
            lblBaslik.Text = "Stok Kartını Düzenle";
            this.Text = "Stok Kartı Düzenle";
            var l = stokkart.bul_stokid(stokid);
            txtUrunismi.Text = l.urunAdi;
            duzenlemeUrunismi = l.urunAdi;
            cmbKategori.Text = l.kategoriAdi;
            cmbKategori.Tag = l.katNo;
            txtAlisFiyat.Text = l.alisFiyat.ToString();
            cmbKdv.Text = l.kdv.ToString();
            cmbKdvTipi.Text = l.kdvTipi.ToString();
            _stokkodu = l.stokkodu;
            _marka = l.markaAdi;
            _markaid = l.markaid.ToString();
            _rafAdi = l.rafAdi;
            _garanti = l.garantiSuresi;
            _urunkodu = l.urunKodu;
            _ayrinti = l.ayrinti;
            chbMobil.Checked = Convert.ToBoolean(l.mobil);
            chbVitrin.Checked = Convert.ToBoolean(l.vitrin);
            if (l.webdeGosterilsinmi == "1") chkWebdeGosterilsinmi.Checked = true;
            else if (l.webdeGosterilsinmi == "0") chkWebdeGosterilsinmi.Checked = false;

            try
            {
                var v = stokkart.fiyatlar.listFiyatlar.Where(u => u.stokid == stokid).First();
                txtSatisFiyat.Text = v.fiyatTutari.ToString();
                _dovizi = v.dovizi;
                _indirimTipi = v.indirimTipi;
                _indirim = v.indirim.ToString();
            }
            catch { }

            try
            {
                var birimDegiskeni = stokkart.birimler.listBirimler.Where(u => u.stokid == stokid).First();
                cmbBirim.Text = birimDegiskeni.birimAdi;
                cmbBirim.Tag = birimDegiskeni.birimid.ToString();
                txtBarkod.Text = birimDegiskeni.barkod;
                duzenlemeBarkodu = birimDegiskeni.barkod;
            }
            catch { }



            if (l.webdeGosterilsinmi == "1") chkWebdeGosterilsinmi.Checked = true;
            else if (l.webdeGosterilsinmi == "0") chkWebdeGosterilsinmi.Checked = false;

            //Resimler Getiriliyor
            if (guvenlikVeKontrol.internetVarmi())
            {

                SqlDataReader dr = veri.getDatareader("SELECT Top 1 [urunSirasi],[detayliBilgi],[gAnahtarKelime],[gAciklama],[asgariSiparisMiktari],[urunPuani],[gosterimAnaSayfa],[gosterimSagSol],[gosterimVitrin],[kargoDesi],[kargoBedavami],[sayac],[kargoTutari] FROM  [wtblStokkartWeb] Where [stokid] = " + stokid + " And [silindimi] = '0' And [firmaid] = " + firma.firmaid + " order by eklenmeTarihi desc");
                while (dr.Read())
                {
                    _urunSirasi = dr["urunSirasi"].ToString();
                    _detayliBilgi = dr["detayliBilgi"].ToString();
                    _gAnahtarKelime = dr["gAnahtarKelime"].ToString();
                    _gAciklama = dr["gAciklama"].ToString();
                    _asgariSiparisMiktari = dr["asgariSiparisMiktari"].ToString();
                    _urunPuani = dr["urunPuani"].ToString();
                    _gosterimAnaSayfa = Convert.ToByte(dr["gosterimAnaSayfa"]).ToString();
                    _gosterimSagSol = Convert.ToByte(dr["gosterimSagSol"]).ToString();
                    _gosterimVitrin = Convert.ToByte(dr["gosterimVitrin"]).ToString();
                    _kargoDesi = dr["kargoDesi"].ToString();
                    _kargoBedavami = Convert.ToByte(dr["kargoBedavami"]).ToString();
                }
                dr.Close();
                dr.Dispose();
            }
        }
        private void frmStokKartEkle_Load(object sender, EventArgs e)
        {
        }
        public void baslangic()
        {
            cmbKategori.Items.Clear();
            try { cmbKategori.Items.AddRange(listeler.getKategoriadi()); }
            catch { }
            cmbBirim.Items.Clear();
            try { cmbBirim.Items.AddRange(listeler.getBirimAdi()); }
            catch { }
            texttemizle();
        }
        void texttemizle()
        {
            txtUrunismi.Clear();
            txtSatisFiyat.Text = "0";
            txtAlisFiyat.Text = "0";
            txtBarkod.Clear();
            cmbKategori.Text = "";
            cmbKategori.Tag = "0";
            if (cmbKdv.Text == "") cmbKdv.Text = "18";
            txtBarkod.Select();
        }
        string duzenlemeUrunismi = "";
        string duzenlemeBarkodu = "";
        private void txtBarkod_Leave(object sender, EventArgs e)
        {
            //txtBarkod.Text = satisislemleri.tirnakDuzenle(txtBarkod.Text);
            //satisislemleri.rengiAyarla(sender);
            if (txtBarkod.Text != "" && txtBarkod.Text != duzenlemeBarkodu)
            {
                byte barkod_varmı = 0;
                SqlDataReader dr = veri.getDatareader("select * from tblStokkartBirimleri where firmaid = '" + firma.firmaid + "' and barkod = '" + txtBarkod.Text + "'  and silindimi = '0'");
                while (dr.Read()) barkod_varmı = 1;
                if (barkod_varmı == 1)
                {
                    MessageBox.Show("Bu barkod daha önce girilmiş", firma.programAdi);
                    barkod_varmı = 0;
                    txtBarkod.Clear();
                    txtBarkod.Select();
                    return;
                }
            }
        }

        private void karHesapla()
        {
            try
            {
                txtKar.Text = String.Format("{0:n2}", Convert.ToDouble(txtSatisFiyat.Text) - Convert.ToDouble(txtAlisFiyat.Text));
                txtKarOrani.Text = String.Format("{0:n2}", ((Convert.ToDouble(txtSatisFiyat.Text) * 100) / Convert.ToDouble(txtAlisFiyat.Text)) - 100);
            }
            catch
            {
            }
        }

        private void txtUrunismi_Leave(object sender, EventArgs e)
        {
            //txtUrunisim.Text = satisislemleri.tirnakDuzenle(txtUrunisim.Text);
            //satisislemleri.rengiAyarla(sender);
            if (txtUrunismi.Text != "" && txtUrunismi.Text != duzenlemeUrunismi)
            {
                int urun_varmı = 0;
                SqlDataReader dr = veri.getDatareader("select urunAdi from sorStokkart where firmaid = '" + firma.firmaid + "' and urunAdi = '" + txtUrunismi.Text + "' and silindimi = '0'");
                while (dr.Read())
                {
                    urun_varmı = 1;
                }
                if (urun_varmı == 1)
                {
                    MessageBox.Show("Bu ürün ismi zaten kullanılıyor.", firma.programAdi);
                    txtUrunismi.Clear();
                    txtUrunismi.Select();
                    return;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbBirim.SelectedIndex == -1)
            {
                MessageBox.Show("Geçerli bir Birim Seçin", firma.programAdi);
                cmbBirim.Select();
                return;
            }
            if (txtUrunismi.Text == "")
            {
                MessageBox.Show("Ürün ismi girişi yapın", firma.programAdi);
                txtUrunismi.Select();
                return;
            }
            if (cmbKdv.Items.Contains(cmbKdv.Text) == false)
            {
                MessageBox.Show("Kdv'yi listeden seçin", firma.programAdi);
                cmbKdv.Select();
                return;
            }
            if (cmbKategori.Text != "" && cmbKategori.Items.Contains(cmbKategori.Text) == false)
            {
                MessageBox.Show("Kategoriyi listeden seçin", firma.programAdi);
                cmbKategori.Select();
                return;
            }
            if (cmbBirim.Text != "" && cmbBirim.Items.Contains(cmbBirim.Text) == false)
            {
                MessageBox.Show("Birimi listeden seçin", firma.programAdi);
                cmbBirim.Select();
                return;
            }
            if (cmbKategori.Tag == null) cmbKategori.Tag = "0";
            if (cmbBirim.Tag == null) cmbBirim.Tag = "0";
            try
            {
                string katNo = "";
                if (txtBarkod.Text.Trim().Length > 16)
                {
                    txtBarkod.Text = txtBarkod.Text.Substring(3, 13);
                }
                if (cmbKategori.SelectedIndex >= 0) katNo = listeler.getKategoriNo()[cmbKategori.SelectedIndex];
               // if (txtBarkod.Text.StartsWith("01") && txtBarkod.Text.Length > 16)
               //     txtBarkod.Text = txtBarkod.Text.Substring(0,16);
                Int64 eklenenStokid = Convert.ToInt64(veri.getdatacell("exec [spSetStokKart] " + stokid + ",'" + txtBarkod.Text + "','" + txtUrunismi.Text + "','" + cmbKategori.Tag.ToString() + "','" + txtAlisFiyat.Text.Replace(".", "").Replace(',', '.') + "','" + txtSatisFiyat.Text.Replace(".", "").Replace(",", ".") + "','" + cmbKdv.Text + "','" + cmbKdvTipi.Text + "'," + cmbBirim.Tag.ToString() + ",'" + Convert.ToByte(chkWebdeGosterilsinmi.CheckState) + "','" + firma.firmaid + "','" + firma.subeid + "','" + firma.kullaniciid + "'"));
                if (stokid != 0) stokkart.sil(stokid);
                else stokid = eklenenStokid;
                stokkart.ekle(stokid, "", "", txtUrunismi.Text, Convert.ToDouble(txtAlisFiyat.Text), Convert.ToInt16(cmbKdv.Text), cmbKdv.Text, cmbKategori.Tag.ToString(), "", "", "0", 0, "", "", "", "1", "", Convert.ToByte(chkWebdeGosterilsinmi.CheckState).ToString(), Convert.ToBoolean(chbMobil.CheckState), Convert.ToBoolean(chbVitrin.CheckState), DateTime.Now, "0", firma.subeid, firma.kullaniciid);
                stokkart.birimler.ekle(0, eklenenStokid, Convert.ToInt32(cmbBirim.Tag), cmbBirim.Text, 1, txtBarkod.Text, DateTime.Now, firma.subeid, firma.kullaniciid);
                stokkart.fiyatlar.ekle(0, eklenenStokid, 0, "Satış Fiyatı 1", Convert.ToDouble(txtSatisFiyat.Text), 0, "TL", Convert.ToDouble(txtSatisFiyat.Text), "TL", DateTime.Now, firma.subeid, firma.kullaniciid);
                if (stokid != 0) stokkart.sil(stokid);//daha önce varsa güncellenmesi için siliniyor.
                else stokid = eklenenStokid;
                stokkart.ekle(stokid, _stokkodu, "", txtUrunismi.Text, Convert.ToDouble(txtAlisFiyat.Text), Convert.ToInt16(cmbKdv.Text), cmbKdvTipi.Text, katNo, cmbKategori.Text, _urunkodu, _garanti, Convert.ToInt32(_markaid), _marka, _rafAdi, _ayrinti, "1", "", Convert.ToByte(chkWebdeGosterilsinmi.CheckState).ToString(), Convert.ToBoolean(chbMobil.CheckState), Convert.ToBoolean(chbVitrin.CheckState), DateTime.Now, "0", firma.subeid, firma.kullaniciid);
                veri.getdatacell("update tblStokKart set vitrin=" + Convert.ToByte(chbVitrin.Checked) + " where stokid=" + stokid);
                veri.getdatacell("update tblStokKart set mobil=" + Convert.ToByte(chbMobil.Checked) + " where stokid=" + stokid);
                guncelle.stokkartVerileriniGuncelle();
                listeler.yukleUrunadi();
                this.Refresh();
                if (Convert.ToInt32(txtAdet.Text) > 0)
                    ticaretEkle(stokid);
                if (stokid != 0) MessageBox.Show("İşlem Başarılı", firma.programAdi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                stokid = 0;
                texttemizle();

            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Eklenemedi. Hata Metni:\n" + hata.Message.ToString(), firma.programAdi);
            }
        }
        public Int64 stokid = 0;
        private void btnKategoriBul_Click(object sender, EventArgs e)
        {
            frmKategoriSecimi frm = new frmKategoriSecimi();
            frm._frmStokKartEkle = this;
            frm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbBirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { cmbBirim.Tag = listeler.getBirimid()[cmbBirim.SelectedIndex]; }
            catch { cmbBirim.Tag = "0"; }
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { cmbKategori.Tag = listeler.getKategoriNo()[cmbKategori.SelectedIndex]; }
            catch { cmbKategori.Tag = "0"; }
        }

        private void btnKaydetYeni_Click(object sender, EventArgs e)
        {
            if (txtUrunismi.Text == "")
            {
                MessageBox.Show("Ürün ismi girişi yapın", firma.programAdi);
                txtUrunismi.Select();
                return;
            }
            if (cmbKdv.Items.Contains(cmbKdv.Text) == false)
            {
                MessageBox.Show("Kdv'yi listeden seçin", firma.programAdi);
                cmbKdv.Select();
                return;
            }
            if (cmbKategori.Text != "" && cmbKategori.Items.Contains(cmbKategori.Text) == false)
            {
                MessageBox.Show("Kategoriyi listeden seçin", firma.programAdi);
                cmbKategori.Select();
                return;
            }
            if (cmbBirim.SelectedIndex == -1)
            {
                MessageBox.Show("Geçerli bir Birim Seçin", firma.programAdi);
                cmbBirim.Select();
                return;
            }

            if (cmbBirim.Text != "" && cmbBirim.Items.Contains(cmbBirim.Text) == false)
            {
                MessageBox.Show("Birimi listeden seçin", firma.programAdi);
                cmbBirim.Select();
                return;
            }
            if (cmbKategori.Tag == null) cmbKategori.Tag = "0";
            if (cmbBirim.Tag == null) cmbBirim.Tag = "0";
            try
            {
                //veritabanına stokkart bilgileri ekleniyor
                this.Refresh();

                string katNo = "";
                if (cmbKategori.SelectedIndex >= 0) katNo = listeler.getKategoriNo()[cmbKategori.SelectedIndex];
                //int markaID = 0;
                //if (cmbMarka.SelectedIndex >= 0) markaID = listeler.getMarkano()[cmbMarka.SelectedIndex];
                Int64 eklenenStokid = Convert.ToInt64(veri.getdatacell("exec SpSetStokkartOrtak " + stokid + ", '" + txtBarkod.Text + "', '" + _stokkodu + "','','" + txtUrunismi.Text + "','" + txtAlisFiyat.Text.Replace(".", "").Replace(',', '.') + "','" + cmbKdv.Text + "','" + cmbKdvTipi.Text + "','" + katNo + "','" + _urunkodu + "','" + _garanti + "'," + _markaid + ",'" + _rafAdi + "', " + _urunSirasi + ", '" + _detayliBilgi + "','" + _gAnahtarKelime + "', '" + _gAciklama + "', '" + _ayrinti + "'," + _asgariSiparisMiktari + ",'" + _urunPuani + "','" + _gosterimAnaSayfa + "','" + _gosterimSagSol + "','" + _gosterimVitrin + "','" + _kargoDesi + "','" + _kargoBedavami + "','0'," + cmbBirim.Tag.ToString() + ",'" + txtSatisFiyat.Text.Replace(".", "").Replace(',', '.') + "','" + _indirim + "','" + _indirimTipi + "','" + _dovizi + "','" + Convert.ToByte(chkWebdeGosterilsinmi.CheckState) + "','" + firma.firmaid + "','" + firma.subeid + "','" + firma.kullaniciid + "'"));
                //class'a stokkart verileri ekleniyor
                if (stokid != 0) stokkart.sil(stokid);//daha önce varsa güncellenmesi için siliniyor.
                else stokid = eklenenStokid;
                stokkart.ekle(stokid, _stokkodu, "", txtUrunismi.Text, Convert.ToDouble(txtAlisFiyat.Text), Convert.ToInt16(cmbKdv.Text), cmbKdvTipi.Text, katNo, cmbKategori.Text, _urunkodu, _garanti, Convert.ToInt32(_markaid), _marka, _rafAdi, _ayrinti, "1", "", Convert.ToByte(chkWebdeGosterilsinmi.CheckState).ToString(), Convert.ToBoolean(chbMobil.CheckState), Convert.ToBoolean(chbVitrin.CheckState), DateTime.Now, "0", firma.subeid, firma.kullaniciid);
                guncelle.stokkartVerileriniGuncelle();
                listeler.yukleUrunadi();
                this.Refresh();
                if (Convert.ToInt32(txtAdet.Text) > 0)
                    ticaretEkle(stokid);
                if (stokid != 0) MessageBox.Show("İşlem Başarılı", firma.programAdi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                stokid = 0;
                texttemizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Eklenemedi. Hata Metni:\n" + hata.Message, firma.programAdi);
            }
        }

        private void ticaretEkle(long stokid)
        {
            int grupid = ticaretAyrinti2.getMaxGrupid() + 1;
            bool grupidVerildimi = true;
            try
            {
                ticaretAyrinti2.ekle(Convert.ToInt64(0), Convert.ToInt64(0), "Peşin", DateTime.Now, DateTime.Now.ToShortTimeString(), DateTime.Now, "Faturasız Alış", "", "", "", "", "", "", "", "Hızlı Stok Ekleme", 0, 0, 0, "1", "0", DateTime.Now, "0", firma.subeid, firma.kullaniciid, true, false, grupid);
                ticaret.ekle(Convert.ToInt64(0), Convert.ToInt64(0), stokid, "", txtBarkod.Text, txtUrunismi.Text, 1 * Math.Abs(Convert.ToDouble(txtAdet.Text)), 0, cmbBirim.Text, Convert.ToDouble(1), Convert.ToDouble(txtAlisFiyat.Text), Convert.ToInt16(cmbKdv.Text), cmbKdvTipi.Text, Convert.ToDouble(0), 0, 0, "TL", 1, "", DateTime.Now, "", firma.subeid, firma.kullaniciid, false, grupid);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ticaret Ayrinti ve Ticaret Ekleme İşleminde Hata Meydana Geldi , Hata:" + ex.Message);
            }
        }

        private void txtAlisFiyat_TextChanged(object sender, EventArgs e)
        {
            karHesapla();
        }
    }
}
