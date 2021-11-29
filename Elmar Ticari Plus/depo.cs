using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using elmarLibrary;
using System.Data;
using System.Media;
using System.Web.UI.WebControls;
using CurrentEDMConnectorClientLibrary;
using CurrentEDMConnectorClientLibrary.Entities;
using Elmar_Ticari_Plus.EDMService;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Elmar_Ticari_Plus
{
    //verileri güncelleme classları
    public class guncelle
    {
        public static void kullaniciVerileriniGuncelle()
        {
            //Kullanici tablosu getiriliyor.
            SqlDataReader dr = veri.getDatareader("select * from sorFirmaKullanicilari where kullaniciid = " + firma.kullaniciid + " and subeid = " + firma.subeid + " and firmaid = " + firma.firmaid + "");
            while (dr.Read())
            {
                firmaKullanicilari.kullaniciid = Convert.ToInt32(dr["kullaniciid"]);
                firmaKullanicilari.kAdi = dr["kAdi"].ToString();
                firmaKullanicilari.sifre = dr["sifre"].ToString();
                firmaKullanicilari.adiSoyadi = dr["adiSoyadi"].ToString();
                firmaKullanicilari.gorevi = dr["gorevi"].ToString();
                firmaKullanicilari.onlinemi = dr["onlinemi"].ToString();
                firmaKullanicilari.girisizni = dr["girisizni"].ToString();
                firmaKullanicilari.eklenmeTarihi = Convert.ToDateTime(dr["eklenmeTarihi"]);
                //firmaKullanicilari.silindimi = dr["silindimi"].ToString();
                firmaKullanicilari.subeid = Convert.ToInt32(dr["subeid"]);
            }
        }
        public static void subeVerileriniGuncelle()
        {
            //Şube tablosu getiriliyor.
            SqlDataReader dr = veri.getDatareader("select * from sorFirmaSubeleri where subeid = " + firma.subeid + " and firmaid = " + firma.firmaid + "");
            while (dr.Read())
            {
                subeBilgileri.subeid = Convert.ToInt32(dr["subeid"]);
                subeBilgileri.subeAdi = dr["subeAdi"].ToString();
                subeBilgileri.bolgeid = dr["bolgeid"].ToString();
                subeBilgileri.bolgeAdi = dr["bolgeAdi"].ToString();
                subeBilgileri.adres = dr["adres"].ToString();
                subeBilgileri.tel = dr["tel"].ToString();
                subeBilgileri.gsm = dr["gsm"].ToString();
                subeBilgileri.fax = dr["fax"].ToString();
                subeBilgileri.email = dr["email"].ToString();
                subeBilgileri.vergiDaire = dr["vergiDaire"].ToString();
                subeBilgileri.vergiNo = dr["vergiNo"].ToString();
                subeBilgileri.altBilgiNotu = dr["altBilgiNotu"].ToString();
                subeBilgileri.eklenmeTarihi = Convert.ToDateTime(dr["eklenmeTarihi"]);
            }
        }
        public static void firmaVerileriniGuncelle()
        {
            //firma tablosu getiriliyor.
            SqlDataReader dr = veri.getDatareader("select * from sorFirmaBilgileri where firmaid = " + firma.firmaid + "");
            while (dr.Read())
            {

                firmaBilgileri.firmaid = dr["aciklama"].ToString();
                firmaBilgileri.adi = dr["adi"].ToString();
                firmaBilgileri.soyadi = dr["soyadi"].ToString();
                firmaBilgileri.aciklama = dr["aciklama"].ToString();
                firmaBilgileri.demoKalanGun = dr["kalanGun"].ToString();
                firmaBilgileri.demomu = dr["demomu"].ToString();
                firmaBilgileri.engellimi = dr["engellimi"].ToString();
                firmaBilgileri.maxKullaniciSayisi = dr["maxKullaniciSayisi"].ToString();
                firmaBilgileri.maxSubeSayisi = dr["maxSubeSayisi"].ToString();
                firmaBilgileri.webSitesi = dr["webSitesi"].ToString();
                firmaBilgileri.eklenmeTarihi = Convert.ToDateTime(dr["eklenmeTarihi"]);
                firmaBilgileri.adisyon = Convert.ToByte(dr["adisyon"]);
                firmaBilgileri.banka = Convert.ToByte(dr["banka"]);
                firmaBilgileri.cari = Convert.ToByte(dr["cari"]);
                firmaBilgileri.cekSenet = Convert.ToByte(dr["cekSenet"]);
                firmaBilgileri.hastane = Convert.ToByte(dr["hastane"]);
                firmaBilgileri.kasa = Convert.ToByte(dr["kasa"]);
                firmaBilgileri.mesajlar = Convert.ToByte(dr["mesajlar"]);
                firmaBilgileri.mobil = Convert.ToByte(dr["mobil"]);
                firmaBilgileri.mobil2 = Convert.ToByte(dr["mobil2"]);
                firmaBilgileri.otel = Convert.ToByte(dr["otel"]);
                firmaBilgileri.personel = Convert.ToByte(dr["personel"]);
                firmaBilgileri.satis = Convert.ToByte(dr["satis"]);
                firmaBilgileri.stok = Convert.ToByte(dr["stok"]);
                firmaBilgileri.uretim = Convert.ToByte(dr["uretim"]);
                firmaBilgileri.yurt = Convert.ToByte(dr["yurt"]);
            }
        }
        public static void stokkartVerileriniGuncelle()
        {
            //Stokkartları getiriliyor.
            stokkart.listStokkart.Clear();
            SqlDataReader dr = veri.getDatareader("select * from sorStokkart where firmaid = " + firma.firmaid + "");
            while (dr.Read())
            {
                stokkart.ekle(Convert.ToInt64(dr["stokid"]), dr["stokkodu"].ToString(), dr["rfidEtiketi"].ToString(), dr["urunAdi"].ToString(), Convert.ToDouble(dr["alisFiyat"]), Convert.ToInt16(dr["kdv"]), dr["kdvTipi"].ToString(), dr["katNo"].ToString(), dr["kategoriAdi"].ToString(), dr["urunKodu"].ToString(), dr["garantiSuresi"].ToString(), Convert.ToInt32(dr["markaid"]), dr["markaAdi"].ToString(), dr["rafAdi"].ToString(), dr["ayrinti"].ToString(), dr["aktifmi"].ToString(), dr["resim"].ToString(), dr["webdeGosterilsinmi"].ToString(), Convert.ToBoolean(dr["mobil"]), Convert.ToBoolean(dr["vitrin"]), Convert.ToDateTime(dr["eklenmeTarihi"]), dr["silindimi"].ToString(), Convert.ToInt32(dr["subeid"]), Convert.ToInt32(dr["kullaniciid"]));
            }
            //birimler getiriliyor.
            stokkart.birimler.listBirimler.Clear();
            SqlDataReader dr2 = veri.getDatareader("select * from sorStokkartBirimleri where firmaid = " + firma.firmaid + "");
            while (dr2.Read())
            {
                try
                {
                    stokkart.birimler.ekle(Convert.ToInt64(dr2["stokkartBirimid"]), Convert.ToInt64(dr2["stokid"]), Convert.ToInt32(dr2["birimid"]), dr2["birimAdi"].ToString(), Convert.ToDouble(dr2["katsayi"]), dr2["barkod"].ToString(), Convert.ToDateTime(dr2["eklenmeTarihi"]), Convert.ToInt32(dr2["subeid"]), Convert.ToInt32(dr2["kullaniciid"]));
                }
                catch (Exception hata)
                {
                    MessageBox.Show(dr2["stokkartBirimid"].ToString());
                }
            }
            //Fiyatlar getiriliyor.
            stokkart.fiyatlar.listFiyatlar.Clear();
            SqlDataReader dr4 = veri.getDatareader("select * from sorStokkartFiyatlari where firmaid = " + firma.firmaid + " order by fiyatAdi");
            while (dr4.Read())
            {
                stokkart.fiyatlar.ekle(Convert.ToInt64(dr4["stokFiyatid"]), Convert.ToInt64(dr4["stokid"]), Convert.ToInt32(dr4["fiyatid"]), dr4["fiyatAdi"].ToString(), Convert.ToDouble(dr4["fiyatTutari"]), Convert.ToDouble(dr4["indirim"]), dr4["indirimTipi"].ToString(), Convert.ToDouble(dr4["indirimliFiyat"]), dr4["dovizi"].ToString(), Convert.ToDateTime(dr4["eklenmeTarihi"]), Convert.ToInt32(dr4["subeid"]), Convert.ToInt32(dr4["kullaniciid"]));
            }
        }
        public static void cariBilgileriVerileriniGuncelle()
        {
            try
            {
                //CariBilgileri tablosu getiriliyor.
                cariBilgileri.listCariBilgileri.Clear();
                SqlDataReader dr = veri.getDatareader("select *, (Select isnull(SUM(bakiye),0) from sorCariBakiye where cariid = sorCariBilgileri.cariid) as bakiye from sorCariBilgileri where firmaid = " + firma.firmaid + "");
                while (dr.Read())
                {
                    int fiyatid = -1;
                    string fiyat = dr["Fiyatid"].ToString();
                    if (fiyat != "" && fiyat != "-1") fiyatid = Convert.ToInt32(dr["Fiyatid"].ToString());
                    cariBilgileri.ekle(Convert.ToInt64(dr["cariid"]), Convert.ToInt32(dr["kimlikid"]), dr["cariKodu"].ToString(), dr["adi"].ToString(), dr["soyadi"].ToString(), dr["adiSoyadi"].ToString(), dr["kullaniciAdi"].ToString(), dr["sifre"].ToString(), dr["vergiDaire"].ToString(), dr["vergiNo"].ToString(), dr["tcNo"].ToString(), Convert.ToInt32(dr["grupid"]), Convert.ToInt32(dr["guzergahid"]), dr["rfidkartNo"].ToString(), dr["paraBirimi"].ToString(), Convert.ToDouble(dr["limit"]), Convert.ToInt16(dr["hatirlatmaGunu"]), dr["cariAciklamasi"].ToString(), dr["webSitesi"].ToString(), dr["cinsiyet"].ToString(), dr["plaka"].ToString(), dr["resim"].ToString(), dr["onay"].ToString(), dr["engellimi"].ToString(), dr["hesabaislensinmi"].ToString(), dr["webdeGosterilsinmi"].ToString(), fiyatid, Convert.ToDateTime(dr["eklenmeTarihi"]), dr["silindimi"].ToString(), Convert.ToInt32(dr["subeid"]), Convert.ToInt32(dr["kullaniciid"]), Convert.ToDouble(dr["bakiye"]), "-");
                }
                //Adres tablosu getiriliyor.
                cariBilgileri.adresBilgileri.listAdresBilgileri.Clear();
                SqlDataReader dr1 = veri.getDatareader("select * from sorAdresBilgileri where firmaid = " + firma.firmaid + "");
                while (dr1.Read())
                {
                    cariBilgileri.adresBilgileri.ekle(Convert.ToInt64(dr1["adresid"]), Convert.ToInt64(dr1["cariid"]), dr1["adiSoyadi"].ToString(), dr1["adresAdi"].ToString(), dr1["adi"].ToString(), dr1["soyadi"].ToString(), dr1["email"].ToString(), dr1["tel"].ToString(), dr1["gsm"].ToString(), dr1["fax"].ToString(), dr1["bolgeid"].ToString(), dr1["boldeAdi"].ToString(), dr1["adres"].ToString(), dr1["postaKodu"].ToString(), dr1["sirketUnvan"].ToString(), dr1["vergiDaire"].ToString(), dr1["vergiNo"].ToString(), dr1["tcNo"].ToString(), dr1["varsayilanmi"].ToString(), Convert.ToDateTime(dr1["eklenmeTarihi"]), Convert.ToInt32(dr1["subeid"].ToString()), Convert.ToInt32(dr1["kullaniciid"]));
                }
                //cariGrupları tablosu getiriliyor
                cariBilgileri.cariGruplari.listCariGruplari.Clear();
                SqlDataReader dr2 = veri.getDatareader("select * from sorCariGruplari where firmaid = '" + firma.firmaid + "'");
                while (dr2.Read())
                {
                    cariBilgileri.cariGruplari.listCariGruplari.Add(new cariBilgileri.cariGruplari.cariGruplariAyrinti(Convert.ToInt32(dr2["cariGrupid"]), dr2["grupAdi"].ToString(), Convert.ToDateTime(dr2["eklenmeTarihi"]), Convert.ToInt32(dr2["subeid"]), Convert.ToInt32(dr2["kullaniciid"])));
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Cari Aktarımında bir hata oluştu. Hata Metni: " + hata.Message);
            }
        }
        public static void bilgileriGuncelle()
        {
            listeler.yukleCariadi();
            listeler.yukleKategori();
            listeler.yukleMarka();
            listeler.yukleSube();
            listeler.yukleKullanici();
            listeler.yukleUrunadi();
            listeler.yukleCariGruplari();
            listeler.yukleAdresler();
            listeler.yukleBirim();
            listeler.yukleFiyat();
            listeler.yuklePersonelAdi();
            bilgiler.dovizVerileri.dovizVerileriniguncelle();
        }
    }
    //firma
    public class firmaBilgileri
    {
        public static string firmaid;
        public static string adi;
        public static string soyadi;
        public static string webSitesi;
        public static string aciklama;
        public static string engellimi;
        public static string maxSubeSayisi;
        public static string maxKullaniciSayisi;
        public static DateTime eklenmeTarihi;
        public static string demomu;
        public static string demoKalanGun;
        public static byte uretim = 0;
        public static byte stok = 0;
        public static byte satis = 0;
        public static byte kasa = 0;
        public static byte cari = 0;
        public static byte cekSenet = 0;
        public static byte personel = 0;
        public static byte banka = 0;
        public static byte adisyon = 0;
        public static byte mesajlar = 0;
        public static byte hastane = 0;
        public static byte otel = 0;
        public static byte yurt = 0;
        public static byte mobil = 0;
        public static byte mobil2 = 0;
    }
    //şube
    public class subeBilgileri
    {
        public static Int32 subeid;
        public static string subeAdi;
        public static string bolgeid;
        public static string bolgeAdi;
        public static string adres;
        public static string tel;
        public static string gsm;
        public static string fax;
        public static string email;
        public static string vergiDaire;
        public static string vergiNo;
        public static string altBilgiNotu;
        public static DateTime eklenmeTarihi;
    }
    //kullanici
    public static class firmaKullanicilari
    {
        public static Int32 kullaniciid;
        public static string kAdi;
        public static string sifre;
        public static string adiSoyadi;
        public static string gorevi;
        public static string onlinemi;
        public static string girisizni;
        public static DateTime eklenmeTarihi;
        public static string silindimi;
        public static Int32 subeid;
    }
    // stokkart
    public class stokkart
    {
        public static List<stokkart.stokkartAyrinti> listStokkart = new List<stokkart.stokkartAyrinti>();

        public static stokkart.stokkartAyrinti bul_stokid(Int64 stokid)
        {
            return listStokkart.Where(u => u.stokid == stokid).OrderBy(u => u.silindimi).First();
        }
        public static stokkart.stokkartAyrinti bul_stokkodu(string stokkodu)
        {
            try
            {
                return listStokkart.Where(u => u.stokkodu == stokkodu).OrderBy(u => u.silindimi).First();
            }
            catch (Exception)
            {
                return null;
            }

        }
        public static stokkart.stokkartAyrinti bul_urunAdi(string urunAdi)
        {
            try
            {
                return listStokkart.Where(u => u.urunAdi == urunAdi).OrderBy(u => u.silindimi).First();
            }
            catch
            {
                return null;
            }
        }
        public static stokkart.stokkartAyrinti bul_urunKodu(string urunKodu)
        {
            return listStokkart.Where(u => u.urunKodu == urunKodu).OrderBy(u => u.silindimi).First();
        }
        public static stokkart.stokkartAyrinti bul_barkod(string barkod)
        {
            try
            {
                birimler.birimlerAyrinti sonuc = birimler.bul_barkod(barkod).First();
                if (sonuc == null) return null;
                return bul_stokid(sonuc.stokid);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static stokkart.stokkartAyrinti bul_seriNo(string seriNumarasi)
        {
            seriNumaralari.seriNumaralariAyrinti sonuc = seriNumaralari.bul(seriNumarasi);
            if (sonuc == null) return null;
            return bul_stokid(sonuc.stokid);
        }
        public static void sil(Int64 stokid)
        {
            listStokkart.Remove(bul_stokid(stokid));
        }
        public static void setSilindimi(Int64 stokid, string degeri)
        {
            bul_stokid(stokid).silindimi = degeri;
        }
        public static void setAktifmi(Int64 stokid, string degeri)
        {
            bul_stokid(stokid).aktifmi = degeri;
        }
        public static void setWebdeGosterilsinmi(Int64 stokid, string degeri)
        {
            bul_stokid(stokid).webdeGosterilsinmi = degeri;
        }
        public static void setMobilGosterilsinmi(Int64 stokid, bool degeri)
        {
            bul_stokid(stokid).mobil = degeri;
        }
        public static void setVitrinGosterilsinmi(Int64 stokid, bool degeri)
        {
            bul_stokid(stokid).vitrin = degeri;
        }

        public static void ekle
        (
            Int64 stokid,
            string stokkodu,
            string rfidEtiketi,
            string urunAdi,
            double alisFiyat,
            Int16 kdv,
            string kdvTipi,
            string katNo,
            string kategoriAdi,
            string urunKodu,
            string garantiSuresi,
            int markaid,
            string markaAdi,
            string rafAdi,
            string ayrinti,
            string aktifmi,
            string resim,
            string webdeGosterilsinmi,
            bool mobil,
            bool vitrin,
            DateTime eklenmeTarihi,
            string silindimi,
            int subeid,
            int kullaniciid
        )
        {
            listStokkart.Add(new stokkart.stokkartAyrinti(
            stokid,
            stokkodu,
            rfidEtiketi,
            urunAdi,
            alisFiyat,
            kdv,
            kdvTipi,
            katNo,
            kategoriAdi,
            urunKodu,
            garantiSuresi,
            markaid,
            markaAdi,
            rafAdi,
            ayrinti,
            aktifmi,
            resim,
            webdeGosterilsinmi,
            mobil,
            vitrin,
            eklenmeTarihi,
            silindimi,
            subeid,
            kullaniciid));
        }
        public class stokkartAyrinti
        {
            public Int64 stokid;
            public string stokkodu;
            public string rfidEtiketi;
            public string urunAdi;
            public double alisFiyat = 0;
            public Int16 kdv;
            public string kdvTipi;
            public string katNo;
            public string kategoriAdi;
            public string urunKodu;
            public string garantiSuresi;
            public int markaid;
            public string markaAdi;
            public string rafAdi;
            public string ayrinti;
            public string aktifmi;
            public string resim;
            public string webdeGosterilsinmi;
            public bool mobil;
            public bool vitrin;
            public DateTime eklenmeTarihi;
            public string silindimi;
            public int subeid;
            public int kullaniciid;
            public stokkartAyrinti
            (
                Int64 stokid,
                string stokkodu,
                string rfidEtiketi,
                string urunAdi,
                double alisFiyat,
                Int16 kdv,
                string kdvTipi,
                string katNo,
                string kategoriAdi,
                string urunKodu,
                string garantiSuresi,
                int markaid,
                string markaAdi,
                string rafAdi,
                string ayrinti,
                string aktifmi,
                string resim,
                string webdeGosterilsinmi,
                bool mobil,
                bool vitrin,
                DateTime eklenmeTarihi,
                string silindimi,
                int subeid,
                int kullaniciid
            )
            {
                this.stokid = stokid;
                this.stokkodu = stokkodu;
                this.rfidEtiketi = rfidEtiketi;
                this.urunAdi = urunAdi;
                this.alisFiyat = alisFiyat;
                this.kdv = kdv;
                this.kdvTipi = kdvTipi;
                this.katNo = katNo;
                this.kategoriAdi = kategoriAdi;
                this.urunKodu = urunKodu;
                this.garantiSuresi = garantiSuresi;
                this.markaid = markaid;
                this.markaAdi = markaAdi;
                this.rafAdi = rafAdi;
                this.ayrinti = ayrinti;
                this.aktifmi = aktifmi;
                this.resim = resim;
                this.webdeGosterilsinmi = webdeGosterilsinmi;
                this.mobil = mobil;
                this.vitrin = vitrin;
                this.eklenmeTarihi = eklenmeTarihi;
                this.silindimi = silindimi;
                this.subeid = subeid;
                this.kullaniciid = kullaniciid;
            }
        }

        public class birimler
        {
            public static List<birimler.birimlerAyrinti> listBirimler = new List<birimler.birimlerAyrinti>();

            public static void sil(Int64 stokkartBirimid)
            {
                try
                {
                    listBirimler.Remove(listBirimler.Where(u => u.stokkartBirimid == stokkartBirimid).First());
                }
                catch (Exception)
                {

                }

                //for (int i = 0; i < listBirimler.Count; i++)
                //{
                //    if (listBirimler[i].stokkartBirimid == stokkartBirimid)
                //    {
                //        listBirimler.RemoveAt(i);
                //    }
                //}
            }

            public static List<birimler.birimlerAyrinti> bul_stokid(Int64 stokid)
            {
                return listBirimler.Where(u => u.stokid == stokid).OrderBy(u => u.birimAdi).ToList();
            }
            public static List<birimler.birimlerAyrinti> bul_barkod(string barkod)
            {
                return listBirimler.Where(u => u.barkod == barkod).OrderBy(u => u.birimAdi).ToList();
            }

            public static void ekle
            (
                Int64 stokkartBirimid,
                Int64 stokid,
                Int32 birimid,
                string birimAdi,
                double katsayi,
                string barkod,
                DateTime eklenmeTarihi,
                int subeid,
                int kullaniciid
            )
            {
                listBirimler.Add(new birimler.birimlerAyrinti(stokkartBirimid, stokid, birimid, birimAdi, katsayi, barkod, eklenmeTarihi, subeid, kullaniciid));
            }
            public class birimlerAyrinti
            {
                public birimlerAyrinti
                (
                    Int64 stokkartBirimid,
                    Int64 stokid,
                    Int32 birimid,
                    string birimAdi,
                    double katsayi,
                    string barkod,
                    DateTime eklenmeTarihi,
                    Int32 subeid,
                    Int32 kullaniciid
                )
                {
                    this.stokkartBirimid = stokkartBirimid;
                    this.stokid = stokid;
                    this.birimid = birimid;
                    this.birimAdi = birimAdi;
                    this.katsayi = katsayi;
                    this.barkod = barkod;
                    this.eklenmeTarihi = eklenmeTarihi;
                    this.subeid = subeid;
                    this.kullaniciid = kullaniciid;
                }

                public Int64 stokkartBirimid;
                public Int64 stokid;
                public Int32 birimid;
                public string birimAdi;
                public double katsayi = 1;
                public string barkod;
                public DateTime eklenmeTarihi;
                public Int32 subeid;
                public Int32 kullaniciid;
            }
        }
        //public class barkodlar
        //{
        //    public static List<barkodlar.barkodlarAyrinti> listBarkodlar = new List<barkodlar.barkodlarAyrinti>();
        //    public static bool sil(Int64 stokid)
        //    {
        //        bool deger = false;
        //        for (int i = 0; i < listBarkodlar.Count; i++)
        //        {
        //            if (listBarkodlar[i].stokid == stokid)
        //            {
        //                listBarkodlar.RemoveAt(i);
        //                deger = true;
        //            }
        //        }
        //        return deger;
        //    }
        //    public static void sil(string barkod)
        //    {
        //        try
        //        {
        //            listBarkodlar.Remove(listBarkodlar.Where(u => u.barkod == barkod).First());
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        //for (int i = 0; i < listBarkodlar.Count; i++)
        //        //{
        //        //    if (listBarkodlar[i].barkod == barkod)
        //        //    {
        //        //        listBarkodlar.RemoveAt(i);
        //        //        return true;
        //        //    }
        //        //}
        //        //return false;
        //    }
        //    public static barkodlar.barkodlarAyrinti bul(string barkod)
        //    {
        //        for (int i = 0; i < listBarkodlar.Count; i++)
        //        {
        //            if (listBarkodlar[i].barkod == barkod)
        //            {
        //                return listBarkodlar[i];
        //            }
        //        }
        //        return null;
        //    }

        //    public static void ekle
        //    (
        //        Int64 stokid,
        //        Int32 birimid,
        //        string birimAdi,
        //        string barkod
        //    )
        //    {
        //        listBarkodlar.Add(new barkodlar.barkodlarAyrinti(stokid, birimid, birimAdi, barkod));
        //    }
        //    public class barkodlarAyrinti
        //    {
        //        public barkodlarAyrinti
        //        (
        //            Int64 stokid,
        //            Int32 birimid,
        //            string birimAdi,
        //            string barkod
        //        )
        //        {
        //            this.stokid = stokid;
        //            this.birimid = birimid;
        //            this.birimAdi = birimAdi;
        //            this.barkod = barkod;
        //        }
        //        public Int64 stokid;
        //        public Int32 birimid;
        //        public string birimAdi;
        //        public string barkod;
        //    }
        //}
        public class fiyatlar
        {
            public static List<fiyatlar.fiyatlarAyrinti> listFiyatlar = new List<fiyatlar.fiyatlarAyrinti>();
            public static double getFiyatTutari(Int32 fiyatid, Int64 stokid)
            {
                try
                {
                    fiyatlarAyrinti fa = listFiyatlar.Where(u => u.fiyatid == fiyatid && u.stokid == stokid).First();
                    double dovizTutari = 1;
                    //if (fa.dovizi == "USD") dovizTutari = bilgiler.dovizVerileri.dDolarsatis;
                    //else if (fa.dovizi == "EURO") dovizTutari = bilgiler.dovizVerileri.dEurosatis;
                    return fa.indirimliFiyat * dovizTutari;
                }
                catch
                {
                    return 0;
                }
            }

            public static fiyatlarAyrinti getFiyat(Int32 fiyatid, Int64 stokid)
            {
                try
                {
                    fiyatlarAyrinti fa = listFiyatlar.Where(u => u.fiyatid == fiyatid && u.stokid == stokid).First();
                    return fa;
                }
                catch
                {
                    return null;
                }
            }


            public static void sil(Int64 stokFiyatid)
            {
                listFiyatlar.Remove(listFiyatlar.Where(u => u.stokFiyatid == stokFiyatid).First());
                //for (int i = 0; i < listFiyatlar.Count; i++)
                //{
                //    if (listFiyatlar[i].stokFiyatid == stokFiyatid)
                //    {
                //        listFiyatlar.RemoveAt(i);
                //    }
                //}
            }
            public static void ekle
            (
                Int64 stokFiyatid,
                Int64 stokid,
                int fiyatid,
                string fiyatAdi,
                double fiyatTutari,
                double indirim,
                string indirimTipi,
                double indirimliFiyat,
                string dovizi,
                DateTime eklenmeTarihi,
                Int32 subeid,
                Int32 kullaniciid
            )
            {
                listFiyatlar.Add(new fiyatlar.fiyatlarAyrinti(stokFiyatid, stokid, fiyatid, fiyatAdi, fiyatTutari, indirim, indirimTipi, indirimliFiyat, dovizi, eklenmeTarihi, subeid, kullaniciid));
            }
            public class fiyatlarAyrinti
            {
                public fiyatlarAyrinti
                (
                    Int64 stokFiyatid,
                    Int64 stokid,
                    int fiyatid,
                    string fiyatAdi,
                    double fiyatTutari,
                    double indirim,
                    string indirimTipi,
                    double indirimliFiyat,
                    string dovizi,
                    DateTime eklenmeTarihi,
                    Int32 subeid,
                    Int32 kullaniciid
                )
                {
                    this.stokFiyatid = stokFiyatid;
                    this.stokid = stokid;
                    this.fiyatid = fiyatid;
                    this.fiyatAdi = fiyatAdi;
                    this.fiyatTutari = fiyatTutari;
                    this.indirim = indirim;
                    this.indirimTipi = indirimTipi;
                    this.indirimliFiyat = indirimliFiyat;
                    this.dovizi = dovizi;
                    this.eklenmeTarihi = eklenmeTarihi;
                    this.subeid = subeid;
                    this.kullaniciid = kullaniciid;
                }

                public Int64 stokFiyatid;
                public Int64 stokid;
                public int fiyatid;
                public string fiyatAdi;
                public double fiyatTutari;
                public double indirim;
                public string indirimTipi;
                public double indirimliFiyat;
                public string dovizi;
                public DateTime eklenmeTarihi;
                public Int32 subeid;
                public Int32 kullaniciid;
            }
        }
        public class seriNumaralari
        {
            private static List<seriNumaralari.seriNumaralariAyrinti> listSeriNumaralari = new List<seriNumaralari.seriNumaralariAyrinti>();

            public static void sil(Int64 seriNoid)
            {
                listSeriNumaralari.Remove(listSeriNumaralari.Where(u => u.seriNoid == seriNoid).First());
                //for (int i = 0; i < listSeriNumaralari.Count; i++)
                //{
                //    if (listSeriNumaralari[i].seriNoid == seriNoid)
                //    {
                //        listSeriNumaralari.RemoveAt(i);
                //    }
                //}
            }
            public static seriNumaralari.seriNumaralariAyrinti bul(string seriNumarasi)
            {
                for (int i = 0; i < listSeriNumaralari.Count; i++)
                {
                    if (listSeriNumaralari[i].seriNumarasi == seriNumarasi)
                    {
                        return listSeriNumaralari[i];
                    }
                }
                return null;
            }
            public static void ekle
            (
                Int64 seriNoid,
                Int64 stokid,
                string seriNumarasi,
                DateTime kullanilmaTarihi,
                Int64 ticaretid,
                DateTime eklenmeTarihi,
                Int32 subeid,
                Int32 kullaniciid
            )
            {
                listSeriNumaralari.Add(new seriNumaralari.seriNumaralariAyrinti(seriNoid, stokid, seriNumarasi, kullanilmaTarihi, ticaretid, eklenmeTarihi, subeid, kullaniciid));
            }
            public class seriNumaralariAyrinti
            {
                public seriNumaralariAyrinti
                (
                    Int64 seriNoid,
                    Int64 stokid,
                    string seriNumarasi,
                    DateTime kullanilmaTarihi,
                    Int64 ticaretid,
                    DateTime eklenmeTarihi,
                    Int32 subeid,
                    Int32 kullaniciid
                )
                {
                    this.seriNoid = seriNoid;
                    this.stokid = stokid;
                    this.seriNumarasi = seriNumarasi;
                    this.kullanilmaTarihi = kullanilmaTarihi;
                    this.ticaretid = ticaretid;
                    this.eklenmeTarihi = eklenmeTarihi;
                    this.subeid = subeid;
                    this.kullaniciid = kullaniciid;
                }

                public Int64 seriNoid;
                public Int64 stokid;
                public string seriNumarasi;
                public DateTime kullanilmaTarihi;
                public Int64 ticaretid;
                public DateTime eklenmeTarihi;
                public Int32 subeid;
                public Int32 kullaniciid;
            }
        }
    }
    //Cari Bilgileri
    public static class cariBilgileri
    {
        public static void bakiyeGuncelle(long pCariid, double borc, double alacak, double duzenlemeBakiyesi)
        {
            double net = borc - alacak - duzenlemeBakiyesi;
            for (int i = 0; i < listCariBilgileri.Count; i++)
            {
                if (listCariBilgileri[i].cariid == pCariid)
                {
                    listCariBilgileri[i].bakiye = listCariBilgileri[i].bakiye + net;
                    if (listCariBilgileri[i].bakiye < 0) listCariBilgileri[i].bakiyeDurumu = "Borçlu";
                    else if (listCariBilgileri[i].bakiye > 0) listCariBilgileri[i].bakiyeDurumu = "Alacaklı";
                    else listCariBilgileri[i].bakiyeDurumu = "";
                }
            }
        }
        public static List<cariBilgileri.cariBilgileriAyrinti> listCariBilgileri = new List<cariBilgileri.cariBilgileriAyrinti>();
        public static cariBilgileri.cariBilgileriAyrinti bul_cariid(Int64 cariid)
        {
            for (int i = 0; i < listCariBilgileri.Count; i++)
            {
                if (listCariBilgileri[i].cariid == cariid)
                {
                    return listCariBilgileri[i];
                }
            }
            return null;
        }

        public static cariBilgileri.cariBilgileriAyrinti bul_RIFDNo(string str)
        {
            for (int i = 0; i < listCariBilgileri.Count; i++)
            {
                if (listCariBilgileri[i].rfidkartNo == str)
                {
                    return listCariBilgileri[i];
                }
            }
            return null;
        }
        public static void setSilindimi(Int64 cariid, string degeri)
        {
            bul_cariid(cariid).silindimi = degeri;
        }
        public static void ekle
        (
            Int64 cariid,
            Int32 kimlikid,
            string cariKodu,
            string adi,
            string soyadi,
            string adiSoyadi,
            string kullaniciAdi,
            string sifre,
            string vergiDaire,
            string vergiNo,
            string tcNo,
            Int32 grupid,
            Int32 guzergahid,
            string rfidkartNo,
            string paraBirimi,
            double limit,
            Int16 hatirlatmaGunu,
            string cariAciklamasi,
            string webSitesi,
            string cinsiyet,
            string plaka,
            string resim,
            string onay,
            string engellimi,
            string hesabaislensinmi,
            string webdeGosterilsinmi,
            int fiyatid,
            DateTime eklenmeTarihi,
            string silindimi,
            int subeid,
            int kullaniciid,
            double bakiye,
            string bakiyeDurumu
        )
        {
            listCariBilgileri.Add(new cariBilgileriAyrinti(cariid, kimlikid, cariKodu, adi, soyadi, adiSoyadi, kullaniciAdi, sifre, vergiDaire, vergiNo, tcNo, grupid, guzergahid, rfidkartNo, paraBirimi, limit, hatirlatmaGunu, cariAciklamasi, webSitesi, cinsiyet, plaka, resim, onay, engellimi, hesabaislensinmi, webdeGosterilsinmi, fiyatid, eklenmeTarihi, silindimi, subeid, kullaniciid, bakiye, bakiyeDurumu));
        }
        public class cariBilgileriAyrinti
        {
            public Int64 cariid;
            public Int32 kimlikid;
            public string cariKodu;
            public string adi;
            public string soyadi;
            public string adiSoyadi;
            public string kullaniciAdi;
            public string sifre;
            public string vergiDaire;
            public string vergiNo;
            public string tcNo;
            public Int32 grupid;
            public Int32 guzergahid;
            public string rfidkartNo;
            public string paraBirimi;
            public double limit;
            public Int16 hatirlatmaGunu;
            public string cariAciklamasi;
            public string webSitesi;
            public string cinsiyet;
            public string plaka;
            public string resim;
            public string onay;
            public string engellimi;
            public string hesabaislensinmi;
            public string webdeGosterilsinmi;
            public int fiyatid;
            public DateTime eklenmeTarihi;
            public string silindimi;
            public int subeid;
            public int kullaniciid;
            public double bakiye;
            public string bakiyeDurumu;
            public cariBilgileriAyrinti
            (
                  Int64 cariid,
                  Int32 kimlikid,
                  string cariKodu,
                  string adi,
                  string soyadi,
                  string adiSoyadi,
                  string kullaniciAdi,
                  string sifre,
                  string vergiDaire,
                  string vergiNo,
                  string tcNo,
                  Int32 grupid,
                  Int32 guzergahid,
                  string rfidkartNo,
                  string paraBirimi,
                  double limit,
                  Int16 hatirlatmaGunu,
                  string cariAciklamasi,
                  string webSitesi,
                  string cinsiyet,
                  string plaka,
                  string resim,
                  string onay,
                  string engellimi,
                  string hesabaislensinmi,
                  string webdeGosterilsinmi,
                  int fiyatid,
                  DateTime eklenmeTarihi,
                  string silindimi,
                  int subeid,
                  int kullaniciid,
                  double bakiye,
                  string bakiyeDurumu
            )
            {
                this.cariid = cariid;
                this.kimlikid = kimlikid;
                this.cariKodu = cariKodu;
                this.adi = adi;
                this.soyadi = soyadi;
                this.adiSoyadi = adiSoyadi;
                this.kullaniciAdi = kullaniciAdi;
                this.sifre = sifre;
                this.vergiDaire = vergiDaire;
                this.vergiNo = vergiNo;
                this.tcNo = tcNo;
                this.grupid = grupid;
                this.guzergahid = guzergahid;
                this.rfidkartNo = rfidkartNo;
                this.paraBirimi = paraBirimi;
                this.limit = limit;
                this.hatirlatmaGunu = hatirlatmaGunu;
                this.cariAciklamasi = cariAciklamasi;
                this.webSitesi = webSitesi;
                this.cinsiyet = cinsiyet;
                this.plaka = plaka;
                this.resim = resim;
                this.onay = onay;
                this.engellimi = engellimi;
                this.hesabaislensinmi = hesabaislensinmi;
                this.webdeGosterilsinmi = webdeGosterilsinmi;
                this.fiyatid = fiyatid;
                this.eklenmeTarihi = eklenmeTarihi;
                this.silindimi = silindimi;
                this.subeid = subeid;
                this.kullaniciid = kullaniciid;
                this.bakiye = bakiye;
                if (bakiye < 0) this.bakiyeDurumu = "Borçlu";
                else if (bakiye > 0) this.bakiyeDurumu = "Alacaklı";
                else this.bakiyeDurumu = "";
            }

        }
        public class adresBilgileri
        {
            public static List<adresBilgileri.adresBilgileriAyrinti> listAdresBilgileri = new List<adresBilgileriAyrinti>();
            public static void ekle
            (
                Int64 adresid,
                Int64 cariid,
                string adiSoyadi,
                string adresAdi,
                string adi,
                string soyadi,
                string email,
                string tel,
                string gsm,
                string fax,
                string bolgeid,
                string boldeAdi,
                string adres,
                string postaKodu,
                string sirketUnvan,
                string vergiDaire,
                string vergiNo,
                string tcNo,
                string varsayilanmi,
                DateTime eklenmeTarihi,
                int subeid,
                int kullaniciid
            )
            {
                listAdresBilgileri.Add(new adresBilgileri.adresBilgileriAyrinti(adresid, cariid, adiSoyadi, adresAdi, adi, soyadi, email, tel, gsm, fax, bolgeid, boldeAdi, adres, postaKodu, sirketUnvan, vergiDaire, vergiNo, tcNo, varsayilanmi, eklenmeTarihi, subeid, kullaniciid));
            }
            public class adresBilgileriAyrinti
            {
                public Int64 adresid;
                public Int64 cariid;
                public string adiSoyadi;
                public string adresAdi;
                public string adi;
                public string soyadi;
                public string email;
                public string tel;
                public string gsm;
                public string fax;
                public string bolgeid;
                public string boldeAdi;
                public string adres;
                public string postaKodu;
                public string sirketUnvan;
                public string vergiDaire;
                public string vergiNo;
                public string tcNo;
                public string varsayilanmi;
                public DateTime eklenmeTarihi;
                public int subeid;
                public int kullaniciid;
                public adresBilgileriAyrinti
                (
                  Int64 adresid,
                  Int64 cariid,
                  string adiSoyadi,
                  string adresAdi,
                  string adi,
                  string soyadi,
                  string email,
                  string tel,
                  string gsm,
                  string fax,
                  string bolgeid,
                  string boldeAdi,
                  string adres,
                  string postaKodu,
                  string sirketUnvan,
                  string vergiDaire,
                  string vergiNo,
                  string tcNo,
                  string varsayilanmi,
                  DateTime eklenmeTarihi,
                  int subeid,
                  int kullaniciid
                )
                {
                    this.adresid = adresid;
                    this.cariid = cariid;
                    this.adiSoyadi = adiSoyadi;
                    this.adresAdi = adresAdi;
                    this.adi = adi;
                    this.soyadi = soyadi;
                    this.email = email;
                    this.tel = tel;
                    this.gsm = gsm;
                    this.fax = fax;
                    this.bolgeid = bolgeid;
                    this.boldeAdi = boldeAdi;
                    this.adres = adres;
                    this.postaKodu = postaKodu;
                    this.sirketUnvan = sirketUnvan;
                    this.vergiDaire = vergiDaire;
                    this.vergiNo = vergiNo;
                    this.tcNo = tcNo;
                    this.varsayilanmi = varsayilanmi;
                    this.eklenmeTarihi = eklenmeTarihi;
                    this.subeid = subeid;
                    this.kullaniciid = kullaniciid;
                }
            }

        }
        public class cariGruplari
        {
            public static List<cariGruplari.cariGruplariAyrinti> listCariGruplari = new List<cariGruplariAyrinti>();
            public static void ekle
            (
                int cariGrupid,
                string grupAdi,
                DateTime eklenmeTarihi,
                int subeid,
                int kullaniciid
            )
            {
                listCariGruplari.Add(new cariGruplariAyrinti(cariGrupid, grupAdi, eklenmeTarihi, subeid, kullaniciid));
            }
            public class cariGruplariAyrinti
            {
                public int cariGrupid;
                public string grupAdi;
                public DateTime eklenmeTarihi;
                public int subeid;
                public int kullaniciid;
                public cariGruplariAyrinti
                (
                    int cariGrupid,
                    string grupAdi,
                    DateTime eklenmeTarihi,
                    int subeid,
                    int kullaniciid
                )
                {
                    this.cariGrupid = cariGrupid;
                    this.grupAdi = grupAdi;
                    this.eklenmeTarihi = eklenmeTarihi;
                    this.subeid = subeid;
                    this.kullaniciid = kullaniciid;
                }
            }
        }
    }
    //Ticaret Ayrıntı Tablosu Bilgileri
    public class ticaretAyrinti2
    {
        public static List<ticaretAyrintiAyrinti> listTicaretAyrinti = new List<ticaretAyrintiAyrinti>();
        public static ticaretAyrinti2.ticaretAyrintiAyrinti bul_ticaretAyrintiid(long ticaretAyrintiid)
        {
            return listTicaretAyrinti.Where(u => u.ticaretAyrintiid == ticaretAyrintiid).First();
        }
        public static void sil(long ticaretAyrintiid)
        {
            ticaret.sil_ticaretAyrintiid(ticaretAyrintiid);
            listTicaretAyrinti.Remove(bul_ticaretAyrintiid(ticaretAyrintiid));
        }
        public static int getMaxGrupid()
        {
            try
            {
                return listTicaretAyrinti.Max(u => u.grupid);
            }
            catch
            {
                return 0;
            }

        }
        public static void ekle
        (
            long ticaretAyrintiid,
            long cariid,
            string odemeTuru,
            DateTime islemTarihi,
            string islemSaati,
            DateTime fiiliSevkTarihi,
            string islemTuru,
            string faturaNo,
            string belgeNo,
            string irsaliyeNo,
            string vergiDaire,
            string vergiNo,
            string adres,
            string faturaAciklamasi,
            string islemAciklamasi,
            double iskonto,
            double nakliyat,
            double iscilik,
            string hesabaislendimi,
            string onay,
            DateTime eklenmeTarihi,
            string silindimi,
            int subeid,
            int kullaniciid,
            bool islemTamamlandimi,
            bool servereYuklendimi,
            int grupid
        )
        {
            listTicaretAyrinti.Add(new ticaretAyrintiAyrinti(ticaretAyrintiid, cariid, odemeTuru, islemTarihi, islemSaati, fiiliSevkTarihi, islemTuru, faturaNo, belgeNo, irsaliyeNo, vergiDaire, vergiNo, adres, faturaAciklamasi, islemAciklamasi, iskonto, nakliyat, iscilik, hesabaislendimi, onay, eklenmeTarihi, silindimi, subeid, kullaniciid, islemTamamlandimi, servereYuklendimi, grupid));
        }
        public class ticaretAyrintiAyrinti
        {
            public long ticaretAyrintiid;
            public long cariid;
            public string odemeTuru;
            public DateTime islemTarihi;
            public string islemSaati;
            public DateTime fiiliSevkTarihi;
            public string islemTuru;
            public string faturaNo;
            public string belgeNo;
            public string irsaliyeNo;
            public string vergiDaire;
            public string vergiNo;
            public string adres;
            public string faturaAciklamasi;
            public string islemAciklamasi;
            public double iskonto;
            public double nakliyat;
            public double iscilik;
            public string hesabaislendimi;
            public string onay;
            public DateTime eklenmeTarihi;
            public string silindimi;
            public int subeid;
            public int kullaniciid;
            public bool servereYuklendimi;
            public bool islemTamamlandimi;
            public int grupid;
            public List<string> listCekSenetID = new List<string>();
            public ticaretAyrintiAyrinti
            (
                long ticaretAyrintiid,
                long cariid,
                string odemeTuru,
                DateTime islemTarihi,
                string islemSaati,
                DateTime fiiliSevkTarihi,
                string islemTuru,
                string faturaNo,
                string belgeNo,
                string irsaliyeNo,
                string vergiDaire,
                string vergiNo,
                string adres,
                string faturaAciklamasi,
                string islemAciklamasi,
                double iskonto,
                double nakliyat,
                double iscilik,
                string hesabaislendimi,
                string onay,
                DateTime eklenmeTarihi,
                string silindimi,
                int subeid,
                int kullaniciid,
                bool islemTamamlandimi,
                bool servereYuklendimi,
                int grupid
            )
            {
                this.ticaretAyrintiid = ticaretAyrintiid;
                this.cariid = cariid;
                this.odemeTuru = odemeTuru;
                this.islemTarihi = islemTarihi;
                this.islemSaati = islemSaati;
                this.fiiliSevkTarihi = fiiliSevkTarihi;
                this.islemTuru = islemTuru;
                this.faturaNo = faturaNo;
                this.belgeNo = belgeNo;
                this.irsaliyeNo = irsaliyeNo;
                this.vergiDaire = vergiDaire;
                this.vergiNo = vergiNo;
                this.adres = adres;
                this.faturaAciklamasi = faturaAciklamasi;
                this.islemAciklamasi = islemAciklamasi;
                this.iskonto = iskonto;
                this.nakliyat = nakliyat;
                this.iscilik = iscilik;
                this.hesabaislendimi = hesabaislendimi;
                this.onay = onay;
                this.eklenmeTarihi = eklenmeTarihi;
                this.silindimi = silindimi;
                this.subeid = subeid;
                this.kullaniciid = kullaniciid;
                this.islemTamamlandimi = islemTamamlandimi;
                this.servereYuklendimi = servereYuklendimi;
                this.grupid = grupid;
            }
        }
    }
    //Ticaret Tablosu Bilgileri
    public static class ticaret
    {
        public static List<ticaretAyrinti> listTicaret = new List<ticaretAyrinti>();
        public static List<ticaret.ticaretAyrinti> bul_ticaretAyrintiid(long ticaretAyrintiid)
        {
            List<ticaretAyrinti> taslakListTicaret = new List<ticaretAyrinti>();
            taslakListTicaret.AddRange(listTicaret.Where(u => u.ticaretAyrintiid == ticaretAyrintiid));
            return taslakListTicaret;
        }
        public static ticaret.ticaretAyrinti bul_ticaretid(long ticaretid)
        {
            return listTicaret.Where(u => u.ticaretid == ticaretid).First();
        }
        public static void sil_ticaretid(long ticaretid)
        {
            listTicaret.Remove(bul_ticaretid(ticaretid));
        }
        public static void sil_ticaretAyrintiid(long ticaretAyrintiid)
        {
            var l = bul_ticaretAyrintiid(ticaretAyrintiid);
            foreach (var i in l)
            {
                sil_ticaretid(i.ticaretid);
            }
        }
        public static void ekle
        (
                long ticaretid
              , long ticaretAyrintiid
              , long stokid
              , string stokkodu
              , string barkod
              , string urunAdi
              , double miktar
              , double satilanMiktar
              , string birim
              , double katsayi
              , double birimFiyat
              , short kdv
              , string kdvTipi
              , double isk1
              , double isk2
              , double isk3
              , string dovizTuru
              , double dovizDegeri
              , string seriNo
              , DateTime eklenmeTarihi
              , string silindimi
              , int subeid
              , int kullaniciid
              , bool servereYuklendimi
              , int grupid
        )
        {
            listTicaret.Add(new ticaretAyrinti(ticaretid, ticaretAyrintiid, stokid, stokkodu, barkod, urunAdi, miktar, satilanMiktar, birim, katsayi, birimFiyat, kdv, kdvTipi, isk1, isk2, isk3, dovizTuru, dovizDegeri, seriNo, eklenmeTarihi, silindimi, subeid, kullaniciid, servereYuklendimi, grupid));
        }
        public static void ekle
        (
            long ticaretid
            , long ticaretAyrintiid
            , long stokid
            , string stokkodu
            , string barkod
            , string urunAdi
            , double miktar
            , double satilanMiktar
            , string birim
            , double katsayi
            , double birimFiyat
            , short kdv
            , string kdvTipi
            , double isk1
            , double isk2
            , double isk3
            , string dovizTuru
            , double dovizDegeri
            , string seriNo
            , DateTime eklenmeTarihi
            , string silindimi
            , int subeid
            , int kullaniciid
            , bool servereYuklendimi
            , int grupid
            , object skt
        )
        {
            listTicaret.Add(new ticaretAyrinti(ticaretid, ticaretAyrintiid, stokid, stokkodu, barkod, urunAdi, miktar, satilanMiktar, birim, katsayi, birimFiyat, kdv, kdvTipi, isk1, isk2, isk3, dovizTuru, dovizDegeri, seriNo, eklenmeTarihi, silindimi, subeid, kullaniciid, servereYuklendimi, grupid, skt));
        }
        public class ticaretAyrinti
        {
            public long ticaretid;
            public long ticaretAyrintiid;
            public long stokid;
            public string stokkodu;
            public string barkod;
            public string urunAdi;
            public double miktar;
            public double satilanMiktar;
            public string birim;
            public double katsayi;
            public double birimFiyat;
            public short kdv;
            public string kdvTipi;
            public double isk1;
            public double isk2;
            public double isk3;
            public string dovizTuru;
            public double dovizDegeri;
            public string seriNo;
            public DateTime eklenmeTarihi;
            public string silindimi;
            public int subeid;
            public int kullaniciid;
            public bool servereYuklendimi;
            public int grupid;
            public object skt;
            public ticaretAyrinti
            (
                long ticaretid
              , long ticaretAyrintiid
              , long stokid
              , string stokkodu
              , string barkod
              , string urunAdi
              , double miktar
              , double satilanMiktar
              , string birim
              , double katsayi
              , double birimFiyat
              , short kdv
              , string kdvTipi
              , double isk1
              , double isk2
              , double isk3
              , string dovizTuru
              , double dovizDegeri
              , string seriNo
              , DateTime eklenmeTarihi
              , string silindimi
              , int subeid
              , int kullaniciid
              , bool servereYuklendimi
              , int grupid
            )
            {
                this.ticaretid = ticaretid;
                this.ticaretAyrintiid = ticaretAyrintiid;
                this.stokid = stokid;
                this.stokkodu = stokkodu;
                this.barkod = barkod;
                this.urunAdi = urunAdi;
                this.miktar = miktar;
                this.satilanMiktar = satilanMiktar;
                this.birim = birim;
                this.katsayi = katsayi;
                this.birimFiyat = birimFiyat;
                this.kdv = kdv;
                this.kdvTipi = kdvTipi;
                this.isk1 = isk1;
                this.isk2 = isk2;
                this.isk3 = isk3;
                this.dovizTuru = dovizTuru;
                this.dovizDegeri = dovizDegeri;
                this.seriNo = seriNo;
                this.eklenmeTarihi = eklenmeTarihi;
                this.silindimi = silindimi;
                this.subeid = subeid;
                this.kullaniciid = kullaniciid;
                this.servereYuklendimi = servereYuklendimi;
                this.grupid = grupid;
            }

            public ticaretAyrinti
            (
                long ticaretid
                , long ticaretAyrintiid
                , long stokid
                , string stokkodu
                , string barkod
                , string urunAdi
                , double miktar
                , double satilanMiktar
                , string birim
                , double katsayi
                , double birimFiyat
                , short kdv
                , string kdvTipi
                , double isk1
                , double isk2
                , double isk3
                , string dovizTuru
                , double dovizDegeri
                , string seriNo
                , DateTime eklenmeTarihi
                , string silindimi
                , int subeid
                , int kullaniciid
                , bool servereYuklendimi
                , int grupid
                , object skt
            )
            {
                this.ticaretid = ticaretid;
                this.ticaretAyrintiid = ticaretAyrintiid;
                this.stokid = stokid;
                this.stokkodu = stokkodu;
                this.barkod = barkod;
                this.urunAdi = urunAdi;
                this.miktar = miktar;
                this.satilanMiktar = satilanMiktar;
                this.birim = birim;
                this.katsayi = katsayi;
                this.birimFiyat = birimFiyat;
                this.kdv = kdv;
                this.kdvTipi = kdvTipi;
                this.isk1 = isk1;
                this.isk2 = isk2;
                this.isk3 = isk3;
                this.dovizTuru = dovizTuru;
                this.dovizDegeri = dovizDegeri;
                this.seriNo = seriNo;
                this.eklenmeTarihi = eklenmeTarihi;
                this.silindimi = silindimi;
                this.subeid = subeid;
                this.kullaniciid = kullaniciid;
                this.servereYuklendimi = servereYuklendimi;
                this.grupid = grupid;
                this.skt = skt;
            }
        }
    }
    //Açık Hesap Tablosu Bilgileri
    public class acikHesap
    {
        public static List<acikHesapAyrinti> listAcikHesap = new List<acikHesapAyrinti>();
        public static void ekle
        (
           long acikHesapid,
           long ticaretAyrintiid,
           long cekSenetid,
           long taksitid,
           int bankaislemid,
           long cariid,
           DateTime kayitTarihi,
           DateTime odemeTarihi,
           DateTime vadeTarihi,
           double borc,
           double alacak,
           string dovizTuru,
           double dovizDegeri,
           double cezaTutari,
           string islemTuru,
           string islemTuru2,
           string yeri,
           string aciklama,
           string faturaNo,
           string belgeNo,
           string irsaliyeNo,
           string vergiDaire,
           string vergiNo,
           string hesabaislendimi,
           string silindimi,
           int subeid,
           int kullaniciid,
           int grupid,
           double duzenlemeBakiyesi
        )
        {
            listAcikHesap.Add(new acikHesapAyrinti(acikHesapid, ticaretAyrintiid, cekSenetid, taksitid, bankaislemid, cariid, kayitTarihi, odemeTarihi, vadeTarihi, borc, alacak, dovizTuru, dovizDegeri, cezaTutari, islemTuru, islemTuru2, yeri, aciklama, faturaNo, belgeNo, irsaliyeNo, vergiDaire, vergiNo, hesabaislendimi, silindimi, subeid, kullaniciid, grupid, duzenlemeBakiyesi));
        }
        public class acikHesapAyrinti
        {
            public long acikHesapid;
            public long ticaretAyrintiid;
            public long cekSenetid;
            public long taksitid;
            public int bankaislemid;
            public long cariid;
            public DateTime kayitTarihi;
            public DateTime odemeTarihi;
            public DateTime vadeTarihi;
            public double borc;
            public double alacak;
            public string dovizTuru;
            public double dovizDegeri;
            public double cezaTutari;
            public string islemTuru;
            public string islemTuru2;
            public string yeri;
            public string aciklama;
            public string faturaNo;
            public string belgeNo;
            public string irsaliyeNo;
            public string vergiDaire;
            public string vergiNo;
            public string hesabaislendimi;
            public string silindimi;
            public int subeid;
            public int kullaniciid;
            public bool servereYuklendimi;
            public int grupid;
            public double duzenlemeBakiyesi;
            public acikHesapAyrinti
            (
                long acikHesapid,
                long ticaretAyrintiid,
                long cekSenetid,
                long taksitid,
                int bankaislemid,
                long cariid,
                DateTime kayitTarihi,
                DateTime odemeTarihi,
                DateTime vadeTarihi,
                double borc,
                double alacak,
                string dovizTuru,
                double dovizDegeri,
                double cezaTutari,
                string islemTuru,
                string islemTuru2,
                string yeri,
                string aciklama,
                string faturaNo,
                string belgeNo,
                string irsaliyeNo,
                string vergiDaire,
                string vergiNo,
                string hesabaislendimi,
                string silindimi,
                int subeid,
                int kullaniciid,
                int grupid,
                double duzenlemeBakiyesi
            )
            {
                this.acikHesapid = acikHesapid;
                this.ticaretAyrintiid = ticaretAyrintiid;
                this.cekSenetid = cekSenetid;
                this.taksitid = taksitid;
                this.bankaislemid = bankaislemid;
                this.cariid = cariid;
                this.kayitTarihi = kayitTarihi;
                this.odemeTarihi = odemeTarihi;
                this.vadeTarihi = vadeTarihi;
                this.borc = borc;
                this.alacak = alacak;
                this.dovizTuru = dovizTuru;
                this.dovizDegeri = dovizDegeri;
                this.cezaTutari = cezaTutari;
                this.islemTuru = islemTuru;
                this.islemTuru2 = islemTuru2;
                this.yeri = yeri;
                this.aciklama = aciklama;
                this.faturaNo = faturaNo;
                this.belgeNo = belgeNo;
                this.irsaliyeNo = irsaliyeNo;
                this.vergiDaire = vergiDaire;
                this.vergiNo = vergiNo;
                this.hesabaislendimi = hesabaislendimi;
                this.silindimi = silindimi;
                this.subeid = subeid;
                this.kullaniciid = kullaniciid;
                this.servereYuklendimi = false;
                this.grupid = grupid;
                this.duzenlemeBakiyesi = duzenlemeBakiyesi;
                cariBilgileri.bakiyeGuncelle(cariid, borc, alacak, duzenlemeBakiyesi);
            }
        }
    }
    //veritabanına değerleri yükleme sınıfı
    public class veritabaninaYuklemeMotoru
    {
        public static bool programCalisiyormu = true;
        private static bool kontrolEdiliyormu = false;
        static Thread kanal;
        public static void baslangic()
        {
            kanal = new Thread(new ThreadStart(bekleVeIslemiTekrarla));
            kanal.Start();
        }
        private static void bekleVeIslemiTekrarla()
        {
            while (programCalisiyormu)
            {
                Thread.Sleep(3000);
                kontrolisleminiYap();
            }
            kanal.Abort();
        }

        public static void kontrolEt()
        {
            kanal = new Thread(new ThreadStart(kontrolisleminiYap));
            kanal.Start();
        }

        private static void kontrolisleminiYap()
        {
            try
            {
                if (kontrolEdiliyormu == true) return;
                if (guvenlikVeKontrol.internetVarmi())
                {
                    kontrolEdiliyormu = true;
                    try
                    {
                        var l1 = ticaretAyrinti2.listTicaretAyrinti.Where(u => u.servereYuklendimi == false && u.islemTamamlandimi == true).OrderBy(u => u.grupid).First();
                        if (l1 != null)
                        {
                            //veritabanına ticaret ayrıntı ekleniyor ve yeni id çekiliyor
                            if (l1.ticaretAyrintiid != 0 && l1.islemTuru == "Giden Transfer")
                            {
                                //Transfer düzenlemesi için eski kayıtlar siliniyor.
                                veri.cmd("Delete from tblTicaretAyrinti where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + l1.ticaretAyrintiid + "");
                                veri.cmd("Delete from tblTicaret where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + l1.ticaretAyrintiid + "");
                                long ticaretAyrintiid_transfer = Convert.ToInt64(veri.getdatacell("Select top 1 ticaretAyrintiid from sorTicaretAyrinti where ticaretAyrintiid > " + l1.ticaretAyrintiid + " and firmaid = " + firma.firmaid + " and islemTuru = 'Gelen Transfer' "));
                                veri.cmd("Delete from tblTicaretAyrinti where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + ticaretAyrintiid_transfer + "");
                                veri.cmd("Delete from tblTicaret where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + ticaretAyrintiid_transfer + "");
                                l1.ticaretAyrintiid = 0;
                            }
                            else if (l1.ticaretAyrintiid != 0 && l1.islemTuru == "Gelen Transfer")
                            {
                                l1.ticaretAyrintiid = 0;
                            }
                            //////////////

                            // önceki tiraceri sil
                            veri.cmd("Delete from tblTicaretAyrinti where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + l1.ticaretAyrintiid + "");
                            veri.cmd("Delete from tblTicaret where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + l1.ticaretAyrintiid + "");
                            if (l1.ticaretAyrintiid != 0)
                                veri.cmd("Delete from tblAcikHesap where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + l1.ticaretAyrintiid + "");

                            /////////////

                            long ticaretAyrintiid = Convert.ToInt64(veri.getdatacell("exec spSetTicaretAyrinti " + 0 + "," + l1.cariid + ",'" + l1.odemeTuru + "','" + l1.islemTarihi + "','" + l1.islemSaati + "','" + l1.fiiliSevkTarihi + "','" + l1.islemTuru + "','" + l1.faturaNo + "','" + l1.belgeNo + "','" + l1.irsaliyeNo + "','" + l1.vergiDaire + "','" + l1.vergiNo + "','" + l1.adres + "','" + l1.faturaAciklamasi + "','" + l1.islemAciklamasi + "','','" + l1.iskonto.ToString().Replace(",", ".") + "','" + l1.nakliyat.ToString().Replace(",", ".") + "','" + l1.iscilik.ToString().Replace(",", ".") + "','" + l1.hesabaislendimi + "','" + l1.onay + "','Ticari Program'," + firma.firmaid + "," + l1.subeid + "," + l1.kullaniciid + ",0,'','','','',0,0,0,0,0"));
                            l1.servereYuklendimi = true;

                            //Çek Senetli alış satış ise ilişkilendiriliyor
                            for (int i = 0; i < l1.listCekSenetID.Count; i++)
                            {
                                veri.cmd("Update tblAcikHesap set ticaretAyrintiid = " + ticaretAyrintiid + " where firmaid = " + firma.firmaid + " and cekSenetid = " + l1.listCekSenetID[i] + "");
                            }
                            //yeni ticaretAyrinti id ticaret tablosuna aktarılıyor
                            var degisecekTicaretTablosu = ticaret.listTicaret.Where(u => u.grupid == l1.grupid);
                            foreach (ticaret.ticaretAyrinti i in degisecekTicaretTablosu)
                            {
                                i.ticaretAyrintiid = ticaretAyrintiid;
                                if (l1.islemTuru.Contains("Transfer")) i.ticaretid = 0;
                            }
                            //yeni ticaretAyrinti id Açıkhesap tablosuna aktarılıyor
                            var degisecekAcikHesapTablosu = acikHesap.listAcikHesap.Where(u => u.grupid == l1.grupid);
                            foreach (acikHesap.acikHesapAyrinti i in degisecekAcikHesapTablosu) i.ticaretAyrintiid = ticaretAyrintiid;

                            //Ticaret tablosu veritabanına aktarılıyor ve eklenen idler güncelleniyor
                            var l2 = ticaret.listTicaret.Where(u => u.servereYuklendimi == false && u.ticaretAyrintiid == ticaretAyrintiid);
                            if (l2 != null)
                            {
                                using (DataTable dt = new DataTable())
                                {
                                    dt.Columns.Add("ticaretid", typeof(Int64));
                                    dt.Columns.Add("ticaretAyrintiid", typeof(Int64));
                                    dt.Columns.Add("stokid", typeof(Int64));
                                    dt.Columns.Add("barkod", typeof(string));
                                    dt.Columns.Add("urunAdi", typeof(string));
                                    dt.Columns.Add("miktar", typeof(double));
                                    dt.Columns.Add("birim", typeof(string));
                                    dt.Columns.Add("katsayi", typeof(double));
                                    dt.Columns.Add("birimFiyat", typeof(double));
                                    dt.Columns.Add("kdv", typeof(Int16));
                                    dt.Columns.Add("kdvTipi", typeof(string));
                                    dt.Columns.Add("isk1", typeof(double));
                                    dt.Columns.Add("isk2", typeof(double));
                                    dt.Columns.Add("isk3", typeof(double));
                                    dt.Columns.Add("dovizTuru", typeof(string));
                                    dt.Columns.Add("dovizDegeri", typeof(float));
                                    dt.Columns.Add("kargoUcreti", typeof(double));/*değiştirdim*/
                                    dt.Columns.Add("seriNo", typeof(string));
                                    dt.Columns.Add("firmaid", typeof(int));
                                    dt.Columns.Add("subeid", typeof(int));
                                    dt.Columns.Add("kullaniciid", typeof(int));
                                    dt.Columns.Add("stk", typeof(DateTime));
                                    foreach (ticaret.ticaretAyrinti i in l2)
                                    {
                                        dt.Rows.Add(0, i.ticaretAyrintiid, i.stokid, i.barkod, i.urunAdi, i.miktar, i.birim, i.katsayi, i.birimFiyat, i.kdv, i.kdvTipi, i.isk1, i.isk2, i.isk3, i.dovizTuru, i.dovizDegeri, 0, i.seriNo, firma.firmaid, i.subeid, i.kullaniciid, i.skt);
                                        i.servereYuklendimi = true;
                                    }
                                    SqlParameter[] parameterList ={
                                                new SqlParameter("@ticaret_type",dt),
                                                new SqlParameter("@ticaretid",Convert.ToInt64(dt.Rows[0]["ticaretid"]))
                                               };
                                    Int64 a = Convert.ToInt64(veri.getdatacell("[spSetTicaretTest]", parameterList));
                                    if (a > 0) //işlem başarıl ise
                                    {
                                        try
                                        {
                                            if (EFatura.LoginOK && EFatura.OtoGonder)
                                            {
                                                #region  E-Fatura İşlemleri
                                                string faturaNo = EFatura.EFaturaNo;
                                                string AliciGib = EFatura.AliciGB;
                                                if ((EFatura.EFaturaID > 0 && ticaretAyrintiid > 0) && l1.islemTuru.Contains("Faturalı"))
                                                {
                                                    SEFatura fatura = new SEFatura(EFatura.KullaniciAdi, EFatura.Sifre, EFatura.UrlAdresi);
                                                    fatura.Current_Login();
                                                    Thread.Sleep(3000);
                                                    string[] faturaYolu = fatura.CreateInvoiceTypeDataTable(AliciGib, EFatura.EFaturaNo, l1.cariid, dt, l1.islemTarihi).Split('~');
                                                    if (faturaYolu.Length > 0)
                                                    {
                                                        List<FormParameters> list = fatura.Current_SendInvoiceMultiTest(AliciGib, faturaYolu[0]);
                                                        if (list != null)
                                                        {
                                                            if (FormValues.sendInvoiceEnter == "Fatura Gönderildi")
                                                            {
                                                                veri.cmd("Update tblTicaretAyrinti set eFaturaMi=1 where ticaretAyrintiid=" + ticaretAyrintiid);
                                                                veri.cmd("insert into tblEFaturaNo (FaturaNo,FirmaID,FaturaTarihi) values('" + faturaNo + "'," + firma.firmaid + ",'" + l1.islemTarihi + "')");
                                                                veri.cmd("Update tblTicaretAyrinti set faturaNo='" + faturaNo + "' where ticaretAyrintiid=" + ticaretAyrintiid);
                                                                MessageBox.Show(FormValues.sendInvoiceEnter + "\n Lütfen bekleyiniz fatura önizleme yapılıyor", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                Task.Run(() =>
                                                                {
                                                                    INVOICE[] getFormParameters =
                                                                        fatura.Current_GetInvoice(true, "PDF", true,
                                                                            "OUT", 1, faturaNo, null);
                                                                    if (FormValues.getInvoiceEnter ==
                                                                        "Faturalar başarıyla indirildi.")
                                                                    {
                                                                        if (getFormParameters != null &&
                                                                            getFormParameters.Length > 0)
                                                                            if (getFormParameters[0].CONTENT != null)
                                                                            {
                                                                                string fileName = faturaNo + ".PDF";
                                                                                File.WriteAllBytes(fileName,
                                                                                    getFormParameters[0].CONTENT.Value);
                                                                                Process.Start(fileName);
                                                                            }

                                                                            else
                                                                                MessageBox.Show(
                                                                                    FormValues.getInvoiceEnter + "\n" +
                                                                                    FormValues.ifHaveError, "Uyarı",
                                                                                    MessageBoxButtons.OK,
                                                                                    MessageBoxIcon.Error);
                                                                    }
                                                                    else
                                                                        MessageBox.Show(
                                                                            FormValues.getInvoiceEnter + "\n" +
                                                                            FormValues.ifHaveError, "Uyarı",
                                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                                                                });
                                                            }
                                                            else if (FormValues.sendInvoiceEnter == "Fatura Gönderilemedi")
                                                                MessageBox.Show(FormValues.sendInvoiceEnter + "\n" + FormValues.ifHaveError, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            MessageBox.Show("E-Fatura gönderirken bir hata oluştu: " + e.Message);
                                        }
                                    }
                                    else //hata olşutu ise ticaretayrintiyi sil
                                    {
                                        veri.cmd("Delete from tblTicaretAyrinti where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + Convert.ToInt64(dt.Rows[0]["ticaretAyrintiid"]) + "");
                                        acikHesap.listAcikHesap.Where(u => u.servereYuklendimi == false && u.ticaretAyrintiid == Convert.ToInt64(dt.Rows[0]["ticaretAyrintiid"]) && u.grupid != 0).ToList().Clear();
                                    }
                                }
                            }
                            if (l1.islemTuru == "Faturasız Alış" || l1.islemTuru == "Faturalı Alış") guncelle.stokkartVerileriniGuncelle();
                            //AçıkHesap tablosu veritabanına aktarılıyor ve eklenen idler güncelleniyor
                            var l3 = acikHesap.listAcikHesap.Where(u => u.servereYuklendimi == false && u.ticaretAyrintiid == ticaretAyrintiid && u.grupid != 0);
                            if (l3 != null)
                            {
                                try
                                {
                                    if (ticaretAyrintiid != 0)
                                    {
                                        if (!l1.odemeTuru.Contains("Pos") && !l1.odemeTuru.Contains("Kredi Kartı"))
                                        {
                                            veri.cmd("delete from tblBankaislemleri Where bankaislemid = (Select top 1 bankaislemid from tblAcikHesap Where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + ticaretAyrintiid + ")  ");
                                        }
                                        if (l1.odemeTuru == "Çek-Senet")
                                        {
                                            veri.cmd("delete from tblAcikHesap Where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + ticaretAyrintiid + " and cekSenetid = 0");
                                        }
                                        else
                                        {
                                            veri.cmd("delete from tblAcikHesap Where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + ticaretAyrintiid + "  ");
                                        }

                                    }
                                    foreach (acikHesap.acikHesapAyrinti i in l3)
                                    {
                                        string odemeTarihi = i.odemeTarihi.ToShortDateString();
                                        if (i.odemeTarihi == Convert.ToDateTime(null)) odemeTarihi = "";
                                        string vadeTarihi = i.vadeTarihi.ToShortDateString();
                                        if (i.vadeTarihi == Convert.ToDateTime(null)) vadeTarihi = "";
                                        i.acikHesapid = Convert.ToInt64(veri.getdatacell("exec spSetAcikHesap '" + i.acikHesapid + "','" + i.ticaretAyrintiid + "','" + i.cekSenetid + "','" + i.taksitid + "','" + i.bankaislemid + "','" + i.cariid + "','" + i.kayitTarihi + "','" + odemeTarihi + "','" + vadeTarihi + "','" + i.borc.ToString().Replace(",", ".") + "','" + i.alacak.ToString().Replace(",", ".") + "','" + i.dovizTuru + "','" + i.dovizDegeri.ToString().Replace(",", ".") + "','" + i.cezaTutari.ToString().Replace(",", ".") + "','" + i.islemTuru + "','" + i.islemTuru2 + "','" + i.yeri + "','" + i.aciklama + "','" + i.faturaNo + "','" + i.belgeNo + "','" + i.irsaliyeNo + "','" + i.vergiDaire + "','" + i.vergiNo + "','" + i.hesabaislendimi + "','" + firma.firmaid + "','" + i.subeid + "','" + i.kullaniciid + "'"));
                                        i.servereYuklendimi = true;
                                    }
                                }
                                catch (Exception hata)
                                {

                                }

                            }
                        }
                    }
                    catch (Exception hata)
                    {
                        kontrolEdiliyormu = false;
                    }

                    try
                    {
                        //AçıkHesap tablosu veritabanına aktarılıyor ve eklenen idler güncelleniyor (ticaret tablosu değil)
                        var l4 = acikHesap.listAcikHesap.Where(u => u.servereYuklendimi == false && u.grupid == 0);
                        if (l4 != null)
                        {
                            foreach (acikHesap.acikHesapAyrinti i in l4)
                            {
                                string odemeTarihi = i.odemeTarihi.ToShortDateString();
                                if (i.odemeTarihi == Convert.ToDateTime(null)) odemeTarihi = null;
                                string vadeTarihi = i.vadeTarihi.ToShortDateString();
                                if (i.vadeTarihi == Convert.ToDateTime(null)) vadeTarihi = null;
                                i.acikHesapid = Convert.ToInt64(veri.getdatacell("exec spSetAcikHesap '" + i.acikHesapid + "','" + i.ticaretAyrintiid + "','" + i.cekSenetid + "','" + i.taksitid + "','" + i.bankaislemid + "','" + i.cariid + "','" + i.kayitTarihi + "','" + odemeTarihi + "','" + vadeTarihi + "','" + i.borc.ToString().Replace(",", ".") + "','" + i.alacak.ToString().Replace(",", ".") + "','" + i.dovizTuru + "','" + i.dovizDegeri.ToString().Replace(",", ".") + "','" + i.cezaTutari.ToString().Replace(",", ".") + "','" + i.islemTuru + "','" + i.islemTuru2 + "','" + i.yeri + "','" + i.aciklama + "','" + i.faturaNo + "','" + i.belgeNo + "','" + i.irsaliyeNo + "','" + i.vergiDaire + "','" + i.vergiNo + "','" + i.hesabaislendimi + "','" + firma.firmaid + "','" + i.subeid + "','" + i.kullaniciid + "'"));
                                i.servereYuklendimi = true;
                            }
                        }
                    }
                    catch
                    {
                        kontrolEdiliyormu = false;
                    }

                }
            }
            catch (Exception hata)
            {
            }
            finally
            {
                kontrolEdiliyormu = false;
            }

        }
    }
    //diğer listeler
    public class listeler
    {
        //kategori getirme işlemleri -------------------------------------------------
        private static string[] kategoriAdlari;
        private static string[] kategoriidleri;
        private static List<string> listKategoriadlari = new List<string>();
        private static List<string> listKategoriidleri = new List<string>();
        public static void yukleKategori()
        {
            listKategoriidleri.Clear();
            listKategoriadlari.Clear();
            SqlDataReader dr = veri.getDatareader("select katNo,kategoriAdi from sorKategori where firmaid = '" + firma.firmaid + "' order by kategoriAdi asc");
            while (dr.Read())
            {
                listKategoriidleri.Add(dr["katNo"].ToString());
                listKategoriadlari.Add(dr["kategoriAdi"].ToString());
            }
            kategoriidleri = new string[listKategoriidleri.Count];
            kategoriAdlari = new string[listKategoriidleri.Count];
            for (int i = 0; i < listKategoriidleri.Count; i++)
            {
                kategoriidleri[i] = listKategoriidleri[i];
                kategoriAdlari[i] = listKategoriadlari[i];
            }

        }
        public static string[] getKategoriNo()
        {
            return kategoriidleri;
        }
        public static string[] getKategoriadi()
        {
            return kategoriAdlari;
        }

        //ürünismi getirme işlemleri-------------------------------------------------
        private static string[] urunAdlari;
        private static Int64[] stokidler;
        public static void yukleUrunadi()
        {
            stokidler = new Int64[stokkart.listStokkart.Count];
            urunAdlari = new string[stokkart.listStokkart.Count];
            var l = stokkart.listStokkart.Where(u => u.aktifmi == "1" && u.silindimi == "0").OrderBy(u => u.urunAdi);
            int i = 0;
            foreach (var item in l)
            {
                stokidler[i] = item.stokid;
                urunAdlari[i] = item.urunAdi;
                i++;
            }
        }
        public static Int64[] getStokid()
        {
            return stokidler;
        }
        public static string[] getUrunisim()
        {
            return urunAdlari;
        }

        //CariAdi getirme işlemleri--------------------------------------------------
        private static string[] cariAdlari;
        private static Int64[] cariidler;
        public static void yukleCariadi()
        {
            cariidler = new Int64[cariBilgileri.listCariBilgileri.Count];
            cariAdlari = new string[cariBilgileri.listCariBilgileri.Count];
            var l = cariBilgileri.listCariBilgileri.Where(u => u.hesabaislensinmi == "1" && u.silindimi == "0").OrderBy(u => u.adiSoyadi);
            int i = 0;
            foreach (var item in l)
            {
                cariidler[i] = item.cariid;
                cariAdlari[i] = item.adiSoyadi;
                i++;
            }
        }
        public static Int64[] getCariid()
        {
            return cariidler;
        }
        public static string[] getCariAdi()
        {
            return cariAdlari;
        }

        //CariGrupları getirme işlemleri---------------------------------------------
        private static string[] cariGrupAdlari;
        private static int[] cariGrupid;
        public static void yukleCariGruplari()
        {
            cariGrupid = new int[cariBilgileri.cariGruplari.listCariGruplari.Count];
            cariGrupAdlari = new string[cariBilgileri.cariGruplari.listCariGruplari.Count];
            var l = cariBilgileri.cariGruplari.listCariGruplari.OrderBy(u => u.grupAdi);
            int i = 0;
            foreach (var item in l)
            {
                cariGrupid[i] = item.cariGrupid;
                cariGrupAdlari[i] = item.grupAdi;
                i++;
            }
        }
        public static int[] getCariGrupid()
        {
            return cariGrupid;
        }
        public static string[] getCariGrupAdi()
        {
            return cariGrupAdlari;
        }

        //Adres Bilgileri getirme işlemleri------------------------------------------
        private static string[] adresAdlari;
        private static Int64[] adresidleri;
        public static void yukleAdresler()
        {
            adresidleri = new Int64[cariBilgileri.adresBilgileri.listAdresBilgileri.Count];
            adresAdlari = new string[cariBilgileri.adresBilgileri.listAdresBilgileri.Count];
            var l = cariBilgileri.adresBilgileri.listAdresBilgileri.OrderBy(u => u.adresAdi);
            int i = 0;
            foreach (var item in l)
            {
                adresidleri[i] = item.adresid;
                adresAdlari[i] = item.adresAdi;
                i++;
            }
        }
        public static Int64[] getAdresidleri()
        {
            return adresidleri;
        }
        public static string[] getAdresAdlari()
        {
            return adresAdlari;
        }

        //Şube getirme işlemleri------------------------------------------------------
        private static List<string> listSubeadlari = new List<string>();
        private static List<int> listSubeidleri = new List<int>();
        public static void yukleSube()
        {
            listSubeidleri.Clear();
            listSubeadlari.Clear();
            SqlDataReader dr = veri.getDatareader("select subeid, subeAdi from sorFirmaSubeleri where firmaid = '" + firma.firmaid + "' order by subeAdi asc");
            while (dr.Read())
            {
                listSubeidleri.Add(Convert.ToInt32(dr["subeid"]));
                listSubeadlari.Add(dr["subeAdi"].ToString());
            }
            //subeidleri = new int[listSubeidleri.Count];
            //subeAdlari = new string[listSubeidleri.Count];
            //for (int i = 0; i < listSubeidleri.Count; i++)
            //{
            //    subeidleri[i] = listSubeidleri[i];
            //    subeAdlari[i] = listSubeadlari[i];
            //}
        }
        public static void doldurSube(ComboBox cmbSube)
        {
            cmbSube.Items.Clear();
            for (int i = 0; i < listSubeadlari.Count; i++)
            {
                cmbSube.Items.Add(new ComboboxItem(listSubeidleri[i].ToString(), listSubeadlari[i]));
            }
            ComboboxItem.setValue(cmbSube, firma.subeid.ToString());
            if (!subelereErisimYetkisi) cmbSube.Enabled = false;
        }
        public static void doldurKullanici(ComboBox cmbKullanici, string subeid)
        {
            cmbKullanici.Items.Clear();
            for (int i = 0; i < listKullaniciadlari.Count(); i++)
            {
                if (listKullaniciSubeidleri[i].ToString() == subeid) cmbKullanici.Items.Add(new ComboboxItem(listKullaniciidleri[i].ToString(), listKullaniciadlari[i]));
                if (subeid.Equals("")) cmbKullanici.Items.Add(new ComboboxItem(listKullaniciidleri[i].ToString(), listKullaniciadlari[i]));
            }
            if (subeid == firma.subeid.ToString()) ComboboxItem.setValue(cmbKullanici, firma.kullaniciid.ToString());
            else if (cmbKullanici.Items.Count > 0) cmbKullanici.SelectedIndex = 0;
            else cmbKullanici.Text = "";
            if (!kullanicilaraErisimYetkisi) cmbKullanici.Enabled = false;
        }

        static bool subelereErisimYetkisi = true;
        static bool kullanicilaraErisimYetkisi = true;
        //public static int[] getSubeno()
        //{
        //    return subeidleri;
        //}
        //public static string[] getSubeadi()
        //{
        //    return subeAdlari;
        //}

        //Marka getirme işlemleri-----------------------------------------------------
        private static string[] markaAdlari;
        private static int[] markaidleri;
        private static List<string> listMarkaadlari = new List<string>();
        private static List<int> listMarkaidleri = new List<int>();
        public static void yukleMarka()
        {
            listMarkaidleri.Clear();
            listMarkaadlari.Clear();
            SqlDataReader dr = veri.getDatareader("select markaid, markaAdi from sorMarkalar where firmaid = '" + firma.firmaid + "' order by markaAdi asc");
            while (dr.Read())
            {
                listMarkaidleri.Add(Convert.ToInt32(dr["markaid"]));
                listMarkaadlari.Add(dr["markaAdi"].ToString());
            }
            markaidleri = new int[listMarkaidleri.Count];
            markaAdlari = new string[listMarkaidleri.Count];
            for (int i = 0; i < listMarkaidleri.Count; i++)
            {
                markaidleri[i] = listMarkaidleri[i];
                markaAdlari[i] = listMarkaadlari[i];
            }
        }
        public static int[] getMarkano()
        {
            return markaidleri;
        }
        public static string[] getMarkaadi()
        {
            return markaAdlari;
        }

        //Kullanici getirme işlemleri-------------------------------------------------
        //private static string[] kullaniciAdlari;
        //private static int[] kullaniciidleri;
        private static List<string> listKullaniciadlari = new List<string>();
        private static List<int> listKullaniciidleri = new List<int>();
        private static List<int> listKullaniciSubeidleri = new List<int>();
        public static void yukleKullanici()
        {
            listKullaniciidleri.Clear();
            listKullaniciadlari.Clear();
            SqlDataReader dr = veri.getDatareader("select kullaniciid, KAdi, subeid from sorFirmaKullanicilari where firmaid = '" + firma.firmaid + "' order by kAdi asc");
            while (dr.Read())
            {
                listKullaniciidleri.Add(Convert.ToInt32(dr["kullaniciid"]));
                listKullaniciadlari.Add(dr["kAdi"].ToString());
                listKullaniciSubeidleri.Add(Convert.ToInt32(dr["subeid"]));
            }
            //kullaniciidleri = new int[listKullaniciidleri.Count];
            //kullaniciAdlari = new string[listKullaniciidleri.Count];
            //for (int i = 0; i < listKullaniciidleri.Count; i++)
            //{
            //    kullaniciidleri[i] = listKullaniciidleri[i];
            //    kullaniciAdlari[i] = listKullaniciadlari[i];
            //}
        }
        //public static int[] getKullaniciid()
        //{
        //    return kullaniciidleri;
        //}
        //public static string[] getKullaniciadi()
        //{
        //    return kullaniciAdlari;
        //}

        //Birim getirme işlemleri-----------------------------------------------------
        private static string[] birimAdlari;
        private static int[] birimidleri;
        private static List<string> listBirimadlari = new List<string>();
        private static List<int> listBirimidleri = new List<int>();
        public static void yukleBirim()
        {
            listBirimidleri.Clear();
            listBirimadlari.Clear();
            SqlDataReader dr = veri.getDatareader("select birimid, birimAdi from sorBirimler where firmaid = '" + firma.firmaid + "' order by birimAdi asc");
            while (dr.Read())
            {
                listBirimidleri.Add(Convert.ToInt32(dr["birimid"]));
                listBirimadlari.Add(dr["birimAdi"].ToString());
            }
            birimidleri = new int[listBirimidleri.Count];
            birimAdlari = new string[listBirimidleri.Count];
            for (int i = 0; i < listBirimidleri.Count; i++)
            {
                birimidleri[i] = listBirimidleri[i];
                birimAdlari[i] = listBirimadlari[i];
            }
        }
        public static int[] getBirimid()
        {
            return birimidleri;
        }
        public static string[] getBirimAdi()
        {
            return birimAdlari;
        }

        //Fiyat Taslak getirme işlemleri----------------------------------------------
        private static string[] fiyatAdlari;
        private static int[] fiyatidleri;
        private static List<string> listFiyatadlari = new List<string>();
        private static List<int> listFiyatidleri = new List<int>();
        public static void yukleFiyat()
        {
            listFiyatidleri.Clear();
            listFiyatadlari.Clear();
            SqlDataReader dr = veri.getDatareader("select fiyatid, fiyatAdi from sorFiyatTaslak where firmaid = '" + firma.firmaid + "' order by fiyatid asc");
            while (dr.Read())
            {
                listFiyatidleri.Add(Convert.ToInt32(dr["fiyatid"]));
                listFiyatadlari.Add(dr["fiyatAdi"].ToString());
            }
            fiyatidleri = new int[listFiyatidleri.Count];
            fiyatAdlari = new string[listFiyatidleri.Count];
            for (int i = 0; i < listFiyatidleri.Count; i++)
            {
                fiyatidleri[i] = listFiyatidleri[i];
                fiyatAdlari[i] = listFiyatadlari[i];
            }
        }
        public static int[] getFiyatid()
        {
            return fiyatidleri;
        }
        public static string[] getFiyatAdi()
        {
            return fiyatAdlari;
        }

        //personel getirme işlemleri--------------------------------------------------
        private static string[] personelAdlari;
        private static Int64[] personelidler;
        private static List<string> listPersonelAdlari = new List<string>();
        private static List<int> listPersonelidleri = new List<int>();
        public static void yuklePersonelAdi()
        {
            listPersonelidleri.Clear();
            listPersonelAdlari.Clear();
            SqlDataReader dr = veri.getDatareader("select personelid, (adi+' ' +soyadi) as personelAdi from sorPersonelBilgileri where firmaid = '" + firma.firmaid + "' and silindimi = '0' and subeid = " + firma.subeid + " order by personelAdi asc");
            while (dr.Read())
            {
                listPersonelidleri.Add(Convert.ToInt32(dr["personelid"]));
                listPersonelAdlari.Add(dr["personelAdi"].ToString());
            }
            personelidler = new long[listPersonelidleri.Count];
            personelAdlari = new string[listPersonelidleri.Count];
            for (int i = 0; i < listPersonelidleri.Count; i++)
            {
                personelidler[i] = listPersonelidleri[i];
                personelAdlari[i] = listPersonelAdlari[i];
            }
        }
        public static Int64[] getPersonelid()
        {
            return personelidler;
        }
        public static string[] getPersonelAdi()
        {
            return personelAdlari;
        }
    }
}