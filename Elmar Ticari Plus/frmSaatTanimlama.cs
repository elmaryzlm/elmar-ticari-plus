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
    public partial class frmOtoparkSaatTanimlama : Form
    {
        public frmOtoparkSaatTanimlama()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmOtopark"]);
            NesneGorselleri.dataGridView(dgSaatTanimlama);
            NesneGorselleri.kontrolEkle(panel2);
        }
        private void frmOtoparkSaatTanimlama_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into oTblSaatler(BaslangicSaati, BitisSaati,Fiyat, FirmaID, SubeID, KullaniciID) values('" + txtBaslangicSaati.Text + "', '" + txtBitisSaati.Text + "','" + txtFiyat.Text.Replace(".", "").Replace(",", ".") + "', " + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                txtBaslangicSaati.Clear();
                txtFiyat.Text = "0";
                listele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
        private void listele()
        {
            dgSaatTanimlama.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select SaatID, BaslangicSaati, BitisSaati,Fiyat From oTblSaatler Where FirmaID = " + firma.firmaid + "  And Silindimi = '0' Order by BaslangicSaati asc");
            while (dr.Read())
            {
                dgSaatTanimlama.Rows.Add(dr["SaatID"].ToString(), dr["BaslangicSaati"].ToString(), dr["BitisSaati"].ToString(), Convert.ToDouble(dr["Fiyat"]));
            }
            lblKayitSayisi.Text = dgSaatTanimlama.Rows.Count.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Seçili Satırı silmek istediğinizden emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update oTblSaatler set Silindimi = '1' where SaatID = " + dgSaatTanimlama.CurrentRow.Cells["SaatID"].Value + " ");
                    txtBaslangicSaati.Clear();
                    txtBitisSaati.Clear();
                    txtFiyat.Text = "0";
                    listele();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgSaatTanimlama_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update oTblSaatler set BaslangicSaati='" + dgSaatTanimlama.CurrentRow.Cells["BaslangicSaati"].Value.ToString() + "', BitisSaati='" + dgSaatTanimlama.CurrentRow.Cells["BitisSaati"].Value.ToString() + "', Fiyat='" + dgSaatTanimlama.CurrentRow.Cells["Fiyat"].Value.ToString().Replace(".", "").Replace(",", ".") + "' where SaatID = " + dgSaatTanimlama.CurrentRow.Cells["SaatID"].Value + "");
                txtBaslangicSaati.Clear();
                txtBitisSaati.Clear();
                txtFiyat.Text = "0";
                listele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
    }
}
