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
    public partial class frmTanimMasrafKartlari : Form
    {
        public frmTanimMasrafKartlari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgMasrafKartTanim);
            NesneGorselleri.kontrolEkle(panel2);
        }
        public frmMasraflar _frmMasraflar = null;
        private void frmTanimMasrafKartlari_Load(object sender, EventArgs e)
        {
            masrafAdiListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into tblMasrafKartlari(masrafAdi, firmaid, subeid, kullaniciid) values('" + txtMasrafAdi.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                //listeler.yukleMasrafKartlari();
                masrafAdiListele();
                txtMasrafAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        void masrafAdiListele()
        {
            try
            {
                dgMasrafKartTanim.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("Select masrafKartid, masrafAdi from tblMasrafKartlari where firmaid = "+firma.firmaid+" and silindimi = '0'");
                while (dr.Read())
                {
                    dgMasrafKartTanim.Rows.Add(dr["masrafKartid"].ToString(), dr["masrafAdi"].ToString());
                }
                lblKayitSayisi.Text = dgMasrafKartTanim.Rows.Count.ToString();
                if (_frmMasraflar != null) _frmMasraflar.masrafKartiListele();
            }
            catch
            {
            }
        }
        
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(dgMasrafKartTanim.CurrentRow.Cells["masrafAdi"].Value.ToString() + " Adlı Masraf Kartını silmek istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update tblMasrafKartlari set silindimi = '1' where masrafKartid = " + dgMasrafKartTanim.CurrentRow.Cells["masrafKartid"].Value + " ");
                    //listeler.yukleMasrafAdi();
                    masrafAdiListele();
                    txtMasrafAdi.Clear();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgMasrafKartTanim_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update tblMasrafKartlari set masrafAdi='" + dgMasrafKartTanim.CurrentRow.Cells["masrafAdi"].Value.ToString() + "' where masrafKartid = " + dgMasrafKartTanim.CurrentRow.Cells["masrafKartid"].Value + "");
                //listeler.yukleMasrafKartlari();
                masrafAdiListele();
                txtMasrafAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
    }
}