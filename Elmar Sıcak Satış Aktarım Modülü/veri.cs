using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
namespace Elmar_Sıcak_Satış_Aktarım_Modülü
{
    class veri
    {
        public static string veritabani_adi = "ElmarTicariPlus";
        public static string kullaniciAdi = "elmarAdmin";
        public static string sifre = "elmar.yazilim123";
        public static string server_adi = "elmaryazilim.net";
        private static SqlConnection con;
        public static SqlConnection baglan()
        {
            con = new SqlConnection(@"Data Source = " + server_adi + "; Database = " + veritabani_adi + "; uid=" + kullaniciAdi + "; pwd= " + sifre);
            //con = new SqlConnection("Data Source=" + server_adi + ";Persist Security Info=False;User ID=" + kullaniciAdi + ";Password=" + sifre + ";Initial Catalog=" + veritabani_adi + "");
            con.Open();
            return (con);
        }
        public static void cmd(string sqlkomut)
        {
            SqlConnection con = baglan();
            SqlCommand cmd = new SqlCommand(sqlkomut, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();

        }

        public static DataTable getdatatable(string sqlselect)
        {
            SqlConnection con = baglan();
            SqlDataAdapter adp = new SqlDataAdapter(sqlselect, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            adp.Dispose();
            con.Close();
            con.Dispose();
            return dt;
        }
        public static DataRow getdatarow(string sqlselect)
        {
            DataTable table = getdatatable(sqlselect);
            if (table.Rows.Count == 0) return null;
            return table.Rows[0];
        }

        public static string getdatacell(string sqlselect)
        {
            DataTable table = getdatatable(sqlselect);
            if (table.Rows.Count == 0) return null;
            return table.Rows[0][0].ToString();
        }
        public static DataSet getdataset(string sqlselect)
        {
            SqlConnection con = baglan();
            SqlDataAdapter adp = new SqlDataAdapter(sqlselect, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            adp.Dispose();
            con.Close();
            con.Dispose();
            return ds;
        }
        public static SqlDataReader getdatareader(string sqlselect)
        {
            //if (con.State == ConnectionState.Open) con.Close();
            SqlConnection con = baglan();
            SqlCommand cmd = new SqlCommand(sqlselect, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
