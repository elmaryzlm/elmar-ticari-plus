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
    public partial class frmBankaKrediKarti : Form
    {
        public frmBankaKrediKarti()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgBankaKrediKarti);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(groupBox9);
        }

        private void frmBankaKrediKarti_Load(object sender, EventArgs e)
        {
            btnSorgula.PerformClick();
        }

        public void bankaListele()
        {
            dgBankaKrediKarti.Rows.Clear();
            string sorgu = " ";

            if (chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '1' ";
            else if (!chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '0' ";

            if (txtHesapKesim.Text != "") sorgu = sorgu + " and hesapKesim " + cmbHesapKesim.Text + " " + txtHesapKesim.Text + " ";
            if (txtSonOdemeGunu.Text != "") sorgu = sorgu + " and sonOdeme " + cmbSonOdemeGunu.Text + " " + txtSonOdemeGunu.Text + " ";
            if (txtKartLimiti.Text != "") sorgu = sorgu + " and kartLimiti " + cmbKartLimiti.Text + " " + txtKartLimiti.Text.Replace(".", "").Replace(",", ".") + " ";
            if (txtBankaHesapAdi.Text != "") sorgu = sorgu + " and bankaAdi like '%" + txtBankaHesapAdi.Text + "%'";
            if (txtAyrinti.Text != "") sorgu = sorgu + " and ayrinti like '%" + txtAyrinti.Text + "%'";
            SqlDataReader dr = veri.getDatareader("SELECT [krediKartid], [bankaHesapid], [hesapAdi], [bankaAdi], [hesapKesim], [sonOdeme], [kartLimit], [ayrinti] from [sorBankaKrediKarti] where firmaid = "+firma.firmaid+ sorgu+ " order by bankaAdi asc");
            while (dr.Read())
            {
                dgBankaKrediKarti.Rows.Add(dr["krediKartid"].ToString(), dr["bankaHesapid"].ToString(), dr["hesapAdi"].ToString(), dr["bankaAdi"].ToString(), dr["hesapKesim"].ToString(), dr["sonOdeme"].ToString(), dr["kartLimit"].ToString(), dr["ayrinti"].ToString());
            }
            lblKayitSayisi3.Text = "Kayıt Sayısı: " + dgBankaKrediKarti.Rows.Count.ToString();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            bankaListele();
        }

        private void btnKrediKartiEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kredi_Kartı_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaKrediKartiEkle frm = new frmBankaKrediKartiEkle();
            frm._frmBankaKrediKarti = this;
            frm.Show();
        }

        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {

        }

        private void raporGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRaporGoruntule.PerformClick();
        }

        private void yeniBankaTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnKrediKartiEkle.PerformClick();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kredi_Kartı_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            try
            {
                veri.cmd("Update tblBankaKrediKarti set silindimi ='1' where krediKartid = " + dgBankaKrediKarti.CurrentRow.Cells["krediKartid"].Value + " ");
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
                veri.cmd("Update tblBankaKrediKarti set silindimi ='0' where krediKartid = " + dgBankaKrediKarti.CurrentRow.Cells["krediKartid"].Value + " ");
                bankaListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işlemi geri alınırken sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kredi_Kartı_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
            DataGridViewRow rw = dgBankaKrediKarti.CurrentRow;
            frmBankaKrediKartiEkle frm = new frmBankaKrediKartiEkle(rw.Cells["krediKartid"].Value.ToString(), rw.Cells["bankaHesapAdi"].Value.ToString(), rw.Cells["hesapKesim"].Value.ToString(), rw.Cells["sonOdeme"].Value.ToString(), rw.Cells["kartLimit"].Value.ToString(), rw.Cells["ayrinti"].Value.ToString());
            frm.Show();
        }
    }
}
