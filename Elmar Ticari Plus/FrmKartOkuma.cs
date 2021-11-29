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
    public partial class FrmKartOkuma : Form
    {
        public FrmKartOkuma()
        {
            InitializeComponent();
            NesneGorselleri.dataGridView(dgCariRaporu);
        }

        private void Listele()
        {
            dgCariRaporu.Rows.Clear();
            SqlDataReader dr = veri.getDatareader(@"SELECT     dbo.tblCariKartPuani.kartPuanid, dbo.tblCariBilgileri.adi, dbo.tblCariBilgileri.soyadi, dbo.tblCariKartPuani.miktar, dbo.tblCariKartPuani.eklenmeTarihi
                                                    FROM  dbo.tblCariBilgileri INNER JOIN
                                                    dbo.tblCariKartPuani ON dbo.tblCariBilgileri.cariid = dbo.tblCariKartPuani.cariid Where tblCariBilgileri.firmaid = " + firma.firmaid + "  And tblCariBilgileri.silindimi = '0' Order by eklenmetarihi asc");
            while (dr.Read())
            {
                dgCariRaporu.Rows.Add(dr["adi"].ToString(), dr["soyadi"].ToString(), Convert.ToDouble(dr["miktar"]),Convert.ToDateTime(dr["eklenmetarihi"]));
            }
        }
        private void FrmKartOkuma_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("insert into tblCariKartPuani(cariid,miktar,firmaid,subeid,kullaniciid) values (65750," + txtKalan.Text + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                MessageBox.Show("İşlem tamamlandı", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }


        void tutarHesapla()
        {
            txtKalan.Text = ((Convert.ToDouble(txtBakiye.Text) - Convert.ToDouble(txtMiktar.Text)).ToString());
        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            tutarHesapla();
        }
    }
}
