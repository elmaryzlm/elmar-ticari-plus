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
using CurrentEDMConnectorClientLibrary;
using CurrentEDMConnectorClientLibrary.Entities;

namespace Elmar_Ticari_Plus
{
    public partial class frmTicaret : Form
    {
        //değişkenler ve tanımlamalar
        public enum formTipi
        {
            faturasizSatis, faturaliSatis, satisDuzenle, faturasizAlis, faturaliAlis, stokDuzenle, siparisOlustur, siparisDuzenle, teklifOlustur, teklifDuzenle, stokTransferi, transferDuzenle, satisiade, alisiade, stokCikis, pesinSatis, alisiadeDuzenle, satisiadeDuzenle
        }

        private Int16 miktarCarpani = 1;
        public faturaBilgileri _faturaBilgileri;
        //private cariTipleri cariTipi = cariTipleri.carisizislem;
        private stokkart.stokkartAyrinti urunBilgisi;
        public Int64 cariid = 0;
        public string islemTuru;
        private string onay = "0";
        private bool alisMi = false;
        public string _hesabaislendimi = "0";
        private Int32 gecerliFiyatid = 1;
        private List<Int64> adresidler = new List<Int64>();
        public long ticaretAyrintiid = 0;
        public string silindimi = "0";
        public formTipi _formTipi;
        public int grupid = 1;
        private bool grupidVerildimi = false;
        private int gonderenSubeid = 0, alanSubeid = 0;
        double duzenlemeBakiyesi = 0;
        //Düzenleme işlemindeki bakiye hatasının önüne geçmek için (eskibakiye - eski satış bakiyesi + yeni satış bakiyesi)
        //------------------------------------------------------------
        double tAraToplam = 0;
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
        string tIscilik_F
        {
            get { return String.Format("{0:n2}", tIscilik); }
            set { tIscilik = Convert.ToDouble(value); txtiscilik.Text = tIscilik_F; }
        }
        double tNakliyat = 0;
        string tNakliyat_F
        {
            get { return String.Format("{0:n2}", tNakliyat); }
            set { tNakliyat = Convert.ToDouble(value); txtNakliyat.Text = tNakliyat_F; }
        }
        double toplamfiyat = 0;
        //_-------------------------------------------------------------------------
        public frmTicaret(formTipi formTipi)
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgTicaret);
            NesneGorselleri.kontrolEkle(tabPage7);
            NesneGorselleri.kontrolEkle(pnlUrunSorgulama);
            NesneGorselleri.kontrolEkle(cariSecimi);
            NesneGorselleri.kontrolEkle(cariTanimlama);
            NesneGorselleri.kontrolEkle(panel1);
            NesneGorselleri.kontrolEkle(panel2);
            NesneGorselleri.kontrolEkle(panel3);
            NesneGorselleri.kontrolEkle(panel4);
            if (formTipi == frmTicaret.formTipi.faturasizSatis || formTipi == frmTicaret.formTipi.teklifDuzenle)
            {
                this.Text = "Ayrıntılı Satış | Faturasız Satış";
                islemTuru = "Faturasız Satış";
                _hesabaislendimi = "1";
                btnPos.Visible = true;
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                miktarCarpani = -1;
                tabCari.TabPages.Remove(tbTransfer);
            }
            if (formTipi == frmTicaret.formTipi.pesinSatis)
            {
                this.Text = "Peşin Satış";
                islemTuru = "Faturasız Satış";
                btnPos.Visible = true;
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                miktarCarpani = -1;
                tabCari.Visible = false;
                pnlCanliStok.Visible = false;
                panel2.Parent = pnlUst;
                panel2.Dock = DockStyle.Right;
                label22.Visible = false;
                label23.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                txtToplam.Visible = false;
                txtKdvTop.Visible = false;
                txtiscilik.Visible = false;
                txtNakliyat.Visible = false;
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                txtiskonto.Parent = panel3;
                label24.Parent = panel3;
                label33.Parent = panel3;
                btnAyar.Parent = panel3;

                txtiskonto.Left = 122;
                label24.Left = 75;
                label31.Left = 218;
                btnAyar.Top = 2;
                btnAyar.Left = 2;
                txtiskonto.Top = 3;
                label24.Top = 6;
                label33.Top = 120;
                txtGenelTop.Top = 2;
                label25.Top = 5;
                label34.Top = 40;
                label25.Text = "";
                txtGenelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 40, FontStyle.Bold);
                txtGenelTop.Width = 220;
                txtGenelTop.Left = txtGenelTop.Left - 80;
                label28.Visible = false;
                txtSeriNo.Visible = false;
                label14.Visible = false;
                txtStokKodu.Visible = false;
                label15.Visible = false;
                dgTicaret.Columns["birim"].Visible = false;
                dgTicaret.Columns["katsayi"].Visible = false;
                dgTicaret.Columns["kdv"].Visible = false;
                dgTicaret.Columns["kdvTipi"].Visible = false;
                dgTicaret.Columns["isk1"].Visible = false;
                dgTicaret.Columns["AraTop"].Visible = false;
                dgTicaret.Columns["TopKDV"].Visible = false;
                dgTicaret.Columns["dovizTuru"].Visible = false;
                label16.Visible = false;
                label35.Visible = false;
                dtislemTarihi.Visible = false;
                txtSaat.Visible = false;
                txtKullaniciAciklamasi.Visible = false;
                rdHesabaislenmesin.Visible = false;
                rdHesabaislensin.Visible = false;
                flowLayoutPanel1.Top = 2;
                pnlAlt.Size = new Size(pnlAlt.Size.Width, 40);
                pnlUst.Size = new Size(pnlUst.Size.Width, 75);


                btnAyrintiliSatis.Visible = false;
                btniptal.BringToFront();
                btnPos2.BringToFront();
                btnPos2.Visible = true;
                btnPesinSatis.BringToFront();

                panel3.Visible = true;
                panel3.Size = new Size(470, panel3.Height);
                btnAyar.Left += 240;
                txtiskonto.Left += 240;
                label24.Left += 240;
                label33.Left += 240;
                this.WindowState = FormWindowState.Maximized;
                this.MdiParent = null;
            }
            else if (formTipi == frmTicaret.formTipi.faturaliSatis)
            {
                this.Text = "Faturalı Satış";
                islemTuru = "Faturalı Satış";
                btnPos.Visible = true;
                miktarCarpani = -1;
                tabCari.TabPages.RemoveAt(0);
                tabCari.TabPages.Remove(tbTransfer);
                chbOto.Visible = true;
                chbOto.Checked = EFatura.OtoGonder;
                tabCari.Tag = "1";
            }
            else if (formTipi == frmTicaret.formTipi.satisDuzenle)
            {
                this.Text = "Satış Düzenle";
                btnPos.Visible = true;
                miktarCarpani = -1;
                tabCari.TabPages.Remove(tbTransfer);
                chbOto.Visible = true;
                chbOto.Checked = EFatura.OtoGonder;
            }
            else if (formTipi == frmTicaret.formTipi.faturasizAlis)
            {
                this.Text = "Faturasız Alış | Stok Girişi";
                islemTuru = "Faturasız Alış";
                btnAyrintiliSatis.Text = "Ayrıntılı Alış";
                btnPesinSatis.Text = "Peşin Alış";
                btnKrediKarti.Visible = true;
                lblGecerliSatisFiyati.Visible = false;
                cmbGecerliSatisFiyati.Visible = false;
                chkKartliSatis.Visible = false;
                tbAyarlar.TabPages.Remove(tabPage1);
                tabCari.TabPages.Remove(tbTransfer);
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                miktarCarpani = 1;
            }
            else if (formTipi == frmTicaret.formTipi.faturaliAlis)
            {
                this.Text = "Faturalı Alış";
                islemTuru = "Faturalı Alış";
                btnAyrintiliSatis.Text = "Ayrıntılı Alış";
                btnPesinSatis.Text = "Peşin Alış";
                btnKrediKarti.Visible = true;
                lblGecerliSatisFiyati.Visible = false;
                cmbGecerliSatisFiyati.Visible = false;
                chkKartliSatis.Visible = false;
                tbAyarlar.TabPages.Remove(tabPage1);
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = 1;
                tabCari.TabPages.RemoveAt(0);
                tabCari.Tag = "1";
            }
            else if (formTipi == frmTicaret.formTipi.stokDuzenle)
            {
                this.Text = "Alış Düzenle";
                btnAyrintiliSatis.Text = "Ayrıntılı Alış";
                btnPesinSatis.Text = "Peşin Alış";
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                btnKrediKarti.Visible = true;
                lblGecerliSatisFiyati.Visible = false;
                cmbGecerliSatisFiyati.Visible = false;
                chkKartliSatis.Visible = false;
                tbAyarlar.TabPages.Remove(tabPage1);
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = 1;
            }
            else if (formTipi == frmTicaret.formTipi.teklifOlustur)
            {
                this.Text = "Teklif Oluştur";
                islemTuru = "Teklif";
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnislemiBitir.Visible = true;
                rdHesabaislensin.Enabled = false;
                rdHesabaislenmesin.Checked = true;
                tabCari.TabPages.RemoveAt(0);
                tabCari.TabPages.Remove(tbTransfer);
                tabCari.Tag = "1";
                miktarCarpani = -1;
            }
            //else if (formTipi == frmTicaret.formTipi.teklifDuzenle)
            //{
            //    this.Text = "Teklif Düzenle";
            //    btnFaturaAyarlari.Text = "Çıktı Ayarları";
            //    islemTuru = "Faturasız Satış";
            //    _hesabaislendimi = "1";
            //    btnPesinSatis.Visible = false;
            //    btnAyrintiliSatis.Visible = false;
            //    btnislemiBitir.Visible = true;
            //    rdHesabaislensin.Enabled = false;
            //    rdHesabaislenmesin.Checked = true;
            //    tabCari.TabPages.RemoveAt(0);
            //    tabCari.TabPages.Remove(tbTransfer);
            //    tabCari.Tag = "1";
            //    miktarCarpani = -1;
            //}
            else if (formTipi == frmTicaret.formTipi.siparisOlustur)
            {
                this.Text = "Sipariş Oluştur";
                islemTuru = "Sipariş";
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnislemiBitir.Visible = true;
                rdHesabaislensin.Enabled = false;
                rdHesabaislenmesin.Checked = true;
                tabCari.TabPages.RemoveAt(0);
                tabCari.Tag = "1";
                lblGecerliSatisFiyati.Visible = false;
                cmbGecerliSatisFiyati.Visible = false;
                chkKartliSatis.Visible = false;
                tbAyarlar.TabPages.Remove(tabPage1);
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = 1;
            }
            else if (formTipi == frmTicaret.formTipi.siparisDuzenle)
            {
                this.Text = "Sipariş Düzenle";
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnislemiBitir.Visible = true;
                rdHesabaislensin.Enabled = false;
                rdHesabaislenmesin.Checked = true;
                tabCari.TabPages.RemoveAt(0);
                tabCari.Tag = "1";
                lblGecerliSatisFiyati.Visible = false;
                cmbGecerliSatisFiyati.Visible = false;
                chkKartliSatis.Visible = false;
                tbAyarlar.TabPages.Remove(tabPage1);
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = 1;
            }
            else if (formTipi == frmTicaret.formTipi.stokTransferi)
            {
                this.Text = "Stok Transferi";
                islemTuru = "Transfer";
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                chkOtoYazdir.Checked = false;
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnTransferYap.Visible = true;
                btnTransferYap.BringToFront();
                tabCari.TabPages.Remove(carisizislem);
                tabCari.TabPages.Remove(cariSecimi);
                tabCari.TabPages.Remove(cariTanimlama);
                listeler.doldurSube(cmbStokAlanSube);
                listeler.doldurSube(cmbStokGonderenSube);
                cmbStokAlanSube.SelectedIndex = -1;
                cmbStokGonderenSube.SelectedIndex = -1;
                miktarCarpani = 1;
            }
            else if (formTipi == frmTicaret.formTipi.transferDuzenle)
            {
                this.Text = "Stok Transferi Düzenle";
                islemTuru = "Transfer";
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                chkOtoYazdir.Checked = false;
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnTransferYap.Visible = true;
                btnTransferYap.BringToFront();
                tabCari.TabPages.Remove(carisizislem);
                tabCari.TabPages.Remove(cariSecimi);
                tabCari.TabPages.Remove(cariTanimlama);
                listeler.doldurSube(cmbStokAlanSube);
                listeler.doldurSube(cmbStokGonderenSube);
                cmbStokAlanSube.SelectedIndex = -1;
                cmbStokGonderenSube.SelectedIndex = -1;
                miktarCarpani = 1;
            }
            else if (formTipi == frmTicaret.formTipi.alisiade)
            {
                this.Text = "Alış İade";
                islemTuru = "Alış İade";
                chkOtoYazdir.Checked = false;
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnislemiBitir.Visible = true;
                btnislemiBitir.Text = "Peşin İade";
                btniadeAcikHesap.Visible = true;
                lblGecerliSatisFiyati.Visible = false;
                cmbGecerliSatisFiyati.Visible = false;
                chkKartliSatis.Visible = false;
                tbAyarlar.TabPages.Remove(tabPage1);
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = -1;
            }
            else if (formTipi == frmTicaret.formTipi.satisiade)
            {
                this.Text = "Satış İade";
                islemTuru = "Satış İade";
                chkOtoYazdir.Checked = false;
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnislemiBitir.Visible = true;
                btnislemiBitir.Text = "Peşin İade";
                btniadeAcikHesap.Visible = true;
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = 1;
            }
            else if (formTipi == frmTicaret.formTipi.alisiadeDuzenle)
            {
                this.Text = "Alış İade Düzenle";
                islemTuru = "Alış İade";
                chkOtoYazdir.Checked = false;
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnislemiBitir.Visible = true;
                btnislemiBitir.Text = "Peşin İade";
                btniadeAcikHesap.Visible = true;
                lblGecerliSatisFiyati.Visible = false;
                cmbGecerliSatisFiyati.Visible = false;
                chkKartliSatis.Visible = false;
                tbAyarlar.TabPages.Remove(tabPage1);
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = -1;
            }
            else if (formTipi == frmTicaret.formTipi.satisiadeDuzenle)
            {
                this.Text = "Satış İade Düzenle";
                islemTuru = "Satış İade";
                chkOtoYazdir.Checked = false;
                btnPesinSatis.Visible = false;
                btnAyrintiliSatis.Visible = false;
                btnislemiBitir.Visible = true;
                btnislemiBitir.Text = "Peşin İade";
                btniadeAcikHesap.Visible = true;
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = 1;
            }
            else if (formTipi == frmTicaret.formTipi.stokCikis)
            {
                this.Text = "Stok Çıkış";
                islemTuru = "Stok Çıkış";
                chkOtoYazdir.Checked = false;
                btnFaturaAyarlari.Text = "Çıktı Ayarları";
                btnPos.Visible = true;
                tabCari.TabPages.Remove(tbTransfer);
                miktarCarpani = -1;
            }
            _faturaBilgileri = new faturaBilgileri();

        }
        private SEFatura servis;
        private void frmTicaret_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgTicaret.Columns["AraTop"].DefaultCellStyle.Format = "n";
                // this.dgTicaret.Columns["birimFiyat"].DefaultCellStyle.Format = "n";
                this.dgTicaret.Columns["TopKDV"].DefaultCellStyle.Format = "n";
                this.dgTicaret.Columns["Tutar"].DefaultCellStyle.Format = "n";
                urunAdiListesiniYenile();
                cariListesiniYenile();
                yaziciListele();
                satisFiyatiListele();
                personelListesiYenile();

                txtSaat.Text = DateTime.Now.ToShortTimeString();
                tabCari.SelectedIndex = 0;
                if (ticaretAyrintiid != 0) duzenlemeFormuislemleriniYap();
                else btniptal.PerformClick();
                ayarlariGetir();
                if (EFatura.KullaniciAdi.Length > 0)
                {
                    servis = new SEFatura(EFatura.KullaniciAdi, EFatura.Sifre, EFatura.UrlAdresi);
                    List<FormParameters> getFormParameters = servis.Current_Login();

                    if (getFormParameters != null)
                    {
                        foreach (var parameter in getFormParameters)
                        {
                            if (parameter.sessionID != null)
                            {
                                if (parameter.sessionID.GetType() == typeof(string)) EFatura.SessionsID = parameter.sessionID.ToString();
                                EFatura.LoginOK = parameter.loginEnter;
                            }
                            // tester.Current_GetInvoice(true, "PDF", true, "OUT", 1, "ARV2020000000001", null);
                        }
                    }
                }
            }
            catch
            {
            }

        }

        void EkranAyari()
        {
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            int ekran_x = Screen.GetBounds(new Point(0, 0)).Width;
            int ekran_y = Screen.GetBounds(new Point(0, 0)).Height;
            string a = Convert.ToString(ekran_x) + "x" + Convert.ToString(ekran_y);
            Rectangle ClientCozunurluk = new Rectangle();
            ClientCozunurluk = Screen.GetBounds(ClientCozunurluk);
            if (Convert.ToDouble(ClientCozunurluk.Width) < 1366)
            {
                frmTicaret frm = new frmTicaret(0);
                frm.Size = new Size();

            }
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
            }
            catch (Exception)
            {
            }

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
        void duzenlemeFormuislemleriniYap()
        {
            try
            {
                string sql = "SELECT [cariid],[adiSoyadi],[odemeTuru],[islemTarihi],[islemSaati],[islemTuru],abs([AraTop]) AraTop,abs([KdvTop]) KdvTop,abs([iskonto]) iskonto,abs([nakliyat]) nakliyat,abs([iscilik]) iscilik,abs([GenelTop]) GenelTop,[fiiliSevkTarihi],[faturaNo],[belgeNo],[irsaliyeNo],[vergiDaire],[vergiNo],[adres],[faturaAciklamasi],[islemAciklamasi],[hesabaislendimi],[onay],[silindimi] FROM [sorTicaretAyrinti] where [ticaretAyrintiid] = " + ticaretAyrintiid + " and firmaid = " + firma.firmaid;
                DataRow rw = veri.getdatarow(sql);
                this.cariid = Convert.ToInt64(rw["cariid"]);
                islemTuru = rw["islemTuru"].ToString();
                if (this.cariid != 0) tabCari.SelectedIndex = 1;
                cmbCariListesi.Text = rw["adiSoyadi"].ToString();
                dtislemTarihi.Value = Convert.ToDateTime(rw["islemTarihi"]);
                txtSaat.Text = rw["islemSaati"].ToString();
                txtiskonto.Text = rw["iskonto"].ToString();
                txtNakliyat.Text = rw["nakliyat"].ToString();
                txtiscilik.Text = rw["iscilik"].ToString();
                _faturaBilgileri = new faturaBilgileri();
                _faturaBilgileri.belgeNo = rw["belgeNo"].ToString();
                _faturaBilgileri.faturaAciklamasi = rw["faturaAciklamasi"].ToString();
                _faturaBilgileri.faturaNo = rw["faturaNo"].ToString();
                _faturaBilgileri.fiiliSefkTarihi = Convert.ToDateTime(rw["fiiliSevkTarihi"]);
                _faturaBilgileri.irsaliyeNo = rw["irsaliyeNo"].ToString();

                txtVergiDairesi.Text = rw["vergiDaire"].ToString();
                txtVergiNo.Text = rw["vergiNo"].ToString();
                txtAdres.Text = rw["adres"].ToString();
                txtKullaniciAciklamasi.Text = rw["islemAciklamasi"].ToString();
                if (rw["hesabaislendimi"].ToString() == "1")
                    rdHesabaislensin.Checked = true;
                else
                    rdHesabaislenmesin.Checked = true;

                onay = rw["onay"].ToString();
                _hesabaislendimi = rw["hesabaislendimi"].ToString();
                silindimi = rw["silindimi"].ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Veriler getirilirken hata oluştu.\nHata Metni[1]: " + hata.Message, firma.programAdi);
            }

            SqlDataReader dr = veri.getDatareader("SELECT [ticaretid],[stokid],[barkod],[urunAdi],abs([miktar]) miktar,[satilanMiktar],[birim],[katsayi],[birimFiyat],[isk1],[kdv],[kdvTipi],[isk2],[isk3],abs([AraTop]) AraTop,abs([KdvTop])KdvTop,abs([Toplam])Toplam,[dovizTuru],[dovizDegeri],[seriNo],[skt] FROM sorTicaret where silindimi = '0' and [ticaretAyrintiid] = " + ticaretAyrintiid + " and firmaid = " + firma.firmaid);
            while (dr.Read())
            {
                try
                {
                    dgTicaret.Rows.Add(dr["ticaretid"].ToString(), dr["stokid"].ToString(), "", dr["barkod"].ToString(), dr["urunAdi"].ToString(), dr["miktar"].ToString(), null, dr["katsayi"].ToString(), dr["birimFiyat"].ToString(), dr["isk1"].ToString(), dr["kdv"].ToString(), null, dr["isk2"].ToString(), dr["isk3"].ToString(), dr["seriNo"].ToString(), dr["AraTop"].ToString(), dr["KdvTop"].ToString(), dr["Toplam"].ToString(), null, dr["dovizDegeri"].ToString());

                    //birimler ekleniyor.
                    DataGridViewComboBoxCell kolon;

                    kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["birim"];
                    foreach (stokkart.birimler.birimlerAyrinti birimBilgisi in stokkart.birimler.bul_stokid(Convert.ToInt64(dr["stokid"]))) kolon.Items.Add(birimBilgisi.birimAdi);
                    kolon.Value = dr["birim"].ToString();

                    //Kdv tipi ekleniyor
                    kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["kdvTipi"];
                    kolon.Items.Add("Dahil");
                    kolon.Items.Add("Hariç");
                    kolon.Value = dr["kdvTipi"].ToString();
                    //Döviz Ekleniyor
                    kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["dovizTuru"];
                    kolon.Items.Add("TL");
                    kolon.Items.Add("USD");
                    kolon.Items.Add("Euro");
                    kolon.Value = dr["dovizTuru"].ToString();
                    dgTicaret.Rows[dgTicaret.RowCount - 1].Cells["skt"].Value = dr["skt"].ToString();

                }
                catch (Exception hata)
                {
                    // MessageBox.Show("Veriler getirilirken hata oluştu.\nHata Metni[2]: " + hata.Message, firma.programAdi);
                }
            }
            ana_toplamlari_hesaplat();
            if (this.Text.Contains("Düzenle"))
                duzenlemeBakiyesi = Convert.ToDouble(txtGenelTop.Text) * miktarCarpani;
        }
        public void urunAdiListesiniYenile()
        {
            //ürün listesi getiriliyor
            cmbUrunAdi.Items.Clear();
            try { cmbUrunAdi.Items.AddRange(listeler.getUrunisim()); }
            catch { }
        }
        public void cariListesiniYenile()
        {
            //cari listesi getiriliyor
            cmbCariListesi.Items.Clear();
            try
            { cmbCariListesi.Items.AddRange(listeler.getCariAdi()); }
            catch { }
        }
        private void personelListesiYenile()
        {
            //personel listesi getiriliyor
            cmbPersonelAdlari.Items.Clear();
            try
            { cmbPersonelAdlari.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
        }
        private void btnAyar_Click(object sender, EventArgs e)
        {
            if (tbAyarlar.Visible == true)
                tbAyarlar.Visible = false;
            else tbAyarlar.Visible = true;
        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void tabCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCari.TabPages[tabCari.SelectedIndex].Name == "carisizislem")
            {
                cariTemizle();
            }
            else if (tabCari.TabPages[tabCari.SelectedIndex].Name == "cariSecimi")
            {
                if (cmbCariListesi.Items.Count == 0)
                {
                    try
                    {
                        cmbCariListesi.Items.Clear();
                        cmbCariListesi.Items.AddRange(listeler.getCariAdi());
                    }
                    catch { }
                }
            }
        }
        private void cmbCariListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCari();
        }

        private void getCari()
        {
            try
            {
                try
                {
                    cariid = listeler.getCariid()[cmbCariListesi.SelectedIndex];
                }
                catch
                {

                    if (cmbCariListesi.Text.Trim().Length == 0 && cmbCariListesi.Text.Length < 12) return;
                    var c = cariBilgileri.bul_RIFDNo(cmbCariListesi.Text);
                    if (c == null) return;
                    cmbCariListesi.Text = "";
                    cariid = c.cariid;
                    cmbCariListesi.Text = c.adiSoyadi;
                }

                if (this.islemTuru == "Faturasız Satış") gecerliFiyatid = Convert.ToInt32(ayarlar.Faturasız_Satış_Fiyatı);
                else if (this.islemTuru == "Transfer") gecerliFiyatid = Convert.ToInt32(ayarlar.Transfer_Satış_Fiyatı);
                else if (this.islemTuru == "Faturalı Satış") gecerliFiyatid = Convert.ToInt32(ayarlar.Faturalı_Satış_Fiyatı);
                else gecerliFiyatid = Convert.ToInt32(ayarlar.Faturasız_Satış_Fiyatı);
                var l = cariBilgileri.bul_cariid(cariid);
                if (l.fiyatid > 0) gecerliFiyatid = l.fiyatid;
                //txtCariLimiti.Text = l.limit.ToString();
                //cmbParaBirimi.Text = l.paraBirimi;            

                try
                {
                    //adresler getiriliyor
                    cmbAdres.Items.Clear();
                    adresidler.Clear();
                    var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid);
                    foreach (var adresKaydi in adresListesi)
                    {
                        cmbAdres.Items.Add(adresKaydi.adresAdi);
                        adresidler.Add(adresKaydi.adresid);
                    }
                    if (cmbAdres.Items.Count >= 0) cmbAdres.SelectedIndex = 0;
                }
                catch { }
                //txtEskiBakiye.Text = String.Format("{0:n2}",  Convert.ToDouble(veri.getdatacell("select sum(bakiye) from sorCariBakiye where firmaid = " + firma.firmaid + " and cariid = " + cariid + "")));
                txtEskiBakiye.Text = String.Format("{0:n2}", l.bakiye) + " " + l.bakiyeDurumu;
                eskiBakiye = l.bakiye;

                if (this.Text.Contains("Düzenle")) eskiBakiye = eskiBakiye - Convert.ToDouble(veri.getdatacell("Select sum(isnull(bakiye,0)) from sorAcikHesap where firmaid = " + firma.firmaid + " And cariid = " + cariid + " and ticaretAyrintiid = " + ticaretAyrintiid + " And islemTuru2 in('Tahsilat','Ödeme')"));
            }
            catch (Exception)
            {
            }
            txtBarkod.Select();
        }


        private void cmbAdres_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var adresKaydi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.adresid == adresidler[cmbAdres.SelectedIndex]).First();
                txtAdres.Text = adresKaydi.boldeAdi + "  " + adresKaydi.adres + "  P.K:" + adresKaydi.postaKodu + "  " + adresKaydi.tel + "  " + adresKaydi.gsm;
                txtVergiDairesi.Text = adresKaydi.vergiDaire;
                txtVergiNo.Text = adresKaydi.vergiNo;
                EFatura.AliciEPosta = adresKaydi.email;

                if (EFatura.LoginOK)
                    backgroundWorker1.RunWorkerAsync();
            }
            catch { }
        }
        void cariEkle()
        {
            try
            {
                if (txtCAdi.Text == "")
                {
                    MessageBox.Show("Cari Adını Girmediniz", firma.programAdi);
                    txtCAdi.Select();
                    return;

                }
                string bolgeid = txtCBolge.Tag.ToString();

                string sql = @"insert into tblCariBilgileri(adi,soyadi,vergiDaire,vergiNo,firmaid,subeid,kullaniciid)
                                        values('" + txtCAdi.Text + "','" + txtCSoyadi.Text + "','" + txtVergiDairesi.Text + "','" + txtVergiNo.Text + "','" + firma.firmaid + "','" + firma.subeid + "','" + firma.kullaniciid + "')";

                Int64 eklenenCariid = Convert.ToInt64(veri.getdatacell(sql));
                SqlDataReader dr = veri.getDatareader("select Max(cariid)as id from tblCariBilgileri");//en son eklenen id yi getiriyor...
                while (dr.Read())
                {
                    eklenenCariid = Convert.ToInt32(dr["id"].ToString());
                }
                if (cariid != 0) cariBilgileri.listCariBilgileri.Remove(cariBilgileri.listCariBilgileri.Where(u => u.cariid == cariid).First());
                cariBilgileri.ekle(eklenenCariid, 0, "", txtCAdi.Text, txtCSoyadi.Text, txtCAdi.Text + " " + txtCSoyadi.Text, "", "", txtCVergiDairesi.Text, txtCVergiNo.Text, "", 0, 0, "", "TL", 0, 0, "", "", "", "", "", "1", "0", "1", "0", -1, DateTime.Now, "0", firma.subeid, firma.kullaniciid, 0, "");
                listeler.yukleCariadi();

                //adres ekleniyor
                Int64 eklenenAdresid = Convert.ToInt64(veri.getdatacell("exec spAdresEkle 0, '" + eklenenCariid + "', 'İletişim Adresi', '" + txtCAdi.Text + "', '" + txtCSoyadi.Text + "', '" + txtCEmail.Text + "', '" + txtCTel.Text + "', '', '', '" + bolgeid + "', '" + txtCAdres.Text + "', '', '', '" + txtCVergiDairesi.Text + "', '" + txtCVergiNo.Text + "', '', '1', '" + firma.firmaid + "', '" + firma.subeid + "', '" + firma.kullaniciid + "'"));
                cariBilgileri.adresBilgileri.ekle(eklenenAdresid, eklenenCariid, txtCAdi.Text + " " + txtCSoyadi.Text, "İletişim Adresi", txtCAdi.Text, txtCSoyadi.Text, txtCEmail.Text, txtCTel.Text, "", "", bolgeid, "", txtCAdres.Text, "", "", txtCVergiDairesi.Text, txtCVergiNo.Text, "", "1", DateTime.Now, firma.subeid, firma.kullaniciid);
                listeler.yukleAdresler();


                cariTemizle();
                cariListesiniYenile();
                cmbCariListesi.Text = cariBilgileri.listCariBilgileri.Where(u => u.cariid == eklenenCariid).First().adiSoyadi;
                tabCari.SelectedTab = tabCari.TabPages["cariSecimi"];
            }
            catch (Exception hata)
            {
                MessageBox.Show("Cari tanımlama işleminde bir hata oluştu.\nHata Metni: " + hata.Message, firma.programAdi);
            }
            //MessageBox.Show("Cari Başarıyla Eklendi", firma.programAdi);
        }
        void cariTemizle()
        {
            txtCBolge.Clear();
            txtCBolge.Tag = "00";
            cmbCariListesi.Text = "";
            cariid = 0;
            txtAdres.Text = "0";
            txtKartBakiyesi.Text = "0";
            txtKartPuani.Text = "0";
            txtCariLimiti.Text = "0";
            txtEskiBakiye.Text = "0";
            txtCAdi.Clear();
            txtCSoyadi.Clear();
            txtCVergiDairesi.Clear();
            txtCVergiNo.Clear();
            txtVergiDairesi.Clear();
            txtVergiNo.Clear();
            txtCEmail.Clear();
            txtCTel.Clear();
            txtAdres.Clear();
            if (tabCari.SelectedIndex == 1) cmbCariListesi.Select();
            else if (tabCari.SelectedIndex == 2) txtCAdi.Select();
            else txtBarkod.Select();

        }
        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            Control sndr = (Control)sender;
            if (e.KeyCode == Keys.Down) this.SelectNextControl(sndr, true, true, true, true);
            else if (e.KeyCode == Keys.Up) this.SelectNextControl(sndr, false, true, true, true);
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarkod.Text.Length > 16) txtBarkod.Text = txtBarkod.Text.Substring(3, 13);
                if (sndr.Name == "txtBarkod") urunBilgisi = stokkart.bul_barkod(txtBarkod.Text);
                else if (sndr.Name == "cmbUrunAdi") urunBilgisi = stokkart.bul_urunAdi(cmbUrunAdi.Text);
                else if (sndr.Name == "txtSeriNo") urunBilgisi = stokkart.bul_seriNo(txtSeriNo.Text);
                else if (sndr.Name == "txtStokKodu") urunBilgisi = stokkart.bul_stokkodu(txtStokKodu.Text);
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
                    urunuDataGrideEkle(urunBilgisi.stokid, txtBarkod.Text, "1");
                }
                catch (Exception hata)
                {

                    if (txtBarkod.Text.StartsWith("27"))
                    {
                        urunBilgisi = stokkart.bul_stokid(Convert.ToInt64((txtBarkod.Text.Substring(2, 5))));
                        string _miktar = (Convert.ToDouble(txtBarkod.Text.Substring(7, 6)) / 10000).ToString();
                        urunuDataGrideEkle(urunBilgisi.stokid, txtBarkod.Text, _miktar);
                    }
                    else if (MessageBox.Show("Ürün bulunamadı. Eklemek ister misiniz?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmStokKartEkle frm = new frmStokKartEkle();
                        frm.Show();
                    }
                }
            }
        }
        long stokID1 = 0;

        void urunuDataGrideEkle(Int64 pStokid, string pBarkod, string pMiktar)
        {
            cmbUrunAdi.Text = "";
            stokID1 = pStokid;
            //Canlı Stok Getiriliyor
            //if (islemTuru.Contains("Satış") && rdStokKontrolleriYapilmasin.Checked == false)
            //{ }
            if (guvenlikVeKontrol.internetVarmi())
            {
                try
                {
                    string canli1 =
                        veri.getdatacell("Select isnull(sum(miktar*katsayi),0) from tblTicaret where stokid =  " +
                                         urunBilgisi.stokid + " and silindimi = '0' and subeid = " + firma.subeid +
                                         " and firmaid = " + firma.firmaid);
                    txtCanli1.Text = canli1;

                    if (rdStokKontrolleriYapilsinEngellesin.Checked &&
                        Convert.ToDouble(canli1) - Convert.ToDouble(pMiktar) <= 0)
                    {
                        MessageBox.Show(
                            urunBilgisi.urunAdi +
                            " Adlı ürüne ait stoğunuz bulunmamaktadır. Bundan dolayı satış yapamazsınız. Stok ayarlarınızı ayarlar menüsünden değiştirebilirsiniz.",
                            firma.programAdi);
                        return;
                    }
                    else if (rdStokKontrolleriYapilsinUyariVersin.Checked &&
                             Convert.ToDouble(canli1) - Convert.ToDouble(pMiktar) <= 0)
                    {
                        if (MessageBox.Show(
                                urunBilgisi.urunAdi +
                                " Adlı ürüne ait stoğunuz bulunmamaktadır. Yinede satış yapmak istiyor musunuz? Canlı stoğunuz 0'ın altına düşecek.",
                                firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.No) return;
                    }

                }
                catch (Exception)
                {
                }
            }

            //Daha önce eklenmişmi diye bakılıyor.
            for (int i = 0; i < dgTicaret.Rows.Count; i++)
            {
                if (dgTicaret.Rows[i].Cells["stokid"].Value.ToString() == pStokid.ToString() &&
                    ((pBarkod != "" && dgTicaret.Rows[i].Cells["barkod"].Value.ToString() == pBarkod) ||
                     dgTicaret.Rows[i].Cells["urunAdi"].Value.ToString() == cmbUrunAdi.Text))
                {
                    dgTicaret.Rows[i].Cells["miktar"].Value =
                        (Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value) + 1).ToString();
                    try
                    {
                        dgTicaret.Rows[i].Cells["barkod"].Selected = true;
                    }
                    catch
                    {
                    }

                    hesaplariYap();

                    temizle_stokkartAra();
                    return;
                }
            }

            //Datagride ekleniyor.
            if (chbKDV.Checked) urunBilgisi.kdv = 0;
            dgTicaret.Rows.Add("0", urunBilgisi.stokid, urunBilgisi.stokkodu, pBarkod, urunBilgisi.urunAdi, pMiktar,
                null, 1, 0, 0, urunBilgisi.kdv, null, 0, 0, txtSeriNo.Text, 0, 0, 0, null, 1, null);

            dgTicaret.Rows[dgTicaret.Rows.Count - 1].Selected = true;
            try
            {
                dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["barkod"].Selected = true;
            }
            catch
            {
            }

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

            dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["katsayi"].Value = stokkart.birimler.bul_stokid(pStokid)
                .Where(u => u.birimAdi == kolon.Value.ToString()).First().katsayi.ToString();
            txtCanli2.Text = kolon.Value.ToString();
            //if (dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["katsayi"].Value.ToString()=="1")


            //Kdv tipi ekleniyor
            kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["kdvTipi"];
            kolon.Items.Add("Dahil");
            kolon.Items.Add("Hariç");
            kolon.Value = urunBilgisi.kdvTipi;
            //Döviz Ekleniyor
            kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["dovizTuru"];
            kolon.Items.Add("TL");
            kolon.Items.Add("USD");
            kolon.Items.Add("EURO");
            kolon.Items.Add("ANZ");
            try
            {
                kolon.Value = stokkart.fiyatlar.listFiyatlar.Where(u =>
                    u.stokid == Convert.ToInt64(dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["stokid"].Value) &&
                    u.fiyatid == gecerliFiyatid).FirstOrDefault().dovizi;
            }
            catch (Exception)
            {
                kolon.Value = "TL";
            }

            double birimfiyat = 0;
            //geçerli fiyat getiriliyor
            if (islemTuru.Contains("Satış") || islemTuru.Contains("Teklif"))
            {
                birimfiyat = Math.Round(stokkart.fiyatlar.getFiyatTutari(gecerliFiyatid, Convert.ToInt64(dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["stokid"].Value)), 2);

                try
                {
                    dgTicaret.Rows[dgTicaret.RowCount - 1].Cells["skt"].Value = veri.getdatarow("select top 1 skt from tblTicaret where stokid=" + Convert.ToInt64(dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["stokid"].Value) + " and firmaid=" + firma.firmaid + " order by eklenmeTarihi desc")["skt"];

                }
                catch (Exception e)
                {

                }

            }
            else if (islemTuru.Contains("Alış") || islemTuru.Contains("Sipariş"))
            {
                birimfiyat = Math.Round(urunBilgisi.alisFiyat, 2);
                dgTicaret.Rows[dgTicaret.RowCount - 1].Cells["skt"].Value = DateTime.Now.AddYears(1);
            }

            dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["birimFiyat"].Value = birimfiyat;
            lblKalemSayisi.Text = "Kalem Sayısı:" + dgTicaret.RowCount.ToString();
            //  dgTicaret.Rows[dgTicaret.Rows.Count - 1].Cells["Column1"].Value = birimfiyat;
            temizle_stokkartAra();
            hesaplariYap();
        }
        void temizle_stokkartAra()
        {
            txtBarkod.Clear();
            txtSeriNo.Clear();
            txtStokKodu.Clear();
            if (chkMiktarOtomatik.Checked) txtBarkod.Select();
            else dgTicaret.Select();
            cmbUrunAdi.Text = "";


        }
        void hesaplariYap()
        {
            try
            {
                double gecici_aratoplam = 0;
                double gecici_kdvtoplam = 0;
                double _AraTop = 0;
                double ttutar1 = 0;
                if (Convert.ToDouble(dgTicaret.CurrentRow.Cells["birimFiyat"].Value) == 0)
                {
                    double birimfiyat = 0;
                    double aratoplam = Convert.ToDouble(dgTicaret.CurrentRow.Cells["AraTop"].Value);
                    double miktar = Convert.ToDouble(dgTicaret.CurrentRow.Cells["miktar"].Value);
                    double isk = Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk1"].Value);
                    double kdv = Convert.ToDouble(dgTicaret.CurrentRow.Cells["kdv"].Value);
                    double tkdv = (aratoplam * kdv) / 100;
                    double tIsk = (aratoplam * isk) / 100;
                    dgTicaret.CurrentRow.Cells["TopKdv"].Value = tkdv.ToString();
                    dgTicaret.CurrentRow.Cells["Tutar"].Value = tkdv + aratoplam;
                    dgTicaret.CurrentRow.Cells["TOPISK"].Value = tIsk;
                    aratoplam = aratoplam - (aratoplam * isk) / 100;
                    aratoplam = aratoplam + (aratoplam * kdv) / 100;
                    birimfiyat = aratoplam / miktar;
                    dgTicaret.CurrentRow.Cells["birimFiyat"].Value = birimfiyat;
                    ana_toplamlari_hesaplat();
                }
                else
                {
                    //satılan her ürün için miktar*katsayı*birimF*dovizKuru-iskonto+kdv işlemini yapar
                    //if (dgTicaret.CurrentRow.Cells["miktar"].Value.ToString() == "") dgTicaret.CurrentRow.Cells["miktar"].Value = "0";
                    //if (dgTicaret.CurrentRow.Cells["birimFiyat"].Value.ToString() == "") dgTicaret.CurrentRow.Cells["birimFiyat"].Value = "0";
                    if (dgTicaret.CurrentRow.Cells["katsayi"].Value == null) dgTicaret.CurrentRow.Cells["katsayi"].Value = "1";
                    _AraTop = Convert.ToDouble(dgTicaret.CurrentRow.Cells["miktar"].Value) * Convert.ToDouble(dgTicaret.CurrentRow.Cells["birimFiyat"].Value) * Convert.ToDouble(dgTicaret.CurrentRow.Cells["katsayi"].Value);
                    dgTicaret.CurrentRow.Cells["TOPISK"].Value = _AraTop;


                    DataGridViewComboBoxCell kolon2;
                    kolon2 = (DataGridViewComboBoxCell)dgTicaret.CurrentRow.Cells["kdvTipi"];
                    if (kolon2.Value.ToString() == "Dahil")
                    {
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
            }

            catch (Exception hata)
            {
                MessageBox.Show("Hata Metni:" + hata.Message, firma.programAdi);
            }
        }
        private void dgTicaret_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //döviz
            try
            {
                DataGridViewComboBoxCell kolon;
                kolon = (DataGridViewComboBoxCell)dgTicaret.CurrentRow.Cells["dovizTuru"];
                if (kolon.Value.ToString() == "TL") dgTicaret.CurrentRow.Cells["dovizDegeri"].Value = 1;
                else if (kolon.Value.ToString() == "USD") dgTicaret.CurrentRow.Cells["dovizDegeri"].Value = bilgiler.dovizVerileri.dDolarsatis.ToString();
                else if (kolon.Value.ToString() == "ANZ") dgTicaret.CurrentRow.Cells["dovizDegeri"].Value = 1;
                else if (kolon.Value.ToString() == "Euro") dgTicaret.CurrentRow.Cells["dovizDegeri"].Value = bilgiler.dovizVerileri.dEurosatis.ToString();
                //birim
                kolon = (DataGridViewComboBoxCell)dgTicaret.CurrentRow.Cells["birim"];
                dgTicaret.CurrentRow.Cells["katsayi"].Value = stokkart.birimler.bul_stokid(Convert.ToInt64(dgTicaret.CurrentRow.Cells["stokid"].Value)).Where(u => u.birimAdi == kolon.Value.ToString()).First().katsayi.ToString();
                txtCanli2.Text = kolon.Value.ToString();
            }
            catch (Exception)
            {

            }

            //Canlı Stok Getiriliyor
            if (guvenlikVeKontrol.internetVarmi())
            {
                try
                {
                    string canli1 = veri.getdatacell("Select isnull(sum(miktar*katsayi),0) from tblTicaret where stokid =  " + dgTicaret.CurrentRow.Cells["stokid"].Value + " and silindimi = '0' and subeid = " + firma.subeid + " and firmaid = " + firma.firmaid);
                    txtCanli1.Text = canli1;

                    if (rdStokKontrolleriYapilsinEngellesin.Checked && Convert.ToDouble(canli1) - Convert.ToDouble(dgTicaret.CurrentRow.Cells["miktar"].Value) <= 0)
                    {
                        MessageBox.Show(urunBilgisi.urunAdi + " Adlı ürüne ait stoğunuz bulunmamaktadır. Bundan dolayı satış yapamazsınız. Stok ayarlarınızı ayarlar menüsünden değiştirebilirsiniz.", firma.programAdi);
                        dgTicaret.CurrentRow.Cells["miktar"].Value = 1;
                        return;
                    }
                    else if (rdStokKontrolleriYapilsinUyariVersin.Checked && Convert.ToDouble(canli1) - Convert.ToDouble(dgTicaret.CurrentRow.Cells["miktar"].Value) <= 0)
                    {
                        if (MessageBox.Show(urunBilgisi.urunAdi + " Adlı ürüne ait stoğunuz bulunmamaktadır. Yinede satış yapmak istiyor musunuz? Canlı stoğunuz 0'ın altına düşecek.", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            dgTicaret.CurrentRow.Cells["miktar"].Value = 1;
                            return;
                        }
                    }

                }
                catch (Exception)
                {
                }
            }
            if (Convert.ToDouble(dgTicaret.CurrentRow.Cells["birimFiyat"].Value) != 0)
                hesaplariYap();
            txtBarkod.Select();
        }
        private void ana_toplamlari_hesaplat()
        {
            try
            {
                tIskonto_F = txtiskonto.Text;
                tIscilik_F = txtiscilik.Text;
                tNakliyat_F = txtNakliyat.Text;
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
                toplamfiyat = 0;
                for (int i = 0; i < dgTicaret.RowCount; i++)
                {
                    Int64 stokid = Convert.ToInt64(dgTicaret.Rows[i].Cells["stokid"].Value);
                    string sql = "select alisFiyat From tblStokKart where stokid=" + stokid;
                    double fiyat = Convert.ToDouble(veri.getdatacell(sql));
                    toplamfiyat += fiyat * Convert.ToInt64(dgTicaret.Rows[i].Cells["miktar"].Value);
                }
                //  dgTicaret.CurrentRow.Cells["miktar"].Value
                lblToplamKar.Text = (Convert.ToDouble(tGenelToplam_F) - toplamfiyat).ToString() + " ₺";
                cmbUrunAdi.Text = "";

            }
            catch (Exception)
            {
            }
        }
        private void dgTicaret_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void txtCBolgeSec_Click(object sender, EventArgs e)
        {
            frmBolgeSecimi frm = new frmBolgeSecimi();
            frm._frmTicaret = this;
            frm.Show();
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
            string islemTuru1 = islemTuru, islemTuru2 = "";
            string yeri = "Kasa";
            if (islemTuru1.Contains("Postan") || islemTuru1.Contains("Kredi Kartı")) yeri = "Banka";
            //Peşin Satış ve Alış Aktarılıyor
            double alacak = Convert.ToDouble(txtGenelTop.Text), borc = Convert.ToDouble(txtGenelTop.Text);
            if (this.islemTuru.Contains("Alış"))
            {
                borc = Convert.ToDouble(txtGenelTop.Text);
                islemTuru2 = "Alış";
                if (islemTuru.Contains("İade"))
                {
                    islemTuru2 = "Alış İade";
                    if (islemTuru == "Açık Hesap İade")
                    {
                        islemTuru1 = "Açık Hesap";
                        alacak = borc;
                        borc = 0;
                    }
                    else islemTuru1 = "Peşin";

                }
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = islemTuru + " Ödeme";
            }
            else if (this.islemTuru.Contains("Satış"))
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
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = islemTuru + " Tahsilat";
            }


            acikHesap.ekle(0, ticaretAyrintiid, 0, 0, 0, cariid, dtislemTarihi.Value, dtislemTarihi.Value, Convert.ToDateTime(null), borc, alacak, "TL", 1, 0, islemTuru1, islemTuru2, yeri, txtKullaniciAciklamasi.Text, _faturaBilgileri.faturaNo, _faturaBilgileri.belgeNo, _faturaBilgileri.irsaliyeNo, txtVergiDairesi.Text, txtVergiNo.Text, _hesabaislendimi, "0", firma.subeid, firma.kullaniciid, grupid, duzenlemeBakiyesi);
            ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
        }
        bool odemeislemiBaslangici(string _odemeTuru)
        {
            //Ürün Kontrolleri
            if (dgTicaret.Rows.Count == 0)
            {
                MessageBox.Show("Önce listeye ürün ekleyin", firma.programAdi);
                return false;
            }

            if (chbOto.Checked)
            {
                DialogResult dr = MessageBox.Show("E-Fatura göndermek istediğize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (!EFatura.LoginOK)
                    {
                        MessageBox.Show("Kullanıcı bulunamadı!",
                            "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    dr = MessageBox.Show("E-Faturayı gönderirseniz iptal edmesiniz yinede göndermek ister misiniz?",
                        "Uyarı", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) EFatura.OtoGonder = true;
                    else EFatura.OtoGonder = false;
                }
                else EFatura.OtoGonder = false;
            }
            //Cari Kontrolleri
            if (tabCari.TabPages[tabCari.SelectedIndex].Name == "cariTanimlama") cariEkle();
            if ((this.islemTuru.Contains("Sipariş") || this.islemTuru.Contains("Teklif") || this.islemTuru.Contains("Faturalı")) && cariid == 0)
            {
                MessageBox.Show("Lütfen işlem yapılacak cariyi seçin.", firma.programAdi);
                cmbCariListesi.Select();
                tabCari.SelectedIndex = 1;
                return false;
            }
            //Diğer Kontroller
            _hesabaislendimi = "0";
            if (rdHesabaislensin.Checked == true) _hesabaislendimi = "1";
            //Ticaret Tablolarına ekleme işlemleri
            if (islemTuru.Contains("Faturalı") && EFatura.OtoGonder)
            {
                if (EFatura.ListSerial.Count == 0)
                {
                    MessageBox.Show("Lütfen fatura seri numarasını tanımlayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string geciciFaturaNo = EFatura.getEFaturaNo();
                frmFaturaBilgileri frm = new frmFaturaBilgileri(_faturaBilgileri, islemTuru.Contains("Faturalı"));
                if (DialogResult.OK != frm.ShowDialog())
                    return false;
                EFatura.EFaturaNo = _faturaBilgileri.faturaNo;
                DateTime dtFaturaTarihi = EFatura.getEFaturaTarihi(EFatura.EFaturaNo);
                DateTime ilkTarih = new DateTime(Convert.ToDateTime(dtFaturaTarihi).Year, Convert.ToDateTime(dtFaturaTarihi).Month, Convert.ToDateTime(dtFaturaTarihi).Day);
                DateTime ikinciTarih = new DateTime(Convert.ToDateTime(dtislemTarihi.Text).Year, Convert.ToDateTime(dtislemTarihi.Text).Month, Convert.ToDateTime(dtislemTarihi.Text).Day);
                TimeSpan fark = ikinciTarih.Subtract(ilkTarih);
                if (geciciFaturaNo.Length > 0)
                {
                    if (geciciFaturaNo.Substring(0, 3).Equals(_faturaBilgileri.faturaNo.Substring(0, 3)))
                    {
                        if (fark.TotalDays < 0)
                        {
                            MessageBox.Show("Aynı seri numarasına ait fatura daha önce kesilen fatura tarihinden önce kesilemez");
                            return false;
                        }
                    }
                    else
                    {
                        if (fark.TotalDays < -7)
                        {
                            MessageBox.Show("Farklı seri numarasına ait fatura daha önce kesilen fatura tarihinden en fazla 7 gün öncesine kadar kesilebilir");
                            return false;
                        }
                    }
                }
                EFatura.EFaturaNo = _faturaBilgileri.faturaNo;
                EFatura.Aciklama = txtKullaniciAciklamasi.Text;
                MessageBox.Show("Lütfen fatura gönderildi uyarısı alana kadar ekranı kapatmayınız");
            }

            if (grupidVerildimi == false)
            {
                grupid = ticaretAyrinti2.getMaxGrupid() + 1;
                grupidVerildimi = true;
                try
                {
                    string skt;
                    ticaretAyrinti2.ekle(ticaretAyrintiid, cariid, _odemeTuru, dtislemTarihi.Value, txtSaat.Text, _faturaBilgileri.fiiliSefkTarihi, islemTuru, _faturaBilgileri.faturaNo, _faturaBilgileri.belgeNo, _faturaBilgileri.irsaliyeNo, txtVergiDairesi.Text, txtVergiNo.Text, txtAdres.Text, _faturaBilgileri.faturaAciklamasi, txtKullaniciAciklamasi.Text, miktarCarpani * Math.Abs(Convert.ToDouble(txtiskonto.Text)), -1 * miktarCarpani * Convert.ToDouble(txtNakliyat.Text), -1 * miktarCarpani * Convert.ToDouble(txtiscilik.Text), _hesabaislendimi, onay, DateTime.Now, silindimi, firma.subeid, firma.kullaniciid, false, false, grupid);
                    for (int i = 0; i < dgTicaret.Rows.Count; i++)
                    {
                        try
                        {
                            skt = dgTicaret.Rows[i].Cells["skt"].Value.ToString();
                            if (skt != null)
                            {
                                skt = skt.Length == 0
                                    ? null
                                    : dgTicaret.Rows[i].Cells["skt"].Value.ToString();
                            }
                        }
                        catch (Exception e)
                        {
                            skt = null;
                        }
                        ticaret.ekle(Convert.ToInt64(dgTicaret.Rows[i].Cells["ticaretid"].Value), ticaretAyrintiid, Convert.ToInt64(dgTicaret.Rows[i].Cells["stokid"].Value), dgTicaret.Rows[i].Cells["stokkodu"].Value.ToString(), dgTicaret.Rows[i].Cells["barkod"].Value.ToString(), dgTicaret.Rows[i].Cells["urunAdi"].Value.ToString(), miktarCarpani * Math.Abs(Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value)), 0, dgTicaret.Rows[i].Cells["birim"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["katsayi"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["birimFiyat"].Value), Convert.ToInt16(dgTicaret.Rows[i].Cells["kdv"].Value), dgTicaret.Rows[i].Cells["kdvTipi"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk1"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk2"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk3"].Value), dgTicaret.Rows[i].Cells["dovizTuru"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["dovizDegeri"].Value), dgTicaret.Rows[i].Cells["seriNo"].Value.ToString(), DateTime.Now, silindimi, firma.subeid, firma.kullaniciid, false, grupid, skt);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Ticaret Ayrinti ve Ticaret Ekleme İşleminde Hata Meydana Geldi , Hata:" + ex.Message);
                }

                try
                {
                    if (cmbPersonelAdlari.SelectedIndex != -1)
                    {
                        long personelID = listeler.getPersonelid()[cmbPersonelAdlari.SelectedIndex];
                        if (personelID > 0) veri.cmd("exec [spSetPersonelMaas] 0," + personelID + ",'" + txtPrimTutari.Text.Replace(".", "").Replace(",", ".") + "','Prim Girişi','" + dtislemTarihi.Value + "','" + txtSaat.Text + "','Satıştan Kazanılan Prim'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + "");
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Prim eklenirken hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
                }
                //if (chkOtoYazdir.Checked && _odemeTuru=="Peşin") yazdirVeonizle("yazdir", _odemeTuru);
            }
            _faturaBilgileri.faturaNo = null;
            return true;
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

        public double _pesinat = 0;
        void formTemizle()
        {
            if (this.Text.Contains("Düzenle")) this.Close();
            grupidVerildimi = false;
            // _faturaBilgileri = new faturaBilgileri();
            _pesinat = 0;
            eskiBakiye = 0;
            duzenlemeBakiyesi = 0;
            onay = "0";
            gonderenSubeid = 0;
            alanSubeid = 0;
            tAraToplam_F = "0";
            tKdvtutar_F = "0";
            tIskonto_F = "0";
            tIscilik_F = "0";
            tNakliyat_F = "0";
            tGenelToplam_F = "0";
            tIskToplam = 0;
            txtToplam.Text = tAraToplam_F;
            txtKdvTop.Text = tKdvtutar_F;
            txtGenelTop.Text = tGenelToplam_F;
            txtCanli1.Text = "0";
            txtCanli2.Text = "";
            txtKullaniciAciklamasi.Clear();
            txtSaat.Text = DateTime.Now.ToShortTimeString();
            temizle_stokkartAra();
            cariTemizle();
            dgTicaret.Rows.Clear();
            pnlAyrintiliSatis.Visible = false;
            txtNakit1.Text = "0";
            txtNakit2.Text = "0";
            lblToplamKar.Text = "";
            toplamfiyat = 0;
        }
        private void btnAyrintiliSatis_Click(object sender, EventArgs e)
        {
            //Ürün Kontrolleri
            if (dgTicaret.Rows.Count == 0)
            {
                MessageBox.Show("Önce listeye ürün ekleyin", firma.programAdi);
                return;
            }

            //Cari Kontrolleri
            //if (tabCari.TabPages[tabCari.SelectedIndex].Name == "cariTanimlama") cariEkle();
            //else if (cariid == 0)
            //{
            //    MessageBox.Show("Lütfen işlem yapılacak cariyi seçin.", firma.programAdi);
            //    cmbCariListesi.Select();
            //    tabCari.SelectedIndex = 1;
            //    return;
            //}

            pnlAyrintiliSatis.Visible = true;
            pnlAyrintiliSatis.BringToFront();
            pnlAyrintiliSatis.Select();

            //_frmOdemeSecenekleri = new frmOdemeSecenekleri(dtislemTarihi.Value, islemTuru, this);
            //_frmOdemeSecenekleri.Show();
        }
        private void btniptal_Click(object sender, EventArgs e)
        {
            formTemizle();
        }
        private void pnlUst_Paint(object sender, PaintEventArgs e)
        {
        }
        private void btnFaturaAyarlari_Click(object sender, EventArgs e)
        {
            frmFaturaBilgileri frm = new frmFaturaBilgileri(_faturaBilgileri, islemTuru.Contains("Faturalı"));
            frm.Show();
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
                string cari = cmbCariListesi.Text.ToString();
                string islemTuru = this.islemTuru.ToString();
                dgTicaret.Rows.Remove(dgTicaret.CurrentRow);
                veri.cmd(@"INSERT INTO [dbo].[tblSilinenSatislar] ([Barkod] ,[UrunAdi] ,[Miktar],[Fiyat],[AraTop],[Toplam],[Cari],[IslemTuru],[FirmaID] ,[SubeID],[KullaniciID]) values ('" + barkod + "','" + urunAdi + "','" + miktar.Replace(",", ".") + "'," + fiyat.ToString().Replace(",", ".") + "," + araTop.ToString().Replace(",", ".") + "," + toplam.ToString().Replace(",", ".") + ",'" + cari + "','" + islemTuru + "', " + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");

                ana_toplamlari_hesaplat();

            }
            catch
            {
            }
        }

        private void txtiskonto_Leave(object sender, EventArgs e)
        {
            ana_toplamlari_hesaplat();
        }
        private void btnislemiBitir_Click(object sender, EventArgs e)
        {
            if (odemeislemiBaslangici(islemTuru) == false) return;
            if (islemTuru.Contains("İade")) pesinislem("İade");
            ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
            yeniKayit();
        }
        private void btnCariSecimi_Click(object sender, EventArgs e)
        {
            frmAyrintiliCariListele frm = new frmAyrintiliCariListele(this);
            frm.Show();
        }
        private void btnAcikHesap_Click(object sender, EventArgs e)
        {
            if (tabCari.TabPages[tabCari.SelectedIndex].Name == "cariTanimlama") cariEkle();
            if (cariid == 0)
            {
                MessageBox.Show("Lütfen işlem yapılacak cariyi seçin.", firma.programAdi);
                cmbCariListesi.Select();
                tabCari.SelectedIndex = 1;
                return;
            }
            if (odemeislemiBaslangici("Açık Hesap") == false) return;
            string islemTuru2 = "";
            if (islemTuru.Contains("Alış"))
            {
                islemTuru2 = "Alış";
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = "Açık Hesaplı Alış";
            }
            else if (islemTuru.Contains("Satış"))
            {
                islemTuru2 = "Satış";
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = "Açık Hesaplı Satış";
            }

            frmOdemeVeTahsilat frm = new frmOdemeVeTahsilat(cariid, cmbCariListesi.Text, txtGenelTop.Text, islemTuru2, dtislemTarihi.Value, grupid, ticaretAyrintiid, txtKullaniciAciklamasi.Text, duzenlemeBakiyesi);
            frm._frmTicaret = this;
            if (frm.ShowDialog() != DialogResult.OK) grupidVerildimi = false;

        }
        private void btnOdemeSecenekleriMenusunuKapat_Click(object sender, EventArgs e)
        {
            pnlAyrintiliSatis.Visible = false;
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
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = "Pos ile Satış";
            }

            frmBankaPosTaksitleriGoruntule frm = new frmBankaPosTaksitleriGoruntule(cariid, cmbCariListesi.Text, txtGenelTop.Text, islemTuru2, dtislemTarihi.Value, grupid, ticaretAyrintiid, txtKullaniciAciklamasi.Text);
            frm._frmTicaret = this;
            frm.Show();
        }

        private void btnTaksit_Click(object sender, EventArgs e)
        {
            if (tabCari.TabPages[tabCari.SelectedIndex].Name == "cariTanimlama") cariEkle();
            if (cariid == 0)
            {
                MessageBox.Show("Lütfen işlem yapılacak cariyi seçin.", firma.programAdi);
                cmbCariListesi.Select();
                tabCari.SelectedIndex = 1;
                return;
            }
            if (odemeislemiBaslangici("Taksitli") == false) return;
            string islemTuru2 = "";
            if (islemTuru.Contains("Alış"))
            {
                islemTuru2 = "Alış";
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = "Taksitli Alış";
            }
            else if (islemTuru.Contains("Satış"))
            {
                islemTuru2 = "Satış";
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = "Taksitli Satış";
            }

            frmTaksitlendirme frm = new frmTaksitlendirme(cariid, cmbCariListesi.Text, txtGenelTop.Text, islemTuru2, dtislemTarihi.Value, grupid, ticaretAyrintiid, txtKullaniciAciklamasi.Text);
            frm._frmTicaret = this;
            frm.Show();
        }

        private void btnKrediKarti_Click(object sender, EventArgs e)
        {
            if (odemeislemiBaslangici("Kredi Kartı") == false) return;
            string islemTuru2 = "";
            if (islemTuru.Contains("Satış"))
            {
                MessageBox.Show("Kredi Kartı ile Satış işlemi yapılamaz.", firma.programAdi);
            }
            else if (islemTuru.Contains("Alış"))
            {
                islemTuru2 = "Alış";
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = "Kredi Kartı ile Alış";
            }

            frmBankaKrediKartiileOdeme frm = new frmBankaKrediKartiileOdeme(cariid, cmbCariListesi.Text, txtGenelTop.Text, islemTuru2, dtislemTarihi.Value, grupid, ticaretAyrintiid, txtKullaniciAciklamasi.Text);
            frm._frmTicaret = this;
            frm.Show();
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

        private void cmbUrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                urunBilgisi = stokkart.bul_urunAdi(cmbUrunAdi.Text);
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

        private void cmbYazicilistesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            islemler.yaziciislemleri.yaziciAyarla(cmbYazicilistesi.Text);
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Yazıcı", cmbYazicilistesi.Text);
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Yazıcı", cmbYazicilistesi.Text);
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Yazıcı", cmbYazicilistesi.Text);
            else if (this.islemTuru == "Satış İade") ayarlar.ayarla_manuel("İade_Satış_Yazıcı", cmbYazicilistesi.Text);
            else if (this.islemTuru == "Faturasız Alış") ayarlar.ayarla_manuel("Faturasız_Alış_Yazıcı", cmbYazicilistesi.Text);
            else if (this.islemTuru == "Faturalı Alış") ayarlar.ayarla_manuel("Faturalı_Alış_Yazıcı", cmbYazicilistesi.Text);
            else if (this.islemTuru == "Alış İade") ayarlar.ayarla_manuel("İade_Alış_Yazıcı", cmbYazicilistesi.Text);
            else if (this.islemTuru == "Teklif") ayarlar.ayarla_manuel("Teklif_Yazıcı", cmbYazicilistesi.Text);
            else if (this.islemTuru == "Sipariş") ayarlar.ayarla_manuel("Sipariş_Yazıcı", cmbYazicilistesi.Text);
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

        private void btnOnizleme_Click(object sender, EventArgs e)
        {
            yazdirVeonizle("onizle", "Peşin");
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
            List<KeyValuePair<int, double>> listKeyValueKDVler1 = new List<KeyValuePair<int, double>>();

            for (int i = 0; i < dgTicaret.Rows.Count; i++)
            {
                DataGridViewRow r = dgTicaret.Rows[i];

                int kdv = Convert.ToInt16(r.Cells["kdv"].Value);
                double kdvToplam = Convert.ToDouble(r.Cells["TopKdv"].Value);
                //  double kdvToplam = Convert.ToDouble(r.Cells["TopKdv"].Value);

                listKeyValueKDVler.Add(new KeyValuePair<int, double>(kdv, kdvToplam));

                _listT.Add(new faturaYazdir.cT(r.Cells["barkod"].Value.ToString(), r.Cells["urunAdi"].Value.ToString(), Convert.ToDouble(r.Cells["miktar"].Value), kdv, r.Cells["kdvTipi"].Value.ToString(), r.Cells["birim"].Value.ToString(), Convert.ToDouble(r.Cells["birimFiyat"].Value), Convert.ToDouble(r.Cells["isk1"].Value), Convert.ToDouble(r.Cells["isk2"].Value), Convert.ToDouble(r.Cells["isk3"].Value), Convert.ToDouble(r.Cells["araTop"].Value), kdvToplam, Convert.ToDouble(r.Cells["tutar"].Value), r.Cells["dovizTuru"].Value.ToString()));
            }
            for (int i = 0; i < dgTicaret.Rows.Count; i++)
            {
                DataGridViewRow r = dgTicaret.Rows[i];

                int kdv = Convert.ToInt16(r.Cells["kdv"].Value);
                double kdvToplam = Convert.ToDouble(r.Cells["tutar"].Value);
                //  double kdvToplam = Convert.ToDouble(r.Cells["TopKdv"].Value);
                listKeyValueKDVler1.Add(new KeyValuePair<int, double>(kdv, kdvToplam));
            }
            //string EskiBakiye = String.Format("{0:n2}", Convert.ToDouble(veri.getdatacell("select sum(bakiye) from sorCariBakiye where firmaid = " + firma.firmaid + " and cariid = " + cariid + "")));
            faturaYazdir fYazdir = new faturaYazdir(faturaTipi, new faturaYazdir.cTA(ticaretAyrintiid, Convert.ToDouble(txtToplam.Text), Convert.ToDouble(txtKdvTop.Text), Convert.ToDouble(txtiskonto.Text), Convert.ToDouble(txtNakliyat.Text), Convert.ToDouble(txtiscilik.Text), Convert.ToDouble(txtGenelTop.Text), tIskToplam, dtislemTarihi.Value, txtSaat.Text, _odemeTuru, _faturaBilgileri.faturaNo, _faturaBilgileri.faturaAciklamasi, listKeyValueKDVler), new faturaYazdir.cC(cmbCariListesi.Text, txtVergiDairesi.Text, txtVergiNo.Text, "", txtAdres.Text, eskiBakiye, _pesinat, miktarCarpani, duzenlemeBakiyesi), _listT);
            fYazdir.keyValueKDVler1 = listKeyValueKDVler1;
            if (_islem == "onizle") fYazdir.onizle();
            else fYazdir.yazdir();
        }

        double eskiBakiye = 0;

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            yazdirVeonizle("yazdir", "Peşin");
        }

        private void chkOtoYazdir_Click(object sender, EventArgs e)
        {
            //burda kaldım.
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

        private void chkKartliSatis_Click(object sender, EventArgs e)
        {
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Kartlı_Satış", Convert.ToByte(chkKartliSatis.Checked).ToString());
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Satış_Kartlı_Satış", Convert.ToByte(chkKartliSatis.Checked).ToString());
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Kartlı_Satış", Convert.ToByte(chkKartliSatis.Checked).ToString());
            else if (this.islemTuru == "Satış İade") ayarlar.ayarla_manuel("İade_Satış_Kartlı_Satış", Convert.ToByte(chkKartliSatis.Checked).ToString());
            else if (this.islemTuru == "Faturasız Alış") ayarlar.ayarla_manuel("Faturasız_Alış_Kartlı_Satış", Convert.ToByte(chkKartliSatis.Checked).ToString());
            else if (this.islemTuru == "Faturalı Alış") ayarlar.ayarla_manuel("Faturalı_Alış_Kartlı_Satış", Convert.ToByte(chkKartliSatis.Checked).ToString());
            else if (this.islemTuru == "Alış İade") ayarlar.ayarla_manuel("İade_Alış_Kartlı_Satış", Convert.ToByte(chkKartliSatis.Checked).ToString());
        }

        List<int> listSatisFiyatlari = new List<int>();

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

        private void cmbGecerliSatisFiyati_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Satış_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            else if (this.islemTuru == "Satış İade") ayarlar.ayarla_manuel("İade_Satış_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            else if (this.islemTuru == "Teklif") ayarlar.ayarla_manuel("Teklif_Fiyatı", listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex].ToString());
            gecerliFiyatid = listSatisFiyatlari[cmbGecerliSatisFiyati.SelectedIndex];
        }

        private void rdStokKontrolleriYapilmasin_Click(object sender, EventArgs e)
        {
            RadioButton sndr = (RadioButton)sender;
            if (this.islemTuru == "Faturasız Satış") ayarlar.ayarla_manuel("Faturasız_Satış_Stok_Kontrolleri_Tipi", sndr.Tag.ToString());
            else if (this.islemTuru == "Transfer") ayarlar.ayarla_manuel("Transfer_Stok_Kontrolleri_Tipi", sndr.Tag.ToString());
            else if (this.islemTuru == "Faturalı Satış") ayarlar.ayarla_manuel("Faturalı_Satış_Stok_Kontrol_Tipi", sndr.Tag.ToString());
        }

        private void frmTicaret_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (btnPesinSatis.Visible == true) btnPesinSatis_Click(sender, e);
                else if (btnislemiBitir.Visible == true) btnislemiBitir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnPos_Click(sender, e);
            }
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
            else if (e.KeyCode == Keys.F7)
            {
                seçiliSatırıSilToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btniptal_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtBarkod.Select();
            }
            else if (e.KeyCode == Keys.F6)
            {
                txtNakit1.Select();
                txtNakit1.Text = "0";
            }
        }

        private void btnTransferYap_Click(object sender, EventArgs e)
        {
            //Ürün Kontrolleri
            if (dgTicaret.Rows.Count == 0)
            {
                MessageBox.Show("Önce listeye transfer edilecek stokları ekleyin", firma.programAdi);
                txtBarkod.Select();
                return;
            }
            //Şube Kontrolleri Yapılıyor.
            if (gonderenSubeid == 0)
            {
                MessageBox.Show("Gönderen şubeyi listeden seçin.", firma.programAdi);
                cmbStokGonderenSube.Select();
                return;
            }
            if (alanSubeid == 0)
            {
                MessageBox.Show("Alıcı şubeyi listeden seçin.", firma.programAdi);
                cmbStokAlanSube.Select();
                return;
            }
            if (gonderenSubeid == alanSubeid)
            {
                MessageBox.Show("Gönderen ve alan şube aynı olamaz.", firma.programAdi);
                cmbStokGonderenSube.Select();
                return;
            }
            //Diğer Kontroller
            _hesabaislendimi = "0";
            if (rdHesabaislensin.Checked == true) _hesabaislendimi = "1";
            //Ticaret Tablolarına ekleme işlemleri
            if (transferislemiBaslangici("Giden Transfer", -1, gonderenSubeid) == false) return;
            ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
            if (transferislemiBaslangici("Gelen Transfer", 1, alanSubeid) == false) return;
            ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
            yeniKayit();
        }

        bool transferislemiBaslangici(string _islemTipi, short _miktarCarpani, int _subeid)
        {
            grupid = ticaretAyrinti2.getMaxGrupid() + 1;
            if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = cmbStokGonderenSube.Text + "/" + cmbStokAlanSube.Text;
            ticaretAyrinti2.ekle(ticaretAyrintiid, cariid, "", dtislemTarihi.Value, txtSaat.Text, _faturaBilgileri.fiiliSefkTarihi, _islemTipi, _faturaBilgileri.faturaNo, _faturaBilgileri.belgeNo, _faturaBilgileri.irsaliyeNo, txtVergiDairesi.Text, txtVergiNo.Text, txtAdres.Text, _faturaBilgileri.faturaAciklamasi, txtKullaniciAciklamasi.Text, _miktarCarpani * Math.Abs(Convert.ToDouble(txtiskonto.Text)), _miktarCarpani * Convert.ToDouble(txtNakliyat.Text), -1 * _miktarCarpani * Convert.ToDouble(txtiscilik.Text), _hesabaislendimi, onay, DateTime.Now, silindimi, _subeid, firma.kullaniciid, false, false, grupid);
            for (int i = 0; i < dgTicaret.Rows.Count; i++)
            {
                ticaret.ekle(Convert.ToInt64(dgTicaret.Rows[i].Cells["ticaretid"].Value), ticaretAyrintiid, Convert.ToInt64(dgTicaret.Rows[i].Cells["stokid"].Value), dgTicaret.Rows[i].Cells["stokkodu"].Value.ToString(), dgTicaret.Rows[i].Cells["barkod"].Value.ToString(), dgTicaret.Rows[i].Cells["urunAdi"].Value.ToString(), _miktarCarpani * Math.Abs(Convert.ToDouble(dgTicaret.Rows[i].Cells["miktar"].Value)), 0, dgTicaret.Rows[i].Cells["birim"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["katsayi"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["birimFiyat"].Value), Convert.ToInt16(dgTicaret.Rows[i].Cells["kdv"].Value), dgTicaret.Rows[i].Cells["kdvTipi"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk1"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk2"].Value), Convert.ToDouble(dgTicaret.Rows[i].Cells["isk3"].Value), dgTicaret.Rows[i].Cells["dovizTuru"].Value.ToString(), Convert.ToDouble(dgTicaret.Rows[i].Cells["dovizDegeri"].Value), dgTicaret.Rows[i].Cells["seriNo"].Value.ToString(), DateTime.Now, silindimi, _subeid, firma.kullaniciid, false, grupid);
            }
            return true;
        }

        private void cmbStokGonderenSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            gonderenSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbStokGonderenSube));
        }

        private void cmbStokAlanSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            alanSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbStokAlanSube));
        }

        private void btnYaziciAyarlari_Click(object sender, EventArgs e)
        {
            yazdirVeonizle("ayarla", "Peşin");
        }

        private void pnlAlt_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btniadeAcikHesap_Click(object sender, EventArgs e)
        {
            //Cari Kontrolleri
            if (tabCari.TabPages[tabCari.SelectedIndex].Name == "cariTanimlama") cariEkle();
            else if (cariid == 0)
            {
                MessageBox.Show("Lütfen işlem yapılacak cariyi seçin.", firma.programAdi);
                cmbCariListesi.Select();
                tabCari.SelectedIndex = 1;
                return;
            }
            if (odemeislemiBaslangici(islemTuru) == false) return;
            if (islemTuru.Contains("İade")) pesinislem("Açık Hesap İade");
            ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
            yeniKayit();
        }

        private void btnCekSenet_Click(object sender, EventArgs e)
        {
            if (tabCari.TabPages[tabCari.SelectedIndex].Name == "cariTanimlama") cariEkle();
            if (cariid == 0)
            {
                MessageBox.Show("Lütfen işlem yapılacak cariyi seçin.", firma.programAdi);
                cmbCariListesi.Select();
                tabCari.SelectedIndex = 1;
                return;
            }
            if (odemeislemiBaslangici("Çek-Senet") == false) return;
            string islemTuru2 = "";
            if (islemTuru.Contains("Alış"))
            {
                islemTuru2 = "Alış";
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = "Çek-Senetli Alış";
            }
            else if (islemTuru.Contains("Satış"))
            {
                islemTuru2 = "Satış";
                if (txtKullaniciAciklamasi.Text == "") txtKullaniciAciklamasi.Text = "Çek-Senetli Satış";
            }

            frmCekSenetileTahsilatveOdeme frm = new frmCekSenetileTahsilatveOdeme(cariid, cmbCariListesi.Text, txtGenelTop.Text, islemTuru2, dtislemTarihi.Value, grupid, ticaretAyrintiid, txtKullaniciAciklamasi.Text, duzenlemeBakiyesi);
            frm._frmTicaret = this;
            frm.Show();
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

        private void dgTicaret_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (cariid == 0) return;
                if (dgTicaret.Columns["urunAdi"].Index == e.ColumnIndex || dgTicaret.Columns["barkod"].Index == e.ColumnIndex)
                    if (lblCariFiyat.Text == "")
                    {
                        //pnlCariFiyat.Visible = true;
                        //pnlCariFiyat.Location = new Point(e.X, e.Y + 150);
                        DataGridViewComboBoxCell kolon;
                        kolon = (DataGridViewComboBoxCell)dgTicaret.Rows[e.RowIndex].Cells["birim"];
                        string sonFiyat = veri.getdatacell("Select Top 1 birimFiyat from sorTicaret Where cariid = " + cariid + " and stokid = " + dgTicaret.Rows[e.RowIndex].Cells["stokid"].Value.ToString() + " and birim = '" + kolon.Value.ToString() + "'");
                        lblCariFiyat.Text = "Ürünün Cariye Son Satış Fiyatı: " + String.Format("{0:n2}", Convert.ToDouble(sonFiyat));
                    }
            }
            catch (Exception)
            {

            }
        }

        private void btnFiyatGizle_Click(object sender, EventArgs e)
        {
            //pnlCariFiyat.Visible = false;
            //lblCariFiyat.Text = "";
        }

        private void dgTicaret_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //pnlCariFiyat.Visible = false;
            //lblCariFiyat.Text = "";
        }

        internal void EnabledAyarla()
        {
            tabCari.Enabled = txtStokKodu.Enabled = txtSeriNo.Enabled = txtBarkod.Enabled = cmbUrunAdi.Enabled = seçiliSatırıSilToolStripMenuItem.Enabled = false;
        }

        private void cariyeSatilanSeciliUrunFiyatlariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabCari.SelectedTab != cariSecimi)
            {
                MessageBox.Show("Bu İşlem İçin Cari Seçin!");
                return;
            }
            if (cariid == 0)
            {
                MessageBox.Show("Lütfen işlem yapılacak cariyi seçin.", firma.programAdi);
                cmbCariListesi.Select();
                tabCari.SelectedIndex = 1;
                return;
            }

            if (dgTicaret.CurrentRow.Cells["stokid"].Value == null)
            {
                MessageBox.Show("Ürün Seçin");
                return;
            }

            long stokID = Convert.ToInt64(dgTicaret.CurrentRow.Cells["stokid"].Value);

            FrmCariyeSatilanUrunFiyatlari frm = new FrmCariyeSatilanUrunFiyatlari(cariid, stokID);
            frm.ShowDialog();
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
        void alisFiyati(long stokID)
        {
            string toplam = txtGenelTop.Text;
            try
            {
                string sql = "select alisFiyat From tblStokKart where stokid=" + stokID;
                double fiyat = Convert.ToDouble(veri.getdatacell(sql));
                toplamfiyat += fiyat;
                lblToplamKar.Text = (Convert.ToDouble(tGenelToplam_F) - toplamfiyat).ToString() + " ₺";
            }
            catch (Exception)
            {
            }

        }

        private void txtGenelTop_TextChanged(object sender, EventArgs e)
        {
            primHesapla();
        }

        private void txtPrimYuzdesi_TextChanged(object sender, EventArgs e)
        {
            primHesapla();
        }

        private void cmbCariListesi_TextChanged(object sender, EventArgs e)
        {
            getCari();
        }

        private void chbKDV_CheckedChanged(object sender, EventArgs e)
        {
            if (chbKDV.Checked)
            {
                for (int i = 0; i < dgTicaret.RowCount; i++)
                {
                    dgTicaret.Rows[i].Cells["KDV"].Value = 0;
                    dgTicaret.Rows[i].Cells["KDV"].Selected = true;
                    double gecici_aratoplam = 0;
                    double _AraTop = 0;

                    if (dgTicaret.CurrentRow.Cells["katsayi"].Value == null)
                        dgTicaret.CurrentRow.Cells["katsayi"].Value = "1";
                    _AraTop = Convert.ToDouble(dgTicaret.CurrentRow.Cells["miktar"].Value) *
                              Convert.ToDouble(dgTicaret.CurrentRow.Cells["birimFiyat"].Value) *
                              Convert.ToDouble(dgTicaret.CurrentRow.Cells["katsayi"].Value);
                    dgTicaret.CurrentRow.Cells["TOPISK"].Value = _AraTop;

                    gecici_aratoplam = _AraTop;

                    dgTicaret.CurrentRow.Cells["TOPISK"].Value = gecici_aratoplam;
                    gecici_aratoplam = gecici_aratoplam -
                                       gecici_aratoplam * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk1"].Value) /
                                       100;
                    gecici_aratoplam = gecici_aratoplam -
                                       gecici_aratoplam * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk2"].Value) /
                                       100;
                    gecici_aratoplam = gecici_aratoplam -
                                       gecici_aratoplam * Convert.ToDouble(dgTicaret.CurrentRow.Cells["isk3"].Value) /
                                       100;
                    dgTicaret.CurrentRow.Cells["TOPISK"].Value =
                        Convert.ToDouble(dgTicaret.CurrentRow.Cells["TOPISK"].Value) - gecici_aratoplam;

                    dgTicaret.CurrentRow.Cells["TopKdv"].Value = 0;
                    dgTicaret.CurrentRow.Cells["AraTop"].Value = gecici_aratoplam.ToString();
                    dgTicaret.CurrentRow.Cells["Tutar"].Value = gecici_aratoplam;
                }
                ana_toplamlari_hesaplat();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (EFatura.EFaturaID == 0) return;
            string vk = txtVergiNo.Text;
            if (vk.Trim().Length == 0) vk = txtCVergiNo.Text;
            if (vk.Length == 0) return;
            List<FormParameters> getFormParameters = servis.Current_CheckUser_byIdentifier(vk);

            if (getFormParameters != null)
            {
                foreach (var parameter in getFormParameters)
                {
                    //add settings items
                    string[] infos = { parameter.ActionName, Convert.ToString(parameter.ActionElapsedMs / 1000), parameter.ActionElapsedMs.ToString() };
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (FormValues.checkUserEnter == "Kullanıcı arama tamamlandı..")
            {
                if (FormValues.vknUser != null)
                {
                    EFatura.AliciGB = FormValues.vknUser[0].ALIAS.ToString();
                    txtCAdi.Text = FormValues.vknUser[0].TITLE.ToString();
                }
                else EFatura.AliciGB = "";
            }
            else EFatura.AliciGB = "";
        }

        private void chbOto_CheckedChanged(object sender, EventArgs e)
        {
            if (chbOto.Checked) EFatura.OtoGonder = true;
            else EFatura.OtoGonder = false;
        }

        private void txtCVergiNo_TextChanged(object sender, EventArgs e)
        {
            if (txtCVergiNo.Text.Length >= 10)
            {
                try
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnFiyatUygula_Click(object sender, EventArgs e)
        {

        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {

        }

        private void primHesapla()
        {
            if (txtPrimYuzdesi.Text.Trim() == "") txtPrimYuzdesi.Text = "10";

            int yuzde = Convert.ToInt32(txtPrimYuzdesi.Text);

            txtPrimTutari.Text = (Convert.ToDouble(txtGenelTop.Text) * yuzde / 100d).ToString();
        }
    }
}