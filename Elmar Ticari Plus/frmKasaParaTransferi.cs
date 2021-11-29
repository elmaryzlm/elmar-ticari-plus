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
    public partial class frmKasaParaTransferi : Form
    {
        public frmKasaParaTransferi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(this);
            NesneGorselleri.kontrolEkle(panel1);
            listeler.doldurSube(cmbESubeler);
            listeler.doldurSube(cmbESubeler2);
        }

        private void frmKasaParaTransferi_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtTutar.Text == "0")
            {
                MessageBox.Show("Tutar Girin", firma.programAdi);
                txtTutar.Select();
                return;
            }
            if (ComboboxItem.seciliMetinKontrolu(cmbESubeler) == false)
            {
                MessageBox.Show("Şubeyi listeden seçin", firma.programAdi);
                cmbESubeler.Select();
                return;
            }
            if (ComboboxItem.seciliMetinKontrolu(cmbEKullanicilar) == false)
            {
                MessageBox.Show("Kullanıcıyı listeden seçin", firma.programAdi);
                cmbEKullanicilar.Select();
                return;
            }

            try
            {
                if (txtAcklama.Text == "") txtAcklama.Text = "Şubeler Arası Para Transferi";
                //Aktaran
                veri.cmd("Exec [spSetMasraflar2] " + masrafid + ", " + masrafKartid + ", '" + dtİslemTarihi.Value + "', '" + txtTutar.Text.Replace(".", "").Replace(",", ".") + "','0' , '" + txtAcklama.Text + "','Firma Gideri', 0, 0, 0, 0, " + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbESubeler) + ", " + ComboboxItem.getSelectedValue(cmbEKullanicilar) + "");
                //Alan
                veri.cmd("Exec [spSetGelirler2] " + gelirid + ", 'Şube Para Transferi', '" + txtTutar.Text.Replace(".", "").Replace(",", ".") + "', '" + dtİslemTarihi.Value + "', '" + txtAcklama.Text + "', 0, " + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbESubeler2) + ", " + ComboboxItem.getSelectedValue(cmbEKullanicilar2) + "");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde bir hata oluştu.\nHata Metni: " + hata.Message, firma.programAdi);
            }

            this.Close();
        }
        int gelirid = 0, masrafid = 0, masrafKartid = 0;
        private void cmbESubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar, ComboboxItem.getSelectedValue(cmbESubeler));
        }

        private void cmbESubeler2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar2, ComboboxItem.getSelectedValue(cmbESubeler2));
        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDovizliTutar.Text = (Convert.ToDouble(txtTutar.Text) * Convert.ToDouble(txtDovizDegeri.Text)).ToString();
            }
            catch (Exception) { }
        }

        private void txtDovizKuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDovizDegeri.Text = "1";
                if (txtDovizKuru.SelectedIndex == 1) txtDovizDegeri.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
                else if (txtDovizKuru.SelectedIndex == 2) txtDovizDegeri.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
            }
            catch { }
        }
    }
}
