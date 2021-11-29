using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Elmar_Ticari_Plus
{
    class log
    {
        static Thread kanal;
        static int logid=0;
        static long iliskiid=0;
        private static void logEkle_i()
        {
            veri.cmd("Insert into tblLog(logid,iliskiid, kullaniciid) values("+logid+", "+iliskiid+", "+firma.kullaniciid+") ");
        }
        private static void logEkle()
        {
            
            veri.cmd("Insert into tblLog(logid, kullaniciid) values(" + logid + ", " + firma.kullaniciid + ") ");
        }

        public static void logEkle_i(int _logid, long _iliskiid)
        {
            logid = _logid;
            iliskiid = _iliskiid;
            kanal = new Thread(new ThreadStart(logEkle_i));
            kanal.Start();
        }

        public static void logEkle(int _logid)
        {
            logid = _logid;
            kanal = new Thread(new ThreadStart(logEkle));
            kanal.Start();
        }
    }
}
