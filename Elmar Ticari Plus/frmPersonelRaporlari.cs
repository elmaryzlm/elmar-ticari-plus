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
    public partial class frmPersonelRaporlari : Form
    {
        public frmPersonelRaporlari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.kontrolEkle(this);
        }
        void listeleriDoldur()
        {
            cmbPersonelAdlari.Items.Clear();
            try { cmbPersonelAdlari.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
        }
        private long seciliPersonelid = 0;

        private void cmbPersonelAdlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciliPersonelid = listeler.getPersonelid()[cmbPersonelAdlari.SelectedIndex];
        }

        private void frmPersonelRaporlari_Load(object sender, EventArgs e)
        {
            listeleriDoldur();
        }
        rapor rpr;
        //void raporisle()
        //{
        //    rpr = new rapor();
        //    int y = 5;
        //    rpr.yaziYazdirmaSiniri = 190;
        //    rpr.excelButonuGosterilsinmi = true;
        //    rpr.sayfayiYatayYap();
        //    rpr.ekleDikgortgen(new rapor.dikdortgen(20, 24, 160, 20));
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("Satış Ayrıntı Raporu", new Font("Arial", 14, FontStyle.Underline), new Point(80, y))); y += 8;
        //    rpr.ekleExcelHucresi("Satış Ayrıntı Raporu", "C1", true, true, 20);

        //    //başlıklar yazdırılıyor
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Adı", new Font("Arial", 9, FontStyle.Underline), new Rectangle(5, y, 74, 5), false));
        //    rpr.ekleExcelHucresi("Cari Adı", "A2", true, false, 11);
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("ARATOP", new Font("Arial", 9, FontStyle.Underline), new Rectangle(80, y, 19, 5), StringFormatFlags.DirectionRightToLeft, false));
        //    rpr.ekleExcelHucresi("ARATOP", "B2", true, false, 11);
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("KDVTOP", new Font("Arial", 9, FontStyle.Underline), new Rectangle(100, y, 19, 5), StringFormatFlags.DirectionRightToLeft, false));
        //    rpr.ekleExcelHucresi("KDVTOP", "C2", true, false, 11);
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("İSK", new Font("Arial", 9, FontStyle.Underline), new Rectangle(120, y, 19, 5), StringFormatFlags.DirectionRightToLeft, false));
        //    rpr.ekleExcelHucresi("İSK", "D2", true, false, 11);
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("TOPLAM", new Font("Arial", 9, FontStyle.Underline), new Rectangle(140, y, 19, 5), StringFormatFlags.DirectionRightToLeft, false));
        //    rpr.ekleExcelHucresi("TOPLAM", "E2", true, false, 11);
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih", new Font("Arial", 9, FontStyle.Underline), new Rectangle(160, y, 19, 3), false));
        //    rpr.ekleExcelHucresi("Tarih", "F2", true, false, 11);
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("Ödeme Türü", new Font("Arial", 9, FontStyle.Underline), new Rectangle(180, y, 29, 5), false));
        //    rpr.ekleExcelHucresi("Ödeme Türü", "G2", true, false, 11);
        //    rpr.ekleSabitYazi(new rapor.sabitYazi("Açıklama", new Font("Arial", 9, FontStyle.Underline), new Rectangle(210, y, 80, 5), false));
        //    rpr.ekleExcelHucresi("Açıklama", "H2", true, false, 11);
        //    y += 5;
        //    int son_i = 0;
        //    //datagrid  verileri yazdırılıyor
        //    for (int i = 0; i < dgSatis.Rows.Count; i++)
        //    {
        //        rpr.ekleYazi(new rapor.yazi(dgSatis.Rows[i].Cells["cariAdi"].Value.ToString(), new Rectangle(5, y, 73, 3), false));
        //        rpr.ekleExcelHucresi(dgSatis.Rows[i].Cells["cariAdi"].Value.ToString(), "A" + (i + 3));
        //        rpr.ekleYazi(new rapor.yazi(dgSatis.Rows[i].Cells["toplam"].Value.ToString(), new Rectangle(80, y, 18, 3), StringFormatFlags.DirectionRightToLeft, true));
        //        rpr.ekleExcelHucresi(dgSatis.Rows[i].Cells["toplam"].Value.ToString(), "B" + (i + 3));
        //        rpr.ekleYazi(new rapor.yazi(dgSatis.Rows[i].Cells["kdvToplam"].Value.ToString(), new Rectangle(100, y, 18, 3), StringFormatFlags.DirectionRightToLeft, true));
        //        rpr.ekleExcelHucresi(dgSatis.Rows[i].Cells["kdvToplam"].Value.ToString(), "C" + (i + 3));
        //        rpr.ekleYazi(new rapor.yazi(dgSatis.Rows[i].Cells["iskonto"].Value.ToString(), new Rectangle(120, y, 18, 3), StringFormatFlags.DirectionRightToLeft, true));
        //        rpr.ekleExcelHucresi(dgSatis.Rows[i].Cells["iskonto"].Value.ToString(), "D" + (i + 3));
        //        rpr.ekleYazi(new rapor.yazi(dgSatis.Rows[i].Cells["tutar"].Value.ToString(), new Rectangle(140, y, 18, 3), StringFormatFlags.DirectionRightToLeft, true));
        //        rpr.ekleExcelHucresi(dgSatis.Rows[i].Cells["tutar"].Value.ToString(), "E" + (i + 3));
        //        rpr.ekleYazi(new rapor.yazi(dgSatis.Rows[i].Cells["satisTarihi"].Value.ToString(), new Rectangle(160, y, 16, 3), false));
        //        rpr.ekleExcelHucresi(dgSatis.Rows[i].Cells["satisTarihi"].Value.ToString(), "F" + (i + 3));
        //        rpr.ekleYazi(new rapor.yazi(dgSatis.Rows[i].Cells["ayrinti"].Value.ToString(), new Rectangle(180, y, 30, 3), false));
        //        rpr.ekleExcelHucresi(dgSatis.Rows[i].Cells["ayrinti"].Value.ToString(), "G" + (i + 3));
        //        rpr.ekleYazi(new rapor.yazi(dgSatis.Rows[i].Cells["faturaAciklamasi"].Value.ToString(), new Rectangle(210, y, 80, 3), false));
        //        rpr.ekleExcelHucresi(dgSatis.Rows[i].Cells["faturaAciklamasi"].Value.ToString(), "H" + (i + 3));
        //        y += 4;
        //        son_i = i + 4;
        //    }
        //    //Toplamlar Yazdırılıyor
        //    rpr.ekleCizgi(new rapor.cizgi(0, rpr._kagitGenisligi, y, y));
        //    //rpr.ekleDikgortgen(new rapor.dikdortgen(125, y, 70, 16));
        //    rpr.ekleYazi(new rapor.yazi("TOPLAM: ", new Font("Arial", 9, FontStyle.Bold), new Rectangle(130, y, 30, 5), false));
        //    rpr.ekleYazi(new rapor.yazi(txtToplam.Text, new Rectangle(165, y, 30, 5), StringFormatFlags.DirectionRightToLeft, true));
        //    rpr.ekleExcelHucresi("TOPLAM", "G" + son_i, true, false, 12);
        //    rpr.ekleExcelHucresi(txtToplam.Text, "H" + son_i++, true, false, 12);
        //    y += 4;

        //    rpr.ekleYazi(new rapor.yazi("KDVTOP: ", new Font("Arial", 9, FontStyle.Bold), new Rectangle(130, y, 30, 5), false));

        //    rpr.ekleYazi(new rapor.yazi(txtKdv.Text, new Rectangle(165, y, 30, 5), StringFormatFlags.DirectionRightToLeft, true));
        //    rpr.ekleExcelHucresi("KDVTOP", "G" + son_i, true, false, 12);
        //    rpr.ekleExcelHucresi(txtKdv.Text, "H" + son_i++, true, false, 12);
        //    y += 4;

        //    rpr.ekleYazi(new rapor.yazi("İSK: ", new Font("Arial", 9, FontStyle.Bold), new Rectangle(130, y, 30, 5), false));
        //    rpr.ekleYazi(new rapor.yazi(txtiskonto.Text, new Rectangle(165, y, 30, 5), StringFormatFlags.DirectionRightToLeft, true));
        //    rpr.ekleExcelHucresi("İSK", "G" + son_i, true, false, 12);
        //    rpr.ekleExcelHucresi(txtiskonto.Text, "H" + son_i++, true, false, 12);
        //    y += 4;

        //    rpr.ekleYazi(new rapor.yazi("Genel Top: ", new Font("Arial", 9, FontStyle.Bold), new Rectangle(130, y, 30, 5), false));
        //    rpr.ekleYazi(new rapor.yazi(txtToplamtutar.Text, new Rectangle(165, y, 30, 5), StringFormatFlags.DirectionRightToLeft, true));
        //    rpr.ekleExcelHucresi("Genel Top", "G" + son_i, true, false, 12);
        //    rpr.ekleExcelHucresi(txtToplamtutar.Text, "H" + son_i++, true, false, 12);
        //    //Alt Bilgi Notu yazdırılıyor
        //    y += 4;
        //    rpr.ekleCizgi(new rapor.cizgi(0, rpr._kagitGenisligi, y, y));
        //    y += 2;
        //    son_i++;
        //    rpr.ekleYazi(new rapor.yazi("Yazdırılma Tarihi: " + DateTime.Now.ToString(), new Rectangle(5, y, 60, 5), false));
        //    rpr.ekleYazi(new rapor.yazi(" Elmar Yazılım Program ve Web Hizmetleri | www.elmaryazilim.com", new Rectangle(90, y, 120, 5), false));
        //    rpr.ekleExcelHucresi("Rapor Tarihi: " + DateTime.Now.ToString(), "A" + son_i, false, false, 10);
        //    rpr.ekleExcelHucresi("Elmar Yazılım Program ve Web Hizmetleri | www.elmaryazilim.com", "C" + son_i, false, false, 10);
        //}
        private void btnRaporuGoruntule_Click(object sender, EventArgs e)
        {
            if (seciliPersonelid == 0)
            {
                MessageBox.Show("Lütfen Listeden bir personel seçin",firma.programAdi);
                cmbPersonelAdlari.Select();
                return;
            }
            rpr = new rapor();
            int y = 5;
            rpr.yaziYazdirmaSiniri = 280;
            rpr.ekleDikgortgen(new rapor.dikdortgen(5, 5, 40, 40));
            
            rpr.ekleSabitYazi(new rapor.sabitYazi("Personel Kişi Bilgileri Raporu", new Font("Arial", 14, FontStyle.Underline), new Point(75, y))); y += 8;
            SqlDataReader dr = veri.getDatareader("SELECT [ozelKod],[tcKimlikNo],[personelKartNo],[adi],[soyadi],[bolgeid],[bolgeAdi],[adres],[egitimBilgileri],[egitimDurumu],[hizmeticiEgitimler],[sertifikalar],[kanGrubu],[tel],[tel2],[gsm],[email],[webSitesi],[odemeGunu],[vergiNo],[sigortaNo],[sicilNo],[ehliyet],[calistigiSube],[calistigiSubeAdi],[iliskiliKullanici],[resim],[departmanid],[departmanAdi],[personelGrupid],[grupAdi],[ayrinti],[unvan],[uzmanlikAlanlari],[cinsiyet],[medeniDurumu],[anaAdi],[babaAdi],[kardesBilgileri],[giysiBedeni],[ayakkabiNo],[aylikUcret],[durumu],[eklenmeTarihi] FROM [ElmarTicariPlus].[dbo].[sorPersonelBilgileri] where [personelid] = " + seciliPersonelid + " and firmaid = " + firma.firmaid + "");
            while (dr.Read())
            {
                Image pic = null;
                try
                {
                    System.IO.Stream s = System.IO.File.Open(Application.StartupPath + "\\KullanıcıResimleri\\personel\\personel" + seciliPersonelid.ToString() + ".png", System.IO.FileMode.Open);
                    Image temp = Image.FromStream(s);
                    s.Close();
                    pic = temp;

                }
                catch
                {
                    try { pic = elmarDosyaislemleri.resimindir("personel/personel" + seciliPersonelid.ToString() + ".png"); }
                    catch { }
                }
                finally
                {
                    if(pic!=null)rpr.ekleSabitResim(new rapor.sabitResim(pic, new Rectangle(6, 6, 38, 38)));
                }


                rpr.ekleSabitYazi(new rapor.sabitYazi("TC Kimlik: "+dr["tcKimlikNo"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(50, y))); y += 4;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Personel Adı: " + dr["adi"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(50, y))); y += 4;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Personel Soyadı: " + dr["soyadi"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(50, y))); y += 4;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Özel Kod: " + dr["ozelKod"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(50, y))); y += 4;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Personel Kart No: " + dr["personelKartNo"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(50, y))); y += 4;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Durumu: " + dr["durumu"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(50, y))); y += 4;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Kayıt Tarihi: " + dr["eklenmeTarihi"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(50, y))); y += 4;
                rpr.ekleSabitCizgi(new rapor.sabitCizgi(5,rpr._kagitGenisligi-5,45,45));y=50;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Adres-İletişim Bilgileri",new Font("Arial", 12,FontStyle.Underline),new Point(10,y)));y+=6;
                rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(5, y, rpr._kagitGenisligi - 10, 30));
                rpr.ekleSabitYazi(new rapor.sabitYazi("Adres ve Bölge: " + dr["adres"].ToString() + "\n" + dr["bolgeAdi"].ToString(), new Rectangle(6, y + 2, rpr._kagitGenisligi - 15, 20), false)); y += 20;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Tel: " + dr["tel"].ToString() + "      Tel2: " + dr["tel2"].ToString() + "      GSM: " + dr["gsm"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Email: " + dr["email"].ToString() + "       Web Sitesi: " + dr["webSitesi"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 8;

                rpr.ekleSabitYazi(new rapor.sabitYazi("Eğitim Bilgileri", new Font("Arial", 12, FontStyle.Underline), new Point(10, y))); y += 6;
                rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(5, y, rpr._kagitGenisligi - 10, 30));
                rpr.ekleSabitYazi(new rapor.sabitYazi("Eğitim Durumu: " + dr["egitimDurumu"].ToString(), new Rectangle(6, y+2, rpr._kagitGenisligi - 15, 4), false)); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Eğitim Bilgileri: " + dr["egitimBilgileri"].ToString(), new Rectangle(6, y+2, rpr._kagitGenisligi - 15, 4), false)); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Hizmet İçi Eğitimler: " + dr["hizmeticiEgitimler"].ToString(), new Rectangle(6, y+2, rpr._kagitGenisligi - 15, 8), false)); y += 9;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Sertifikalar: " + dr["sertifikalar"].ToString(), new Rectangle(6, y+2, rpr._kagitGenisligi - 15, 8), false)); y += 10;

                rpr.ekleSabitCizgi(new rapor.sabitCizgi(5, rpr._kagitGenisligi - 5, y, y)); y += 3;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Personelin Diğer Bilgileri", new Font("Arial", 12, FontStyle.Underline), new Point(10, y))); y += 6;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Vergi No: " + dr["vergiNo"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Sigorta No: " + dr["sigortaNo"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Sicil No: " + dr["sicilNo"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Ehliyet: " + dr["ehliyet"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Departman: " + dr["departmanAdi"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Personel Grubu: " + dr["grupAdi"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Ünvan: " + dr["unvan"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Cinsiyet: " + dr["cinsiyet"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Ana Adı: " + dr["anaAdi"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Baba Adı: " + dr["babaAdi"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Kardeş Bilgileri: " + dr["kardesBilgileri"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;

                rpr.ekleSabitYazi(new rapor.sabitYazi("Kan Grubu: " + dr["kanGrubu"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Medeni Durumu: " + dr["medeniDurumu"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Giysi Bedeni: " + dr["giysiBedeni"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Uzmanlık Alanları: " + dr["uzmanlikAlanlari"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Aylık Ücret: " + dr["aylikUcret"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Ödeme Günü: " + dr["odemeGunu"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
                rpr.ekleSabitYazi(new rapor.sabitYazi("Ayrıntı: " + dr["ayrinti"].ToString(), new Font("Arial", 10, FontStyle.Regular), new Point(6, y))); y += 5;
            }
            rpr.onizleme();
        }
    }
}