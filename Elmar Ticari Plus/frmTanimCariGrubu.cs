using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmTanimCariGrubu : Form
    {
        public frmTanimCariGrubu()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgCariGrubu);
            NesneGorselleri.kontrolEkle(panel2);
        }
        
        private void frmTanimCariGrubu_Load(object sender, EventArgs e)
        {
            cariGrubuListele();
        }

        void cariGrubuListele()
        {
            try
            {
                dgCariGrubu.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("Select cariGrupid, grupAdi from tblCariGruplari Where firmaid = " + firma.firmaid + " and silindimi = '0'");
                while (dr.Read())
                {
                    dgCariGrubu.Rows.Add(dr["cariGrupid"].ToString(), dr["grupAdi"].ToString());
                }
                lblKayitSayisi.Text = dgCariGrubu.Rows.Count.ToString();
            }
            catch
            {
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into tblCariGruplari(grupAdi, firmaid, subeid, kullaniciid) values('" + txtCariGrupAdi.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                guncelle.cariBilgileriVerileriniGuncelle();
                guncelle.bilgileriGuncelle();
                cariGrubuListele();
                txtCariGrupAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(dgCariGrubu.CurrentRow.Cells["grupAdi"].Value.ToString() + " Adlı Cari Grubunu silmek istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update tblCariGruplari set silindimi = '1' where cariGrupid = " + dgCariGrubu.CurrentRow.Cells["cariGrupid"].Value + " ");
                    guncelle.cariBilgileriVerileriniGuncelle();
                    guncelle.bilgileriGuncelle();
                    cariGrubuListele();
                    txtCariGrupAdi.Clear();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgCariGrubu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update tblCariGruplari set grupAdi='" + dgCariGrubu.CurrentRow.Cells["grupAdi"].Value.ToString() + "' where cariGrupid = " + dgCariGrubu.CurrentRow.Cells["cariGrupid"].Value + "");
                guncelle.cariBilgileriVerileriniGuncelle();
                guncelle.bilgileriGuncelle();
                cariGrubuListele();
                txtCariGrupAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
    }
}
