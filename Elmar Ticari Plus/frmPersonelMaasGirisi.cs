using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmPersonelMaasGirisi : Form
    {
        public frmPersonelMaasGirisi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.kontrolEkle(this);
        }
        string maasid = "0";
        public frmPersonelMaasGirisi(string maasid,long personelid, string personelAdiSoyadi, string tutar, string islemTuru, DateTime islemTarihi, string islemSaati, string aciklama)
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            txtTutar.Text = tutar;
            cmbislemTuru.Text = islemTuru;
            dtislemTarihi.Value = islemTarihi;
            txtislemSaati.Text = islemSaati;
            txtAciklama.Text = aciklama;
            cmbPersonelAdlari.Text = personelAdiSoyadi;
            this.cmbPersonelAdlari.Text = "Personel Maaşı Düzenle";
            seciiliPersonelid = personelid;
            btnTemizle.Visible = false;
        }

        private void frmPersonelMaasGirisi_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
        }
        void listeleriDoldur()
        {
            cmbPersonelAdlari.Items.Clear();
            try { cmbPersonelAdlari.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
        }
        private long seciiliPersonelid = 0;
        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void cmbPersonelAdlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciiliPersonelid = listeler.getPersonelid()[cmbPersonelAdlari.SelectedIndex];
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("exec [spSetPersonelMaas] " + maasid + "," + seciiliPersonelid + ",'" + txtTutar.Text.Replace(".", "").Replace(",", ".") + "','" + cmbislemTuru.Text + "','" + dtislemTarihi.Value + "','" + txtislemSaati.Text + "','" + txtAciklama.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + "");
                MessageBox.Show("Kaydetme işlemi başarıyla gerçekleşti", firma.programAdi);
                this.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void cmbislemTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbislemTuru.Text== "Maaş Girişi")lblislemAciklamasi.Text = "Personelin alacağını artırır";
            if(cmbislemTuru.Text== "Prim Girişi")lblislemAciklamasi.Text = "Personelin alacağını artırır";
            if(cmbislemTuru.Text== "Maaş Ödemesi")lblislemAciklamasi.Text = "Personelin alacağını azaltır";
            if (cmbislemTuru.Text == "Prim Ödemesi") lblislemAciklamasi.Text = "Personelin alacağını azaltır";
            if (cmbislemTuru.Text == "Avans") lblislemAciklamasi.Text = "Personelin alacağını azaltır";
            if (cmbislemTuru.Text == "Kesinti") lblislemAciklamasi.Text = "Personelin alacağını azaltır";
            if (cmbislemTuru.Text == "İkramiye") lblislemAciklamasi.Text = "Personelin alacağına etki etmez";
            if (cmbislemTuru.Text == "Yemek Ödemesi") lblislemAciklamasi.Text = "Personelin alacağını azaltır";
            if (cmbislemTuru.Text == "Yol Ödemesi") lblislemAciklamasi.Text = "Personelin alacağını azaltır";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            maasid = "0";
            seciiliPersonelid = 0 ;
            txtAciklama.Clear();
            txtislemSaati.Clear();
            txtTutar.Text = "0";
            cmbislemTuru.Text = "";
            cmbPersonelAdlari.Text = "";
        }
    }
}
