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
namespace Elmar_Ticari_Plus
{
    public partial class frmCekSenetEkle : Form
    {
        public enum formTipi
        {
            kendiCekimEkle, kendiSenedimEkle, musteriCekiEkle, musteriSenediEkle, kendiCekimDuzenle, kendiSenedimDuzenle, musteriCekiDuzenle, musteriSenediDuzenle
        }
        string formTipiMetni = "";
        public frmCekSenetEkle(formTipi formTipi,long cariid, string cariAdi)
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(panel9);
            NesneGorselleri.kontrolEkle(panel6);
            NesneGorselleri.kontrolEkle(panel7);
            NesneGorselleri.kontrolEkle(panel8);
            NesneGorselleri.kontrolEkle(pnlCekNo);
            NesneGorselleri.kontrolEkle(panel2);
            NesneGorselleri.kontrolEkle(groupBox2);
            NesneGorselleri.kontrolEkle(groupBox3);

            if (cariid != 0)
            {
                this.cariid = cariid;
                cmbCariler.Text = cariAdi;
            }
            if (formTipi == frmCekSenetEkle.formTipi.kendiCekimEkle)
            {
                lblBaslik.Text = "Kendi Çekim Ekle";
                pnlCekNo.Visible = true;
                pnlBanka.Visible = true;
                formTipiMetni = "Kendi Çekim";
                bankaHesabiListele();
                this.Size = new Size(516, 563);
            }
            else if (formTipi == frmCekSenetEkle.formTipi.kendiSenedimEkle)
            {
                lblBaslik.Text = "Kendi Senedim Ekle";
                lblCekSenetBaslik.Text = "Senet No";
                formTipiMetni = "Kendi Senedim";
            }
            else if (formTipi == frmCekSenetEkle.formTipi.musteriCekiEkle)
            {
                lblBaslik.Text = "Müşteri Çeki Ekle";
                pnlCekNo.Visible = true;
                formTipiMetni = "Müşteri Çeki";
                bankaListele();
                panel9.Visible = true;
            }
            else if (formTipi == frmCekSenetEkle.formTipi.musteriSenediEkle)
            {
                lblBaslik.Text = "Müşteri Senedi Ekle";
                lblCekSenetBaslik.Text = "Senet No";
                formTipiMetni="Müşteri Senedi";
                bankaListele();
                panel9.Visible = true;
            }
            else if (formTipi == frmCekSenetEkle.formTipi.kendiCekimDuzenle)
            {
                lblBaslik.Text = "Kendi Çekim Düzenle";
                pnlCekNo.Visible = true;
                pnlBanka.Visible = true;
                formTipiMetni = "Kendi Çekim";
                bankaHesabiListele();
                this.Size = new Size(516, 563);
            }
            else if (formTipi == frmCekSenetEkle.formTipi.kendiSenedimDuzenle)
            {
                lblBaslik.Text = "Kendi Senedim Düzenle";
                lblCekSenetBaslik.Text = "Senet No";
                formTipiMetni = "Kendi Senedim";
            }
            else if (formTipi == frmCekSenetEkle.formTipi.musteriCekiDuzenle)
            {
                lblBaslik.Text = "Müşteri Çeki Düzenle";
                pnlCekNo.Visible = true;
                formTipiMetni = "Müşteri Çeki";
                bankaListele();
                panel9.Visible = true;
            }
            else if (formTipi == frmCekSenetEkle.formTipi.musteriSenediDuzenle)
            {
                lblBaslik.Text = "Müşteri Senedi Düzenle";
                lblCekSenetBaslik.Text = "Senet No";
                formTipiMetni = "Müşteri Senedi";
                bankaListele();
                panel9.Visible = true;
            }
            this.Text = lblBaslik.Text;

        }
        public frmCekSenetListele _frmCekSenetListele = null;
        public frmCekSenetileTahsilatveOdeme _frmCekSenetileTahsilatveOdeme = null;
        private void frmCekSenetEkle_Load(object sender, EventArgs e)
        {
            cariListesiniYenile();
            if (this.cekSenetid != 0) bilgileriGetir();
        }
        List<int> listBankaid = new List<int>();
        void bankaListele()
        {
            cmbBanka.Items.Clear();
            listBankaid.Clear();
            SqlDataReader dr = veri.getDatareader("select bankaid, bankaAdi from tblBankaisimleri where bankaid > 1 order by bankaAdi");
            while (dr.Read())
            {
                listBankaid.Add(Convert.ToInt32(dr["bankaid"]));
                cmbBanka.Items.Add(dr["bankaAdi"].ToString());
            }
            cmbBanka.SelectedIndex = -1;
        }
        public void cariListesiniYenile()
        {
            cmbCariler.Items.Clear();
            try
            {
                cmbCariler.Items.AddRange(listeler.getCariAdi());
            }
            catch { }
        }
        public Int64 cekSenetid = 0;
        private Int64 cariid = 0;        
        private Int64 bankaHesapid2 = 0;
        private void btnCariEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCariKartEkle frm = new frmCariKartEkle();
            frm._frmCekSenetEkle = this;
            frm.Show();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbCariler.SelectedIndex == -1)
            {
                MessageBox.Show("Cari Seçin", firma.programAdi);
                cmbCariler.Select();
                return;
            }
            int bankaid = 0;
            if (cmbBanka.SelectedIndex > -1) bankaid = listBankaid[cmbBanka.SelectedIndex];
            long eklenecekSenetid = Convert.ToInt64(veri.getdatacell("exec spSetCekSenet2 " + cekSenetid + "," + cariid + "," + bankaHesapid2 + ",'" + txtSeriNo.Text + "','" + txtCekSenetNo.Text + "','" + dtKayitTarihi.Value + "','" + dtVadeTarihi.Value + "'," + txtTutari.Text.Replace(".", "").Replace(",", ".") + ",'" + cmbDoviz.Text + "'," + txtDovizKuru.Text.Replace(".", "").Replace(",", ".") + ", 0,"+bankaid+",'"+txtSube.Text+"','" + txtAciklama.Text + "','" + cmbCariler.Text + "','" + formTipiMetni + "','" + firma.firmaid + "','" + firma.subeid + "','" + firma.kullaniciid + "'"));
            if (_frmCekSenetListele!=null) _frmCekSenetListele.cekSenetListele();
            if (_frmCekSenetileTahsilatveOdeme != null) _frmCekSenetileTahsilatveOdeme.cekSenetListele();
            if (cekSenetid != 0) this.Close();
            temizle();   
        }
        
        void bilgileriGetir()
        {
            DataRow rw = veri.getdatarow("SELECT [cekSenetid], [adiSoyadi], [cariid], [bankaHesapid], [seriNo], [CekSenetNo], [kayitTarihi], [vadeTarihi], [tutari], [dovizTuru], [dovizDegeri], [cekSenetGideri],[bankaid], [bankaAdi],[subeAdi], [aciklama] FROM [sorCekSenet] Where cekSenetid = "+cekSenetid+" and firmaid = "+firma.firmaid+"");
            cmbCariler.Text = rw["adiSoyadi"].ToString();
            cariid = Convert.ToInt64(rw["cariid"]);
            bankaHesapid2 = Convert.ToInt64(rw["bankaHesapid"]);
            if (pnlBanka.Visible == true)
            {
                for (int i = 0; i < dgAlanHesap.Rows.Count; i++)
                {
                    if (dgAlanHesap.Rows[i].Cells["bankaHesapid"].Value.ToString() == bankaHesapid2.ToString())
                    {
                        dgAlanHesap.Rows[i].Selected = true;
                        dgAlanHesap.Rows[i].Cells["hesapAdi"].Selected = true;
                        break;
                    }
                }
            }
            txtSeriNo.Text = rw["seriNo"].ToString();
            txtCekSenetNo.Text = rw["CekSenetNo"].ToString();
            dtKayitTarihi.Value = Convert.ToDateTime(rw["kayitTarihi"]);
            dtVadeTarihi.Value = Convert.ToDateTime(rw["vadeTarihi"]);
            txtTutari.Text = rw["tutari"].ToString();
            cmbDoviz.Text = rw["dovizTuru"].ToString();
            txtDovizliTutar.Text = rw["dovizDegeri"].ToString();
            txtAciklama.Text = rw["aciklama"].ToString();

            txtSube.Text = rw["subeAdi"].ToString();
            cmbBanka.Text = rw["bankaAdi"].ToString();
        }

        void temizle()
        {
            txtAciklama.Clear();
            txtCekSenetNo.Clear();
            txtSube.Text = "";
            cmbBanka.SelectedIndex = -1;
            txtSeriNo.Clear();
            txtTutari.Text = "0";            
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cariid = listeler.getCariid()[cmbCariler.SelectedIndex];
        }

        private void cmbDoviz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoviz.SelectedIndex == 1) txtDovizKuru.Text = bilgiler.dovizVerileri.dDolarsatis.ToString();
            else if (cmbDoviz.SelectedIndex == 2) txtDovizKuru.Text = bilgiler.dovizVerileri.dEurosatis.ToString();
            else txtDovizKuru.Text = "1";
        }

        private void txtTutari_TextChanged(object sender, EventArgs e)
        {
            dovizTutariHesapla();
        }
        void dovizTutariHesapla()
        {
            try
            {
                txtDovizliTutar.Text = string.Format("{0:n2}", Convert.ToDouble(txtTutari.Text) * Convert.ToDouble(txtDovizKuru.Text));
            }
            catch {
                txtDovizliTutar.Text = "0";
                txtTutari.Text = "0";
                txtDovizKuru.Text = "1";   
            }
           
        }

        public void bankaHesabiListele()
        {
            dgAlanHesap.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select bankaHesapid, bankaid, bankaAdi, subeNo, hesapAdi, hesapNo from sorBankaHesaplari where firmaid = " + firma.firmaid + " and silindimi = '0' order by hesapAdi asc");
            while (dr.Read())
            {
                dgAlanHesap.Rows.Add(dr["bankaHesapid"].ToString(), dr["bankaid"].ToString(), dr["bankaAdi"].ToString(), dr["subeNo"].ToString(), dr["hesapAdi"].ToString(), dr["hesapNo"].ToString());
            }
            dgAlanHesap.ClearSelection();
        }

        private void frmCekSenetEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnKaydet.PerformClick();
            }
        }

    }
}