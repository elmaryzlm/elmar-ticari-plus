using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Data.SqlServerCe;

namespace Elmar_Sıcak_Satış_Aktarım_Modülü
{
    class veriCE
    {
        public static void bagliKal()
        {
            SqlCeConnection con2 = new SqlCeConnection(connectionstring);
            con2.Open();
        }
        public static string connectionstring = "";
        private static SqlCeConnection con;
        public static SqlCeConnection baglan()
        {
            con = new SqlCeConnection(connectionstring);
            con.Open();
            return (con);
        }

        public static void cmd(string sqlkomut)
        {
            SqlCeConnection con = baglan();
            SqlCeCommand cmd = new SqlCeCommand(sqlkomut, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }

        public static DataTable getdatatable(string sqlselect)
        {
            SqlCeConnection con = baglan();
            SqlCeDataAdapter adp = new SqlCeDataAdapter(sqlselect, con);
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
            SqlCeConnection con = baglan();
            SqlCeDataAdapter adp = new SqlCeDataAdapter(sqlselect, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            adp.Dispose();
            con.Close();
            con.Dispose();
            return ds;
        }
        public static SqlCeDataReader getdatareader(string sqlselect)
        {
            SqlCeConnection con = baglan();
            SqlCeCommand cmd = new SqlCeCommand(sqlselect, con);
            SqlCeDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
