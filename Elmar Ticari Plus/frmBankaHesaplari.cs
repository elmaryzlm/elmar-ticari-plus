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
    public partial class frmBankaHesaplari : Form
    {
        public frmBankaHesaplari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgBankaHesaplari);
            NesneGorselleri.kontrolEkle(grpBelgeNumarası);
            NesneGorselleri.kontrolEkle(groupBox9);
        }

        private void dgBankaHesaplari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        public void bankaListele()
        {
            dgBankaHesaplari.Rows.Clear();
            string sorgu = " ";

            if (chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '1' ";
            else if (!chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '0' ";

            if (txtBankaAdi.Text != "") sorgu = sorgu + " and bankaAdi like '%" + txtBankaAdi.Text + "%'";
            if (txtHesapAdi.Text != "") sorgu = sorgu + " and hesapAdi like '%" + txtHesapAdi.Text + "%'";
            if (txtHesapNo.Text != "") sorgu = sorgu + " and hesapNo like '%" + txtHesapNo.Text + "%'";
            if (txtiban.Text != "") sorgu = sorgu + " and iban like '%" + txtiban.Text + "%'";
            if (txtAyrinti.Text != "") sorgu = sorgu + " and ayrinti like '%" + txtAyrinti.Text + "%'";

            if (rdKendiHesaplarim.Checked) sorgu = sorgu + " and hesapTuru = 'Kendi Hesabım'";
            else if (rdCariHesaplarim.Checked) sorgu = sorgu + " and hesapTuru = 'Cari Hesabı' ";
            SqlDataReader dr = veri.getDatareader("select bankaHesapid,bankaid, bankaAdi, hesapAdi, subeNo, hesapNo, iban, ayrinti,cariid, cariAdiSoyadi, hesapTuru from sorBankaHesaplari where firmaid = "+firma.firmaid + sorgu + " order by bankaAdi, hesapAdi asc");
            while (dr.Read())
            {
                dgBankaHesaplari.Rows.Add(dr["bankaHesapid"].ToString(), dr["bankaid"].ToString(), dr["bankaAdi"].ToString(), dr["hesapAdi"].ToString(), dr["subeNo"].ToString(), dr["hesapNo"].ToString(), dr["iban"].ToString(), dr["cariid"].ToString(), dr["cariAdiSoyadi"].ToString(), dr["hesapTuru"].ToString(), dr["ayrinti"].ToString());
            }
            lblKayitSayisi3.Text = "Kayıt Sayısı: " + dgBankaHesaplari.Rows.Count.ToString();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            bankaListele();
        }

        private void btnHesapEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Banka_Hesabı_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaHesapEkle frm = new frmBankaHesapEkle();
            frm._frmBankaHesaplari = this;
            frm.Show();
        }

        private void raporGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRaporGoruntule.PerformClick();
        }

        private void yeniBankaTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHesapEkle.PerformClick();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Banka_Hesabı_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            try
            {
                veri.cmd("update tblBankaHesaplari set silindimi ='1' where bankaHesapid = " + dgBankaHesaplari.CurrentRow.Cells["bankaHesapid"].Value + " and firmaid = "+firma.firmaid+" ");
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
                veri.cmd("update tblBankaHesaplari set silindimi ='0' where bankaHesapid = " + dgBankaHesaplari.CurrentRow.Cells["bankaHesapid"].Value + " and firmaid = " + firma.firmaid + " ");
                bankaListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işlemi geri alınırken sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void frmBankaHesaplari_Load(object sender, EventArgs e)
        {
            btnSorgula.PerformClick();
        }

        private void chkCariHesabi_Click(object sender, EventArgs e)
        {
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Banka_Hesabı_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
            DataGridViewRow rw = dgBankaHesaplari.CurrentRow;
            frmBankaHesapEkle frm = new frmBankaHesapEkle(rw.Cells["bankaHesapid"].Value.ToString(), rw.Cells["bankaid"].Value.ToString(), rw.Cells["bankaAdi"].Value.ToString(), rw.Cells["hesapAdi"].Value.ToString(), rw.Cells["subeNo"].Value.ToString(), rw.Cells["hesapNo"].Value.ToString(), rw.Cells["iban"].Value.ToString(), rw.Cells["ayrinti"].Value.ToString(), rw.Cells["cariid"].Value.ToString(), rw.Cells["cariAdiSoyadi"].Value.ToString(), rw.Cells["hesapTuru"].Value.ToString());
            frm.Show();
        }
    }
}
