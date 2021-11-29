using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Elmar_Ticari_Plus
{
    public partial class frmOtoparkAboneler : Form
    {
        public frmOtoparkAboneler()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmOtopark"]);
            NesneGorselleri.dataGridView(dgAboneListesi);
        }

        private void frmOtoparkAboneler_Load(object sender, EventArgs e)
        {
            aboneListesiniYenile();
        }

        public void aboneListesiniYenile()
        {
            dgAboneListesi.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select * from oSorAbone Where firmaid = "+firma.firmaid+" Order by adi, soyadi asc");
            while (dr.Read())
            {
                dgAboneListesi.Rows.Add(dr["aboneid"].ToString(), dr["cariid"].ToString(), dr["adi"].ToString(), dr["soyadi"].ToString(), dr["plaka"].ToString(), dr["markaModel"].ToString());
            }
            lblKayitSayisi.Text = "Kayıt Sayısı: " + dgAboneListesi.Rows.Count.ToString();
        }
        private void btnYeniAboneEkle_Click(object sender, EventArgs e)
        {
            frmOtoparkAboneEkle frm = new frmOtoparkAboneEkle();
            frm._frmOtoparkAboneler = this;
            frm.Show();
        }

        private void btnAboneDuzenle_Click(object sender, EventArgs e)
        {
            frmOtoparkAboneEkle frm = new frmOtoparkAboneEkle();
            frm.aboneid = Convert.ToInt32(dgAboneListesi.CurrentRow.Cells["aboneid"].Value);
            frm._frmOtoparkAboneler = this;
            
            frm.Show();
        }

        private void btnAboneSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili abone silinsin mi?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                veri.cmd("Update oTblAbone Set silindimi = '1' Where aboneid = "+dgAboneListesi.CurrentRow.Cells["aboneid"].Value.ToString()+" And firmaid = "+firma.firmaid+"");
                aboneListesiniYenile();
            }
        }

        private void btnListeyiYenile_Click(object sender, EventArgs e)
        {
            aboneListesiniYenile();
        }

        private void btnDevir_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Devir_İşlemi)
            {
                yetkiler.mesajVer();
                return;
            }
            frmDevir frm = new frmDevir(Convert.ToInt64(dgAboneListesi.CurrentRow.Cells["cariid"].Value), dgAboneListesi.CurrentRow.Cells["adi"].Value.ToString() + " " + dgAboneListesi.CurrentRow.Cells["soyadi"].Value.ToString(), cariBilgileri.bul_cariid(Convert.ToInt64(dgAboneListesi.CurrentRow.Cells["cariid"].Value)).bakiye);
            frm.Show();
        }

        private void btnTahsilat_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Nakit_Tahsilat_ve_Ödeme)
            {
                yetkiler.mesajVer();
                return;
            }
            frmOdemeVeTahsilat frm = new frmOdemeVeTahsilat(Convert.ToInt64(dgAboneListesi.CurrentRow.Cells["cariid"].Value), dgAboneListesi.CurrentRow.Cells["adi"].Value.ToString() + " " + dgAboneListesi.CurrentRow.Cells["soyadi"].Value.ToString());
            frm.Show();
        }
    }
}
