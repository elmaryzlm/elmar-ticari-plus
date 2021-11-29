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
    public partial class frmFisOlustur : Form
    {
        public frmFisOlustur()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
        }

        private void frmFisOlustur_Load(object sender, EventArgs e)
        {
            txtGenislik.Text = ayarlar.fis_kagit_genislik;
            txtSol.Text = ayarlar.fis_kagit_sol_bosluk;
            txtUst.Text = ayarlar.fis_kagit_ust_bosluk;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ayarlar.ayarla_manuel("fis_kagit_genislik", txtGenislik.Text);
            ayarlar.ayarla_manuel("fis_kagit_sol_bosluk", txtSol.Text);
            ayarlar.ayarla_manuel("fis_kagit_ust_bosluk", txtUst.Text);
            ayarlar.ayarlariGuncelle();
            MessageBox.Show("Kaydedildi", firma.programAdi);
        }
    }
}
