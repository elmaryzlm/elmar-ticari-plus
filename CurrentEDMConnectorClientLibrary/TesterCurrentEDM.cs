using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Runtime.Serialization.Formatters;
using System.ServiceModel;
using System.Diagnostics;

using CurrentEDMConnectorClientLibrary.EdmService;
using CurrentEDMConnectorClientLibrary.Entities;

using NLog;
using Newtonsoft.Json;

using hm.common.Ubltr.ApplicationResponse20;
using hm.common.Ubltr.Invoice21;
using System.Windows.Forms;

namespace CurrentEDMConnectorClientLibrary
{
    public partial class TesterCurrentEDM
    {
        
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        // EFaturaOIBPortClient --> EFaturaEDMPortClient  
        private EFaturaEDMPortClient _service;
        private REQUEST_HEADERType _requestHeader;

        private String _username { get; set; }
        private String _password { get; set; }
        private string _path = System.Configuration.ConfigurationSettings.AppSettings["Path"].ToString();
        private static Regex timeZoneRegex = new Regex(@"(\d{2}:\d{2}:\d{2})(\.\d{7}[\+|-]\d{2}:\d{2})");
        
        public TesterCurrentEDM(string user, string password, string endpointname)
        {
            
            _service = new EFaturaEDMPortClient();
            _service.Endpoint.Address = new EndpointAddress(endpointname);

            _username = user;
            _password = password;
            //_service = new EFaturaEDMPortClient(endpointname);
            //_service = new EFaturaEDMPortClient();
           


            //"EFaturaEDMPortBinding" + (Test ? "Test" : ""));
            ////"EFaturaEDMPortBinding",
            ////        new System.ServiceModel.EndpointAddress("https://efatura.edmbilisim.com.tr:2443/EFaturaEDM") { });
            //else
            //    service = new EFaturaEDMPortClient("EFaturaEDMPortBindingTest",
            //    new System.ServiceModel.EndpointAddress("https://testefatura.edmbilisim.com.tr:2443/EFaturaEDM") { });

            _requestHeader = new EdmService.REQUEST_HEADERType();
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

            //_requestHeader.REASON = "RELOADING_INVOICE_AFTER_EDIT_FROM_PORTAL";
            //_requestHeader.APPLICATION_NAME = "PORTAL";
            //_requestHeader.HOSTNAME = "ist.efaturaappserver";
            //_requestHeader.CHANNEL_NAME = "PORTAL_INVOICE_UPLOAD_AFTER_EDIT";
            //_requestHeader.COMPRESSED = "COMPRESSED";
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

        public List<FormParameters> Current_SendInvoiceMultiTest(string ublfilefullpath,
                                                int multiplexcount = 1,
                                                bool createUUID = true,
                                                string invoiceid = null,
                                                string pk = null,
                                                string gb =null,
                                                string receiverMail =null,
                                                string receiverVKNTCKN = null,
                                                string senderVKNTCKN = null)
        {
            
            List<FormParameters> sendFormParametersList = new List<FormParameters>();
            FormParameters sendFormParametersEntity = new FormParameters();

            try
            {
                byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);

                hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
                    = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));

                // smooth serialize
                string invoiceUblXmlStr
                    = ublinvoice.SerializeF();

                List<INVOICE> cntrinvoiceList = new List<INVOICE>();


                for (int i = 0; i < multiplexcount; i++)
                {

                    if (createUUID)
                    {
                        ublinvoice.UUID.Value = Guid.NewGuid().ToString();
                    }

                    if (ublinvoice.ID == null)
                    {
                        ublinvoice.ID = new hm.common.Ubltr.Invoice21.IDType();
                    }

                    if (!string.IsNullOrEmpty(invoiceid))
                    {
                        ublinvoice.ID.Value = invoiceid;
                    }
                    
                    invoiceUblXmlStr = ublinvoice.SerializeF();
                    invoiceUblXmlStr = timeZoneRegex.Replace(invoiceUblXmlStr, "$1");
                    ublfilebytes = System.Text.Encoding.UTF8.GetBytes(invoiceUblXmlStr);


                    /// set receiver sample

                    if (string.IsNullOrEmpty(receiverVKNTCKN))
                    {
                        receiverVKNTCKN = ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN").First().ID.Value;
                    }
                    if (string.IsNullOrEmpty(senderVKNTCKN))
                    {
                        senderVKNTCKN = ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN").First().ID.Value;
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
                        //INTERNETSALES = true,
                       // SENDER = senderVKNTCKN,//
                        FROM = "urn:mail:defaultgb@yenibirfirmadaha.com.tr",
                       // RECEIVER = receiverVKNTCKN,
                       // TO = pk

                        SENDER = "3230512384",
                        RECEIVER = "3230512384",
                        TO = "urn:mail:defaultpk@yenibirfirmadaha.com.tr",
                        //FROM = "urn:mail:defaultgb@edmbilisim.com.tr",
                    };
                    cntrinvoice.CONTENT = new EdmService.base64Binary()
                    {
                        Value = ublfilebytes
                    };
                   
                    cntrinvoiceList.Add(cntrinvoice);
                    if(cntrinvoice.UUID != null)
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
                    cntrinvoice.CONTENT = new EdmService.base64Binary()
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


        // fatura alma , indirme ve durum sorgulama
        #region GetInvoice
        /// <summary>
        /// Verilen kriterlere uyan E-fatura/E-Arşiv faturaların sistemden çekilmesini sağlar. 
        /// Çekilen bilgiler için fatura kafa kaydı, fatura dosyası, fatutra durum bilgisi, zarf bilgileri yer alır.
        /// </summary>
        /// <param name="headeronly">Fatura dosyasını okuma kriteri true: kafa kaydı bilgileri, false: contenttype'a bağlı istenen fatura dosyası</param>
        public List<FormParameters> Current_GetInvoice(bool downloadcontent = false,  // true: kafa kaydı bilgileri, false: contenttype'a bağlı istenen fatura dosyası
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

              
                if(invoiceListResponse.Count() > 0)
                {
                   FormValues.getInvoiceEnter = "Faturalar başarıyla indirildi.";
                }else
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
        public void Current_SendInvoiceResponseWithServerSign_KABUL()
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
                                                    ID = "XEX2015000000002",
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
                if(gibuserPKs != null) FormValues.gibUserListEnter = "Yükleme başarıyla tamamlandı.";
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
                //MessageBox.Show(detail);
               // MessageBox.Show(requesterror.ToString());
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
        public void Current_GetUserListBinary_XML()
        {
            try
            {
                logger.Info("GetUserListBinary XML test...");

                GetUserListBinaryRequest getUserListBinaryRequest = new GetUserListBinaryRequest();
                getUserListBinaryRequest.TYPE = GetUserListBinaryRequestTYPE.XML;
                getUserListBinaryRequest.REQUEST_HEADER = _requestHeader;

                GetUserListBinaryResponse getUserListBinaryResponse = _service.GetUserListBinary(getUserListBinaryRequest);
                byte[] userlistdata = getUserListBinaryResponse.Item.Value;
                File.WriteAllBytes(Path.Combine(_path, "GetUserListBinary_xml.zip"), userlistdata);
                string userliststring = System.Text.Encoding.UTF8.GetString(userlistdata);
                logger.Info("{0} bytes, OK", userlistdata.Length);
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
        /// e-fatura mükellef listesi .CSV içeriği şeklinde ve zipli olarak alınır
        /// </summary>
        /// <param name="title"></param>
        public void Current_GetUserListBinary_CSV()
        {
            try
            {
                logger.Info("GetUserListBinary CSV test...");

                GetUserListBinaryRequest getUserListBinaryRequest = new GetUserListBinaryRequest();
                getUserListBinaryRequest.TYPE = GetUserListBinaryRequestTYPE.CSV;
                getUserListBinaryRequest.REQUEST_HEADER = _requestHeader;

                GetUserListBinaryResponse getUserListBinaryResponse = _service.GetUserListBinary(getUserListBinaryRequest);
                byte[] userlistdata = getUserListBinaryResponse.Item.Value;
                File.WriteAllBytes(Path.Combine(_path, "GetUserListBinary_csv.zip"), userlistdata);
                string userliststring = System.Text.Encoding.UTF8.GetString(userlistdata);
                logger.Info("{0} bytes, OK", userlistdata.Length);
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


        // yardımcı fonksiyonlar
        #region helper tools

        private string xmlSerializeObject(object Object)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(REQUEST_ERRORType));
            StringWriter SW = new StringWriter();
            serializer.Serialize(SW, Object);
            return SW.ToString();
        }

        public List<hm.common.Ubltr.Invoice21.InvoiceType> CreateInvoiceTypeTestObject(string serial, int startinvoiceserial, int count)
        {
            List<hm.common.Ubltr.Invoice21.InvoiceType> ublinvoicelist = new List<hm.common.Ubltr.Invoice21.InvoiceType>();


            for (int i = startinvoiceserial; i <= (startinvoiceserial + count); i++)
            {

                // create and return invoice of type InvoiceType
                hm.common.Ubltr.Invoice21.InvoiceType ublinvoice = new hm.common.Ubltr.Invoice21.InvoiceType();

                #region Header
                ublinvoice.UBLExtensions = new hm.common.Ubltr.Invoice21.UBLExtensionType[]
            {
                new hm.common.Ubltr.Invoice21.UBLExtensionType()
                {
                    ExtensionContent = new hm.common.Ubltr.Invoice21.ExtensionContentType()
                    {
                    }
                }
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
                    Value = "TICARIFATURA"
                };

                ublinvoice.ID = new hm.common.Ubltr.Invoice21.IDType()
                {
                    Value = string.Format("{0}{1}{2}", serial, DateTime.Now.Year, i.ToString().PadLeft(9, '0'))
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
                    Value = DateTime.Now
                };

                ublinvoice.InvoiceTypeCode = new hm.common.Ubltr.Invoice21.InvoiceTypeCodeType()
                {
                    Value = "SATIS"
                };


                List<hm.common.Ubltr.Invoice21.NoteType> notes = new List<hm.common.Ubltr.Invoice21.NoteType>();
                notes.Add(new hm.common.Ubltr.Invoice21.NoteType()
                {
                    Value = "Ticaret Sicil No.:888376, İşletme Merkezi: ISTANBUL"
                });

                ublinvoice.Note = notes.ToArray();

                ublinvoice.DocumentCurrencyCode = new hm.common.Ubltr.Invoice21.DocumentCurrencyCodeType()
                {
                    Value = "TRY"
                };

                #endregion

                #region Signature

                ublinvoice.Signature = new hm.common.Ubltr.Invoice21.SignatureType1[]
            {
                new hm.common.Ubltr.Invoice21.SignatureType1()
                {
                    ID = new hm.common.Ubltr.Invoice21.IDType()
                    {
                        schemeID = "VKN_TCKN",
                        Value = "3230512384"
                    },
                    SignatoryParty = new hm.common.Ubltr.Invoice21.PartyType()
                    {
                        PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
                        {
                            new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                            {
                                ID = new hm.common.Ubltr.Invoice21.IDType()
                                {
                                    schemeID = "VKN",
                                    Value = "3230512384"
                                }
                            }
                        },
                        PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
                        {
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = null
                            },
                        },
                        PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
                        {
                            TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
                            {
                                Name = new hm.common.Ubltr.Invoice21.NameType1()
                                {
                                    Value = null
                                }
                            }
                        },
                        PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
                        {
                            StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
                            {
                                Value = "Cansızoğlu işhanı No:7/35 Mecidiyeköy"
                            },
                            CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
                            {
                                Value    = "Şişli"
                            },
                            CityName = new hm.common.Ubltr.Invoice21.CityNameType()
                            {
                                Value = "İstanbul"
                            },
                            Country = new hm.common.Ubltr.Invoice21.CountryType()
                            {
                                IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
                                {
                                    Value = "TR"
                                },
                                Name = new hm.common.Ubltr.Invoice21.NameType1()
                                {
                                    Value  = "Türkiye"
                                }
                            }
                        }
                    },
                    DigitalSignatureAttachment = new hm.common.Ubltr.Invoice21.AttachmentType()
                    {
                        ExternalReference = new hm.common.Ubltr.Invoice21.ExternalReferenceType()
                        {
                            URI = new hm.common.Ubltr.Invoice21.URIType()
                            {
                                Value =  "#Signature_" + ublinvoice.ID.Value 
                            }
                        }
                    }
                }
            };

                #endregion

                #region Default Fatura Dizaynı (xslt)

                ublinvoice.AdditionalDocumentReference = new hm.common.Ubltr.Invoice21.DocumentReferenceType[]
            {
                new hm.common.Ubltr.Invoice21.DocumentReferenceType()
                {
                    ID = new hm.common.Ubltr.Invoice21.IDType()
                    {
                        Value = Guid.NewGuid().ToString()
                    },
                    IssueDate = new hm.common.Ubltr.Invoice21.IssueDateType()
                    {
                        Value = DateTime.Now
                    },
                    Attachment = new hm.common.Ubltr.Invoice21.AttachmentType()
                    {
                        EmbeddedDocumentBinaryObject  = new hm.common.Ubltr.Invoice21.EmbeddedDocumentBinaryObjectType()
                        {
                            filename = ublinvoice.ID.Value + ".xslt",
                            characterSetCode ="UTF-8" ,
                            encodingCode="Base64",
                            mimeCode="application/xml",
                            Value = File.ReadAllBytes("default.xslt")
                        }
                    }
                }
                
            };


                #endregion

                #region Gönderen Bilgileri

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
                                Value = "3230512384"
                            }
                        },
                        new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                        {
                            ID = new hm.common.Ubltr.Invoice21.IDType()
                            {
                                schemeID = "MERSISNO",
                                Value = "0000000000000000"
                            }
                        },
                        new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                        {
                            ID = new hm.common.Ubltr.Invoice21.IDType()
                            {
                                schemeID = "TICARETSICILNO",
                                Value = "12345678"
                            }
                        }
                    },
                        PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
                        {
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = "EDM Bilişim Sistemleri ve Danışmanlık Hizmetleri A.Ş."
                            }
                        },
                        PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
                        {
                            StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
                            {
                                Value = "Cansızoğlu işhanı No:7/35 Mecidiyeköy"
                            },
                            CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
                            {
                                Value = "Şişli"
                            },
                            CityName = new hm.common.Ubltr.Invoice21.CityNameType()
                            {
                                Value = "İstanbul"
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
                                    Value = "Büyük Mükellefler"
                                }
                            }
                        },
                        WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
                        {
                            Value = "www.edmbilisim.com.tr"
                        },
                        Contact = new hm.common.Ubltr.Invoice21.ContactType()
                        {
                            Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
                            {
                                Value = "+90 111 222 3344"
                            }
                        }
                    }
                };

                #endregion

                #region Alıcı Bilgileri

                ublinvoice.AccountingCustomerParty = new hm.common.Ubltr.Invoice21.CustomerPartyType()
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
                                Value = "3230512384"
                            }
                        },
                        new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                        {
                            ID = new hm.common.Ubltr.Invoice21.IDType()
                            {
                                schemeID = "MERSISNO",
                                Value = "0000000000000000"
                            }
                        },
                        new hm.common.Ubltr.Invoice21.PartyIdentificationType()
                        {
                            ID = new hm.common.Ubltr.Invoice21.IDType()
                            {
                                schemeID = "TICARETSICILNO",
                                Value = "12345678"
                            }
                        }
                    },
                        PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
                        {
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = "EDM Bilişim Sistemleri ve Danışmanlık Hizmetleri A.Ş."
                            }
                        },
                        PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
                        {
                            StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
                            {
                                Value = "Cansızoğlu işhanı No:7/35 Mecidiyeköy"
                            },
                            CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
                            {
                                Value = "Şişli"
                            },
                            CityName = new hm.common.Ubltr.Invoice21.CityNameType()
                            {
                                Value = "İstanbul"
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
                                    Value = "Büyük Mükellefler"
                                }
                            }
                        },
                        WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
                        {
                            Value = "www.edmbilisim.com.tr"
                        },
                        Contact = new hm.common.Ubltr.Invoice21.ContactType()
                        {
                            Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
                            {
                                Value = "+90 111 222 3344"
                            }
                        }
                    }
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
                        Value = 3600
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
                                Value = 3600
                            },
                            CalculationSequenceNumeric = new hm.common.Ubltr.Invoice21.CalculationSequenceNumericType()
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
                        Value = 20000
                    },
                    TaxExclusiveAmount = new hm.common.Ubltr.Invoice21.TaxExclusiveAmountType()
                    {
                        currencyID = "TRY",
                        Value = 20000
                    },
                    TaxInclusiveAmount = new hm.common.Ubltr.Invoice21.TaxInclusiveAmountType()
                    {
                        currencyID = "TRY",
                        Value = 23600
                    },
                    AllowanceTotalAmount = new hm.common.Ubltr.Invoice21.AllowanceTotalAmountType()
                    {
                        currencyID = "TRY",
                        Value = 0
                    },
                    PayableAmount = new hm.common.Ubltr.Invoice21.PayableAmountType()
                    {
                        currencyID = "TRY",
                        Value = 23600
                    },
                };

                #endregion

                #region invoice lines


                List<hm.common.Ubltr.Invoice21.InvoiceLineType> invoiceLines
                    = new List<hm.common.Ubltr.Invoice21.InvoiceLineType>();

                hm.common.Ubltr.Invoice21.InvoiceLineType invoiceLine
                    = new hm.common.Ubltr.Invoice21.InvoiceLineType()
                    {
                        ID = new hm.common.Ubltr.Invoice21.IDType()
                        {
                            Value = "1"
                        },
                        InvoicedQuantity = new hm.common.Ubltr.Invoice21.InvoicedQuantityType()
                        {
                            unitCode = "NIU",
                            Value = 1
                        },
                        LineExtensionAmount = new hm.common.Ubltr.Invoice21.LineExtensionAmountType()
                        {
                            currencyID = "TRY",
                            Value = 20000
                        },
                        TaxTotal = new hm.common.Ubltr.Invoice21.TaxTotalType()
                        {
                            TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
                            {
                                currencyID = "TRY",
                                Value = 3600
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
                                    Value = 3600
                                },
                                CalculationSequenceNumeric = new hm.common.Ubltr.Invoice21.CalculationSequenceNumericType()
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
                        },
                        Item = new hm.common.Ubltr.Invoice21.ItemType()
                        {
                            Name = new hm.common.Ubltr.Invoice21.NameType1()
                            {
                                Value = "Ürün Bedeli"
                            }
                        },
                        Price = new hm.common.Ubltr.Invoice21.PriceType()
                        {
                            PriceAmount = new hm.common.Ubltr.Invoice21.PriceAmountType()
                            {
                                currencyID = "TRY",
                                Value = 20000
                            }
                        }
                    };

                invoiceLines.Add(invoiceLine);


                ublinvoice.InvoiceLine = invoiceLines.ToArray();

                ublinvoice.LineCountNumeric = new hm.common.Ubltr.Invoice21.LineCountNumericType()
                {
                    Value = invoiceLines.Count
                };

                #endregion

                ublinvoicelist.Add(ublinvoice);
                string test= ublinvoice.SerializeF();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML-File | *.xml";
                saveFileDialog.FileName = DateTime.Now.ToString("yyyy-MM-dd");
                File.WriteAllText(Application.StartupPath + @"\ubl_testfatura\"+ saveFileDialog.FileName+".xml", test, Encoding.GetEncoding("iso-8859-9"));

            }
           
            return ublinvoicelist;
        }


        public static object[] Measure<TI, TO>(Func<TI, TO> action, TI o)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var output = (TO)action(o);
            sw.Stop();
            
            return new object[] { output , sw.ElapsedMilliseconds, action.Method.Name};
        }

        #endregion

    }



    //public partial class Tester
    //{
    //    private static Logger logger = LogManager.GetCurrentClassLogger();

    //    // EFaturaOIBPortClient --> ESmmEDMPortClient  
    //     private EFaturaEDMPortClient _service;
    //    private REQUEST_HEADERType _requestHeader;

    //    private String _username { get; set; }
    //    private String _password { get; set; }
    //    private string _path = System.Configuration.ConfigurationSettings.AppSettings["Path"].ToString();
    //    private static Regex timeZoneRegex = new Regex(@"(\d{2}:\d{2}:\d{2})(\.\d{7}[\+|-]\d{2}:\d{2})");
    //    //private static string EmailRegularExpression = "^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$";


    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="user">k.adı</param>
    //    /// <param name="password">şifre</param>
    //    /// <param name="endpointconfigurationname">config name</param>
    //    /// <param name="sessionId">bilinen session id varsa verilir ve bir daha login olunmaz yoksa bu alanı boş bırakınız</param>
    //    public Tester(string user, string password, string endpointconfigurationname, string sessionId = "")
    //    {
    //        _username = user;
    //        _password = password;
    //        _service = new EFaturaEDMPortClient(endpointconfigurationname);

    //        //"EFaturaEDMPortBinding" + (Test ? "Test" : ""));
    //        ////"EFaturaEDMPortBinding",
    //        ////        new System.ServiceModel.EndpointAddress("https://efatura.edmbilisim.com.tr:2443/EFaturaEDM") { });
    //        //else
    //        //    service = new ESmmEDMPortClient("EFaturaEDMPortBindingTest",
    //        //    new System.ServiceModel.EndpointAddress("https://testefatura.edmbilisim.com.tr:2443/EFaturaEDM") { });

    //        _requestHeader = new CurrentEDMConnectorClientLibrary.EdmService.REQUEST_HEADERType();
    //        _requestHeader.SESSION_ID = String.IsNullOrEmpty(sessionId) ? "0" : sessionId;
    //        _requestHeader.CLIENT_TXN_ID = System.Guid.NewGuid().ToString();
    //        _requestHeader.APPLICATION_NAME = "CONNECTOR TEST vX";
    //        _requestHeader.CHANNEL_NAME = "CHANNEŞ";
    //        _requestHeader.HOSTNAME = "HOSTNAME";
    //        _requestHeader.ACTION_DATE = DateTime.Now;
    //        _requestHeader.ACTION_DATESpecified = true;
    //        _requestHeader.REASON = "Test"; // "EFATURA GONDERME VE ALMA ISLEMLERI" + (Test ? " TEST" : "");
    //        _requestHeader.COMPRESSED = "N";

    //        //_requestHeader.REASON = "RELOADING_INVOICE_AFTER_EDIT_FROM_PORTAL";
    //        //_requestHeader.APPLICATION_NAME = "PORTAL";
    //        //_requestHeader.HOSTNAME = "ist.efaturaappserver";
    //        //_requestHeader.CHANNEL_NAME = "PORTAL_INVOICE_UPLOAD_AFTER_EDIT";
    //        //_requestHeader.COMPRESSED = "COMPRESSED";
    //    }

    //    #region login & logout

    //    /// <summary>
    //    /// EDM web servis Login işlemi
    //    /// </summary>
    //    public void Test_Login(string username = null, string password = null)
    //    {
    //        try
    //        {
    //            if (username != null && password != null)
    //            {
    //                _username = username;
    //                _password = password;
    //            }

    //            logger.Info("Login test...");

    //            LoginRequest loginRequest = new LoginRequest();
    //            loginRequest.USER_NAME = _username;
    //            loginRequest.PASSWORD = _password;
    //            loginRequest.REQUEST_HEADER = _requestHeader;
    //            loginRequest.REQUEST_HEADER.ACTION_DATE = DateTime.Now;
    //            loginRequest.REQUEST_HEADER.ACTION_DATESpecified = true;
    //            loginRequest.REQUEST_HEADER.APPLICATION_NAME = "Hakan test connector console app.";
    //            loginRequest.REQUEST_HEADER.CHANNEL_NAME = "EDM test company";
    //            loginRequest.REQUEST_HEADER.COMPRESSED = "N";
    //            loginRequest.REQUEST_HEADER.HOSTNAME = "Sony";

    //            //LoginResponse loginResponse = _service.Login(loginRequest);
    //            LoginResponse loginResponse = Measure<LoginRequest, LoginResponse>(_service.Login, loginRequest);

    //            _requestHeader.SESSION_ID = loginResponse.SESSION_ID;

    //            logger.Info("Ok");
    //            //logger.Info(loginRequest.REQUEST_HEADER.ToJSONString());
    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    /// <summary>
    //    /// EDM web servis Logout işlemi
    //    /// </summary>
    //    public void Test_Logout()
    //    {
    //        try
    //        {
    //            logger.Info("Logout test...");

    //            LogoutRequest logoutRequest = new LogoutRequest();
    //            logoutRequest.REQUEST_HEADER = _requestHeader;

    //            //LogoutResponse logoutResponse = _service.Logout(logoutRequest);
    //            LogoutResponse logoutResponse = Measure<LogoutRequest, LogoutResponse>(_service.Logout, logoutRequest);

    //            logger.Info("Ok");
    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    #endregion


    //    #region SendSMM

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="sender">gönderici vkn</param>
    //    /// <param name="receiver">alıcı vkn</param>
    //    /// <param name="to">gönderen gb</param>
    //    /// <param name="from">alıcı pk veya email</param>
    //    /// <param name="relogin"></param>
    //    public void Test_SendSMMMultiTest(string sender, string receiver,
    //        string to, string from,
    //        bool relogin = false)
    //    {
    //        try
    //        {
    //            if (relogin)
    //                Test_Login();

    //            logger.Info("SendSMM multi test...");

    //            List<INVOICE> smmList = new List<INVOICE>();

    //            // create connector smm
    //            SMM smm = new SMM()
    //            {
    //                CURRENCY_CODE = "TRY",

    //                ID = "AOP2019000000019",
    //                UUID = System.Guid.NewGuid().ToString(),

    //                SUPPLIER_NAME = "ALICI UNVAN",
    //                SUPPLIER_ADRESS = "ADRES",
    //                SUPPLIER_CITY = "İl",
    //                SUPPLIER_COUNTY = "İlçe",
    //                SUPPLIER_EMAIL = "E-POSTA",
    //                SUPPLIER_TAX_OFFICE = "VERGI DAIRESI",

    //                SMM_LINE_ITEMS = new SMMSMM_LINE_ITEMS[] {
    //                    new SMMSMM_LINE_ITEMS
    //                {
    //                    FEE_REASON = "ürün1",
    //                     NET_AMOUNT = Convert.ToDouble("225,9241"),
    //                     GROSS_AMOUNT = Convert.ToDouble("195,50"),
    //                     NET_REVENUE = Convert.ToDouble("210,65"),
    //                     STOPPAGE_RATE = Convert.ToDouble("20"),
    //                     TAX_RATE = Convert.ToDouble("8"),
    //                } ,new SMMSMM_LINE_ITEMS
    //                {
    //                    FEE_REASON = "ürün2",
    //                     NET_AMOUNT = Convert.ToDouble("11,21"),
    //                     GROSS_AMOUNT = Convert.ToDouble("41,21"),
    //                     NET_REVENUE = Convert.ToDouble("21,21"),
    //                     STOPPAGE_RATE = Convert.ToDouble("20"),
    //                     TAX_RATE = Convert.ToDouble("8"),
    //                },
    //                },
    //                HEADER = new SMMHEADER()
    //                {
    //                    SENDER = "3230512384",
    //                    RECEIVER = "12653256589",
    //                    TO = "damla.bas@edmbilisim.com.tr",
    //                    FROM = "urn:mail:defaultgb@edmbilisim.com.tr",
    //                    SMM_DATE = DateTime.Now.AddHours(-5),
    //                },
    //            };

    //            //cntrinvoice.CONTENT = new EdmService.base64Binary()
    //            //{
    //            //    Value = ublfilebytes
    //            //};

    //            smmList.Add(smm);


    //            SendSMMRequest sendInvoiceRequest = new SendSMMRequest();
    //            sendInvoiceRequest.REQUEST_HEADER = _requestHeader;
    //            sendInvoiceRequest.RECEIVER = new SendSMMRequestRECEIVER()
    //            {
    //                vkn = smmList[0].HEADER.RECEIVER,
    //                alias = smmList[0].HEADER.TO,
    //            };
    //            sendInvoiceRequest.SMM = smmList.ToArray();

    //            SendSMMResponse sendInvoiceResponse = Measure<SendSMMRequest, SendSMMResponse>(_service.SendSMM, sendInvoiceRequest);


    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;


    //            logger.Error("FaultException fault message:" + fexp.Message);
    //            logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);

    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="sender">gönderici vkn</param>
    //    /// <param name="receiver">alıcı vkn</param>
    //    /// <param name="to">gönderen gb</param>
    //    /// <param name="from">alıcı pk veya email</param>
    //    /// <param name="relogin"></param>
    //    public void Test_LoadSMMMultiTest(string sender, string receiver,
    //        string to, string from,
    //        bool relogin = false)
    //    {
    //        try
    //        {
    //            if (relogin)
    //                Test_Login();

    //            logger.Info("Test_LoadSMMMultiTest test...");

    //            List<SMM> smmList = new List<SMM>();

    //            // create connector smm
    //            SMM smm = new SMM()
    //            {
    //                CURRENCY_CODE = "TRY",

    //                ID = "AOP2019000000019",
    //                UUID = System.Guid.NewGuid().ToString(),

    //                SUPPLIER_NAME = "ALICI UNVAN",
    //                SUPPLIER_ADRESS = "ADRES",
    //                SUPPLIER_CITY = "İl",
    //                SUPPLIER_COUNTY = "İlçe",
    //                SUPPLIER_EMAIL = "E-POSTA",
    //                SUPPLIER_TAX_OFFICE = "VERGI DAIRESI",

    //                SMM_LINE_ITEMS = new SMMSMM_LINE_ITEMS[] {
    //                    new SMMSMM_LINE_ITEMS
    //                {
    //                    FEE_REASON = "ürün1",
    //                     NET_AMOUNT = Convert.ToDouble("225,9241"),
    //                     GROSS_AMOUNT = Convert.ToDouble("195,50"),
    //                     NET_REVENUE = Convert.ToDouble("210,65"),
    //                     STOPPAGE_RATE = Convert.ToDouble("20"),
    //                     TAX_RATE = 8
    //                } ,new SMMSMM_LINE_ITEMS
    //                {
    //                    FEE_REASON = "ürün2",
    //                     NET_AMOUNT = Convert.ToDouble("11,21"),
    //                     GROSS_AMOUNT = Convert.ToDouble("41,21"),
    //                     NET_REVENUE = Convert.ToDouble("21,21"),
    //                     STOPPAGE_RATE = Convert.ToDouble("20"),
    //                     TAX_RATE = 8
    //                },
    //                },
    //                HEADER = new SMMHEADER()
    //                {
    //                    SENDER = sender,
    //                    RECEIVER = receiver,
    //                    TO = to,
    //                    FROM = from,
    //                    //ERP_REFERENCE = "1903",
    //                    SMM_DATE = DateTime.Now.AddHours(-1),
    //                },
    //            };

    //            smmList.Add(smm);


    //            LoadSMMRequest sendInvoiceRequest = new LoadSMMRequest();
    //            sendInvoiceRequest.REQUEST_HEADER = _requestHeader;
    //            sendInvoiceRequest.RECEIVER = new LoadSMMRequestRECEIVER()
    //            {
    //                vkn = smmList[0].HEADER.RECEIVER,
    //                alias = smmList[0].HEADER.TO,
    //            };
    //            sendInvoiceRequest.SMM = smmList.ToArray();

    //            LoadSMMResponse sendInvoiceResponse = Measure<LoadSMMRequest, LoadSMMResponse>(_service.LoadSMM, sendInvoiceRequest);


    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;


    //            logger.Error("FaultException fault message:" + fexp.Message);
    //            logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);

    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="sender">gönderici vkn</param>
    //    /// <param name="receiver">alıcı vkn</param>
    //    /// <param name="to">gönderen gb</param>
    //    /// <param name="from">alıcı pk veya email</param>
    //    /// <param name="relogin"></param>
    //    public void Test_SendSMMPreparedMultiTest(string file,
    //        string sender, string receiver,
    //        string to, string from,
    //        bool relogin = false)
    //    {
    //        try
    //        {
    //            if (relogin)
    //                Test_Login();

    //            logger.Info("Test_SendSMMPreparedMultiTest test...");

    //            List<SMM> smmList = new List<SMM>();

    //            byte[] xmlBytes = File.ReadAllBytes(file);

    //            // create connector smm
    //            SMM smm = new SMM()
    //            {
    //                CONTENT = new base64Binary()
    //                {
    //                    contentType = "application/xml",
    //                    Value = xmlBytes
    //                },
    //                HEADER = new SMMHEADER()
    //                {
    //                    SENDER = "3230512384",
    //                    RECEIVER = "3230512384",
    //                    TO = "muhammet.dora@edmbilisim.com.tr",
    //                    FROM = "urn:mail:defaultgb@edmbilisim.com.tr",
    //                },
    //            };

    //            smmList.Add(smm);


    //            SendSMMPreparedRequest sendSMMPreparedRequest = new SendSMMPreparedRequest();

    //            sendSMMPreparedRequest.REQUEST_HEADER = _requestHeader;
    //            sendSMMPreparedRequest.RECEIVER = new SendSMMPreparedRequestRECEIVER()
    //            {
    //                vkn = smmList[0].HEADER.RECEIVER,
    //                alias = smmList[0].HEADER.TO,
    //            };
    //            sendSMMPreparedRequest.SMM = smmList.ToArray();

    //            SendSMMPreparedResponse sendInvoiceResponse =
    //                Measure<SendSMMPreparedRequest, SendSMMPreparedResponse>(_service.SendSMMPrepared, sendSMMPreparedRequest);


    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;


    //            logger.Error("FaultException fault message:" + fexp.Message);
    //            logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);

    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="sender">gönderici vkn</param>
    //    /// <param name="receiver">alıcı vkn</param>
    //    /// <param name="to">gönderen gb</param>
    //    /// <param name="from">alıcı pk veya email</param>
    //    /// <param name="relogin"></param>
    //    public void Test_LoadSMMPreparedMultiTest(string file,
    //        string sender, string receiver,
    //        string to, string from,
    //        bool relogin = false)
    //    {
    //        try
    //        {
    //            if (relogin)
    //                Test_Login();

    //            logger.Info("Test_SendSMMPreparedMultiTest test...");

    //            List<SMM> smmList = new List<SMM>();

    //            byte[] xmlBytes = File.ReadAllBytes(file);

    //            // create connector smm
    //            SMM smm = new SMM()
    //            {
    //                CONTENT = new base64Binary()
    //                {
    //                    contentType = "application/xml",
    //                    Value = xmlBytes
    //                },
    //                HEADER = new SMMHEADER()
    //                {
    //                    SENDER = "3230512384",
    //                    RECEIVER = "3230512384",
    //                    TO = "muhammet.dora@edmbilisim.com.tr",
    //                    FROM = "urn:mail:defaultgb@edmbilisim.com.tr",
    //                },
    //            };

    //            smmList.Add(smm);


    //            LoadSMMPreparedRequest loadSMMPreparedRequest = new LoadSMMPreparedRequest();

    //            loadSMMPreparedRequest.REQUEST_HEADER = _requestHeader;
    //            loadSMMPreparedRequest.RECEIVER = new LoadSMMPreparedRequestRECEIVER()
    //            {
    //                vkn = smmList[0].HEADER.RECEIVER,
    //                alias = smmList[0].HEADER.TO,
    //            };
    //            loadSMMPreparedRequest.SMM = smmList.ToArray();

    //            LoadSMMPreparedResponse loadInvoiceResponse =
    //                Measure<LoadSMMPreparedRequest, LoadSMMPreparedResponse>(_service.LoadSMMPrepared, loadSMMPreparedRequest);

    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;


    //            logger.Error("FaultException fault message:" + fexp.Message);
    //            logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);

    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    #endregion


    //    #region GetSMM, GetSMMStatus

    //    /// <summary>
    //    /// Verilen kriterlere uyan E-SMM lerin sistemden çekilmesini sağlar. 
    //    /// Çekilen bilgiler için smm kafa kaydı, smm dosyası, smm durum bilgisi, zarf bilgileri yer alır.
    //    /// Content bilgisi L:\gidendir altına kaydedilir
    //    /// </summary>
    //    /// <param name="headeronly">SMM dosyasını okuma kriteri true: kafa kaydı bilgileri, false: contenttype'a bağlı istenen fatura dosyası</param>
    //    public SMM[] Test_GetSmm(bool downloadcontent = false,  // true: kafa kaydı bilgileri, false: contenttype'a bağlı istenen fatura dosyası
    //                                string contenttype = "XML",  // "XML", "PDF", "ZIP"
    //                                bool read_included = true,  // true: MARK işlemi ile işaretlenmiş olanları da listeler, false: MARK ie işaretlenmil olanları listeye dahil etmez
    //                                string direction = "OUT",   // Gönderilenler için: "OUT" "OUT-EINVOICE"  "OUT-EARCHIVE" / Gelenler için:"IN";
    //                                int limit = 10,  // çekilen fatura adedi için limit 
    //                                string smmno = null,  // spesifik bir faturano
    //                                string smmuuid = null,
    //        string gidendir = "")   // spesifik bir ETTN 
    //    {
    //        SMM[] invoiceList = null;

    //        try
    //        {
    //            logger.Info("GetSMM test...");

    //            GetSMMRequest getInvoiceRequest = new GetSMMRequest();
    //            GetSMMRequestSMM_SEARCH_KEY invoiceSearchKey = new GetSMMRequestSMM_SEARCH_KEY();

    //            invoiceSearchKey.DIRECTION = direction;//iptal edilecek
    //            //invoiceSearchKey.START_DATE = DateTime.Now.Date.AddDays(-30);
    //            //invoiceSearchKey.START_DATESpecified = true;
    //            //invoiceSearchKey.END_DATE = DateTime.Now.Date.AddDays(1);
    //            //invoiceSearchKey.END_DATESpecified = true;
    //            invoiceSearchKey.CR_START_DATE = DateTime.Now.Date.AddDays(-30);
    //            invoiceSearchKey.CR_START_DATESpecified = true;
    //            invoiceSearchKey.CR_END_DATE = DateTime.Now.Date.AddDays(1);
    //            invoiceSearchKey.CR_END_DATESpecified = true;
    //            invoiceSearchKey.LIMIT = limit;
    //            //invoiceSearchKey.LIMITSpecified = (limit == int.MaxValue) ? false : true;
    //            invoiceSearchKey.LIMITSpecified = true;
    //            //invoiceSearchKey.READ_INCLUDED = read_included;     // true/false; true: MARK işlemi ile işaretlenmiş olanları da listeler, false: MARK ie işaretlenmil olanları listeye dahil etmez
    //            //invoiceSearchKey.READ_INCLUDEDSpecified = true;
    //            //invoiceSearchKey.SENDER = "3230512384";
    //            //invoiceSearchKey.RECEIVER = "3230512384";
    //            //invoiceSearchKey.FROM = null;
    //            //invoiceSearchKey.TO = null;
    //            //invoiceSearchKey.ID = smmno;
    //            invoiceSearchKey.UUID = smmuuid;

    //            invoiceSearchKey.ISARCHIVEDSpecified = true;
    //            invoiceSearchKey.ISARCHIVED = false;

    //            //invoiceSearchKey.CONNECTORSTATUSDESCRIPTION = "RECEIVE - WAIT_APPLICATION_RESPONSE";
    //            //invoiceSearchKey.CONNECTORSTATUSDESCRIPTION = "SEND - SUCCEED";
    //            getInvoiceRequest.HEADER_ONLY = downloadcontent ? "N" : "Y";   // "Y": get header only , "N": also get content 
    //            getInvoiceRequest.SMM_CONTENT_TYPE = (contenttype == "PDF") ? SMM_CONTENT_TYPE.PDF : SMM_CONTENT_TYPE.ALL;

    //            getInvoiceRequest.SMM_SEARCH_KEY = invoiceSearchKey;
    //            getInvoiceRequest.REQUEST_HEADER = _requestHeader;

    //            //invoiceList = _service.GetInvoice(getInvoiceRequest);
    //            invoiceList = Measure<GetSMMRequest, SMM[]>(_service.GetSMM, getInvoiceRequest);


    //            logger.Info("{0} adet, OK", invoiceList.Count());

    //            StringBuilder tmpsbresponse = new StringBuilder();
    //            StringBuilder tmpsbresponsefull = new StringBuilder();

    //            foreach (SMM smm in invoiceList)
    //            {
    //                //if (invoice.CONTENT != null)
    //                //{
    //                //    // download if content exists..
    //                //    string extension = ".xml";
    //                //    if (invoice.CONTENT.contentType.Contains("pdf"))
    //                //    {
    //                //        extension = ".pdf";
    //                //    }
    //                //    else if (invoice.CONTENT.contentType.Contains("excel"))
    //                //    {
    //                //        extension = ".xls";
    //                //    }
    //                //    else if (invoice.CONTENT.contentType.Contains("zip"))
    //                //    {
    //                //        extension = ".zip";
    //                //    }
    //                //    File.WriteAllBytes(Path.Combine(_path, invoice.ID + extension), invoice.CONTENT.Value);
    //                //}


    //                tmpsbresponse.AppendLine("UUID=" + smm.UUID + '\t' +
    //                                        "ID=" + smm.ID + '\t' +
    //                                        "FROM=" + smm.HEADER.FROM + '\t' +
    //                                        "TO=" + smm.HEADER.TO + '\t' +
    //                                        //"SUPPLIER=" + invoice.HEADER.SUPPLIER + '\t' +
    //                                        //"CUSTOMER=" + invoice.HEADER.CUSTOMER + '\t' +
    //                                        "SENDER=" + smm.HEADER.SENDER + '\t' +
    //                                        "RECEIVER=" + smm.HEADER.RECEIVER + '\r' + '\n'
    //                                        );


    //                tmpsbresponsefull.AppendLine("--------------------------------------------------------------------------------------------------------");

    //                if (smm.CONTENT.contentType.Contains("pdf"))
    //                    File.WriteAllBytes(@"L:\gidendir\" + smm.UUID + ".pdf", smm.CONTENT.Value);
    //                else
    //                    File.WriteAllBytes(@"L:\gidendir\" + smm.UUID + ".xls", smm.CONTENT.Value);
    //            }

    //            File.WriteAllBytes(Path.Combine(_path, "GetInvoice - List.txt"), System.Text.Encoding.UTF8.GetBytes(tmpsbresponse.ToString()));
    //            File.WriteAllBytes(Path.Combine(_path, "GetInvoice - Response.txt"), System.Text.Encoding.UTF8.GetBytes(tmpsbresponsefull.ToString()));

    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }

    //        return invoiceList;
    //    }

    //    /// <summary>
    //    /// faturano ve ettn si verilen faturanın durum sorgulanması
    //    /// </summary>
    //    /// <param name="title"></param>
    //    public void Test_GetSmmStatus(string smmuuid)
    //    {
    //        try
    //        {
    //            logger.Info("GetInvoiceStatus test...");

    //            GetSMMStatusRequest getSmmStatusRequest = new GetSMMStatusRequest()
    //            {
    //                REQUEST_HEADER = _requestHeader,
    //                SMM = new SMM()
    //                {
    //                    //ID = smmNo,
    //                    UUID = smmuuid,
    //                }
    //            };

    //            GetSMMStatusResponse getSmmStatusResponse = Measure<GetSMMStatusRequest, GetSMMStatusResponse>(_service.GetSMMStatus, getSmmStatusRequest);

    //            Console.WriteLine("STATUS : " + getSmmStatusResponse.SMM_STATUS.STATUS +
    //                Environment.NewLine +
    //                "STATUS DESC." + getSmmStatusResponse.SMM_STATUS.STATUS_DESCRIPTION);

    //            logger.Info("Ok {0} ({1})", getSmmStatusResponse.SMM_STATUS.STATUS, getSmmStatusResponse.SMM_STATUS.STATUS_DESCRIPTION);

    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    #endregion


    //    #region GetUserList, CheckUser, GetUserListBinary

    //    /// <summary>
    //    /// EDM web servis GİB e-fatura mükellef tam Listesini alma
    //    /// </summary>
    //    public void Test_GetUserList(DateTime? fromDate = null, string unit = null)
    //    {
    //        try
    //        {
    //            logger.Info("GetUserList test...");

    //            GetUserListRequest getUserListRequest = new GetUserListRequest();
    //            getUserListRequest.REQUEST_HEADER = _requestHeader;
    //            if (fromDate.HasValue)
    //            {
    //                getUserListRequest.REGISTER_TIME_START = fromDate.Value;
    //                getUserListRequest.REGISTER_TIME_STARTSpecified = true;
    //            }
    //            getUserListRequest.UNIT = unit;

    //            //GetUserListResponse getUserListResponse = _service.GetUserList(getUserListRequest);
    //            GetUserListResponse getUserListResponse = Measure<GetUserListRequest, GetUserListResponse>(_service.GetUserList, getUserListRequest);

    //            logger.Info("{0} adet, OK", getUserListResponse.Items.Count());

    //            GIBUSER[] gibusers = getUserListResponse.Items;

    //            // yalnızca PK ları istenirse.
    //            GIBUSER[] gibuserPKs = gibusers.Where(t => t.UNIT == "PK").ToArray();

    //            int i = 0;
    //            Parallel.ForEach(gibuserPKs, new ParallelOptions() { MaxDegreeOfParallelism = 16 }, gibuser =>
    //            {
    //                logger.Info(string.Format(@"{0} {1} {2} {3} {4} {5}",
    //                        gibuser.TITLE,
    //                        gibuser.IDENTIFIER,
    //                        gibuser.TYPE,
    //                        gibuser.UNIT,
    //                        gibuser.ALIAS,
    //                        gibuser.ALIAS_CREATION_TIME));

    //                //i++;
    //                //if (i % 10 == 0)
    //                //{
    //                //    break;

    //                //    //logger.Info("     press ESC to exit or else to continue..");
    //                //    //var keyInfo = Console.ReadKey();
    //                //    //if (keyInfo.Key == ConsoleKey.Escape)
    //                //    //{
    //                //    //    break;
    //                //    //}
    //                //}
    //            });

    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    public void Test_GetUserListBinary(DateTime? fromDate = null, string unit = null)
    //    {
    //        try
    //        {
    //            logger.Info("GetUserListBinary test...");

    //            GetUserListBinaryRequest getUserListRequest = new GetUserListBinaryRequest();
    //            getUserListRequest.REQUEST_HEADER = _requestHeader;
    //            //if (fromDate.HasValue)
    //            //{
    //            //    getUserListRequest.REGISTER_TIME_START = fromDate.Value;
    //            //    getUserListRequest.REGISTER_TIME_STARTSpecified = true;
    //            //}
    //            //getUserListRequest.UNIT = unit;

    //            //GetUserListResponse getUserListResponse = _service.GetUserList(getUserListRequest);
    //            GetUserListBinaryResponse getUserListResponse = Measure<GetUserListBinaryRequest, GetUserListBinaryResponse>(_service.GetUserListBinary, getUserListRequest);

    //            //return & result
    //            byte[] userlistdata = getUserListResponse.Item.Value;

    //            File.WriteAllBytes(Path.Combine(@"C:\EDM", "GetUserListBinary_xml.zip"), userlistdata);

    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    /// <summary>
    //    /// Vergi Kimlik No ile e-fatura mükellefi arama
    //    /// </summary>
    //    /// <param name="identifier"></param>
    //    public void Test_CheckUser_byIdentifier(string vkn)
    //    {
    //        try
    //        {
    //            logger.Info("CheckUser byIdentifier test...");

    //            CheckUserRequest checkUserRequest = new CheckUserRequest();
    //            checkUserRequest.USER = new GIBUSER();
    //            checkUserRequest.USER.IDENTIFIER = vkn;
    //            checkUserRequest.USER.UNIT = "Pk";
    //            checkUserRequest.REQUEST_HEADER = _requestHeader;

    //            //GIBUSER[] gibusers = _service.CheckUser(checkUserRequest);
    //            GIBUSER[] gibusers = Measure<CheckUserRequest, GIBUSER[]>(_service.CheckUser, checkUserRequest);

    //            logger.Info("{0} adet, OK", gibusers.Count());
    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }

    //    }

    //    /// <summary>
    //    /// Firma Ünvanı ile  e-fatura mükellefi arama
    //    /// </summary>
    //    /// <param name="title">Firma Ünvanı</param>
    //    public void Test_CheckUser_byTitle(string title)
    //    {
    //        try
    //        {

    //            logger.Info("CheckUser byTitle test...");

    //            CheckUserRequest checkUserRequest = new CheckUserRequest();
    //            checkUserRequest.USER = new GIBUSER();
    //            checkUserRequest.USER.TITLE = title;
    //            checkUserRequest.REQUEST_HEADER = _requestHeader;

    //            //GIBUSER[] gibusers = _service.CheckUser(checkUserRequest);
    //            GIBUSER[] gibusers = Measure<CheckUserRequest, GIBUSER[]>(_service.CheckUser, checkUserRequest);

    //            logger.Info("{0} adet, OK", gibusers.Count());
    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    ///// <summary>
    //    ///// GİB e-fatura mükllef listesini xml içerik zipli olarak alınır
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_GetUserListBinary_XML()
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("GetUserListBinary XML test...");

    //    //        GetUserListBinaryRequest getUserListBinaryRequest = new GetUserListBinaryRequest();
    //    //        getUserListBinaryRequest.TYPE = GetUserListBinaryRequestTYPE.XML;
    //    //        getUserListBinaryRequest.REQUEST_HEADER = _requestHeader;

    //    //        //GetUserListBinaryResponse getUserListBinaryResponse = _service.GetUserListBinary(getUserListBinaryRequest);
    //    //        GetUserListBinaryResponse getUserListBinaryResponse = Measure<GetUserListBinaryRequest, GetUserListBinaryResponse>(_service.GetUserListBinary, getUserListBinaryRequest);

    //    //        byte[] userlistdata = getUserListBinaryResponse.Item.Value;
    //    //        File.WriteAllBytes(Path.Combine(_path, "GetUserListBinary_xml.zip"), userlistdata);
    //    //        string userliststring = System.Text.Encoding.UTF8.GetString(userlistdata);
    //    //        logger.Info("{0} bytes, OK", userlistdata.Length);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    ///// <summary>
    //    ///// e-fatura mükellef listesi .CSV içeriği şeklinde ve zipli olarak alınır
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_GetUserListBinary_CSV()
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("GetUserListBinary CSV test...");

    //    //        GetUserListBinaryRequest getUserListBinaryRequest = new GetUserListBinaryRequest();
    //    //        getUserListBinaryRequest.TYPE = GetUserListBinaryRequestTYPE.CSV;
    //    //        getUserListBinaryRequest.REQUEST_HEADER = _requestHeader;

    //    //        //GetUserListBinaryResponse getUserListBinaryResponse = _service.GetUserListBinary(getUserListBinaryRequest);
    //    //        GetUserListBinaryResponse getUserListBinaryResponse = Measure<GetUserListBinaryRequest, GetUserListBinaryResponse>(_service.GetUserListBinary, getUserListBinaryRequest);

    //    //        byte[] userlistdata = getUserListBinaryResponse.Item.Value;
    //    //        File.WriteAllBytes(Path.Combine(_path, "GetUserListBinary_csv.zip"), userlistdata);
    //    //        string userliststring = System.Text.Encoding.UTF8.GetString(userlistdata);
    //    //        logger.Info("{0} bytes, OK", userlistdata.Length);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    ///// <summary>
    //    ///// Yalnızca İptal edilmiş Etiketlerin alınması
    //    ///// </summary>
    //    //public void Test_GetOnlyCancelledUserList(DateTime? fromDate = null)
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("Cancelled Only GetUserList test...");

    //    //        GetUserListRequest getUserListRequest = new GetUserListRequest();
    //    //        getUserListRequest.REQUEST_HEADER = _requestHeader;

    //    //        // 
    //    //        getUserListRequest.REGISTER_TIME_STARTSpecified = true;
    //    //        if (fromDate.HasValue)
    //    //            getUserListRequest.REGISTER_TIME_START = fromDate.Value;

    //    //        getUserListRequest.REMOVED_ONLYSpecified = true;
    //    //        getUserListRequest.REMOVED_ONLY = false;
    //    //        getUserListRequest.REMOVED_TIME_STARTSpecified = true;
    //    //        if (fromDate.HasValue)
    //    //            getUserListRequest.REMOVED_TIME_START = fromDate.Value;

    //    //        //GetUserListResponse getUserListResponse = _service.GetUserList(getUserListRequest);
    //    //        GetUserListResponse getUserListResponse = Measure<GetUserListRequest, GetUserListResponse>(_service.GetUserList, getUserListRequest);

    //    //        logger.Info("{0} adet, OK", getUserListResponse.Items.Count());

    //    //        GIBUSER[] gibusers = getUserListResponse.Items;

    //    //        // yalnızca PK ları istenirse.
    //    //        GIBUSER[] gibuserPKs = gibusers.Where(t => t.UNIT == "PK").ToArray();

    //    //        int i = 0;
    //    //        foreach (GIBUSER gibuser in gibuserPKs)
    //    //        {
    //    //            logger.Info(string.Format(@"{0} {1} {2} {3} {4} {5} {6}",
    //    //                    gibuser.TITLE,
    //    //                    gibuser.IDENTIFIER,
    //    //                    gibuser.TYPE,
    //    //                    gibuser.UNIT,
    //    //                    gibuser.ALIAS,
    //    //                    gibuser.ALIAS_CREATION_TIME,
    //    //                    gibuser.ALIAS_REMOVAL_TIME));

    //    //            i++;
    //    //            if (i % 10 == 0)
    //    //            {
    //    //                break;

    //    //                //logger.Info("     press ESC to exit or else to continue..");
    //    //                //var keyInfo = Console.ReadKey();
    //    //                //if (keyInfo.Key == ConsoleKey.Escape)
    //    //                //{
    //    //                //    break;
    //    //                //}
    //    //            }
    //    //        }

    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    ///// <summary>
    //    ///// İptal edilenlerle birlikte aktif etiketlerin alınması
    //    ///// </summary>
    //    //public void Test_GetWithCancelledUserList(DateTime? fromDate = null)
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("With Cancelled GetUserList test...");

    //    //        GetUserListRequest getUserListRequest = new GetUserListRequest();
    //    //        getUserListRequest.REQUEST_HEADER = _requestHeader;
    //    //        if (fromDate.HasValue)
    //    //        {
    //    //            getUserListRequest.REGISTER_TIME_START = fromDate.Value;
    //    //            getUserListRequest.REGISTER_TIME_STARTSpecified = true;
    //    //            getUserListRequest.REMOVED_TIME_START = fromDate.Value;
    //    //            getUserListRequest.REMOVED_TIME_STARTSpecified = true;
    //    //        }


    //    //        //GetUserListResponse getUserListResponse = _service.GetUserList(getUserListRequest);
    //    //        GetUserListResponse getUserListResponse = Measure<GetUserListRequest, GetUserListResponse>(_service.GetUserList, getUserListRequest);

    //    //        logger.Info("{0} adet, OK", getUserListResponse.Items.Count());

    //    //        GIBUSER[] gibusers = getUserListResponse.Items;

    //    //        // yalnızca PK ları istenirse.
    //    //        GIBUSER[] gibuserPKs = gibusers.Where(t => t.UNIT == "PK").ToArray();

    //    //        int i = 0;
    //    //        foreach (GIBUSER gibuser in gibuserPKs)
    //    //        {
    //    //            logger.Info(string.Format(@"{0} {1} {2} {3} {4} {5} {6}",
    //    //                    gibuser.TITLE,
    //    //                    gibuser.IDENTIFIER,
    //    //                    gibuser.TYPE,
    //    //                    gibuser.UNIT,
    //    //                    gibuser.ALIAS,
    //    //                    gibuser.ALIAS_CREATION_TIME,
    //    //                    gibuser.ALIAS_REMOVAL_TIME));

    //    //            i++;
    //    //            if (i % 10 == 0)
    //    //            {
    //    //                break;

    //    //                //logger.Info("     press ESC to exit or else to continue..");
    //    //                //var keyInfo = Console.ReadKey();
    //    //                //if (keyInfo.Key == ConsoleKey.Escape)
    //    //                //{
    //    //                //    break;
    //    //                //}
    //    //            }
    //    //        }

    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    //#endregion


    //    //// fatura gönderimi
    //    //#region SendInvoice

    //    //public void Test_SendInvoiceMultiTest(string ublfilefullpath,
    //    //                                       int multiplexcount = 1,
    //    //                                       string invoiceUUID = null,
    //    //                                       string invoiceid = null,
    //    //                                       string receiverPostBox = "urn:mail:defaultpk@edmbilisim.com.tr",
    //    //                                       string receiverVkn = null,
    //    //                                       string senderPostBox = "urn:mail:defaultgb@edmbilisim.com.tr",
    //    //                                       string senderVkn = null,
    //    //                                       string serialRequested = null,
    //    //                                       bool relogin = false)
    //    //{
    //    //    try
    //    //    {
    //    //        if (relogin)
    //    //            Test_Login();

    //    //        logger.Info("SendInvoice multi test...");

    //    //        byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);

    //    //        hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
    //    //            = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));

    //    //        // smooth serialize
    //    //        string invoiceUblXmlStr
    //    //            = ublinvoice.SerializeF();

    //    //        List<INVOICE> cntrinvoiceList = new List<INVOICE>();


    //    //        for (int i = 0; i < multiplexcount; i++)
    //    //        {
    //    //            if (ublinvoice != null)
    //    //            {
    //    //                if (ublinvoice.UUID != null)
    //    //                {
    //    //                    if (string.IsNullOrEmpty(invoiceUUID) || string.IsNullOrWhiteSpace(invoiceUUID))
    //    //                    {
    //    //                        ublinvoice.UUID.Value = (ublinvoice.UUID == null) ? null : Guid.NewGuid().ToString();
    //    //                    }
    //    //                    else
    //    //                    {
    //    //                        ublinvoice.UUID.Value = (ublinvoice.UUID == null) ? null : invoiceUUID;
    //    //                    }
    //    //                }

    //    //                if (ublinvoice.ID == null)
    //    //                {
    //    //                    ublinvoice.ID = new hm.common.Ubltr.Invoice21.IDType();
    //    //                }

    //    //                if (!string.IsNullOrEmpty(invoiceid))
    //    //                {
    //    //                    ublinvoice.ID.Value = invoiceid;
    //    //                }

    //    //                if ((receiverVkn != null) && (ublinvoice.AccountingCustomerParty != null))
    //    //                {
    //    //                    ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value = receiverVkn;
    //    //                }

    //    //                invoiceUblXmlStr = ublinvoice.SerializeF();
    //    //                invoiceUblXmlStr = timeZoneRegex.Replace(invoiceUblXmlStr, "$1");
    //    //            }

    //    //            ublfilebytes = System.Text.Encoding.UTF8.GetBytes(invoiceUblXmlStr);
    //    //            ////

    //    //            /// set receiver sample

    //    //            string receiverVKNTCKN = (ublinvoice == null) ? null : ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN").First().ID.Value;

    //    //            // create connector invoice
    //    //            INVOICE cntrinvoice = new SMM();

    //    //            if (ublinvoice != null)
    //    //            {
    //    //                cntrinvoice.ID = (ublinvoice.ID == null) ? null : ublinvoice.ID.Value;
    //    //                cntrinvoice.UUID = (ublinvoice.UUID == null) ? null : ublinvoice.UUID.Value;
    //    //            }

    //    //            cntrinvoice.HEADER = new INVOICEHEADER()
    //    //            {
    //    //                //INTERNETSALES = true,
    //    //                SENDER = (ublinvoice == null) ? null : (ublinvoice.AccountingSupplierParty == null) ? null : ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    //                FROM = senderPostBox ?? "urn:mail:defaultgb@edmbilisim.com.tr", // "defaultgb@edmbilisim.com.tr", // "urn:mail:defaultgb@edmbilisim.com.tr",
    //    //                RECEIVER = receiverVKNTCKN,                                     //ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    //                TO = receiverPostBox ?? "urn:mail:defaultpk@edmbilisim.com.tr", //"urn:mail:defaultpk@edmbilisim.com.tr", //"defaultpk@edmbilisim.com.tr", // "defaultpk@edmbilisim.com.tr",
    //    //                INVOICESERIAL_REQUESTED = serialRequested,
    //    //                //EARCHIVE_REPORT_SENDDATE = null,

    //    //            };
    //    //            cntrinvoice.CONTENT = new EdmService.base64Binary()
    //    //            {
    //    //                Value = ublfilebytes
    //    //            };

    //    //            cntrinvoiceList.Add(cntrinvoice);

    //    //        }


    //    //        SendSMMRequest SendSMMRequest = new SendSMMRequest();
    //    //        SendSMMRequest.REQUEST_HEADER = _requestHeader;
    //    //        SendSMMRequest.RECEIVER = new SendSMMRequestRECEIVER()
    //    //        {
    //    //            vkn = cntrinvoiceList[0].HEADER.RECEIVER,
    //    //            alias = cntrinvoiceList[0].HEADER.TO,
    //    //        };
    //    //        SendSMMRequest.INVOICE = cntrinvoiceList.ToArray();

    //    //        var watch = System.Diagnostics.Stopwatch.StartNew();

    //    //        //SendSMMResponse SendSMMResponse = _service.SendInvoice(SendSMMRequest);
    //    //        SendSMMResponse SendSMMResponse = Measure<SendSMMRequest, SendSMMResponse>(_service.SendInvoice, SendSMMRequest);

    //    //        watch.Stop();
    //    //        var elapsedMs = watch.ElapsedMilliseconds;

    //    //        logger.Info("Ok " + elapsedMs.ToString() + " ms.");
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;


    //    //        logger.Error("FaultException fault message:" + fexp.Message);
    //    //        logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);

    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    ///// <summary>
    //    ///// Fatura Gönderimi
    //    ///// </summary>
    //    ///// <param name="fromVkn"></param>
    //    ///// <param name="fromAlias"></param>
    //    ///// <param name="toVkn"></param>
    //    ///// <param name="toAlias"></param>
    //    ///// <param name="SMM[]"></param>
    //    ///// <returns></returns>
    //    //public void Test_SendInvoice_multiple_from_class()
    //    //{
    //    //    logger.Info("SendInvoice multiple created invoices test...");

    //    //    List<hm.common.Ubltr.Invoice21.InvoiceType> ublinvoices = CreateInvoiceTypeTestObject("EDM", 100, 10);

    //    //    List<INVOICE> cntrinvoiceList = new List<INVOICE>();

    //    //    foreach (hm.common.Ubltr.Invoice21.InvoiceType ublinvoice in ublinvoices)
    //    //    {
    //    //        string ublinvoicestr = ublinvoice.SerializeF();
    //    //        byte[] ublfilebytes = System.Text.Encoding.UTF8.GetBytes(ublinvoicestr);

    //    //        // create connector invoice
    //    //        INVOICE cntrinvoice = new SMM();
    //    //        cntrinvoice.ID = ublinvoice.ID.Value;
    //    //        cntrinvoice.UUID = ublinvoice.UUID.Value;
    //    //        cntrinvoice.HEADER = new INVOICEHEADER()
    //    //        {
    //    //            SENDER = ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    //            FROM = "urn:mail:defaultgb@edmbilisim.com.tr",
    //    //            RECEIVER = ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    //            TO = "urn:mail:defaultpk@edmbilisim.com.tr",
    //    //        };

    //    //        cntrinvoice.CONTENT = new EdmService.base64Binary()
    //    //        {
    //    //            Value = ublfilebytes
    //    //        };

    //    //        cntrinvoiceList.Add(cntrinvoice);
    //    //    }

    //    //    SendSMMRequest SendSMMRequest = new SendSMMRequest();
    //    //    SendSMMRequest.REQUEST_HEADER = _requestHeader;
    //    //    SendSMMRequest.RECEIVER = new SendSMMRequestRECEIVER()
    //    //    {
    //    //        vkn = cntrinvoiceList[0].HEADER.RECEIVER,
    //    //        alias = cntrinvoiceList[0].HEADER.TO,
    //    //    };
    //    //    SendSMMRequest.INVOICE = cntrinvoiceList.ToArray();

    //    //    //SendSMMResponse SendSMMResponse = _service.SendInvoice(SendSMMRequest);
    //    //    SendSMMResponse SendSMMResponse = Measure<SendSMMRequest, SendSMMResponse>(_service.SendInvoice, SendSMMRequest);

    //    //    logger.Info("Ok");
    //    //}

    //    ///// <summary>
    //    ///// kayıtlı XML fatura dosyasının gönderimi örneği
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_SendInvoice_singlefromfile(string ublfilefullpath, int multiplexcount = 1)
    //    //{
    //    //    logger.Info("SendInvoice from file test...");

    //    //    List<INVOICE> cntrinvoiceList = new List<INVOICE>();

    //    //    byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);

    //    //    hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
    //    //        = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));

    //    //    // set receiver alias
    //    //    string receiverPostBox = "urn:mail:defaultpk@edmbilisim.com.tr";
    //    //    string receiverVKN = ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN").First().ID.Value;
    //    //    if (receiverVKN == "7750409379")
    //    //    {
    //    //        receiverPostBox = "defaultpk";
    //    //    }
    //    //    string senderOutBox = "urn:mail:defaultgb@edmbilisim.com.tr";  // "defaultgb@edmbilisim.com.tr", // "urn:mail:defaultgb@edmbilisim.com.tr",


    //    //    for (int i = 0; i < multiplexcount; i++)
    //    //    {

    //    //        //// aynı user- farklı firma ozel test hazırlığı
    //    //        //senderOutBox = "urn:mail:avsaroglugb@kollektif.com";
    //    //        //receiverPostBox = "urn:mail:avsaroglupk@kollektif.com";
    //    //        ublinvoice.UUID.Value = Guid.NewGuid().ToString();
    //    //        string invoiceUblXmlStr = ublinvoice.SerializeF();
    //    //        invoiceUblXmlStr = timeZoneRegex.Replace(invoiceUblXmlStr, "$1");
    //    //        ublfilebytes = System.Text.Encoding.UTF8.GetBytes(invoiceUblXmlStr);
    //    //        ////



    //    //        // create connector invoice
    //    //        INVOICE cntrinvoice = new SMM();
    //    //        cntrinvoice.ID = ublinvoice.ID.Value;
    //    //        cntrinvoice.UUID = ublinvoice.UUID.Value;
    //    //        cntrinvoice.HEADER = new INVOICEHEADER()
    //    //        {
    //    //            SENDER = ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    //            FROM = senderOutBox,
    //    //            RECEIVER = ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    //            TO = receiverPostBox,

    //    //        };
    //    //        cntrinvoice.CONTENT = new EdmService.base64Binary()
    //    //        {
    //    //            Value = ublfilebytes
    //    //        };

    //    //        cntrinvoiceList.Add(cntrinvoice);

    //    //    }


    //    //    SendSMMRequest SendSMMRequest = new SendSMMRequest();
    //    //    SendSMMRequest.REQUEST_HEADER = _requestHeader;
    //    //    SendSMMRequest.RECEIVER = new SendSMMRequestRECEIVER()
    //    //    {
    //    //        vkn = cntrinvoiceList[0].HEADER.RECEIVER,
    //    //        alias = cntrinvoiceList[0].HEADER.TO,
    //    //    };
    //    //    SendSMMRequest.INVOICE = cntrinvoiceList.ToArray();

    //    //    //SendSMMResponse SendSMMResponse = _service.SendInvoice(SendSMMRequest);
    //    //    SendSMMResponse SendSMMResponse = Measure<SendSMMRequest, SendSMMResponse>(_service.SendInvoice, SendSMMRequest);

    //    //    logger.Info("Ok " + SendSMMResponse.REQUEST_RETURN.INTL_TXN_ID.ToString());
    //    //}

    //    ///// <summary>
    //    ///// kayıtlı birden çok XML fatura dosyasının gönderimi örneği
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_SendInvoice_multiple(string[] ublfilefullpaths)
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("SendInvoice multiple invoices test...");

    //    //        List<INVOICE> cntrinvoiceList = new List<INVOICE>();

    //    //        foreach (string ublfilefullpath in ublfilefullpaths)
    //    //        {
    //    //            byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);

    //    //            hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
    //    //                = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));


    //    //            // create connector invoice
    //    //            INVOICE cntrinvoice = new SMM();
    //    //            cntrinvoice.ID = ublinvoice.ID.Value;
    //    //            cntrinvoice.UUID = ublinvoice.UUID.Value;
    //    //            cntrinvoice.HEADER = new INVOICEHEADER()
    //    //            {
    //    //                SENDER = ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    //                FROM = "urn:mail:defaultgb@edmbilisim.com.tr",
    //    //                RECEIVER = ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    //                TO = "urn:mail:defaultgb@edmbilisim.com.tr",
    //    //            };

    //    //            cntrinvoice.CONTENT = new EdmService.base64Binary()
    //    //            {
    //    //                Value = ublfilebytes
    //    //            };

    //    //            cntrinvoiceList.Add(cntrinvoice);
    //    //        }

    //    //        SendSMMRequest SendSMMRequest = new SendSMMRequest();
    //    //        SendSMMRequest.REQUEST_HEADER = _requestHeader;
    //    //        SendSMMRequest.RECEIVER = new SendSMMRequestRECEIVER()
    //    //        {
    //    //            vkn = cntrinvoiceList[0].HEADER.RECEIVER,
    //    //            alias = cntrinvoiceList[0].HEADER.TO,
    //    //        };
    //    //        SendSMMRequest.INVOICE = cntrinvoiceList.ToArray();

    //    //        //SendSMMResponse SendSMMResponse = _service.SendInvoice(SendSMMRequest);
    //    //        SendSMMResponse SendSMMResponse = Measure<SendSMMRequest, SendSMMResponse>(_service.SendInvoice, SendSMMRequest);

    //    //        logger.Info("Ok");
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    ///// <summary>
    //    ///// taslaktan fatura gönderimi örneği
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_SendInvoice_fromLoadedDraft(string uuid, string sender = null, string senderOutBox = null, string receiver = null, string receiverPostBox = null)
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("SendInvoice from Loaded Draft test...");

    //    //        List<INVOICE> cntrinvoiceList = new List<INVOICE>();

    //    //        // create connector invoice
    //    //        INVOICE cntrinvoice = new SMM();
    //    //        cntrinvoice.UUID = uuid;


    //    //        cntrinvoice.HEADER = new INVOICEHEADER()
    //    //        {
    //    //            SENDER = sender,
    //    //            FROM = senderOutBox,
    //    //            RECEIVER = receiver,
    //    //            TO = receiverPostBox,
    //    //        };


    //    //        //// opsiyonel - gönderim anında fatura revize edilebilir:
    //    //        //if (!string.IsNullOrEmpty(ublfilefullpath))
    //    //        //{
    //    //        //    byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);
    //    //        //    hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
    //    //        //       = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));
    //    //        //    ublinvoice.UUID.Value = Guid.NewGuid().ToString();
    //    //        //    string invoiceUblXmlStr = ublinvoice.SerializeF();
    //    //        //    invoiceUblXmlStr = timeZoneRegex.Replace(invoiceUblXmlStr, "$1");
    //    //        //    ublfilebytes = System.Text.Encoding.UTF8.GetBytes(invoiceUblXmlStr);
    //    //        //    cntrinvoice.CONTENT = new EdmService.base64Binary()
    //    //        //    {
    //    //        //        Value = ublfilebytes
    //    //        //    };
    //    //        //}


    //    //        cntrinvoiceList.Add(cntrinvoice);


    //    //        SendSMMRequest SendSMMRequest = new SendSMMRequest();
    //    //        SendSMMRequest.REQUEST_HEADER = _requestHeader;

    //    //        // opsiyonel - gönderim anında alıcı revize edilebilir:
    //    //        //SendSMMRequest.RECEIVER = new SendSMMRequestRECEIVER()
    //    //        //{
    //    //        //    vkn = receiver,
    //    //        //    alias = receiverPostBox,
    //    //        //};

    //    //        SendSMMRequest.INVOICE = cntrinvoiceList.ToArray();

    //    //        //SendSMMResponse SendSMMResponse = _service.SendInvoice(SendSMMRequest);
    //    //        SendSMMResponse SendSMMResponse = Measure<SendSMMRequest, SendSMMResponse>(_service.SendInvoice, SendSMMRequest);

    //    //        logger.Info("Ok " + SendSMMResponse.REQUEST_RETURN.INTL_TXN_ID.ToString());
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        //logger.Error("FaultException with RequestFault catched:");
    //    //        //logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}


    //    //#endregion

    //    //// taslağa fatura yükleme
    //    //#region LoadInvoice

    //    ///// <summary>
    //    ///// Fatura Gönderimi
    //    ///// </summary>
    //    ///// <param name="fromVkn"></param>
    //    ///// <param name="fromAlias"></param>
    //    ///// <param name="toVkn"></param>
    //    ///// <param name="toAlias"></param>
    //    ///// <param name="SMM[]"></param>
    //    ///// <returns></returns>
    //    ////public void Test_LoadInvoice_multiple_from_class()
    //    ////{
    //    ////    logger.Info("LoadInvoice multiple created invoices test...");

    //    ////    List<hm.common.Ubltr.Invoice21.InvoiceType> ublinvoices = CreateInvoiceTypeTestObject("EDM", 100, 10);

    //    ////    List<INVOICE> cntrinvoiceList = new List<INVOICE>();

    //    ////    foreach (hm.common.Ubltr.Invoice21.InvoiceType ublinvoice in ublinvoices)
    //    ////    {
    //    ////        string ublinvoicestr = ublinvoice.SerializeF();
    //    ////        byte[] ublfilebytes = System.Text.Encoding.UTF8.GetBytes(ublinvoicestr);

    //    ////        // create connector invoice
    //    ////        INVOICE cntrinvoice = new SMM();
    //    ////        cntrinvoice.ID = ublinvoice.ID.Value;
    //    ////        cntrinvoice.UUID = ublinvoice.UUID.Value;
    //    ////        cntrinvoice.HEADER = new INVOICEHEADER()
    //    ////        {
    //    ////            SENDER = ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    ////            FROM = "urn:mail:defaultgb@edmbilisim.com.tr",
    //    ////            RECEIVER = ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    ////            TO = "urn:mail:defaultpk@edmbilisim.com.tr",
    //    ////        };

    //    ////        cntrinvoice.CONTENT = new EdmService.base64Binary()
    //    ////        {
    //    ////            Value = ublfilebytes
    //    ////        };

    //    ////        cntrinvoiceList.Add(cntrinvoice);
    //    ////    }

    //    ////    LoadInvoiceRequest loadInvoiceRequest = new LoadInvoiceRequest();
    //    ////    loadInvoiceRequest.REQUEST_HEADER = _requestHeader;
    //    ////    loadInvoiceRequest.RECEIVER = new LoadInvoiceRequestRECEIVER()
    //    ////    {
    //    ////        vkn = cntrinvoiceList[0].HEADER.RECEIVER,
    //    ////        alias = cntrinvoiceList[0].HEADER.TO,
    //    ////    };
    //    ////    loadInvoiceRequest.INVOICE = cntrinvoiceList.ToArray();

    //    ////    LoadInvoiceResponse loadInvoiceResponse = _service.LoadInvoice(loadInvoiceRequest);

    //    ////    logger.Info("Ok");


    //    ////}

    //    ///// <summary>
    //    ///// kayıtlı XML fatura dosyasının gönderimi örneği
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_LoadInvoice_singlefromfile(string ublfilefullpath,
    //    //                                                int multiplexcount = 1,
    //    //                                                string invoiceUUID = null,
    //    //                                                string invoiceid = null,
    //    //                                                string receiverPostBox = "urn:mail:defaultpk@edmbilisim.com.tr",
    //    //                                                string receiverVkn = null,
    //    //                                                string senderPostBox = "urn:mail:defaultgb@edmbilisim.com.tr",
    //    //                                                string senderVkn = null,
    //    //                                                bool? generateInvoiceNumberOnLoad = null,
    //    //                                                string serialRequested = null)
    //    //{

    //    //    try
    //    //    {
    //    //        logger.Info("LoadInvoice from file test...");

    //    //        List<INVOICE> cntrinvoiceList = new List<INVOICE>();

    //    //        byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);

    //    //        hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
    //    //            = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));

    //    //        // set receiver alias
    //    //        //string receiverPostBox = "urn:mail:defaultpk@edmbilisim.com.tr";
    //    //        //string senderOutBox = "urn:mail:defaultgb@edmbilisim.com.tr";  // "defaultgb@edmbilisim.com.tr", // "urn:mail:defaultgb@edmbilisim.com.tr",


    //    //        for (int i = 0; i < multiplexcount; i++)
    //    //        {

    //    //            if (string.IsNullOrEmpty(invoiceUUID) || string.IsNullOrWhiteSpace(invoiceUUID))
    //    //            {
    //    //                ublinvoice.UUID.Value = Guid.NewGuid().ToString();
    //    //            }
    //    //            else
    //    //            {
    //    //                ublinvoice.UUID.Value = invoiceUUID;
    //    //            }

    //    //            if (ublinvoice.ID == null)
    //    //            {
    //    //                ublinvoice.ID = new hm.common.Ubltr.Invoice21.IDType();
    //    //            }
    //    //            if (!string.IsNullOrEmpty(invoiceid))
    //    //            {
    //    //                ublinvoice.ID.Value = invoiceid;
    //    //            }

    //    //            if (receiverVkn != null)
    //    //            {
    //    //                ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value = receiverVkn;
    //    //            }

    //    //            string invoiceUblXmlStr = ublinvoice.SerializeF();
    //    //            invoiceUblXmlStr = timeZoneRegex.Replace(invoiceUblXmlStr, "$1");
    //    //            ublfilebytes = System.Text.Encoding.UTF8.GetBytes(invoiceUblXmlStr);
    //    //            ////


    //    //            // create connector invoice
    //    //            INVOICE cntrinvoice = new SMM();
    //    //            cntrinvoice.ID = ublinvoice.ID.Value;
    //    //            cntrinvoice.UUID = ublinvoice.UUID.Value;
    //    //            cntrinvoice.HEADER = new INVOICEHEADER()
    //    //            {
    //    //                SENDER = senderVkn,
    //    //                FROM = senderPostBox,
    //    //                RECEIVER = receiverVkn,
    //    //                TO = receiverPostBox,
    //    //                INVOICESERIAL_REQUESTED = serialRequested,
    //    //            };

    //    //            cntrinvoice.CONTENT = new EdmService.base64Binary()
    //    //            {
    //    //                Value = ublfilebytes
    //    //            };

    //    //            cntrinvoiceList.Add(cntrinvoice);

    //    //        }

    //    //        LoadInvoiceRequest loadInvoiceRequest = new LoadInvoiceRequest();

    //    //        ////_requestHeader.ACTION_DATESpecified = false;
    //    //        //_requestHeader.SESSION_ID = "0";

    //    //        loadInvoiceRequest.REQUEST_HEADER = _requestHeader;
    //    //        loadInvoiceRequest.INVOICE = cntrinvoiceList.ToArray();
    //    //        if (generateInvoiceNumberOnLoad.HasValue)
    //    //        {
    //    //            loadInvoiceRequest.GENERATEINVOICEIDONLOAD = generateInvoiceNumberOnLoad.Value;
    //    //        }

    //    //        //LoadInvoiceResponse loadInvoiceResponse = _service.LoadInvoice(loadInvoiceRequest);
    //    //        LoadInvoiceResponse loadInvoiceResponse = Measure<LoadInvoiceRequest, LoadInvoiceResponse>(_service.LoadInvoice, loadInvoiceRequest);

    //    //        logger.Info("Ok " + loadInvoiceResponse.REQUEST_RETURN.INTL_TXN_ID.ToString());
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        //logger.Error("FaultException with RequestFault catched:");
    //    //        //logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    ///// <summary>
    //    ///// kayıtlı birden çok XML fatura dosyasının gönderimi örneği
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    ////public void Test_LoadInvoice_multiple(string[] ublfilefullpaths)
    //    ////{
    //    ////    try
    //    ////    {
    //    ////        logger.Info("LoadInvoice multiple invoices test...");

    //    ////        List<INVOICE> cntrinvoiceList = new List<INVOICE>();

    //    ////        foreach (string ublfilefullpath in ublfilefullpaths)
    //    ////        {
    //    ////            byte[] ublfilebytes = File.ReadAllBytes(ublfilefullpath);

    //    ////            hm.common.Ubltr.Invoice21.InvoiceType ublinvoice
    //    ////                = hm.common.Ubltr.Invoice21.InvoiceType.DeserializeF(System.Text.Encoding.UTF8.GetString(ublfilebytes));


    //    ////            // create connector invoice
    //    ////            INVOICE cntrinvoice = new SMM();
    //    ////            cntrinvoice.ID = ublinvoice.ID.Value;
    //    ////            cntrinvoice.UUID = ublinvoice.UUID.Value;
    //    ////            cntrinvoice.HEADER = new INVOICEHEADER()
    //    ////            {
    //    ////                SENDER = ublinvoice.AccountingSupplierParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    ////                FROM = "urn:mail:defaultgb@edmbilisim.com.tr",
    //    ////                RECEIVER = ublinvoice.AccountingCustomerParty.Party.PartyIdentification.Where(t => t.ID.schemeID == "VKN" || t.ID.schemeID == "TCKN" ).First().ID.Value,
    //    ////                TO = "urn:mail:defaultgb@edmbilisim.com.tr",
    //    ////            };

    //    ////            cntrinvoice.CONTENT = new EdmService.base64Binary()
    //    ////            {
    //    ////                Value = ublfilebytes
    //    ////            };

    //    ////            cntrinvoiceList.Add(cntrinvoice);
    //    ////        }

    //    ////        LoadInvoiceRequest loadInvoiceRequest = new LoadInvoiceRequest();
    //    ////        loadInvoiceRequest.REQUEST_HEADER = _requestHeader;
    //    ////        loadInvoiceRequest.RECEIVER = new LoadInvoiceRequestRECEIVER()
    //    ////        {
    //    ////            vkn = cntrinvoiceList[0].HEADER.RECEIVER,
    //    ////            alias = cntrinvoiceList[0].HEADER.TO,
    //    ////        };
    //    ////        loadInvoiceRequest.INVOICE = cntrinvoiceList.ToArray();

    //    ////        LoadInvoiceResponse loadInvoiceResponse = _service.LoadInvoice(loadInvoiceRequest);

    //    ////        logger.Info("Ok");
    //    ////    }
    //    ////    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    ////    {
    //    ////        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    ////        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    ////        logger.Error("FaultException with RequestFault catched:");
    //    ////        logger.Error("requestError XML:" + detail);
    //    ////        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    ////        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    ////        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    ////        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    ////        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    ////        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    ////        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    ////        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    ////    }
    //    ////    catch (System.ServiceModel.FaultException fex)
    //    ////    {
    //    ////        logger.Error("FaultException catched:");
    //    ////        logger.Error("FaultException fault code:" + fex.Code);
    //    ////        logger.Error("FaultException fault details:" + fex.Data);
    //    ////        logger.Error("FaultException fault message:" + fex.Message);
    //    ////        logger.Error("FaultException fault reason:" + fex.Reason);
    //    ////        logger.Error("FaultException :" + fex.ToString());
    //    ////    }
    //    ////    catch (Exception ex)
    //    ////    {
    //    ////        logger.Error("Exception catched:");
    //    ////        logger.Error("Exception data:" + ex.Data);
    //    ////        logger.Error("Exception message:" + ex.ToString());
    //    ////    }
    //    ////}

    //    //#endregion

    //    // fatura alma , indirme ve durum sorgulama


    //    //// okunan faturaların işaretlenmesi  



    //    //// gelen ticari faturaya yanıt gönderimi
    //    //#region InvoiceResponse

    //    ///// <summary>
    //    ///// gelen ticari faturanın KABUL edilmesi
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_SendInvoiceResponseWithServerSign_KABUL()
    //    //{
    //    //    try
    //    //    {

    //    //        //byte[] appresionsebytes = 

    //    //        logger.Info("SendInvoiceResponseWithServerSign for KABUL test...");

    //    //        SendInvoiceResponseWithServerSignRequest sendInvoiceResponseWithServerSignRequest
    //    //            = new SendInvoiceResponseWithServerSignRequest()
    //    //            {
    //    //                REQUEST_HEADER = _requestHeader,
    //    //                STATUS = "KABUL",
    //    //                INVOICE = new SMM[] {
    //    //                                        new SMM()
    //    //                                        {
    //    //                                            ID = "HGL2016000000105",
    //    //                                        },
    //    //                                    },
    //    //            };

    //    //        //SendInvoiceResponseWithServerSignResponse sendInvoiceResponseWithServerSignResponse
    //    //        //    = _service.SendInvoiceResponseWithServerSign(sendInvoiceResponseWithServerSignRequest);

    //    //        SendInvoiceResponseWithServerSignResponse sendInvoiceResponseWithServerSignResponse
    //    //            = Measure<SendInvoiceResponseWithServerSignRequest, SendInvoiceResponseWithServerSignResponse>(_service.SendInvoiceResponseWithServerSign, sendInvoiceResponseWithServerSignRequest);


    //    //        logger.Info("Ok");
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    ///// <summary>
    //    ///// gelen ticari faturanın RED edilmesi
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_SendInvoiceResponseWithServerSign_RED()
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("SendInvoiceResponseWithServerSign for RED test...");

    //    //        SendInvoiceResponseWithServerSignRequest sendInvoiceResponseWithServerSignRequest
    //    //            = new SendInvoiceResponseWithServerSignRequest()
    //    //            {
    //    //                REQUEST_HEADER = _requestHeader,
    //    //                DESCRIPTION = new string[] {
    //    //                                            "Fatura birim kodu bulunamadı: Fatura No: EBD2015000000016 Fatura Reddediliyor.",
    //    //                                    },
    //    //                STATUS = "RED",
    //    //                INVOICE = new SMM[] {
    //    //                                        new SMM()
    //    //                                        {
    //    //                                            //ID = "EBD2015000000016",
    //    //                                            //UUID = "6703b82a-a59f-40de-ac08-1603c651ff49",
    //    //                                            UUID = "b2c73626-92ac-425b-998d-d1329f5de1be",
    //    //                                        },
    //    //                                    },
    //    //            };

    //    //        //SendInvoiceResponseWithServerSignResponse sendInvoiceResponseWithServerSignResponse
    //    //        //    = _service.SendInvoiceResponseWithServerSign(sendInvoiceResponseWithServerSignRequest);

    //    //        SendInvoiceResponseWithServerSignResponse sendInvoiceResponseWithServerSignResponse 
    //    //            = Measure<SendInvoiceResponseWithServerSignRequest, SendInvoiceResponseWithServerSignResponse>(_service.SendInvoiceResponseWithServerSign, sendInvoiceResponseWithServerSignRequest);

    //    //        logger.Info("Ok");
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    //#endregion



    //    //#region archive-dearchive

    //    ///// <summary>
    //    ///// verilen faturanın arsivlenmesi
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_ArchiveSMM()
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("ARCHIVE Invoice test...");

    //    //        ArchiveInvoiceRequest archiveInvoiceRequest = new ArchiveInvoiceRequest()
    //    //        {
    //    //            REQUEST_HEADER = _requestHeader,
    //    //            ARCHIVE = new ArchiveInvoiceRequestARCHIVE()
    //    //            {
    //    //                valueSpecified = true,
    //    //                value = ArchiveInvoiceRequestARCHIVEValue.ARCHIVE,
    //    //                INVOICE = new SMM[]
    //    //                            {
    //    //                                new SMM()
    //    //                                {
    //    //                                    ID = "YSN2017000000004"
    //    //                                },
    //    //                                new SMM()
    //    //                                {
    //    //                                    UUID = "63e00f3b-5741-430d-b43a-7e4e0ae8021d",
    //    //                                },
    //    //                            },
    //    //            }
    //    //        };

    //    //        ArchiveInvoiceResponse getInvoiceStatusResponse = Measure<ArchiveInvoiceRequest, ArchiveInvoiceResponse>(_service.ArchiveInvoice, archiveInvoiceRequest);

    //    //        logger.Info("Ok");
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}




    //    //// <summary>
    //    ///// verilen faturanın arsivlenmesi
    //    ///// </summary>
    //    ///// <param name="title"></param>
    //    //public void Test_DeArchiveSMM()
    //    //{
    //    //    try
    //    //    {
    //    //        logger.Info("DEARCHIVE Invoice test...");

    //    //        ArchiveInvoiceRequest archiveInvoiceRequest = new ArchiveInvoiceRequest()
    //    //        {
    //    //            REQUEST_HEADER = _requestHeader,
    //    //            ARCHIVE = new ArchiveInvoiceRequestARCHIVE()
    //    //            {
    //    //                valueSpecified = true,
    //    //                value = ArchiveInvoiceRequestARCHIVEValue.DEARCHIVE,
    //    //                INVOICE = new SMM[]
    //    //                            {
    //    //                                new SMM()
    //    //                                {
    //    //                                    ID = "YSN2017000000004"
    //    //                                },
    //    //                                new SMM()
    //    //                                {
    //    //                                    UUID = "63e00f3b-5741-430d-b43a-7e4e0ae8021d",
    //    //                                },
    //    //                            },
    //    //            }
    //    //        };

    //    //        ArchiveInvoiceResponse getInvoiceStatusResponse = Measure<ArchiveInvoiceRequest, ArchiveInvoiceResponse>(_service.ArchiveInvoice, archiveInvoiceRequest);

    //    //        logger.Info("Ok");
    //    //    }
    //    //    catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //    //    {
    //    //        string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //    //        var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //    //        logger.Error("FaultException with RequestFault catched:");
    //    //        logger.Error("requestError XML:" + detail);
    //    //        //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //    //        //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //    //        //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //    //        //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //    //        //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //    //        //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //    //        //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //    //    }
    //    //    catch (System.ServiceModel.FaultException fex)
    //    //    {
    //    //        logger.Error("FaultException catched:");
    //    //        logger.Error("FaultException fault code:" + fex.Code);
    //    //        logger.Error("FaultException fault details:" + fex.Data);
    //    //        logger.Error("FaultException fault message:" + fex.Message);
    //    //        logger.Error("FaultException fault reason:" + fex.Reason);
    //    //        logger.Error("FaultException :" + fex.ToString());
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        logger.Error("Exception catched:");
    //    //        logger.Error("Exception data:" + ex.Data);
    //    //        logger.Error("Exception message:" + ex.ToString());
    //    //    }
    //    //}

    //    //#endregion



    //    //// yardımcı fonksiyonlar
    //    //#region helper tools

    //    #endregion


    //    #region MarkSMM

    //    /// <summary>
    //    /// verilen faturanın okunmuş olarak işaretlenmesi
    //    /// </summary>
    //    /// <param name="title"></param>
    //    public void Test_MarkSmm_asRead(string smmNo)
    //    {
    //        try
    //        {
    //            logger.Info("MARK SMM test...");

    //            MarkSMMRequest MarkSMMRequest = new MarkSMMRequest()
    //            {
    //                REQUEST_HEADER = _requestHeader,
    //                MARK = new MarkSMMRequestMARK()
    //                {
    //                    valueSpecified = true,
    //                    value = MarkSMMRequestMARKValue.READ,
    //                    SMM = new SMM[]
    //                                {
    //                                    new SMM()
    //                                    {
    //                                        ID = smmNo,
    //                                    },
    //                                },
    //                }
    //            };

    //            //MarkSMMResponse getInvoiceStatusResponse = _service.MarkSMM(MarkSMMRequest);
    //            MarkSMMResponse getInvoiceStatusResponse = Measure<MarkSMMRequest, MarkSMMResponse>(_service.MarkSMM, MarkSMMRequest);

    //            logger.Info("Ok");

    //            //MarkSMMRequest = new MarkSMMRequest()
    //            //{
    //            //    REQUEST_HEADER = _requestHeader,
    //            //    MARK = new MarkSMMRequestMARK()
    //            //    {
    //            //        valueSpecified = true,
    //            //        value = MarkSMMRequestMARKValue.READ,
    //            //        SMM = new SMM[]
    //            //                    {
    //            //                        new SMM()
    //            //                        {
    //            //                            ID = "EDM20150000000XX",
    //            //                        },
    //            //                    },
    //            //    }
    //            //};

    //            ////getInvoiceStatusResponse = _service.MarkSMM(MarkSMMRequest);
    //            //getInvoiceStatusResponse = Measure<MarkSMMRequest, MarkSMMResponse>(_service.MarkSMM, MarkSMMRequest);

    //            //logger.Info("Ok2");
    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    /// <summary>
    //    /// verilen faturanın okunMAmış olarak işaretlenmesi
    //    /// </summary>
    //    /// <param name="title"></param>
    //    public void Test_MarkSmm_asUnread(string smmNo)
    //    {
    //        try
    //        {
    //            logger.Info("UNMARK Invoice test...");

    //            MarkSMMRequest MarkSMMRequest = new MarkSMMRequest()
    //            {
    //                REQUEST_HEADER = _requestHeader,
    //                MARK = new MarkSMMRequestMARK()
    //                {
    //                    valueSpecified = true,
    //                    value = MarkSMMRequestMARKValue.UNREAD,
    //                    SMM = new SMM[]
    //                                {
    //                                    new SMM()
    //                                    {
    //                                        ID = smmNo,
    //                                    }
    //                                },
    //                }
    //            };

    //            //MarkSMMResponse getInvoiceStatusResponse = _service.MarkSMM(MarkSMMRequest);
    //            MarkSMMResponse getInvoiceStatusResponse = Measure<MarkSMMRequest, MarkSMMResponse>(_service.MarkSMM, MarkSMMRequest);

    //            logger.Info("Ok");
    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }

    //    #endregion


    //    #region SMM e-Arşiv fatura iptal

    //    public void Test_CancelEarchieveSMM(string smmNo)
    //    {
    //        try
    //        {
    //            logger.Info(@"Test_CancelSMMEArchive test...");

    //            CancelSMMRequest cancelSMMRequest = new CancelSMMRequest()
    //            {
    //                REQUEST_HEADER = _requestHeader,
    //                SMM = new SMM[]
    //                                {
    //                                    new SMM()
    //                                    {
    //                                        ID = smmNo,
    //                                    }
    //                                },
    //            };

    //            //CancelInvoiceResponse getInvoiceStatusResponse = _service.CancelInvoice(cancelInvoiceRequest);
    //            CancelSMMResponse getInvoiceStatusResponse = Measure<CancelSMMRequest, CancelSMMResponse>(_service.CancelSMM, cancelSMMRequest);

    //            logger.Info("Ok");
    //        }
    //        catch (System.ServiceModel.FaultException<REQUEST_ERRORType> fexp)
    //        {
    //            string detail = xmlSerializeObject((((System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp)).Detail);
    //            var requesterror = (System.ServiceModel.FaultException<REQUEST_ERRORType>)fexp;

    //            logger.Error("FaultException with RequestFault catched:");
    //            logger.Error("requestError XML:" + detail);
    //            //logger.Error("requestError CLIENT_TXN_ID:" + requesterror.Detail.CLIENT_TXN_ID);
    //            //logger.Error("requestError ERROR_CODE:" + requesterror.Detail.ERROR_CODE);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEX:" + requesterror.Detail.ERROR_ELEMENT_INDEX);
    //            //logger.Error("requestError ERROR_ELEMENT_INDEXSpecified:" + requesterror.Detail.ERROR_ELEMENT_INDEXSpecified);
    //            //logger.Error("requestError ERROR_LONG_DES:" + requesterror.Detail.ERROR_LONG_DES);
    //            //logger.Error("requestError ERROR_SHORT_DES:" + requesterror.Detail.ERROR_SHORT_DES);
    //            //logger.Error("requestError INTL_TXN_ID:" + requesterror.Detail.INTL_TXN_ID);
    //            //logger.Error("requestError STACKTRACE:" + requesterror.Detail.STACKTRACE);
    //        }
    //        catch (System.ServiceModel.FaultException fex)
    //        {
    //            logger.Error("FaultException catched:");
    //            logger.Error("FaultException fault code:" + fex.Code);
    //            logger.Error("FaultException fault details:" + fex.Data);
    //            logger.Error("FaultException fault message:" + fex.Message);
    //            logger.Error("FaultException fault reason:" + fex.Reason);
    //            logger.Error("FaultException :" + fex.ToString());
    //        }
    //        catch (Exception ex)
    //        {
    //            logger.Error("Exception catched:");
    //            logger.Error("Exception data:" + ex.Data);
    //            logger.Error("Exception message:" + ex.ToString());
    //        }
    //    }


    //    #endregion


    //    #region helpers

    //    private string xmlSerializeObject(object Object)
    //    {

    //        XmlSerializer serializer = new XmlSerializer(typeof(REQUEST_ERRORType));
    //        StringWriter SW = new StringWriter();
    //        serializer.Serialize(SW, Object);
    //        return SW.ToString();
    //    }

    //    //protected List<hm.common.Ubltr.Invoice21.InvoiceType> CreateInvoiceTypeTestObject(string serial, int startinvoiceserial, int count)
    //    //{
    //    //    List<hm.common.Ubltr.Invoice21.InvoiceType> ublinvoicelist = new List<hm.common.Ubltr.Invoice21.InvoiceType>();


    //    //    for (int i = startinvoiceserial; i <= (startinvoiceserial + count); i++)
    //    //    {

    //    //        // create and return invoice of type InvoiceType
    //    //        hm.common.Ubltr.Invoice21.InvoiceType ublinvoice = new hm.common.Ubltr.Invoice21.InvoiceType();

    //    //        #region Header
    //    //        ublinvoice.UBLExtensions = new hm.common.Ubltr.Invoice21.UBLExtensionType[]
    //    //    {
    //    //        new hm.common.Ubltr.Invoice21.UBLExtensionType()
    //    //        {
    //    //            ExtensionContent = new hm.common.Ubltr.Invoice21.ExtensionContentType()
    //    //            {
    //    //            }
    //    //        }
    //    //    };

    //    //        ublinvoice.UBLVersionID = new hm.common.Ubltr.Invoice21.UBLVersionIDType()
    //    //        {
    //    //            Value = "2.1"
    //    //        };

    //    //        ublinvoice.CustomizationID = new hm.common.Ubltr.Invoice21.CustomizationIDType()
    //    //        {
    //    //            Value = "TR1.2"
    //    //        };

    //    //        ublinvoice.ProfileID = new hm.common.Ubltr.Invoice21.ProfileIDType()
    //    //        {
    //    //            Value = "TICARIFATURA"
    //    //        };

    //    //        ublinvoice.ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //        {
    //    //            Value = string.Format("{0}{1}{2}", serial, DateTime.Now.Year, i.ToString().PadLeft(9, '0'))
    //    //        };

    //    //        ublinvoice.CopyIndicator = new hm.common.Ubltr.Invoice21.CopyIndicatorType()
    //    //        {
    //    //            Value = false
    //    //        };

    //    //        ublinvoice.UUID = new hm.common.Ubltr.Invoice21.UUIDType()
    //    //        {
    //    //            Value = Guid.NewGuid().ToString()
    //    //        };

    //    //        ublinvoice.IssueDate = new hm.common.Ubltr.Invoice21.IssueDateType()
    //    //        {
    //    //            Value = DateTime.Now
    //    //        };

    //    //        ublinvoice.InvoiceTypeCode = new hm.common.Ubltr.Invoice21.InvoiceTypeCodeType()
    //    //        {
    //    //            Value = "SATIS"
    //    //        };


    //    //        List<hm.common.Ubltr.Invoice21.NoteType> notes = new List<hm.common.Ubltr.Invoice21.NoteType>();
    //    //        notes.Add(new hm.common.Ubltr.Invoice21.NoteType()
    //    //        {
    //    //            Value = "Ticaret Sicil No.:888376, İşletme Merkezi: ISTANBUL"
    //    //        });

    //    //        ublinvoice.Note = notes.ToArray();

    //    //        ublinvoice.DocumentCurrencyCode = new hm.common.Ubltr.Invoice21.DocumentCurrencyCodeType()
    //    //        {
    //    //            Value = "TRY"
    //    //        };

    //    //        #endregion

    //    //        #region Signature

    //    //        ublinvoice.Signature = new hm.common.Ubltr.Invoice21.SignatureType1[]
    //    //    {
    //    //        new hm.common.Ubltr.Invoice21.SignatureType1()
    //    //        {
    //    //            ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //            {
    //    //                schemeID = "VKN_TCKN",
    //    //                Value = "3230512384"
    //    //            },
    //    //            SignatoryParty = new hm.common.Ubltr.Invoice21.PartyType()
    //    //            {
    //    //                PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
    //    //                {
    //    //                    new hm.common.Ubltr.Invoice21.PartyIdentificationType()
    //    //                    {
    //    //                        ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //                        {
    //    //                            schemeID = "VKN",
    //    //                            Value = "3230512384"
    //    //                        }
    //    //                    }
    //    //                },
    //    //                PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
    //    //                {
    //    //                    Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                    {
    //    //                        Value = null
    //    //                    },
    //    //                },
    //    //                PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
    //    //                {
    //    //                    TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
    //    //                    {
    //    //                        Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                        {
    //    //                            Value = null
    //    //                        }
    //    //                    }
    //    //                },
    //    //                PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
    //    //                {
    //    //                    StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
    //    //                    {
    //    //                        Value = "Cansızoğlu işhanı No:7/35 Mecidiyeköy"
    //    //                    },
    //    //                    CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
    //    //                    {
    //    //                        Value    = "Şişli"
    //    //                    },
    //    //                    CityName = new hm.common.Ubltr.Invoice21.CityNameType()
    //    //                    {
    //    //                        Value = "İstanbul"
    //    //                    },
    //    //                    Country = new hm.common.Ubltr.Invoice21.CountryType()
    //    //                    {
    //    //                        IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
    //    //                        {
    //    //                            Value = "TR"
    //    //                        },
    //    //                        Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                        {
    //    //                            Value  = "Türkiye"
    //    //                        }
    //    //                    }
    //    //                }
    //    //            },
    //    //            DigitalSignatureAttachment = new hm.common.Ubltr.Invoice21.AttachmentType()
    //    //            {
    //    //                ExternalReference = new hm.common.Ubltr.Invoice21.ExternalReferenceType()
    //    //                {
    //    //                    URI = new hm.common.Ubltr.Invoice21.URIType()
    //    //                    {
    //    //                        Value =  "#Signature_" + ublinvoice.ID.Value 
    //    //                    }
    //    //                }
    //    //            }
    //    //        }
    //    //    };

    //    //        #endregion

    //    //        #region Default Fatura Dizaynı (xslt)

    //    //        ublinvoice.AdditionalDocumentReference = new hm.common.Ubltr.Invoice21.DocumentReferenceType[]
    //    //    {
    //    //        new hm.common.Ubltr.Invoice21.DocumentReferenceType()
    //    //        {
    //    //            ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //            {
    //    //                Value = Guid.NewGuid().ToString()
    //    //            },
    //    //            IssueDate = new hm.common.Ubltr.Invoice21.IssueDateType()
    //    //            {
    //    //                Value = DateTime.Now
    //    //            },
    //    //            Attachment = new hm.common.Ubltr.Invoice21.AttachmentType()
    //    //            {
    //    //                EmbeddedDocumentBinaryObject  = new hm.common.Ubltr.Invoice21.EmbeddedDocumentBinaryObjectType()
    //    //                {
    //    //                    filename = ublinvoice.ID.Value + ".xslt",
    //    //                    characterSetCode ="UTF-8" ,
    //    //                    encodingCode="Base64",
    //    //                    mimeCode="application/xml",
    //    //                    Value = File.ReadAllBytes("default.xslt")
    //    //                }
    //    //            }
    //    //        }

    //    //    };


    //    //        #endregion

    //    //        #region Gönderen Bilgileri

    //    //        ublinvoice.AccountingSupplierParty = new hm.common.Ubltr.Invoice21.SupplierPartyType()
    //    //        {
    //    //            Party = new hm.common.Ubltr.Invoice21.PartyType()
    //    //            {
    //    //                PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
    //    //            {
    //    //                new hm.common.Ubltr.Invoice21.PartyIdentificationType()
    //    //                {
    //    //                    ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //                    {
    //    //                        schemeID = "VKN",
    //    //                        Value = "3230512384"
    //    //                    }
    //    //                },
    //    //                new hm.common.Ubltr.Invoice21.PartyIdentificationType()
    //    //                {
    //    //                    ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //                    {
    //    //                        schemeID = "MERSISNO",
    //    //                        Value = "0000000000000000"
    //    //                    }
    //    //                },
    //    //                new hm.common.Ubltr.Invoice21.PartyIdentificationType()
    //    //                {
    //    //                    ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //                    {
    //    //                        schemeID = "TICARETSICILNO",
    //    //                        Value = "12345678"
    //    //                    }
    //    //                }
    //    //            },
    //    //                PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
    //    //                {
    //    //                    Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                    {
    //    //                        Value = "EDM Bilişim Sistemleri ve Danışmanlık Hizmetleri A.Ş."
    //    //                    }
    //    //                },
    //    //                PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
    //    //                {
    //    //                    StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
    //    //                    {
    //    //                        Value = "Cansızoğlu işhanı No:7/35 Mecidiyeköy"
    //    //                    },
    //    //                    CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
    //    //                    {
    //    //                        Value = "Şişli"
    //    //                    },
    //    //                    CityName = new hm.common.Ubltr.Invoice21.CityNameType()
    //    //                    {
    //    //                        Value = "İstanbul"
    //    //                    },
    //    //                    Country = new hm.common.Ubltr.Invoice21.CountryType()
    //    //                    {
    //    //                        IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
    //    //                        {
    //    //                            Value = "TR"
    //    //                        },
    //    //                        Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                        {
    //    //                            Value = "Türkiye"
    //    //                        }
    //    //                    }
    //    //                },
    //    //                PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
    //    //                {
    //    //                    TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
    //    //                    {
    //    //                        Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                        {
    //    //                            Value = "Büyük Mükellefler"
    //    //                        }
    //    //                    }
    //    //                },
    //    //                WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
    //    //                {
    //    //                    Value = "www.edmbilisim.com.tr"
    //    //                },
    //    //                Contact = new hm.common.Ubltr.Invoice21.ContactType()
    //    //                {
    //    //                    Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
    //    //                    {
    //    //                        Value = "+90 111 222 3344"
    //    //                    }
    //    //                }
    //    //            }
    //    //        };

    //    //        #endregion

    //    //        #region Alıcı Bilgileri

    //    //        ublinvoice.AccountingCustomerParty = new hm.common.Ubltr.Invoice21.CustomerPartyType()
    //    //        {
    //    //            Party = new hm.common.Ubltr.Invoice21.PartyType()
    //    //            {
    //    //                PartyIdentification = new hm.common.Ubltr.Invoice21.PartyIdentificationType[]
    //    //            {
    //    //                new hm.common.Ubltr.Invoice21.PartyIdentificationType()
    //    //                {
    //    //                    ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //                    {
    //    //                        schemeID = "VKN",
    //    //                        Value = "3230512384"
    //    //                    }
    //    //                },
    //    //                new hm.common.Ubltr.Invoice21.PartyIdentificationType()
    //    //                {
    //    //                    ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //                    {
    //    //                        schemeID = "MERSISNO",
    //    //                        Value = "0000000000000000"
    //    //                    }
    //    //                },
    //    //                new hm.common.Ubltr.Invoice21.PartyIdentificationType()
    //    //                {
    //    //                    ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //                    {
    //    //                        schemeID = "TICARETSICILNO",
    //    //                        Value = "12345678"
    //    //                    }
    //    //                }
    //    //            },
    //    //                PartyName = new hm.common.Ubltr.Invoice21.PartyNameType()
    //    //                {
    //    //                    Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                    {
    //    //                        Value = "EDM Bilişim Sistemleri ve Danışmanlık Hizmetleri A.Ş."
    //    //                    }
    //    //                },
    //    //                PostalAddress = new hm.common.Ubltr.Invoice21.AddressType()
    //    //                {
    //    //                    StreetName = new hm.common.Ubltr.Invoice21.StreetNameType()
    //    //                    {
    //    //                        Value = "Cansızoğlu işhanı No:7/35 Mecidiyeköy"
    //    //                    },
    //    //                    CitySubdivisionName = new hm.common.Ubltr.Invoice21.CitySubdivisionNameType()
    //    //                    {
    //    //                        Value = "Şişli"
    //    //                    },
    //    //                    CityName = new hm.common.Ubltr.Invoice21.CityNameType()
    //    //                    {
    //    //                        Value = "İstanbul"
    //    //                    },
    //    //                    Country = new hm.common.Ubltr.Invoice21.CountryType()
    //    //                    {
    //    //                        IdentificationCode = new hm.common.Ubltr.Invoice21.IdentificationCodeType()
    //    //                        {
    //    //                            Value = "TR"
    //    //                        },
    //    //                        Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                        {
    //    //                            Value = "Türkiye"
    //    //                        }
    //    //                    }
    //    //                },
    //    //                PartyTaxScheme = new hm.common.Ubltr.Invoice21.PartyTaxSchemeType()
    //    //                {
    //    //                    TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
    //    //                    {
    //    //                        Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                        {
    //    //                            Value = "Büyük Mükellefler"
    //    //                        }
    //    //                    }
    //    //                },
    //    //                WebsiteURI = new hm.common.Ubltr.Invoice21.WebsiteURIType()
    //    //                {
    //    //                    Value = "www.edmbilisim.com.tr"
    //    //                },
    //    //                Contact = new hm.common.Ubltr.Invoice21.ContactType()
    //    //                {
    //    //                    Telephone = new hm.common.Ubltr.Invoice21.TelephoneType()
    //    //                    {
    //    //                        Value = "+90 111 222 3344"
    //    //                    }
    //    //                }
    //    //            }
    //    //        };

    //    //        #endregion

    //    //        #region Total Taxes

    //    //        ublinvoice.TaxTotal = new hm.common.Ubltr.Invoice21.TaxTotalType[]
    //    //    {
    //    //        new hm.common.Ubltr.Invoice21.TaxTotalType()
    //    //        {
    //    //            TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
    //    //            {
    //    //                currencyID = "TRY",
    //    //                Value = 3600
    //    //            },
    //    //            TaxSubtotal = new hm.common.Ubltr.Invoice21.TaxSubtotalType[]
    //    //            {
    //    //                new hm.common.Ubltr.Invoice21.TaxSubtotalType()
    //    //                {
    //    //                    TaxableAmount = new hm.common.Ubltr.Invoice21.TaxableAmountType()
    //    //                    {
    //    //                        currencyID = "TRY",
    //    //                        Value = 20000
    //    //                    },
    //    //                    TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
    //    //                    {
    //    //                        currencyID = "TRY",
    //    //                        Value = 3600
    //    //                    },
    //    //                    CalculationSequenceNumeric = new hm.common.Ubltr.Invoice21.CalculationSequenceNumericType()
    //    //                    {
    //    //                        Value = 1
    //    //                    },
    //    //                    Percent = new hm.common.Ubltr.Invoice21.PercentType1()
    //    //                    {
    //    //                        Value = 18
    //    //                    },
    //    //                    TaxCategory = new hm.common.Ubltr.Invoice21.TaxCategoryType()
    //    //                    {
    //    //                        TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
    //    //                        {
    //    //                            Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                            {
    //    //                                Value = "KDV GERCEK"
    //    //                            },
    //    //                            TaxTypeCode = new hm.common.Ubltr.Invoice21.TaxTypeCodeType()
    //    //                            {
    //    //                                Value = "0015"
    //    //                            }
    //    //                        }
    //    //                    }
    //    //                }
    //    //            }
    //    //        }
    //    //    };


    //    //        #endregion

    //    //        #region Invoice.LegalMonetaryTotal

    //    //        ublinvoice.LegalMonetaryTotal = new hm.common.Ubltr.Invoice21.MonetaryTotalType()
    //    //        {
    //    //            LineExtensionAmount = new hm.common.Ubltr.Invoice21.LineExtensionAmountType()
    //    //            {
    //    //                currencyID = "TRY",
    //    //                Value = 20000
    //    //            },
    //    //            TaxExclusiveAmount = new hm.common.Ubltr.Invoice21.TaxExclusiveAmountType()
    //    //            {
    //    //                currencyID = "TRY",
    //    //                Value = 20000
    //    //            },
    //    //            TaxInclusiveAmount = new hm.common.Ubltr.Invoice21.TaxInclusiveAmountType()
    //    //            {
    //    //                currencyID = "TRY",
    //    //                Value = 23600
    //    //            },
    //    //            AllowanceTotalAmount = new hm.common.Ubltr.Invoice21.AllowanceTotalAmountType()
    //    //            {
    //    //                currencyID = "TRY",
    //    //                Value = 0
    //    //            },
    //    //            PayableAmount = new hm.common.Ubltr.Invoice21.PayableAmountType()
    //    //            {
    //    //                currencyID = "TRY",
    //    //                Value = 23600
    //    //            },
    //    //        };

    //    //        #endregion

    //    //        #region invoice lines


    //    //        List<hm.common.Ubltr.Invoice21.InvoiceLineType> invoiceLines
    //    //            = new List<hm.common.Ubltr.Invoice21.InvoiceLineType>();

    //    //        hm.common.Ubltr.Invoice21.InvoiceLineType invoiceLine
    //    //            = new hm.common.Ubltr.Invoice21.InvoiceLineType()
    //    //            {
    //    //                ID = new hm.common.Ubltr.Invoice21.IDType()
    //    //                {
    //    //                    Value = "1"
    //    //                },
    //    //                InvoicedQuantity = new hm.common.Ubltr.Invoice21.InvoicedQuantityType()
    //    //                {
    //    //                    unitCode = "NIU",
    //    //                    Value = 1
    //    //                },
    //    //                LineExtensionAmount = new hm.common.Ubltr.Invoice21.LineExtensionAmountType()
    //    //                {
    //    //                    currencyID = "TRY",
    //    //                    Value = 20000
    //    //                },
    //    //                TaxTotal = new hm.common.Ubltr.Invoice21.TaxTotalType()
    //    //                {
    //    //                    TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
    //    //                    {
    //    //                        currencyID = "TRY",
    //    //                        Value = 3600
    //    //                    },
    //    //                    TaxSubtotal = new hm.common.Ubltr.Invoice21.TaxSubtotalType[]
    //    //                {
    //    //                    new hm.common.Ubltr.Invoice21.TaxSubtotalType()
    //    //                    {
    //    //                        TaxableAmount = new hm.common.Ubltr.Invoice21.TaxableAmountType()
    //    //                        {
    //    //                            currencyID = "TRY",
    //    //                            Value = 20000
    //    //                        },
    //    //                        TaxAmount = new hm.common.Ubltr.Invoice21.TaxAmountType()
    //    //                        {
    //    //                            currencyID = "TRY",
    //    //                            Value = 3600
    //    //                        },
    //    //                        CalculationSequenceNumeric = new hm.common.Ubltr.Invoice21.CalculationSequenceNumericType()
    //    //                        {
    //    //                            Value = 1
    //    //                        },
    //    //                        Percent = new hm.common.Ubltr.Invoice21.PercentType1()
    //    //                        {
    //    //                            Value = 18
    //    //                        },
    //    //                        TaxCategory = new hm.common.Ubltr.Invoice21.TaxCategoryType()
    //    //                        {
    //    //                            TaxScheme = new hm.common.Ubltr.Invoice21.TaxSchemeType()
    //    //                            {
    //    //                                Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                                {
    //    //                                    Value = "KDV GERCEK"
    //    //                                },
    //    //                                TaxTypeCode = new hm.common.Ubltr.Invoice21.TaxTypeCodeType()
    //    //                                {
    //    //                                    Value = "0015"
    //    //                                }
    //    //                            }
    //    //                        }
    //    //                    }
    //    //                }
    //    //                },
    //    //                Item = new hm.common.Ubltr.Invoice21.ItemType()
    //    //                {
    //    //                    Name = new hm.common.Ubltr.Invoice21.NameType1()
    //    //                    {
    //    //                        Value = "Ürün Bedeli"
    //    //                    }
    //    //                },
    //    //                Price = new hm.common.Ubltr.Invoice21.PriceType()
    //    //                {
    //    //                    PriceAmount = new hm.common.Ubltr.Invoice21.PriceAmountType()
    //    //                    {
    //    //                        currencyID = "TRY",
    //    //                        Value = 20000
    //    //                    }
    //    //                }
    //    //            };

    //    //        invoiceLines.Add(invoiceLine);


    //    //        ublinvoice.InvoiceLine = invoiceLines.ToArray();

    //    //        ublinvoice.LineCountNumeric = new hm.common.Ubltr.Invoice21.LineCountNumericType()
    //    //        {
    //    //            Value = invoiceLines.Count
    //    //        };

    //    //        #endregion

    //    //        ublinvoicelist.Add(ublinvoice);
    //    //    }

    //    //    return ublinvoicelist;
    //    //}

    //    #region duration measurement

    //    public static long Measure(Action<string, int> action, string s, int c)
    //    {
    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        action(s, c);
    //        sw.Stop();

    //        Console.WriteLine(" * Measure(" + action.Method.Name + "):" + sw.ElapsedMilliseconds + " msec\n");
    //        return sw.ElapsedMilliseconds;
    //    }

    //    public static TO Measure<TI, TO>(Func<TI, TO> action, TI o)
    //    {
    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        var output = (TO)action(o);
    //        sw.Stop();

    //        Console.WriteLine(" * Measure (" + action.Method.Name + "):" + sw.ElapsedMilliseconds + " msec\n");
    //        return output;
    //    }

    //    public static long Measure(Action action)
    //    {
    //        Stopwatch sw = new Stopwatch();
    //        sw.Start();
    //        action();
    //        sw.Stop();

    //        Console.WriteLine(" * Measure(" + action.Method.Name + "):" + sw.ElapsedMilliseconds + " msec\n");
    //        return sw.ElapsedMilliseconds;
    //    }

    //    #endregion

    //    #endregion

    //}
}