using elmarLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmDoviz : Form
    {
        public frmDoviz()
        {
            InitializeComponent();
            NesneGorselleri.kontrolEkle(this);
            NesneGorselleri.form(this, false);
            this.StartPosition = FormStartPosition.CenterScreen;
            txtDolarAlis.Text = bilgiler.dovizVerileri.dDolaralis.ToString();
            txtDolarSatis.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
            txtEuroAlis.Text = bilgiler.dovizVerileri.dEuroalis.ToString();
            txtEuroSatis.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string dolarAlis = txtDolarAlis.Text;
            string dolarSatis = txtDolarSatis.Text;
            string euroAlis = txtEuroAlis.Text;
            string euroSatis = txtEuroSatis.Text;
            if (dolarAlis.Trim() == "") MessageBox.Show("Dolar Alış Fiyatını Girin!");
            if (dolarSatis.Trim() == "") MessageBox.Show("Dolar Satış Fiyatını Girin!");
            if (euroAlis.Trim() == "") MessageBox.Show("Euro Satış Fiyatını Girin!");
            if (euroSatis.Trim() == "") MessageBox.Show("Euro Satış Fiyatını Girin!");

            bilgiler.dovizVerileri.dDolaralis = Convert.ToDouble(dolarAlis);
            bilgiler.dovizVerileri.dDolarsatis = Convert.ToDouble(dolarSatis);
            bilgiler.dovizVerileri.dEuroalis = Convert.ToDouble(euroAlis);
            bilgiler.dovizVerileri.dEurosatis = Convert.ToDouble(euroSatis);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}