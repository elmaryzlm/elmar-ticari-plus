using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Elmar_Ticari_Plus;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmTanimDepartman : Form
    {
        public frmTanimDepartman()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgDepartmanTanim);
            NesneGorselleri.kontrolEkle(panel2);
        }

        private void frmTanimDepartman_Load(object sender, EventArgs e)
        {
            departmanListele();
        }
        public frmPersonel _frmPersonel = null;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into tblPersonelDepartmanTanim(adi, firmaid, subeid, kullaniciid) values('" + txtDepartmanAdi.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                departmanListele();
                if (_frmPersonel != null) _frmPersonel.departmanListele();
                txtDepartmanAdi.Clear();
                txtDepartmanAdi.Select();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
        void departmanListele()
        {
            try
            {
                dgDepartmanTanim.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("select departmanid, adi from sorPersonelDepartmanTanim where firmaid = " + firma.firmaid + " order by adi");
                while (dr.Read())
                {
                    dgDepartmanTanim.Rows.Add(dr["departmanid"].ToString(), dr["adi"].ToString());
                }

                lblKayitSayisi.Text = dgDepartmanTanim.Rows.Count.ToString();
            }
            catch (Exception hata)
            { 
            
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(dgDepartmanTanim.CurrentRow.Cells["departmanAdi"].Value.ToString() + " Adlı Departmanı silmek istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update tblPersonelDepartmanTanim set silindimi = '1' where departmanid = " + dgDepartmanTanim.CurrentRow.Cells["departmanid"].Value + " ");
                    departmanListele();
                    if (_frmPersonel != null) _frmPersonel.departmanListele();
                    txtDepartmanAdi.Clear();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgDepartmanTanim_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update tblPersonelDepartmanTanim set adi='" + dgDepartmanTanim.CurrentRow.Cells["departmanAdi"].Value.ToString() + "' where departmanid = " + dgDepartmanTanim.CurrentRow.Cells["departmanid"].Value + "");
                departmanListele();
                if (_frmPersonel != null) _frmPersonel.departmanListele();
                txtDepartmanAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
    }
}
