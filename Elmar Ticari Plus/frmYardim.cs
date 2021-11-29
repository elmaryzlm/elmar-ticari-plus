using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmYardim : Form
    {
        public frmYardim()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
        }

        private void frmYardim_Load(object sender, EventArgs e)
        {

        }

        private void btnResimliEgitimSayfasiniGoruntule_Click(object sender, EventArgs e)
        {
            
        }

        private void btniletisimAdresleri_Click(object sender, EventArgs e)
        {
            frmiletisim frm = new frmiletisim();
            frm.Show();
        }

        private void btnUzaktanYardimPrograminiCalistir_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\Destek\\TeamViewer.exe");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Uzaktan Yardım programı çalıştırılamadı. \nHata Metni: "+hata.Message);
            }
        }
    }
}
