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
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(panel12);
            NesneGorselleri.dataGridView(dgLog);
            listeler.doldurSube(cmbSubeler);
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            btnSorgula.PerformClick();
        }
        
        void logListele()
        {            
            string sorgu = "", topMetni="";

            if (cmbLogAciklamasi.Text != "") sorgu = sorgu + " and aciklama = '"+cmbLogAciklamasi.Text+"'";
            if (chkİslemTarihi.Checked) sorgu = sorgu + " and (tarih between '" + dtİslemTarihi1.Value + "' and '" + dtİslemTarihi2.Value + "')";
            if (cmbSubeler.Text != "") sorgu = sorgu + " and subeid =" + ComboboxItem.getSelectedValue(cmbSubeler);
            if (cmbKullanicilar.Text != "") sorgu = sorgu + " and kullaniciid =" + ComboboxItem.getSelectedValue(cmbKullanicilar);
            if (txtListelenecekLogSayisi.Text != "") topMetni = " Top " + txtListelenecekLogSayisi.Text + " ";
            dgLog.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select " + topMetni + " logid, aciklama, kullaniciid, tarih, kAdi, iliskiid from hSorLog Where firmaid = " + firma.firmaid + sorgu+" order by tarih desc");
            while (dr.Read())
            {
                dgLog.Rows.Add(dr["logid"].ToString(), dr["aciklama"].ToString(), dr["kullaniciid"].ToString(), dr["tarih"].ToString(), dr["kAdi"].ToString(), dr["iliskiid"].ToString());
            }
            lblKayitSayisiF.Text = dgLog.Rows.Count.ToString();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            logListele();
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
        }
    }
}
