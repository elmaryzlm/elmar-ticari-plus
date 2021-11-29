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
    public partial class frmBankaEkle : Form
    {
        public frmBankaEkle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
        }
        int bankaid = 0;
        public frmBankalar _frmBankalar = null;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
               string eklenenBankaid = veri.getdatacell("exec spSetBankaTaslak " + bankaid + ", '" + txtBankaAdi.Text + "', '" + txtSubeAdi.Text + "','"+txtSubeKodu.Text+"', '" + txtSehir.Text + "', '" + txtilce.Text + "', '" + txtAdres.Text + "', '" + txtTel.Text + "', '" + txtFax.Text + "', '" + txtAciklama.Text + "', " + firma.firmaid + " ");
               if (_frmBankalar != null)
               {
                   _frmBankalar.dgBankalar.Rows.Add(eklenenBankaid, txtBankaAdi.Text, txtSubeAdi.Text, txtilce.Text, txtilce.Text, txtAdres.Text, txtTel.Text, txtFax.Text, txtAciklama.Text, firma.firmaid.ToString());
                   _frmBankalar.dgBankalar.Rows[_frmBankalar.dgBankalar.Rows.Count - 1].Cells["bankaAdi"].Selected = true;
                   //MessageBox.Show("Ekleme İşlemi Başarılı", firma.programAdi);
               }
                this.Close();
                
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt işleminde hata oluştu. Hata Metni: "+hata.Message, firma.programAdi);
            }
        }

        private void frmBankaEkle_Load(object sender, EventArgs e)
        {
        }

    }
}
