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
    public partial class frmPersonelVardiyalari : Form
    {
        public frmPersonelVardiyalari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgPersonelVardiyalari);
            NesneGorselleri.kontrolEkle(panel12);
            listeler.doldurSube(cmbSubeler);
            try { cmbPersonel.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
            vardiyaListele();
        }
        public List<long> listVardiyaid = new List<long>();
        public void vardiyaListele()
        {
            listVardiyaid.Clear();
            cmbVardiya.Items.Clear();
            SqlDataReader dr = veri.getDatareader("Select vardiyaid, vardiyaAdi + ' (' + CAST(baslangicSaati AS varchar(5)) + ' - ' + CAST(bitisSaati AS varchar(5)) + ')' AS vardiyaAdi from sorPersonelVardiyaTanim where firmaid = " + firma.firmaid + " order by vardiyaAdi asc");
            while (dr.Read())
            {
                listVardiyaid.Add(Convert.ToInt64(dr["vardiyaid"]));
                cmbVardiya.Items.Add(dr["vardiyaAdi"].ToString());
            }
        }
        public void listele()
        {
            string sorgu = "";
            if (cmbPersonel.Text != "") sorgu = sorgu + " and personelid = "+listeler.getPersonelid()[cmbPersonel.SelectedIndex]+"";
            if (cmbVardiya.Text != "") sorgu = sorgu + " and vardiyaid = " + listVardiyaid[cmbVardiya.SelectedIndex] + "";
            if (cmbSubeler.Text != "") sorgu = sorgu + " and subeid = " + ComboboxItem.getSelectedValue(cmbSubeler) + "";
            if (chkSilinenKayitlariGoster.Checked) sorgu = sorgu + " and silindimi = '1'";
            if (chkSilinenKayitlariGoster.Checked==false) sorgu = sorgu + " and  silindimi = '0'";
            dgPersonelVardiyalari.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select personelVardiyaid, personelid, personelAdiSoyadi, vardiyaid, vardiyaAdi,baslangicTarihi,bitisTarihi, tatilGunu, subeid, subeAdi, kullaniciid, eklenmeTarihi from sorPersonelVardiyalari where firmaid = " + firma.firmaid +sorgu+ " order by bitisTarihi desc, baslangicTarihi desc , personelAdiSoyadi asc");
            while (dr.Read())
            {
                dgPersonelVardiyalari.Rows.Add(dr["personelVardiyaid"].ToString(), dr["personelid"].ToString(), dr["personelAdiSoyadi"].ToString(), dr["vardiyaid"].ToString(), dr["vardiyaAdi"].ToString(), dr["baslangicTarihi"].ToString(),dr["bitisTarihi"].ToString(), dr["tatilGunu"].ToString(), dr["subeid"].ToString(), dr["subeAdi"].ToString(), "Düzenle", "Sil");
            }
            lblKayitSayisi.Text = "Kayıt Sayısı: " + dgPersonelVardiyalari.Rows.Count.ToString();
        }
        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmPersonelVardiyalari_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnHesapEkle_Click(object sender, EventArgs e)
        {
            frmPersonelVardiyasiEkle frm = new frmPersonelVardiyasiEkle();
            frm._frmPersonelVardiyalari = this;
            frm.Show();
        }

        private void dgPersonelVardiyalari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgPersonelVardiyalari.Columns["duzenle"].Index)
            {
                //Düzenle
                frmPersonelVardiyasiEkle frm = new frmPersonelVardiyasiEkle();
                frm._frmPersonelVardiyalari = this;
                frm.personelVardiyaid = Convert.ToInt32(dgPersonelVardiyalari.CurrentRow.Cells["personelVardiyaid"].Value);
                frm.vardiyaid = Convert.ToInt32(dgPersonelVardiyalari.CurrentRow.Cells["vardiyaid2"].Value);
                frm.cmbVardiya.Text = dgPersonelVardiyalari.CurrentRow.Cells["vardiyaAdi2"].Value.ToString();
                frm.personelid = Convert.ToInt32(dgPersonelVardiyalari.CurrentRow.Cells["personelid"].Value);
                frm.cmbPersonel.Text = dgPersonelVardiyalari.CurrentRow.Cells["personelAdi"].Value.ToString();
                frm.txtTatilGunleri.Text = dgPersonelVardiyalari.CurrentRow.Cells["tatilGunu"].Value.ToString();
                frm.dtBaslangicTarihi.Value = Convert.ToDateTime(dgPersonelVardiyalari.CurrentRow.Cells["baslangicTarihi"].Value);
                frm.dtBitisTarihi.Value = Convert.ToDateTime(dgPersonelVardiyalari.CurrentRow.Cells["bitisTarihi"].Value);
                frm.Show();
            }
            else if (e.ColumnIndex == dgPersonelVardiyalari.Columns["sil"].Index)
            {
                if (MessageBox.Show("Seçili kayıt silinsin mi ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    veri.cmd("Update tblPersonelVardiyalari Set silindimi = '1' Where personelVardiyaid= " + dgPersonelVardiyalari.CurrentRow.Cells["personelVardiyaid"].Value + "");
                    listele();
                }
            }
        }
    }
}
