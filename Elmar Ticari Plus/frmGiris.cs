using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading;
using elmarLibrary;
using fonksiyonlarim;
using System.Collections.Generic;
using NLog;
using CurrentEDMConnectorClientLibrary;
using Elmar_Ticari_Plus.EDMService;
using System.IO;

namespace Elmar_Ticari_Plus
{
    public partial class frmGiris : Form
    {
        private string _path = System.Configuration.ConfigurationSettings.AppSettings["Path"].ToString();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private SEFatura tester;
        public frmGiris()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            NesneGorselleri.form(this, false);
            NesneGorselleri.kontrolEkle(panel3);
            this.StartPosition = FormStartPosition.CenterScreen;
            veri.server = "176.53.32.55";
            veri.db = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.1000110.1110001.1100000.1011000.1100111.1000010.1010011.1010100.1000001.1011011.1110111.1000101.1111101.1011001.1011100.1011100.1001001.10001011.1100101.10001001.10000110.1110110.1001111.", 8), "mykfs");
            veri.kadi = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.1000110.1001011.111010.1110111.10000110.1000101.1010100.1100110.1000001.1110110.10001000.1001001.1001110.1111100.10001101.1111110.1001001.1001001.1100000.10010001.10000000.1101011.1101000.", 8), "mykfs");
            veri.sifre = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.111001.1111001.1001111.1000011.1010100.1010101.1000110.1011111.1111010.10000110.1100110.1000111.1010111.10000011.10001111.1101110.1110011.1100001.1101111.10010011.10010101.1001111.1110000.1110111.1011001.1010010.1101001.1101100.1111011.10011110.1011111.1110001.10011000.1011111.1111101.10011111.1110110.1011001.10000100.10000101.1100000.1110101.10101000.", 8), "mykfs");

        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = veri.getdatatable("Select top 1 * from tblUyarilar where firmaid =0 and aktifmi=1  order by uyariid desc");
                if (dt.Rows.Count > 0)
                    if (Convert.ToInt32(dt.Rows[0]["uyariid"]) != Convert.ToInt32(Properties.Settings.Default["uyariid"]))
                        new FrmUyarı(dt).ShowDialog();
            }
            catch
            { }
            txtKullaniciAdi.Select();
            alarm.kontrolMotorunuCalistir();
            ortamDegiskeniniGuncelle();
            if (ortam == "hastane")
            {
                pictureBox1.Image = Properties.Resources.icon;
                this.Text = "Bakım Merkezi Sistemi Giriş Paneli";
            }
            kanal = new Thread(new ThreadStart(guncellemeKontroluYap));
            kanal.Start();
            if (System.IO.Directory.Exists(Application.StartupPath + "\\KullanıcıResimleri\\logo") == false) System.IO.Directory.CreateDirectory(Application.StartupPath + "\\KullanıcıResimleri\\logo");
        }

        Thread kanal;
        private void btnGiris_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtKullaniciAdi.Text == "")
                {
                    MessageBox.Show("Kullanıcı adını girmediniz", firma.programAdi);
                    txtKullaniciAdi.Select();
                    return;
                }
                if (txtSifre.Text == "")
                {
                    MessageBox.Show("Şifreyi girmediniz", firma.programAdi);
                    txtSifre.Select();
                    return;
                }
                if (txtKullaniciAdi.Text.Contains(" "))
                {
                    MessageBox.Show("Kullanıcı Adı Boşluk Karakteri İçeremez", firma.programAdi);
                    txtKullaniciAdi.Select();
                    return;
                }
                if (txtKullaniciAdi.Text.Contains("é"))
                {
                    MessageBox.Show("Kullanıcı Adı 'é' özel karakterini içeremez.", firma.programAdi);
                    txtKullaniciAdi.Select();
                    return;
                }
                string tektenVt = "ElmarTicariPlus_Tekten";
                veri.db = tektenVt;
                git:

                lblBilgi.Text = "Lütfen Bekleyin..";
                this.Refresh();
                string girisMesaji = "";
                string girisizni = "0";
                string onlinemi = "0";
                SqlDataReader dr = veri.getDatareader("exec [spGirisKontrol] '" + txtKullaniciAdi.Text + "','" + txtSifre.Text + "'");
                while (dr.Read())
                {
                    firma.kullaniciAdi = txtKullaniciAdi.Text;
                    firma.firmaid = Convert.ToInt32(dr[0]);
                    firma.subeid = Convert.ToInt32(dr[1].ToString());
                    firma.kullaniciid = Convert.ToInt32(dr[2].ToString());

                    if (firma.firmaid == 0 && veri.db == tektenVt)
                    {
                        veri.db = "ElmarTicariPlus";
                        goto git;
                    }

                    else if (firma.firmaid == 0 && veri.db == "ElmarTicariPlus")
                    {
                        veri.db = "ElmarTicariPlus2017";

                        goto git;
                    }
                    //else if (firma.firmaid == 0 && veri.db == "ElmarTicariPlus2017")
                    // {
                    //     veri.db = "ElmarTicariPlus2018";                  
                    //     goto git;
                    // }
                    firma.sw = new Stopwatch();
                    firma.sw.Start();
                    girisizni = dr[3].ToString();
                    onlinemi = dr[4].ToString();
                    firma.demoKalanGun = dr[5].ToString();
                    firma.demomu = dr[6].ToString();
                    firma.gorevi = "Yönetici";
                    girisMesaji = dr[7].ToString();
                    firma.muhasebe = "1";
                    firma.personel = dr[8].ToString();
                    firma.hastane = dr[11].ToString();
                    firma.otel = dr[12].ToString();
                    firma.yurt = dr[13].ToString();
                    if (dr["hastane"].ToString() == "1") firma.programAdi = "BMS";
                    else if (dr["otel"].ToString() == "1") firma.programAdi = "Elmar Otel Otomasyonu";
                    else if (dr["yurt"].ToString() == "1") firma.programAdi = "Elmar Yurt Otomasyonu";
                    else if (dr["adisyon"].ToString() == "1") firma.programAdi = "Elmar Adisyon";
                    else if (dr["uretim"].ToString() == "1") firma.programAdi = "Elmar Ticari Plus | Üretim";
                    else if (dr["personel"].ToString() == "1") firma.programAdi = "Elmar Ticari Plus | Personel";
                    else firma.programAdi = "Elmar Ticari Plus";
                }
                if (girisizni == "0")
                {
                    MessageBox.Show(girisMesaji, firma.programAdi);
                    lblBilgi.Text = "Hazır";
                    return;
                }
                else
                {
                    if (girisMesaji != "")
                    {
                        MessageBox.Show(girisMesaji, firma.programAdi);
                    }
                    //Ana Forma Giriş Yapılıyor.
                    firma.firmaAdi = veri.getdatacell("Select adi from tblFirmaBilgileri Where firmaid=" + firma.firmaid);
                    verileriCekVeGirisYap();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void verileriCekVeGirisYap()
        {
            p1.Value = 0;
            p1.Value++;
            //aktif online kullanıcı yapılması sağlanıyor.
            veri.cmd("exec spKullaniciGirisiYapildi '" + bilgiler.ip_al() + "', " + firma.kullaniciid + "");
            if (firma.hastane == "1")
            {
                Process.Start(Application.StartupPath + "\\BakımMerkezi.exe", firma.parametreGegerleriniOlustur());
                Application.Exit();
                Application.ExitThread();
                return;
            }
            else if (firma.yurt == "1")
            {
                Process.Start(Application.StartupPath + "\\Yurt Elmar Yazılım.exe", firma.parametreGegerleriniOlustur());
                Application.Exit();
                Application.ExitThread();
                return;
            }
            p1.Value++;
            //firma Bilgileri Çekiliyor
            lblBilgi.Text = "Firma Bilgileri Güncelleniyor";
            this.Refresh();
            guncelle.firmaVerileriniGuncelle();
            p1.Value++;
            //Şube Bilgileri Çekiliyor
            lblBilgi.Text = "Şube Bilgileri Güncelleniyor";
            GC.Collect();
            this.Refresh();
            guncelle.subeVerileriniGuncelle();
            p1.Value++;
            //Kullanıcı Bilgilleri çekiliyor
            lblBilgi.Text = "Kullanıcı Bilgileri Güncelleniyor";
            GC.Collect();
            this.Refresh();
            guncelle.kullaniciVerileriniGuncelle();
            p1.Value++;
            //StokKartlar Getiriliyor
            lblBilgi.Text = "Stokkart Bilgileri Güncelleniyor..";
            GC.Collect();
            this.Refresh();
            guncelle.stokkartVerileriniGuncelle();
            p1.Value++;
            p1.Value++;
            //Cari Bilgileri Getiriliyor
            lblBilgi.Text = "Cari Bilgileri Güncelleniyor";
            GC.Collect();
            this.Refresh();
            guncelle.cariBilgileriVerileriniGuncelle();
            p1.Value++;
            //liste verileri yükleniyor
            lblBilgi.Text = "Diğer Bilgileri Güncelleniyor";
            GC.Collect();
            this.Refresh();
            guncelle.bilgileriGuncelle();
            p1.Value++;
            DataTable dt = veri.getdatatable("Select * from tblSmsYetkileri where firmaid=" + firma.firmaid);
            if (dt.Rows.Count > 0)
            { }
            else { veri.getdatacell("exec spSmsYetkileriOlustur " + firma.firmaid + ""); }

            dt = veri.getdatatable("select * from tblHazirMesaj where FirmaID=" + firma.firmaid);
            if (dt.Rows.Count > 0)
            { }
            else { veri.getdatacell("exec spHazirMesajOlustur " + firma.firmaid + ", " + firma.subeid + "," + firma.kullaniciid + " "); }
            //liste verileri yükleniyor
            lblBilgi.Text = "SMS Bilgileri Güncelleniyor";
            GC.Collect();
            this.Refresh();
            SmsYetkileri.SmsYetkiGuncelle();
            p1.Value++;
            //veritabanına yükleme motoru aktif ediliyor (5 saniye aralıkla çalışır)
            lblBilgi.Text = "Yükleme Motoru Hazırlanıyor";
            this.Refresh();
            lblBilgi.Text = "Ayarlar Güncelleniyor";
            GC.Collect();
            ayarlar.ayarlariGuncelle();
            lblBilgi.Text = "Yetkiler Güncelleniyor";
            GC.Collect();
            yetkiler.yetkileriGuncelle();
            EFatura.getEFaturaBilgileri();
            EFatura.EFaturaNo = EFatura.getEFaturaNo();
            if (EFatura.EFaturaID > 0 && EFatura.KullaniciAdi.Length > 0)
            {
                backgroundWorker1.RunWorkerAsync();
                if (!Directory.Exists("ubl_testfatura"))
                    Directory.CreateDirectory("ubl_testfatura");
            }
            GC.Collect();
            this.Refresh();
            veritabaninaYuklemeMotoru.baslangic();
            GC.Collect();
            p1.Value++;
            if (firma.programAdi == "Elmar Ticari Plus" || firma.programAdi == "Elmar Ticari Plus | Personel")
            {
                Form1 frm = new Form1();
                frm.Select();
                frm.BringToFront();
                frm.Show();
            }
            this.Hide();
        }

        private void frmGiris_FormClosing(object sender, FormClosingEventArgs e)
        {
            veritabaninaYuklemeMotoru.programCalisiyormu = false;
            Application.ExitThread();            
        }

        private void lnkYeniFirmaHesabiAc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmYeniFirmaHesabiAc frm = new frmYeniFirmaHesabiAc();
            frm.Show();
        }

        string ortam = "ticari";

        veritabani.elmarAccess2003DataClass veriAccess;

        void ortamDegiskeniniGuncelle()
        {
            veriAccess = new veritabani.elmarAccess2003DataClass();
            veriAccess.setVeritabaniyolu(Application.StartupPath + "\\elmar.mdb");
            try
            {
                ortam = veriAccess.getdatacell("select ortam from tblOrtam");
            }
            catch
            {
            }
        }

        void guncellemeKontroluYap()
        {
            try
            {
                byte guncelleme = 0;
                SqlDataReader dr = veri.getDatareader("Select * from tblGuncelleme Where ortam = '*' or ortam = '" + ortam + "'");
                while (dr.Read())
                {
                    guncelleme = 1;
                    OleDbDataReader dro = veriAccess.getdatareader("select * from tblGuncellemekontrol where guncellemeNo ='" + (dr["guncellemeNo"].ToString()) + "'");
                    while (dro.Read())
                    {
                        guncelleme = 0;
                    }
                    if (guncelleme == 1) break;
                }
                if (guncelleme == 1)
                {
                    string surumNotu = "Yenilikler:--" + veri.getdatacell("select top 1 Bilgi from VerisonControl order by VersionID desc");
                    DialogResult result = MessageBox.Show(surumNotu + "\nGüncelleme Çıktı. Almak İstemiyorsanız Hayır Seçeneğine Tıklayınız.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        veriAccess.cmd("insert into tblGuncellemekontrol values ('" + (dr["guncellemeNo"].ToString()) + "')");
                    }
                    else
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(Application.StartupPath + "\\guncelle\\Oto Guncelleme.exe");
                            Application.DoEvents();
                            Environment.Exit(0);
                            Application.Exit();
                            Application.ExitThread();
                        }
                        catch (Exception hata)
                        {
                            //MessageBox.Show(Application.StartupPath + "\\Oto Guncelleme.exe dosyasında hatalar oluştu veya bulunamadı.Elmar Ticariyi tekrar yüklemeyi deneyin.");
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir Hata Oluştu.İnternet bağlantınızın olduğunu kontrol edin. [Hata Kodu : 21] \r\n" + hata.ToString(), "Elmar Ticari Plus");

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("osk.exe");
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        #region E-Fatura
        public void Win_Current_Login(string user, string pass, object environment)
        {
            string environmentName = getEnvironmentName(EFatura.UrlAdresi);
            tester = new SEFatura(user, pass, environment.ToString());

            // login..
            List<FormParameters> getFormParameters = tester.Current_Login();

            if (getFormParameters != null)
            {
                foreach (var parameter in getFormParameters)
                {

                    //add settings items
                    string[] infos = { parameter.ActionName, Convert.ToString(parameter.ActionElapsedMs / 1000), parameter.ActionElapsedMs.ToString(), environmentName };
                    var listViewItem = new ListViewItem(infos);
                    if (parameter.sessionID != null)
                    {
                        if (parameter.sessionID.GetType() == typeof(string)) EFatura.SessionsID = parameter.sessionID.ToString();
                        EFatura.LoginOK = parameter.loginEnter;
                        tester.GetInvoiceSerila();
                    }
                    // tester.Current_GetInvoice(true, "PDF", true, "OUT", 1, "ARV2020000000001", null);
                }
            }
            if (EFatura.LoginOK)
                backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Object selectedCmbItem = EFatura.UrlAdresi;
            Win_Current_Login(EFatura.KullaniciAdi, EFatura.Sifre, selectedCmbItem);//RUN EDM LOGIN

        }

        private string getEnvironmentName(string value)
        {
            return "CANLI";
        }
        #endregion

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            tester.Current_GetUserList();
        }
    }
}