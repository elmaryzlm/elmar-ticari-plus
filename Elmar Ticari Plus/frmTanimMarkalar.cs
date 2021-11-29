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
    public partial class frmTanimMarkalar : Form
    {
        public frmTanimMarkalar()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgMarkaTanim);
            NesneGorselleri.kontrolEkle(panel2);
        }

        private void frmTanimMarkalar_Load(object sender, EventArgs e)
        {
            markaAdiListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMarkaAdi.Text == "")
                {
                    MessageBox.Show("Lütfen eklenecek marka adını girin.", firma.programAdi);
                    txtMarkaAdi.Select();
                    return;
                }
                veri.cmd("insert into tblMarkalar(markaAdi, firmaid) values('" + txtMarkaAdi.Text + "'," + firma.firmaid + ")");
                listeler.yukleMarka();
                markaAdiListele();
                txtMarkaAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
        void markaAdiListele()
        {
            try
            {
                dgMarkaTanim.Rows.Clear();
                for (int i = 0; i < listeler.getMarkano().Count(); i++)
                {
                    dgMarkaTanim.Rows.Add(listeler.getMarkano()[i], listeler.getMarkaadi()[i]);
                }
                lblKayitSayisi.Text = dgMarkaTanim.Rows.Count.ToString();
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
                if (MessageBox.Show(dgMarkaTanim.CurrentRow.Cells["markaAdi"].Value.ToString() + " Adlı markayı silmek istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Update tblMarkalar set silindimi = '1' where markaid = " + dgMarkaTanim.CurrentRow.Cells["markaid"].Value + " ");
                    listeler.yukleMarka();
                    markaAdiListele();
                    txtMarkaAdi.Clear();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgMarkaTanim_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Update tblMarkalar set markaAdi='" + dgMarkaTanim.CurrentRow.Cells["markaAdi"].Value.ToString() + "' where markaid = " + dgMarkaTanim.CurrentRow.Cells["markaid"].Value + "");
                listeler.yukleMarka();
                markaAdiListele();
                txtMarkaAdi.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }
    }
}
