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
    public partial class frmPersonelListele : Form
    {
        public frmPersonelListele()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.dataGridView(dgFiltre);
            NesneGorselleri.dataGridView(dgPersonelBilgileri);
            filtreDoldur();
        }

        private void frmPersonelListele_Load(object sender, EventArgs e)
        {
            personelListele(" and silindimi = '0'");
        }

        void filtreDoldur()
        {
            dgFiltre.Rows.Add("ozelKod","Özel Kod",null, "" ,"metin");
            dgFiltre.Rows.Add("tcKimlikNo", "TC Kimlik No", null, "", "metin");
            dgFiltre.Rows.Add("personelKartNo", "Personel Kart No", null, "", "metin");
            dgFiltre.Rows.Add("adi", "Adı", null, "", "metin");
            dgFiltre.Rows.Add("soyadi", "Soyadı", null, "", "metin");
            dgFiltre.Rows.Add("bolgeAdi", "Bölge Adı", null, "", "metin");
            dgFiltre.Rows.Add("adres", "Adres", null, "", "metin");
            dgFiltre.Rows.Add("egitimBilgileri", "Eğitim Bilgileri", null, "", "metin");
            dgFiltre.Rows.Add("egitimDurumu", "Eğitim Durumu", null, "", "metin");
            dgFiltre.Rows.Add("kanGrubu", "Kan Grubu", null, "", "metin");
            dgFiltre.Rows.Add("tel", "Tel", null, "", "metin");
            dgFiltre.Rows.Add("tel2", "Tel2", null, "", "metin");
            dgFiltre.Rows.Add("gsm", "Gsm", null, "", "metin");
            dgFiltre.Rows.Add("eMail", "E-Mail", null, "", "metin");
            dgFiltre.Rows.Add("webSitesi", "Web Sitesi", null, "", "metin");
            dgFiltre.Rows.Add("odemeGunu", "Ödeme Günü", null, "", "sayı");
            dgFiltre.Rows.Add("vergiNo", "Vergi No", null, "", "metin");
            dgFiltre.Rows.Add("sigortaNo", "Sigorta No", null, "", "metin");
            dgFiltre.Rows.Add("sicilNo", "Sicil No", null, "", "metin");
            dgFiltre.Rows.Add("ehliyet", "Ehliyet", null, "", "metin");
            dgFiltre.Rows.Add("calistigiSubeAdi", "Calıştığı Şube", null, "", "metin");
            dgFiltre.Rows.Add("resim", "Resim", null, "", "resim");
            dgFiltre.Rows.Add("departmanAdi", "Departman", null, "", "metin");
            dgFiltre.Rows.Add("grupAdi", "Personel Grubu", null, "", "metin");
            dgFiltre.Rows.Add("unvan", "Ünvan", null, "", "metin");
            dgFiltre.Rows.Add("uzmanlikAlanlari", "Uzmanlık Alanları", null, "", "metin");
            dgFiltre.Rows.Add("hizmeticiEgitimler", "Hizmet İçi Eğitimler", null, "", "metin");
            dgFiltre.Rows.Add("sertifikalar", "Sertifikalar", null, "", "metin");
            dgFiltre.Rows.Add("cinsiyet", "Cinsiyet", null, "", "metin");
            dgFiltre.Rows.Add("merdeniDurumu", "Medeni Durumu", null, "", "metin");
            dgFiltre.Rows.Add("anaAdi", "Ana Adı", null, "", "metin");
            dgFiltre.Rows.Add("babaAdi", "Baba Adı", null, "", "metin");
            dgFiltre.Rows.Add("kardesBilgileri", "Kardeş Bilgileri", null, "", "metin");
            dgFiltre.Rows.Add("giysiBedeni", "Giysi Bedeni", null, "", "metin");
            dgFiltre.Rows.Add("ayakkabiNo", "Ayakkabı No", null, "", "metin");
            dgFiltre.Rows.Add("aylikÜcret", "Aylık Ücret", null, "","sayı");
            dgFiltre.Rows.Add("durumu", "Durumu", null, "", "metin");
            dgFiltre.Rows.Add("eklenmeTarihi", "Eklenme Tarihi", null, "","tarih");
            dgFiltre.Rows.Add("silindimi", "Silindimi", null, "0", "bool");
            dgFiltre.Rows.Add("ayrinti", "Ayrıntı", null, "", "metin");
            
            DataGridViewComboBoxCell c;
            for (int i = 0; i < 40; i++)
            {
                c = (DataGridViewComboBoxCell)dgFiltre.Rows[i].Cells["turu"];
                c.Items.Clear();
                c.Items.Add("");
                c.Items.Add("=");
                if (dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "sayı" || dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "tarih") c.Items.Add(">");
                if (dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "sayı" || dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "tarih") c.Items.Add(">=");
                if (dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "sayı" || dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "tarih") c.Items.Add("<");
                if (dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "sayı" || dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "tarih") c.Items.Add("<=");
                c.Items.Add("Eşit Değilse");
                if (dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "metin") c.Items.Add("İle Başlayanlar");
                if (dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "metin") c.Items.Add("İle Bitenler");
                if (dgFiltre.Rows[i].Cells["veritipi"].Value.ToString() == "metin") c.Items.Add("Metnin içinde varsa");
                if (dgFiltre.Rows[i].Cells["filtreDegiskenAdi"].Value.ToString() == "silindimi") c.Value = "=";
                else c.Value = "";
            }
        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            if (btnFiltre.Text == "<")
            {
                dgFiltre.Visible = false;
                btnFiltre.Text = ">";
            }
            else
            {
                dgFiltre.Visible = true;
                btnFiltre.Text = "<";
            }
        }

        private void dgFiltre_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                try
                {
                    if (dgFiltre.CurrentRow.Cells["turu"].Value.ToString() == "")
                    {
                        MessageBox.Show("Lütfen Filtre Türünü seçin.", firma.programAdi);
                        return;
                    }
                    string sorgu = "  ";
                    for (int i = 0; i < 40; i++)
                    {
                        try
                        {
                            if (dgFiltre.Rows[i].Cells["filtre"].Value.ToString() != "")
                            {
                                if (dgFiltre.Rows[i].Cells["turu"].Value.ToString() == "Eşit Değilse")
                                {
                                    sorgu = sorgu + " and " + dgFiltre.Rows[i].Cells["filtreDegiskenAdi"].Value.ToString() + " != '" + dgFiltre.Rows[i].Cells["filtre"].Value.ToString() + "'";
                                }
                                else if (dgFiltre.Rows[i].Cells["turu"].Value.ToString() == "İle Başlayanlar")
                                {
                                    sorgu = sorgu + " and " + dgFiltre.Rows[i].Cells["filtreDegiskenAdi"].Value.ToString() + " like '" + dgFiltre.Rows[i].Cells["filtre"].Value.ToString() + "%'";
                                }
                                else if (dgFiltre.Rows[i].Cells["turu"].Value.ToString() == "İle Bitenler")
                                {
                                    sorgu = sorgu + " and " + dgFiltre.Rows[i].Cells["filtreDegiskenAdi"].Value.ToString() + " like '%" + dgFiltre.Rows[i].Cells["filtre"].Value.ToString() + "'";
                                }
                                else if (dgFiltre.Rows[i].Cells["turu"].Value.ToString() == "Metnin içinde varsa")
                                {
                                    sorgu = sorgu + " and " + dgFiltre.Rows[i].Cells["filtreDegiskenAdi"].Value.ToString() + " like '%" + dgFiltre.Rows[i].Cells["filtre"].Value.ToString() + "%'";
                                }
                                else
                                {
                                    sorgu = sorgu + " and " + dgFiltre.Rows[i].Cells["filtreDegiskenAdi"].Value.ToString() + " " + dgFiltre.Rows[i].Cells["turu"].Value.ToString() + " '" + dgFiltre.Rows[i].Cells["filtre"].Value.ToString() + "'";
                                }
                            }
                        }
                        catch
                        {
                        }

                    }
                    personelListele(sorgu);
                }
                catch (Exception)
                {
                    personelListele("");
                }            
        }

        void personelListele(string sorgu)
        {
            dgPersonelBilgileri.DataSource = veri.getdatatable("SELECT [personelid], [ozelKod] as 'Özel Kod', [tcKimlikNo] as 'TC No', [personelKartNo] as 'P.Kart No', [rfidKartNo], [adi] as 'Adı' ,[soyadi] as 'Soyadı', [bolgeid], [bolgeAdi] as 'Bölge', [adres] as 'Adres', [egitimBilgileri] as 'Eğitim Bilgileri', [egitimDurumu] as 'Eğitim Durumu', [kanGrubu] as 'Kan Gurubu', [tel] as 'Tel', [tel2] as 'Tel2', [gsm] as 'GSM', [email] as 'Email', [webSitesi] as 'Web Sitesi', [odemeGunu] as 'Ödeme Günü', [vergiNo] as 'Vergi No', [sigortaNo] as 'Sigorta No', [sicilNo] as 'Sicil No', [ehliyet] as 'Ehliyet', [calistigiSube], [calistigiSubeAdi] AS 'Şubesi', [iliskiliKullanici], [resim], [departmanid], [departmanAdi] as 'Departman', [personelGrupid], [grupAdi] as 'Personel Grubu', [unvan] as 'Ünvan', [uzmanlikAlanlari] as 'Uzmanlık Alanları', [hizmeticiEgitimler] as 'Hizmet İçi Eğitimler', [sertifikalar] as Sertifikalar,  [cinsiyet] as 'Cinsiyet', [medeniDurumu] as 'Medeni Durumu', [anaAdi] as 'Ana Adı', [babaAdi] as 'Baba Adı', [kardesBilgileri] as 'Kardeş Bilgileri', [giysiBedeni] as 'Giysi B.', [ayakkabiNo] as 'Ayk.No', [aylikUcret] as 'Ücret', [durumu] as 'Durumu', [eklenmeTarihi] as 'Eklenme T.', [silindimi] as 'Silindimi', [ayrinti] as 'Ayrıntı' FROM [ElmarTicariPlus].[dbo].[sorPersonelBilgileri] where firmaid = " + firma.firmaid + " " + sorgu + "");
            dgPersonelBilgileri.Columns["personelid"].Visible = false;
            dgPersonelBilgileri.Columns["rfidKartNo"].Visible = false;
            dgPersonelBilgileri.Columns["bolgeid"].Visible = false;
            dgPersonelBilgileri.Columns["calistigiSube"].Visible = false;
            dgPersonelBilgileri.Columns["iliskiliKullanici"].Visible = false;
            dgPersonelBilgileri.Columns["resim"].Visible = false;
            dgPersonelBilgileri.Columns["departmanid"].Visible = false;
            dgPersonelBilgileri.Columns["personelGrupid"].Visible = false;

            lblKayitSayisi.Text = "Kayıt Sayısı: " + dgPersonelBilgileri.Rows.Count.ToString();
        }
    }
}
