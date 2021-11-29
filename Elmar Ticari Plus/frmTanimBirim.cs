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
    public partial class frmTanimBirim : Form
    {
        public frmTanimBirim()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgBirimTanim);
            NesneGorselleri.kontrolEkle(panel2);
        }

        private void frmTanimBirim_Load(object sender, EventArgs e)
        {
            birimListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into tblBirimler(birimAdi, firmaid, subeid, kullaniciid) values('" + txtBirimAdi.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                listeler.yukleBirim();
                birimListele();
                txtBirimAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: "+hata.Message,firma.programAdi);
            }
            

        }
        void birimListele()
        {
            try
            {
                dgBirimTanim.Rows.Clear();
                for (int i = 0; i < listeler.getBirimid().Count(); i++)
                {
                    dgBirimTanim.Rows.Add(listeler.getBirimid()[i], listeler.getBirimAdi()[i]);
                }
                lblKayitSayisi.Text = dgBirimTanim.Rows.Count.ToString();
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
                if (MessageBox.Show(dgBirimTanim.CurrentRow.Cells["birimAdi"].Value.ToString() + " Adlı birimi silemk istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dgBirimTanim.CurrentRow.Cells["birimAdi"].Value.ToString() == "Adet")
                    {
                        MessageBox.Show("Bu birimi silemezsiniz.", firma.programAdi);
                        return;
                    }
                    veri.cmd("Update tblBirimler set silindimi = '1' where birimid = " + dgBirimTanim.CurrentRow.Cells["birimid"].Value + " ");
                    listeler.yukleBirim();
                    birimListele();
                    txtBirimAdi.Clear();
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
                veri.cmd("Update tblBirimler set birimAdi='" + dgBirimTanim.CurrentRow.Cells["birimAdi"].Value.ToString() + "' where birimid = " + dgBirimTanim.CurrentRow.Cells["birimid"].Value + "");
                listeler.yukleBirim();
                birimListele();
                txtBirimAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgBirimTanim_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgBirimTanim.CurrentRow.Cells["birimAdi"].Value.ToString() == "Adet")
            {
                MessageBox.Show("Bu birimi düzenleyemezsiniz.", firma.programAdi);
                dgBirimTanim.CancelEdit();
                return;
            }
        }
    }
}