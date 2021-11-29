using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Elmar_Ticari_Plus
{
    class SmsYetkileri
    {      
        public static bool Faturalı_Satıs = true;
        public static bool Faturasiz_Satis = true;
        public static bool Urun_İndirimleri = true;
        public static bool Cari_Borc_Hatırlatma = true;
        public static bool Bayram_Mesajı = true;
        public static bool Bayram_Kampanyaları = true;
        public static bool Dogum_Gunleri = true;
        public static bool Ozel_Gunler = true;
        public static void SmsYetkiGuncelle()
        {
            SqlDataReader dr = veri.getDatareader(" Select * from tblSmsYetkileri Where firmaid="+firma.firmaid);
            while (dr.Read())
            {
                     if (dr["YetkiAdi"].ToString() == "Faturalı Satış") Faturalı_Satıs = Convert.ToBoolean(Convert.ToByte(dr["YetkiDegeri"]));
                else if (dr["YetkiAdi"].ToString() == "Faturasız Satış") Faturasiz_Satis = Convert.ToBoolean(Convert.ToByte(dr["YetkiDegeri"]));
                else if (dr["YetkiAdi"].ToString() == "Ürün İndirimleri") Urun_İndirimleri = Convert.ToBoolean(Convert.ToByte(dr["YetkiDegeri"]));
                else if (dr["YetkiAdi"].ToString() == "Cari Borç Hatırlatma") Cari_Borc_Hatırlatma = Convert.ToBoolean(Convert.ToByte(dr["YetkiDegeri"]));
                else if (dr["YetkiAdi"].ToString() == "Bayram Mesajı") Bayram_Mesajı = Convert.ToBoolean(Convert.ToByte(dr["YetkiDegeri"]));
                else if (dr["YetkiAdi"].ToString() == "Bayram Kampanyaları") Bayram_Kampanyaları = Convert.ToBoolean(Convert.ToByte(dr["YetkiDegeri"]));
                else if (dr["YetkiAdi"].ToString() == "Doğum Günleri") Dogum_Gunleri = Convert.ToBoolean(Convert.ToByte(dr["YetkiDegeri"]));
                else if (dr["YetkiAdi"].ToString() == "Özel Günler") Ozel_Gunler = Convert.ToBoolean(Convert.ToByte(dr["YetkiDegeri"]));
            }
        }
    }
}
