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
    public partial class frmSilinenSatislar : Form
    {
        public frmSilinenSatislar()
        {
            InitializeComponent();
            listeler.doldurSube(cmbSubeler);
            dtİslemTarihi1.Text = dtİslemTarihi2.Text = DateTime.Now.ToString();

        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            veriGetir();
        }

        void veriGetir()
        {
            string sql = "select * from ViewSilinenSatislar where FirmaID=" + firma.firmaid + " and SubeID=" + ComboboxItem.getSelectedValue(cmbSubeler) + " and KullaniciID=" + ComboboxItem.getSelectedValue(cmbKullanicilar) + "  and  (Tarih between '" + dtİslemTarihi1.Value.ToShortDateString() + "' and '" + dtİslemTarihi2.Value.ToShortDateString() + "') ";
            dgTicaretUrunler.DataSource = veri.getdatatable(sql);
        }
    }
}
