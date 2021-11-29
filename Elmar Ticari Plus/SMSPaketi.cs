using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Elmar_Ticari_Plus
{
    public class SMSPaketi
    {
        //    public SMSPaketi(String userName, String password, String org)
        //    {
        //        start += "<smspack ka=\"" + xmlEncode(userName) + "\" pwd=\"" + xmlEncode(password)
        //                + "\" org=\"" + xmlEncode(org) + "\">";

        //    }

        //    public SMSPaketi(String userName, String password, String org, DateTime date)
        //    {
        //        start += "<smspack ka=\"" + xmlEncode(userName) + "\" pwd=\"" + xmlEncode(password) +
        //                "\" org=\"" + xmlEncode(org) + "\" tarih=\"" + tarihStr(date) + "\">";

        //    }

        //    public void addSMS(String message, String[] phones)
        //    {
        //        body += "<mesaj><metin>";
        //        body += xmlEncode(message);
        //        body += "</metin><nums>";
        //        foreach (String s in phones)
        //        {
        //            body += xmlEncode(s) + ",";
        //        }
        //        body += "</nums></mesaj>";
        //    }

        //    public String xml()
        //    {
        //        if (body.Length == 0)
        //            throw new ArgumentException("SMS paketinede sms yok!");
        //        return start + body + end;
        //    }

        //    public String gonder()
        //    {
        //        WebClient wc = new WebClient();

        //        string postData = xml();
        //        wc.Headers.Add("Content-Type", "text/xml; charset=UTF-8");
        //        // Apply ASCII Encoding to obtain the string as a byte array.
        //        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //        byte[] responseArray = wc.UploadData("https://smsgw.mutlucell.com/smsgw-ws/sndblkex", "POST", byteArray);
        //        String response = Encoding.UTF8.GetString(responseArray);
        //        return response;
        //    }

        //    /*
        //     * ka = kullanici adi
        //     * parola
        //     * id: gonderim sonucu donen paket ID
        //     */
        //    public static String rapor(String ka, String parola, long id)
        //    {
        //        String xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
        //                "<smsrapor ka=\"" + ka + "\" pwd=\"" + parola + "\" id=\"" + id + "\" />";
        //        WebClient wc = new WebClient();
        //        string postData = xml;
        //        wc.Headers.Add("Content-Type", "text/xml; charset=UTF-8");
        //        // Apply ASCII Encoding to obtain the string as a byte array.
        //        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //        byte[] responseArray = wc.UploadData("https://smsgw.mutlucell.com/smsgw-ws/gtblkrprtex", "POST", byteArray);
        //        String response = Encoding.UTF8.GetString(responseArray);
        //        return response;
        //    }


        //    private static String tarihStr(DateTime d)
        //    {
        //        return xmlEncode(d.ToString("yyyy-MM-dd HH:mm"));
        //    }

        //    private static String xmlEncode(String s)
        //    {
        //        s = s.Replace("&", "&amp;");
        //        s = s.Replace("<", "&lt;");
        //        s = s.Replace(">", "&gt;");
        //        s = s.Replace("'", "&apos;");
        //        s = s.Replace("\"", "&quot;");
        //        return s;
        //    }

        //    private String start = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        //    private String end = "</smspack>";
        //    private String body = "";
        //}


           /*********************************************************************************/
        public static string SendSms(string baslik, string message, string phoneNumbers)
        {
            //baslik = "ELMAR YZLM";
            string ss = "";
            ss += "<?xml version='1.0' encoding='UTF-8'?>";
            ss += "<mainbody>";
            ss += "<header>";
            ss += "<company>NETGSM</company>";
            ss += "<usercode>5333954050</usercode>";
            ss += "<password>624688ma</password>";
            ss += "<startdate></startdate>";
            ss += "<stopdate>" + DateTime.Now.ToString("ddMMyyyyHHmm") + "</stopdate>";
            ss += "<type>1:n</type>";
            ss += "<msgheader>" + baslik + "</msgheader>";
            ss += "</header>";
            ss += "<body>";
            ss += "<msg><![CDATA[" + message + "]]></msg>";
            ss += "<no>";
            ss += phoneNumbers;
            ss += "</no>";
            ss += "</body>";
            ss += "</mainbody>";
            return XMLPOST("http://api.netgsm.com.tr/xmlbulkhttppost.asp", ss);
        }

        public static string SendSmsCoklu(string baslik, string message, string phoneNumbers)
        {
            //baslik = "ELMAR YZLM";
            string ss = "";
            ss += "<?xml version='1.0' encoding='UTF-8'?>";
            ss += "<mainbody>";
            ss += "<header>";
            ss += "<company>MUL</company>";
            ss += "<usercode>serviscim</usercode>";
            ss += "<password>serviscim23</password>";
            ss += "<startdate></startdate>";
            ss += "<stopdate>" + DateTime.Now.ToString("ddMMyyyyHHmm") + "</stopdate>";
            ss += "<type>1:n</type>";
            ss += "<msgheader>" + baslik + "</msgheader>";
            ss += "</header>";
            ss += "<body>";
            ss += "<msg><![CDATA[" + message + "]]></msg>"; 
            ss += phoneNumbers; 
            ss += "</body>";
            ss += "</mainbody>";
            return XMLPOST("http://api.netgsm.com.tr/xmlbulkhttppost.asp", ss);
        }

        private static string XMLPOST(string postAddress, string xmlData)
        {
            try
            {
                WebClient wUpload = new WebClient();
                HttpWebRequest request = WebRequest.Create(postAddress) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                Byte[] bPostArray = Encoding.UTF8.GetBytes(xmlData);
                Byte[] bResponse = wUpload.UploadData(postAddress, "POST", bPostArray);
                Char[] sReturnChars = Encoding.UTF8.GetChars(bResponse);
                string sWebPage = new string(sReturnChars);
                return sWebPage;
            }
            catch
            {
                return "-1";
            }
        }
    }
}