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
    public partial class frmFaturaBilgileri : Form
    {
        public frmFaturaBilgileri(frmTicaret.faturaBilgileri _frmFaturaBilgileri, bool faturamı)
        {
            InitializeComponent();
           // NesneGorselleri.form(this, false);
            NesneGorselleri.kontrolEkle(this);
            this._frmFaturaBilgileri = _frmFaturaBilgileri;
            txtBelgeNo.Text = _frmFaturaBilgileri.belgeNo;
            txtFaturaAciklamasi.Text = _frmFaturaBilgileri.faturaAciklamasi;
            txtFaturaNo.Text = EFatura.getEFaturaNo();
            txtirsaliyeNo.Text = _frmFaturaBilgileri.irsaliyeNo;
            foreach (var item in EFatura.ListSerial)
            {
                if (EFatura.AliciGB == "")
                {
                    if (item.Contains("Arşiv"))
                        cmbSeri.Items.Add(item);
                }
                else
                {
                    if (item.Contains("Fatura"))
                        cmbSeri.Items.Add(item);
                }
            }

          
            try
            {
                cmbSeri.SelectedIndex = 0;
                dtFaturaTarihi.Value = _frmFaturaBilgileri.faturaTarihi;
            }
            catch { }
            try
            {
                dtFiiliSevkTarihi.Value = _frmFaturaBilgileri.fiiliSefkTarihi;
            }
            catch { }
            if (faturamı == false)
            {
                txtFaturaNo.Enabled = false;
                dtFaturaTarihi.Enabled = false;
                dtFiiliSevkTarihi.Enabled = false;
                txtirsaliyeNo.Enabled = false;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_frmFaturaBilgileri != null)
            {
                firma.faturaNo = txtFaturaNo.Text;
                _frmFaturaBilgileri.belgeNo = txtBelgeNo.Text;
                _frmFaturaBilgileri.irsaliyeNo = txtirsaliyeNo.Text;
                _frmFaturaBilgileri.faturaNo = txtFaturaNo.Text;
                _frmFaturaBilgileri.faturaAciklamasi = txtFaturaAciklamasi.Text;
                _frmFaturaBilgileri.faturaTarihi = dtFaturaTarihi.Value;
                _frmFaturaBilgileri.fiiliSefkTarihi = dtFiiliSevkTarihi.Value;
            }
            if (EFatura.OtoGonder && txtFaturaNo.Text.Length != 16)
            {
                MessageBox.Show("Lütfen fatura numarası 16 hane olacak şekilde giriniz");
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private frmTicaret.faturaBilgileri _frmFaturaBilgileri = null;

        private void frmFaturaBilgileri_Load(object sender, EventArgs e)
        {

        }

        private void cmbSeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seri = cmbSeri.Text;
            seri = seri.Split('-')[0];
            string faturaNo = EFatura.getEFaturaNo(seri);
            Int64 faturaNoint = 0;
            //new SEFatura(EFatura.KullaniciAdi,EFatura.Sifre,EFatura.UrlAdresi).Current_GetInvoice();
            if (faturaNo.Length > 0)
            {
                //faturano 1 artırılacak
                faturaNoint = Convert.ToInt64(faturaNo.Substring(7).ToString()); //0000006
                faturaNoint = faturaNoint + 1; //0000007
                faturaNo = seri + DateTime.Now.Year + 0.ToString().PadLeft(9 - faturaNoint.ToString().Length, '0') + faturaNoint;
            }
            else
            {
                faturaNo = seri + DateTime.Now.Year + 1.ToString().PadLeft(9, '0');
            }
            txtFaturaNo.Text = faturaNo;
        }
    }
}