using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebServiceTicariPlus
{
    public static class DataAccess
    {
        static string connStr = @"Data Source=176.53.32.51;
                                  Initial Catalog=ElmarTicariPlus;
                                  User ID=elmarAdmin;
                                  Password=elmar.yazilim123;";
                                   
        public static class Get
        {
            public static DataSet KullaniciGiris(string kullaniciAdi, string sifre)
            {
                using (DbManager dbManager = new DbManager(connStr))
                {
                    string sql = "spGirisKontrol";
                    dbManager.DataCommand.Parameters.Add("@kAdi", SqlDbType.VarChar).Value = kullaniciAdi;
                    dbManager.DataCommand.Parameters.Add("@sifre", SqlDbType.VarChar).Value = sifre;
                    return dbManager.GetDataSet(sql, CommandType.StoredProcedure);
                }
            }

            #region Stok
            public static DataSet GetBirimler(int firmaID)
            {
                using (DbManager dbManager = new DbManager(connStr))
                {
                    string sql = "Select * from tblBirimler where Firmaid=@firmaID and silindiMi=0";
                    dbManager.DataCommand.Parameters.Add("@firmaID", SqlDbType.Int).Value = firmaID;
                    return dbManager.GetDataSet(sql);
                }
            }
            public static DataSet GetFiyatTaslak(int firmaID)
            {
                using (DbManager dbManager = new DbManager(connStr))
                {
                    string sql = "Select * from tblFiyatTaslak where Firmaid=@firmaID and silindiMi=0";
                    dbManager.DataCommand.Parameters.Add("@firmaID", SqlDbType.Int).Value = firmaID;
                    return dbManager.GetDataSet(sql);
                }
            }
            public static DataSet GetStokKartBirimleri(int firmaID)
            {
                using (DbManager dbManager = new DbManager(connStr))
                {
                    string sql = "Select * from tblStokkartBirimleri Where Firmaid=@firmaID and silindiMi=0";
                    dbManager.DataCommand.Parameters.Add("@firmaID", SqlDbType.Int).Value = firmaID;
                    return dbManager.GetDataSet(sql);
                }
            }
            public static DataSet GetStokKartFiyatlari(int firmaID)
            {
                using (DbManager dbManager = new DbManager(connStr))
                {
                    string sql = "Select * from tblStokFiyatlari Where Firmaid=@firmaID and silindiMi=0";
                    dbManager.DataCommand.Parameters.Add("@firmaID", SqlDbType.Int).Value = firmaID;
                    return dbManager.GetDataSet(sql);
                }
            }
            public static DataSet GetStokKartlari(int firmaID)
            {
                using (DbManager dbManager = new DbManager(connStr))
                {
                    string sql = "Select * from tblStokKart Where Firmaid=@firmaID and silindiMi=0";
                    dbManager.DataCommand.Parameters.Add("@firmaID", SqlDbType.Int).Value = firmaID;
                    return dbManager.GetDataSet(sql);
                }
            }
            #endregion
        }
    }
}