using EFaturaApi;
using EFaturaApi.Entities;
using Elmar_Ticari_Plus;
using elmarLibrary;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using EFatura = EFaturaApi.EFatura;

namespace EFaturaWebApi.Controllers
{
    public class EFaturaMobilController : ApiController
    {
        elmarLibrary.veritabani _library = new elmarLibrary.veritabani();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private EFaturaApi.SEFatura tester;
        [HttpGet]
        public string UserLogin(string userName, string password)
        {
            veri.server = "176.53.32.55";
            veri.db = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.1000110.1110001.1100000.1011000.1100111.1000010.1010011.1010100.1000001.1011011.1110111.1000101.1111101.1011001.1011100.1011100.1001001.10001011.1100101.10001001.10000110.1110110.1001111.", 8), "mykfs");
            veri.kadi = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.1000110.1001011.111010.1110111.10000110.1000101.1010100.1100110.1000001.1110110.10001000.1001001.1001110.1111100.10001101.1111110.1001001.1001001.1100000.10010001.10000000.1101011.1101000.", 8), "mykfs");
            veri.sifre = guvenlikVeKontrol.aesSifrecoz(guvenlikVeKontrol.yunusSifrecoz("1000101.111001.1111001.1001111.1000011.1010100.1010101.1000110.1011111.1111010.10000110.1100110.1000111.1010111.10000011.10001111.1101110.1110011.1100001.1101111.10010011.10010101.1001111.1110000.1110111.1011001.1010010.1101001.1101100.1111011.10011110.1011111.1110001.10011000.1011111.1111101.10011111.1110110.1011001.10000100.10000101.1100000.1110101.10101000.", 8), "mykfs");
            try
            {
                string tektenVt = "ElmarTicariPlus_Tekten";
                veri.db = tektenVt;
                git:
                SqlDataReader dr = veri.getDatareader("exec [spGirisKontrol] '" + userName + "','" + password + "'");
                while (dr.Read())
                {
                    firma.kullaniciAdi = userName;
                    firma.firmaid = Convert.ToInt32(dr[0]);
                    firma.subeid = Convert.ToInt32(dr[1].ToString());
                    firma.kullaniciid = Convert.ToInt32(dr[2].ToString());
                    if (firma.firmaid == 0 && veri.db == tektenVt)
                    {
                        veri.db = "ElmarTicariPlus";
                        goto git;
                    }
                    else if (firma.firmaid == 0 && veri.db == "ElmarTicariPlus")
                    {
                        veri.db = "ElmarTicariPlus2017";
                        goto git;
                    }
                }

                firma.firmaAdi = veri.getdatacell("Select adi from tblFirmaBilgileri Where firmaid=" + firma.firmaid);
                EFaturaApi.EFatura.getEFaturaBilgileri();
                if (EFaturaApi.EFatura.KullaniciAdi.Length == 0)
                    return "";
                else Win_Current_Login( EFaturaApi.EFatura.KullaniciAdi,  EFaturaApi.EFatura.Sifre,  EFaturaApi.EFatura.UrlAdresi);

                return (firma.firmaid.ToString() + "~" + firma.subeid.ToString() + "~" + firma.kullaniciid.ToString() + "~" + firma.firmaAdi + "~" +  EFaturaApi.EFatura.SessionsID);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public void Win_Current_Login(string user, string pass, object environment)
        {
            string environmentName = "CANLI";
            tester = new EFaturaApi.SEFatura(user, pass, environment.ToString());

            // login..
            List<FormParameters> getFormParameters = tester.Current_Login();

            if (getFormParameters != null)
            {
                foreach (var parameter in getFormParameters)
                {

                    //add settings items
                    string[] infos = { parameter.ActionName, Convert.ToString(parameter.ActionElapsedMs / 1000), parameter.ActionElapsedMs.ToString(), environmentName };
                     EFaturaApi.EFatura.LoginOK = parameter.loginEnter;
                    if (parameter.sessionID.GetType() == typeof(string))  EFaturaApi.EFatura.SessionsID = parameter.sessionID.ToString();
                }
            }

            if (EFatura.LoginOK)
            {
                tester.Current_GetUserList();
            }
        }

        [HttpGet]
        public IEnumerable<cariBilgileri.cariBilgileriAyrinti> GetCustomer()
        {
            guncelle.cariBilgileriVerileriniGuncelle();
            return cariBilgileri.listCariBilgileri.ToList();
        }
        [HttpGet]
        public IEnumerable<cariBilgileri.adresBilgileri.adresBilgileriAyrinti> GetCustomerAddress()
        {
            return cariBilgileri.adresBilgileri.listAdresBilgileri.ToList();
        }

        [HttpGet]
        public string  CustomerContolGIB(string vk)
        {
            List<FormParameters> getFormParameters=null;
            try
            {
                getFormParameters = tester.Current_CheckUser_byIdentifier(vk);

                if (getFormParameters != null)
                {
                    foreach (var parameter in getFormParameters)
                    {
                        //add settings items
                        string[] infos =
                        {
                            parameter.ActionName, Convert.ToString(parameter.ActionElapsedMs / 1000),
                            parameter.ActionElapsedMs.ToString()
                        };
                    }
                }

                if (FormValues.checkUserEnter == "Kullanıcı arama tamamlandı..")
                {
                    if (FormValues.vknUser != null)
                    {
                        return EFaturaApi.EFatura.AliciGB = FormValues.vknUser[0].ALIAS.ToString();
                    }

                    return EFaturaApi.EFatura.AliciGB = "";
                }

                return EFaturaApi.EFatura.AliciGB = "";
            }
            catch (Exception e)
            {
                return "BU HATA OLUŞTU:"+FormValues.ifHaveError.ToString();
            }
        }

        [HttpGet]
        public string SendInvoice(int customerid, DataTable dt)
        {
            try
            {
                #region  E-Fatura İşlemleri
                string faturaNo = EFaturaApi.EFatura.getEFaturaNo();


                Int64 faturaNoint = 0;
                if (faturaNo.Length > 0)
                {
                    //faturano 1 artırılacak
                    faturaNoint = Convert.ToInt64(faturaNo.Substring(7).ToString()); //0000006
                    faturaNoint = faturaNoint + 1; //0000007
                    faturaNo = "SHM" + DateTime.Now.Year + 0.ToString().PadLeft(9 - faturaNoint.ToString().Length, '0') + faturaNoint;
                }
                else
                {
                    faturaNo = "SHM" + DateTime.Now.Year + 1.ToString().PadLeft(9, '0');
                }
                var fatura = new EFaturaApi.SEFatura( EFaturaApi.EFatura.KullaniciAdi,  EFaturaApi.EFatura.Sifre,  EFaturaApi.EFatura.UrlAdresi);
                fatura.Current_Login();
                Thread.Sleep(3000);
                string faturaYolu = fatura.CreateInvoiceTypeDataTable(faturaNo, customerid, dt);
                if (faturaYolu.Length > 0)
                {
                    List<FormParameters> list = fatura.Current_SendInvoiceMultiTest(faturaYolu);
                    if (list != null)
                    {

                        return FormValues.sendInvoiceEnter;

                    }
                }
                #endregion
            }
            catch (Exception e)
            {
                return "E-Fatura gönderirken bir hata oluştu: " + e.Message;
            }

            return "";
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}