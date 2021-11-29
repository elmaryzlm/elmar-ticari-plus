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
    public partial class frmBankaPos : Form
    {
        public frmBankaPos()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgBankaPos);
            NesneGorselleri.kontrolEkle(groupBox9);
            NesneGorselleri.kontrolEkle(grpBelgeNumarası);
        }

        private void frmBankaPos_Load(object sender, EventArgs e)
        {
            btnSorgula.PerformClick();
        }

        public void bankaListele()
        {
            dgBankaPos.Rows.Clear();
            string sorgu = " ";

            if (chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '1' ";
            else if (!chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '0' ";


            if (txtPosAdi.Text != "") sorgu = sorgu + " and posAdi like '%" + txtPosAdi.Text + "%'";
            if (txtHesapAdi.Text != "") sorgu = sorgu + " and hesapAdi like '%" + txtHesapAdi.Text + "%'";
            if (txtTanimAdi.Text != "") sorgu = sorgu + " and adi like '%" + txtTanimAdi.Text + "%'";
            if (txtAyrinti.Text != "") sorgu = sorgu + " and ayrinti like '%" + txtAyrinti.Text + "%'";
            SqlDataReader dr = veri.getDatareader("select posid, bankaHesapid, hesapAdi, adi, posAdi, ayrinti from sorBankaPos where firmaid = "+firma.firmaid+" " + sorgu + " order by adi, posAdi asc");
            while (dr.Read())
            {
                dgBankaPos.Rows.Add(dr["posid"].ToString(), dr["bankaHesapid"].ToString(), dr["hesapAdi"].ToString(), dr["adi"].ToString(), dr["posAdi"].ToString(), dr["ayrinti"].ToString());
            }
            lblKayitSayisi3.Text = "Kayıt Sayısı: " + dgBankaPos.Rows.Count.ToString();
            dgBankaPos.ClearSelection();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            bankaListele();
        }

        private void btnPosEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Pos_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaPosEkle frm = new frmBankaPosEkle();
            frm._frmBankaPos = this;
            frm.Show();
        }

        private void raporGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRaporGoruntule.PerformClick();
        }

        private void yeniBankaTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPosEkle.PerformClick();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Pos_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            try
            {
                veri.cmd("update tblBankaPos set silindimi ='1' where posid = " + dgBankaPos.CurrentRow.Cells["posid"].Value + " ");
                
                bankaListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silmede sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void silmeİşleminiGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("update tblBankaPos set silindimi ='0' where posid = " + dgBankaPos.CurrentRow.Cells["posid"].Value + " ");
                bankaListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işlemi geri alınırken sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgBankaPos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgTaksitOranlari.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("select posTaksitid, taksitSayisi, aylikOran from sorBankaPosTaksit where silindimi = '0' and firmaid = " + firma.firmaid + " and posid = " + dgBankaPos.CurrentRow.Cells["posid"].Value.ToString() + " order by taksitSayisi");
                while (dr.Read())
                {

                    string aylikOran = "-";
                    if (dr["aylikOran"].ToString() != "-1") aylikOran = dr["aylikOran"].ToString();
                    dgTaksitOranlari.Rows.Add(dr["posTaksitid"].ToString(), dr["taksitSayisi"].ToString(), aylikOran);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata Metni: "+ hata.Message, firma.programAdi);
            }
        }

        private void dgTaksitOranlari_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string aylikOran = "-1";
                if (dgTaksitOranlari.CurrentRow.Cells["aylikOran"].Value.ToString() != "-") aylikOran = dgTaksitOranlari.CurrentRow.Cells["aylikOran"].Value.ToString();
                veri.getdatacell("exec spSetBankaPosTaksitleri " + dgTaksitOranlari.CurrentRow.Cells["posTaksitid"].Value.ToString() + ", " + dgBankaPos.CurrentRow.Cells["posid"].Value.ToString() + ", " + dgTaksitOranlari.CurrentRow.Cells["taksitSayisi"].Value.ToString() + ", " + aylikOran + ", " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");
                
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Pos_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
        }
    }
}
