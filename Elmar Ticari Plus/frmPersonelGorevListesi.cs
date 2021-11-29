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
    public partial class frmPersonelGorevListesi : Form
    {
        public frmPersonelGorevListesi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgGorevler);
            NesneGorselleri.kontrolEkle(panel1);
            NesneGorselleri.kontrolEkle(panel12);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(groupBox2);
            NesneGorselleri.kontrolEkle(groupBox9);
            NesneGorselleri.kontrolEkle(grpİslemTarihi);
        }

        private void frmPersonelGorevListesi_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
            temizle();
            gorevListele();
        }
        void listeleriDoldur()
        {
            cmbPersonelAdlari.Items.Clear();
            try { cmbPersonelAdlari.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
            listeler.doldurSube(cmbSubeler);
        }

        void gorevListele()
        {
            dgGorevler.Rows.Clear();
            string sorgu = " ";
            if (cmbPersonelAdlari.SelectedIndex >= 0) sorgu = sorgu + " and personelid = "+listeler.getPersonelid()[cmbPersonelAdlari.SelectedIndex]+" ";
            if (txtGorevAdi.Text != "") sorgu = sorgu + " and gorevAdi like '%"+txtGorevAdi.Text+"%' ";
            if (txtGorevTanimi.Text != "") sorgu = sorgu + " and gorevTanimi like '%" + txtGorevTanimi.Text + "%' ";
            if (txtKalanGun.Text != "") sorgu = sorgu + " and kalanGun "+cmbKalanGun.Text+" " + txtKalanGun.Text + " ";
            if (txtYorumSayisi.Text != "") sorgu = sorgu + " and yorumSayisi " + cmbYorumSayisi.Text + " " + txtYorumSayisi.Text + " ";
            if (cmbSubeler.SelectedIndex >= 0) sorgu = sorgu + " and subeid = " + ComboboxItem.getSelectedValue(cmbSubeler) + " ";
            if (cmbKullanicilar.SelectedIndex >= 0) sorgu = sorgu + " and kullaniciid = " + ComboboxItem.getSelectedValue(cmbKullanicilar) + " ";
            if (chkBaslangicTarihi.Checked == true) sorgu = sorgu + " and gorevBaslangiTarihi = '" + dtBaslangictarihi.Value + "' ";
            if (chkBitisTarihi.Checked == true) sorgu = sorgu + " and gorevBitisTarihi = '" + dtBitisTarihi.Value + "' ";
            if (chkBitenGorevleriGoster.Checked == true) sorgu = sorgu + " and gorevBittimi = '1' ";
            else sorgu = sorgu + " and gorevBittimi = '0' ";

            if (chkSilinenKayitlariGoster.Checked == true) sorgu = sorgu + " and silindimi = '1' ";
            else sorgu = sorgu + " and silindimi = '0' ";
            

            SqlDataReader dr = veri.getDatareader("select gorevid, personelid, personelAdi, gorevAdi, gorevTanimi, gorevBaslangiTarihi, gorevBitisTarihi, baslangicSaati, bitisSaati, kalanGun, yorumSayisi, gorevBittimi, aciklama from sorPersonelGorevleri where firmaid = "+firma.firmaid+" "+sorgu+" order by gorevBittimi, kalanGun asc");
            while (dr.Read())
            {
                dgGorevler.Rows.Add(dr["gorevid"].ToString(), dr["personelid"].ToString(), dr["personelAdi"].ToString(), dr["gorevAdi"].ToString(), dr["gorevTanimi"].ToString(), dr["gorevBaslangiTarihi"].ToString(), dr["gorevBitisTarihi"].ToString(), dr["baslangicSaati"].ToString(), dr["bitisSaati"].ToString(), dr["kalanGun"].ToString()+" gün", dr["yorumSayisi"].ToString(), Convert.ToBoolean(Convert.ToByte(dr["gorevBittimi"])), dr["aciklama"].ToString());
            }

            lblKayitSayisi3.Text = dgGorevler.Rows.Count.ToString();
        }
        long seciliPersonelid = 0;
        long seciliGorevid = 0;
        private void dgGorevler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seciliPersonelid = Convert.ToInt64(dgGorevler.CurrentRow.Cells["personelid"].Value);
                seciliGorevid = Convert.ToInt64(dgGorevler.CurrentRow.Cells["gorevid"].Value);
                txtPersonelAdi2.Text = dgGorevler.CurrentRow.Cells["personelAdi"].Value.ToString();
                txtGorevAdi2.Text = dgGorevler.CurrentRow.Cells["gorevAdi"].Value.ToString();
                txtGorevTanimi2.Text = dgGorevler.CurrentRow.Cells["gorevTanimi"].Value.ToString();
                dtBaslangicTarihi2.Value = Convert.ToDateTime(dgGorevler.CurrentRow.Cells["gorevBaslangicTarihi"].Value);
                dtBitisTarihi2.Value =Convert.ToDateTime(dgGorevler.CurrentRow.Cells["gorevBitisTarihi"].Value);
                txtBaslangicSaati.Text = dgGorevler.CurrentRow.Cells["baslangicSaati"].Value.ToString();
                txtSonlanmaSaati.Text = dgGorevler.CurrentRow.Cells["bitisSaati"].Value.ToString();
                txtAciklama2.Text = dgGorevler.CurrentRow.Cells["aciklama"].Value.ToString();
            }
            catch 
            {
                
            }
        }
        void temizle()
        {
            try
            {
                seciliPersonelid = 0;
                seciliGorevid = 0;
                txtPersonelAdi2.Text = "";
                txtGorevAdi2.Text = "";
                txtGorevTanimi2.Text = "";
                txtBaslangicSaati.Text = "";
                txtSonlanmaSaati.Text = "";
                txtAciklama2.Text = "";
                dtBaslangicTarihi2.Text = "";
                dtBitisTarihi2.Text = "";
                dgGorevler.ClearSelection();
            }
            catch 
            {
                
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Görev_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
            try
            {
                veri.cmd("exec [spSetPersonelGorevleri] " + seciliGorevid + "," + seciliPersonelid + ",'" + txtGorevAdi2.Text + "','" + txtGorevTanimi2.Text + "','" + dtBaslangicTarihi2.Value + "','" + dtBitisTarihi2.Value + "','" + txtBaslangicSaati.Text + "','" + txtSonlanmaSaati.Text + "','" + txtAciklama2.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + "");
                dgGorevler.CurrentRow.Cells["gorevAdi"].Value = txtGorevAdi2.Text;
                dgGorevler.CurrentRow.Cells["gorevTanimi"].Value = txtGorevTanimi2.Text;
                dgGorevler.CurrentRow.Cells["gorevBaslangicTarihi"].Value = dtBaslangicTarihi2.Text;
                dgGorevler.CurrentRow.Cells["gorevBitisTarihi"].Value = dtBitisTarihi2.Text;
                dgGorevler.CurrentRow.Cells["baslangicSaati"].Value = txtBaslangicSaati.Text;
                dgGorevler.CurrentRow.Cells["bitisSaati"].Value = txtSonlanmaSaati.Text;
                dgGorevler.CurrentRow.Cells["aciklama"].Value = txtAciklama2.Text;
                MessageBox.Show("Kayıt Başarıyla Güncellendi.", firma.programAdi);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            gorevListele();
        }

        private void dgGorevler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("update tblPersonelGorevleri set gorevBittimi = '" + Convert.ToByte(dgGorevler.CurrentRow.Cells["gorevBittimi"].Value) + "' where gorevid = " + dgGorevler.CurrentRow.Cells["gorevid"].Value.ToString() + " and firmaid = " + firma.firmaid + "");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. Hata Metni: "+hata.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Görev_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            if (MessageBox.Show(dgGorevler.CurrentRow.Cells["personelAdi"].Value.ToString() +" - "+dgGorevler.CurrentRow.Cells["gorevAdi"].Value.ToString() + "  silmek istediğinizden emin misiniz ? ", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                veri.cmd("update tblPersonelGorevleri set silindimi = '1' where gorevid = " + dgGorevler.CurrentRow.Cells["gorevid"].Value.ToString() + " ");
                dgGorevler.Rows.Remove(dgGorevler.CurrentRow);
                temizle();
            }
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
            gorevListele();
        }
    }
}
