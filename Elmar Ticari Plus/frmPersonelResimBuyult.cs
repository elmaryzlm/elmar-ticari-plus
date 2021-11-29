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
    public partial class frmPersonelResimBuyult : Form
    {
        public frmPersonelResimBuyult(Image resim, string personelAdi)
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            this.Text = personelAdi + " Personeline Ait Resim";
            this.pictureBox1.Image = resim;
        }

        private void frmPersonelResimBuyult_Load(object sender, EventArgs e)
        {

        }
    }
}
