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
    public partial class frmYaziciSecimi : Form
    {
        public frmYaziciSecimi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            NesneGorselleri.kontrolEkle(this);
        }
        public bool yazdirilacakmi = false;
        private void btnDokumaniYazdir_Click(object sender, EventArgs e)
        {
            islemler.yaziciislemleri.yaziciAyarla(cmbYazicilistesi.Text);
            yazdirilacakmi = true;
            this.Close();
        }

        private void frmYaziciSecimi_Load(object sender, EventArgs e)
        {

        }

        private void btnYazdirma_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
