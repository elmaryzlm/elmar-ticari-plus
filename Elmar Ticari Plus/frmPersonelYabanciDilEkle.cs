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
    public partial class frmPersonelYabanciDilEkle : Form
    {
        public frmPersonelYabanciDilEkle(long personelid, string personelAdi)
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.kontrolEkle(this);
            this.personelid = personelid;
            this.txtPersonelAdi.Text = personelAdi;
        }
        long personelid = 0;
        public frmPersonel _frmPersonel = null;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_frmPersonel != null)
            {
                //if (_frmPersonel.seciliPersonelid == 0)
                _frmPersonel.dgYabanciDiller.Rows.Add("0", cmbDilAdi.Text, cmbOkuma.Text, cmbYazma.Text, cmbKonusma.Text, cmbOgrenildigiYer.Text, DateTime.Now, "Sil");
            }
            this.Close();
        }

        private void frmPersonelYabanciDilEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
