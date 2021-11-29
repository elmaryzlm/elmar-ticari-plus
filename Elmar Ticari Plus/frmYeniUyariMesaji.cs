using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;

namespace Elmar_Ticari_Plus
{
    public partial class frmYeniUyariMesaji : Form
    {
        public frmYeniUyariMesaji(int firmaid)
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            this._firmaid = firmaid;
            doldurSube();
        }
        List<string> listSubeid = new List<string>();
        private void doldurSube()
        {
            cmbSubeler.Items.Clear();
            listSubeid.Clear();
            SqlDataReader dr = veri.getDatareader("Select subeid, subeAdi from tblFirmaSubeleri where silindimi = '0' And firmaid = "+_firmaid+" order by subeAdi asc");
            while (dr.Read())
            {
                listSubeid.Add(dr["subeid"].ToString());
                cmbSubeler.Items.Add(dr["subeAdi"].ToString());
            }
            cmbSubeler.SelectedIndex = 0;
        }

        private void frmYeniUyariMesaji_Load(object sender, EventArgs e)
        {

        }
        List<string>  listKullaniciid = new List<string>();
        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbKullanicilar.Items.Clear();
            listKullaniciid.Clear();
            SqlDataReader dr = veri.getDatareader("Select kullaniciid, kAdi from tblFirmaKullanicilari where silindimi = '0' And firmaid = " + _firmaid + " and subeid = " + listSubeid[cmbSubeler.SelectedIndex] + " order by kAdi asc");
            while (dr.Read())
            {
                listKullaniciid.Add(dr["kullaniciid"].ToString());
                cmbKullanicilar.Items.Add(dr["kAdi"].ToString());
            }
            cmbKullanicilar.SelectedIndex = 0;
        }

        private int _firmaid = 0;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (cmbKullanicilar.Items.Contains(cmbKullanicilar.Text) == false)
            {
                MessageBox.Show("Geçerli şube ve kullanıcı seçin.", firma.programAdi);
                return;
            }
            veri.cmd("insert into tblUyarilar(uyariMetni, firmaid, subeid, kullaniciid) values('" + txtUyariMetni.Text + "', " + _firmaid + ", " + listSubeid[cmbSubeler.SelectedIndex] + ", " + listKullaniciid[cmbKullanicilar.SelectedIndex] + ")");
            MessageBox.Show("İşlem Başarılı", firma.programAdi);
            this.Close();
        }
    }
}
