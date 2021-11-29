using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using elmarLibrary;
using System.Diagnostics;
namespace Elmar_Ticari_Plus
{
    public partial class frmYukle : Form
    {
        public frmYukle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            veri.server = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.1110000.1100000.1110001.1010001.1110100.1011011.1010001.1110001.1001000.10000011.1100001.1011100.1101010.1101010.1101110.1111111.10010001.1100111.1110000.1100000.10001000.10001011.10000111.1001111.10010001.10011001.1110010.1111010.1010111.10011100.1110010.1110000.1110000.1110111.10010101.1101111.10011001.1110111.10011110.10010001.10011000.10100101.10010101.", 8), "mykfs");
            veri.db = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.1000110.1110001.1100000.1011000.1100111.1000010.1010011.1010100.1000001.1011011.1110111.1000101.1111101.1011001.1011100.1011100.1001001.10001011.1100101.10001001.10000110.1110110.1001111.", 8), "mykfs");
            veri.kadi = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.1000110.1001011.111010.1110111.10000110.1000101.1010100.1100110.1000001.1110110.10001000.1001001.1001110.1111100.10001101.1111110.1001001.1001001.1100000.10010001.10000000.1101011.1101000.", 8), "mykfs");
            veri.sifre = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.111001.1111001.1001111.1000011.1010100.1010101.1000110.1011111.1111010.10000110.1100110.1000111.1010111.10000011.10001111.1101110.1110011.1100001.1101111.10010011.10010101.1001111.1110000.1110111.1011001.1010010.1101001.1101100.1111011.10011110.1011111.1110001.10011000.1011111.1111101.10011111.1110110.1011001.10000100.10000101.1100000.1110101.10101000.", 8), "mykfs");
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmYukle_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.Refresh();
            kanal = new Thread(new ThreadStart(verileriCekVeGirisYap));
            kanal.Start();
        }
        Thread kanal;
        void verileriCekVeGirisYap()
        {
            try
            {
                p1.Value++;
                //aktif online kullanıcı yapılması sağlanıyor.
                veri.cmd("exec spKullaniciGirisiYapildi '" + bilgiler.ip_al() + "', " + firma.kullaniciid + "");

                p1.Value++;
                //firma Bilgileri Çekiliyor
                lblBilgi.Text = "Firma Bilgileri Güncelleniyor";
                this.Refresh();
                guncelle.firmaVerileriniGuncelle();
                p1.Value++;
                //Şube Bilgileri Çekiliyor
                lblBilgi.Text = "Şube Bilgileri Güncelleniyor";
                this.Refresh();
                guncelle.subeVerileriniGuncelle();
                p1.Value++;
                //Kullanıcı Bilgilleri çekiliyor
                lblBilgi.Text = "Kullanıcı Bilgileri Güncelleniyor";
                this.Refresh();
                guncelle.kullaniciVerileriniGuncelle();
                p1.Value++;
                //StokKartlar Getiriliyor
                lblBilgi.Text = "Stokkart Bilgileri Güncelleniyor..";
                this.Refresh();
                guncelle.stokkartVerileriniGuncelle();
                p1.Value++;
                p1.Value++;
                
                //Cari Bilgileri Getiriliyor
                lblBilgi.Text = "Cari Bilgileri Güncelleniyor";
                this.Refresh();
                guncelle.cariBilgileriVerileriniGuncelle();
                p1.Value++;
                //liste verileri yükleniyor
                lblBilgi.Text = "Diğer Bilgileri Güncelleniyor";
                this.Refresh();
                guncelle.bilgileriGuncelle();
                p1.Value++;
                //veritabanına yükleme motoru aktif ediliyor (5 saniye aralıkla çalışır)
                lblBilgi.Text = "Yükleme Motoru Hazırlanıyor";
                this.Refresh();
                veritabaninaYuklemeMotoru.baslangic();
                p1.Value++;
                firma.programAdi = firma.programAdi + " Ticari | Personel";
                yuklendimi = true;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        bool yuklendimi = false;
        private void frmYukle_FormClosing(object sender, FormClosingEventArgs e)
        {
            veritabaninaYuklemeMotoru.programCalisiyormu = false;
            Application.ExitThread();
        }

        private void tmrFormAc_Tick(object sender, EventArgs e)
        {
            if (yuklendimi)
            {
                tmrFormAc.Stop();
                if (firma.muhasebe == "1")
                {
                    Form1 frm = new Form1();
                    frm.Show();
                }
                else if (firma.personel == "1")
                {
                    frmPersonelAna frm = new frmPersonelAna();
                    frm.Show();
                    frm.Select();
                    frm.BringToFront();
                }
                this.Hide();
                //this.Opacity = 0.2f;
                //this.ShowInTaskbar = false;
                //this.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
