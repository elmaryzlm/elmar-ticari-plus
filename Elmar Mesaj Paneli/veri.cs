using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using elmarLibrary;
using System.Windows.Forms;
namespace Elmar_Mesaj_Paneli
{
    public class veri
    {
       public static string server = "www.elmaryazilim.net";
        public static string db = "ElmarTicariPlus";
        public static string kadi= "elmarAdmin";
        public static string sifre =  "elmar.yazilim123";
        static veritabani.elmarSifreliSqlDataClass veri2 = new veritabani.elmarSifreliSqlDataClass();
        static void baslangic()
        {
            veri2.setVeritabaniyolu(server, db, kadi, sifre);
        }
        public static void cmd(string sorgu)
        {
            try
            {
                baslangic();
                veri2.cmd(sorgu);
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Tekrar Deneyin\n" + hata.Message, firma.programAdi);
            }
        }
        public static DataTable getdatatable(string sqlselect)
        {
            try
            {
                baslangic();
                return veri2.getdatatable(sqlselect);
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Tekrar Deneyin\n" + hata.Message, firma.programAdi);
                return null;
            }
        }
        public static SqlDataReader getDatareader(string sqlselect)
        {
            try
            {
                baslangic();
                return veri2.getdatareader(sqlselect);
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Tekrar Deneyin\n" + hata.Message, firma.programAdi);
                return null;
            }

        }
        public static DataRow getdatarow(string sqlselect)
        {
            try
            {
                baslangic();
                return veri2.getdatarow(sqlselect);
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Tekrar Deneyin\n" + hata.Message, firma.programAdi);
                return null;
            }
        }
        public static string getdatacell(string sqlselect)
        {
            try
            {
                baslangic();
                return veri2.getdatacell(sqlselect);
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Tekrar Deneyin\n" + hata.Message, firma.programAdi);
                return null;
            }
        }
        public static DataSet getDataset(string sqlselect)
        {
            try
            {
                baslangic();
                return veri2.getdataset(sqlselect);
            }
            catch (Exception hata)
            {
                //MessageBox.Show("Tekrar Deneyin\n" + hata.Message, firma.programAdi);
                return null;
            }
        }
    }
}
