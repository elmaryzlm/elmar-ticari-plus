using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using elmarLibrary;
using System.Windows.Forms;
namespace Elmar_Ticari_Plus
{
    public class veri
    {
        public static string server;
        public static string db;
        public static string kadi;
        public static string sifre;

        static veritabani.elmarSifreliSqlDataClass veri2 = new veritabani.elmarSifreliSqlDataClass();
        static void baslangic()
        {
            /*   server = "176.53.32.51";
               db = "ElamrTicariPuls2017";
               kadi = "elamrAdmin";
               sifre = "elmar.yazilim123";*/

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
                MessageBox.Show("Tekrar Deneyin\n" + hata.Message, firma.programAdi);
                return null;
            }
        }
        public static string getdatacell(string procedureName, SqlParameter[] sqlParameters)
        {
            string result = "";
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    baslangic();
                    command.Connection = veri2.baglan();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    if (sqlParameters != null) command.Parameters.AddRange(sqlParameters);
                    result = command.ExecuteScalar().ToString();
                }
                catch (Exception e)
                {

                }
                finally
                {
                    command.Dispose();
                }
            }
            return result;
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
