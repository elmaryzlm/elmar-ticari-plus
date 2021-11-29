using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmOtopark : Form
    {
        public frmOtopark()
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            this.WindowState = FormWindowState.Maximized;

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

        private void btnGiris_Click(object sender, EventArgs e)
        {
            frmOtoparkGirisCikis frm = new frmOtoparkGirisCikis();
            frm.Show();
        }

        private void frmOtopark_Load(object sender, EventArgs e)
        {

        }

        private void btnAboneler_Click(object sender, EventArgs e)
        {
            frmOtoparkAboneler frm = new frmOtoparkAboneler();
            frm.Show();
        }

        private void btnHizmetTanimlari_Click(object sender, EventArgs e)
        {
            frmOtoparkHizmetTanimlari frm = new frmOtoparkHizmetTanimlari();
            frm.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            frmOtoparkRaporlari frm = new frmOtoparkRaporlari();
            frm.Show();
        }

        private void btnGirisCikisListesi_Click(object sender, EventArgs e)
        {
            frmOtoparkGirisCikisRaporu frm = new frmOtoparkGirisCikisRaporu();
            frm.Show();
        }

        private void btnOtoparktakiAraclar_Click(object sender, EventArgs e)
        {
            frmOtoparkAracListesi frm = new frmOtoparkAracListesi();
            frm.Show();
        }     
        private void btnSaatTanimla_Click(object sender, EventArgs e)
        {
            frmOtoparkSaatTanimlama frm = new frmOtoparkSaatTanimlama();
            frm.Show();
        }

    }
}
