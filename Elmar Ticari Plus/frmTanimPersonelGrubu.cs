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
    public partial class frmTanimPersonelGrubu : Form
    {
        public frmTanimPersonelGrubu()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgPersonelGrubu);
            NesneGorselleri.kontrolEkle(panel2);
        }

        private void frmTanimPersonelGrubu_Load(object sender, EventArgs e)
        {
            personelGrubuListele();
        }
        public frmPersonel _frmPersonel = null;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into tblPersonelGruplari(grupAdi, firmaid, subeid, kullaniciid) values('" + txtPersonelGrubuAdi.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                personelGrubuListele();
                if (_frmPersonel != null) _frmPersonel.personelGrubuListele();
                txtPersonelGrubuAdi.Clear();
                txtPersonelGrubuAdi.Select();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
        void personelGrubuListele()
        {
            try
            {
                dgPersonelGrubu.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("select personelGrupid, grupAdi from sorPersonelGruplari where firmaid = " + firma.firmaid + " order by grupAdi");
                while (dr.Read())
                {
                    dgPersonelGrubu.Rows.Add(dr["personelGrupid"].ToString(), dr["grupAdi"].ToString());
                }
                lblKayitSayisi.Text = dgPersonelGrubu.Rows.Count.ToString();
            }
            catch (Exception hata)
            {
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(dgPersonelGrubu.CurrentRow.Cells["grupAdi"].Value.ToString() + " Adlı Personel grubunu silmek istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update tblPersonelGruplari set silindimi = '1' where personelGrupid = " + dgPersonelGrubu.CurrentRow.Cells["personelGrupid"].Value + " ");
                    personelGrubuListele();
                    if (_frmPersonel != null) _frmPersonel.personelGrubuListele();
                    txtPersonelGrubuAdi.Clear();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgPersonelGrubu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update tblPersonelGruplari set grupAdi='" + dgPersonelGrubu.CurrentRow.Cells["grupAdi"].Value.ToString() + "' where personelGrupid = " + dgPersonelGrubu.CurrentRow.Cells["personelGrupid"].Value + "");
                personelGrubuListele();
                if (_frmPersonel != null) _frmPersonel.personelGrubuListele();
                txtPersonelGrubuAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

    }
}
