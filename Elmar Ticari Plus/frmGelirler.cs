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
namespace Elmar_Ticari_Plus
{
    public partial class frmGelirler : Form
    {
        public frmGelirler()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(panel4);
            NesneGorselleri.kontrolEkle(panel5);
            NesneGorselleri.kontrolEkle(panel6);
            NesneGorselleri.kontrolEkle(panel8);
            NesneGorselleri.kontrolEkle(panel9);
            listeler.doldurSube(cmbSubeler);
        }

        private void frmGelirler_Load(object sender, EventArgs e)
        {           
        }
        public int gelirid = 0;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("Exec spSetGelirler2 " + gelirid + ", '" + txtGelirAdi.Text + "', '" + txtTutar.Text.Replace(".", "").Replace(",", ".") + "', '" + dtislemTarihi.Value + "', '" + txtAciklama.Text + "',0, " + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbSubeler) + ", " + ComboboxItem.getSelectedValue(cmbKullanicilar) + "");
                temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde bir hata oluştu.\nHata Metni: " + hata.Message, firma.programAdi);
            }
        }

        void temizle()
        {
            txtAciklama.Clear();
            txtGelirAdi.Clear();
            txtTutar.Text = "0";
            txtGelirAdi.Select();
            gelirid = 0;
        }
        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
        }
    }
}
