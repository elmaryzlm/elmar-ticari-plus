using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Elmar_Ticari_Plus
{
    public partial class frmOtoparkGirisCikisRaporu : Form
    {
        public frmOtoparkGirisCikisRaporu()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmOtopark"]);
            NesneGorselleri.dataGridView(dgGirisCikis);
            NesneGorselleri.kontrolEkle(panel7);
        }

        private void frmOtoparkGirisCikisRaporu_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            string sorgu = " And (tarih between '" + dt1.Value + "' And '" + dt2.Value + "')";
            if (txtPlaka.Text != "") sorgu = sorgu + " And plaka like '"+txtPlaka.Text+"%'";
            if (txtAboneAdi.Text != "") sorgu = sorgu + " And aboneAdi like '" + txtAboneAdi.Text + "%'";
            if (rdGiris.Checked) sorgu = sorgu + " And islemTuru = 'Giriş'";
            if (rdCikis.Checked) sorgu = sorgu + " And islemTuru = 'Çıkış'";

            double toplam = 0;
            dgGirisCikis.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select plaka, aboneAdi, tarih, saat, islemTuru, toplam From oSorOtoparkGirisCikis Where firmaid = " + firma.firmaid + sorgu + " Order by tarih desc, saat desc");
            while (dr.Read())
            {
                dgGirisCikis.Rows.Add(dr["plaka"].ToString(), dr["aboneAdi"].ToString(), Convert.ToDateTime(dr["tarih"]), dr["saat"].ToString(), dr["islemTuru"].ToString(), Convert.ToDouble(dr["toplam"]));
                toplam += Convert.ToDouble(dr["toplam"]);
            }
            txtToplamHizmetTutari.Text = String.Format("{0:n2}", toplam);
            txtKayitSayisi.Text = dgGirisCikis.Rows.Count.ToString();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
