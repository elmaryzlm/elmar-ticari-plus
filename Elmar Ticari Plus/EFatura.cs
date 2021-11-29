using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elmar_Ticari_Plus.EDMService;
using System.Linq;

namespace Elmar_Ticari_Plus
{
    public class EFatura
    {
        public static int EFaturaID = 0;
        public static string SessionsID = "";
        public static string KullaniciAdi = "";
        public static string Sifre = "";
        public static string Gb = ""; //gelir vergi dairesinde posta kutu numarası şu şekilde olur genelede  urn:mail:defaultgb@yenibirfirmadaha.com.tr
        public static string VergiNo = "";
        public static string VergiDairesi = "";
        public static string Adres = "";
        public static string MersisNo = "";
        public static string TicaretSicilNo = "";

        public static string FirmaAdi = "";
        public static string Sehir = "";
        public static string UrlAdresi = "https://portal2.edmbilisim.com.tr/EFaturaEDM/EFaturaEDM.svc";
        public static string AliciGB = "";
        public static string AliciEPosta = "";
        public static bool OtoGonder = false;
        public static bool LoginOK = false;
        public static string EFaturaNo = "";
        public static string Aciklama = "";
        public static List<String> ListSerial=new List<string>();
        public static void getEFaturaBilgileri()
        {
            SqlDataReader dataReader =
                veri.getDatareader("select * from tblEFaturaBilgileri where FirmaID=" + firma.firmaid);
            while (dataReader.Read())
            {
                EFaturaID = Convert.ToInt32(dataReader["EFaturaID"]);
                KullaniciAdi = dataReader["KAdi"].ToString();
                Sifre = dataReader["Sifre"].ToString();
                Gb = dataReader["GB"].ToString();
                VergiNo = dataReader["VNo"].ToString();
                VergiDairesi = dataReader["VD"].ToString();
                Adres = dataReader["Adres"].ToString();
                MersisNo = dataReader["MN"].ToString();
                TicaretSicilNo = dataReader["TSC"].ToString();
                FirmaAdi = dataReader["FirmaAdi"].ToString();
                Sehir = dataReader["Sehir"].ToString();
                OtoGonder = Convert.ToBoolean(dataReader["OtoGonder"]);
            }
        }
        public static string getEFaturaNo()
        {
            string faturaNo = "";
            SqlDataReader dataReader =
                veri.getDatareader("select top 1 FaturaNo from tblEFaturaNo where FirmaID=" + firma.firmaid + " order by ID desc");
            while (dataReader.Read())
            {
                faturaNo = dataReader["FaturaNo"].ToString();
            }

            return faturaNo;
        }
        public static string getEFaturaNo(string seri)
        {
            string faturaNo = "";
            SqlDataReader dataReader =
                veri.getDatareader("select top 1 FaturaNo from tblEFaturaNo where FirmaID=" + firma.firmaid + " and FaturaNo like '%"+seri+"%' order by ID desc");
            while (dataReader.Read())
            {
                faturaNo = dataReader["FaturaNo"].ToString();
            }

            return faturaNo;
        }
        public static DateTime getEFaturaTarihi(string faturaNo)
        {
            DateTime dtFatura = DateTime.Now;
            SqlDataReader dataReader =
                veri.getDatareader("select top 1 FaturaTarihi from tblEFaturaNo where FirmaID=" + firma.firmaid + " and FaturaNo like'%" + faturaNo.Substring(0, 3) + "%' order by ID desc");
            while (dataReader.Read())
            {
                dtFatura = Convert.ToDateTime(dataReader["FaturaTarihi"].ToString());
            }

            return dtFatura;
        }
    }
}
