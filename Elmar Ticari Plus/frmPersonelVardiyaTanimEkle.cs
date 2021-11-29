using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.Data.SqlClient;
namespace Elmar_Ticari_Plus
{
    public partial class frmPersonelVardiyaTanimEkle : Form
    {
        public int vardiyaid = 0;
        public frmPersonelVardiyaTanim _frmPersonelVardiyaTanim = null;
        public frmPersonelVardiyasiEkle _frmPersonelVardiyasiEkle = null;
        public frmPersonelVardiyaTanimEkle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.kontrolEkle(this);
            listeler.doldurSube(cmbSubeAdi);
            if (vardiyaid != 0)
            {
                lblBaslik.Text = "Vardiya Düzenle";
            }
        }

        private void frmPersonelVardiyaTanimEkle_Load(object sender, EventArgs e)
        {
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            veri.cmd("Exec spSetPersonelVardiyaTanim " + vardiyaid + ", '" + txtVardiyaAdi.Text + "', '" + txtBaslangicSaati.Text + "', '" + txtBitisSaati.Text + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");
            if (_frmPersonelVardiyaTanim != null) _frmPersonelVardiyaTanim.listele();
            if (_frmPersonelVardiyasiEkle != null) _frmPersonelVardiyasiEkle.vardiyaListele();

            
            if (vardiyaid == 0)
            {
                MessageBox.Show("Vardiya tanımlama işlemi başarıyla gerçekleştirildi.", firma.programAdi);
                this.Close();
            }
            else
            {
                MessageBox.Show("Vardiya başarıyla düzenlendi.", firma.programAdi);
                this.Close();
            }
        }
    }
}
