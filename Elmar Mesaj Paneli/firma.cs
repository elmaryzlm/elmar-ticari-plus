using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elmar_Mesaj_Paneli
{
    public class firma
    {      
        //Kullanıcı
        public static string kullaniciAdi;
        public static int kullaniciid;
        public static string gorevi;
        
        //Şube
        public static int subeid;

        //Firma                
        public static int firmaid;
        public static string demomu;
        public static string demoKalanGun;

      
        public static string programAdi="Elmar Ticari Plus";
        public static string personel = "0";
        public static string muhasebe = "0";
        public static string hastane = "0";
        public static string otel = "0";
        public static string yurt = "0";

        public static string parametreGegerleriniOlustur()
        {
            return firmaid.ToString()+"é"+subeid.ToString()+"é"+kullaniciid.ToString()+"é"+demomu+"é"+demoKalanGun+"é"+kullaniciAdi+"é"+gorevi.Replace(" ","-")+"é"+programAdi.Replace(" ","-")+"é"+personel+"é"+muhasebe+"é"+hastane+"é"+otel+"é"+yurt;
        }
    }
}
