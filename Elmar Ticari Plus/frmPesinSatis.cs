using elmarLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Linq.Expressions;
namespace Elmar_Ticari_Plus
{
    public partial class frmPesinSatis : System.Windows.Forms.Form
    {
        #region Form ve Nesne Boyutları
        //private Rectangle btnPesinOrjinal;
        //private Rectangle btnPosOrjinal;
        //private Rectangle btnIptalOrjinal;
        //private Rectangle btnAyarOrjinal;
        //private Rectangle btn5Orjinal;
        //private Rectangle btn10Orjinal;
        //private Rectangle btn20Orjinal;
        //private Rectangle btn50Orjinal;
        //private Rectangle btn100Orjinal;
        //private Rectangle btn200Orjinal;
        //private Rectangle txtAlinanOrjinal;
        //private Rectangle txtParaUstuOrjinal;
        //private Rectangle txtIndirimOrjinal;
        //private Rectangle txtGenelToplamOrjinal;
        //private Size frmPesinSatisOrjinal;
        #endregion

        #region Tanımlamalar
        private formTipi pesinSatis;
        public string[] ports = SerialPort.GetPortNames();
        private List<string> listKategori = new List<string>();
        private List<string> listKatNo = new List<string>();
        int toplam = 0;
        private Int16 miktarCarpani = -1;
        public faturaBilgileri _faturaBilgileri;
        //private cariTipleri cariTipi = cariTipleri.carisizislem;
        private stokkart.stokkartAyrinti urunBilgisi;
        public Int64 cariid = 0;
        public string islemTuru;
        private string onay = "0";
        public string _hesabaislendimi = "0";
        private Int32 gecerliFiyatid = 1;
        private List<Int64> adresidler = new List<Int64>();
        public long ticaretAyrintiid = 0;
        public string silindimi = "0";
        public formTipi _formTipi;
        public int grupid = 1;
        private bool grupidVerildimi = false;
        double duzenlemeBakiyesi = 0;
        string egelen = "0";
        String terazicom = "COM4";
        String displaycom = "COM2";
        private int teraziAdi = 0;
        String tMiktar;
        String kosul;
        SerialPort sp3 = new SerialPort();
        SerialPort sp2 = new SerialPort();
        SerialPort sp1 = new SerialPort();
        double tAraToplam = 0;
        List<int> listSatisFiyatlari = new List<int>();
        string tAraToplam_F
        {
            get { return String.Format("{0:n2}", tAraToplam); }
            set { tAraToplam = Convert.ToDouble(value); txtToplam.Text = tAraToplam_F; }
        }
        double tKdvtutar = 0;
        double tIskToplam = 0;
        string tKdvtutar_F
        {
            get { return String.Format("{0:n2}", tKdvtutar); }
            set { tKdvtutar = Convert.ToDouble(value); txtKdvTop.Text = tKdvtutar_F; }
        }
        double tGenelToplam = 0;
        string tGenelToplam_F
        {
            get { return String.Format("{0:n2}", tGenelToplam); }
            set { tGenelToplam = Convert.ToDouble(value); txtGenelTop.Text = tGenelToplam_F; }
        }
        double tIskonto = 0;
        string tIskonto_F
        {
            get { return String.Format("{0:n2}", tIskonto); }
            set { tIskonto = Convert.ToDouble(value); txtiskonto.Text = tIskonto_F; }
        }
        double tIscilik = 0;

        double tNakliyat = 0;
        static Thread t1;
        public static bool programCalisiyormu = false;
        #endregion

        public frmPesinSatis()
        {
            InitializeComponent();
        }

        public frmPesinSatis(formTipi pesinSatis)
        {
            InitializeComponent();
            this.pesinSatis = pesinSatis;
            NesneGorselleri.dataGridView(dgTicaret);
            //   PesinSatisVitrinIslemleri();
            dgTicaret.Columns["birim"].Visible = false;
            dgTicaret.Columns["katsayi"].Visible = false;
            dgTicaret.Columns["kdv"].Visible = false;
            dgTicaret.Columns["kdvTipi"].Visible = false;
            dgTicaret.Columns["isk1"].Visible = false;
            dgTicaret.Columns["AraTop"].Visible = false;
            dgTicaret.Columns["TopKDV"].Visible = false;
            dgTicaret.Columns["dovizTuru"].Visible = false;

        }

        public enum formTipi
        {
            faturasizSatis, faturaliSatis, satisDuzenle, faturasizAlis, faturaliAlis, stokDuzenle, siparisOlustur, siparisDuzenle, teklifOlustur, teklifDuzenle, stokTransferi, transferDuzenle, satisiade, alisiade, stokCikis, pesinSatis, alisiadeDuzenle, satisiadeDuzenle
        }

        public class faturaBilgileri
        {
            public string faturaNo;
            public string belgeNo;
            public string irsaliyeNo;
            public string faturaAciklamasi;
            public DateTime faturaTarihi;
            public DateTime fiiliSefkTarihi;
        }

        #region Terazi Ve Port Kontrolleri
        public void terazi()
        {

            egelen = "0";
            if (sp3.IsOpen != true)
            {
                try
                {
                    sp3.PortName = terazicom;
                    sp3.Open();
                    sp3.Write("On");
                    sp3.Write("8888");
                    for (int y = 0; y < 1;)
                    {
                        string gelen = sp3.ReadLine();
                        if (gelen.StartsWith("+"))
                        {
                            sp3.Close();
                            gelen = gelen.Replace(" ", "").ToString();
                            gelen = gelen.Replace("+", "");
                            int kgIndex = gelen.IndexOf("kg");
                            if (kgIndex > -1)
                            {
                                gelen = gelen.Substring(0, kgIndex);
                            }
                            if (gelen != egelen)
                            {
                                //textBox1.Text = gelen;
                                egelen = gelen;
                                y = 5;
                            }
                            else
                            {
                                sp3.Open();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    if (sp3.IsOpen)
                        sp3.Close();
                }
                //  timer1.Start();
            }
        } //TEM

        public void terazi2() //CAS
        {
            if (terazicom.Equals(""))
                terazicom = "COM2";
            try
            {
                sp3 = new SerialPort(terazicom, 9600, Parity.None, 8, StopBits.One);
                egelen = "0";
                if (sp3.IsOpen != true)
                {
                    sp3.Open();
                    try
                    {
                        string veri = sp3.ReadLine();
                        var decimalArray = Regex.Split(veri, @"[^0-9\,\.]+").Where(c => c != "." && c.Trim() != "");
                        foreach (var s in decimalArray)
                        {
                            egelen = s;
                        }

                        egelen = egelen.Replace("S", "").Replace("s", "").Replace("U", "");
                        sp3.Close();
                    }
                    catch (Exception e)
                    {
                        if (sp3.IsOpen)
                            sp3.Close();
                    }

                }
                else
                {
                    if (sp3.IsOpen) sp3.Close();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata oluştu:" + exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void terazi3() //SELES 
        {
            Application.DoEvents();
            SerialPort serialPort = new SerialPort();
            try
            {
                serialPort.PortName = terazicom;
                if (!serialPort.IsOpen)
                    serialPort.Open();
                serialPort.Write("$");
                Thread.Sleep(200);
                string str;
                try
                {
                    str = serialPort.ReadExisting();
                }
                catch (Exception ex)
                {
                    Exception exception = ex;
                    serialPort.Close();
                    return;
                }

                egelen = str.Replace("S", "").Replace(" ", "").Replace("kg", "");
                serialPort.Close();
            }
            catch (Exception ex)
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
            }
        }

        void PortKontrol()
        {
            if (ports.Length < 1 && checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                MessageBox.Show("Bilgisayarınıza Bağlı Cihaz Bulunamıyor");
            }
            else if (ports.Length < 1 && checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                MessageBox.Show("Bilgisayarınıza Bağlı Cihaz Bulunamıyor");
            }
        }
        #endregion

        #region Metotlar

        void urunuDataGrideEkle(Int64 pStokid, string pBarkod, string pMiktar)
        {
            //string birim = veri.getdatacell("Select birimid from tblStokkartBirimleri where  tblStokkartBirimleri.stokid="  + urunBilgisi.stokid);
            foreach (stokkart.birimler.birimlerAyrinti birimBilgisi in stokkart.birimler.bul_stokid(pStokid))
            {
                kosul = (birimBilgisi.birimAdi);
                pBarkod = birimBilgisi.barkod;
            }
            //Daha önce eklenmişmi diye bakılıyor.
            if (firma.firmaid == 16463) goto git; //30 yıl kafe için yapıldı
            for (int i = 0; i < dgTicaret.Rows.Count; i++)
            {// && ((pBarkod != "" && dgTicaret.Rows[i].Cells["barkod"].Value.ToString() == pBarkod) || dgTicaret.Rows[i].Cells["urunAdi"].Value.ToString() == cmbUrunAdi.Text)
                if (dgTicaret.Rows[i].Cells["stokid"].Value.ToString() == pStokid.ToString())
                {
                    double miktar = 1;
                    if (kosul == "KG")
                    {
                        if (checkBox1.Checked == true)
                        {
                            //TEM TERAZİ
                            // CAS TERAZİ
                            // SELES WSP
                            if (teraziAdi == 0)
                            {
                                terazi();
                            }
                            else if (teraziAdi == 2) //firma.kullaniciAdi.Equals("PINARTEPE") || firma.firmaid==17881)//kosem manav ve arıcak kullanıcısı için yapıldı cas terazisi
                            {
                                terazi2();
                            }
                            else if (teraziAdi == 1) // (firma.firmaid == 16768)//çaydaçıra market cas terazi SW -||
                            {
                                terazi3();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen terazi adını seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            tMiktar = egelen;
                            tMiktar = tMiktar.Replace(".", ",").ToString();
                        }
                        else tMiktar = "1";
                        miktar = Convert.ToDouble(tMiktar);
                        Double eski = Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value);
                        Double yeni = Convert.ToDouble(pMiktar);
                        if (txtBarkod.Text.StartsWith("24") ||txtBarkod.Text.StartsWith("21") || txtBarkod.Text.StartsWith("27") || txtBarkod.Text.StartsWith("28")) dgTicaret.Rows[i].Cells["miktar"].Value = (Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value) + yeni).ToString();
                        else dgTicaret.Rows[i].Cells["miktar"].Value = (Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value) + miktar).ToString();
                        try { dgTicaret.Rows[i].Cells["barkod"].Selected = true; }
                        catch { }

                    }
                    else
                    {
                        Double yeni = Convert.ToDouble(pMiktar);
                        if ((txtBarkod.Text.StartsWith("24") || txtBarkod.Text.StartsWith("21") || txtBarkod.Text.StartsWith("27") || txtBarkod.Text.StartsWith("28"))) dgTicaret.Rows[i].Cells["miktar"].Value = (Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value) + yeni).ToString();
                        else dgTicaret.Rows[i].Cells["miktar"].Value = (Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value) + 1).ToString();
                        try { dgTicaret.Rows[i].Cells["barkod"].Selected = true; }
                        catch { }
                    }
                    hesaplariYap();
                    temizle_stokkartAra();
                    return;
                }
            }
            git:
            if (kosul == "KG")
            {
                if (checkBox1.Checked == true)
                {
                    if (teraziAdi == 0)
                    {
                        terazi();
                    }
                    else if (teraziAdi == 2) //firma.kullaniciAdi.Equals("PINARTEPE") || firma.firmaid==17881)//kosem manav ve arıcak kullanıcısı için yapıldı cas terazisi
                    {
                        terazi2();
                    }
                    else if (teraziAdi == 1) // (firma.firmaid == 16768)//çaydaçıra market cas terazi SW -||
                    {
                        terazi3();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen terazi adını seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    tMiktar = egelen;
                    tMiktar = tMiktar.Replace(".", ",").ToString();
                    if (chbAgirlik.Checked)
                    {
                        try
                        {
                            pnlAgirlik.Visible = true;
                            if (txtTutar.Text.Equals(""))
                                txtTutar.Text = "0";
                            lblBirimFiyat.Text = stokkart.fiyatlar.getFiyatTutari(gecerliFiyatid, Convert.ToInt64(pStokid)).ToString();
                            txtMiktar.Text = (Convert.ToDouble(txtTutar.Text) / stokkart.fiyatlar.getFiyatTutari(gecerliFiyatid, Convert.ToInt64(pStokid))).ToString();
                            lblUrunAdi.Text = urunBilgisi.urunAdi;
                            programCalisiyormu = true;
                            //   MessageBox.Show("Thread Başladı");
                            baslangic();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                else
                {

                    tMiktar = "1";
                }
                //Datagride ekleniyor.
                if (txtBarkod.Text.StartsWith("27") || txtBarkod.Text.StartsWith("28") || txtBarkod.Text.StartsWith("21"))

                    dgTicaret.Rows.Add("0", urunBilgisi.stokid, urunBilgisi.stokkodu, pBarkod, urunBilgisi.urunAdi, pMiktar, kosul, 1, 0, 0, urunBilgisi.kdv, null, 0, 0, "", 0, 0, 0, null, 1);
                else dgTicaret.Rows.Add("0", urunBilgisi.stokid, urunBilgisi.stokkodu, pBarkod, urunBilgisi.urunAdi, tMiktar, kosul, 1, 0, 0, urunBilgisi.kdv, null, 0, 0, "", 0, 0, 0, null, 1);

                dgTicaret.Rows[dgTicaret.Rows.Count - 1].Selected = true;
                try { dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["barkod"].Selected = true; }
                catch { }

                //birimler ekleniyor.
                DataGridViewComboBoxCell kolon;
                kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["birim"];
                foreach (stokkart.birimler.birimlerAyrinti birimBilgisi in stokkart.birimler.bul_stokid(pStokid))
                {
                    kolon.Items.Add(birimBilgisi.birimAdi);
                    if (pBarkod == "" && kolon.Value == null)
                    {
                        dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["barkod"].Value = birimBilgisi.barkod;
                        kolon.Value = birimBilgisi.birimAdi;
                        MessageBox.Show(kolon.Value.ToString());
                    }
                    else if (birimBilgisi.barkod == txtBarkod.Text) kolon.Value = birimBilgisi.birimAdi;
                    //kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["katsayi"];
                    //kolon.Items.Add(birimBilgisi.katsayi);
                }
                if (kolon.Value == null || kolon.Value.ToString() == "")
                {
                    if (kolon.Items.Count == 0) kolon.Items.Add("Adet");
                    kolon.Value = kolon.Items[0].ToString();
                    MessageBox.Show(kolon.Value.ToString());
                }
                dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["katsayi"].Value = stokkart.birimler.bul_stokid(pStokid).Where(u => u.birimAdi == kolon.Value.ToString()).First().katsayi.ToString();
                //Kdv tipi ekleniyor
                kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["kdvTipi"];
                kolon.Items.Add("Dahil");
                kolon.Items.Add("Hariç");
                kolon.Value = urunBilgisi.kdvTipi;
                //Döviz Ekleniyor
                kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["dovizTuru"];
                kolon.Items.Add("TL");
                kolon.Items.Add("USD");
                kolon.Items.Add("Euro");
                kolon.Items.Add("ANZ");
                try
                {
                    kolon.Value = stokkart.fiyatlar.listFiyatlar.Where(u => u.stokid == Convert.ToInt64(dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["stokid"].Value) && u.fiyatid == gecerliFiyatid).FirstOrDefault().dovizi;
                }
                catch (Exception)
                {
                    kolon.Value = "TL";
                }
                //geçerli fiyat getiriliyor
                if (islemTuru.Contains("Satış") || islemTuru.Contains("Teklif")) dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["birimFiyat"].Value = stokkart.fiyatlar.getFiyatTutari(gecerliFiyatid, Convert.ToInt64(dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["stokid"].Value));
                else if (islemTuru.Contains("Alış") || islemTuru.Contains("Sipariş")) dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["birimFiyat"].Value = urunBilgisi.alisFiyat;
                temizle_stokkartAra();
                hesaplariYap();
            }

            else
            {
                //Datagride ekleniyor.
                dgTicaret.Rows.Add("0", urunBilgisi.stokid, urunBilgisi.stokkodu, pBarkod, urunBilgisi.urunAdi, pMiktar, null, 1, 0, 0, urunBilgisi.kdv, null, 0, 0, "", 0, 0, 0, null, 1);

                dgTicaret.Rows[dgTicaret.Rows.Count - 1].Selected = true;
                try { dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["barkod"].Selected = true; }
                catch { }

                //birimler ekleniyor.
                DataGridViewComboBoxCell kolon;
                kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["birim"];
                foreach (stokkart.birimler.birimlerAyrinti birimBilgisi in stokkart.birimler.bul_stokid(pStokid))
                {
                    kolon.Items.Add(birimBilgisi.birimAdi);
                    if (pBarkod == "" && kolon.Value == null)
                    {
                        dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["barkod"].Value = birimBilgisi.barkod;
                        kolon.Value = birimBilgisi.birimAdi;
                    }
                    else if (birimBilgisi.barkod == txtBarkod.Text) kolon.Value = birimBilgisi.birimAdi;
                    //kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["katsayi"];
                    //kolon.Items.Add(birimBilgisi.katsayi);
                }
                if (kolon.Value == null || kolon.Value.ToString() == "")
                {
                    if (kolon.Items.Count == 0) kolon.Items.Add("Adet");
                    kolon.Value = kolon.Items[0].ToString();
                }
                dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["katsayi"].Value = stokkart.birimler.bul_stokid(pStokid).Where(u => u.birimAdi == kolon.Value.ToString()).First().katsayi.ToString();

                //Kdv tipi ekleniyor
                kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["kdvTipi"];
                kolon.Items.Add("Dahil");
                kolon.Items.Add("Hariç");
                kolon.Value = urunBilgisi.kdvTipi;
                //Döviz Ekleniyor
                kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["dovizTuru"];
                kolon.Items.Add("TL");
                kolon.Items.Add("USD");
                kolon.Items.Add("Euro");
                kolon.Items.Add("ANZ");
                try
                {
                    kolon.Value = stokkart.fiyatlar.listFiyatlar.Where(u => u.stokid == Convert.ToInt64(dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["stokid"].Value) && u.fiyatid == gecerliFiyatid).FirstOrDefault().dovizi;
                }
                catch (Exception)
                {
                    kolon.Value = "TL";
                }
                //geçerli fiyat getiriliyor
                double fiyat = 0;
                stokkart.fiyatlar.fiyatlarAyrinti fa = stokkart.fiyatlar.getFiyat(gecerliFiyatid, Convert.ToInt64(dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["stokid"].Value));
                if (fa != null)
                {
                    fiyat = fa.fiyatTutari;
                    dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["isk1"].Value = fa.indirim;
                }
                if (islemTuru.Contains("Satış") || islemTuru.Contains("Teklif")) dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["birimFiyat"].Value = fiyat;
                else if (islemTuru.Contains("Alış") || islemTuru.Contains("Sipariş")) dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["birimFiyat"].Value = urunBilgisi.alisFiyat;
                temizle_stokkartAra();
                hesaplariYap();
            }
        }
        void temizle_stokkartAra()
        {
            txtBarkod.Clear();
            cmbUrunAdi.Text = "";
            if (chkMiktarOtomatik.Checked) txtBarkod.Select();
            else dgTicaret.Select();
        }
        void yaziciListele()
        {
            try
            {
                cmbYazicilistesi.Items.Clear();
                cmbYazicilistesi.Items.AddRange(islemler.yaziciislemleri.yaziciListele());
            }
            catch (Exception hata)
            {
            }
        }
        void portListele()
        {
            try
            {
                ports = SerialPort.GetPortNames();
                cmbPort.Items.Clear();
                foreach (var item in ports)
                {
                    cmbPort.Items.Add(item);
                }
            }
            catch (Exception hata)
            {
            }
        }
        public void urunAdiListesiniYenile()
        {
            //ürün listesi getiriliyor
            cmbUrunAdi.Items.Clear();
            try { cmbUrunAdi.Items.AddRange(listeler.getUrunisim()); }
            catch { }
        }

        void satisFiyatiListele()
        {
            cmbGecerliSatisFiyati.Items.Clear();
            listSatisFiyatlari.Clear();
            SqlDataReader dr = veri.getDatareader("Select fiyatid, fiyatAdi From tblFiyatTaslak Where firmaid = " + firma.firmaid + " and silindimi = '0' order by fiyatAdi asc");
            while (dr.Read())
            {
                listSatisFiyatlari.Add(Convert.ToInt32(dr["fiyatid"]));
                cmbGecerliSatisFiyati.Items.Add(dr["fiyatAdi"].ToString());
            }

        }

        void formTemizle()
        {
            toplam = 0;
            if (this.Text.Contains("Düzenle")) this.Close();
            grupidVerildimi = false;
            _faturaBilgileri = new faturaBilgileri();
            duzenlemeBakiyesi = 0;
            onay = "0";
            tAraToplam_F = "0";
            tKdvtutar_F = "0";
            tIskonto_F = "0";
            tGenelToplam_F = "0";
            tIskToplam = 0;
            txtToplam.Text = tAraToplam_F;
            txtKdvTop.Text = tKdvtutar_F;
            txtGenelTop.Text = tGenelToplam_F;
            temizle_stokkartAra();
            dgTicaret.Rows.Clear();
            txtNakit1.Text = "V.P.";
            txtNakit2.Text = "P.Ü";
            cariid = 0;
        }

        void ayarlariGetir()
        {
            try
            {

                //Stok Kontrol Türü Getiriliyor (1-2-3)
                if (this.islemTuru == "Faturasız Satış")
                {
                    if (ayarlar.Faturasız_Satış_Stok_Kontrolleri_Tipi == "1") rdStokKontrolleriYapilmasin.Checked = true;
                    else if (ayarlar.Faturasız_Satış_Stok_Kontrolleri_Tipi == "2") rdStokKontrolleriYapilsinUyariVersin.Checked = true;
                    else if (ayarlar.Faturasız_Satış_Stok_Kontrolleri_Tipi == "3") rdStokKontrolleriYapilsinEngellesin.Checked = true;
                    else rdStokKontrolleriYapilmasin.Checked = true;
                }
                else if (this.islemTuru == "Transfer")
                {
                    if (ayarlar.Transfer_Stok_Kontrolleri_Tipi == "1") rdStokKontrolleriYapilmasin.Checked = true;
                    else if (ayarlar.Transfer_Stok_Kontrolleri_Tipi == "2") rdStokKontrolleriYapilsinUyariVersin.Checked = true;
                    else if (ayarlar.Transfer_Stok_Kontrolleri_Tipi == "3") rdStokKontrolleriYapilsinEngellesin.Checked = true;
                    else rdStokKontrolleriYapilmasin.Checked = true;
                }
                else if (this.islemTuru == "Faturalı Satış")
                {
                    if (ayarlar.Faturalı_Satış_Stok_Kontrol_Tipi == "1") rdStokKontrolleriYapilmasin.Checked = true;
                    else if (ayarlar.Faturalı_Satış_Stok_Kontrol_Tipi == "2") rdStokKontrolleriYapilsinUyariVersin.Checked = true;
                    else if (ayarlar.Faturalı_Satış_Stok_Kontrol_Tipi == "3") rdStokKontrolleriYapilsinEngellesin.Checked = true;
                    else rdStokKontrolleriYapilmasin.Checked = true;
                }
                //Satış Fiyatları Getiriliyor
                if (this.islemTuru == "Faturasız Satış") gecerliFiyatid = Convert.ToInt32(ayarlar.Faturasız_Satış_Fiyatı);
                else if (this.islemTuru == "Transfer") gecerliFiyatid = Convert.ToInt32(ayarlar.Transfer_Satış_Fiyatı);
                else if (this.islemTuru == "Faturalı Satış") gecerliFiyatid = Convert.ToInt32(ayarlar.Faturalı_Satış_Fiyatı);
                else gecerliFiyatid = Convert.ToInt32(ayarlar.Faturasız_Satış_Fiyatı);
                for (int i = 0; i < listSatisFiyatlari.Count; i++)
                {
                    if (listSatisFiyatlari[i] == gecerliFiyatid)
                    {
                        cmbGecerliSatisFiyati.SelectedIndex = i;
                        break;
                    }
                }
                //Oto Yazdır Getiriliyor
                if (this.islemTuru == "Faturasız Satış") chkOtoYazdir.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturasız_Satış_Oto_Yazdır));
                else if (this.islemTuru == "Transfer") chkOtoYazdir.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Transfer_Oto_Yazdır));
                else if (this.islemTuru == "Faturalı Satış") chkOtoYazdir.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturalı_Satış_Oto_Yazdır));
                else if (this.islemTuru == "Satış İade") chkOtoYazdir.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.İade_Satış_Oto_Yazdır));
                else if (this.islemTuru == "Faturasız Alış") chkOtoYazdir.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturasız_Alış_Oto_Yazdır));
                else if (this.islemTuru == "Faturalı Alış") chkOtoYazdir.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturalı_Alış_Oto_Yazdır));
                else if (this.islemTuru == "Alış İade") chkOtoYazdir.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.İade_Alış_Oto_Yazdır));
                //Miktar Otomatik Getiriliyor
                if (this.islemTuru == "Faturasız Satış") chkMiktarOtomatik.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturasız_Satış_Miktar_Otomatik));
                else if (this.islemTuru == "Transfer") chkMiktarOtomatik.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Transfer_Satış_Miktar_Otomatik));
                else if (this.islemTuru == "Faturalı Satış") chkMiktarOtomatik.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturalı_Satış_Miktar_Otomatik));
                else if (this.islemTuru == "Satış İade") chkMiktarOtomatik.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.İade_Satış_Miktar_Otomatik));
                else if (this.islemTuru == "Faturasız Alış") chkMiktarOtomatik.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturasız_Alış_Miktar_Otomatik));
                else if (this.islemTuru == "Faturalı Alış") chkMiktarOtomatik.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturalı_Alış_Miktar_Otomatik));
                else if (this.islemTuru == "Alış İade") chkMiktarOtomatik.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.İade_Alış_Miktar_Otomatik));
                //Kartlı Satış Getiriliyor
                if (this.islemTuru == "Faturasız Satış") chkKartliSatis.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturasız_Satış_Kartlı_Satış));
                else if (this.islemTuru == "Transfer") chkKartliSatis.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Transfer_Satış_Kartlı_Satış));
                else if (this.islemTuru == "Faturalı Satış") chkKartliSatis.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturalı_Satış_Kartlı_Satış));
                else if (this.islemTuru == "Satış İade") chkKartliSatis.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.İade_Satış_Kartlı_Satış));
                else if (this.islemTuru == "Faturasız Alış") chkKartliSatis.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturasız_Alış_Kartlı_Satış));
                else if (this.islemTuru == "Faturalı Alış") chkKartliSatis.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Faturalı_Alış_Kartlı_Satış));
                else if (this.islemTuru == "Alış İade") chkKartliSatis.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.İade_Alış_Kartlı_Satış));
                //Yazıcı Listesi Getiriliyor
                if (this.islemTuru == "Faturasız Satış") cmbYazicilistesi.Text = ayarlar.Faturasız_Satış_Yazıcı;
                else if (this.islemTuru == "Transfer") cmbYazicilistesi.Text = ayarlar.Transfer_Yazıcı;
                else if (this.islemTuru == "Faturalı Satış") cmbYazicilistesi.Text = ayarlar.Faturalı_Satış_Yazıcı;
                else if (this.islemTuru == "Satış İade") cmbYazicilistesi.Text = ayarlar.İade_Satış_Yazıcı;
                else if (this.islemTuru == "Faturasız Alış") cmbYazicilistesi.Text = ayarlar.Faturasız_Alış_Yazıcı;
                else if (this.islemTuru == "Faturalı Alış") cmbYazicilistesi.Text = ayarlar.Faturalı_Alış_Yazıcı;
                else if (this.islemTuru == "Alış İade") cmbYazicilistesi.Text = ayarlar.İade_Alış_Yazıcı;
                else if (this.islemTuru == "Sipariş") cmbYazicilistesi.Text = ayarlar.Sipariş_Yazıcı;
                else if (this.islemTuru == "Teklif") cmbYazicilistesi.Text = ayarlar.Teklif_Yazıcı;
                //Çıktı Türü Getiriliyor
                if (this.islemTuru == "Faturasız Satış") cmbCiktituru.Text = ayarlar.Faturasız_Satış_Kağıt_Tipi;
                else if (this.islemTuru == "Transfer") cmbCiktituru.Text = ayarlar.Transfer_Kağıt_Tipi;
                else if (this.islemTuru == "Faturalı Satış") cmbCiktituru.Text = ayarlar.Faturalı_Satış_Kağıt_Tipi;
                else if (this.islemTuru == "Satış İade") cmbCiktituru.Text = ayarlar.İade_Satış_Kağıt_Tipi;
                else if (this.islemTuru == "Faturasız Alış") cmbCiktituru.Text = ayarlar.Faturasız_Alış_Kağıt_Tipi;
                else if (this.islemTuru == "Faturalı Alış") cmbCiktituru.Text = ayarlar.Faturalı_Alış_Kağıt_Tipi;
                else if (this.islemTuru == "Alış İade") cmbCiktituru.Text = ayarlar.İade_Alış_Kağıt_Tipi;
                else if (this.islemTuru == "Sipariş") cmbCiktituru.Text = ayarlar.Sipariş_Kağıt_Tipi;
                else if (this.islemTuru == "Teklif") cmbCiktituru.Text = ayarlar.Teklif_Kağıt_Tipi;
                //Çıktı Türü Getiriliyor
                if (this.islemTuru == "Faturasız Satış") listeyiGrideUygula(ayarlar.Faturasız_Satış_Liste);
                else if (this.islemTuru == "Transfer") listeyiGrideUygula(ayarlar.Transfer_Liste);
                else if (this.islemTuru == "Faturalı Satış") listeyiGrideUygula(ayarlar.Faturalı_Satış_Liste);
                else if (this.islemTuru == "Satış İade") listeyiGrideUygula(ayarlar.İade_Satış_Liste);
                else if (this.islemTuru == "Faturasız Alış") listeyiGrideUygula(ayarlar.Faturasız_Alış_Liste);
                else if (this.islemTuru == "Faturalı Alış") listeyiGrideUygula(ayarlar.Faturalı_Alış_Liste);
                else if (this.islemTuru == "Alış İade") listeyiGrideUygula(ayarlar.İade_Alış_Liste);
                else if (this.islemTuru == "Sipariş") listeyiGrideUygula(ayarlar.Sipariş_Liste);
                else if (this.islemTuru == "Teklif") listeyiGrideUygula(ayarlar.Teklif_Liste);
                //Auto Terazi Ve Display Ekranı
                checkBox1.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Auto_Terazi));
                checkBox2.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Display));
                chbAgirlik.Checked = Convert.ToBoolean(Convert.ToByte(ayarlar.Agirlik));
                cmbPort.Text = ayarlar.Terazi_Portu;
                cmbTeraziAdi.SelectedIndex = Convert.ToInt32(ayarlar.Terazi_Adi);
            }
            catch (Exception)
            {
            }

        }

        public void yeniKayit()
        {
            if (chkOtoYazdir.Checked)
            {
                for (int i = 0; i < Convert.ToInt32(txtYazdirilacakBelgeSayisi.Text); i++)
                {
                    try
                    {
                        yazdirVeonizle("yazdir", ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().odemeTuru);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            formTemizle();
            if (this.islemTuru.Contains("Faturalı"))
            {
                try
                {
                    txtFaturaNo.Text = (Convert.ToInt64(txtFaturaNo.Text) + 1).ToString();
                }
                catch { }
            }
        }

        bool odemeislemiBaslangici(string _odemeTuru)
        {
            //Ürün Kontrolleri
            if (dgTicaret.Rows.Count == 0)
            {
                MessageBox.Show("Önce listeye ürün ekleyin", firma.programAdi);
                return false;
            }
            //Diğer Kontroller         
            _hesabaislendimi = "1";
            //Ticaret Tablolarına ekleme işlemleri
            if (grupidVerildimi == false)
            {
                string txtSaat = DateTime.Now.ToShortTimeString();
                grupid = ticaretAyrinti2.getMaxGrupid() + 1;
                grupidVerildimi = true;
                try
                {
                    ticaretAyrinti2.ekle(ticaretAyrintiid, cariid, _odemeTuru, DateTime.Now, txtSaat, _faturaBilgileri.fiiliSefkTarihi, islemTuru, _faturaBilgileri.faturaNo, _faturaBilgileri.belgeNo, _faturaBilgileri.irsaliyeNo, "", "", "", _faturaBilgileri.faturaAciklamasi, "", miktarCarpani * Math.Abs(Convert.ToDouble(txtiskonto.Text)), -1 * miktarCarpani * Convert.ToDouble("0"), -1 * miktarCarpani * Convert.ToDouble("0"), _hesabaislendimi, onay, DateTime.Now, silindimi, firma.subeid, firma.kullaniciid, false, false, grupid);
                    for (int i = 0; i < dgTicaret.Rows.Count; i++)
                    {
                        ticaret.ekle(Convert.ToInt64(dgTicaret.Rows[i].Cells["ticaretid"].Value), ticaretAyrintiid, Convert.ToInt64(dgTicaret.Rows[i].Cells["stokid"].Value), dgTicaret.Rows[i].Cells["stokkodu"].Value.ToString(), dgTicaret.Rows[i].Cells["barkod"].Value.ToString(), dgTicaret.Rows[i].Cells["urunAdi"].Value.ToString(), miktarCarpani * Math.Abs(Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value)), 0, dgTicaret.Rows[i].Cells["birim"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["katsayi"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["birimFiyat"].Value), Convert.ToInt16(dgTicaret.Rows[i].Cells["kdv"].Value), dgTicaret.Rows[i].Cells["kdvTipi"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk1"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk2"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk3"].Value), dgTicaret.Rows[i].Cells["dovizTuru"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["dovizDegeri"].Value), dgTicaret.Rows[i].Cells["seriNo"].Value.ToString(), DateTime.Now, silindimi, firma.subeid, firma.kullaniciid, false, grupid);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                //if (chkOtoYazdir.Checked && _odemeTuru=="Peşin") yazdirVeonizle("yazdir", _odemeTuru);
            }
            return true;
        }

        void yazdirVeonizle(string _islem, string _odemeTuru)
        {
            //string sql = "SELECT [cariid],[adiSoyadi],[odemeTuru],[islemTarihi],[islemSaati],[islemTuru],abs([AraTop]) AraTop,abs([KdvTop]) KdvTop,abs([iskonto]) iskonto,abs([nakliyat]) nakliyat,abs([iscilik]) iscilik,abs([GenelTop]) GenelTop,[fiiliSevkTarihi],[faturaNo],[belgeNo],[irsaliyeNo],[vergiDaire],[vergiNo],[adres],[faturaAciklamasi],[islemAciklamasi],[hesabaislendimi],[onay],[silindimi] FROM [sorTicaretAyrinti] where [ticaretAyrintiid] = " + ticaretAyrintiid + " and firmaid = " + firma.firmaid;
            //DataRow rw = veri.getdatarow(sql);

            islemler.yaziciislemleri.yaziciAyarla(cmbYazicilistesi.Text);
            string faturaTipi = "";
            if (cmbCiktituru.SelectedIndex == 0) faturaTipi = "ciktiFis";
            else if (cmbCiktituru.SelectedIndex == 1) faturaTipi = "faturaFis";
            else faturaTipi = (cmbCiktituru.SelectedIndex - 2).ToString();

            List<faturaYazdir.cT> _listT = new List<faturaYazdir.cT>();


            List<KeyValuePair<int, double>> listKeyValueKDVler = new List<KeyValuePair<int, double>>();

            for (int i = 0; i < dgTicaret.Rows.Count; i++)
            {
                DataGridViewRow r = dgTicaret.Rows[i];

                int kdv = Convert.ToInt16(r.Cells["kdv"].Value);
                double kdvToplam = Convert.ToDouble(r.Cells["TopKdv"].Value);

                listKeyValueKDVler.Add(new KeyValuePair<int, double>(kdv, kdvToplam));

                _listT.Add(new faturaYazdir.cT(r.Cells["barkod"].Value.ToString(), r.Cells["urunAdi"].Value.ToString(), Convert.ToDouble(r.Cells["miktar"].Value), kdv, r.Cells["kdvTipi"].Value.ToString(), r.Cells["birim"].Value.ToString(), Convert.ToDouble(r.Cells["birimFiyat"].Value), Convert.ToDouble(r.Cells["isk1"].Value), Convert.ToDouble(r.Cells["isk2"].Value), Convert.ToDouble(r.Cells["isk3"].Value), Convert.ToDouble(r.Cells["araTop"].Value), kdvToplam, Convert.ToDouble(r.Cells["tutar"].Value), r.Cells["dovizTuru"].Value.ToString()));
            }
            string saat = DateTime.Now.ToShortTimeString();
            //string EskiBakiye = String.Format("{0:n2}", Convert.ToDouble(veri.getdatacell("select sum(bakiye) from sorCariBakiye where firmaid = " + firma.firmaid + " and cariid = " + cariid + "")));
            faturaYazdir fYazdir = new faturaYazdir(faturaTipi, new faturaYazdir.cTA(ticaretAyrintiid, Convert.ToDouble(txtToplam.Text), Convert.ToDouble(txtKdvTop.Text), Convert.ToDouble(txtiskonto.Text), 0, 0, Convert.ToDouble(txtGenelTop.Text), tIskToplam, DateTime.Now, saat, _odemeTuru, _faturaBilgileri.faturaNo, _faturaBilgileri.faturaAciklamasi, listKeyValueKDVler),
                new faturaYazdir.cC("", "", "", "", "", 0, 0, miktarCarpani, duzenlemeBakiyesi), _listT);
            if (_islem == "onizle") fYazdir.onizle();
            else fYazdir.yazdir();
        }
        private void listeyiGrideUygula(string listeMetni)
        {
            for (int i = 0; i < chklistDatagrid.Items.Count; i++)
            {
                string harf = listeMetni[i].ToString();
                Boolean durum = Convert.ToBoolean(Convert.ToByte(harf));
                chklistDatagrid.SetItemChecked(i, durum);
                dgTicaret.Columns[i + 2].Visible = durum;
            }
        }

        void PesinSatisVitrinIslemleri()
        {
            try
            {
                tabControlVitrin.Controls.Clear();
                SqlDataReader dr = veri.getDatareader("select katNo,kategoriAdi,vitrin from sorKategori where firmaid = '" + firma.firmaid + "' and vitrin=1 order by kategoriAdi asc");
                while (dr.Read())
                {
                    try
                    {
                        listKategori.Add(dr["kategoriAdi"].ToString());
                        listKatNo.Add(dr["katNo"].ToString());

                    }
                    catch
                    {

                    }
                }
                DataTable dt = veri.getdatatable("Select * from tblStokkart where silindimi = '0' and vitrin = '1' and firmaid=" + firma.firmaid + " order by stokid asc");
                if (dt.Rows.Count == 0) return;
                if (listKategori != null)
                {
                    if (listKategori.Count > 0)
                    {
                        for (int i = 0; i < listKategori.Count; i++)
                        {
                            TabPage tabPage = new TabPage();
                            tabPage.Text = listKategori[i].ToUpper();
                            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                            flowLayoutPanel.BackColor = Color.LightSeaGreen;
                            flowLayoutPanel.Dock = DockStyle.Fill;
                            tabPage.Controls.Add(flowLayoutPanel);
                            tabControlVitrin.TabPages.Add(tabPage);
                            try
                            {
                                DataTable dtyolu = new DataTable();
                                DirectoryInfo file = new DirectoryInfo(Application.StartupPath + "\\vitrinresimleri");
                                int x = 10;
                                foreach (DataRow s1 in dt.Select("katNo = " + listKatNo[i] + ""))
                                {
                                    long stokid = Convert.ToInt64(s1["stokid"]);
                                    System.Windows.Forms.PictureBox pb = new System.Windows.Forms.PictureBox();
                                    this.Controls.Add(pb);
                                    pb.BackColor = Color.White;
                                    pb.Tag = stokid.ToString();
                                    string adi = "\n" + s1["urunAdi"].ToString();
                                    string adi1 = "";
                                    Bitmap bm = new Bitmap(80, 100);
                                    string[] parcalar;
                                    parcalar = adi.Split(' ');
                                    foreach (string s in parcalar)
                                    {
                                        adi1 += s + "\n";
                                    }
                                    using (Graphics g = Graphics.FromImage(bm))
                                    {
                                        foreach (FileInfo e2 in file.GetFiles())
                                        {
                                            if (e2.Name == stokid.ToString() + ".jpg")
                                            {
                                                pb.BackgroundImage = Image.FromFile(file + "\\" + e2.Name);
                                                adi = "";
                                                using (SolidBrush myBrush = new SolidBrush(Color.DarkRed))
                                                {
                                                    using (Font myFont = new Font("Microsoft Sans Serif", 10))
                                                    {
                                                        g.DrawString(adi, myFont, myBrush, 10, 10);
                                                        pb.Image = null;
                                                    }
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                using (SolidBrush myBrush = new SolidBrush(Color.Black))
                                                {
                                                    using (Font myFont = new Font("Verdava", 10, FontStyle.Regular))
                                                    {
                                                        g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                                        g.DrawString(adi1, myFont, myBrush, 1, 1);
                                                        pb.Image = bm;
                                                    }
                                                }
                                            }
                                        }

                                        if (file.GetFiles().Length == 0)
                                        {

                                            using (SolidBrush myBrush = new SolidBrush(Color.Black))
                                            {
                                                using (Font myFont = new Font("Verdava", 10, FontStyle.Regular))
                                                {
                                                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                                                    g.DrawString(adi1, myFont, myBrush, 1, 1);
                                                    pb.Image = bm;
                                                }
                                            }
                                        }

                                    }
                                    pb.Size = new Size(80, 80);
                                    pb.Location = new Point(x, 40);
                                    pb.Click += new EventHandler(pb_Click);
                                    pb.MouseMove += new MouseEventHandler(ImageMouseMove);
                                    flowLayoutPanel.Controls.Add(pb);
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }

                    }
                }
            }
            catch
            {

            }
            txtBarkod.Select();
        }
        private void ImageMouseMove(object sender, MouseEventArgs e)
        {
            //int say = 0;
            //System.Windows.Forms.PictureBox pic = ((System.Windows.Forms.PictureBox)sender);
            //System.Windows.Forms.Panel pnl = (System.Windows.Forms.Panel)pic.Parent;
            //int id = -1;
            //etiket:
            //if (id < 0 && say == 0)
            //{
            //    foreach (Control item in pnl.Controls)
            //    {
            //        if (item is System.Windows.Forms.PictureBox)
            //        {
            //            System.Windows.Forms.PictureBox test = (System.Windows.Forms.PictureBox)item;
            //            if (!string.IsNullOrEmpty(test.Tag.ToString()))
            //                id = Convert.ToInt32(test.Tag.ToString());
            //            if (id > 0) // item is Label bloğuna tekrar tekrar girmemesi için kullanıldı
            //            {
            //                //var frm = new FrmCariEkle(OrtakID(pic.Tag.ToString(), 0).ToInt32(), id); *** Programın en az 15 saniye geç cevap vermesine neden oluyor 
            //                urunBilgisi = stokkart.bul_stokid(Convert.ToInt32(pic.Tag)); // Üsteki kod parçasından daha erken cevap veriyor                          
            //                try
            //                {
            //                    toolTip1.SetToolTip(pic, urunBilgisi.urunAdi);
            //                    toolTip1.ToolTipIcon = ToolTipIcon.None;
            //                    toolTip1.IsBalloon = true;
            //                    say = 1;
            //                    break;
            //                }
            //                catch (Exception)
            //                {
            //                }
            //                goto etiket; //Tekrar foreach e girmemesi için kullanılıdı.                       
            //            }
            //        }
            //        break;
            //    }
            //}

        }
        int OrtakID(string Toplam, int VirgulSıra)
        {
            int ID = 0, baslangicdeger = 0, gelen = 0;

            for (int i = 0; i < Toplam.Length; i++)
            {
                if (Toplam.Substring(i, 1).ToString() == ",")
                {
                    if (gelen == VirgulSıra)
                    {
                        ID = Convert.ToInt32(Toplam.Substring(baslangicdeger, i - baslangicdeger).Trim());
                    }
                    gelen += 1;

                    baslangicdeger = i + 1;

                }

            }
            return ID;
        }
        private void pb_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PictureBox pic = ((System.Windows.Forms.PictureBox)sender);
            System.Windows.Forms.Panel pnl = (System.Windows.Forms.Panel)pic.Parent;
            int id = -1;

            foreach (Control item in pnl.Controls)
            {
                if (item is System.Windows.Forms.PictureBox)
                {
                    System.Windows.Forms.PictureBox test = (System.Windows.Forms.PictureBox)item;

                    if (!string.IsNullOrEmpty(test.Text) &&
                       !string.IsNullOrEmpty(test.Tag.ToString())) id = int.Parse(test.Tag.ToString());
                }
            }
            long id1 = Convert.ToInt64(pic.Tag);
            urunBilgisi = stokkart.bul_stokid(id1);
            urunuDataGrideEkle(urunBilgisi.stokid, "", "1");
        }
        private void EkranAyari()
        {
            splitContainer1.SplitterDistance = Properties.Settings.Default["SplitterDistance"] == null ? 722 : Convert.ToInt32(Properties.Settings.Default["SplitterDistance"].ToString());
        }

        void display()
        {
            string sayi = txtGenelTop.Text.Replace(".", ",");
            float deger = float.Parse(sayi);
            string yazi = EkranIcinCevir(deger);
            try
            {
                sp1.Open();
                sp1.Write(yazi);
                sp1.Close();
            }
            catch
            {
            }
        }
        private string EkranIcinCevir(float deger)
        {
            string sonuc = string.Empty;
            string strDeger = String.Format("{0:0.00}", deger).Replace(",", ".");

            // Ekran Ayarlari
            int karakterSayi = 8;

            #region Ekran Yazisi Belirle

            for (int i = 0; i < karakterSayi; i++)
            {
                sonuc += "-";
            }

            #endregion

            int degerSayUzunluk = strDeger.Replace(".", "").Length;
            sonuc = sonuc.Remove(sonuc.Length - degerSayUzunluk);
            sonuc = sonuc + strDeger;
            sonuc = sonuc.Replace("-", " ");

            return sonuc;
        }
        #endregion

        #region Hesaplamaları Yap
        void hesaplariYap()
        {
            try
            {
                //satılan her ürün için miktar*katsayı*birimF*dovizKuru-iskonto+kdv işlemini yapar
                //if (dgTicaret.CurrentRow.Cells["miktar"].Value.ToString() == "") dgTicaret.CurrentRow.Cells["miktar"].Value = "0";
                //if (dgTicaret.CurrentRow.Cells["birimFiyat"].Value.ToString() == "") dgTicaret.CurrentRow.Cells["birimFiyat"].Value = "0";
                if (dgTicaret.CurrentRow.Cells["katsayi"].Value == null) dgTicaret.CurrentRow.Cells["katsayi"].Value = "1";
                double _AraTop = Convert.ToDouble(dgTicaret.CurrentRow.Cells["miktar"].Value) * Convert.ToDouble(dgTicaret.CurrentRow.Cells["birimFiyat"].Value) * Convert.ToDouble(dgTicaret.CurrentRow.Cells["katsayi"].Value);
                dgTicaret.CurrentRow.Cells["TOPISK"].Value = _AraTop;

                double gecici_aratoplam = 0;
                double gecici_kdvtoplam = 0;
                DataGridViewComboBoxCell kolon2;
                kolon2 = (DataGridViewComboBoxCell)dgTicaret.CurrentRow.Cells["kdvTipi"];
                if (kolon2.Value.ToString() == "Dahil")
                {

                    /*
                        tempSubTotal = subTotal / (1 + kdv / 100);
                        iskTotal = tempSubTotal;
                        tempSubTotal -= tempSubTotal * isk1 / 100;
                        tempSubTotal -= tempSubTotal * isk2 / 100;
                        tempSubTotal -= tempSubTotal * isk3 / 100;

                        iskTotal -= tempSubTotal;
                        gridView1.SetFocusedRowCellValue(gridColumnDiscountTotal, iskTotal);

                        tempKdvTotal = (tempSubTotal * (1 + kdv / 100)) - tempSubTotal;
                     */
                    double kdv = Convert.ToDouble(dgTicaret.CurrentRow.Cells["kdv"].Value);
                    gecici_aratoplam = _AraTop / (1 + kdv / 100);
                    dgTicaret.CurrentRow.Cells["TOPISK"].Value = gecici_aratoplam;
                    gecici_aratoplam = gecici_aratoplam - gecici_aratoplam * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk1"].Value) / 100;
                    gecici_aratoplam = gecici_aratoplam - gecici_aratoplam * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk2"].Value) / 100;
                    gecici_aratoplam = gecici_aratoplam - gecici_aratoplam * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk3"].Value) / 100;
                    dgTicaret.CurrentRow.Cells["TOPISK"].Value = Convert.ToDouble(dgTicaret.CurrentRow.Cells["TOPISK"].Value) - gecici_aratoplam;
                    gecici_kdvtoplam = gecici_aratoplam * (1 + kdv / 100) - gecici_aratoplam;
                }
                else
                {
                    _AraTop = _AraTop - _AraTop * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk1"].Value) / 100;
                    _AraTop = _AraTop - _AraTop * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk2"].Value) / 100;
                    _AraTop = _AraTop - _AraTop * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk3"].Value) / 100;
                    dgTicaret.CurrentRow.Cells["TOPISK"].Value = Convert.ToDouble(dgTicaret.CurrentRow.Cells["TOPISK"].Value) - _AraTop;
                    gecici_aratoplam = _AraTop;
                    gecici_kdvtoplam = (_AraTop * (1 + Convert.ToDouble(dgTicaret.CurrentRow.Cells["kdv"].Value) / 100)) - _AraTop;
                }
                dgTicaret.CurrentRow.Cells["TopKdv"].Value = gecici_kdvtoplam.ToString();
                dgTicaret.CurrentRow.Cells["AraTop"].Value = gecici_aratoplam.ToString();
                dgTicaret.CurrentRow.Cells["Tutar"].Value = gecici_aratoplam + gecici_kdvtoplam;
                ana_toplamlari_hesaplat();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Metni:" + hata.Message, firma.programAdi);
            }
        }
        private void ana_toplamlari_hesaplat()
        {
            try
            {
                if (txtiskonto.Text == "İSK") tIskonto_F = "0";
                tIskonto_F = txtiskonto.Text;
                tAraToplam = 0;
                tKdvtutar = 0;
                tGenelToplam = 0;
                tIskToplam = 0;
                for (int j = 0; j < dgTicaret.Rows.Count; j++)
                {
                    double pb = 1;
                    if (dgTicaret.Rows[j].Cells["dovizTuru"].Value.ToString() == "USD") pb = bilgiler.dovizVerileri.dDolarsatis;
                    else if (dgTicaret.Rows[j].Cells["dovizTuru"].Value.ToString() == "Euro") pb = bilgiler.dovizVerileri.dEurosatis;
                    tAraToplam = tAraToplam + Convert.ToDouble(dgTicaret.Rows[j].Cells["AraTop"].Value) * pb;
                    tKdvtutar = tKdvtutar + Convert.ToDouble(dgTicaret.Rows[j].Cells["TopKDV"].Value) * pb;
                    //tAraToplam = tAraToplam + Convert.ToDouble(dgTicaret.Rows[j].Cells["AraTop"].Value) * pb;
                    tIskToplam = tIskToplam + Convert.ToDouble(dgTicaret.Rows[j].Cells["TOPISK"].Value) * pb;
                }

                tAraToplam_F = tAraToplam.ToString();
                tKdvtutar_F = tKdvtutar.ToString();
                tGenelToplam_F = (tAraToplam + tKdvtutar - tIskonto + tNakliyat + tIscilik).ToString();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Button Clickleri
        private void btniptal_Click(object sender, EventArgs e)
        {
            formTemizle();
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
            if (tbAyarlar.Visible == true)
                tbAyarlar.Visible = false;
            else tbAyarlar.Visible = true;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = (System.Windows.Forms.Button)sender;
            toplam += Convert.ToInt32(((System.Windows.Forms.Button)sender).Tag);
            txtNakit1.Text = toplam.ToString();
            //b.Click += new EventHandler(Tikla);
        }

        private void btnPos_Click(object sender, EventArgs e)
        {
            if (odemeislemiBaslangici("Pos") == false) return;
            string islemTuru2 = "";
            if (islemTuru.Contains("Alış"))
            {
                MessageBox.Show("Pos ile alış işlemi yapılamaz.", firma.programAdi);
            }
            else if (islemTuru.Contains("Satış"))
            {
                islemTuru2 = "Satış";

            }
            frmBankaPosTaksitleriGoruntule frm = new frmBankaPosTaksitleriGoruntule(cariid, "", txtGenelTop.Text, islemTuru2, DateTime.Now, grupid, ticaretAyrintiid, "Pos ile Satış");
            frm._frmPesinSatis = this;
            frm.Show();
        }
        #endregion

        #region DataGridView Olayları
        private void chklistDatagrid_MouseUp(object sender, MouseEventArgs e)
        {
            string listeMetni = "";
            for (int i = 0; i < chklistDatagrid.Items.Count; i++)
            {
                if (Convert.ToBoolean(chklistDatagrid.GetItemCheckState(i)))
                    listeMetni = listeMetni + "1";
                else
                    listeMetni = listeMetni + "0";
            }
            listeyiGrideUygula(listeMetni);
            try
            {
                //Kaydediliyor
                if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Liste", listeMetni);
                else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Liste", listeMetni);
                else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Liste", listeMetni);
                else if (this.islemTuru == "Satış İade") ayarlar.ayarla_manuel("İade_Satış_Liste", listeMetni);
                else if (this.islemTuru == "Faturasız Alış") ayarlar.ayarla_manuel("Faturasız_Alış_Liste", listeMetni);
                else if (this.islemTuru == "Faturalı Alış") ayarlar.ayarla_manuel("Faturalı_Alış_Liste", listeMetni);
                else if (this.islemTuru == "Alış İade") ayarlar.ayarla_manuel("İade_Alış_Liste", listeMetni);
                else if (this.islemTuru == "Sipariş") ayarlar.ayarla_manuel("Sipariş_Liste", listeMetni);
                else if (this.islemTuru == "Teklif") ayarlar.ayarla_manuel("Teklif_Liste", listeMetni);
            }
            catch (Exception)
            {
            }
        }

        private void dgTicaret_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgTicaret.Columns["isk1"].Index || e.ColumnIndex == dgTicaret.Columns["isk2"].Index || e.ColumnIndex == dgTicaret.Columns["isk3"].Index || e.ColumnIndex == dgTicaret.Columns["AraTop"].Index || e.ColumnIndex == dgTicaret.Columns["TopKDV"].Index || e.ColumnIndex == dgTicaret.Columns["Tutar"].Index) dgTicaret.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:n2}", Math.Round(Convert.ToDouble(dgTicaret.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), 2));
                else if (e.ColumnIndex == dgTicaret.Columns["dovizDegeri"].Index || e.ColumnIndex == dgTicaret.Columns["birimFiyat"].Index) dgTicaret.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:n2}", Convert.ToDouble(dgTicaret.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
            }
            catch (Exception)
            {
                if (e.RowIndex > -1) dgTicaret.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
            }
        }

        private void dgTicaret_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //döviz
            DataGridViewComboBoxCell kolon;
            kolon = (DataGridViewComboBoxCell)dgTicaret.CurrentRow.Cells["dovizTuru"];
            if (kolon.Value.ToString() == "TL") dgTicaret.CurrentRow.Cells["dovizDegeri"].Value = 1;
            else if (kolon.Value.ToString() == "USD") dgTicaret.CurrentRow.Cells["dovizDegeri"].Value = bilgiler.dovizVerileri.dDolarsatis.ToString();
            else if (kolon.Value.ToString() == "ANZ") dgTicaret.CurrentRow.Cells["dovizDegeri"].Value = 1;
            else if (kolon.Value.ToString() == "Euro") dgTicaret.CurrentRow.Cells["dovizDegeri"].Value = bilgiler.dovizVerileri.dEurosatis.ToString();
            try
            {
                //birim
                kolon = (DataGridViewComboBoxCell)dgTicaret.CurrentRow.Cells["birim"];
                dgTicaret.CurrentRow.Cells["katsayi"].Value = stokkart.birimler.bul_stokid(Convert.ToInt64(dgTicaret.CurrentRow.Cells["stokid"].Value)).Where(u => u.birimAdi == kolon.Value.ToString()).First().katsayi.ToString();
            }
            catch (Exception)
            {
            }
            hesaplariYap();
            txtBarkod.Select();
        }
        #endregion

        #region txt ve ToolStrip Olayları
        private void frmPesinSatis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4) btnPesinSatis_Click(sender, e);

            else if (e.KeyCode == Keys.F8) btnPos_Click(sender, e);

            else if (e.KeyCode == Keys.F10)
            {
                //double mik = Convert.ToDouble(dgTicaret.CurrentRow.Cells["miktar"].Value);
                dgTicaret.CurrentRow.Cells["miktar"].Selected = true;
                dgTicaret.BeginEdit(true);
                dgTicaret.CurrentRow.Cells["miktar"].Selected = true;
                dgTicaret.BeginEdit(true);
                dgTicaret.Refresh();

                //SendKeys.Send("{backspace}");
                //dgTicaret.CurrentRow.Cells["miktar"].Value = mik;
            }
            else if (e.KeyCode == Keys.F7) seçiliSatırıSilToolStripMenuItem_Click(sender, e);

            else if (e.KeyCode == Keys.F9) btniptal_Click(sender, e);

            else if (e.KeyCode == Keys.Escape) txtBarkod.Select();

            else if (e.KeyCode == Keys.F6)
            {
                txtNakit1.Select();
                txtNakit1.Text = "0";
            }
            else if (e.KeyCode == Keys.F1) btnAyar_Click(sender, e);

        }
        private void urunAlisFiyatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgTicaret.CurrentRow.Cells["stokid"].Value == null)
            {
                MessageBox.Show("Ürün Seçin");
                return;
            }
            long stokID = Convert.ToInt64(dgTicaret.CurrentRow.Cells["stokid"].Value);
            string sql = "select alisFiyat From tblStokKart where stokid=" + stokID;
            double fiyat = Convert.ToDouble(veri.getdatacell(sql));
            MessageBox.Show("Ürünün Alış Fiyatı: " + fiyat.ToString());
        }
        private void urunAlimFiyatlariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgTicaret.CurrentRow.Cells["stokid"].Value == null)
            {
                MessageBox.Show("Ürün Seçin");
                return;
            }

            long stokID = Convert.ToInt64(dgTicaret.CurrentRow.Cells["stokid"].Value);

            frmUrunAlimFiyatlari frm = new frmUrunAlimFiyatlari(cariid, stokID);
            frm.ShowDialog();
        }
        private void chkOtoYazdir_Click(object sender, EventArgs e)
        {
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Oto_Yazdır", Convert.ToByte(chkOtoYazdir.Checked).ToString());
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Oto_Yazdır", Convert.ToByte(chkOtoYazdir.Checked).ToString());
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Oto_Yazdır", Convert.ToByte(chkOtoYazdir.Checked).ToString());
            else if (this.islemTuru == "Satış İade") ayarlar.ayarla_manuel("İade_Satış_Oto_Yazdır", Convert.ToByte(chkOtoYazdir.Checked).ToString());
            else if (this.islemTuru == "Faturasız Alış") ayarlar.ayarla_manuel("Faturasız_Alış_Oto_Yazdır", Convert.ToByte(chkOtoYazdir.Checked).ToString());
            else if (this.islemTuru == "Faturalı Alış") ayarlar.ayarla_manuel("Faturalı_Alış_Oto_Yazdır", Convert.ToByte(chkOtoYazdir.Checked).ToString());
            else if (this.islemTuru == "Alış İade") ayarlar.ayarla_manuel("İade_Alış_Oto_Yazdır", Convert.ToByte(chkOtoYazdir.Checked).ToString());

        }
        private void chkMiktarOtomatik_Click(object sender, EventArgs e)
        {
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Miktar_Otomatik", Convert.ToByte(chkMiktarOtomatik.Checked).ToString());
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Satış_Miktar_Otomatik", Convert.ToByte(chkMiktarOtomatik.Checked).ToString());
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Miktar_Otomatik", Convert.ToByte(chkMiktarOtomatik.Checked).ToString());
            else if (this.islemTuru == "Satış İade") ayarlar.ayarla_manuel("İade_Satış_Miktar_Otomatik", Convert.ToByte(chkMiktarOtomatik.Checked).ToString());
            else if (this.islemTuru == "Faturasız Alış") ayarlar.ayarla_manuel("Faturasız_Alış_Miktar_Otomatik", Convert.ToByte(chkMiktarOtomatik.Checked).ToString());
            else if (this.islemTuru == "Faturalı Alış") ayarlar.ayarla_manuel("Faturalı_Alış_Miktar_Otomatik", Convert.ToByte(chkMiktarOtomatik.Checked).ToString());
            else if (this.islemTuru == "Alış İade") ayarlar.ayarla_manuel("İade_Alış_Miktar_Otomatik", Convert.ToByte(chkMiktarOtomatik.Checked).ToString());

        }
        private void rdStokKontrolleriYapilmasin_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton sndr = (System.Windows.Forms.RadioButton)sender;
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Stok_Kontrolleri_Tipi", sndr.Tag.ToString());
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Stok_Kontrolleri_Tipi", sndr.Tag.ToString());
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Stok_Kontrol_Tipi", sndr.Tag.ToString());
        }
        private void cmbUrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                urunBilgisi = stokkart.listStokkart.Where(u => u.urunAdi.ToUpper() == cmbUrunAdi.Text.ToUpper()).OrderBy(u => u.silindimi).First();
                if (urunBilgisi.silindimi == "1")
                {
                    MessageBox.Show("Bu stok kartı silinmiş.", firma.programAdi);
                    return;
                }
                else if (urunBilgisi.aktifmi == "0")
                {
                    MessageBox.Show("Bu stok kartı devre dışı bırakılmış.", firma.programAdi);
                    return;
                }
                urunuDataGrideEkle(urunBilgisi.stokid, "", "1");
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Bir hata oluştu. Hata Metni: "+hata.Message);
                if (MessageBox.Show("Ürün bulunamadı. Eklemek ister misiniz?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmStokKartEkle frm = new frmStokKartEkle();
                    frm.Show();
                }
            }
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnPesinSatis.PerformClick();
            }
            else if (e.KeyCode == Keys.F7) seçiliSatırıSilToolStripMenuItem_Click(sender, e);

            Control sndr = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                string[] barkod = null;
                if (txtBarkod.Text.Contains("*") && txtBarkod.Text.Length < 6)
                {
                    barkod = txtBarkod.Text.Split('*');
                }
                else
                {
                    if (txtBarkod.Text.Contains("*"))
                        txtBarkod.Text = txtBarkod.Text.Replace("*", "");
                    txtBarkod.Text = txtBarkod.Text + "*" + "1";
                    barkod = txtBarkod.Text.Split('*');
                }

                if (barkod[0].Length > 16) barkod[0] = barkod[0].Substring(3, 13);
                if (sndr.Name == "txtBarkod") urunBilgisi = stokkart.bul_barkod(barkod[0].ToString());
                else if (sndr.Name == "cmbUrunAdi") urunBilgisi = stokkart.bul_urunAdi(cmbUrunAdi.Text);
                try
                {
                    if (urunBilgisi.silindimi == "1")
                    {
                        MessageBox.Show("Böyle bir stok kartı bulunamadı.", firma.programAdi);
                        return;
                    }
                    else if (urunBilgisi.aktifmi == "0")
                    {
                        MessageBox.Show("Bu stok kartı devre dışı bırakılmış satılamaz.", firma.programAdi);
                        return;
                    }

                    if (sndr.Name != "txtBarkod") txtBarkod.Text = "";
                    urunuDataGrideEkle(urunBilgisi.stokid, txtBarkod.Text, barkod[1]);
                }
                catch (Exception hata)
                {
                    txtBarkod.Text = txtBarkod.Text.Substring(0, 13);
                    if (txtBarkod.Text.StartsWith("27"))
                    {
                        urunBilgisi = stokkart.bul_stokkodu((txtBarkod.Text.Substring(2, 5)));
                        if (urunBilgisi != null)
                        {
                            string _miktar = (Convert.ToDouble(txtBarkod.Text.Substring(7, 6)) / 10000).ToString();
                            urunuDataGrideEkle(urunBilgisi.stokid, txtBarkod.Text, _miktar);
                        }
                        else
                        {
                            urunBilgisi = stokkart.bul_stokid(Convert.ToInt64((txtBarkod.Text.Substring(2, 5))));
                            string _miktar = (Convert.ToDouble(txtBarkod.Text.Substring(7, 6)) / 10000).ToString();
                            urunuDataGrideEkle(urunBilgisi.stokid, txtBarkod.Text, _miktar);
                        }

                    }
                    else if (txtBarkod.Text.StartsWith("28") || txtBarkod.Text.StartsWith("21") || txtBarkod.Text.StartsWith("24"))
                    {
                        urunBilgisi = stokkart.bul_barkod((txtBarkod.Text.Substring(0, 7)));
                        if (urunBilgisi != null)
                        {
                            string _miktar = (Convert.ToDouble(txtBarkod.Text.Substring(7, 6)) / 10000).ToString();
                            urunuDataGrideEkle(urunBilgisi.stokid, txtBarkod.Text, _miktar);
                        }
                    }
                    else if (MessageBox.Show("Ürün bulunamadı. Eklemek ister misiniz?", firma.programAdi,
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                             System.Windows.Forms.DialogResult.Yes)
                    {
                        frmStokKartEkle frm = new frmStokKartEkle();
                        frm.Show();
                    }
                }
            }
        }

        private void cmbGecerliSatisFiyati_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Satış_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            else if (this.islemTuru == "Satış İade") ayarlar.ayarla_manuel("İade_Satış_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            else if (this.islemTuru == "Teklif") ayarlar.ayarla_manuel("Teklif_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            gecerliFiyatid = listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex];
        }
        private void txtNakit1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNakit2.Text = String.Format("{0:n2}",
                Convert.ToDouble(txtNakit1.Text) - Convert.ToDouble(txtGenelTop.Text));
            }
            catch (Exception)
            {
            }
        }
        private void txtGenelTop_TextChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                display();
            }
        }
        private void seçiliSatırıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("Update tblTicaret set silindimi = '1' where firmaid = " + firma.firmaid + " and ticaretid = " + dgTicaret.CurrentRow.Cells["ticaretid"].Value.ToString() + "");
                string urunAdi = dgTicaret.CurrentRow.Cells["urunAdi"].Value.ToString();
                string barkod = dgTicaret.CurrentRow.Cells["barkod"].Value.ToString();
                string miktar = dgTicaret.CurrentRow.Cells["miktar"].Value.ToString();
                double fiyat = Convert.ToDouble(dgTicaret.CurrentRow.Cells["birimFiyat"].Value);
                double araTop = Convert.ToDouble(dgTicaret.CurrentRow.Cells["AraTop"].Value);
                double toplam = Convert.ToDouble(dgTicaret.CurrentRow.Cells["Tutar"].Value);
                string cari = "";
                string islemTuru = this.islemTuru.ToString();
                dgTicaret.Rows.Remove(dgTicaret.CurrentRow);
                veri.cmd(@"INSERT INTO [dbo].[tblSilinenSatislar] ([Barkod] ,[UrunAdi] ,[Miktar],[Fiyat],[AraTop],[Toplam],[Cari],[IslemTuru],[FirmaID] ,[SubeID],[KullaniciID]) values ('" + barkod + "','" + urunAdi + "','" + miktar.Replace(",", ".") + "'," + fiyat.ToString().Replace(",", ".") + "," + araTop.ToString().Replace(",", ".") + "," + toplam.ToString().Replace(",", ".") + ",'" + cari + "','" + islemTuru + "', " + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                ana_toplamlari_hesaplat();
            }
            catch
            {
            }
        }
        private void stokKartTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStokKartEkle frm = new frmStokKartEkle();
            frm.Show();
        }
        private void ayrıntılıStokKartTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYeniAyrintiliStokkartEkle frm = new frmYeniAyrintiliStokkartEkle();
            frm.Show();
        }
        private void txtiskonto_Leave(object sender, EventArgs e)
        {
            if (txtiskonto.Text == "0,00")
            {
                txtiskonto.Text = "İSK";
                txtiskonto.ForeColor = Color.Gray;
            }
            txtiskonto.ForeColor = Color.Black;
            ana_toplamlari_hesaplat();
            if (txtiskonto.Text == "0,00")
            {
                txtiskonto.Text = "İSK";
                txtiskonto.ForeColor = Color.Gray;
            }
        }

        //private void txtiskonto_TextChanged(object sender, EventArgs e)
        //{
        //   // ana_toplamlari_hesaplat();
        //}
        private void txtNakit1_Enter(object sender, EventArgs e)
        {
            if (txtNakit1.Text == "V.P.")
            {
                txtNakit1.Text = "";
                txtNakit1.ForeColor = Color.Black;
            }
        }
        private void txtNakit1_Leave(object sender, EventArgs e)
        {
            if (txtNakit1.Text == "")
            {
                txtNakit1.Text = "V.P.";
                txtNakit1.ForeColor = Color.Gray;
            }

        }
        private void txtNakit2_Enter(object sender, EventArgs e)
        {
            if (txtNakit2.Text == "P.Ü.")
            {
                txtNakit2.Text = "";
                txtNakit2.ForeColor = Color.Black;
            }
            txtNakit2.ForeColor = Color.Black;
        }
        private void txtNakit2_Leave(object sender, EventArgs e)
        {
            if (txtNakit2.Text == "")
            {
                txtNakit2.Text = "P.Ü.";
                txtNakit2.ForeColor = Color.Gray;
            }

        }
        private void txtiskonto_Enter(object sender, EventArgs e)
        {
            if (txtiskonto.Text == "İSK")
            {
                txtiskonto.Text = "";
                txtiskonto.ForeColor = Color.Black;
            }

        }
        #endregion

        private void frmPesinSatis_Load(object sender, EventArgs e)
        {
            #region Size kontrolleri

            //frmPesinSatisOrjinal = this.Size;
            //btnPesinOrjinal = new Rectangle(btnPesinSatis.Location.X, btnPesinSatis.Location.Y, btnPesinSatis.Width, btnPesinSatis.Height);
            //btnPosOrjinal = new Rectangle(btnPos.Location.X, btnPos.Location.Y, btnPos.Width, btnPos.Height);
            //btnIptalOrjinal = new Rectangle(btniptal.Location.X, btniptal.Location.Y, btniptal.Width, btniptal.Height);
            //btnAyarOrjinal = new Rectangle(btnAyar.Location.X, btnAyar.Location.Y, btnAyar.Width, btnAyar.Height);
            //btn5Orjinal = new Rectangle(btn5.Location.X, btn5.Location.Y, btn5.Width, btn5.Height);
            //btn10Orjinal = new Rectangle(btn10.Location.X, btn10.Location.Y, btn10.Width, btn10.Height);
            //btn20Orjinal = new Rectangle(btn20.Location.X, btn20.Location.Y, btn20.Width, btn20.Height);
            //btn50Orjinal = new Rectangle(btn50.Location.X, btn50.Location.Y, btn50.Width, btn50.Height);
            //btn100Orjinal = new Rectangle(btn100.Location.X, btn100.Location.Y, btn100.Width, btn100.Height);
            //btn200Orjinal = new Rectangle(btn200.Location.X, btn200.Location.Y, btn200.Width, btn200.Height);

            //txtAlinanOrjinal = new Rectangle(txtNakit1.Location.X, txtNakit1.Location.Y, txtNakit1.Width, txtNakit1.Height);
            //txtParaUstuOrjinal = new Rectangle(txtNakit2.Location.X, txtNakit2.Location.Y, txtNakit2.Width, txtNakit2.Height);
            //txtIndirimOrjinal = new Rectangle(txtiskonto.Location.X, txtiskonto.Location.Y, txtiskonto.Width, txtiskonto.Height);
            //txtGenelToplamOrjinal = new Rectangle(txtGenelTop.Location.X, txtGenelTop.Location.Y, txtGenelTop.Width, txtGenelTop.Height);
            #endregion
            try
            {
                cmbUrunAdi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbUrunAdi.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.Text = "Peşin Satış";
                islemTuru = "Faturasız Satış";
                this.dgTicaret.Columns["AraTop"].DefaultCellStyle.Format = "n";
                this.dgTicaret.Columns["TopKDV"].DefaultCellStyle.Format = "n";
                this.dgTicaret.Columns["Tutar"].DefaultCellStyle.Format = "n";
                urunAdiListesiniYenile();
                yaziciListele();
                portListele();
                satisFiyatiListele();
                btniptal.PerformClick();
                ayarlariGetir();
                sp1.PortName = displaycom;
                teraziAdi = cmbTeraziAdi.SelectedIndex;
                terazicom = cmbPort.Text;
                sp3.PortName = cmbPort.Text;
                sp1.BaudRate = 2400;
                sp3.BaudRate = 9600;
                sp3.Open();
                sp3.Write("Off");
                sp3.Close();
            }
            catch
            {
            }
            this.dgTicaret.Columns["AraTop"].DefaultCellStyle.Format = "n";
            this.dgTicaret.Columns["TopKDV"].DefaultCellStyle.Format = "n";
            this.dgTicaret.Columns["Tutar"].DefaultCellStyle.Format = "n";
            urunAdiListesiniYenile();
            satisFiyatiListele();
            EkranAyari();

            txtNakit1.Text = "V.P";
            this.txtNakit1.Leave += new System.EventHandler(this.txtNakit1_Leave);
            this.txtNakit1.Enter += new System.EventHandler(this.txtNakit1_Enter);
            txtNakit1.ForeColor = Color.Gray;

            txtNakit2.Text = "P.Ü";
            this.txtNakit2.Leave += new System.EventHandler(this.txtNakit2_Leave);
            this.txtNakit2.Enter += new System.EventHandler(this.txtNakit2_Enter);
            txtNakit2.ForeColor = Color.Gray;

            txtiskonto.Text = "İSK";
            this.txtiskonto.Leave += new System.EventHandler(this.txtiskonto_Leave);
            this.txtiskonto.Enter += new System.EventHandler(this.txtiskonto_Enter);
            txtiskonto.ForeColor = Color.Gray;
            PesinSatisVitrinIslemleri();
            DataTable dt = veri.getdatatable("Select fiyatid, fiyatAdi From tblFiyatTaslak Where fiyatid = " + gecerliFiyatid + " and silindimi = '0'");
            cmbGecerliSatisFiyati.Text = dt.Rows[0]["fiyatAdi"].ToString();
        }
        private void resizeChildrenControl()
        {
            #region
            // resizeControl(btnPesinOrjinal, btnPesinSatis);
            //resizeControl(btnPosOrjinal, btnPos);
            //resizeControl(btnAyarOrjinal, btnAyar);
            //resizeControl(btnIptalOrjinal, btniptal);
            //resizeControl(btn5Orjinal, btn5);
            //resizeControl(btn10Orjinal, btn10);
            //resizeControl(btn20Orjinal, btn20);
            //resizeControl(btn50Orjinal, btn50);
            //resizeControl(btn100Orjinal, btn100);
            //resizeControl(btn200Orjinal, btn200);

            //resizeControl(txtAlinanOrjinal, txtNakit1);
            //resizeControl(txtParaUstuOrjinal, txtNakit2);
            //resizeControl(txtIndirimOrjinal, txtiskonto);
            //resizeControl(txtGenelToplamOrjinal, txtGenelTop);
            #endregion
        }
        private void frmPesinSatis_Resize(object sender, EventArgs e)
        {
            //resizeChildrenControl();
        }
        private void resizeControl(Rectangle orjinalControlRect, Control control)
        {
            #region
            //float xRation = (float)(this.Width) / (float)(frmPesinSatisOrjinal.Width);
            //float yRation = (float)(this.Height) / (float)(frmPesinSatisOrjinal.Height);
            //int newX = (int)(orjinalControlRect.X * xRation);
            //int newY = (int)(orjinalControlRect.Y * yRation);
            //int newWidth = (int)(orjinalControlRect.Width * xRation);
            //int newHeigth = (int)(orjinalControlRect.Height * yRation);
            //control.Location = new Point(newX, newY);
            //control.Size = new Size(newWidth, newHeigth);
            #endregion
        }
        private void btnPesinSatis_Click(object sender, EventArgs e)
        {
            if (odemeislemiBaslangici("Peşin"))
            {
                pesinislem("Peşin");
                yeniKayit();
            }
        }
        public void pesinislem(string islemTuru)
        {
            string txtKullaniciAciklamasi = "";
            string islemTuru1 = islemTuru, islemTuru2 = "";
            string yeri = "Kasa";
            if (islemTuru1.Contains("Postan") || islemTuru1.Contains("Kredi Kartı")) yeri = "Banka";
            //Peşin Satış ve Alış Aktarılıyor
            double alacak = Convert.ToDouble(txtGenelTop.Text), borc = Convert.ToDouble(txtGenelTop.Text);
            if (this.islemTuru.Contains("Satış"))
            {
                alacak = Convert.ToDouble(txtGenelTop.Text);
                islemTuru2 = "Satış";
                if (islemTuru.Contains("İade"))
                {
                    islemTuru2 = "Satış İade";
                    if (islemTuru == "Açık Hesap İade")
                    {
                        islemTuru1 = "Açık Hesap";
                        borc = alacak;
                        alacak = 0;
                    }
                    else islemTuru1 = "Peşin";
                }
                txtKullaniciAciklamasi = islemTuru + " Tahsilat";
            }
            acikHesap.ekle(0, ticaretAyrintiid, 0, 0, 0, cariid, DateTime.Now, DateTime.Now, Convert.ToDateTime(null), borc, alacak, "TL", 1, 0, islemTuru1, islemTuru2, yeri, txtKullaniciAciklamasi, _faturaBilgileri.faturaNo, _faturaBilgileri.belgeNo, _faturaBilgileri.irsaliyeNo, "", "", _hesabaislendimi, "0", firma.subeid, firma.kullaniciid, grupid, duzenlemeBakiyesi);
            ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
        }
        private void dgTicaret_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ayarlar.ayarla_manuel("Auto Terazi", Convert.ToByte(checkBox1.Checked).ToString());
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ayarlar.ayarla_manuel("Display", Convert.ToByte(checkBox2.Checked).ToString());
        }
        private void btnOnizleme_Click(object sender, EventArgs e)
        {
            yazdirVeonizle("onizle", "Peşin");
        }
        private void pbHesap_Click(object sender, EventArgs e)
        {
            if (pnlHesap.Visible == true)
                pnlHesap.Visible = false;
            else pnlHesap.Visible = true;
        }
        string tp = "";
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                tp += (((System.Windows.Forms.Button)sender).Text);
                dgTicaret.CurrentRow.Cells["miktar"].Value = tp;
            }
            catch
            {
            }

        }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {
                tp = "";
                hesaplariYap();
                txtBarkod.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu\n" + ex.Message);
            }

        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                string a = dgTicaret.CurrentRow.Cells["miktar"].Value.ToString();
                dgTicaret.CurrentRow.Cells["miktar"].Value = a.Substring(0, a.Length - 1);
                tp = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu\n" + ex.Message);
            }

        }
        private void cmbCiktituru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Kağıt_Tipi", cmbCiktituru.Text);
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Kağıt_Tipi", cmbCiktituru.Text);
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Kağıt_Tipi", cmbCiktituru.Text);
            else if (this.islemTuru == "Satış İade") ayarlar.ayarla_manuel("İade_Satış_Kağıt_Tipi", cmbCiktituru.Text);
            else if (this.islemTuru == "Faturasız Alış") ayarlar.ayarla_manuel("Faturasız_Alış_Kağıt_Tipi", cmbCiktituru.Text);
            else if (this.islemTuru == "Faturalı Alış") ayarlar.ayarla_manuel("Faturalı_Alış_Kağıt_Tipi", cmbCiktituru.Text);
            else if (this.islemTuru == "Alış İade") ayarlar.ayarla_manuel("İade_Alış_Kağıt_Tipi", cmbCiktituru.Text);
            else if (this.islemTuru == "Teklif") ayarlar.ayarla_manuel("Teklif_Kağıt_Tipi", cmbCiktituru.Text);
            else if (this.islemTuru == "Sipariş") ayarlar.ayarla_manuel("Sipariş_Kağıt_Tipi", cmbCiktituru.Text);
        }
        private void btnAgirlikHesp_Click(object sender, EventArgs e)
        {
            dgTicaret.CurrentRow.Cells["miktar"].Value = txtMiktar.Text;
            hesaplariYap();
            pnlAgirlik.Visible = false;
            txtMiktar.Text = "0";
            txtTutar.Text = "0";
            programCalisiyormu = false;
            t1.Abort();
            // MessageBox.Show("Thread Sonlandırıldı");
        }
        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            /*  if (!txtTutar.Text.Equals(""))
              {
                  txtMiktar.Text = (Convert.ToDouble(txtTutar.Text) / Convert.ToDouble(lblBirimFiyat.Text)).ToString();
              }*/
        }
        private void chbAgirlik_CheckedChanged(object sender, EventArgs e)
        {
            ayarlar.ayarla_manuel("Ağırlık", Convert.ToByte(chbAgirlik.Checked).ToString());
        }
        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            //terazi();
            //tMiktar = egelen;
            //tMiktar = tMiktar.Replace(".", ",").ToString();
            //txtMiktar.Text = tMiktar;
            //txtTutar.Text = (Convert.ToDouble(tMiktar) * Convert.ToDouble(lblBirimFiyat.Text)).ToString();
        }
        public void baslangic()
        {
            t1 = new Thread(new ThreadStart(bekleVeIslemiTekrarla));
            t1.Start();
        }
        public void bekleVeIslemiTekrarla()
        {
            while (programCalisiyormu && chbAgirlik.Checked)
            {
                Thread.Sleep(2000);
                Hesapla();
            }

        }
        void Hesapla()
        {
            try
            {
                terazi();
                tMiktar = egelen;
                tMiktar = tMiktar.Replace(".", ",").ToString();
                txtMiktar.Text = tMiktar;
                txtTutar.Text = (Convert.ToDouble(tMiktar) * Convert.ToDouble(lblBirimFiyat.Text)).ToString();
            }
            catch (Exception)
            {

            }

        }
        private void btnKapat_Click(object sender, EventArgs e)
        {
            programCalisiyormu = false;
            pnlAgirlik.Visible = false;
        }
        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ayarlar.ayarla_manuel("Terazi_Portu", cmbPort.Text);
            terazicom = cmbPort.Text;
        }
        private void cmbPTeraziAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ayarlar.ayarla_manuel("Terazi_Adi", cmbTeraziAdi.SelectedIndex.ToString());
            teraziAdi = cmbTeraziAdi.SelectedIndex;
        }
        private void btnVeresiye_Click(object sender, EventArgs e)
        {
            string txtKullaniciAciklamasi = "";
            if (odemeislemiBaslangici("Açık Hesap") == false) return;
            string islemTuru2 = "";
            if (islemTuru.Contains("Alış"))
            {
                islemTuru2 = "Alış";
                if (txtKullaniciAciklamasi == "") txtKullaniciAciklamasi = "Açık Hesaplı Alış";
            }
            else if (islemTuru.Contains("Satış"))
            {
                islemTuru2 = "Satış";
                if (txtKullaniciAciklamasi == "") txtKullaniciAciklamasi = "Açık Hesaplı Satış";
            }
            cariid = 0;
            frmOdemeVeTahsilat frm = new frmOdemeVeTahsilat(cariid, "", txtGenelTop.Text, islemTuru2, DateTime.Now, grupid, ticaretAyrintiid, txtKullaniciAciklamasi, duzenlemeBakiyesi);
            frm._frmTicaret1 = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (DialogResult == frm.ShowDialog()) cariid = 0;
        }

        private void txtBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmPesinSatis_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["SplitterDistance"] = splitContainer1.SplitterDistance.ToString();
            Properties.Settings.Default.Save();
        }

        private void cmbUrunAdi_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void TrySomeThings()
        {
            //// assume you bind a list of persons to the ComboBox with 'Name' as DisplayMember:
            //cmbUrunAdi.DataSource = cmbUrunAdi.Items.Cast<string>().Select(i => new Person { Name = i }).ToList();
            //cmbUrunAdi.DisplayMember = "Name";

            //// then you have to set the PropertySelector like this:
            //cmbUrunAdi.PropertySelector = collection => collection.Cast<Person>().Select(p => p.Name);

            //// filter rule can be customized: e.g. a StartsWith search:
            //cmbUrunAdi.FilterRule = (item, text) => item.StartsWith(text.Trim(), StringComparison.CurrentCultureIgnoreCase);

            //// ordering rule can also be customized: e.g. order by the surname:
            //cmbUrunAdi.SuggestListOrderRule = s => s.Split(' ')[1];

        }
    }
}

public class SuggestComboBox : ComboBox
{
    #region fields and properties

    private readonly ListBox _suggLb = new ListBox { Visible = false, TabStop = false };
    private readonly BindingList<string> _suggBindingList = new BindingList<string>();
    private Expression<Func<ObjectCollection, IEnumerable<string>>> _propertySelector;
    private Func<ObjectCollection, IEnumerable<string>> _propertySelectorCompiled;
    private Expression<Func<string, string, bool>> _filterRule;
    private Func<string, bool> _filterRuleCompiled;
    private Expression<Func<string, string>> _suggestListOrderRule;
    private Func<string, string> _suggestListOrderRuleCompiled;

    public int SuggestBoxHeight
    {
        get { return _suggLb.Height; }
        set { if (value > 0) _suggLb.Height = value; }
    }

    /// <summary>
    /// If the item-type of the ComboBox is not string,
    /// you can set here which property should be used
    /// </summary>
    public Expression<Func<ObjectCollection, IEnumerable<string>>> PropertySelector
    {
        get { return _propertySelector; }
        set
        {
            if (value == null) return;
            _propertySelector = value;
            _propertySelectorCompiled = value.Compile();
        }
    }

    ///<summary>
    /// Lambda-Expression to determine the suggested items
    /// (as Expression here because simple lamda (func) is not serializable)
    /// <para>default: case-insensitive contains search</para>
    /// <para>1st string: list item</para>
    /// <para>2nd string: typed text</para>
    ///</summary>
    public Expression<Func<string, string, bool>> FilterRule
    {
        get { return _filterRule; }
        set
        {
            if (value == null) return;
            _filterRule = value;
            _filterRuleCompiled = item => value.Compile()(item, Text);
        }
    }

    ///<summary>
    /// Lambda-Expression to order the suggested items
    /// (as Expression here because simple lamda (func) is not serializable)
    /// <para>default: alphabetic ordering</para>
    ///</summary>
    public Expression<Func<string, string>> SuggestListOrderRule
    {
        get { return _suggestListOrderRule; }
        set
        {
            if (value == null) return;
            _suggestListOrderRule = value;
            _suggestListOrderRuleCompiled = value.Compile();
        }
    }

    #endregion

    /// <summary>
    /// ctor
    /// </summary>
    public SuggestComboBox()
    {
        // set the standard rules:
        _filterRuleCompiled = s => s.ToLower().Contains(Text.Trim().ToLower());
        _suggestListOrderRuleCompiled = s => s;
        _propertySelectorCompiled = collection => collection.Cast<string>();

        _suggLb.DataSource = _suggBindingList;
        _suggLb.Click += SuggLbOnClick;

        ParentChanged += OnParentChanged;
    }

    /// <summary>
    /// the magic happens here ;-)
    /// </summary>
    /// <param name="e"></param>
    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);

        if (!Focused) return;

        _suggBindingList.Clear();
        _suggBindingList.RaiseListChangedEvents = false;
        _propertySelectorCompiled(Items)
             .Where(_filterRuleCompiled)
             .OrderBy(_suggestListOrderRuleCompiled)
             .ToList()
             .ForEach(_suggBindingList.Add);
        _suggBindingList.RaiseListChangedEvents = true;
        _suggBindingList.ResetBindings();

        _suggLb.Visible = _suggBindingList.Any();

        if (_suggBindingList.Count == 1 &&
                    _suggBindingList.Single().Length == Text.Trim().Length)
        {
            Text = _suggBindingList.Single();
            Select(0, Text.Length);
            _suggLb.Visible = false;
        }
    }

    #region size and position of suggest box

    /// <summary>
    /// suggest-ListBox is added to parent control
    /// (in ctor parent isn't already assigned)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnParentChanged(object sender, EventArgs e)
    {
        Parent.Controls.Add(_suggLb);
        Parent.Controls.SetChildIndex(_suggLb, 0);
        _suggLb.Top = Top + Height - 3;
        _suggLb.Left = Left + 3;
        _suggLb.Width = Width - 20;
        _suggLb.Font = new Font("Segoe UI", 9);
    }

    protected override void OnLocationChanged(EventArgs e)
    {
        base.OnLocationChanged(e);
        _suggLb.Top = Top + Height - 3;
        _suggLb.Left = Left + 3;
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        _suggLb.Width = Width - 20;
    }

    #endregion

    #region visibility of suggest box

    protected override void OnLostFocus(EventArgs e)
    {
        // _suggLb can only getting focused by clicking (because TabStop is off)
        // --> click-eventhandler 'SuggLbOnClick' is called
        if (!_suggLb.Focused)
            HideSuggBox();
        base.OnLostFocus(e);
    }

    private void SuggLbOnClick(object sender, EventArgs eventArgs)
    {
        Text = _suggLb.Text;
        Focus();
    }

    private void HideSuggBox()
    {
        _suggLb.Visible = false;
    }

    protected override void OnDropDown(EventArgs e)
    {
        HideSuggBox();
        base.OnDropDown(e);
    }

    #endregion

    #region keystroke events

    /// <summary>
    /// if the suggest-ListBox is visible some keystrokes
    /// should behave in a custom way
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
    {
        if (!_suggLb.Visible)
        {
            base.OnPreviewKeyDown(e);
            return;
        }

        switch (e.KeyCode)
        {
            case Keys.Down:
                if (_suggLb.SelectedIndex < _suggBindingList.Count - 1)
                    _suggLb.SelectedIndex++;
                return;
            case Keys.Up:
                if (_suggLb.SelectedIndex > 0)
                    _suggLb.SelectedIndex--;
                return;
            case Keys.Enter:
                Text = _suggLb.Text;
                Select(0, Text.Length);
                _suggLb.Visible = false;
                return;
            case Keys.Escape:
                HideSuggBox();
                return;
        }

        base.OnPreviewKeyDown(e);
    }

    private static readonly Keys[] KeysToHandle = new[] { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape };
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // the keysstrokes of our interest should not be processed be base class:
        if (_suggLb.Visible && KeysToHandle.Contains(keyData))
            return true;
        return base.ProcessCmdKey(ref msg, keyData);
    }

    #endregion
}