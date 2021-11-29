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
    public partial class frmPersonelVardiyaTanim : Form
    {
        public frmPersonelVardiyaTanim()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgPersonelVardiyalari);
            listeler.doldurSube(cmbSubeAdi);
        }
        
        private void frmPersonelVardiyaTanim_Load(object sender, EventArgs e)
        {
            listele();
        }

        public void listele()
        {
            try
            {
                string sorgu = "";
                if (txtVardiyaAdi.Text != "") sorgu = " and vardiyaAdi like '%" + txtVardiyaAdi.Text + "%'";
                if (cmbSubeAdi.Text != "") sorgu = " and subeid = " + ComboboxItem.getSelectedValue(cmbSubeAdi) + "";
                dgPersonelVardiyalari.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("Select vardiyaid, vardiyaAdi, baslangicSaati, bitisSaati,subeid, subeAdi, eklenmeTarihi from sorPersonelVardiyaTanim where firmaid = " + firma.firmaid + sorgu + "");
                while (dr.Read())
                {
                    dgPersonelVardiyalari.Rows.Add(dr["vardiyaid"].ToString(), dr["vardiyaAdi"].ToString(), dr["baslangicSaati"].ToString(), dr["bitisSaati"].ToString(), dr["subeid"].ToString(), dr["subeAdi"].ToString(), "Düzenle", "Sil");
                }
                lblKayitSayisi.Text = dgPersonelVardiyalari.Rows.Count.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message,firma.programAdi);
            }
           
        }

        private void btnHesapEkle_Click(object sender, EventArgs e)
        {
            frmPersonelVardiyaTanimEkle frm = new frmPersonelVardiyaTanimEkle();
            frm._frmPersonelVardiyaTanim = this;
            frm.Show();
        }

        private void dgPersonelVardiyalari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgPersonelVardiyalari.Columns["duzenle"].Index)
            { 
                //Düzenle
                frmPersonelVardiyaTanimEkle frm = new frmPersonelVardiyaTanimEkle();
                frm._frmPersonelVardiyaTanim = this;
                frm.vardiyaid = Convert.ToInt32(dgPersonelVardiyalari.CurrentRow.Cells["vardiyaid"].Value);
                frm.txtVardiyaAdi.Text = dgPersonelVardiyalari.CurrentRow.Cells["vardiyaAdi"].Value.ToString();
                frm.txtBaslangicSaati.Text = dgPersonelVardiyalari.CurrentRow.Cells["baslangicSaati"].Value.ToString();
                frm.txtBitisSaati.Text = dgPersonelVardiyalari.CurrentRow.Cells["bitisSaati"].Value.ToString();
                frm.cmbSubeAdi.Text = dgPersonelVardiyalari.CurrentRow.Cells["subeAdi"].Value.ToString();
                frm.Show();
            }
            else if (e.ColumnIndex == dgPersonelVardiyalari.Columns["sil"].Index)
            {
                if (MessageBox.Show("Seçili kayıt silinsin mi ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    veri.cmd("Update tblPersonelVardiyaTanim Set silindimi = '1' Where vardiyaid= " + dgPersonelVardiyalari.CurrentRow.Cells["vardiyaid"].Value + "");
                    listele();
                }
            }
        }

        private void txtVardiyaAdi_TextChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void cmbSubeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();
        }
    }
}
