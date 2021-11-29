using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmYeniFirmaOdemesiEkle : Form
    {
        private int _firmaid = 0;
        public frmYeniFirmaOdemesiEkle(int firmaid)
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
            SqlDataReader dr = veri.getDatareader("Select subeid, subeAdi from tblFirmaSubeleri where silindimi = '0' And firmaid = " + _firmaid + " order by subeAdi asc");
            while (dr.Read())
            {
                listSubeid.Add(dr["subeid"].ToString());
                cmbSubeler.Items.Add(dr["subeAdi"].ToString());
            }
            cmbSubeler.SelectedIndex = 0;
        }
        private void frmYeniFirmaOdemesiEkle_Load(object sender, EventArgs e)
        {

        }

        List<string> listKullaniciid = new List<string>();
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (cmbKullanicilar.Items.Contains(cmbKullanicilar.Text) == false)
            {
                MessageBox.Show("Geçerli şube ve kullanıcı seçin.", firma.programAdi);
                return;
            }
            double alacak = 0, borc = 0;
            string vadeTarihi1 = "", vadeTarihi2 = "";
            string odemeTarihi1 = "", odemeTarihi2 = "";

            if (cmbislemTipi.Text == "Tahsilat")
            {
                borc = Convert.ToDouble(txtTutar.Text);
                odemeTarihi1 = ", odemeTarihi";
                odemeTarihi2 = ",'"+dtİslemTarihi.Value+"'";
            }
            else if (cmbislemTipi.Text == "Ödeme")
            {
                alacak = Convert.ToDouble(txtTutar.Text);
                odemeTarihi1 = ", odemeTarihi";
                odemeTarihi2 = ",'" + dtİslemTarihi.Value + "'";
            }
            else if (cmbislemTipi.Text == "Alacak")
            {
                alacak = Convert.ToDouble(txtTutar.Text);
                vadeTarihi1 = ", vadeTarihi";
                vadeTarihi2 = ",'" + dtVadeTarihi.Value + "'";
            }
            else if (cmbislemTipi.Text == "Borç")
            {
                borc = Convert.ToDouble(txtTutar.Text);
                vadeTarihi1 = ", vadeTarihi";
                vadeTarihi2 = ",'" + dtVadeTarihi.Value + "'";
            }
            else
            {
                MessageBox.Show("İşlem Tipini listeden seçin.", firma.programAdi);
                return;
            }

            veri.cmd("insert into tblFirmaOdemeleri(alacak, borc, kayitTarihi " + vadeTarihi1 + odemeTarihi1 + ", islemTuru, aciklama, firmaid, subeid, kullaniciid) values(" + alacak + ", " + borc + ", '" + dtİslemTarihi.Value + "'" + vadeTarihi2 + odemeTarihi2 + ",'" + cmbislemTipi.Text + "','" + txtAcklama.Text + "', " + _firmaid + ", " + listSubeid[cmbSubeler.SelectedIndex] + ", " + listKullaniciid[cmbKullanicilar.SelectedIndex] + ")");
            this.Close();
        }

        private void cmbislemTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbislemTipi.Text == "Ödeme" || cmbislemTipi.Text == "Tahsilat")
            {
                dtVadeTarihi.Enabled = false;
            }
            else
            {
                dtVadeTarihi.Enabled = true;
            }
        }
    }
}
