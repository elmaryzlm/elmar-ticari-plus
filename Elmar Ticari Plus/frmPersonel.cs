using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmPersonel : Form
    {
        public frmPersonel()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgPersonel);
            NesneGorselleri.dataGridView(dgMaasMiktarlari);
            NesneGorselleri.kontrolEkle(pnlAna);
            NesneGorselleri.kontrolEkle(tabAyrinti);
            NesneGorselleri.kontrolEkle(tabEgitim1);
            NesneGorselleri.kontrolEkle(tabEgitim2);
            NesneGorselleri.kontrolEkle(tabGenel);
            NesneGorselleri.kontrolEkle(tabiletisim);
            NesneGorselleri.kontrolEkle(tabiseBaslama);
            NesneGorselleri.kontrolEkle(panel4);
            NesneGorselleri.kontrolEkle(tabOzluk);
        }
        private void frmPersonel_Load(object sender, EventArgs e)
        {
            departmanListele();
            personelGrubuListele();
            subeKullaniciListele();
            ters();
        }
        void subeKullaniciListele()
        {
            cmbPersonelinCalistigiSube.Items.Clear();
            cmbSubeler.Items.Clear();
            cmbProgramKullanicisi.Items.Clear();
            listeler.doldurSube(cmbPersonelinCalistigiSube);
            listeler.doldurSube(cmbSubeler);
        }
        public long seciliPersonelid = 0;
        public string seciliPersonelAdi = "";
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        int seciliSubeid = 0;
        public void personelListele()
        {
            
            dgPersonel.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("select personelid, adi, soyadi from sorPersonelBilgileri where firmaid = " + firma.firmaid + " and silindimi = '0' and ("+seciliSubeid+" = 0 or subeid = "+seciliSubeid+") order by adi, soyadi");
            while (dr.Read())
            {
                dgPersonel.Rows.Add(dr["personelid"].ToString(), dr["adi"].ToString(), dr["soyadi"].ToString());
            }
            dgPersonel.ClearSelection();
        }
        string resimYolu = "";
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            p1.Visible = true;
            p1.Value = 0;
            lblDurum.Text = "Kontroller Yapılıyor..";
            this.Refresh();
            p1.Value++;
            if (txtAdi.Text == "")
            {
                MessageBox.Show("Personel Adı alanı boş bırakılamaz.", firma.programAdi);
                txtAdi.Select();
                return;
            }
            try
            {
                //personel bilgileri ekleniyor
                string seciliDepartmanid = "";
                if (cmbDepartman.SelectedIndex >= 0) seciliDepartmanid = listDepartmanid[cmbDepartman.SelectedIndex];
                string seciliPersonelGrubuid = "";
                if (cmbGrup.SelectedIndex >= 0) seciliPersonelGrubuid = listPersonelGrupid[cmbGrup.SelectedIndex];

                lblDurum.Text = "Personel Bilgisi Ekleniyor..";
                p1.Value++;
                this.Refresh();

                seciliPersonelid = Convert.ToInt64(veri.getdatacell("[dbo].[spSetPersonel] " + seciliPersonelid + ", '" + txtOzelKod.Text + "','" + txtTcKimlikNo.Text + "','" + txtPersonelKartNo.Text + "','','" + txtAdi.Text + "','" + txtSoyadi.Text + "','" + txtBolge.Tag.ToString() + "' ,'" + txtAdres.Text + "','" + txtEgitimBilgileri.Text + "','" + cmbEgitimDurumu.Text + "','" + cmbKanGrubu.Text + "','" + txtTel.Text + "','" + txtTel2.Text + "','" + txtGsm.Text + "','" + txtEmail.Text + "','" + txtWebSitesi.Text + "','" + txtOdemeGunu.Value + "','" + txtVergiNo.Text + "','" + txtSigortaNo.Text + "','" + txtSicilNo.Text + "','" + txtEhliyet.Text + "',"+personelinCalistigiSubeid+","+plesiyerid+",'" + resimYolu + "','" + seciliDepartmanid + "','" + seciliPersonelGrubuid + "','" + txtAyrinti.Text + "','" + txtUnvan.Text + "','" + txtUzmanlikAlanlari.Text + "','" + txtHizmeticiEgitimler.Text + "','" + txtSertifikalar.Text + "','" + cmbCinsiyet.Text + "','" + cmbMedeniDurum.Text + "','" + txtAnaAdi.Text + "','" + txtBabaAdi.Text + "','" + txtKardesBilgileri.Text + "','" + txtGiysiBedeni.Text + "','" + txtAyakkabiNo.Text + "','" + txtAylikUcret.Text.Replace(".", "").Replace(",", ".") + "','Kaydedildi'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid));
                seciliPersonelAdi = txtAdi.Text + " " + txtSoyadi;

                lblDurum.Text = "Dil Bilgileri Yükleniyor..";
                p1.Value++;
                this.Refresh();
                //diller ekleniyor
                for (int i = 0; i < dgYabanciDiller.Rows.Count; i++)
                {
                    if (dgYabanciDiller.Rows[i].Cells["dilid"].Value.ToString() == "0")
                    {
                        veri.cmd("insert into tblPersonelDilleri(dilAdi, okuma, yazma, konusma, ogrenildigiYer, personelid, firmaid, subeid, kullaniciid) values('" + dgYabanciDiller.Rows[i].Cells["dilAdi"].Value.ToString() + "','" + dgYabanciDiller.Rows[i].Cells["okuma"].Value.ToString() + "','" + dgYabanciDiller.Rows[i].Cells["yazma"].Value.ToString() + "','" + dgYabanciDiller.Rows[i].Cells["konusma"].Value.ToString() + "','" + dgYabanciDiller.Rows[i].Cells["ogrenildigiYer"].Value.ToString() + "','" + seciliPersonelid + "','" + firma.firmaid + "','" + firma.subeid + "','" + firma.kullaniciid + "')");
                    }
                }
                if (deger == 1)
                {
                    dgPersonel.Rows.Add(seciliPersonelid, txtAdi.Text, txtSoyadi.Text);
                    dgPersonel.Rows[dgPersonel.Rows.Count - 1].Cells[1].Selected = true;
                }
                else if (deger == 2)
                {
                    dgPersonel.CurrentRow.Cells["adi"].Value = txtAdi.Text;
                    dgPersonel.CurrentRow.Cells["soyadi"].Value = txtSoyadi.Text;
                }
                this.Refresh();


                //System.IO.File.Delete(Application.StartupPath + "\\KullanıcıResimleri\\personel\\personel" + seciliPersonelid.ToString() + ".png");

                if (picPersonelResmi.Image != null)
                {
                    p1.Maximum += 2;
                    picPersonelResmi.Image.Save(Application.StartupPath + "\\KullanıcıResimleri\\personel\\personel" + seciliPersonelid.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    elmarDosyaislemleri.resimYukle(picPersonelResmi.Image, "personel/personel" + seciliPersonelid.ToString() + ".png");
                    this.Refresh();
                    lblDurum.Text = "Resim Yükleniyor..";
                    p1.Value++;
                    this.Refresh();
                }

                if (chkiseBaslat.Checked && chkiseBaslat.Visible)
                {
                    p1.Maximum += 1;
                    lblDurum.Text = "İşe Başlatma Bilgileri Ekleniyor";
                    this.Refresh();
                    veri.cmd("exec spSetPersoneliseBaslat " + seciliPersonelid + ", '" + txtSicilNo.Text + "','" + txtSigortaNo.Text + "','" + txtVergiNo.Text + "','" + dtiseGirisTarihi.Value + "','" + txtiseGirisSaati.Text + "'," + personelinCalistigiSubeid + "," + plesiyerid + ",'" + txtAylikUcret.Text.Replace(".", "").Replace(",", ".") + "'," + txtGunlukCalismaSaati.Value + "," + txtOdemeGunu.Value + ",'" + (byte)chkOtomatikMaasAtamasiYapilsin.CheckState + "',''," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + "");
                    p1.Value++;
                    this.Refresh();
                }
                else if (chkiseBaslat.Visible==false)
                {
                    p1.Maximum += 1;
                    lblDurum.Text = "İşe Başlatma Bilgileri düzenleniyor";
                    this.Refresh();
                    veri.cmd("Update tblPersonelGirisCikis set kayitTarihi = '" + dtiseGirisTarihi.Value + "', kayitSaati='" + txtiseGirisSaati.Text + "' where (select top 1 girisCikisid from tblPersonelGirisCikis where firmaid = " + firma.firmaid + " and personelid = " + seciliPersonelid + " and silindimi = '0' order by eklenmeTarihi desc)  =  girisCikisid");
                    p1.Value++;
                    this.Refresh();
                }
                lblDurum.Text = "Bilgiler Güncelleniyor..";
                p1.Value++;
                this.Refresh();
                listeler.yuklePersonelAdi();
                p1.Value++;
                this.Refresh();
                dilListele();
                p1.Value++;
                lblDurum.Text = "Hazır";
                p1.Visible = false;
                this.Refresh();
                chkiseBaslat.Visible = false;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Personel işleminde bir hata oluştu.\nHata metni: " + hata.Message, firma.programAdi);
            }
            ters();
            deger = 0;
        }

        void ters()
        {
            btnDegistir.Enabled = true;
            btnEkle.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            btnİptal.Enabled = false;

            dgPersonel.Enabled = true;
            pnlAna.Enabled = false;
            tabGenel.Enabled = false;
            tabEgitim1.Enabled = false;
            tabEgitim2.Enabled = false;
            tabOzluk.Enabled = false;
            tabiletisim.Enabled = false;
            tabMaas.Enabled = false;
            tabiseBaslama.Enabled = false;
            tabAyrinti.Enabled = false;
        }
        void duz()
        {
            btnDegistir.Enabled = false;
            btnEkle.Enabled = false;
            btnSil.Enabled = false;
            btnKaydet.Enabled = true;
            btnİptal.Enabled = true;

            dgPersonel.Enabled = false;
            pnlAna.Enabled = true;
            tabGenel.Enabled = true;
            tabEgitim1.Enabled = true;
            tabEgitim2.Enabled = true;
            tabOzluk.Enabled = true;
            tabiletisim.Enabled = true;
            tabMaas.Enabled = true;
            tabiseBaslama.Enabled = true;
            tabAyrinti.Enabled = true;
        }

        void temizle()
        {
            txtOzelKod.Clear();
            txtEhliyet.Clear();
            txtUzmanlikAlanlari.Clear();
            txtSertifikalar.Clear();
            txtHizmeticiEgitimler.Clear();
            txtKardesBilgileri.Clear();
            txtSoyadi.Clear();
            txtDurum.Clear();
            cmbGrup.Text = "";
            txtBolge.Text = "";
            txtBolge.Tag = "0";
            seciliPersonelid = 0;
            seciliPersonelAdi = "";
            resimYolu = "";
            picPersonelResmi.Image = null;
            txtAdi.Clear();
            txtSicilNo.Clear();
            txtUnvan.Clear();
            cmbDepartman.Text = "";
            txtEgitimBilgileri.Clear();
            txtAnaAdi.Clear();
            txtBabaAdi.Clear();
            txtGiysiBedeni.Clear();
            txtAyakkabiNo.Clear();
            txtAylikUcret.Text = "0";
            txtGunlukUcret.Text = "0";
            txtSaatlikUcret.Text = "0";
            txtAdres.Clear();
            txtAyrinti.Clear();
            txtEgitimBilgileri.Clear();
            txtEmail.Clear();
            txtGsm.Clear();
            cmbCinsiyet.SelectedIndex = 0;
            cmbKanGrubu.SelectedIndex = 0;
            cmbEgitimDurumu.SelectedIndex = 0;
            cmbMedeniDurum.SelectedIndex = 0;
            txtOdemeGunu.Value = 1;
            txtSigortaNo.Clear();
            txtTcKimlikNo.Clear();
            txtTel.Clear();
            txtWebSitesi.Clear();
            txtVergiNo.Clear();
            dgMaasMiktarlari.DataSource = null;
            txtEklenmeTarihi.Text = "";
            dgYabanciDiller.Rows.Clear();
            cmbPersonelinCalistigiSube.SelectedIndex = -1;
            cmbProgramKullanicisi.SelectedIndex = -1;
            plesiyerid = 0;
            personelinCalistigiSubeid = 0;
            txtiseGirisSaati.Clear();
            dtiseGirisTarihi.Value = DateTime.Today;
            
        }
        byte deger = 0;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Personel_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            chkiseBaslat.Visible = true;
            chkiseBaslat.Checked = false;
            seciliPersonelid = 0;
            seciliPersonelAdi = "";
            duz();
            temizle();
            txtAdi.Select();
            deger = 1;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Personel_Sil)
            {
                yetkiler.mesajVer();
                return;
            }

            try
            {
                if (seciliPersonelid == 0)
                {
                    MessageBox.Show("Listeden işlem yapılacak personeli seçin", firma.programAdi);
                    return;
                }
                if (MessageBox.Show(seciliPersonelAdi + " isimli personeli silerseniz tüm maaş ve kişisel bilgileride silinecek. Silmek İstediğinize Eminmisiniz?", firma.programAdi, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    veri.cmd("exec spSilPersonel " + seciliPersonelid + ", "+firma.firmaid);
                    listeler.yuklePersonelAdi();
                    temizle();
                    dgPersonel.Rows.Remove(dgPersonel.CurrentRow);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Silinemedi\nHata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Personel_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
            if (seciliPersonelid == 0)
            {
                MessageBox.Show("Listeden işlem yapılacak personeli seçin", firma.programAdi);
                return;
            }
            duz();
            txtAdi.Select();
            deger = 2;
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            ters();
            chkiseBaslat.Visible = false;
        }

        private void cmbEgitimDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDepartmanEkle_Click(object sender, EventArgs e)
        {
            frmTanimDepartman frm = new frmTanimDepartman();
            frm._frmPersonel = this;
            frm.Show();
        }
        //departman listeleme fonksiyonu 
        public void departmanListele()
        {
            try
            {
                cmbDepartman.Items.Clear();
                listDepartmanid.Clear();
                SqlDataReader dr = veri.getDatareader("select departmanid, adi from sorPersonelDepartmanTanim where firmaid = " + firma.firmaid + " order by adi");
                while (dr.Read())
                {
                    cmbDepartman.Items.Add(dr["adi"].ToString());
                    listDepartmanid.Add(dr["departmanid"].ToString());
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Departmanlar Listelenemedi\nHata Metni: " + hata.Message, firma.programAdi);
            }
        }
        public List<string> listDepartmanid = new List<string>();

        public void personelGrubuListele()
        {
            try
            {
                cmbGrup.Items.Clear();
                listPersonelGrupid.Clear();
                SqlDataReader dr = veri.getDatareader("select personelGrupid, grupAdi from sorPersonelGruplari where firmaid = " + firma.firmaid + " order by grupAdi");
                while (dr.Read())
                {
                    cmbGrup.Items.Add(dr["grupAdi"].ToString());
                    listPersonelGrupid.Add(dr["personelGrupid"].ToString());
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Personel Grupları Listelenemedi\nHata Metni: " + hata.Message, firma.programAdi);
            }
        }
        public List<string> listPersonelGrupid = new List<string>();

        private void btnPersonelGrubuEkle_Click(object sender, EventArgs e)
        {
            frmTanimPersonelGrubu frm = new frmTanimPersonelGrubu();
            frm._frmPersonel = this;
            frm.Show();
        }

        private void dgYabanciDiller_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //düzenle
                if (dgYabanciDiller.CurrentRow.Cells["dilid"].Value.ToString() != "0")
                {
                    DataGridViewRow rw = dgYabanciDiller.Rows[dgYabanciDiller.Rows.Count - 1];
                    veri.cmd("update tblPersonelDilleri set dilAdi='" + rw.Cells["dilAdi"].Value.ToString() + "', okuma='" + rw.Cells["okuma"].Value.ToString() + "', yazma='" + rw.Cells["yazma"].Value.ToString() + "', konusma='" + rw.Cells["konusma"].Value.ToString() + "', ogrenildigiYer='" + rw.Cells["ogrenildigiYer"].Value.ToString() + "', personelid=" + seciliPersonelid + " where firmaid = '" + firma.firmaid + "' and dilid = " + rw.Cells["dilid"].Value.ToString() + "");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Düzenleme işleminde hata oluştu. \nHata Metni: " + hata.Message, firma.programAdi);
            }

        }
        public void dilListele()
        {
            dgYabanciDiller.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("select dilid, dilAdi, okuma, yazma, konusma, ogrenildigiYer,eklenmeTarihi from sorPersonelDilleri where personelid = " + seciliPersonelid + " and firmaid = " + firma.firmaid + "");
            while (dr.Read())
            {
                dgYabanciDiller.Rows.Add(dr["dilid"].ToString(), dr["dilAdi"].ToString(), dr["okuma"].ToString(), dr["yazma"].ToString(), dr["konusma"].ToString(), dr["ogrenildigiYer"].ToString(), dr["eklenmeTarihi"].ToString(), "Sil");
            }
            dgYabanciDiller.ClearSelection();
        }

        private void btnYeniDilEkle_Click(object sender, EventArgs e)
        {
            frmPersonelYabanciDilEkle frm = new frmPersonelYabanciDilEkle(seciliPersonelid, seciliPersonelAdi);
            frm._frmPersonel = this;
            frm.Show();
        }

        private void dgYabanciDiller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgYabanciDiller.Columns["sil"].Index)
            {
                try
                {
                    if (MessageBox.Show(dgYabanciDiller.CurrentRow.Cells["dilAdi"].Value.ToString() + " Adlı Dili silmek istediğinizden Emin  misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (dgYabanciDiller.CurrentRow.Cells["dilid"].Value.ToString() != "0")
                        {
                            veri.cmd("Update tblPersonelDilleri set silindimi = '1' where dilid = " + dgYabanciDiller.CurrentRow.Cells["dilid"].Value + " ");
                        }
                        dgYabanciDiller.Rows.Remove(dgYabanciDiller.CurrentRow);
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Silme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
                }
            }
        }

        private void dgPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seciliPersonelid = Convert.ToInt64(dgPersonel.CurrentRow.Cells["personelid"].Value);
                seciliPersonelAdi = dgPersonel.CurrentRow.Cells["adi"].Value.ToString() + " " + dgPersonel.CurrentRow.Cells["soyadi"].Value.ToString();
                SqlDataReader dr = veri.getDatareader("SELECT [ozelKod],[tcKimlikNo],[personelKartNo],[adi],[soyadi],[bolgeid],[bolgeAdi],[adres],[egitimBilgileri],[egitimDurumu],[hizmeticiEgitimler],[sertifikalar],[kanGrubu],[tel],[tel2],[gsm],[email],[webSitesi],[odemeGunu],[vergiNo],[sigortaNo],[sicilNo],[ehliyet],[calistigiSube],[calistigiSubeAdi],[iliskiliKullanici],[kAdi],[resim],[departmanid],[departmanAdi],[personelGrupid],[grupAdi],[ayrinti],[unvan],[uzmanlikAlanlari],[cinsiyet],[medeniDurumu],[anaAdi],[babaAdi],[kardesBilgileri],[giysiBedeni],[ayakkabiNo],[aylikUcret],[durumu],[eklenmeTarihi] FROM [ElmarTicariPlus].[dbo].[sorPersonelBilgileri] where [personelid] = " + seciliPersonelid + " and firmaid = " + firma.firmaid + "");
                while (dr.Read())
                {
                    txtOzelKod.Text = dr["ozelKod"].ToString();
                    txtTcKimlikNo.Text = dr["tcKimlikNo"].ToString();
                    txtPersonelKartNo.Text = dr["personelKartNo"].ToString();
                    txtAdi.Text = dr["adi"].ToString();
                    txtSoyadi.Text = dr["soyadi"].ToString();
                    txtBolge.Tag = dr["bolgeid"].ToString();
                    txtBolge.Text = dr["bolgeAdi"].ToString();
                    txtAdres.Text = dr["adres"].ToString();
                    txtEgitimBilgileri.Text = dr["egitimBilgileri"].ToString();
                    cmbEgitimDurumu.Text = dr["egitimDurumu"].ToString();
                    txtHizmeticiEgitimler.Text = dr["hizmeticiEgitimler"].ToString();
                    txtSertifikalar.Text = dr["sertifikalar"].ToString();
                    cmbKanGrubu.Text = dr["kanGrubu"].ToString();
                    txtTel.Text = dr["tel"].ToString();
                    txtTel2.Text = dr["tel2"].ToString();
                    txtGsm.Text = dr["gsm"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    txtWebSitesi.Text = dr["webSitesi"].ToString();
                    try { txtOdemeGunu.Value = Convert.ToInt32(dr["odemeGunu"]); }
                    catch { }
                    txtVergiNo.Text = dr["vergiNo"].ToString();
                    txtSigortaNo.Text = dr["sigortaNo"].ToString();
                    txtSicilNo.Text = dr["sicilNo"].ToString();
                    txtEhliyet.Text = dr["ehliyet"].ToString();
                    cmbPersonelinCalistigiSube.Text = dr["calistigiSubeAdi"].ToString();
                    cmbProgramKullanicisi.Text = dr["kAdi"].ToString();
                    p1.Tag = dr["resim"].ToString();
                    //txtOzelKod.Text = dr["departmanid"].ToString();
                    cmbDepartman.Text = dr["departmanAdi"].ToString();
                    //txtOzelKod.Text = dr["personelGrupid"].ToString();
                    cmbGrup.Text = dr["grupAdi"].ToString();
                    txtAyrinti.Text = dr["ayrinti"].ToString();
                    txtUnvan.Text = dr["unvan"].ToString();
                    txtUzmanlikAlanlari.Text = dr["uzmanlikAlanlari"].ToString();
                    cmbCinsiyet.Text = dr["cinsiyet"].ToString();
                    txtAnaAdi.Text = dr["anaAdi"].ToString();
                    txtBabaAdi.Text = dr["babaAdi"].ToString();
                    cmbMedeniDurum.Text = dr["medeniDurumu"].ToString();
                    txtKardesBilgileri.Text = dr["kardesBilgileri"].ToString();
                    txtGiysiBedeni.Text = dr["giysiBedeni"].ToString();
                    txtAyakkabiNo.Text = dr["ayakkabiNo"].ToString();
                    txtAylikUcret.Text = dr["aylikUcret"].ToString();
                    txtDurum.Text = dr["durumu"].ToString();
                    txtEklenmeTarihi.Text = dr["eklenmeTarihi"].ToString();
                }
                dilListele();
                try
                {
                    DataRow rw = veri.getdatarow("Select kayitTarihi, kayitSaati from tblPersonelGirisCikis where (select top 1 girisCikisid from tblPersonelGirisCikis where firmaid = " + firma.firmaid + " and personelid = " + seciliPersonelid + " and silindimi = '0' and kayitTuru = 'İşe Başladı' order by eklenmeTarihi desc)  =  girisCikisid");
                    dtiseGirisTarihi.Value = Convert.ToDateTime(rw["kayitTarihi"]);
                    txtiseGirisSaati.Text = rw["kayitSaati"].ToString();
                }catch{
                    dtiseGirisTarihi.Value = DateTime.Today;
                    txtiseGirisSaati.Clear();
                }
                try
                {
                    picPersonelResmi.Image = null;
                    Stream s = File.Open(Application.StartupPath + "\\KullanıcıResimleri\\personel\\personel" + seciliPersonelid.ToString() + ".png", FileMode.Open);
                    Image temp = Image.FromStream(s);
                    s.Close();
                    picPersonelResmi.Image = temp;

                }
                catch
                {
                    try { picPersonelResmi.Image = elmarDosyaislemleri.resimindir("personel/personel" + seciliPersonelid.ToString() + ".png"); }
                    catch { }
                }
                try
                {
                    string yol = Application.StartupPath + "\\KullanıcıResimleri\\personel\\personel" + seciliPersonelid.ToString() + ".png";
                    if (!File.Exists(yol)) picPersonelResmi.Image.Save(yol);
                }
                catch { }

            }
            catch (Exception hata)
            {

            }

        }

        private void btnileri1_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex += 1;
        }

        private void btnGeri2_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex -= 1;
        }

        private void txtAdi_KeyDown(object sender, KeyEventArgs e)
        {
            Control sndr = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(sndr, true, true, true, true);
            }
        }

        private void txtPersonelKartNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl3.SelectedIndex = 0;
                cmbDepartman.Select();
            }
        }

        private void dgYabanciDiller_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void txtAylikUcret_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGunlukUcret.Text = (Convert.ToDouble(txtAylikUcret.Text) / 30).ToString();
            }
            catch { }
        }

        private void txtGunlukUcret_TextChanged(object sender, EventArgs e)
        {
            txtSaatlikUcret.Text = (Convert.ToDouble(txtGunlukUcret.Text) / Convert.ToInt32(txtGunlukCalismaSaati.Value)).ToString();
        }
        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            dosyaSec.Title = "Resim Seçimi";
            dosyaSec.Filter = "Resim Dosyaları|*.png;*.bmp;*.gif;*.jpg";
            dosyaSec.ShowDialog();
            if (dosyaSec.SafeFileName == "")
            {
            }
            else
            {
                picPersonelResmi.Image = Image.FromFile(dosyaSec.FileName);
            }
        }

        private void btnResimBuyult_Click(object sender, EventArgs e)
        {
            if (picPersonelResmi.Image == null)
            {
                MessageBox.Show("Gösterilecek Resim Yok", firma.programAdi);
                return;
            }
            frmPersonelResimBuyult frm = new frmPersonelResimBuyult(picPersonelResmi.Image, seciliPersonelAdi);
            frm.Show();
        }

        private void chkiseBaslat_Click(object sender, EventArgs e)
        {
            if (chkiseBaslat.Checked) pnliseGiris.Visible = true;
            else pnliseGiris.Visible = false;
        }
        int personelinCalistigiSubeid=0;
        private void cmbPersonelinCalistigiSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbProgramKullanicisi, ComboboxItem.getSelectedValue(cmbPersonelinCalistigiSube));
            if (cmbPersonelinCalistigiSube.SelectedIndex == -1) personelinCalistigiSubeid = 0;
            else personelinCalistigiSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbPersonelinCalistigiSube));
        }
        int plesiyerid=0;
        private void cmbProgramKullanicisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgramKullanicisi.SelectedIndex == -1) plesiyerid = 0;
            else plesiyerid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbProgramKullanicisi));
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSubeler.Text == "") seciliSubeid = 0;
            else seciliSubeid = Convert.ToInt32(ComboboxItem.getSelectedValue(cmbSubeler));
            personelListele();
        }
    }
}