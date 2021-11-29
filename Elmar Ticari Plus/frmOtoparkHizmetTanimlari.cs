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
    public partial class frmOtoparkHizmetTanimlari : Form
    {
        public frmOtoparkHizmetTanimlari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmOtopark"]);
            NesneGorselleri.dataGridView(dgHizmetTanim);
            NesneGorselleri.kontrolEkle(panel2);
        }

        private void frmOtoparkHizmetTanimlari_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            dgHizmetTanim.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select hizmetid, adi, fiyat From oTblHizmetTaslak Where firmaid = "+firma.firmaid+"  And silindimi = '0' Order by adi asc");
            while (dr.Read())
            {
                dgHizmetTanim.Rows.Add(dr["hizmetid"].ToString(), dr["adi"].ToString(), Convert.ToDouble(dr["fiyat"]));
            }
            lblKayitSayisi.Text = dgHizmetTanim.Rows.Count.ToString();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into oTblHizmetTaslak(adi, fiyat, firmaid, subeid, kullaniciid) values('" + txtHizmetAdi.Text + "', '" + txtFiyat.Text.Replace(".", "").Replace(",", ".") + "', " + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                txtHizmetAdi.Clear();
                txtFiyat.Text = "0";
                listele();
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
                if (MessageBox.Show(dgHizmetTanim.CurrentRow.Cells["adi"].Value.ToString() + " Adlı hizmeti silmek istediğinizden emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update oTblHizmetTaslak set silindimi = '1' where hizmetid = " + dgHizmetTanim.CurrentRow.Cells["hizmetid"].Value + " ");
                    txtHizmetAdi.Clear();
                    txtFiyat.Text = "0";
                    listele();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgHizmetTanim_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update oTblHizmetTaslak set adi='" + dgHizmetTanim.CurrentRow.Cells["adi"].Value.ToString() + "', fiyat='" + dgHizmetTanim.CurrentRow.Cells["fiyat"].Value.ToString().Replace(".", "").Replace(",", ".") + "' where hizmetid = " + dgHizmetTanim.CurrentRow.Cells["hizmetid"].Value + "");
                txtHizmetAdi.Clear();
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
