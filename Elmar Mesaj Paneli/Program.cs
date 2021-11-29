using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Elmar_Mesaj_Paneli
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        static string str = "";
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            str = "13é12é13é0é30ésadettinéYöneticiéElmar-Bakımé0é1é1é1é1é";

            if (args.Length > 0) str = args[0];
            if (str.Count() > 0)
            {
                string[] S = str.Split('é');
                firma.firmaid = Convert.ToInt32(S[0]);
                firma.subeid = Convert.ToInt32(S[1]);
                firma.kullaniciid = Convert.ToInt32(S[2]);
                firma.demomu = S[3];
                firma.demoKalanGun = S[4];
                firma.kullaniciAdi = S[5];
                firma.gorevi = S[6];
                firma.programAdi = S[7];
                firma.personel = S[8];
                firma.muhasebe = S[9];
                firma.hastane = S[10];
                firma.otel = S[11];
                firma.yurt = S[12];
                MessageBox.Show("1");
                Application.Run(new frmMesajlar());
            }
            else
            {
                Application.Exit();
            }

        }
    }
}
