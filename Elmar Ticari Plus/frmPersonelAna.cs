using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace Elmar_Ticari_Plus
{
    public partial class frmPersonelAna : Form
    {
        public frmPersonelAna()
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            this.WindowState = FormWindowState.Maximized;
            this.Text = firma.programAdi;
            pnlSol.Width = 105;
            pnlSol.Select();
        }

        public void logoGetir()
        {

            try
            {
                this.BackgroundImage = elmarDosyaislemleri.resimindir("logo/logo" + firma.firmaid + ".png");
            }
            catch {
                if (firma.programAdi.Contains("BMS")) this.BackgroundImage = Properties.Resources.arkaplan1;
                else this.BackgroundImage = Properties.Resources.arkaplan;
            }
            
        }

        private void frmPersonelAna_Load(object sender, EventArgs e)
        {
            btnDovizyenile_Click(sender, e);
            //Thread kanal = new Thread(new ThreadStart(logoGetir));
            //kanal.Start();
        }
       
        private void btnPersonel_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Personel_Ana_Menüsü)
            {
                yetkiler.mesajVer();
                return;
            }
            menuleriGizle();
            pnlPersonel.Visible = true;
        }
        void menuleriGizle()
        {
            pnlGorevler.Visible = false;
            pnlKartislemleri.Visible = false;
            pnlMaas.Visible = false;
            pnlPersonel.Visible = false;
            pnlPrim.Visible = false;
            pnlTanimlar.Visible = false;
            pnlVardiya.Visible = false;
        }
        private void frmPersonelAna_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Application.OpenForms["Form1"].IsHandleCreated == false)
                {
                    Application.Exit(); Application.ExitThread();
                }
            }
            catch (Exception)
            {
                Application.Exit(); Application.ExitThread();
            }
           
        }

        private void btnPersonelislemleri_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Personel_Kartı_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            frmPersonel frm = new frmPersonel();
            frm.Show();
        }

        private void frmGorevler_Click(object sender, EventArgs e)
        {
            menuleriGizle();
            pnlGorevler.Visible = true;
        }

        private void frmMaas_Click(object sender, EventArgs e)
        {
            menuleriGizle();
            pnlMaas.Visible = true;
        }

        private void frmPrim_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Prim_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            menuleriGizle();
            pnlPrim.Visible = true;
        }

        private void btnPersonelKarti_Click(object sender, EventArgs e)
        {
            menuleriGizle();
            pnlKartislemleri.Visible = true;
        }

        private void btnPersonelListele_Click(object sender, EventArgs e)
        {
            frmPersonelListele frm = new frmPersonelListele();
            frm.Show();
        }

        private void btnDepartmanTanimla_Click(object sender, EventArgs e)
        {
            frmTanimDepartman frm = new frmTanimDepartman();
            frm.Show();
        }

        private void btnPersonelGrubu_Click(object sender, EventArgs e)
        {
            frmTanimPersonelGrubu frm = new frmTanimPersonelGrubu();
            frm.Show();
        }

        private void btniseBaslatistenCikar_Click(object sender, EventArgs e)
        {
            if (!yetkiler.İşe_başlat___İşten_Çıkar)
            {
                yetkiler.mesajVer();
                return;
            }
            frmPersonelisebaslatistencikar frm = new frmPersonelisebaslatistencikar();
            frm.Show();
        }

        private void btnGirisCikisAnalizi_Click(object sender, EventArgs e)
        {

        }

        private void btnYeniGorev_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Görev_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmPersonelGorevEkle frm = new frmPersonelGorevEkle();
            frm.Show();
        }

        private void btnGorevListesi_Click(object sender, EventArgs e)
        {
            frmPersonelGorevListesi frm = new frmPersonelGorevListesi();
            frm.Show();
        }

        private void btnMaasGirisi_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Maaş_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmPersonelMaasGirisi frm = new frmPersonelMaasGirisi();
            frm.Show();
        }

        private void btnMaasListesi_Click(object sender, EventArgs e)
        {
            frmPersonelMaasListele frm = new frmPersonelMaasListele();
            frm.Show();
        }

        private void btnPersonelRaporu_Click(object sender, EventArgs e)
        {
            frmPersonelRaporlari frm = new frmPersonelRaporlari();
            frm.Show();
        }

        private void btnKendiCekim_Click(object sender, EventArgs e)
        {

        }

        private void elmarTicariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMuhasebe_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["Form1"].IsHandleCreated == false)
                {
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Close();
                }
                else
                {
                    Application.OpenForms["Form1"].BringToFront();
                    Application.OpenForms["Form1"].Activate();
                    Application.OpenForms["Form1"].Select();
                    this.Close();
                }
            }
            catch
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Close();
            }
        }

        private void btnVardiya_Click(object sender, EventArgs e)
        {
            menuleriGizle();
            pnlVardiya.Visible = true;
        }

        private void btnVardiyaTanimla_Click(object sender, EventArgs e)
        {
            frmPersonelVardiyaTanim frm = new frmPersonelVardiyaTanim();
            frm.Show();
        }

        private void btnPersonelVardiyalari_Click(object sender, EventArgs e)
        {
            frmPersonelVardiyalari frm = new frmPersonelVardiyalari();
            frm.Show();
        }

        private void btnBordro_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Maaş_Bordrosu)
            {
                yetkiler.mesajVer();
                return;
            }
        }

        private void btnYardim_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\Yardım.exe", "0é" + firma.kullaniciid.ToString());
            }
            catch (Exception hata)
            {
                MessageBox.Show("Yardım Programı Çalıştırılırken bir hata oluştu.\n Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnDovizyenile_Click(object sender, EventArgs e)
        {
            try
            {
                bilgiler.dovizVerileri.dovizVerileriniguncelle();
                lblEUROalis.Text = bilgiler.dovizVerileri.dEuroalis.ToString();
                lblEUROsatis.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
                lblUSDalis.Text = bilgiler.dovizVerileri.dDolaralis.ToString();
                lblUSDsatis.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
            }
            catch (Exception hata)
            {

            }
        }
    }
}