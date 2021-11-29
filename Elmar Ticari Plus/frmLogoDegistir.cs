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
namespace Elmar_Ticari_Plus
{
    public partial class frmLogoDegistir : Form
    {
        public frmLogoDegistir()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Resim Seçimi";
            o.Filter = "Resim Dosyaları|*.png;*.bmp;*.gif;*.jpg";
            o.ShowDialog();
            if (o.SafeFileName == "")
            {
            }
            else
            {
                picLogo.Image = Image.FromFile(o.FileName);
                //File.Delete(Application.StartupPath + "\\KullanıcıResimleri\\logo\\logo" + firma.firmaid + ".png");
                picLogo.Image.Save(Application.StartupPath + "\\KullanıcıResimleri\\logo\\logo" + firma.firmaid + ".png",System.Drawing.Imaging.ImageFormat.Png);
                elmarDosyaislemleri.resimYukle(picLogo.Image, "logo/logo" + firma.firmaid + ".png");
                ((Form1)Application.OpenForms["Form1"]).logoGetir();
            }
        }
        private void frmLogoDegistir_Load(object sender, EventArgs e)
        {
            logoGetir();
        }

        void logoGetir()
        {
            try
            {
                picLogo.Image = null;
                Stream s = File.Open(Application.StartupPath + "\\KullanıcıResimleri\\logo\\logo" + firma.firmaid + ".png", FileMode.Open);
                Image temp = Image.FromStream(s);
                s.Close();
                picLogo.Image = temp;

            }
            catch
            {
                try { picLogo.Image = elmarDosyaislemleri.resimindir("logo/logo" + firma.firmaid + ".png"); }
                catch { }
            }
            try
            {
                string yol = Application.StartupPath + "\\KullanıcıResimleri\\logo\\logo" + firma.firmaid + ".png";
                if (!File.Exists(yol)) picLogo.Image.Save(yol);
            }
            catch { }
        }
    }
}
