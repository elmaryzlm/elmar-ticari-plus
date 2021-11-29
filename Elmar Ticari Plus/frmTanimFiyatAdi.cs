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
    public partial class frmTanimFiyatAdi : Form
    {
        public frmTanimFiyatAdi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgFiyatTanim);
            NesneGorselleri.kontrolEkle(panel2);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into tblFiyatTaslak(fiyatAdi, firmaid, subeid, kullaniciid) values('" + txtFiyatAdi.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                listeler.yukleFiyat();
                fiyatAdiListele();
                txtFiyatAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void frmTanimFiyatAdi_Load(object sender, EventArgs e)
        {
            fiyatAdiListele();
        }
        void fiyatAdiListele()
        {
            try
            {
                dgFiyatTanim.Rows.Clear();
                for (int i = 0; i < listeler.getFiyatid().Count(); i++)
                {
                    dgFiyatTanim.Rows.Add(listeler.getFiyatid()[i], listeler.getFiyatAdi()[i]);
                }
                lblKayitSayisi.Text = dgFiyatTanim.Rows.Count.ToString();
                _frmYeniAyrintiliStokkartEkle.baslangic();
            }
            catch
            {
            }
        }
        public frmYeniAyrintiliStokkartEkle _frmYeniAyrintiliStokkartEkle;
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(dgFiyatTanim.CurrentRow.Cells["fiyatAdi"].Value.ToString() + " Adlı fiyatı silmek istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update tblFiyatTaslak set silindimi = '1' where fiyatid = " + dgFiyatTanim.CurrentRow.Cells["fiyatid"].Value + " ");
                    listeler.yukleFiyat();
                    fiyatAdiListele();
                    txtFiyatAdi.Clear();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgBirimTanim_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update tblFiyatTaslak set fiyatAdi='" + dgFiyatTanim.CurrentRow.Cells["fiyatAdi"].Value.ToString() + "' where fiyatid = " + dgFiyatTanim.CurrentRow.Cells["fiyatid"].Value + "");
                listeler.yukleFiyat();
                fiyatAdiListele();
                txtFiyatAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
    }
}
