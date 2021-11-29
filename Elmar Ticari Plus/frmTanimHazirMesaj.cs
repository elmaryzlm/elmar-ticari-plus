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
    public partial class frmTanimHazirMesaj : Form
    {
        public frmTanimHazirMesaj()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgHazirMesaj);
            NesneGorselleri.kontrolEkle(panel2);

            mesajListele();
            txtMesaj.MaxLength = 155 - firma.firmaAdi.Length;
        }

        private void mesajListele()
        {
            try
            {
                dgHazirMesaj.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("Select hazirMesajID, Adi, Mesaj,mesajSaati from tblHazirMesaj Where firmaId = " + firma.firmaid + " and silindimi = '0'");
                while (dr.Read())
                {
                    dgHazirMesaj.Rows.Add(dr["hazirMesajID"].ToString(), dr["Adi"].ToString(), dr["Mesaj"].ToString(), dr["mesajSaati"].ToString());
                }
                lblKayitSayisi.Text = dgHazirMesaj.Rows.Count.ToString();
            }
            catch
            {
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text.Length < 0)
                {
                    MessageBox.Show("Saati giriniz.!"); return;
                }
                if (txtHazirMesajAdi.Text.Length < 0)
                {
                    MessageBox.Show("Mesajı adını giriniz.!"); return;
                }
                if (txtMesaj.Text.Length < 0)
                {
                    MessageBox.Show("Mesajı giriniz.!"); return;
                }
                veri.cmd("insert into tblHazirMesaj(Adi, Mesaj,mesajSaati, firmaID, subeID, kullaniciID) values('" + txtHazirMesajAdi.Text + "','" + txtMesaj.Text + " " + firma.firmaAdi + "','" + maskedTextBox1.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                mesajListele();
                txtMesaj.Clear();
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
                if (MessageBox.Show(dgHazirMesaj.CurrentRow.Cells["mesajAdi"].Value.ToString() + " Adlı Mesajı silmek istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update tblHazirMesaj set silindimi = '1' where HazirMesajID = " + dgHazirMesaj.CurrentRow.Cells["HazirMesajID"].Value + " ");

                    mesajListele();
                    txtMesaj.Clear();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgHazirMesaj_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update tblHazirMesaj set Adi='" + dgHazirMesaj.CurrentRow.Cells["mesajAdi"].Value.ToString() + "', Mesaj='" + dgHazirMesaj.CurrentRow.Cells["MesajIcerik"].Value.ToString() + "',mesajSaati='" + dgHazirMesaj.CurrentRow.Cells["mesajSaati"].Value.ToString() + "'  where HazirMesajID = " + dgHazirMesaj.CurrentRow.Cells["HazirMesajID"].Value + "");
                guncelle.cariBilgileriVerileriniGuncelle();
                guncelle.bilgileriGuncelle();
                mesajListele();
                txtMesaj.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
    }
}
