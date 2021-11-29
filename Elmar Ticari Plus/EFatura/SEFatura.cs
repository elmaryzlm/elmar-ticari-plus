using CurrentEDMConnectorClientLibrary;
using CurrentEDMConnectorClientLibrary.Entities;
using Elmar_Ticari_Plus.EDMService;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using hm.common.Ubltr.Invoice21;
using elmarLibrary;

namespace Elmar_Ticari_Plus
{
    public partial class SEFatura
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // EFaturaOIBPortClient --> EFaturaEDMPortClient  
        private EFaturaEDMPortClient _service;
        private REQUEST_HEADERType _requestHeader;
        private String _username { get; set; }
        private String _password { get; set; }
        // private string _path = System.Configuration.ConfigurationSettings.AppSettings["Path"].ToString();
        private static Regex timeZoneRegex = new Regex(@"(\d{2}:\d{2}:\d{2})(\.\d{7}[\+|-]\d{2}:\d{2})");
        public SEFatura(string user, string password, string endpointname)
        {
            _service = new EFaturaEDMPortClient();
            _service.Endpoint.Address = new EndpointAddress(endpointname);
            _username = user;
            _password = password;
            _requestHeader = new EDMService.REQUEST_HEADERType();
            _requestHeader.SESSION_ID = "0";
            _requestHeader.CLIENT_TXN_ID = System.Guid.NewGuid().ToString();
            _requestHeader.APPLICATION_NAME = "EDM MUHAMMET DORA - TEKNIK/ERP";
            _requestHeader.CHANNEL_NAME = "EDM BİLİŞİM";
            _requestHeader.HOSTNAME = "HOST-EDMBİLİŞİM-DEFAULT";
            _requestHeader.ACTION_DATE = DateTime.Now;
            _requestHeader.ACTION_DATESpecified = true;
            _requestHeader.REASON = "ERP ve TEKNİK için deneme yöntemi"; // "EFATURA GONDERME VE ALMA ISLEMLERI" + (Test ? " TEST" : "");
            _requestHeader.COMPRESSED = "N";
            FormValues.sessionID = _requestHeader.SESSION_ID;
        }

        // oturum açma-kapama
        #region login & logout

        /// <summary>
        /// EDM web servis Login işlemi
        /// </summary>
        public List<FormParameters> Current_Login()
        {
            logger.Info("Login test...");
            List<FormParameters> sendFormParametersList = new List<FormParameters>();
            FormParameters sendFormParametersEntity = new FormParameters();

            try
            {
                LoginRequest loginRequest = new LoginRequest();
                loginRequest.USER_NAME = _username;
                loginRequest.PASSWORD = _password;
                loginRequest.REQUEST_HEADER = _requestHeader;
                loginRequest.REQUEST_HEADER.ACTION_DATE = DateTime.Now;
                loginRequest.REQUEST_HEADER.ACTION_DATESpecified = true;
                loginRequest.REQUEST_HEADER.APPLICATION_NAME = "EDM MUHAMMET DORA - TEKNIK/ERP";
                loginRequest.REQUEST_HEADER.CHANNEL_NAME = "EDM test company";
                loginRequest.REQUEST_HEADER.COMPRESSED = "N";
                loginRequest.REQUEST_HEADER.HOSTNAME = "HOST-EDMBİLİŞİM-DEFAULT";

                //LoginResponse loginResponse = _service.Login(loginRequest);

                // Süre ölçüm wrapper:
                var loginResponseMeasure = Measure<LoginRequest, LoginResponse>(_service.Login, loginRequest);

                LoginResponse loginResponse = (LoginResponse)loginResponseMeasure[0];
                long loginFunctionMs = (long)loginResponseMeasure[1];
                string loginFunctionName = (string)loginResponseMeasure[2];

                if (!(String.IsNullOrEmpty(loginResponse.SESSION_ID)) || !(loginResponse.SESSION_ID == "0"))
                {
                    _requestHeader.SESSION_ID = loginResponse.SESSION_ID;

                    sendFormParametersEntity.sessionID = loginResponse.SESSION_ID;
                    sendFormParametersEntity.actionDate = DateTime.Now.ToShortDateString().ToString();
                    sendFormParametersEntity.applicationName = loginRequest.REQUEST_HEADER.APPLICATION_NAME;
                    sendFormParametersEntity.channelName = loginRequest.REQUEST_HEADER.CHANNEL_NAME;
                    sendFormParametersEntity.compressed = loginRequest.REQUEST_HEADER.COMPRESSED;
                    sendFormParametersEntity.hostName = loginRequest.REQUEST_HEADER.HOSTNAME;
                    sendFormParametersEntity.ActionElapsedMs = loginFunctionMs;
                    sendFormParametersEntity.ActionName = loginFunctionName;
                    sendFormParametersEntity.loginEnter = true;

                    return sendFormParametersList;
                }

                logger.Info(loginRequest.REQUEST_HEADER.ToJSONString());
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                sendFormParametersEntity.loginEnter = false;
                sendFormParametersEntity.ifHaveError = requesterror;
                sendFormParametersEntity.ifHaveErrorDetail = detail;
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                sendFormParametersEntity.loginEnter = false;
                sendFormParametersEntity.ifHaveError = fex;
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                sendFormParametersEntity.loginEnter = false;
                sendFormParametersEntity.ifHaveError = ex;
            }
            finally
            {
                sendFormParametersList.Add(sendFormParametersEntity);
            }

            return sendFormParametersList;
        }

        /// <summary>
        /// EDM web servis Logout işlemi
        /// </summary>
        public List<FormParameters> Current_Logout()
        {
            logger.Info("Logout test...");
            List<FormParameters> sendFormParametersList = new List<FormParameters>();
            FormParameters sendFormParametersEntity = new FormParameters();

            try
            {
                LogoutRequest logoutRequest = new LogoutRequest();
                logoutRequest.REQUEST_HEADER = _requestHeader;

                // Süre ölçüm wrapper:
                var logoutResponseMeasure = Measure<LogoutRequest, LogoutResponse>(_service.Logout, logoutRequest);

                LogoutResponse logoutResponse = (LogoutResponse)logoutResponseMeasure[0];
                long logoutFunctionMs = (long)logoutResponseMeasure[1];
                string logoutFunctionName = (string)logoutResponseMeasure[2];


                sendFormParametersEntity.ActionElapsedMs = logoutFunctionMs;
                sendFormParametersEntity.ActionName = logoutFunctionName;

                FormValues.loginEnter = "Oturum sonlandırıldı..";


                return sendFormParametersList;
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
                FormValues.loginEnter = "Oturum sonlandırma hatası";
                FormValues.ifHaveErrorDetail = detail;
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                FormValues.loginEnter = "Oturum sonlandırma hatası";
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                FormValues.loginEnter = "Oturum sonlandırma hatası";
            }
            finally
            {
                sendFormParametersList.Add(sendFormParametersEntity);
            }
            return sendFormParametersList;
        }

        #endregion
       
        // Fatura gönderimleri..
        #region e-Fatura e-Arşiv gönderimi

        public List<FormParameters> Current_SendInvoiceMultiTest(string aliciGIB, string ublfilefullpath)
        {

            List<FormParameters> sendFormParametersList = new List<FormParameters>();
            FormParameters sendFormParametersEntity = new FormParameters();
            string receiverVKNTCKN = null;
            try
            {
                byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);

                hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
                    = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));

                // smooth serialize
                string invoiceUblXmlStr
                    = ublinvoice.SerializeF();

                List<INVOICE> cntrinvoiceList = new List<INVOICE>();
                for (int i = 0; i < 1; i++)
                {

                    if (false)
                    {
                        ublinvoice.UUID.Value = Guid.NewGuid().ToString();
                    }

                    if (ublinvoice.ID == null)
                    {
                        ublinvoice.ID = new hm.common.Ubltr.Invoice21.IDType();
                    }

                    if (!string.IsNullOrEmpty(null))
                    {
                        ublinvoice.ID.Value = "";
                    }

                    invoiceUblXmlStr = ublinvoice.SerializeF();
                    invoiceUblXmlStr = timeZoneRegex.Replace(invoiceUblXmlStr, "$1");
                    ublfilebytes = System.Text.Encoding.UTF8.GetBytes(invoiceUblXmlStr);


                    /// set receiver sample

                    if (string.IsNullOrEmpty(null))
                    {
                        receiverVKNTCKN = ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN").First().ID.Value;
                    }
                    CheckUserRequest checkUserRequest = new CheckUserRequest();
                    checkUserRequest.USER = new GIBUSER();
                    checkUserRequest.USER.IDENTIFIER = receiverVKNTCKN;
                    checkUserRequest.REQUEST_HEADER = _requestHeader;

                    GIBUSER[] gibusers = _service.CheckUser(checkUserRequest);

                    // create connector invoice
                    INVOICE cntrinvoice = new INVOICE();

                    cntrinvoice.ID = ublinvoice.ID.Value;//ublinvoice.ID.Value;
                    cntrinvoice.UUID = ublinvoice.UUID.Value;//ublinvoice.UUID.Value;
                    cntrinvoice.HEADER = new INVOICEHEADER()
                    {
                        EARCHIVE = aliciGIB.Trim().Length == 0 ? true : false,
                        SENDER = EFatura.VergiNo,
                        FROM = EFatura.Gb,//gönderici
                        RECEIVER = receiverVKNTCKN,
                        TO = aliciGIB.Trim().Length == 0 ? EFatura.AliciEPosta : aliciGIB, //alıcı
                    };
                    cntrinvoice.CONTENT = new EDMService.base64Binary()
                    {
                        Value = ublfilebytes
                    };

                    cntrinvoiceList.Add(cntrinvoice);
                    if (cntrinvoice.UUID != null)
                    {
                        FormValues.sendInvoiceEnter = "Fatura Gönderildi";
                    }
                }


                SendInvoiceRequest sendInvoiceRequest = new SendInvoiceRequest();

                sendInvoiceRequest.REQUEST_HEADER = _requestHeader;
                sendInvoiceRequest.RECEIVER = new SendInvoiceRequestRECEIVER()
                {
                    vkn = cntrinvoiceList[0].HEADER.RECEIVER,
                    alias = cntrinvoiceList[0].HEADER.TO,


                };
                sendInvoiceRequest.INVOICE = cntrinvoiceList.ToArray();

                //SendInvoiceResponse sendInvoiceResponse = _service.SendInvoice(sendInvoiceRequest);

                // Süre ölçüm wrapper:
                var sendInvoiceResponseMeasure = Measure<SendInvoiceRequest, SendInvoiceResponse>(_service.SendInvoice, sendInvoiceRequest);
                long sendInvoiceFunctionMs = (long)sendInvoiceResponseMeasure[1];
                string sendInvoiceFunctionName = (string)sendInvoiceResponseMeasure[2];

                sendFormParametersEntity.ActionElapsedMs = sendInvoiceFunctionMs;
                sendFormParametersEntity.ActionName = sendInvoiceFunctionName;

            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;


                logger.Error("FaultException fault message:" + fexp.Message);
                logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                FormValues.sendInvoiceEnter = "Fatura Gönderilemedi";
                FormValues.ifHaveError = requesterror;
                FormValues.ifHaveErrorDetail = detail;
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                FormValues.sendInvoiceEnter = "Fatura Gönderilemedi";
                FormValues.ifHaveError = fex;
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                FormValues.sendInvoiceEnter = "Fatura Gönderilemedi";
                FormValues.ifHaveError = ex;
            }
            finally
            {
                sendFormParametersList.Add(sendFormParametersEntity);
            }
            return sendFormParametersList;
        }
        #endregion

        #region internet satis gonderimi

        public void Current_SendInternetInvoice_singlefromfile(string ublfilefullpath, int multiplexcount = 1)
        {

            try
            {

                logger.Info("SendInvoice of INTERNET from file test...");

                byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);

                hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
                    = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));

                // smooth serialize
                string invoiceUblXmlStr
                    = ublinvoice.SerializeF();

                List<INVOICE> cntrinvoiceList = new List<INVOICE>();


                for (int i = 0; i < multiplexcount; i++)
                {

                    //// aynı user- farklı firma ozel test hazırlığı
                    ublinvoice.UUID.Value = Guid.NewGuid().ToString();
                    invoiceUblXmlStr = ublinvoice.SerializeF();
                    invoiceUblXmlStr = timeZoneRegex.Replace(invoiceUblXmlStr, "$1");
                    ublfilebytes = System.Text.Encoding.UTF8.GetBytes(invoiceUblXmlStr);
                    ////

                    /// set receiver sample

                    string receiverVKNTCKN = ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN").First().ID.Value;

                    CheckUserRequest checkUserRequest = new CheckUserRequest();
                    checkUserRequest.USER = new GIBUSER();
                    checkUserRequest.USER.IDENTIFIER = receiverVKNTCKN;
                    checkUserRequest.REQUEST_HEADER = _requestHeader;

                    GIBUSER[] gibusers = _service.CheckUser(checkUserRequest);

                    // set receiver alias
                    string receiverPostBox = "";

                    if (gibusers.Count() > 0)
                    {
                        // check receiver gib alias..  
                        receiverPostBox = "urn:mail:defaultpk@edmbilisim.com.tr";
                    }
                    else
                    {
                        // check email..
                        receiverPostBox = "eposta@firma.com";

                        string EmailRegularExpression = "^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9_-]+(\\.[a-z0-9_-]+)*\\.([a-z]+)$";

                        foreach (string s in receiverPostBox.Split(','))
                        {
                            Match match = Regex.Match(s, EmailRegularExpression, RegexOptions.IgnoreCase);
                            if (!match.Success)
                            {
                                logger.Info("eposta hatalı");
                            }
                        }
                    }




                    // create connector invoice
                    INVOICE cntrinvoice = new INVOICE();
                    cntrinvoice.ID = ublinvoice.ID.Value;
                    cntrinvoice.UUID = ublinvoice.UUID.Value;
                    cntrinvoice.HEADER = new INVOICEHEADER()
                    {
                        SENDER = ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN").First().ID.Value,
                        FROM = "urn:mail:defaultgb@edmbilisim.com.tr", // "defaultgb@edmbilisim.com.tr", // "urn:mail:defaultgb@edmbilisim.com.tr",
                        RECEIVER = receiverVKNTCKN, //ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN").First().ID.Value,
                        TO = receiverPostBox, //"urn:mail:defaultpk@edmbilisim.com.tr", //"defaultpk@edmbilisim.com.tr", // "defaultpk@edmbilisim.com.tr",

                        // internet satis bilgileri
                        INTERNETSALES = true,
                        INTERNETSALESDETAILS = new INVOICEHEADERINTERNETSALESDETAILS()
                        {
                            webAdresi = "www.ebay.com",
                            odemeSekli = "banka havalesi",
                            odemeAracisiAdi = "İş bankası",
                            odemeTarihiSpecified = true,
                            odemeTarihi = DateTime.Now,
                            gonderiBilgileri = new INVOICEHEADERINTERNETSALESDETAILSGonderiBilgileri()
                            {
                                gonderimTarihi = DateTime.Now,
                                gonderiTasiyan = new INVOICEHEADERINTERNETSALESDETAILSGonderiBilgileriGonderiTasiyan()
                                {
                                    gercekKisi = new INVOICEHEADERINTERNETSALESDETAILSGonderiBilgileriGonderiTasiyanGercekKisi()
                                    {
                                        tckn = "11111111111",
                                        adiSoyadi = "isim soyisim",
                                    },
                                    //tuzelKisi = new INVOICEHEADERINTERNETSALESDETAILSGonderiBilgileriGonderiTasiyanTuzelKisi()
                                    //{
                                    //    vkn = "2222222222",
                                    //    unvan = "XYZ kargo"
                                    //}
                                },
                            },
                        }

                    };
                    cntrinvoice.CONTENT = new EDMService.base64Binary()
                    {
                        Value = ublfilebytes
                    };

                    cntrinvoiceList.Add(cntrinvoice);

                }


                SendInvoiceRequest sendInvoiceRequest = new SendInvoiceRequest();
                sendInvoiceRequest.REQUEST_HEADER = _requestHeader;
                sendInvoiceRequest.RECEIVER = new SendInvoiceRequestRECEIVER()
                {
                    vkn = cntrinvoiceList[0].HEADER.RECEIVER,
                    alias = cntrinvoiceList[0].HEADER.TO,
                };
                sendInvoiceRequest.INVOICE = cntrinvoiceList.ToArray();

                SendInvoiceResponse sendInvoiceResponse = _service.SendInvoice(sendInvoiceRequest);

                logger.Info("Ok " + sendInvoiceResponse.REQUEST_RETURN.INTL_TXN_ID.ToString());

            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException fault message:" + fexp.Message);
                logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
            }

        }

        #endregion


        #region GetInvoice
        /// <summary>
        /// Verilen kriterlere uyan E-fatura/E-Arşiv faturaların sistemden çekilmesini sağlar. 
        /// Çekilen bilgiler için fatura kafa kaydı, fatura dosyası, fatutra durum bilgisi, zarf bilgileri yer alır.
        /// </summary>
        /// <param name="headeronly">Fatura dosyasını okuma kriteri true: kafa kaydı bilgileri, false: contenttype'a bağlı istenen fatura dosyası</param>
        public List<FormParameters> Current_GetInvoice(string faturaNo = null)   // spesifik bir ETTN 
        {
            bool downloadcontent = false;  // true: kafa kaydı bilgileri, false: contenttype'a bağlı istenen fatura dosyası
            string contenttype = "PDF";// "XML", "PDF", "ZIP"

            bool read_included = true;  // true: MARK işlemi ile işaretlenmiş olanları da listeler, false: MARK ie işaretlenmil olanları listeye dahil etmez
            string direction = "OUT";   // Gönderilenler için: "OUT" "OUT-EINVOICE"  "OUT-EARCHIVE" / Gelenler için:"IN";
            int limit = 10;  // çekilen fatura adedi için limit 
            string faturano = faturaNo;  // spesifik bir faturano
            string faturauuid = null;
            logger.Info("GetInvoice test...");
            List<FormParameters> sendFormParametersList = new List<FormParameters>();
            FormParameters sendFormParametersEntity = new FormParameters();

            try
            {

                FormValues.invoiceElements = new String[10];
                GetInvoiceRequest getInvoiceRequest = new GetInvoiceRequest();
                GetInvoiceRequestINVOICE_SEARCH_KEY invoiceSearchKey = new GetInvoiceRequestINVOICE_SEARCH_KEY();

                invoiceSearchKey.DIRECTION = direction;
                invoiceSearchKey.CR_START_DATE = DateTime.Now.Date.AddDays(-30);
                invoiceSearchKey.CR_START_DATESpecified = true;
                invoiceSearchKey.CR_END_DATE = DateTime.Now.Date.AddDays(1);
                invoiceSearchKey.CR_END_DATESpecified = true;
                invoiceSearchKey.LIMIT = limit;
                invoiceSearchKey.LIMITSpecified = (limit == int.MaxValue) ? false : true;
                invoiceSearchKey.READ_INCLUDED = read_included;     // true/false; true: MARK işlemi ile işaretlenmiş olanları da listeler, false: MARK ie işaretlenmil olanları listeye dahil etmez
                invoiceSearchKey.READ_INCLUDEDSpecified = true;
                invoiceSearchKey.ID = faturano;
                invoiceSearchKey.UUID = faturauuid;

                getInvoiceRequest.HEADER_ONLY = downloadcontent ? "N" : "Y";   // "Y": get header only , "N": also get content 
                getInvoiceRequest.INVOICE_CONTENT_TYPE
                    = (contenttype == "XML") ? INVOICE_CONTENT_TYPE.XML
                    : (contenttype == "PDF") ? INVOICE_CONTENT_TYPE.PDF
                    : (contenttype == "ZIP") ? INVOICE_CONTENT_TYPE.ALL
                    : INVOICE_CONTENT_TYPE.XML;

                getInvoiceRequest.INVOICE_SEARCH_KEY = invoiceSearchKey;
                getInvoiceRequest.REQUEST_HEADER = _requestHeader;

                //INVOICE[] invoiceList = _service.GetInvoice(getInvoiceRequest);
                var invoiceListResponseMeasure = Measure<GetInvoiceRequest, INVOICE[]>(_service.GetInvoice, getInvoiceRequest);

                INVOICE[] invoiceListResponse = (INVOICE[])invoiceListResponseMeasure[0];
                long invoiceListFunctionMs = (long)invoiceListResponseMeasure[1];
                string invoiceListFunctionName = (string)invoiceListResponseMeasure[2];

                sendFormParametersEntity.ActionElapsedMs = invoiceListFunctionMs;
                sendFormParametersEntity.ActionName = invoiceListFunctionName;

                logger.Info("{0} adet, OK", invoiceListResponse.Count());


                if (invoiceListResponse.Count() > 0)
                {
                    FormValues.getInvoiceEnter = "Faturalar başarıyla indirildi.";
                    FormValues.hostName = invoiceListResponse[0].UUID;
                }
                else
                {
                    FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                }

            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = requesterror;
                FormValues.ifHaveErrorDetail = detail;
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = fex;
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = ex;
            }
            finally
            {
                sendFormParametersList.Add(sendFormParametersEntity);
            }

            return sendFormParametersList;
        }
        #endregion

        // fatura alma , indirme ve durum sorgulama
        #region GetInvoice
        /// <summary>
        /// Verilen kriterlere uyan E-fatura/E-Arşiv faturaların sistemden çekilmesini sağlar. 
        /// Çekilen bilgiler için fatura kafa kaydı, fatura dosyası, fatutra durum bilgisi, zarf bilgileri yer alır.
        /// </summary>
        /// <param name="headeronly">Fatura dosyasını okuma kriteri true: kafa kaydı bilgileri, false: contenttype'a bağlı istenen fatura dosyası</param>
        public INVOICE[] Current_GetInvoice(bool downloadcontent = false,  // true: kafa kaydı bilgileri, false: contenttype'a bağlı istenen fatura dosyası
                                    string contenttype = "XML",  // "XML", "PDF", "ZIP"
                                    bool read_included = true,  // true: MARK işlemi ile işaretlenmiş olanları da listeler, false: MARK ie işaretlenmil olanları listeye dahil etmez
                                    string direction = "OUT",   // Gönderilenler için: "OUT" "OUT-EINVOICE"  "OUT-EARCHIVE" / Gelenler için:"IN";
                                    int limit = 10,  // çekilen fatura adedi için limit 
                                    string faturano = null,  // spesifik bir faturano
                                    string faturauuid = null)   // spesifik bir ETTN 
        {
            logger.Info("GetInvoice test...");
            List<FormParameters> sendFormParametersList = new List<FormParameters>();
            FormParameters sendFormParametersEntity = new FormParameters();
            INVOICE[] invoiceListResponse = null;
            try
            {

                FormValues.invoiceElements = new String[10];
                GetInvoiceRequest getInvoiceRequest = new GetInvoiceRequest();
                GetInvoiceRequestINVOICE_SEARCH_KEY invoiceSearchKey = new GetInvoiceRequestINVOICE_SEARCH_KEY();

                invoiceSearchKey.DIRECTION = direction;
                invoiceSearchKey.CR_START_DATE = DateTime.Now.Date.AddDays(-30);
                invoiceSearchKey.CR_START_DATESpecified = true;
                invoiceSearchKey.CR_END_DATE = DateTime.Now.Date.AddDays(1);
                invoiceSearchKey.CR_END_DATESpecified = true;
                invoiceSearchKey.LIMIT = limit;
                invoiceSearchKey.LIMITSpecified = (limit == int.MaxValue) ? false : true;
                invoiceSearchKey.READ_INCLUDED = read_included;     // true/false; true: MARK işlemi ile işaretlenmiş olanları da listeler, false: MARK ie işaretlenmil olanları listeye dahil etmez
                invoiceSearchKey.READ_INCLUDEDSpecified = true;
                invoiceSearchKey.ID = faturano;
                invoiceSearchKey.UUID = faturauuid;

                getInvoiceRequest.HEADER_ONLY = downloadcontent ? "N" : "Y";   // "Y": get header only , "N": also get content 
                getInvoiceRequest.INVOICE_CONTENT_TYPE
                    = (contenttype == "XML") ? INVOICE_CONTENT_TYPE.XML
                    : (contenttype == "PDF") ? INVOICE_CONTENT_TYPE.PDF
                    : (contenttype == "ZIP") ? INVOICE_CONTENT_TYPE.ALL
                    : INVOICE_CONTENT_TYPE.XML;

                getInvoiceRequest.INVOICE_SEARCH_KEY = invoiceSearchKey;
                getInvoiceRequest.REQUEST_HEADER = _requestHeader;

                //INVOICE[] invoiceList = _service.GetInvoice(getInvoiceRequest);
                var invoiceListResponseMeasure = Measure<GetInvoiceRequest, INVOICE[]>(_service.GetInvoice, getInvoiceRequest);

                invoiceListResponse = (INVOICE[])invoiceListResponseMeasure[0];
                long invoiceListFunctionMs = (long)invoiceListResponseMeasure[1];
                string invoiceListFunctionName = (string)invoiceListResponseMeasure[2];

                sendFormParametersEntity.ActionElapsedMs = invoiceListFunctionMs;
                sendFormParametersEntity.ActionName = invoiceListFunctionName;

                logger.Info("{0} adet, OK", invoiceListResponse.Count());


                if (invoiceListResponse.Count() > 0)
                {
                    FormValues.getInvoiceEnter = "Faturalar başarıyla indirildi.";
                }
                else
                {
                    FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                }

            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = requesterror;
                FormValues.ifHaveErrorDetail = detail;
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = fex;
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = ex;
            }
            finally
            {
                sendFormParametersList.Add(sendFormParametersEntity);
            }

            return invoiceListResponse;
        }
        #endregion


        // faturanın durum bilgisinin sorgulanması
        #region GetInvoiceStatus

        /// <summary>
        /// faturano ve ettn si verilen faturanın durum sorgulanması
        /// </summary>
        /// <param name="title"></param>
        /// 

        public List<FormParameters> Current_GetInvoiceStatus(string invoiceno)
        {
            logger.Info("GetInvoiceStatus test...");
            List<FormParameters> sendFormParametersList = new List<FormParameters>();
            FormParameters sendFormParametersEntity = new FormParameters();

            try
            {

                FormValues.invoiceStatusElements = new String[10];
                GetInvoiceStatusRequest getInvoiceStatusRequest = new GetInvoiceStatusRequest()
                {
                    REQUEST_HEADER = _requestHeader,
                    INVOICE = new INVOICE()
                    {
                        ID = invoiceno,
                        //UUID = "572B1FFE-05FB-44B6-9BE6-79BCBD24AEFE",
                    }
                };

                //GetInvoiceStatusResponse getInvoiceStatusResponse = _service.GetInvoiceStatus(getInvoiceStatusRequest);
                var getInvoiceStatusResponseMeasure = Measure<GetInvoiceStatusRequest, GetInvoiceStatusResponse>(_service.GetInvoiceStatus, getInvoiceStatusRequest);
                GetInvoiceStatusResponse getInvoiceStatusResponse = (GetInvoiceStatusResponse)getInvoiceStatusResponseMeasure[0];
                long invoiceStatusFunctionMs = (long)getInvoiceStatusResponseMeasure[1];
                string invoiceStatusFunctionName = (string)getInvoiceStatusResponseMeasure[2];

                if (getInvoiceStatusResponse.INVOICE_STATUS.UUID != null) FormValues.invoiceStatusEnter = "Durum Sorgulama Başarılı";
                if (getInvoiceStatusResponse.INVOICE_STATUS.UUID != null) FormValues.invoiceStatusElements[0] = getInvoiceStatusResponse.INVOICE_STATUS.ID.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.STATUS != null) FormValues.invoiceStatusElements[1] = getInvoiceStatusResponse.INVOICE_STATUS.STATUS.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.STATUS_DESCRIPTION != null) FormValues.invoiceStatusElements[2] = getInvoiceStatusResponse.INVOICE_STATUS.STATUS_DESCRIPTION.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.RESPONSE_CODE != null) FormValues.invoiceStatusElements[3] = getInvoiceStatusResponse.INVOICE_STATUS.RESPONSE_CODE.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.RESPONSE_DESCRIPTION != null) FormValues.invoiceStatusElements[4] = getInvoiceStatusResponse.INVOICE_STATUS.RESPONSE_DESCRIPTION.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.HEADER != null) FormValues.invoiceStatusElements[5] = getInvoiceStatusResponse.INVOICE_STATUS.HEADER.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.CONTENT != null) FormValues.invoiceStatusElements[6] = getInvoiceStatusResponse.INVOICE_STATUS.CONTENT.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.CDATE != null) FormValues.invoiceStatusElements[7] = getInvoiceStatusResponse.INVOICE_STATUS.CDATE.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.GIB_STATUS_CODE != null) FormValues.invoiceStatusElements[8] = getInvoiceStatusResponse.INVOICE_STATUS.GIB_STATUS_CODE.ToString();
                if (getInvoiceStatusResponse.INVOICE_STATUS.GIB_STATUS_DESCRIPTION != null) FormValues.invoiceStatusElements[9] = getInvoiceStatusResponse.INVOICE_STATUS.GIB_STATUS_DESCRIPTION.ToString();

                logger.Info("Ok {0} ({1})", getInvoiceStatusResponse.INVOICE_STATUS.STATUS, getInvoiceStatusResponse.INVOICE_STATUS.STATUS_DESCRIPTION);

                sendFormParametersEntity.ActionElapsedMs = invoiceStatusFunctionMs;
                sendFormParametersEntity.ActionName = invoiceStatusFunctionName;


                //ETTN İLE BUL
                /*
                getInvoiceStatusRequest = new GetInvoiceStatusRequest()
                {
                    REQUEST_HEADER = _requestHeader,
                    INVOICE = new INVOICE()
                    {
                        UUID = "6593b723-9447-4706-9fdf-0820dbfb1728",
                    }
                };
               
                getInvoiceStatusResponse = _service.GetInvoiceStatus(getInvoiceStatusRequest);
                */
                //ETTN İLE BUL

            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
                FormValues.invoiceStatusEnter = "Durum sorgulanamadı.";
                FormValues.ifHaveError = fexp;
                FormValues.ifHaveErrorDetail = detail;

            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                FormValues.ifHaveError = fex;
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                FormValues.ifHaveError = ex;
            }
            finally
            {
                sendFormParametersList.Add(sendFormParametersEntity);
            }

            return sendFormParametersList;
        }

        #endregion


        // okunan faturaların işaretlenmesi  
        #region MarkInvoice

        /// <summary>
        /// verilen faturanın okunmuş olarak işaretlenmesi
        /// </summary>
        /// <param name="title"></param>
        public void Current_MarkInvoice_asRead()
        {
            try
            {
                logger.Info("MARK Invoice test...");

                MarkInvoiceRequest markInvoiceRequest = new MarkInvoiceRequest()
                {
                    REQUEST_HEADER = _requestHeader,
                    MARK = new MarkInvoiceRequestMARK()
                    {
                        valueSpecified = true,
                        value = MarkInvoiceRequestMARKValue.READ,
                        INVOICE = new INVOICE[]
                                    {
                                        new INVOICE()
                                        {
                                            ID = "EDM2015000000017",
                                        },
                                    },
                    }
                };

                MarkInvoiceResponse getInvoiceStatusResponse = _service.MarkInvoice(markInvoiceRequest);

                logger.Info("Ok");

                markInvoiceRequest = new MarkInvoiceRequest()
                {
                    REQUEST_HEADER = _requestHeader,
                    MARK = new MarkInvoiceRequestMARK()
                    {
                        valueSpecified = true,
                        value = MarkInvoiceRequestMARKValue.READ,
                        INVOICE = new INVOICE[]
                                    {
                                        new INVOICE()
                                        {
                                            ID = "EDM20150000000XX",
                                        },
                                    },
                    }
                };

                getInvoiceStatusResponse = _service.MarkInvoice(markInvoiceRequest);

                logger.Info("Ok2");

            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
            }
        }

        /// <summary>
        /// verilen faturanın okunMAmış olarak işaretlenmesi
        /// </summary>
        /// <param name="title"></param>
        public void Current_MarkInvoice_asUnread()
        {
            try
            {
                logger.Info("UNMARK Invoice test...");

                MarkInvoiceRequest markInvoiceRequest = new MarkInvoiceRequest()
                {
                    REQUEST_HEADER = _requestHeader,
                    MARK = new MarkInvoiceRequestMARK()
                    {
                        valueSpecified = true,
                        value = MarkInvoiceRequestMARKValue.UNREAD,
                        INVOICE = new INVOICE[]
                                    {
                                        new INVOICE()
                                        {
                                            ID = "EDM2015000000039",
                                        },
                                        new INVOICE()
                                        {
                                            ID = "EDM2015000000038",
                                        },
                                        new INVOICE()
                                        {
                                            ID = "EDM2015000000037",
                                        }
                                    },
                    }
                };

                MarkInvoiceResponse getInvoiceStatusResponse = _service.MarkInvoice(markInvoiceRequest);

                logger.Info("Ok");
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
            }
        }

        #endregion


        // gelen ticari faturaya yanıt gönderimi
        #region InvoiceResponse

        /// <summary>
        /// gelen ticari faturanın KABUL edilmesi
        /// </summary>
        /// <param name="title"></param>
        public void Current_SendInvoiceResponseWithServerSign_KABUL(string faturaNo)
        {
            try
            {

                //byte[] appresionsebytes = 

                logger.Info("SendInvoiceResponseWithServerSign for KABUL test...");

                SendInvoiceResponseWithServerSignRequest sendInvoiceResponseWithServerSignRequest
                    = new SendInvoiceResponseWithServerSignRequest()
                    {
                        REQUEST_HEADER = _requestHeader,
                        STATUS = "KABUL",
                        INVOICE = new INVOICE[] {
                                                new INVOICE()
                                                {
                                                    ID = faturaNo.ToString().Trim(),
                                                },
                                            },
                    };

                SendInvoiceResponseWithServerSignResponse sendInvoiceResponseWithServerSignResponse
                    = _service.SendInvoiceResponseWithServerSign(sendInvoiceResponseWithServerSignRequest);

                logger.Info("Ok");
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
            }
        }

        /// <summary>
        /// gelen ticari faturanın RED edilmesi
        /// </summary>
        /// <param name="title"></param>
        public void Current_SendInvoiceResponseWithServerSign_RED()
        {
            try
            {
                logger.Info("SendInvoiceResponseWithServerSign for RED test...");

                SendInvoiceResponseWithServerSignRequest sendInvoiceResponseWithServerSignRequest
                    = new SendInvoiceResponseWithServerSignRequest()
                    {
                        REQUEST_HEADER = _requestHeader,
                        DESCRIPTION = new string[] {
                                                    "Fatura birim kodu bulunamadı: Fatura No: EBD2015000000016 Fatura Reddediliyor.",
                                            },
                        STATUS = "RED",
                        INVOICE = new INVOICE[] {
                                                new INVOICE()
                                                {
                                                    //ID = "EBD2015000000016",
                                                    //UUID = "6703b82a-a59f-40de-ac08-1603c651ff49",
                                                    UUID = "36755A18-6d5f-4e01-98a4-d5720F4C01b4",
                                                },
                                            },
                    };

                SendInvoiceResponseWithServerSignResponse sendInvoiceResponseWithServerSignResponse
                    = _service.SendInvoiceResponseWithServerSign(sendInvoiceResponseWithServerSignRequest);

                logger.Info("Ok");
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
            }
        }

        #endregion


        // e-Arşiv fatura iptali
        #region e-Arşiv fatura iptal

        public void Current_CancelEarchieveInvoice()
        {
            try
            {
                logger.Info(@"Current_CancelEarchieveInvoice test...");

                CancelInvoiceRequest cancelInvoiceRequest = new CancelInvoiceRequest()
                {
                    REQUEST_HEADER = _requestHeader,
                    INVOICE = new INVOICE[]
                                    {
                                        new INVOICE()
                                        {
                                            ID = "II22016000000062",
                                        },
                                    },
                };

                CancelInvoiceResponse getInvoiceStatusResponse = _service.CancelInvoice(cancelInvoiceRequest);

                logger.Info("Ok");

            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
            }
        }


        #endregion


        // e-fatura'ya kayıtlı mükellef bilgilerine erişim 
        #region GetUserList, CheckUser, GetUserListBinary

        /// <summary>
        /// EDM web servis GİB e-fatura mükellef tam Listesini alma
        /// </summary>
        public void Current_GetUserList()
        {
            try
            {
                logger.Info("GetUserList test...");
                FormValues.gibUserList = new GIBUSER[10];
                GetUserListRequest getUserListRequest = new GetUserListRequest();
                getUserListRequest.REQUEST_HEADER = _requestHeader;
                //getUserListRequest.REGISTER_TIME_START = DateTime.Now.AddMonths(-6);
                //getUserListRequest.REGISTER_TIME_STARTSpecified = true;
                GetUserListResponse getUserListResponse = _service.GetUserList(getUserListRequest);
                logger.Info("{0} adet, OK", getUserListResponse.Items.Count());
                GIBUSER[] gibusers = getUserListResponse.Items;
                // yalnızca PK ları istenirse.
                GIBUSER[] gibuserPKs = gibusers.Where(t => t.UNIT == "PK").ToArray();
                FormValues.gibUserList = gibuserPKs;
                if (gibuserPKs != null) FormValues.gibUserListEnter = "Yükleme başarıyla tamamlandı.";
                if (gibuserPKs == null) FormValues.gibUserListEnter = "Yükleme gerçekleştirilemiyor.";
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
                FormValues.gibUserListEnter = "Yükleme başarısız.";
                FormValues.ifHaveError = requesterror;
                FormValues.ifHaveErrorDetail = detail;
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                FormValues.gibUserListEnter = "Yükleme başarısız.";
                FormValues.ifHaveError = fex;
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                FormValues.gibUserListEnter = "Yükleme başarısız.";
                FormValues.ifHaveError = ex;
            }
        }

        /// <summary>
        /// Vergi Kimlik No ile e-fatura mükellefi arama
        /// </summary>
        /// <param name="identifier"></param>
        public List<FormParameters> Current_CheckUser_byIdentifier(string vkn)
        {
            logger.Info("Current_CheckUser_byIdentifier test...");
            List<FormParameters> sendFormParametersList = new List<FormParameters>();
            FormParameters sendFormParametersEntity = new FormParameters();

            try
            {
                FormValues.vknUser = new GIBUSER[10];

                CheckUserRequest checkUserRequest = new CheckUserRequest();

                checkUserRequest.USER = new GIBUSER();
                checkUserRequest.REQUEST_HEADER = _requestHeader;
                checkUserRequest.USER.IDENTIFIER = vkn;

                //GIBUSER[] gibusers = _service.CheckUser(checkUserRequest);
                var gibusersResponseMeasure = Measure<CheckUserRequest, GIBUSER[]>(_service.CheckUser, checkUserRequest);
                GIBUSER[] gibusers = (GIBUSER[])gibusersResponseMeasure[0];
                long logoutFunctionMs = (long)gibusersResponseMeasure[1];
                string logoutFunctionName = (string)gibusersResponseMeasure[2];

                if (gibusers != null)
                {
                    sendFormParametersEntity.ActionElapsedMs = logoutFunctionMs;
                    sendFormParametersEntity.ActionName = logoutFunctionName;
                    FormValues.checkUserEnter = "Kullanıcı arama tamamlandı..";
                    FormValues.vknUser = gibusers;
                    FormValues.vknUser[0].IDENTIFIER.ToString();
                }
                return sendFormParametersList;
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;
                MessageBox.Show(detail);
                MessageBox.Show(requesterror.ToString());
                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
                FormValues.checkUserEnter = "Kullanıcı arama hatalı..";
                FormValues.ifHaveError = requesterror;
                FormValues.ifHaveErrorDetail = detail;
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                FormValues.checkUserEnter = "Kullanıcı arama hatalı..";
                FormValues.ifHaveError = fex;


            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                FormValues.checkUserEnter = "Kullanıcı arama hatalı..";
                FormValues.ifHaveError = ex;
            }
            finally
            {
                sendFormParametersList.Add(sendFormParametersEntity);
            }
            return sendFormParametersList;

        }

        /// <summary>
        /// Firma Ünvanı ile  e-fatura mükellefi arama
        /// </summary>
        /// <param name="title">Firma Ünvanı</param>
        public void Current_CheckUser_byTitle(string title)
        {
            try
            {

                logger.Info("CheckUser byTitle test...");

                CheckUserRequest checkUserRequest = new CheckUserRequest();
                checkUserRequest.USER = new GIBUSER();
                checkUserRequest.USER.TITLE = title;
                checkUserRequest.REQUEST_HEADER = _requestHeader;

                GIBUSER[] gibusers = _service.CheckUser(checkUserRequest);

                logger.Info("{0} adet, OK", gibusers.Count());
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
                //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
                //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
                //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
                //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
                //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
                //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
                //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
            }
        }

        /// <summary>
        /// GİB e-fatura mükllef listesini xml içerik zipli olarak alınır
        /// </summary>
        /// <param name="title"></param>
        //public void Current_GetUserListBinary_XML()
        //{
        //    try
        //    {
        //        logger.Info("GetUserListBinary XML test...");

        //        GetUserListBinaryRequest getUserListBinaryRequest = new GetUserListBinaryRequest();
        //        getUserListBinaryRequest.TYPE = GetUserListBinaryRequestTYPE.XML;
        //        getUserListBinaryRequest.REQUEST_HEADER = _requestHeader;

        //        GetUserListBinaryResponse getUserListBinaryResponse = _service.GetUserListBinary(getUserListBinaryRequest);
        //        byte[] userlistdata = getUserListBinaryResponse.Item.Value;
        //        File.WriteAllBytes(Path.Combine(_path, "GetUserListBinary_xml.zip"), userlistdata);
        //        string userliststring = System.Text.Encoding.UTF8.GetString(userlistdata);
        //        logger.Info("{0} bytes, OK", userlistdata.Length);
        //    }
        //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
        //    {
        //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
        //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

        //        logger.Error("FaultException with RequestFault catched:");
        //        logger.Error("requestError XML:" + detail);
        //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
        //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
        //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
        //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
        //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
        //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
        //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
        //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
        //    }
        //    catch (System.ServiceModel.FaultException fex)
        //    {
        //        logger.Error("FaultException catched:");
        //        logger.Error("FaultException fault code:" + fex.Code);
        //        logger.Error("FaultException fault details:" + fex.Data);
        //        logger.Error("FaultException fault message:" + fex.Message);
        //        logger.Error("FaultException fault reason:" + fex.Reason);
        //        logger.Error("FaultException :" + fex.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Exception catched:");
        //        logger.Error("Exception data:" + ex.Data);
        //        logger.Error("Exception message:" + ex.ToString());
        //    }
        //}

        ///// <summary>
        ///// e-fatura mükellef listesi .CSV içeriği şeklinde ve zipli olarak alınır
        ///// </summary>
        ///// <param name="title"></param>
        //public void Current_GetUserListBinary_CSV()
        //{
        //    try
        //    {
        //        logger.Info("GetUserListBinary CSV test...");

        //        GetUserListBinaryRequest getUserListBinaryRequest = new GetUserListBinaryRequest();
        //        getUserListBinaryRequest.TYPE = GetUserListBinaryRequestTYPE.CSV;
        //        getUserListBinaryRequest.REQUEST_HEADER = _requestHeader;

        //        GetUserListBinaryResponse getUserListBinaryResponse = _service.GetUserListBinary(getUserListBinaryRequest);
        //        byte[] userlistdata = getUserListBinaryResponse.Item.Value;
        //        File.WriteAllBytes(Path.Combine(_path, "GetUserListBinary_csv.zip"), userlistdata);
        //        string userliststring = System.Text.Encoding.UTF8.GetString(userlistdata);
        //        logger.Info("{0} bytes, OK", userlistdata.Length);
        //    }
        //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
        //    {
        //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
        //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

        //        logger.Error("FaultException with RequestFault catched:");
        //        logger.Error("requestError XML:" + detail);
        //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
        //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
        //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
        //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
        //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
        //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
        //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
        //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
        //    }
        //    catch (System.ServiceModel.FaultException fex)
        //    {
        //        logger.Error("FaultException catched:");
        //        logger.Error("FaultException fault code:" + fex.Code);
        //        logger.Error("FaultException fault details:" + fex.Data);
        //        logger.Error("FaultException fault message:" + fex.Message);
        //        logger.Error("FaultException fault reason:" + fex.Reason);
        //        logger.Error("FaultException :" + fex.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Exception catched:");
        //        logger.Error("Exception data:" + ex.Data);
        //        logger.Error("Exception message:" + ex.ToString());
        //    }
        //}

        #endregion


        #region Invoice Serail

        public void GetInvoiceSerila()
        {
            INVOICESERIALLIST[] invoiceseriallists = new INVOICESERIALLIST[0];
            try
            {
                GetInvoiceSerialRequest getInvoiceRequest = new GetInvoiceSerialRequest();
                GetInvoiceSerialResponse getInvoiceSerialResponse = new GetInvoiceSerialResponse();
                getInvoiceRequest.REQUEST_HEADER = _requestHeader;
                getInvoiceSerialResponse = _service.GetInvoiceSerial(getInvoiceRequest);
                logger.Info("{0} adet, OK", getInvoiceSerialResponse.Items.Count());

                invoiceseriallists = getInvoiceSerialResponse.Items;

                // bu yıl olanları getirir.
                invoiceseriallists = invoiceseriallists.Where(t => t.YEAR == DateTime.Now.Year).ToArray();
                if (invoiceseriallists != null)
                {
                    EFatura.ListSerial.Clear();
                    foreach (INVOICESERIALLIST serial in invoiceseriallists)
                    {
                        EFatura.ListSerial.Add(serial.INVOICESERIALCODE.ToString() + "-" + serial.INVOİCESENDTYPE.ToString());
                    }
                }
            }
            catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
            {
                string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
                var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

                logger.Error("FaultException with RequestFault catched:");
                logger.Error("requestError XML:" + detail);
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = requesterror;
                FormValues.ifHaveErrorDetail = detail;

            }
            catch (System.ServiceModel.FaultException fex)
            {
                logger.Error("FaultException catched:");
                logger.Error("FaultException fault code:" + fex.Code);
                logger.Error("FaultException fault details:" + fex.Data);
                logger.Error("FaultException fault message:" + fex.Message);
                logger.Error("FaultException fault reason:" + fex.Reason);
                logger.Error("FaultException :" + fex.ToString());
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = fex;

            }
            catch (Exception ex)
            {
                logger.Error("Exception catched:");
                logger.Error("Exception data:" + ex.Data);
                logger.Error("Exception message:" + ex.ToString());
                FormValues.getInvoiceEnter = "Faturalar indirilemedi.";
                FormValues.ifHaveError = ex;

            }
        }
        #endregion

        // fatura oluştur, gönder yardımcı fonksiyonlar
        #region Send invoice

        private string xmlSerializeObject(object Object)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(REQUEST_ERRORType));
            StringWriter SW = new StringWriter();
            serializer.Serialize(SW, Object);
            return SW.ToString();
        }

        double tAraToplam = 0;
        string tAraToplam_F
        {
            get { return String.Format("{0:n2}", tAraToplam); }
            set { tAraToplam = Convert.ToDouble(value); }
        }
        double tKdvtutar = 0;
        double tIskToplam = 0;
        string tKdvtutar_F
        {
            get { return String.Format("{0:n2}", tKdvtutar); }
            set { tKdvtutar = Convert.ToDouble(value); }
        }
        double tGenelToplam = 0;
        string tGenelToplam_F
        {
            get { return String.Format("{0:n2}", tGenelToplam); }
            set { tGenelToplam = Convert.ToDouble(value); }
        }
        double tIskonto = 0;
        string tIskonto_F
        {
            get { return String.Format("{0:n2}", tIskonto); }
            set { tIskonto = Convert.ToDouble(value); }
        }
        double toplamfiyat = 0;
        private string yaziylaTutar = "";
        private DataTable dt;
        private void ana_toplamlari_hesaplat(DataTable dgTicaret)
        {
            dt = new DataTable();
            try
            {

                tAraToplam = 0;
                tKdvtutar = 0;
                tGenelToplam = 0;
                tIskToplam = 0;
                for (int j = 0; j < dgTicaret.Rows.Count; j++)
                {
                    tAraToplam = tAraToplam + Convert.ToDouble(dgTicaret.Rows[j]["AraTop"]);
                    tKdvtutar = tKdvtutar + Convert.ToDouble(dgTicaret.Rows[j]["TopKDV"]);
                    tIskToplam = tIskToplam + Convert.ToDouble(dgTicaret.Rows[j]["TOPISK"]);
                }

                tAraToplam_F = tAraToplam.ToString();
                tKdvtutar_F = tKdvtutar.ToString();
                tGenelToplam_F = (tAraToplam + tKdvtutar - tIskonto).ToString();
                toplamfiyat = 0;
                dt = dgTicaret;
                string[] metin = tGenelToplam.ToString().Split(',');
                yaziylaTutar = "Yalnızca " + islemler.sayiyiYaziyacevir(metin[0].ToString()) + "  TL  ";
                if (metin.Length > 1) yaziylaTutar = yaziylaTutar + islemler.sayiyiYaziyacevir(metin[1].ToString()) + "  Kr. ";
                yaziylaTutar = yaziylaTutar + " ";
            }
            catch (Exception ex)
            {
            }
        }
        void hesaplariYap(DataTable dgTicaret)
        {
            try
            {
                double gecici_aratoplam = 0;
                double gecici_kdvtoplam = 0;
                double _AraTop = 0;
                dgTicaret.Columns.Add("TOPISK");
                dgTicaret.Columns.Add("TopKdv");
                dgTicaret.Columns.Add("AraTop");
                dgTicaret.Columns.Add("Tutar");
                for (int i = 0; i < dgTicaret.Rows.Count; i++)
                {
                    _AraTop = Math.Abs(Convert.ToDouble(dgTicaret.Rows[i]["miktar"])) * Convert.ToDouble(dgTicaret.Rows[i]["birimFiyat"]) * Convert.ToDouble(1);
                    dgTicaret.Rows[i]["TOPISK"] = _AraTop;

                    string kolon2 = dgTicaret.Rows[i]["kdvTipi"].ToString();
                    if (kolon2.ToString() == "Dahil")
                    {
                        double kdv = Convert.ToDouble(dgTicaret.Rows[i]["kdv"]);
                        gecici_aratoplam = _AraTop / (1 + kdv / 100);

                        dgTicaret.Rows[i]["TOPISK"] = gecici_aratoplam;
                        gecici_aratoplam = gecici_aratoplam - gecici_aratoplam * Convert.ToDouble(dgTicaret.Rows[i]["isk1"]) / 100;
                        dgTicaret.Rows[i]["TOPISK"] = Convert.ToDouble(dgTicaret.Rows[i]["TOPISK"]) - gecici_aratoplam;
                        gecici_kdvtoplam = gecici_aratoplam * (1 + kdv / 100) - gecici_aratoplam;
                    }
                    else
                    {
                        _AraTop = _AraTop - _AraTop * Convert.ToDouble(dgTicaret.Rows[i]["isk1"]) / 100;

                        dgTicaret.Rows[i]["TOPISK"] = Convert.ToDouble(dgTicaret.Rows[i]["TOPISK"]) - _AraTop;
                        gecici_aratoplam = _AraTop;
                        gecici_kdvtoplam = (_AraTop * (1 + Convert.ToDouble(dgTicaret.Rows[i]["kdv"]) / 100)) - _AraTop;
                    }
                    dgTicaret.Rows[i]["TopKdv"] = gecici_kdvtoplam.ToString("F2");
                    dgTicaret.Rows[i]["AraTop"] = gecici_aratoplam.ToString("F2");
                    string tutar = (gecici_aratoplam + gecici_kdvtoplam).ToString("F2");
                    dgTicaret.Rows[i]["Tutar"] = tutar;
                }
                ana_toplamlari_hesaplat(dgTicaret);

            }


            catch (Exception hata)
            {
                MessageBox.Show("Hata Metni:" + hata.Message, firma.programAdi);
            }
        }


        public string CreateInvoiceTypeDataTable(string aliciGIB, string faturaNo, Int64 cariid, DataTable dtTicaret,
            DateTime IslemTarihi)
        {
            var cari = cariBilgileri.bul_cariid(cariid);
            var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid)
                .FirstOrDefault();
            if (cari == null) return "";
            if (adresListesi == null)
            {
                MessageBox.Show("Hatalı Adres Lütfen cariyi silip tekrardan kayıt ediniz");
                return "";
            }
            else cari.vergiNo = adresListesi.vergiNo;

            List<hm.common.Ubltr.Invoice21.InvoiceType> ublinvoicelist =
                new List<hm.common.Ubltr.Invoice21.InvoiceType>();

            string fileName = "";
            // create and return invoice of type InvoiceType
            hm.common.Ubltr.Invoice21.InvoiceType ublinvoice = new hm.common.Ubltr.Invoice21.InvoiceType();
            INVOICEHEADER invoiceheader = new INVOICEHEADER();

            // if (aliciGIB.Trim().Length > 0)
            //     invoiceheader.EARCHIVE = false;
            hesaplariYap(dtTicaret);

            #region Header

            ublinvoice.UBLExtensions = new hm.common.Ubltr.Invoice21.UBLExtensionType[]
            {
                new hm.common.Ubltr.Invoice21.UBLExtensionType()
                {
                    ExtensionContent = new hm.common.Ubltr.Invoice21.ExtensionContentType()
                    {
                    }
                },
            };

            ublinvoice.UBLVersionID = new hm.common.Ubltr.Invoice21.UBLVersionIDType()
            {
                Value = "2.1"
            };

            ublinvoice.CustomizationID = new hm.common.Ubltr.Invoice21.CustomizationIDType()
            {
                Value = "TR1.2"
            };
            ublinvoice.ProfileID = new hm.common.Ubltr.Invoice21.ProfileIDType()
            {
                Value = aliciGIB.Trim().Length == 0 ? "EARSIVFATURA" : "TICARIFATURA"
            };

            ublinvoice.ID = new hm.common.Ubltr.Invoice21.IDType()
            {
                Value = faturaNo

            };

            ublinvoice.CopyIndicator = new hm.common.Ubltr.Invoice21.CopyIndicatorType()
            {
                Value = false
            };

            ublinvoice.UUID = new hm.common.Ubltr.Invoice21.UUIDType()
            {
                Value = Guid.NewGuid().ToString()
            };

            ublinvoice.IssueDate = new hm.common.Ubltr.Invoice21.IssueDateType()
            {
                Value = IslemTarihi
            };

            ublinvoice.InvoiceTypeCode = new hm.common.Ubltr.Invoice21.InvoiceTypeCodeType()
            {
                Value = "SATIS"
            };


            List<hm.common.Ubltr.Invoice21.NoteType> notes = new List<hm.common.Ubltr.Invoice21.NoteType>();
            notes.Add(new hm.common.Ubltr.Invoice21.NoteType()
            {
                Value = yaziylaTutar
            });
            ublinvoice.Note = notes.ToArray();

            ublinvoice.DocumentCurrencyCode = new hm.common.Ubltr.Invoice21.DocumentCurrencyCodeType()
            {
                Value = "TRY"
            };

            #endregion

            #region Signature

            //    ublinvoice.Signature = new hm.common.Ubltr.Invoice21.SignatureType1[]
            //{
            //    new hm.common.Ubltr.Invoice21.SignatureType1()
            //    {
            //        ID = new hm.common.Ubltr.Invoice21.IDType()
            //        {
            //            schemeID = "VKN_TCKN",
            //            Value = "3230512384"
            //        },
            //        SignatoryParty = new hm.common.Ubltr.Invoice21.PartyType()
            //        {
            //            PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
            //            {
            //                new hm.common.Ubltr.Invoice21.PartyIdentificationType()
            //                {
            //                    ID = new hm.common.Ubltr.Invoice21.IDType()
            //                    {
            //                        schemeID = "VKN",
            //                        Value = "3230512384"
            //                    }
            //                }
            //            },
            //            PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
            //            {
            //                Name = new hm.common.Ubltr.Invoice21.NameType1()
            //                {
            //                    Value = null
            //                },
            //            },
            //            PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
            //            {
            //                TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
            //                {
            //                    Name = new hm.common.Ubltr.Invoice21.NameType1()
            //                    {
            //                        Value = null
            //                    }
            //                }
            //            },
            //            PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
            //            {
            //                StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
            //                {
            //                    Value = "Cansızoğlu işhanı No:7/35 Mecidiyeköy"
            //                },
            //                CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
            //                {
            //                    Value    = "Şişli"
            //                },
            //                CityName = new hm.common.Ubltr.Invoice21.CityNameType()
            //                {
            //                    Value = "İstanbul"
            //                },
            //                Country = new hm.common.Ubltr.Invoice21.CountryType()
            //                {
            //                    IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
            //                    {
            //                        Value = "TR"
            //                    },
            //                    Name = new hm.common.Ubltr.Invoice21.NameType1()
            //                    {
            //                        Value  = "Türkiye"
            //                    }
            //                }
            //            }
            //        },
            //        DigitalSignatureAttachment = new hm.common.Ubltr.Invoice21.AttachmentType()
            //        {
            //            ExternalReference = new hm.common.Ubltr.Invoice21.ExternalReferenceType()
            //            {
            //                URI = new hm.common.Ubltr.Invoice21.URIType()
            //                {
            //                    Value =  "#Signature_" + ublinvoice.ID.Value 
            //                }
            //            }
            //        }
            //    }
            //};

            #endregion

            #region Default Fatura Dizaynı (xslt)

            ublinvoice.AdditionalDocumentReference = new hm.common.Ubltr.Invoice21.DocumentReferenceType[]
            {
                new hm.common.Ubltr.Invoice21.DocumentReferenceType()
                {
                    ID = new hm.common.Ubltr.Invoice21.IDType()
                    {
                        Value = fileName = Guid.NewGuid().ToString()
                    },
                    IssueDate = new hm.common.Ubltr.Invoice21.IssueDateType()
                    {
                        Value = IslemTarihi
                    },

                    //Attachment = new hm.common.Ubltr.Invoice21.AttachmentType()
                    //{
                    //    EmbeddedDocumentBinaryObject  = new hm.common.Ubltr.Invoice21.EmbeddedDocumentBinaryObjectType()
                    //    {
                    //        filename = ublinvoice.ID.Value + ".xslt",
                    //        characterSetCode ="UTF-8" ,
                    //        encodingCode="Base64",
                    //        mimeCode="application/xml",
                    //        Value = File.ReadAllBytes("eFatura.xslt")
                    //    }
                    //}
                }

            };


            #endregion

            #region Gönderen Bilgileri

            if (EFatura.VergiNo.Length == 11)
            {
                #region Şahıs ise

                ublinvoice.AccountingSupplierParty = new hm.common.Ubltr.Invoice21.SupplierPartyType()
                {
                    Party = new hm.common.Ubltr.Invoice21.PartyType()
                    {
                        PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
                        {
                            new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                            {
                                ID = new hm.common.Ubltr.Invoice21.IDType()
                                {
                                    schemeID = "TCKN",
                                    Value = EFatura.VergiNo
                                }
                            },
                            new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                            {
                                ID = new hm.common.Ubltr.Invoice21.IDType()
                                {
                                    schemeID = "MERSISNO",
                                    Value = EFatura.MersisNo
                                }
                            },
                            new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                            {
                                ID = new hm.common.Ubltr.Invoice21.IDType()
                                {
                                    schemeID = "TICARETSICILNO",
                                    Value = EFatura.TicaretSicilNo
                                }
                            }
                        },
                        Person = new PersonType()
                        {
                            FirstName = new FirstNameType()
                            {
                                Value = EFatura.FirmaAdi
                            },
                            FamilyName = new FamilyNameType()
                            {
                                Value = EFatura.FirmaAdi
                            },
                        },

                        PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
                        {
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = EFatura.FirmaAdi
                            }
                        },
                        PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
                        {
                            StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
                            {
                                Value = EFatura.Adres.Split(',')[0]
                            },
                            CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
                            {
                                Value = EFatura.Adres.Split(',')[1]
                            },
                            CityName = new hm.common.Ubltr.Invoice21.CityNameType()
                            {
                                Value = EFatura.Adres.Split(',')[2]
                            },
                            Country = new hm.common.Ubltr.Invoice21.CountryType()
                            {
                                IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
                                {
                                    Value = "TR"
                                },
                                Name = new hm.common.Ubltr.Invoice21.NameType1()
                                {
                                    Value = "Türkiye"
                                }
                            }
                        },
                        PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
                        {
                            TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
                            {
                                Name = new hm.common.Ubltr.Invoice21.NameType1()
                                {
                                    Value = EFatura.VergiDairesi
                                }
                            }
                        },
                        WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
                        {
                            Value = ""
                        },
                        Contact = new hm.common.Ubltr.Invoice21.ContactType()
                        {
                            Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
                            {
                                Value = ""
                            }
                        },
                    }
                };

                #endregion
            }
            else
            {
                #region Firma

                ublinvoice.AccountingSupplierParty = new hm.common.Ubltr.Invoice21.SupplierPartyType()
                {
                    Party = new hm.common.Ubltr.Invoice21.PartyType()
                    {
                        PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
                        {
                            new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                            {
                                ID = new hm.common.Ubltr.Invoice21.IDType()
                                {
                                    schemeID = "VKN",
                                    Value = EFatura.VergiNo
                                }
                            },
                            new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                            {
                                ID = new hm.common.Ubltr.Invoice21.IDType()
                                {
                                    schemeID = "MERSISNO",
                                    Value = EFatura.MersisNo
                                }
                            },
                            new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                            {
                                ID = new hm.common.Ubltr.Invoice21.IDType()
                                {
                                    schemeID = "TICARETSICILNO",
                                    Value = EFatura.TicaretSicilNo
                                }
                            }
                        },
                        PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
                        {
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = EFatura.FirmaAdi
                            }
                        },
                        PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
                        {
                            StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
                            {
                                Value = EFatura.Adres.Split(',')[0]
                            },
                            CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
                            {
                                Value = EFatura.Adres.Split(',')[1]
                            },
                            CityName = new hm.common.Ubltr.Invoice21.CityNameType()
                            {
                                Value = EFatura.Adres.Split(',')[2]
                            },
                            Country = new hm.common.Ubltr.Invoice21.CountryType()
                            {
                                IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
                                {
                                    Value = "TR"
                                },
                                Name = new hm.common.Ubltr.Invoice21.NameType1()
                                {
                                    Value = "Türkiye"
                                }
                            }
                        },
                        PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
                        {
                            TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
                            {
                                Name = new hm.common.Ubltr.Invoice21.NameType1()
                                {
                                    Value = EFatura.VergiDairesi
                                }
                            }
                        },
                        WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
                        {
                            Value = ""
                        },
                        Contact = new hm.common.Ubltr.Invoice21.ContactType()
                        {
                            Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
                            {
                                Value = ""
                            }
                        },
                    }
                };


                #endregion
            }

            #endregion

            #region Alıcı Bilgileri

            //if (aliciGIB.Trim().Length == 0)
            //{
            //    ublinvoice.AccountingCustomerParty = GetTC(aliciGIB, cariid);
            //}
            //else

            hm.common.Ubltr.Invoice21.CustomerPartyType accountingCustomerParty = new hm.common.Ubltr.Invoice21.CustomerPartyType();
            PartyType party = new hm.common.Ubltr.Invoice21.PartyType();
            party.PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
            {
                    new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                    {
                        ID = new hm.common.Ubltr.Invoice21.IDType()
                        {
                            schemeID = cari.vergiNo.Length == 10 ? "VKN" : "TCKN",
                            Value = cari.vergiNo
                        }
                    },
            };

            #region GİB etiketi yok ise

            if (aliciGIB.Trim().Length == 0)
            {

                if (cari.vergiNo.Length == 10)
                {
                    party.PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
                    {
                        Name = new hm.common.Ubltr.Invoice21.NameType1()
                        {
                            Value = cari.adi
                        }
                    };
                }
                party.Person = new PersonType()
                {
                    FirstName = new FirstNameType()
                    {
                        Value = cari.adi
                    },
                    FamilyName = new FamilyNameType()
                    {
                        Value = cari.soyadi.Length == 0 ? cari.adi : cari.soyadi
                    },
                };
                party.PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
                {
                    StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
                    {
                        Value = adresListesi.adres
                    },
                    CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
                    {
                        Value = adresListesi.boldeAdi
                    },
                    CityName = new hm.common.Ubltr.Invoice21.CityNameType()
                    {
                        Value = adresListesi.boldeAdi
                    },
                    Country = new hm.common.Ubltr.Invoice21.CountryType()
                    {
                        IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
                        {
                            Value = "TR"
                        },
                        Name = new hm.common.Ubltr.Invoice21.NameType1()
                        {
                            Value = "Türkiye"
                        }
                    }
                };
                party.PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
                {
                    TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
                    {
                        Name = new hm.common.Ubltr.Invoice21.NameType1()
                        {
                            Value = adresListesi.vergiDaire
                        }
                    }
                };
                party.WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
                {
                    Value = ""
                };
                party.Contact = new hm.common.Ubltr.Invoice21.ContactType()
                {
                    Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
                    {
                        Value = adresListesi.gsm
                    }
                };
            }
            #endregion

            #region GİB etiketi var ise
            else
            {
                party.PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
                {
                    Name = new hm.common.Ubltr.Invoice21.NameType1()
                    {
                        Value = cari.adi
                    }
                };
                if (cari.vergiNo.Trim().Length == 11)
                {
                    party.Person = new PersonType()
                    {
                        FirstName = new FirstNameType()
                        {
                            Value = cari.adi
                        },
                        FamilyName = new FamilyNameType()
                        {
                            Value = cari.soyadi.Length == 0 ? cari.adi : cari.soyadi
                        },
                    };
                }
            }
            #endregion

            #region E-arşiv E-fatura ortak

            party.PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
            {
                StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
                {
                    Value = adresListesi.adres
                },
                CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
                {
                    Value = adresListesi.boldeAdi
                },
                CityName = new hm.common.Ubltr.Invoice21.CityNameType()
                {
                    Value = adresListesi.boldeAdi
                },
                Country = new hm.common.Ubltr.Invoice21.CountryType()
                {
                    IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
                    {
                        Value = "TR"
                    },
                    Name = new hm.common.Ubltr.Invoice21.NameType1()
                    {
                        Value = "Türkiye"
                    }
                }
            };
            party.PartyTaxScheme = new PartyTaxSchemeType()
            {
                TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
                {
                    Name = new hm.common.Ubltr.Invoice21.NameType1()
                    {
                        Value = adresListesi.vergiDaire
                    }
                }
            };
            party.WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
            {
                Value = ""
            };
            party.Contact = new hm.common.Ubltr.Invoice21.ContactType()
            {
                Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
                {
                    Value = adresListesi.gsm
                },
                ElectronicMail = new ElectronicMailType()
                {
                    Value = adresListesi.email
                },
            };

            #endregion

            accountingCustomerParty.Party = party;
            ublinvoice.AccountingCustomerParty = accountingCustomerParty;

            #endregion

            #region Ödeme Bilgileri

            ublinvoice.PaymentTerms = new hm.common.Ubltr.Invoice21.PaymentTermsType()
            {
                PaymentDueDate = new hm.common.Ubltr.Invoice21.PaymentDueDateType()
                {
                    Value = IslemTarihi,
                },
                Note = new hm.common.Ubltr.Invoice21.NoteType()
                {
                    Value = EFatura.Aciklama
                },
            };

            #endregion

            #region Total Taxes

            ublinvoice.TaxTotal = new hm.common.Ubltr.Invoice21.TaxTotalType[]
            {
                    new hm.common.Ubltr.Invoice21.TaxTotalType()
                    {
                        TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
                        {
                            currencyID = "TRY",
                            Value = Convert.ToDecimal(tKdvtutar)
                        },
                        TaxSubtotal = new hm.common.Ubltr.Invoice21.TaxSubtotalType[]
                        {
                            new hm.common.Ubltr.Invoice21.TaxSubtotalType()
                            {
                                TaxableAmount = new hm.common.Ubltr.Invoice21.TaxableAmountType()
                                {
                                    currencyID = "TRY",
                                    Value = Convert.ToDecimal(tAraToplam)
                                },
                                TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
                                {
                                    currencyID = "TRY",
                                    Value = Convert.ToDecimal(tKdvtutar)
                                },
                                CalculationSequenceNumeric =
                                    new hm.common.Ubltr.Invoice21.CalculationSequenceNumericType()
                                    {
                                        Value = 1
                                    },
                                Percent = new hm.common.Ubltr.Invoice21.PercentType1()
                                {
                                    Value = 18
                                },
                                TaxCategory = new hm.common.Ubltr.Invoice21.TaxCategoryType()
                                {
                                    TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
                                    {
                                        Name = new hm.common.Ubltr.Invoice21.NameType1()
                                        {
                                            Value = "KDV GERCEK"
                                        },
                                        TaxTypeCode = new hm.common.Ubltr.Invoice21.TaxTypeCodeType()
                                        {
                                            Value = "0015"
                                        }
                                    }
                                }
                            }
                        }
                    }
            };


            #endregion

            #region Invoice.LegalMonetaryTotal

            ublinvoice.LegalMonetaryTotal = new hm.common.Ubltr.Invoice21.MonetaryTotalType()
            {
                LineExtensionAmount = new hm.common.Ubltr.Invoice21.LineExtensionAmountType()
                {
                    currencyID = "TRY",
                    Value = Convert.ToDecimal(tAraToplam)
                },
                TaxExclusiveAmount = new hm.common.Ubltr.Invoice21.TaxExclusiveAmountType()
                {
                    currencyID = "TRY",
                    Value = Convert.ToDecimal(tAraToplam)
                },
                TaxInclusiveAmount = new hm.common.Ubltr.Invoice21.TaxInclusiveAmountType()
                {
                    currencyID = "TRY",
                    Value = Convert.ToDecimal(tGenelToplam)
                },
                AllowanceTotalAmount = new hm.common.Ubltr.Invoice21.AllowanceTotalAmountType()
                {
                    currencyID = "TRY",
                    Value = 0
                },
                PayableAmount = new hm.common.Ubltr.Invoice21.PayableAmountType()
                {
                    currencyID = "TRY",
                    Value = Convert.ToDecimal(tGenelToplam)
                },
            };

            #endregion

            #region invoice lines


            List<hm.common.Ubltr.Invoice21.InvoiceLineType> invoiceLines
                = new List<hm.common.Ubltr.Invoice21.InvoiceLineType>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string birim = dt.Rows[i]["birim"].ToString();
                if (birim == null)
                    birim = "C62";
                if (birim.ToUpper().Contains("ADET"))
                    birim = "C62";
                else if (birim.ToUpper().Contains("KG"))
                    birim = "KGM";
                else if (birim.ToUpper().Equals("METRE"))
                    birim = "MTR";
                else if (birim.ToUpper().Contains("L"))
                    birim = "LTR";
                else if (birim.ToUpper().Contains("P"))
                    birim = "PA";
                else if (birim.ToUpper().Contains("K"))
                    birim = "BX";
                else if (birim.ToUpper().Contains("S"))
                    birim = "CMT";
                else if (birim.ToUpper().Contains("METREKÜP"))
                    birim = "MTQ";
                else if (birim.ToUpper().Contains("METREKARE") | birim.ToUpper().Contains("M2"))
                    birim = "MTK";


                hm.common.Ubltr.Invoice21.InvoiceLineType invoiceLine
                    = new hm.common.Ubltr.Invoice21.InvoiceLineType()
                    {
                        ID = new hm.common.Ubltr.Invoice21.IDType()
                        {
                            Value = (i + 1).ToString()
                        },
                        InvoicedQuantity = new hm.common.Ubltr.Invoice21.InvoicedQuantityType()
                        {
                            unitCode = birim,
                            Value = Math.Abs(Convert.ToDecimal(dt.Rows[i]["miktar"].ToString()))
                        },
                        LineExtensionAmount = new hm.common.Ubltr.Invoice21.LineExtensionAmountType()
                        {
                            currencyID = "TRY",
                            Value = Convert.ToDecimal(dt.Rows[i]["Tutar"])
                        },
                        TaxTotal = new hm.common.Ubltr.Invoice21.TaxTotalType()
                        {
                            TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
                            {
                                currencyID = "TRY",
                                Value = Convert.ToDecimal(dt.Rows[i]["Tutar"])
                            },
                            TaxSubtotal = new hm.common.Ubltr.Invoice21.TaxSubtotalType[]
                            {
                                    new hm.common.Ubltr.Invoice21.TaxSubtotalType()
                                    {
                                        TaxableAmount = new hm.common.Ubltr.Invoice21.TaxableAmountType()
                                        {
                                            currencyID = "TRY",
                                            Value = 20000
                                        },
                                        TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
                                        {
                                            currencyID = "TRY",
                                            Value = Convert.ToDecimal(dt.Rows[i]["TopKDV"].ToString())
                                        },
                                        CalculationSequenceNumeric =
                                            new hm.common.Ubltr.Invoice21.CalculationSequenceNumericType()
                                            {
                                                Value = 1
                                            },
                                        Percent = new hm.common.Ubltr.Invoice21.PercentType1()
                                        {
                                            Value = Convert.ToDecimal(dt.Rows[i]["kdv"].ToString())
                                        },
                                        TaxCategory = new hm.common.Ubltr.Invoice21.TaxCategoryType()
                                        {
                                            TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
                                            {
                                                Name = new hm.common.Ubltr.Invoice21.NameType1()
                                                {
                                                    Value = "KDV GERCEK"
                                                },
                                                TaxTypeCode = new hm.common.Ubltr.Invoice21.TaxTypeCodeType()
                                                {
                                                    Value = "0015"
                                                }
                                            }
                                        }
                                    }
                            }
                        },
                        Item = new hm.common.Ubltr.Invoice21.ItemType()
                        {
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = dt.Rows[i]["urunAdi"].ToString()
                            }
                        },

                        Price = new hm.common.Ubltr.Invoice21.PriceType()
                        {
                            PriceAmount = new hm.common.Ubltr.Invoice21.PriceAmountType()
                            {
                                currencyID = "TRY",
                                Value = Convert.ToDecimal(dt.Rows[i]["birimFiyat"].ToString())
                            }
                        }
                    };

                invoiceLines.Add(invoiceLine);


                ublinvoice.InvoiceLine = invoiceLines.ToArray();

                ublinvoice.LineCountNumeric = new hm.common.Ubltr.Invoice21.LineCountNumericType()
                {
                    Value = invoiceLines.Count
                };



                ublinvoicelist.Add(ublinvoice);
            }

            #endregion

            string test = ublinvoice.SerializeF();
            string str = "<?xml-stylesheet type='text/xsl' href='eFatura.xslt'?>";
            string xml = test.Substring(0, 38) + str + test.Substring(38);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-File | *.xml";
            saveFileDialog.FileName = fileName;
            string invoiceFindPath = Application.StartupPath + @"\ubl_testfatura\" + saveFileDialog.FileName + ".xml";
            File.WriteAllText(invoiceFindPath, xml, Encoding.GetEncoding("UTF-8"));
            return invoiceFindPath + "~" + fileName;
        }

        hm.common.Ubltr.Invoice21.CustomerPartyType GetTC(string aliciGIB, Int64 cariid)


        {
            var cari = cariBilgileri.bul_cariid(cariid);
            var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid).FirstOrDefault();
            return new hm.common.Ubltr.Invoice21.CustomerPartyType()
            {
                Party = new hm.common.Ubltr.Invoice21.PartyType()
                {
                    PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
                {
                        new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                        {
                            ID = new hm.common.Ubltr.Invoice21.IDType()
                            {
                                schemeID =cari.vergiNo.Trim().Length==11 ? "TCKN":"VKN",
                                Value = cari.vergiNo
                            }
                        },

                },
                    Person = new PersonType()
                    {
                        FirstName = new FirstNameType()
                        {
                            Value = cari.adi
                        },
                        FamilyName = new FamilyNameType()
                        {
                            Value = cari.soyadi.Length == 0 ? cari.adi : cari.soyadi
                        },
                    },
                    PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
                    {
                        StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
                        {
                            Value = adresListesi.adres
                        },
                        CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
                        {
                            Value = adresListesi.boldeAdi
                        },
                        CityName = new hm.common.Ubltr.Invoice21.CityNameType()
                        {
                            Value = adresListesi.boldeAdi
                        },
                        Country = new hm.common.Ubltr.Invoice21.CountryType()
                        {
                            IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
                            {
                                Value = "TR"
                            },
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = "Türkiye"
                            }
                        }
                    },
                    PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
                    {
                        TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
                        {
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = adresListesi.vergiDaire
                            }
                        }
                    },
                    WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
                    {
                        Value = ""
                    },
                    Contact = new hm.common.Ubltr.Invoice21.ContactType()
                    {
                        Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
                        {
                            Value = adresListesi.gsm
                        }
                    }
                }
            };
        }

        public static object[] Measure<TI, TO>(Func<TI, TO> action, TI o)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var output = (TO)action(o);
            sw.Stop();

            return new object[] { output, sw.ElapsedMilliseconds, action.Method.Name };
        }
        #endregion

    }
}
