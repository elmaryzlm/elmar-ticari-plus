using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceTicariPlus
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet KullaniciGiris(string kullaniciAdi, string sifre)
        {
            return DataAccess.Get.KullaniciGiris(kullaniciAdi, sifre);
        }

        #region Stok
        [WebMethod]
        public DataSet GetBirimler(int firmaID)
        {
            return DataAccess.Get.GetBirimler(firmaID);
        }

        [WebMethod]
        public DataSet GetFiyatTaslak(int firmaID)
        {
            return DataAccess.Get.GetFiyatTaslak(firmaID);
        }

        [WebMethod]
        public DataSet GetStokKartBirimleri(int firmaID)
        {
            return DataAccess.Get.GetStokKartBirimleri(firmaID);
        }

        [WebMethod]
        public DataSet GetStokKartFiyatlari(int firmaID)
        {
            return DataAccess.Get.GetStokKartFiyatlari(firmaID);
        }

        [WebMethod]
        public DataSet GetStokKartlari(int firmaID)
        {
            return DataAccess.Get.GetStokKartlari(firmaID);
        }
        #endregion
    }
}