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
    public partial class frmPersonelGorevEkle : Form
    {
        public frmPersonelGorevEkle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.kontrolEkle(this);
        }
        void listeleriDoldur()
        {
            cmbPersonelAdlari.Items.Clear();
            try { cmbPersonelAdlari.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
        }
        private long seciiliPersonelid = 0;
        private void frmPersonelGorevEkle_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
        }

        private void cmbPersonelAdlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciiliPersonelid = listeler.getPersonelid()[cmbPersonelAdlari.SelectedIndex];
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("exec [spSetPersonelGorevleri] 0," + seciiliPersonelid + ",'" + txtGorevAdi.Text + "','" + txtGorevTanimi.Text + "','" + dtBaslangicTarihi.Value + "','" + dtSonlanmaTarihi.Value + "','" + txtBaslangicSaati.Text + "','" + txtSonlanmaSaati.Text + "','" + txtAciklama.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + "");
                MessageBox.Show("Kaydetme işlemi başarıyla gerçekleşti", firma.programAdi);
                this.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde hata oluştu. Hata Metni: "+hata.Message, firma.programAdi);
            }

        }
    }
}
