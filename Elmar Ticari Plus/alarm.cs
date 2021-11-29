using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using elmarLibrary;
using System.Data.SqlClient;
using System.Threading;
//using Proshot.UtilityLib.CommonDialogs;
using System.Windows.Forms;
namespace Elmar_Ticari_Plus
{
    class alarm
    {
        static double minimumMiktar = 100;
        private static double canliStokKontrolu()
        {
            try
            {
                double say = 0;
                SqlDataReader dr =  veri.getDatareader("SELECT sum(t.miktar * t.katsayi) FROM tblTicaret AS t INNER JOIN tblTicaretAyrinti AS ta ON t.ticaretAyrintiid = ta.ticaretAyrintiid  WHERE ta.silindimi = '0' and t.silindimi = '0' and  t.firmaid = " + firma.firmaid + " and ta.subeid = " + firma.subeid + " and ta.islemTuru not in ('Teklif','Sipariş') group by stokid having sum(t.miktar * t.katsayi) <= " + minimumMiktar + "");
                while (dr.Read()) say++;
                return say;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
        public static void kontrolMotorunuCalistir()
        {
            tmr.Interval = 10000;
            tmr.Tick += tmr_Tick;
            tmr.Start();


            //tmrOnlineKontrol.Interval = 10000;
            //tmrOnlineKontrol.Tick += tmrOnlineKontrol_tick;
            //tmrOnlineKontrol.Start();
        }

        static void tmr_Tick(object sender, EventArgs e)
        {
            //double d = canliStokKontrolu();
            //if (d > 0)
            //{
            //   // frmPopup popup;
            // //   popup = new frmPopup(PopupSkins.AlertSkin);
            //  //  popup.ShowPopup("Canlı Stok Kontrolü", d.ToString() + " Adet stoğunuz kritik seviyenin altına düşmüş. Görüntülemek için tıklayın.", 200, 2000, 2000);
            //  //  popup.Click += new EventHandler(tıklama_Click);
            //   tmr.Interval = 3600000;
            //}
            //Thread.Sleep(7200000);
        }
        public static void kontrolMotorunuDurdur()
        {
            tmr.Stop();
        }

        protected static void tıklama_Click(object sender, EventArgs e)
        {
            frmCanliStok frm = new frmCanliStok(false);
            frm.Show();
        }

        static System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer tmrOnlineKontrol = new System.Windows.Forms.Timer();
        static void tmrOnlineKontrol_tick(object sender, EventArgs e)
        {
            try
            {
                if (bilgiler.ip_al() != veri.getdatacell("select kullaniciip from tblFirmaKullanicilari where kullaniciid = " + firma.kullaniciid + ""))
                {
                 /*   MessageBox.Show("Başka biri bu kullanıcı ile oturumu açtı. Program Kapatılıyor.", firma.programAdi,MessageBoxButtons.OK,MessageBoxIcon.Hand);
                    tmrOnlineKontrol.Enabled = false;
                    programiKapat = true;
                    Application.OpenForms["Form1"].Close();*/
                }
            }
            catch (Exception)
            {
                Application.ExitThread();
            }
            
        }

        public static bool programiKapat = false;
    }
}