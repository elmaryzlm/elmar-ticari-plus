using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Elmar_Ticari_Plus
{
        //firma
        public class firmaBilgileri2
        {
            public static string firmaAdiSoyadi;
            public static string engellimi;
            public static byte stok = 0;
            public static byte satis = 0;
            public static byte kasa = 0;
            public static byte cari = 0;
            public static byte cekSenet = 0;
            public static byte personel = 0;
            public static byte banka = 0;
            public static byte mobil = 0;
        }
        //şube
        public class subeBilgileri2
        {
            public static string subeAdi;
            public static string adres;
            public static string tel;
            public static string gsm;
            public static string fax;
        }
        public class firma2
        {
            //Kullanıcı
            public static string sifre;
            public static string kullaniciAdi;
            public static int kullaniciid;
            public static string gorevi;

            //Şube
            public static int subeid;

            //Firma                
            public static int firmaid;
            public static string demomu;
            public static string demoKalanGun;


            public static string programAdi = "Elmar Ticari Plus Mobile";
            public static string personel = "0";
            public static string muhasebe = "0";
            public static string hastane = "0";
            public static string otel = "0";
            public static string yurt = "0";
        }
        //verileri güncelleme classları
        public class guncelle2
        {
            public static void ayarlariGuncelle2()
            {

                try
                {
                    veriCE.cmd("Delete from tblFirmaKullaniciAyarlari where kullaniciid = " + firma2.kullaniciid + "");
                    SqlDataReader dr = veri.getDatareader("select ayarid, firmaid, subeid, kullaniciid, ayarAdi, degeri from tblFirmaKullaniciAyarlari where kullaniciid = " + firma2.kullaniciid + " and (ortam = 'Ticari Program' or ortam = 'Mobil')");
                    while (dr.Read())
                    {
                        try
                        {
                            veriCE.cmd("Insert into tblFirmaKullaniciAyarlari(ayarid, firmaid, subeid, kullaniciid, ayarAdi, degeri, servereYuklendimi) values(" + dr["ayarid"].ToString() + ", " + dr["firmaid"].ToString() + ", " + dr["subeid"].ToString() + ", " + dr["kullaniciid"].ToString() + ", '" + dr["ayarAdi"].ToString() + "', '" + dr["degeri"].ToString() + "','1')");
                        }
                        catch
                        {
                        }
                    }
                    dr.Close();
                }
                catch (Exception hata)
                {
                }


            }
            public static void yetkileriGuncelle2()
            {
                try
                {
                    SqlDataReader dr = veri.getDatareader("select yetkiid, firmaid, subeid, kullaniciid, yetkiAdi, degeri from tblFirmaKullaniciYetkileri where kullaniciid = " + firma2.kullaniciid + " and (ortam = 'Ticari Program' or ortam = 'Mobil')");
                    while (dr.Read())
                    {
                        try
                        {
                            veriCE.cmd("Insert into tblFirmaKullaniciYetkileri(yetkiid, firmaid, subeid, kullaniciid, yetkiAdi, degeri) values(" + dr["yetkiid"].ToString() + "," + dr["firmaid"].ToString() + ", " + dr["subeid"].ToString() + ", " + dr["kullaniciid"].ToString() + ", '" + dr["yetkiAdi"].ToString() + "', '" + dr["degeri"].ToString() + "')");
                        }
                        catch (Exception hata)
                        {
                        }
                    }
                    dr.Close();
                }
                catch (Exception hata)
                {
                }
            }
            public static void firmaVerileriniGuncelle2()
            {
                //firma tablosu getiriliyor.
                SqlDataReader dr = veri.getDatareader("select * from sorFirmaBilgileri Where firmaid = " + firma2.firmaid + "");
                while (dr.Read())
                {
                    firmaBilgileri2.firmaAdiSoyadi = dr["adi"].ToString() + " " + dr["soyadi"].ToString();
                    firmaBilgileri2.engellimi = dr["engellimi"].ToString();
                    firmaBilgileri2.banka = Convert.ToByte(dr["banka"]);
                    firmaBilgileri2.cari = Convert.ToByte(dr["cari"]);
                    firmaBilgileri2.cekSenet = Convert.ToByte(dr["cekSenet"]);
                    firmaBilgileri2.kasa = Convert.ToByte(dr["kasa"]);
                    firmaBilgileri2.mobil = Convert.ToByte(dr["mobil"]);
                    firmaBilgileri2.personel = Convert.ToByte(dr["personel"]);
                    firmaBilgileri2.satis = Convert.ToByte(dr["satis"]);
                    firmaBilgileri2.stok = Convert.ToByte(dr["stok"]);

                    veriCE.cmd("Delete from tblFirmaBilgileri where firmaid = " + firma2.firmaid + "");
                    veriCE.cmd("Insert into tblFirmaBilgileri(firmaid, firmaAdiSoyadi, demomu, kalanGun, programAdi, kullaniciid, kullaniciAdi, sifre, subeid, mobilGirisizni) values(" + firma2.firmaid + ", '" + firmaBilgileri2.firmaAdiSoyadi + "', '" + firma2.demomu + "', " + firma2.demoKalanGun + ", '" + firma2.programAdi + "', " + firma2.kullaniciid + ", '" + firma2.kullaniciAdi + "', '" + firma2.sifre + "', " + firma2.subeid + ", " + firmaBilgileri2.mobil + ") ");
                }


            }
            public static void subeVerileriniGuncelle2()
            {
                //Şube tablosu getiriliyor.
                SqlDataReader dr = veri.getDatareader("select * from sorFirmaSubeleri Where subeid = " + firma.subeid + " and firmaid = " + firma.firmaid + "");
                while (dr.Read())
                {
                    subeBilgileri2.subeAdi = dr["subeAdi"].ToString();
                    subeBilgileri2.adres = dr["adres"].ToString();
                    subeBilgileri2.tel = dr["tel"].ToString();
                    subeBilgileri2.gsm = dr["gsm"].ToString();
                    subeBilgileri2.fax = dr["fax"].ToString();
                    veriCE.cmd("Update tblFirmaBilgileri set subeAdi = '" + subeBilgileri2.subeAdi + "', subeAdresi = '" + subeBilgileri2.adres + " " + dr["bolgeAdi"].ToString() + "', tel = '" + subeBilgileri2.tel + "', gsm = '" + subeBilgileri2.gsm + "', fax = '" + subeBilgileri2.fax + "'");
                }
                dr.Close();
            }
            public static void stokkartVerileriniGuncelle2()
            {
                //Stokkartları getiriliyor.
                veriCE.cmd("Delete from tblStokkart where firmaid = " + firma2.firmaid + " and servereYuklendimi = '1' ");
                SqlDataReader dr = veri.getDatareader("select stokid,stokkodu,rfidEtiketi,urunAdi,alisFiyat,kdv,kdvTipi,katNo, (Select sum(miktar*katsayi) from tblTicaret where stokid =  sorStokkart.stokid and silindimi = '0' and subeid = " + firma2.subeid + " and firmaid = " + firma2.firmaid + ") As canliStok, aktifmi, firmaid, subeid, kullaniciid from sorStokkart Where silindimi = '0' and  firmaid = " + firma2.firmaid + "");
                while (dr.Read())
                {
                    veriCE.cmd("Insert into tblStokkart(stokid, stokkodu, rfidEtiketi, urunAdi, alisFiyat, satisFiyat, kdv, kdvTipi, katNo, canliStok, aktifmi, firmaid, subeid, kullaniciid, servereYuklendimi, _stokid) Values(" + dr["stokid"] + ", '" + dr["stokkodu"] + "', '" + dr["rfidEtiketi"] + "', '" + dr["urunAdi"] + "', " + dr["alisFiyat"].ToString().Replace(",", ".") + ", 0, " + dr["kdv"] + ", '" + dr["kdvTipi"] + "', '" + dr["katNo"] + "', '" + dr["canliStok"].ToString().Replace(",", ".") + "', '" + dr["aktifmi"] + "', " + dr["firmaid"] + ", " + dr["subeid"] + ", " + dr["kullaniciid"] + ", '1', 0)");
                }
                dr.Close();
                //birimler getiriliyor.
                veriCE.cmd("Delete from tblStokkartBirimleri where firmaid = " + firma2.firmaid + " and servereYuklendimi = '1'");
                SqlDataReader dr2 = veri.getDatareader("select * from sorStokkartBirimleri where firmaid = " + firma2.firmaid + "");
                while (dr2.Read())
                {
                    veriCE.cmd("Insert into tblStokkartBirimleri(stokid, birimid, birimAdi, katsayi, barkod, firmaid, subeid, kullaniciid, servereYuklendimi) values(" + dr2["stokid"] + ", " + dr2["birimid"] + ", '" + dr2["birimAdi"] + "', " + dr2["katsayi"].ToString().Replace(",", ".") + ", '" + dr2["barkod"] + "', " + dr2["firmaid"] + ", " + dr2["subeid"] + ", " + dr2["kullaniciid"] + ", '1')");
                }
                dr2.Close();
                //Stok Fiyatları getiriliyor.
                veriCE.cmd("Delete from tblStokFiyatlari where firmaid = " + firma2.firmaid + " and servereYuklendimi = '1'");
                SqlDataReader dr3 = veri.getDatareader("select * from sorStokkartFiyatlari Where firmaid = " + firma2.firmaid + "");
                while (dr3.Read())
                {
                    veriCE.cmd("Insert into tblStokFiyatlari(stokid, _stokid, fiyatid, fiyatAdi, indirimliFiyat, doviz, firmaid, subeid, kullaniciid, servereYuklendimi) values(" + dr3["stokid"] + ", 0, " + dr3["fiyatid"] + ", '" + dr3["fiyatAdi"] + "', " + dr3["indirimliFiyat"].ToString().Replace(",", ".") + ", '" + dr3["dovizi"] + "', " + dr3["firmaid"] + ", " + dr3["subeid"] + ", " + dr3["kullaniciid"] + ", '1')");
                }
                dr3.Close();
                //Kategoriler Getiriliyor
                veriCE.cmd("Delete from tblKategori where firmaid = " + firma2.firmaid + "");
                SqlDataReader dr4 = veri.getDatareader("select katNo, kategoriAdi, firmaid, subeid, kullaniciid from sorKategori Where firmaid = " + firma2.firmaid + "");
                while (dr4.Read())
                {
                    veriCE.cmd("Insert into tblKategori(katNo, katAdi, firmaid, subeid, kullaniciiid) values('" + dr4["katNo"] + "', '" + dr4["kategoriAdi"] + "', " + dr4["firmaid"] + ", " + dr4["subeid"] + ", " + dr4["kullaniciid"] + ")");
                }
                dr4.Close();
            }
            public static void cariBilgileriVerileriniGuncelle2()
            {
                //CariBilgileri tablosu getiriliyor.
                veriCE.cmd("Delete from tblCariBilgileri where firmaid = " + firma2.firmaid + " and servereYuklendimi = '1'");
                SqlDataReader dr = veri.getDatareader("Select  c.cariid, c.adi, c.soyadi, c.vergiDaire, c.vergiNo, c.rfidKartNo, c.paraBirimi, c.limit, c.hesabaislensinmi, c.firmaid, c.subeid, c.kullaniciid, a.tel, a.gsm, a.fax, a.adres, (Select isnull(sum(bakiye),0) from sorCariBakiye where cariid = c.cariid) as bakiye  from sorCariBilgileri as c left join sorAdresBilgileri as a on c.cariid = a.cariid  Where a.adresid = (Select min(adresid) from sorAdresBilgileri where cariid = c.cariid and a.varsayilanmi = '1') and c.firmaid = " + firma2.firmaid + "");
                while (dr.Read())
                {
                    veriCE.cmd("Insert into tblCariBilgileri(cariid, adi, soyadi, vergiDaire, vergiNo, rfidKartNo, paraBirimi, limit, hesabaislensinmi, tel, gsm, fax, adres, bakiye, bakiyeDurumu, firmaid, subeid, kullaniciid, servereYuklendimi) values(" + dr["cariid"] + ", '" + dr["adi"] + "', '" + dr["soyadi"] + "', '" + dr["vergiDaire"] + "', '" + dr["vergiNo"] + "', '" + dr["rfidKartNo"] + "', '" + dr["paraBirimi"] + "', " + dr["limit"].ToString().Replace(",", ".") + ", '" + dr["hesabaislensinmi"] + "', '" + dr["tel"] + "', '" + dr["gsm"] + "', '" + dr["fax"] + "', '" + dr["adres"] + "', " + dr["bakiye"].ToString().Replace(",", ".") + ", '-', " + dr["firmaid"] + ", " + dr["subeid"] + ", " + dr["kullaniciid"] + ", '1')");
                }
                dr.Close();
                veriCE.cmd("Update tblCariBilgileri set bakiyeDurumu = 'Alacaklı' where bakiye>0");
                veriCE.cmd("Update tblCariBilgileri set bakiyeDurumu = 'Borçlu' where bakiye<0");
                veriCE.cmd("Update tblCariBilgileri set bakiyeDurumu = '' where bakiye=0");
            }
            public static void BankaPosBilgileriniGuncelle()
            {
                //Banka Pos tablosu getiriliyor.
                veriCE.cmd("Delete from [tblBankaPos] where [firmaid] = " + firma.firmaid + "");
                SqlDataReader dr = veri.getDatareader("SELECT [posid],[bankaHesapid] ,[hesapAdi] ,[adi] ,[posAdi] ,[firmaid] ,[subeid] ,[kullaniciid] FROM [ElmarTicariPlus].[dbo].[sorBankaPos] Where [silindimi] = '0' and firmaid = " + firma.firmaid + "");
                while (dr.Read())
                {
                    veriCE.cmd("Insert into [tblBankaPos]([posid],[bankaHesapid] ,[hesapAdi] ,[adi] ,[posAdi] ,[firmaid] ,[subeid] ,[kullaniciid]) values('" + dr["posid"] + "', '" + dr["bankaHesapid"] + "', '" + dr["hesapAdi"] + "', '" + dr["adi"] + "', '" + dr["posAdi"] + "', " + dr["firmaid"] + ", " + dr["subeid"] + ", " + dr["kullaniciid"] + ")");
                }
                dr.Close();
                //Banka Pos Taksit tablosu getiriliyor.
                veriCE.cmd("Delete from [tblBankaPosTaksit] where [firmaid] = " + firma.firmaid + "");
                SqlDataReader dr2 = veri.getDatareader("SELECT [posTaksitid],[posid] ,[adi] ,[posAdi] ,[bankaHesapid] ,[taksitSayisi] ,[aylikOran] ,[firmaid] ,[subeid] ,[kullaniciid] FROM [ElmarTicariPlus].[dbo].[sorBankaPosTaksit_silinenler] where  firmaid = " + firma.firmaid + "");
                while (dr2.Read())
                {
                    veriCE.cmd("Insert into [tblBankaPosTaksit]([posTaksitid],[posid] ,[adi] ,[posAdi] ,[bankaHesapid] ,[taksitSayisi] ,[aylikOran] ,[firmaid] ,[subeid] ,[kullaniciid]) values(" + dr2["posTaksitid"] + ", '" + dr2["posid"] + "', '" + dr2["adi"] + "', '" + dr2["posAdi"] + "', '" + dr2["bankaHesapid"] + "', '" + dr2["taksitSayisi"] + "', '" + dr2["aylikOran"] + "', " + dr2["firmaid"] + ", " + dr2["subeid"] + ", " + dr2["kullaniciid"] + ")");
                }
                dr2.Close();
            }
            public static void tabloOlustur()
            {
                string sorgu = "";
                try
                {
                    sorgu = " CREATE TABLE tblFaturaEl( [ayarid] [int] NULL,[kullaniciid] [int] NULL,[subeid] [int] NULL,[firmaid] [int] NULL,[kagitTipi] [nvarchar](8) NULL,[kagitBoyutu_Genislik] [nvarchar](4) NULL,[kagitBoyutu_Yukseklik] [nvarchar](4) NULL,[firmaBilgileri] [nvarchar](1) NULL,[firmaBilgileri_Genislik] [nvarchar](4) NULL,[firmaBilgileri_Yukseklik] [nvarchar](4) NULL,[firmaBilgileri_X] [nvarchar](4) NULL,[firmaBilgileri_Y] [nvarchar](4) NULL,[firmaBilgileri_YaziBuyuklugu] [tinyint] NULL,[firmaBilgileri_Baslik] [nvarchar](50) NULL,[firmaBilgileri_Kalin] [nvarchar](1) NULL,[cariBilgileri] [nvarchar](1) NULL,[cariBilgileri_Genislik] [nvarchar](4) NULL,[cariBilgileri_Yukseklik] [nvarchar](4) NULL,[cariBilgileri_X] [nvarchar](4) NULL, [cariBilgileri_Y] [nvarchar](4) NULL,[cariBilgileri_YaziBuyuklugu] [tinyint] NULL, [cariBilgileri_Baslik] [nvarchar](50) NULL, [cariBilgileri_Kalin] [nvarchar](1) NULL, [VD] [nvarchar](1) NULL,[VD_Genislik] [nvarchar](4) NULL, [VD_Yukseklik] [nvarchar](4) NULL,[VD_X] [nvarchar](4) NULL,[VD_Y] [nvarchar](4) NULL,[VD_YaziBuyuklugu] [tinyint] NULL,[VD_Baslik] [nvarchar](50) NULL,[VD_Kalin] [nvarchar](1) NULL, [VN] [nvarchar](1) NULL, [VN_Genislik] [nvarchar](4) NULL, [VN_Yukseklik] [nvarchar](4) NULL, [VN_X] [nvarchar](4) NULL, [VN_Y] [nvarchar](4) NULL, [VN_YaziBuyuklugu] [tinyint] NULL, [VN_Baslik] [nvarchar](50) NULL, [VN_Kalin] [nvarchar](1) NULL, [tarih] [nvarchar](1) NULL, [tarih_Genislik] [nvarchar](4) NULL, [tarih_Yukseklik] [nvarchar](4) NULL, [tarih_X] [nvarchar](4) NULL, [tarih_Y] [nvarchar](4) NULL,[tarih_YaziBuyuklugu] [tinyint] NULL, [tarih_Baslik] [nvarchar](50) NULL, [tarih_Kalin] [nvarchar](1) NULL, [urunBilgileri] [nvarchar](1) NULL, [urunBilgileri_Genislik] [nvarchar](4) NULL, [urunBilgileri_Yukseklik] [nvarchar](4) NULL, [urunBilgileri_X] [nvarchar](4) NULL, [urunBilgileri_Y] [nvarchar](4) NULL, [urunBilgileri_YaziBuyuklugu] [tinyint] NULL, [urunBilgileri_Basliklar] [nvarchar](1) NULL,	[urunBilgileri_BaslikUstBoslugu] [nvarchar](4) NULL,[urunBilgileri_UrunAdi_Genislik] [nvarchar](4) NULL,[urunBilgileri_UrunAdi_X] [nvarchar](4) NULL,[urunBilgileri_Adet_Genislik] [nvarchar](4) NULL,[urunBilgileri_Adet_X] [nvarchar](4) NULL,[urunBilgileri_Fiyat_Genislik] [nvarchar](4) NULL,[urunBilgileri_Fiyat_X] [nvarchar](4) NULL,[urunBilgileri_Tutar_Genislik] [nvarchar](4) NULL,[urunBilgileri_Tutar_X] [nvarchar](4) NULL,[toplamlar] [nvarchar](1) NULL,[toplamlar_Genislik] [nvarchar](4) NULL,[toplamlar_Yukseklik] [nvarchar](4) NULL,[toplamlar_X] [nvarchar](4) NULL,[toplamlar_Y] [nvarchar](4) NULL,[toplamlar_YaziBuyuklugu] [tinyint] NULL,[toplamlar_Baslik] [nvarchar](50) NULL,[toplamlar_Kalin] [nvarchar](1) NULL,[aciklama] [nvarchar](1) NULL,[aciklama_Metin] [nvarchar](150) NULL,[aciklama_Genislik] [nvarchar](4) NULL,[aciklama_Yukseklik] [nvarchar](4) NULL,[aciklama_X] [nvarchar](4) NULL,[aciklama_Y] [nvarchar](4) NULL,[aciklama_YaziBuyuklugu] [tinyint] NULL,[aciklama_Kalin] [nvarchar](1) NULL)";
                    veriCE.cmd(sorgu);
                }
                catch (Exception hata)
                {
                }
                try
                {
                    sorgu = "CREATE TABLE [tblBankaPos]([posid] [int] NULL,[bankaHesapid] [int] NULL,[hesapAdi] [nvarchar](50) NULL,[adi] [nvarchar](30) NULL,[posAdi] [nvarchar](30) NULL,[firmaid] [int] NULL,[subeid] [int] NULL,[kullaniciid] [int] NULL)";
                    veriCE.cmd(sorgu);
                }
                catch (Exception hata)
                {
                }
                try
                {
                    sorgu = "CREATE TABLE tblBankaPosTaksit([posTaksitid] [int] NULL,[posid] [int] NULL,[adi] [nvarchar](30) NULL,[posAdi] [nvarchar](30) NULL,[bankaHesapid] [int] NULL,[taksitSayisi] [tinyint] NULL,[aylikOran] [float] NULL,[firmaid] [int] NULL,[subeid] [int] NULL,[kullaniciid] [int] NULL)";
                    veriCE.cmd(sorgu);
                }
                catch (Exception hata)
                {
                }
                try
                {
                    sorgu = "CREATE TABLE [tblBankaislemleri]([bankaislemid] [int] NULL,[_bankaislemid] [int] NULL,[bankaHesapid] [int] NULL,[krediKartid] [int] NULL,[posid] [int] NULL,[taksitSayisi] [nvarchar](5) NULL,[aylikTaksitTutari] [float] NULL,[cekSenetid] [int] NULL,[_cekSenetid] [int] NULL,[cariBankaHesapid] [int] NULL,[cariKrediKartid] [int] NULL,[cariid] [int] NULL,[_cariid] [int] NULL,[tutar] [float] NULL,[doviz] [nvarchar](5) NULL,[dovizKuru] [float] NULL,[ayrinti] [nvarchar](250) NULL,[islemTuru] [nvarchar](50) NULL,[islemTarihi] [datetime] NULL,[firmaid] [int] NULL,[subeid] [int] NULL,[kullaniciid] [int] NULL,[servereYuklendimi] [nvarchar](1) NULL)";
                    veriCE.cmd(sorgu);
                }
                catch (Exception hata)
                {
                }
                try
                {
                    veriCE.cmd("ALTER TABLE [tblAcikHesap] ADD COLUMN [bankaislemid] [int];");
                    veriCE.cmd("ALTER TABLE [tblAcikHesap] ADD COLUMN [yeri] [nvarchar](5);");
                }
                catch (Exception hata)
                {
                }
                try
                {
                    veriCE.cmd("ALTER TABLE [tblTicaret] ADD COLUMN [isk1] [float];");
                }
                catch (Exception hata)
                {
                }
                try
                {
                    veriCE.cmd("ALTER TABLE [tblTicaretAyrinti] ADD COLUMN [yuzdeisk] [float];");
                }
                catch (Exception hata)
                {
                }
            }
            public static void yazdirmaKoordinatlariniGuncelle()
            {
                //Yazdırma kordinat tablosu getiriliyor.
                veriCE.cmd("Delete from tblFaturaEl where kullaniciid = " + firma.kullaniciid + "");
                SqlDataReader dr = veri.getDatareader("SELECT [ayarid], [kullaniciid],[subeid],[firmaid],[kagitTipi],[kagitBoyutu_Genislik],[kagitBoyutu_Yukseklik],[firmaBilgileri],[firmaBilgileri_Genislik],[firmaBilgileri_Yukseklik],[firmaBilgileri_X],[firmaBilgileri_Y],[firmaBilgileri_YaziBuyuklugu],[firmaBilgileri_Baslik],[firmaBilgileri_Kalin],[cariBilgileri],[cariBilgileri_Genislik],[cariBilgileri_Yukseklik],[cariBilgileri_X],[cariBilgileri_Y],[cariBilgileri_YaziBuyuklugu],[cariBilgileri_Baslik],[cariBilgileri_Kalin],[VD],[VD_Genislik],[VD_Yukseklik],[VD_X],[VD_Y],[VD_YaziBuyuklugu],[VD_Baslik],[VD_Kalin],[VN],[VN_Genislik],[VN_Yukseklik],[VN_X],[VN_Y],[VN_YaziBuyuklugu],[VN_Baslik] ,[VN_Kalin] ,[tarih] ,[tarih_Genislik] ,[tarih_Yukseklik] ,[tarih_X] ,[tarih_Y] ,[tarih_YaziBuyuklugu] ,[tarih_Baslik] ,[tarih_Kalin] ,[urunBilgileri] ,[urunBilgileri_Genislik] ,[urunBilgileri_Yukseklik] ,[urunBilgileri_X] ,[urunBilgileri_Y] ,[urunBilgileri_YaziBuyuklugu] ,[urunBilgileri_Basliklar] ,[urunBilgileri_BaslikUstBoslugu] ,[urunBilgileri_UrunAdi_Genislik] ,[urunBilgileri_UrunAdi_X] ,[urunBilgileri_Adet_Genislik] ,[urunBilgileri_Adet_X] ,[urunBilgileri_Fiyat_Genislik] ,[urunBilgileri_Fiyat_X] ,[urunBilgileri_Tutar_Genislik] ,[urunBilgileri_Tutar_X] ,[toplamlar] ,[toplamlar_Genislik] ,[toplamlar_Yukseklik] ,[toplamlar_X] ,[toplamlar_Y] ,[toplamlar_YaziBuyuklugu] ,[toplamlar_Baslik] ,[toplamlar_Kalin] ,[aciklama] ,[aciklama_Metin] ,[aciklama_Genislik] ,[aciklama_Yukseklik] ,[aciklama_X] ,[aciklama_Y] ,[aciklama_YaziBuyuklugu] ,[aciklama_Kalin] FROM tblSicakSatisFaturaOlustur where kullaniciid = " + firma.kullaniciid + " order by kagitTipi asc");
                while (dr.Read())
                {
                    veriCE.cmd("INSERT INTO tblFaturaEl ([kullaniciid],[subeid],[firmaid],[kagitTipi],[kagitBoyutu_Genislik],[kagitBoyutu_Yukseklik],[firmaBilgileri],[firmaBilgileri_Genislik],[firmaBilgileri_Yukseklik],[firmaBilgileri_X],[firmaBilgileri_Y],[firmaBilgileri_YaziBuyuklugu],[firmaBilgileri_Baslik],[firmaBilgileri_Kalin],[cariBilgileri],[cariBilgileri_Genislik],[cariBilgileri_Yukseklik],[cariBilgileri_X],[cariBilgileri_Y],[cariBilgileri_YaziBuyuklugu],[cariBilgileri_Baslik],[cariBilgileri_Kalin],[VD],[VD_Genislik],[VD_Yukseklik],[VD_X],[VD_Y],[VD_YaziBuyuklugu],[VD_Baslik],[VD_Kalin],[VN],[VN_Genislik],[VN_Yukseklik],[VN_X],[VN_Y],[VN_YaziBuyuklugu],[VN_Baslik],[VN_Kalin],[tarih],[tarih_Genislik],[tarih_Yukseklik],[tarih_X],[tarih_Y],[tarih_YaziBuyuklugu],[tarih_Baslik],[tarih_Kalin],[urunBilgileri],[urunBilgileri_Genislik],[urunBilgileri_Yukseklik],[urunBilgileri_X],[urunBilgileri_Y],[urunBilgileri_YaziBuyuklugu],[urunBilgileri_Basliklar],[urunBilgileri_BaslikUstBoslugu],[urunBilgileri_UrunAdi_Genislik],[urunBilgileri_UrunAdi_X],[urunBilgileri_Adet_Genislik],[urunBilgileri_Adet_X],[urunBilgileri_Fiyat_Genislik],[urunBilgileri_Fiyat_X],[urunBilgileri_Tutar_Genislik],[urunBilgileri_Tutar_X],[toplamlar],[toplamlar_Genislik],[toplamlar_Yukseklik],[toplamlar_X],[toplamlar_Y],[toplamlar_YaziBuyuklugu],[toplamlar_Baslik],[toplamlar_Kalin],[aciklama],[aciklama_Metin],[aciklama_Genislik],[aciklama_Yukseklik],[aciklama_X],[aciklama_Y],[aciklama_YaziBuyuklugu],[aciklama_Kalin])  Values('" + dr["kullaniciid"].ToString() + "', '" + dr["subeid"].ToString() + "', '" + dr["firmaid"].ToString() + "', '" + dr["kagitTipi"].ToString() + "', '" + dr["kagitBoyutu_Genislik"].ToString() + "', '" + dr["kagitBoyutu_Yukseklik"].ToString() + "', '" + dr["firmaBilgileri"].ToString() + "', '" + dr["firmaBilgileri_Genislik"].ToString() + "', '" + dr["firmaBilgileri_Yukseklik"].ToString() + "', '" + dr["firmaBilgileri_X"].ToString() + "', '" + dr["firmaBilgileri_Y"].ToString() + "', '" + dr["firmaBilgileri_YaziBuyuklugu"].ToString() + "', '" + dr["firmaBilgileri_Baslik"].ToString() + "', '" + dr["firmaBilgileri_Kalin"].ToString() + "', '" + dr["cariBilgileri"].ToString() + "', '" + dr["cariBilgileri_Genislik"].ToString() + "', '" + dr["cariBilgileri_Yukseklik"].ToString() + "', '" + dr["cariBilgileri_X"].ToString() + "', '" + dr["cariBilgileri_Y"].ToString() + "', '" + dr["cariBilgileri_YaziBuyuklugu"].ToString() + "', '" + dr["cariBilgileri_Baslik"].ToString() + "', '" + dr["cariBilgileri_Kalin"].ToString() + "', '" + dr["VD"].ToString() + "', '" + dr["VD_Genislik"].ToString() + "', '" + dr["VD_Yukseklik"].ToString() + "', '" + dr["VD_X"].ToString() + "', '" + dr["VD_Y"].ToString() + "', '" + dr["VD_YaziBuyuklugu"].ToString() + "', '" + dr["VD_Baslik"].ToString() + "', '" + dr["VD_Kalin"].ToString() + "', '" + dr["VN"].ToString() + "', '" + dr["VN_Genislik"].ToString() + "', '" + dr["VN_Yukseklik"].ToString() + "', '" + dr["VN_X"].ToString() + "', '" + dr["VN_Y"].ToString() + "', '" + dr["VN_YaziBuyuklugu"].ToString() + "', '" + dr["VN_Baslik"].ToString() + "', '" + dr["VN_Kalin"].ToString() + "', '" + dr["tarih"].ToString() + "', '" + dr["tarih_Genislik"].ToString() + "', '" + dr["tarih_Yukseklik"].ToString() + "', '" + dr["tarih_X"].ToString() + "', '" + dr["tarih_Y"].ToString() + "', '" + dr["tarih_YaziBuyuklugu"].ToString() + "', '" + dr["tarih_Baslik"].ToString() + "', '" + dr["tarih_Kalin"].ToString() + "', '" + dr["urunBilgileri"].ToString() + "', '" + dr["urunBilgileri_Genislik"].ToString() + "', '" + dr["urunBilgileri_Yukseklik"].ToString() + "', '" + dr["urunBilgileri_X"].ToString() + "', '" + dr["urunBilgileri_Y"].ToString() + "', '" + dr["urunBilgileri_YaziBuyuklugu"].ToString() + "', '" + dr["urunBilgileri_Basliklar"].ToString() + "', '" + dr["urunBilgileri_BaslikUstBoslugu"].ToString() + "', '" + dr["urunBilgileri_UrunAdi_Genislik"].ToString() + "', '" + dr["urunBilgileri_UrunAdi_X"].ToString() + "', '" + dr["urunBilgileri_Adet_Genislik"].ToString() + "', '" + dr["urunBilgileri_Adet_X"].ToString() + "', '" + dr["urunBilgileri_Fiyat_Genislik"].ToString() + "', '" + dr["urunBilgileri_Fiyat_X"].ToString() + "', '" + dr["urunBilgileri_Tutar_Genislik"].ToString() + "', '" + dr["urunBilgileri_Tutar_X"].ToString() + "', '" + dr["toplamlar"].ToString() + "', '" + dr["toplamlar_Genislik"].ToString() + "', '" + dr["toplamlar_Yukseklik"].ToString() + "', '" + dr["toplamlar_X"].ToString() + "', '" + dr["toplamlar_Y"].ToString() + "', '" + dr["toplamlar_YaziBuyuklugu"].ToString() + "', '" + dr["toplamlar_Baslik"].ToString() + "', '" + dr["toplamlar_Kalin"].ToString() + "', '" + dr["aciklama"].ToString() + "', '" + dr["aciklama_Metin"].ToString() + "', '" + dr["aciklama_Genislik"].ToString() + "', '" + dr["aciklama_Yukseklik"].ToString() + "', '" + dr["aciklama_X"].ToString() + "', '" + dr["aciklama_Y"].ToString() + "', '" + dr["aciklama_YaziBuyuklugu"].ToString() + "', '" + dr["aciklama_Kalin"].ToString() + "')");
                }
                dr.Close();
            }
        }

    
}
