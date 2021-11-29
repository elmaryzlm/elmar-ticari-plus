using elmarLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public class Selahattin
    {
        public Selahattin(String userName, String password, String org)
        {
            start += "<smspack ka=\"" + xmlEncode(userName) + "\" pwd=\"" + xmlEncode(password)
                    + "\" org=\"" + xmlEncode(org) + "\">";

        }

        public Selahattin(String userName, String password, String org, DateTime date)
        {
            start += "<smspack ka=\"" + xmlEncode(userName) + "\" pwd=\"" + xmlEncode(password) +
                    "\" org=\"" + xmlEncode(org) + "\" tarih=\"" + tarihStr(date) + "\">";

        }

        public void addSMS(String message, String[] phones)
        {
            body += "<mesaj><metin>";
            body += xmlEncode(message);
            body += "</metin><nums>";
            foreach (String s in phones)
            {
                body += xmlEncode(s) + ",";
            }
            body += "</nums></mesaj>";
        }

        public String xml()
        {
            if (body.Length == 0)
                throw new ArgumentException("SMS paketinede sms yok!");
            return start + body + end;
        }

        public String gonder()
        {
            WebClient wc = new WebClient();

            string postData = xml();
            wc.Headers.Add("Content-Type", "text/xml; charset=UTF-8");
            // Apply ASCII Encoding to obtain the string as a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            byte[] responseArray = wc.UploadData("https://smsgw.mutlucell.com/smsgw-ws/sndblkex", "POST", byteArray);
            String response = Encoding.UTF8.GetString(responseArray);
            return response;
        }

        /*
         * ka = kullanici adi
         * parola
         * id: gonderim sonucu donen paket ID
         */
        public static String rapor(String ka, String parola, long id)
        {
            String xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    "<smsrapor ka=\"" + ka + "\" pwd=\"" + parola + "\" id=\"" + id + "\" />";
            WebClient wc = new WebClient();
            string postData = xml;
            wc.Headers.Add("Content-Type", "text/xml; charset=UTF-8");
            // Apply ASCII Encoding to obtain the string as a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            byte[] responseArray = wc.UploadData("https://smsgw.mutlucell.com/smsgw-ws/gtblkrprtex", "POST", byteArray);
            String response = Encoding.UTF8.GetString(responseArray);
            return response;
        }


        private static String tarihStr(DateTime d)
        {
            return xmlEncode(d.ToString("yyyy-MM-dd HH:mm"));
        }

        private static String xmlEncode(String s)
        {
            s = s.Replace("&", "&amp;");
            s = s.Replace("<", "&lt;");
            s = s.Replace(">", "&gt;");
            s = s.Replace("'", "&apos;");
            s = s.Replace("\"", "&quot;");
            return s;
        }

        private String start = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        private String end = "</smspack>";
        private String body = "";

        public static Image logoGetir()
        {
            Image imgReturn = null;
            try
            {
                Stream s = File.Open(Application.StartupPath + "\\KullanıcıResimleri\\logo\\logoCikti" + firma.firmaid + ".png", FileMode.Open);
                Image temp = Image.FromStream(s);
                s.Close();
                imgReturn = temp;
            }
            catch
            {
                try
                {
                    Image img = elmarDosyaislemleri.resimindir("logo/logologoCikti" + firma.firmaid + ".png");
                    imgReturn = img;
                }
                catch (Exception hata)
                {
                }
            }
            return imgReturn;
        }


    }

}

