using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.Data.SqlClient;
using System.Diagnostics;
namespace Elmar_Ticari_Plus
{
    public partial class frmFirmaSubeBilgileri : Form
    {
        int seciliSubeid = 0;
        string seciliSubeAdi = "";

        public frmFirmaSubeBilgileri()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgSubeler);
            NesneGorselleri.kontrolEkle(pnlBilgileri);
        }

        private void frmFirmaSubeBilgileri_Load(object sender, EventArgs e)
        {
            subeListele();
            temizle();
            ters();
        }
        void subeListele()
        {
            dgSubeler.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("SELECT [subeid],[subeAdi],[bolgeid],[bolgeAdi],[adres],[tel],[gsm],[fax],[email],[vergiDaire],[vergiNo],[altBilgiNotu],[eklenmeTarihi] FROM [ElmarTicariPlus].[dbo].[sorFirmaSubeleri] where firmaid = '" + firma.firmaid + "' order by subeAdi asc");
            while(dr.Read())
            {
                dgSubeler.Rows.Add(dr["subeid"].ToString(), dr["subeAdi"].ToString(), dr["bolgeid"].ToString(), dr["bolgeAdi"].ToString(), dr["adres"].ToString(), dr["tel"].ToString(), dr["gsm"].ToString(), dr["fax"].ToString(), dr["email"].ToString(), dr["vergiDaire"].ToString(), dr["vergiNo"].ToString(), dr["altBilgiNotu"].ToString(), dr["eklenmeTarihi"].ToString());
            }
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            int mevcutSubeSayisi = Convert.ToInt32(veri.getdatacell("select count(*) from sorFirmaSubeleri where  firmaid = " + firma.firmaid));
            int maxSubeSayisi = Convert.ToInt32(firmaBilgileri.maxSubeSayisi);
            
            if (mevcutSubeSayisi + 1 > maxSubeSayisi)
            {
                MessageBox.Show("Maksimum Şube sayısına ulaşmışsınız. Yeni şube eklemek için üst pakete geçmelisiniz. Elmar Yazılım ile irtibata geçin.", firma.programAdi);
                Process.Start(Application.StartupPath + "\\Yardım.exe", "1é" + firma.kullaniciid.ToString());
                return;
            }
            duz();
            temizle();
            txtSubeAdi.Select();
            deger = 1;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgSubeler.Rows.Count == 1)
                {
                    MessageBox.Show("Son kalan şubenizi silemezsiniz.", firma.programAdi);
                    return;
                }
                if (seciliSubeid == 0)
                {
                    MessageBox.Show("Listeden işlem yapılacak şubeyi seçin", firma.programAdi);
                    return;
                }
                if (MessageBox.Show(seciliSubeAdi + " adlı şubeyi Silmek İstediğinize Eminmisiniz?", firma.programAdi, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    veri.cmd("Update tblFirmaSubeleri set silindimi = '1' where subeid = " + seciliSubeid + " and firmaid = " + firma.firmaid + "");
                    temizle();
                    dgSubeler.Rows.Remove(dgSubeler.CurrentRow);
                    listeler.yukleSube();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Silinemedi\nHata Metni: " + hata.Message, firma.programAdi);
            }          
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (seciliSubeid == 0)
            {
                MessageBox.Show("Listeden işlem yapılacak şubeyi seçin", firma.programAdi);
                return;
            }
            duz();
            txtSubeAdi.Select();
            deger = 2;
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            ters();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtSubeAdi.Text == "")
            {
                MessageBox.Show("Şube Adı alanı boş bırakılamaz.", firma.programAdi);
                txtSubeAdi.Select();
                return;
            }
            try
            {
                //Şube bilgileri ekleniyor
                seciliSubeid = Convert.ToInt32(veri.getdatacell("Exec spSetFirmaSubeBilgileri "+seciliSubeid+", '"+txtSubeAdi.Text+"', '"+txtBolge.Tag.ToString()+"', '"+txtAdres.Text+"', '"+txtTel.Text+"', '"+txtGsm.Text+"', '"+txtFax.Text+"', '"+txtEmail.Text+"', '"+txtVergiDairesi.Text+"', '"+txtVergiNo.Text+"', '"+txtAltBilgiNotu.Text+"', "+firma.firmaid+", "+firma.kullaniciid+""));
                seciliSubeAdi = txtSubeAdi.Text;

                if (deger == 1)
                {
                    dgSubeler.Rows.Add(seciliSubeid, txtSubeAdi.Text, txtBolge.Tag.ToString(), txtBolge.Text, txtAdres.Text, txtTel.Text, txtGsm.Text, txtFax.Text, txtEmail.Text, txtVergiDairesi.Text, txtVergiNo.Text, txtAltBilgiNotu.Text, DateTime.Now, "0");
                    dgSubeler.Rows[dgSubeler.Rows.Count - 1].Cells[1].Selected = true;
                }
                else if (deger == 2)
                {
                    subeListele();
                }
                listeler.yukleSube();
                this.Refresh();
            }
            catch(Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. \nHata Metni: "+hata.Message);
            }
            ters();
        }
        void ters()
        {
            btnDegistir.Enabled = true;
            btnEkle.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            btnİptal.Enabled = false;
            pnlBilgileri.Enabled = false;
            dgSubeler.Enabled = true;
        }
        void duz()
        {
            btnDegistir.Enabled = false;
            btnEkle.Enabled = false;
            btnSil.Enabled = false;
            btnKaydet.Enabled = true;
            btnİptal.Enabled = true;
            pnlBilgileri.Enabled = true;
            dgSubeler.Enabled = false;
        }
      
        void temizle()
        {
            txtSubeAdi.Clear();
            txtBolge.Text = "";
            txtBolge.Tag = "0";
            seciliSubeid = 0;
            seciliSubeAdi = "";
            txtAdres.Clear();
            txtEmail.Clear();
            txtGsm.Clear();
            txtTel.Clear();
            txtFax.Clear();
            txtVergiNo.Clear();
            txtVergiDairesi.Clear();
            txtEklenmeTarihi.Clear();
            txtAltBilgiNotu.Clear();
            dgSubeler.ClearSelection();
            deger = 0;
        }
        byte deger = 0;

        private void dgSubeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seciliSubeid = Convert.ToInt32(dgSubeler.CurrentRow.Cells["subeid"].Value);
                seciliSubeAdi = dgSubeler.CurrentRow.Cells["subeAdi"].Value.ToString();
                txtSubeAdi.Text = dgSubeler.CurrentRow.Cells["subeAdi"].Value.ToString();
                txtBolge.Tag = dgSubeler.CurrentRow.Cells["bolgeid"].Value.ToString();
                txtBolge.Text = dgSubeler.CurrentRow.Cells["bolgeAdi"].Value.ToString();
                txtAdres.Text = dgSubeler.CurrentRow.Cells["adres"].Value.ToString();
                txtTel.Text = dgSubeler.CurrentRow.Cells["tel"].Value.ToString();
                txtGsm.Text = dgSubeler.CurrentRow.Cells["gsm"].Value.ToString();
                txtFax.Text = dgSubeler.CurrentRow.Cells["fax"].Value.ToString();
                txtEmail.Text = dgSubeler.CurrentRow.Cells["email"].Value.ToString();
                txtVergiDairesi.Text = dgSubeler.CurrentRow.Cells["vergiDaire"].Value.ToString();
                txtVergiNo.Text = dgSubeler.CurrentRow.Cells["vergiNo"].Value.ToString();
                txtAltBilgiNotu.Text = dgSubeler.CurrentRow.Cells["altBilgiNotu"].Value.ToString();
                txtEklenmeTarihi.Text = dgSubeler.CurrentRow.Cells["eklenmeTarihi"].Value.ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void txtBolgeSec_Click(object sender, EventArgs e)
        {
            frmBolgeSecimi frm = new frmBolgeSecimi();
            frm._frmFirmaSubeBilgileri = this;
            frm.Show();
        }
    }
}
