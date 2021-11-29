using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public static class ayarlar
    {
        private static string _Faturasız_Satış_Fiyatı="0";
        public static string Faturasız_Satış_Fiyatı
        { 
            get
            {
            
                return _Faturasız_Satış_Fiyatı;
            }
            set
            {
            
                _Faturasız_Satış_Fiyatı = value;
            
            }
        }
        public static string Faturalı_Satış_Fiyatı = "0";
        public static string İade_Satış_Fiyatı = "0";
        public static string Teklif_Fiyatı = "0";
        public static string Faturasız_Satış_Stok_Kontrolleri_Tipi = "2";
        public static string Faturalı_Satış_Stok_Kontrol_Tipi = "2";
        public static string Faturasız_Satış_Yazıcı = "";
        public static string Faturalı_Satış_Yazıcı = "";
        public static string İade_Satış_Yazıcı = "";
        public static string Faturasız_Alış_Yazıcı = "";
        public static string Faturalı_Alış_Yazıcı = "";
        public static string İade_Alış_Yazıcı = "";
        public static string Teklif_Yazıcı = "";
        public static string Sipariş_Yazıcı = "";
        public static string Faturasız_Satış_Kağıt_Tipi = "Çıktı 1";
        public static string Faturalı_Satış_Kağıt_Tipi = "Çıktı 1";
        public static string İade_Satış_Kağıt_Tipi = "Çıktı 1";
        public static string Faturasız_Alış_Kağıt_Tipi = "Çıktı 1";
        public static string Faturalı_Alış_Kağıt_Tipi = "Çıktı 1";
        public static string İade_Alış_Kağıt_Tipi = "Çıktı 1";
        public static string Teklif_Kağıt_Tipi = "Çıktı 1";
        public static string Sipariş_Kağıt_Tipi = "Çıktı 1";
        public static string Faturasız_Satış_Oto_Yazdır = "0";
        public static string Faturasız_Satış_Miktar_Otomatik = "1";
        public static string Faturasız_Satış_Kartlı_Satış = "0";
        public static string Faturalı_Satış_Oto_Yazdır = "0";
        public static string Faturalı_Satış_Miktar_Otomatik = "1";
        public static string Faturalı_Satış_Kartlı_Satış = "0";
        public static string İade_Satış_Oto_Yazdır = "0";
        public static string İade_Satış_Miktar_Otomatik = "1";
        public static string İade_Satış_Kartlı_Satış = "0";
        public static string Faturasız_Alış_Oto_Yazdır = "0";
        public static string Faturasız_Alış_Miktar_Otomatik = "1";
        public static string Faturasız_Alış_Kartlı_Satış = "0";
        public static string Faturalı_Alış_Oto_Yazdır = "0";
        public static string Faturalı_Alış_Miktar_Otomatik = "1";
        public static string Faturalı_Alış_Kartlı_Satış = "0";
        public static string İade_Alış_Oto_Yazdır = "0";
        public static string İade_Alış_Miktar_Otomatik = "1";
        public static string İade_Alış_Kartlı_Satış = "0";
        public static string fis_kagit_genislik = "80";
        public static string fis_kagit_sol_bosluk = "5";
        public static string fis_kagit_ust_bosluk = "5";
        public static string Transfer_Stok_Kontrolleri_Tipi = "2";
        public static string Transfer_Satış_Fiyatı = "0";
        public static string Transfer_Yazıcı = "";
        public static string Transfer_Kağıt_Tipi = "Çıktı 1";
        public static string Transfer_Oto_Yazdır = "0";
        public static string Transfer_Satış_Miktar_Otomatik = "1";
        public static string Transfer_Satış_Kartlı_Satış = "0";
        public static string Faturasız_Satış_Liste = "011110111100011100";
        public static string Transfer_Liste = "011110111100011100";
        public static string Faturalı_Satış_Liste = "011110111100011100";
        public static string İade_Satış_Liste = "011110111100011100";
        public static string Faturasız_Alış_Liste = "011110111100011100";
        public static string Faturalı_Alış_Liste = "011110111100011100";
        public static string İade_Alış_Liste = "011110111100011100";
        public static string Teklif_Liste = "011110111100011100";
        public static string Sipariş_Liste = "011110111100011100";
        //terazi
        public static string Terazi_Portu = "COM3";
        public static string Auto_Terazi= "0";
        public static string Display= "0";
        public static string Agirlik = "0";
        public static string Terazi_Adi = "0";
        public static void ayarlariGuncelle()
        {
            try
            {
                SqlDataReader dr = veri.getDatareader("select ayarAdi, degeri from tblFirmaKullaniciAyarlari where kullaniciid = " + firma.kullaniciid + " and ortam = 'Ticari Program'");
                while (dr.Read())
                {
                    try
                    {
                        if (dr["ayarAdi"].ToString() == "Faturasız_Satış_Fiyatı") Faturasız_Satış_Fiyatı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Satış_Fiyatı") Faturalı_Satış_Fiyatı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Satış_Fiyatı") İade_Satış_Fiyatı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Teklif_Fiyatı") Teklif_Fiyatı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Satış_Stok_Kontrolleri_Tipi") Faturasız_Satış_Stok_Kontrolleri_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Satış_Stok_Kontrol_Tipi") Faturalı_Satış_Stok_Kontrol_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Satış_Yazıcı") Faturasız_Satış_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Satış_Yazıcı") Faturalı_Satış_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Satış_Yazıcı") İade_Satış_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Alış_Yazıcı") Faturasız_Alış_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Alış_Yazıcı") Faturalı_Alış_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Alış_Yazıcı") İade_Alış_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Teklif_Yazıcı") Teklif_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Sipariş_Yazıcı") Sipariş_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Satış_Kağıt_Tipi") Faturasız_Satış_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Satış_Kağıt_Tipi") Faturalı_Satış_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Satış_Kağıt_Tipi") İade_Satış_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Alış_Kağıt_Tipi") Faturasız_Alış_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Alış_Kağıt_Tipi") Faturalı_Alış_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Alış_Kağıt_Tipi") İade_Alış_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Teklif_Kağıt_Tipi") Teklif_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Sipariş_Kağıt_Tipi") Sipariş_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Satış_Oto_Yazdır") Faturasız_Satış_Oto_Yazdır = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Satış_Miktar_Otomatik") Faturasız_Satış_Miktar_Otomatik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Satış_Kartlı_Satış") Faturasız_Satış_Kartlı_Satış = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Satış_Oto_Yazdır") Faturalı_Satış_Oto_Yazdır = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Satış_Miktar_Otomatik") Faturalı_Satış_Miktar_Otomatik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Satış_Kartlı_Satış") Faturalı_Satış_Kartlı_Satış = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Satış_Oto_Yazdır") İade_Satış_Oto_Yazdır = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Satış_Miktar_Otomatik") İade_Satış_Miktar_Otomatik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Satış_Kartlı_Satış") İade_Satış_Kartlı_Satış = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Alış_Oto_Yazdır") Faturasız_Alış_Oto_Yazdır = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Alış_Miktar_Otomatik") Faturasız_Alış_Miktar_Otomatik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Alış_Kartlı_Satış") Faturasız_Alış_Kartlı_Satış = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Alış_Oto_Yazdır") Faturalı_Alış_Oto_Yazdır = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Alış_Miktar_Otomatik") Faturalı_Alış_Miktar_Otomatik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Alış_Kartlı_Satış") Faturalı_Alış_Kartlı_Satış = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Alış_Oto_Yazdır") İade_Alış_Oto_Yazdır = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Alış_Miktar_Otomatik") İade_Alış_Miktar_Otomatik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Alış_Kartlı_Satış") İade_Alış_Kartlı_Satış = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "fis_kagit_genislik") fis_kagit_genislik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "fis_kagit_sol_bosluk") fis_kagit_sol_bosluk = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "fis_kagit_ust_bosluk") fis_kagit_ust_bosluk = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Transfer_Stok_Kontrolleri_Tipi") Transfer_Stok_Kontrolleri_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Transfer_Satış_Fiyatı") Transfer_Satış_Fiyatı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Transfer_Yazıcı") Transfer_Yazıcı = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Transfer_Kağıt_Tipi") Transfer_Kağıt_Tipi = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Transfer_Oto_Yazdır") Transfer_Oto_Yazdır = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Transfer_Satış_Miktar_Otomatik") Transfer_Satış_Miktar_Otomatik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Transfer_Satış_Kartlı_Satış") Transfer_Satış_Kartlı_Satış = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Satış_Liste") Faturasız_Satış_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Transfer_Liste") Transfer_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Satış_Liste") Faturalı_Satış_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Satış_Liste") İade_Satış_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturasız_Alış_Liste") Faturasız_Alış_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Faturalı_Alış_Liste") Faturalı_Alış_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "İade_Alış_Liste") İade_Alış_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Teklif_Liste") Teklif_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Sipariş_Liste") Sipariş_Liste = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Auto Terazi") Auto_Terazi= dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Display") Display= dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Ağırlık") Agirlik = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Terazi_Portu") Terazi_Portu = dr["degeri"].ToString();
                        else if (dr["ayarAdi"].ToString() == "Terazi_Adi") Terazi_Adi = dr["degeri"].ToString();
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception hata)
            {
            }
        }
        static Thread kanal;
        public static void ayarla_manuel(string ayarAdi, string deger)
        {
            try
            {
                veri.cmd("update  tblFirmaKullaniciAyarlari set degeri = '" + deger + "' where kullaniciid = " + firma.kullaniciid + " and ortam = 'Ticari Program' and ayarAdi = '" + ayarAdi + "'");
                kanal = new Thread(new ThreadStart(ayarlariGuncelle));
                kanal.Start();
            }
            catch (Exception hata)
            {
            }
        }
    }
}
