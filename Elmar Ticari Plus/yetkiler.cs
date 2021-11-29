using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using elmarLibrary;
using System.Windows.Forms;
namespace Elmar_Ticari_Plus
{
    class yetkiler
    {
        public static bool Alacak_Borç_Raporlari = true;
        public static bool Alış_İade = true;
        public static bool Ayrıntılı_Kasa = true;
        public static bool Banka_Ana_Menüsü = true;
        public static bool Banka_Ekle_Düzenle_Sil = true;
        public static bool Banka_Hesabı_Düzenle = true;
        public static bool Banka_Hesabı_Ekle = true;
        public static bool Banka_Hesabı_Sil = true;
        public static bool Canlı_Stok_Görüntüle = true;
        public static bool Cari_Ana_Menüsü = true;
        public static bool Cari_Düzenle = true;
        public static bool Cari_Ekle = true;
        public static bool Cari_Hesabını_Durdurma = true;
        public static bool Cari_Sil = true;
        public static bool Cari_Ürün_Raporları = true;
        public static bool Çek_Senet_Ana_Menüsü = true;
        public static bool Çek_Senet_Cirola = true;
        public static bool Çek_Senet_Düzenleme_İşlemleri = true;
        public static bool Çek_Senet_Ekleme_İşlemleri = true;
        public static bool Çek_Senet_Raporu_Görüntüle = true;
        public static bool Çek_Senet_Silme_İşlemleri = true;
        public static bool Devir_İşlemi = true;
        public static bool Diğer_Cari_Raporlarına_Erişim = true;
        public static bool Ekstre_Raporu_Silme = true;
        public static bool Fatura_Tanımlamaları = true;
        public static bool Faturalı_Alış = true;
        public static bool Faturalı_Satış = true;
        public static bool Faturasız_Alış = true;
        public static bool Faturasız_Satış = true;
        public static bool Firma_ve_Şube_Tanıml_ = true;
        public static bool Gelen_EFT = true;
        public static bool Gelen_Havale = true;
        public static bool Giden_EFT = true;
        public static bool Giden_Havale = true;
        public static bool Görev_Düzenle = true;
        public static bool Görev_Ekle = true;
        public static bool Görev_Sil = true;
        public static bool Günlük_Kasa = true;
        public static bool İşe_başlat___İşten_Çıkar = true;
        public static bool Kasa_Ana_Menüsü = true;
        public static bool Kasa_İşlemleri = true;
        public static bool Kasa_Tanımlamaları = true;
        public static bool Kendi_Çekim = true;
        public static bool Kendi_Senedim = true;
        public static bool Kredi_Kartı_Düzenle = true;
        public static bool Kredi_Kartı_Ekle = true;
        public static bool Kredi_Kartı_ile_Ödeme = true;
        public static bool Kredi_Kartı_Sil = true;
        public static bool Maaş_Bordrosu = true;
        public static bool Maaş_Düzenle = true;
        public static bool Maaş_Ekle = true;
        public static bool Maaş_Sil = true;
        public static bool Mail_Gönder = true;
        public static bool Masraf_Kartı_Düzenle = true;
        public static bool Masraf_Kartı_Ekle = true;
        public static bool Masraf_Kartı_Görüntüle = true;
        public static bool Masraf_Kartı_Sil = true;
        public static bool Mesajlar_Ana_Menüsü = true;
        public static bool Müşteri_Çeki = true;
        public static bool Müşteri_Senedi = true;
        public static bool Nakit_Tahsilat_ve_Ödeme = true;
        public static bool Para_Transferi = true;
        public static bool Para_Yatır___Para_Çek = true;
        public static bool Personel_Ana_Menüsü = true;
        public static bool Personel_Düzenle = true;
        public static bool Personel_Ekle = true;
        public static bool Personel_Kartı_İşlemleri = true;
        public static bool Personel_Sil = true;
        public static bool Pos_Düzenle = true;
        public static bool Pos_Ekle = true;
        public static bool Pos_ile_Tahsilat = true;
        public static bool Pos_Sil = true;
        public static bool Prim_İşlemleri = true;
        public static bool Rapor_Düzenle = true;
        public static bool Rapor_Görüntüle = true;
        public static bool Rapor_Sil = true;
        public static bool RFID_Kart_İşlemleri = true;
        public static bool Satış_Ana_Menüsü = true;
        public static bool Satış_İade = true;
        public static bool Satış_Raporu_Düzenle = true;
        public static bool Satış_Raporu_Görüntüle = true;
        public static bool Satış_Raporu_Sil = true;
        public static bool Satış_Tanımlamaları = true;
        public static bool Sipariş_Düzenle = true;
        public static bool Sipariş_Ekle = true;
        public static bool Sipariş_Sil = true;
        public static bool Stok_Ana_Menüsü = true;
        public static bool Stok_Kart_Düzenle = true;
        public static bool Stok_Kart_Ekle = true;
        public static bool Stok_Kart_Sil = true;
        public static bool Stok_Raporu_Düzenle = true;
        public static bool Stok_Raporu_Görüntüle = true;
        public static bool Stok_Raporu_Sil = true;
        public static bool Stok_Tanımlamaları = true;
        public static bool Tahsilat_Ödeme_Raporları = true;
        public static bool Taksit_Tahsil_Et___Öde = true;
        public static bool Taksit_Tanımla = true;
        public static bool Tanımlar_Ana_Menüsü = true;
        public static bool Teklif_Düzenle = true;
        public static bool Teklif_Ekle = true;
        public static bool Teklif_Sil = true;
        public static bool Teklif_Sipariş_Ana_Menüsü = true;
        public static bool Ürün_Transferi = true;
        public static bool Virman_İşlemi = true;
        public static bool Virman = true;
        public static bool Web_Sitesi_İşlemleri = true;
        public static bool Yetkiler_Ana_Menüsü = true;      
        public static void yetkileriGuncelle()
        {
            try
            {
                SqlDataReader dr = veri.getDatareader("select yetkiAdi, degeri from tblFirmaKullaniciYetkileri where kullaniciid = " + firma.kullaniciid + " and ortam = 'Ticari Program'");
                while (dr.Read())
                {
                    try
                    {
                        if (dr["yetkiAdi"].ToString() == "Alacak-Borç Raporlari") Alacak_Borç_Raporlari = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Alış İade") Alış_İade = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Ayrıntılı Kasa") Ayrıntılı_Kasa = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Banka Ana Menüsü") Banka_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Banka Ekle Düzenle Sil") Banka_Ekle_Düzenle_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Banka Hesabı Düzenle") Banka_Hesabı_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Banka Hesabı Ekle") Banka_Hesabı_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Banka Hesabı Sil") Banka_Hesabı_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Canlı Stok Görüntüle") Canlı_Stok_Görüntüle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Cari Ana Menüsü") Cari_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Cari Düzenle") Cari_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Cari Ekle") Cari_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Cari Hesabını Durdurma") Cari_Hesabını_Durdurma = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Cari Sil") Cari_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Cari Ürün Raporları") Cari_Ürün_Raporları = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Çek-Senet Ana Menüsü") Çek_Senet_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Çek-Senet Cirola") Çek_Senet_Cirola = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Çek-Senet Düzenleme İşlemleri") Çek_Senet_Düzenleme_İşlemleri = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Çek-Senet Ekleme İşlemleri") Çek_Senet_Ekleme_İşlemleri = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Çek-Senet Raporu Görüntüle") Çek_Senet_Raporu_Görüntüle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Çek-Senet Silme İşlemleri") Çek_Senet_Silme_İşlemleri = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Devir İşlemi") Devir_İşlemi = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Diğer Cari Raporlarına Erişim") Diğer_Cari_Raporlarına_Erişim = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Ekstre Raporu Silme") Ekstre_Raporu_Silme = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Fatura Tanımlamaları") Fatura_Tanımlamaları = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Faturalı Alış") Faturalı_Alış = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Faturalı Satış") Faturalı_Satış = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Faturasız Alış") Faturasız_Alış = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Faturasız Satış") Faturasız_Satış = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Firma ve Şube Tanıml.") Firma_ve_Şube_Tanıml_ = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Gelen EFT") Gelen_EFT = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Gelen Havale") Gelen_Havale = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Giden EFT") Giden_EFT = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Giden Havale") Giden_Havale = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Görev Düzenle") Görev_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Görev Ekle") Görev_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Görev Sil") Görev_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Günlük Kasa") Günlük_Kasa = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "İşe başlat / İşten Çıkar") İşe_başlat___İşten_Çıkar = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kasa Ana Menüsü") Kasa_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kasa İşlemleri") Kasa_İşlemleri = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kasa Tanımlamaları") Kasa_Tanımlamaları = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kendi Çekim") Kendi_Çekim = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kendi Senedim") Kendi_Senedim = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kredi Kartı Düzenle") Kredi_Kartı_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kredi Kartı Ekle") Kredi_Kartı_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kredi Kartı ile Ödeme") Kredi_Kartı_ile_Ödeme = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Kredi Kartı Sil") Kredi_Kartı_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Maaş Bordrosu") Maaş_Bordrosu = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Maaş Düzenle") Maaş_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Maaş Ekle") Maaş_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Maaş Sil") Maaş_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Mail Gönder") Mail_Gönder = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Masraf Kartı Düzenle") Masraf_Kartı_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Masraf Kartı Ekle") Masraf_Kartı_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Masraf Kartı Görüntüle") Masraf_Kartı_Görüntüle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Masraf Kartı Sil") Masraf_Kartı_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Mesajlar Ana Menüsü") Mesajlar_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Müşteri Çeki") Müşteri_Çeki = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Müşteri Senedi") Müşteri_Senedi = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Nakit Tahsilat ve Ödeme") Nakit_Tahsilat_ve_Ödeme = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Para Transferi") Para_Transferi = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Para Yatır / Para Çek") Para_Yatır___Para_Çek = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Personel Ana Menüsü") Personel_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Personel Düzenle") Personel_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Personel Ekle") Personel_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Personel Kartı İşlemleri") Personel_Kartı_İşlemleri = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Personel Sil") Personel_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Pos Düzenle") Pos_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Pos Ekle") Pos_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Pos ile Tahsilat") Pos_ile_Tahsilat = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Pos Sil") Pos_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Prim İşlemleri") Prim_İşlemleri = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Rapor Düzenle") Rapor_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Rapor Görüntüle") Rapor_Görüntüle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Rapor Sil") Rapor_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "RFID Kart İşlemleri") RFID_Kart_İşlemleri = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Satış Ana Menüsü") Satış_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Satış İade") Satış_İade = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Satış Raporu Düzenle") Satış_Raporu_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Satış Raporu Görüntüle") Satış_Raporu_Görüntüle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Satış Raporu Sil") Satış_Raporu_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Satış Tanımlamaları") Satış_Tanımlamaları = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Sipariş Düzenle") Sipariş_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Sipariş Ekle") Sipariş_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Sipariş Sil") Sipariş_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Stok Ana Menüsü") Stok_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Stok Kart Düzenle") Stok_Kart_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Stok Kart Ekle") Stok_Kart_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Stok Kart Sil") Stok_Kart_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Stok Raporu Düzenle") Stok_Raporu_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Stok Raporu Görüntüle") Stok_Raporu_Görüntüle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Stok Raporu Sil") Stok_Raporu_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Stok Tanımlamaları") Stok_Tanımlamaları = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Tahsilat-Ödeme Raporları") Tahsilat_Ödeme_Raporları = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Taksit Tahsil Et / Öde") Taksit_Tahsil_Et___Öde = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Taksit Tanımla") Taksit_Tanımla = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Tanımlar Ana Menüsü") Tanımlar_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Teklif Düzenle") Teklif_Düzenle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Teklif Ekle") Teklif_Ekle = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Teklif Sil") Teklif_Sil = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Teklif-Sipariş Ana Menüsü") Teklif_Sipariş_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Ürün Transferi") Ürün_Transferi = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Virman İşlemi") Virman_İşlemi = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Virman") Virman = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Web Sitesi İşlemleri") Web_Sitesi_İşlemleri = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        else if (dr["yetkiAdi"].ToString() == "Yetkiler Ana Menüsü") Yetkiler_Ana_Menüsü = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));

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
        public static void mesajVer()
        {
            MessageBox.Show("Bu işlemi yapmak için yetkili değilsiniz.", firma.programAdi, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
