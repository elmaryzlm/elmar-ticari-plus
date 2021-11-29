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
    public partial class frmBankalar : Form
    {
        public frmBankalar()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgBankalar);
            NesneGorselleri.kontrolEkle(groupBox9);
            NesneGorselleri.kontrolEkle(grpBelgeNumarası);
        }

        private void frmBankalar_Load(object sender, EventArgs e)
        {
            if (_frmBankaHesapEkle != null)
                dgBankalar.Columns["sec"].Visible = true;
        }
        public frmBankaHesapEkle _frmBankaHesapEkle = null;
        public void bankaListele()
        {
            dgBankalar.Rows.Clear();
            string sorgu = " ";
            if (chkFirmamTarafindanEklenmisOlanKayitlar.Checked && chkTaslaktaMevcutBulunanKayitlar.Checked) sorgu = sorgu + " where (firmaid = " + firma.firmaid + "  or firmaid  is null) ";
            else if (chkFirmamTarafindanEklenmisOlanKayitlar.Checked && !chkTaslaktaMevcutBulunanKayitlar.Checked) sorgu = sorgu + " where firmaid = " + firma.firmaid + " ";
            else if (!chkFirmamTarafindanEklenmisOlanKayitlar.Checked && chkTaslaktaMevcutBulunanKayitlar.Checked) sorgu = sorgu + " where  firmaid  is null ";

            if (chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '1' ";
            else if (!chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '0' ";

            
            if (txtBankaAdi.Text != "") sorgu = sorgu + " and bankaAdi like '%"+txtBankaAdi.Text+"%'";
            if (txtil.Text != "") sorgu = sorgu + " and il like '%" + txtil.Text + "%'";
            if (txtilce.Text != "") sorgu = sorgu + " and ilce like '%" + txtilce.Text + "%'";
            if (txtSubeAdi.Text != "") sorgu = sorgu + " and subeAdi like '%" + txtSubeAdi.Text + "%'";
            if (txtAdres.Text != "") sorgu = sorgu + " and adres like '%" + txtAdres.Text + "%'";
            if (txtAciklama.Text != "") sorgu = sorgu + " and aciklama like '%" + txtAciklama.Text + "%'";
            SqlDataReader dr = veri.getDatareader("select bankaid, bankaAdi, subeAdi, il, ilce, adres, tel, faks, aciklama, firmaid from sorBankaTaslak " + sorgu + " order by bankaAdi, subeAdi");
            while (dr.Read())
            {
                dgBankalar.Rows.Add(dr["bankaid"].ToString(), "Seç", dr["bankaAdi"].ToString(), dr["subeAdi"].ToString(), dr["il"].ToString(), dr["ilce"].ToString(), dr["adres"].ToString(), dr["tel"].ToString(), dr["faks"].ToString(), dr["aciklama"].ToString(), dr["firmaid"].ToString());
            }
            lblKayitSayisi3.Text = "Kayıt Sayısı: " + dgBankalar.Rows.Count.ToString();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            bankaListele();
        }

        private void btnBankaEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Banka_Ekle_Düzenle_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaEkle frm = new frmBankaEkle();
            frm._frmBankalar = this;
            frm.Show();
        }

        private void cmbBankalar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void raporGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRaporGoruntule.PerformClick();
        }

        private void yeniBankaTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBankaEkle.PerformClick();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Banka_Ekle_Düzenle_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            try
            {
                if (dgBankalar.CurrentRow.Cells["firmaid"].Value.ToString().Length == 0)
                {
                    MessageBox.Show("Taslakta bulunan kayıtları silemezsiniz. Sadece kendi firmanızdan eklediğiniz bankaları silebilirsiniz.",firma.programAdi);
                    return;
                }
                veri.cmd("update tblBankaTaslak set silindimi ='1' where bankaid = " + dgBankalar.CurrentRow.Cells["bankaid"].Value + " ");

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
                veri.cmd("update tblBankaTaslak set silindimi ='0' where bankaid = " + dgBankalar.CurrentRow.Cells["bankaid"].Value + " ");
                bankaListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işlemi geri alınırken sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void dgBankalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (e.ColumnIndex == dgBankalar.Columns["sec"].Index)
                //{
                //    _frmBankaHesapEkle.txtBankaAdi.Text = dgBankalar.CurrentRow.Cells["bankaAdi"].Value.ToString() + " " + dgBankalar.CurrentRow.Cells["subeAdi"].Value.ToString();
                //    _frmBankaHesapEkle.txtBankaAdi.Tag = dgBankalar.CurrentRow.Cells["bankaid"].Value.ToString();
                //    this.Close();
                //}
            }
            catch {
            }
     
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Banka_Ekle_Düzenle_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
        }
    }
}
