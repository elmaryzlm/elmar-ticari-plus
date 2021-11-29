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
    public partial class frmPersonelisebaslatistencikar : Form
    {
        public frmPersonelisebaslatistencikar()
        {
            InitializeComponent();
            NesneGorselleri.form(this,Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgiseGirisCikisGecmisi);
            NesneGorselleri.dataGridView(dgMaasMiktarlari);
            NesneGorselleri.dataGridView(dgMaasMiktarlari2);
            NesneGorselleri.kontrolEkle(panel4);
            NesneGorselleri.kontrolEkle(panel2);
            NesneGorselleri.kontrolEkle(tabPage1);
            NesneGorselleri.kontrolEkle(tabPage4);
            NesneGorselleri.kontrolEkle(tabPage3);
            NesneGorselleri.kontrolEkle(tabPage10);
            NesneGorselleri.kontrolEkle(tabPage8);
        }

        private void frmPersonelisebaslatistencikar_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
        }

        void listeleriDoldur()
        {
            cmbPersonelAdlari.Items.Clear();
            cmbPersonelinCalistigiSube.Items.Clear();
            cmbProgramKullanicisi.Items.Clear();
            listeler.doldurSube(cmbPersonelinCalistigiSube);            
            try { cmbPersonelAdlari.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
        }
        private long seciiliPersonelid = 0;
        private void cmbPersonelAdlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciiliPersonelid = listeler.getPersonelid()[cmbPersonelAdlari.SelectedIndex];
            bilgileriGetir();
        }
        void bilgileriGetir()
        {
            p1.Value = 0;
            lblDurum.Text = "Hazır";

            dtiseGirisTarihi.Enabled = true;
            txtiseGirisSaati.Enabled = true;
            txtSicilNo.Enabled = true;
            txtSigortaNo.Enabled = true;
            txtVergiNo.Enabled = true;
            cmbProgramKullanicisi.Enabled = true;
            cmbPersonelinCalistigiSube.Enabled = true;
            panel4.Enabled = true;
            txtAciklama.Enabled = true;
            btniseBaslat.Enabled = true;
            dtistenAyrilmaTarihi.Enabled = true;
            txtistenAyrilmaTarihi.Enabled = true;
            btnistenCikart.Enabled = true;
            txtCikisAciklamasi.Enabled = true;
            tabControl2.SelectedIndex = 0;

            //genel personel bilgileri getiriliyor.
            p1.Value = 1;
            lblDurum.Text = "Personel Bilgileri Getiriliyor";
            this.Refresh();

            SqlDataReader dr = veri.getDatareader("select durumu,sicilNo,sigortaNo,vergiNo,resim,calistigiSubeAdi,kAdi,aylikUcret, gunlukCalismaSaati, otomatikMaasAtamasiYapilsinmi, eklenmeTarihi from sorPersonelBilgileri where personelid = " + seciiliPersonelid + " and firmaid = " + firma.firmaid + "");
            while (dr.Read())
            {
                txtEklenmeTarihi.Text = dr["eklenmeTarihi"].ToString();
                txtDurum.Text = dr["durumu"].ToString();
                txtSicilNo.Text = dr["sicilNo"].ToString();
                txtSigortaNo.Text = dr["sigortaNo"].ToString();
                txtVergiNo.Text = dr["vergiNo"].ToString();
                picPersonelResmi.Tag = dr["resim"].ToString();
                cmbPersonelinCalistigiSube.Text = dr["calistigiSubeAdi"].ToString();
                cmbProgramKullanicisi.Text = dr["kAdi"].ToString();
                txtAylikUcret.Text = dr["aylikUcret"].ToString();
                try{txtGunlukCalismaSaati.Value = Convert.ToInt32(dr["gunlukCalismaSaati"]);}
                catch{}
                
                chkOtomatikMaasAtamasiYapilsin.Checked = false;
                if (dr["otomatikMaasAtamasiYapilsinmi"].ToString() == "1") chkOtomatikMaasAtamasiYapilsin.Checked = true;
            }

            //işe başlama metinleri dolduruluyor
            p1.Value = 3;
            lblDurum.Text = "İşe Başlatma Bilgileri Güncelleniyor";
            this.Refresh();

            SqlDataReader dr2 = veri.getDatareader("select top 1 kayitTarihi, kayitSaati, kayitTuru, aciklama  from sorPersonelGirisCikis where kayitTuru = 'İşe Başladı' and personelid = " + seciiliPersonelid + " and firmaid = " + firma.firmaid + " order by girisCikisid desc");
            while (dr2.Read())
            {
                dtiseGirisTarihi.Value = Convert.ToDateTime(dr2["kayitTarihi"]);
                txtiseGirisSaati.Text = dr2["kayitSaati"].ToString();
                txtAciklama.Text = dr2["aciklama"].ToString();
            }

            //işten ayrılma metinleri dolduruluyor
            p1.Value = 5;
            lblDurum.Text = "İşten Ayrılma Bilgileri Güncelleniyor";
            this.Refresh();

            SqlDataReader dr3 = veri.getDatareader("select top 1 kayitTarihi, kayitSaati, kayitTuru, aciklama  from sorPersonelGirisCikis where kayitTuru = 'İşten Ayrıldı' and personelid = " + seciiliPersonelid + " and firmaid = " + firma.firmaid + " order by girisCikisid desc");
            while (dr3.Read())
            {
                dtistenAyrilmaTarihi.Value = Convert.ToDateTime(dr3["kayitTarihi"]);
                txtistenAyrilmaTarihi.Text = dr3["kayitSaati"].ToString();
                txtCikisAciklamasi.Text = dr3["aciklama"].ToString();
            }

            //nesne aktiflikleri ayarlanıyor
            p1.Value = 6;
            lblDurum.Text = "Nesneler Aktifleştiriliyor";
            this.Refresh();

            SqlDataReader dr4 = veri.getDatareader("select top 1 kayitTuru from sorPersonelGirisCikis where  personelid = " + seciiliPersonelid + " and firmaid = " + firma.firmaid + " order by girisCikisid desc");
            while (dr4.Read())
            {
                if (dr4["kayitTuru"].ToString() == "İşe Başladı")
                {
                    dtiseGirisTarihi.Enabled = false;
                    txtiseGirisSaati.Enabled = false;
                    txtSicilNo.Enabled = false;
                    txtSigortaNo.Enabled = false;
                    txtVergiNo.Enabled = false;
                    cmbProgramKullanicisi.Enabled = false;
                    cmbPersonelinCalistigiSube.Enabled = false;
                    panel4.Enabled = false;
                    txtAciklama.Enabled = false;
                    btniseBaslat.Enabled = false;
                    tabControl2.SelectedIndex = 2;
                }
                else if (dr4["kayitTuru"].ToString() == "İşten Ayrıldı")
                {
                    tabControl2.SelectedIndex = 2;
                    dtistenAyrilmaTarihi.Enabled = false;
                    txtistenAyrilmaTarihi.Enabled = false;
                    btnistenCikart.Enabled = false;
                    txtCikisAciklamasi.Enabled = false;
                }
            }

            //işe giriş çıkış geçmişi listeleniyor.
            p1.Value = 8;
            lblDurum.Text = "İşe giriş-çıkış geçmişi listeleniyor";
            this.Refresh();

            dgiseGirisCikisGecmisi.DataSource = veri.getdatatable("select kayitTarihi as 'Tarih', kayitSaati as 'Saat', kayitTuru as 'İşlem Türü',aciklama as 'Açıklama', eklenmeTarihi from sorPersonelGirisCikis where firmaid = "+firma.firmaid+" and personelid = "+seciiliPersonelid+" order by eklenmeTarihi desc");
            dgiseGirisCikisGecmisi.Columns["eklenmeTarihi"].Visible = false;

            //Maaş geçmişi listeleniyor.
            p1.Value = 10;
            lblDurum.Text = "Maaş geçmişi listeleniyor";
            this.Refresh();

            dgMaasMiktarlari2.DataSource = dgMaasMiktarlari.DataSource = veri.getdatatable("select tutar as 'Tutar', turu as 'İşlem Tipi',kayitTarihi as 'Tarih', kayitSaati  as 'Saat', aciklama as 'Açıklama' from sorPersonelMaas where firmaid = " + firma.firmaid + " and personelid = " + seciiliPersonelid + " and silindimi = '0' order by maasid desc");
            lblDurum.Text = "Hazır";
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGunlukUcret_TextChanged(object sender, EventArgs e)
        {
            txtSaatlikUcret.Text = (Convert.ToDouble(txtGunlukUcret.Text) / Convert.ToInt32(txtGunlukCalismaSaati.Value)).ToString();
        }

        private void txtAylikUcret_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGunlukUcret.Text = (Convert.ToDouble(txtAylikUcret.Text) / 30).ToString();
            }
            catch{}
        }
        float aylikUcret = 0;
        private void btniseBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("exec spSetPersoneliseBaslat " + seciiliPersonelid + ", '" + txtSicilNo.Text + "','" + txtSigortaNo.Text + "','" + txtVergiNo.Text + "','" + dtiseGirisTarihi.Value + "','" + txtiseGirisSaati.Text + "'," + personelinCalistigiSubeid + "," + plesiyerid + ",'" + aylikUcret + "'," + txtGunlukCalismaSaati.Value + "," + txtOdemeGunu.Value + ",'" + (byte)chkOtomatikMaasAtamasiYapilsin.CheckState + "','" + txtAciklama.Text + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + "");
                MessageBox.Show(cmbPersonelAdlari.Text + " başarıyla işe başlatıldı. Artık Maaş ve prim sistemi aktif olarak çalışacaktır", firma.programAdi);
                this.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde bir hata ile karşılaşıldı./n Hata Metni: "+ hata.Message , firma.programAdi);
            }
        }
        int personelinCalistigiSubeid = 0;
        private void cmbPersonelinCalistigiSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbProgramKullanicisi, ComboboxItem.getSelectedValue(cmbPersonelinCalistigiSube));
            personelinCalistigiSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbPersonelinCalistigiSube));
        }
        int plesiyerid = 0;
        private void cmbProgramKullanicisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            plesiyerid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbProgramKullanicisi));
        }

        private void btnistenCikart_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("exec spSetPersonelistenCikar " + seciiliPersonelid + ", '" + txtSicilNo.Text + "','" + txtSigortaNo.Text + "','" + txtVergiNo.Text + "','" + dtistenAyrilmaTarihi.Value + "','" + txtistenAyrilmaTarihi.Text + "','" + txtCikisAciklamasi.Text + "','"+(byte)chkOtomatikMaasAtamasiYapilsin.CheckState+"'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + "");
                MessageBox.Show(cmbPersonelAdlari.Text + " İşten Ayrıldı. Artık bu personel için maaş ve prim sistemi pasif olarak çalışacaktır.", firma.programAdi);
                this.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kaydetme işleminde bir hata ile karşılaşıldı./n Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}