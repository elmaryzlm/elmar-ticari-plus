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
    public partial class frmTopluFiyatGuncelle : Form
    {
        public frmTopluFiyatGuncelle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgFiyat);
            NesneGorselleri.kontrolEkle(this);
        }
        string sorgu = "";
        private void btnSorgula_Click(object sender, EventArgs e)
        {
            sorgu = " ";
            if (cmbCariadi.Text != "") sorgu = " and cariid = " + cariid + " ";
            sorgu = sorgu + " and (islemTarihi between '" + dtTarih1.Value + "' and '" + dtTarih2.Value + "') ";
            dgFiyat.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("SELECT [stokid],[urunAdi],max([birimFiyat])  birimFiyat FROM sorTicaret where firmaid = " + firma.firmaid + sorgu + " group by stokid, urunAdi");
            while (dr.Read())
            {
                dgFiyat.Rows.Add(dr["stokid"].ToString(), dr["urunAdi"].ToString(), dr["birimFiyat"].ToString());
            }
        }

        public void cariListesiniYenile()
        {
            cmbCariadi.Items.Clear();
            try
            {
                cmbCariadi.Items.AddRange(listeler.getCariAdi());
            }
            catch { }
        }
        private void frmTopluFiyatGuncelle_Load(object sender, EventArgs e)
        {
            cariListesiniYenile();
            cmbCariadi.Select();
        }
        private long cariid = 0;
        private void cmbCariadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cariid = listeler.getCariid()[cmbCariadi.SelectedIndex];
        }

        private void btnFiyatlariGuncelle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgFiyat.Rows.Count; i++)
            {
                veri.cmd("Update sorTicaret set birimFiyat = '" + dgFiyat.Rows[i].Cells["birimFiyat"].Value.ToString() + "' Where firmaid = " + firma.firmaid + " And stokid = " + dgFiyat.Rows[i].Cells["stokid"].Value.ToString() +" "+ sorgu);
            }
            MessageBox.Show("İşlem Başarılı", firma.programAdi);
            this.Close();
        }
    }
}
