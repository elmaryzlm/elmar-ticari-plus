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
    public partial class frmMasraflar : Form
    {
        List<int> listMasrafKartid = new List<int>();
        List<int> listHastaid = new List<int>();
        public frmMasraflar()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(pnlAna);
            NesneGorselleri.kontrolEkle(pnlCari);
            NesneGorselleri.kontrolEkle(pnlHasta);
            NesneGorselleri.kontrolEkle(pnlListeler);
            NesneGorselleri.kontrolEkle(pnlPersonel);
            NesneGorselleri.kontrolEkle(pnlUst);
            NesneGorselleri.kontrolEkle(panel4);
            NesneGorselleri.kontrolEkle(panel5);
            NesneGorselleri.kontrolEkle(panel6);
            NesneGorselleri.kontrolEkle(panel7);
            NesneGorselleri.kontrolEkle(panel8);
            NesneGorselleri.kontrolEkle(panel9);
            NesneGorselleri.kontrolEkle(panel10);
            listeler.doldurSube(cmbSubeler);
            masrafKartiListele();
        }

        public void masrafKartiListele()
        {
            try
            {
                listMasrafKartid.Clear();
                cmbMasrafKartSecimi.Items.Clear();
                SqlDataReader dr = veri.getDatareader("Select masrafKartid, masrafAdi from tblMasrafKartlari where firmaid = " + firma.firmaid + " and silindimi = '0' order by masrafAdi asc");
                while (dr.Read())
                {
                    listMasrafKartid.Add(Convert.ToInt32(dr["masrafKartid"]));
                    cmbMasrafKartSecimi.Items.Add(dr["masrafAdi"].ToString());
                }
                if (cmbMasrafKartSecimi.Items.Count > 0) cmbMasrafKartSecimi.SelectedIndex = 0;
            }
            catch { }
        }
        private void frmMasraflar_Load(object sender, EventArgs e)
        {
            if (firma.hastane == "1") cmbMasrafTipi.Items.Add("Hizmet Alan Gideri");
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
        }
        void panelleriGizle()
        {
            pnlCari.Visible = false;
            pnlHasta.Visible = false;
            pnlPersonel.Visible = false;
        }
        private void cmbMasrafTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMasrafTipi.Text == "Firma Gideri")
            {
                panelleriGizle();
            }
            else if(cmbMasrafTipi.Text == "Personel Gideri")
            {
                try { cmbPersonelSecimi.Items.Clear(); cmbPersonelSecimi.Items.AddRange(listeler.getPersonelAdi()); }
                catch { }
                panelleriGizle();
                pnlPersonel.Visible = true;
            }
            else if (cmbMasrafTipi.Text == "Cari Gideri")
            {
                try { cmbCariSecimi.Items.Clear(); cmbCariSecimi.Items.AddRange(listeler.getCariAdi()); }
                catch { }
                panelleriGizle();
                pnlCari.Visible = true;
            }
            else if (cmbMasrafTipi.Text == "Hizmet Alan Gideri")
            {
                try
                {
                    if (cmbHastaSecimi.Items.Count == 0)
                    {
                        listHastaid.Clear();
                        cmbHastaSecimi.Items.Clear();
                        SqlDataReader dr = veri.getDatareader("select hastaid,(isnull(adi,'')+' '+isnull(soyadi,'')) as hastaAdiSoyadi from hTblHastalar where firmaid = " + firma.firmaid + " and silindimi = 'h' order by adi,soyadi ");

                        while (dr.Read())
                        {
                            listHastaid.Add(Convert.ToInt32(dr["hastaid"]));
                            cmbHastaSecimi.Items.Add(dr["hastaAdiSoyadi"].ToString());
                        }
                        if (cmbHastaSecimi.Items.Count > 0) cmbHastaSecimi.SelectedIndex = 0;
                    }
                }
                catch{}
                panelleriGizle();
                pnlHasta.Visible = true;
            }
            else 
            {
                MessageBox.Show("Geçerli bir Masraf Tipi seçmediniz.",firma.programAdi);
                cmbMasrafTipi.Select();
            }
        }
        public int masrafid = 0;
        public int masrafKartid = 0;
        public long cariid = 0;
        public long personelid = 0;
        public int hastaid = 0;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbMasrafKartSecimi.Items.Contains(cmbMasrafKartSecimi.Text) == false)
                {
                    MessageBox.Show("Geçerli bir masraf kartı seçin",firma.programAdi);
                    cmbMasrafKartSecimi.Select();
                    return;
                } 
                masrafKartid = listMasrafKartid[cmbMasrafKartSecimi.SelectedIndex];
                if (cmbMasrafTipi.Text == "Personel Gideri")
                {
                    personelid = listeler.getPersonelid()[cmbPersonelSecimi.SelectedIndex];
                }
                else if (cmbMasrafTipi.Text == "Cari Gideri")
                {
                    cariid = listeler.getCariid()[cmbCariSecimi.SelectedIndex];
                }
                else if (cmbMasrafTipi.Text == "Hizmet Alan Gideri")
                {
                    hastaid = listHastaid[cmbHastaSecimi.SelectedIndex];
                }
                veri.cmd("Exec spSetMasraflar2 " + masrafid + ", " + masrafKartid + ", '" + dtislemTarihi.Value + "', '" + txtTutar.Text.Replace(".", "").Replace(",", ".") + "','" + txtBelgeNo.Text + "' , '" + txtAciklama.Text + "','" + cmbMasrafTipi.Text + "', " + hastaid + ", " + personelid + ", " + cariid + ",0, " + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbSubeler) + ", " + ComboboxItem.getSelectedValue(cmbKullanicilar) + "");
                temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde bir hata oluştu.\nHata Metni: "+hata.Message,firma.programAdi);
            }
        }
        void temizle()
        {
            txtAciklama.Clear();
            txtTutar.Text = "0";
            masrafid = 0;
            cmbMasrafKartSecimi.Select();
        }
        private void btnMasrafKartiEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Masraf_Kartı_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimMasrafKartlari frm = new frmTanimMasrafKartlari();
            frm._frmMasraflar = this;
            frm.Show();
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
        }
    }
}
