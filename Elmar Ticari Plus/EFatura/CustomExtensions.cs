using System;
using System.IO;
using System.Globalization;
using System.Configuration;
using System.Xml;
using System.Web;
using System.Linq;

using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using System.Reflection;


namespace Elmar_Ticari_Plus
{
    public static class CustomExtensions
    {
        // This is the extension method. 
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.

        public static string ReplaceWCI(this String str, string searchfor, string replacewith)  // wholeword case-insentitive
        {
            string pattern = string.Format(@"\b{0}\b", searchfor);
            string replaced = Regex.Replace(str, pattern, replacewith, RegexOptions.IgnoreCase);
            return replaced;
        }

        public static string ReplaceWCS(this String str, string searchfor, string replacewith)  // wholeword case-sentitive
        {
            string pattern = string.Format(@"\b{0}\b", searchfor);
            string replaced = Regex.Replace(str, pattern, replacewith, RegexOptions.None);
            return replaced;
        }

        public static int WordCount(this String str)
        {
            if (str == null) return 0;
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string HtmlEncoded(this String str)
        {
            if (str == null) return null;
            return HttpUtility.HtmlEncode(str);
        }

        public static string HtmlDecoded(this String str)
        {
            if (str == null) return null;
            return HttpUtility.HtmlDecode(str);
        }

        public static string UrlEncoded(this String str)
        {
            if (str == null) return null;
            return HttpUtility.UrlEncode(str);
        }

        public static string UrlDecoded(this String str)
        {
            if (str == null) return null;
            return HttpUtility.UrlDecode(str);
        }

        public static string ToHtmlLineBreak(this String str)
        {
            if (str == null) return null;
            return str.Replace("\r", "<br />").Replace("", "<br />").Replace("\r", "<br />");
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }


        // create stream from string
        public static Stream ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static String ToStringTR(this Double num)
        {
            string retval = "";

            try
            {
                retval = num.ToString(CultureInfo.CreateSpecificCulture("tr-TR"));
            }
            catch
            {
                retval = num.ToString();
            }

            return retval;
        }

        public static String ToStringEN(this Double num)
        {
            string retval = "";

            try
            {
                retval = num.ToString(CultureInfo.CreateSpecificCulture("en-EN"));
            }
            catch
            {
                retval = num.ToString();
            }

            return retval;
        }

        public static String ToStringUBLAmount(this double? num, byte digit = 2)
        {
            string retval = "";

            if (num != null)
            {
                try
                {
                    string pattern = string.Format("#0.{0}", new String('0', digit));
                    retval = ((double)num).ToString(pattern, CultureInfo.CreateSpecificCulture("en-EN"));
                }
                catch
                {
                    retval = num.ToString();
                }
            }
            return retval;
        }

        public static String ToStringUBLAmount(this double num, byte digit = 2)
        {
            string retval = "";

            try
            {
                string pattern = string.Format("#0.{0}", new String('0', digit));
                retval = ((double)num).ToString(pattern, CultureInfo.CreateSpecificCulture("en-EN"));
            }
            catch
            {
                retval = num.ToString();
            }

            return retval;
        }

        public static String ToStringUBLAmount(this float? num, byte digit = 2)
        {
            string retval = "";

            if (num != null)
            {
                try
                {
                    string pattern = string.Format("#0.{0}", new String('0', digit));
                    retval = ((double)num).ToString(pattern, CultureInfo.CreateSpecificCulture("en-EN"));
                }
                catch
                {
                    retval = num.ToString();
                }
            }
            return retval;
        }

        public static String ToStringUBLAmount(this float num, byte digit = 2)
        {
            string retval = "";

            try
            {
                string pattern = string.Format("#0.{0}", new String('0', digit));
                retval = ((double)num).ToString(pattern, CultureInfo.CreateSpecificCulture("en-EN"));
            }
            catch
            {
                retval = num.ToString();
            }

            return retval;
        }

        public static int ToNumber(this String str, CultureInfo culture = null)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            int myNum = 0;
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowThousands;

            if (culture == null)
            {
                string decimalsetting = ConfigurationManager.AppSettings["decimal"];
                if (decimalsetting == null)
                {
                    decimalsetting = CultureInfo.CurrentCulture.Name;
                }
                culture = CultureInfo.CreateSpecificCulture(decimalsetting); // "1,097.63" gibi..
            }

            if (int.TryParse(str, style, culture, out myNum))
            {
                return myNum;
            }
            else
            {
                return (0);
                // it is not a number
            }
        }

        // formatlı string tutar içeriklerini float'a donusturur
        public static float ToFloat(this String str)
        {
            if (str == null) return 0;
            float floatvalue = 0;
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint |
                                 NumberStyles.AllowThousands;
            string decimalsetting = ConfigurationManager.AppSettings["decimal"];
            if (decimalsetting == null)
            {
                decimalsetting = CultureInfo.CurrentCulture.Name;
            }
            CultureInfo culture = CultureInfo.CreateSpecificCulture(decimalsetting); // "1,097.63" gibi..
            float.TryParse(str, style, culture, out floatvalue);
            return floatvalue;
        }

        public static double ToDouble(this String str, CultureInfo culture = null)
        {
            double myNum = 0;
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowDecimalPoint | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;

            if (culture == null)
            {
                string decimalsetting = ConfigurationManager.AppSettings["decimal"];
                if (decimalsetting == null)
                {
                    decimalsetting = CultureInfo.CurrentCulture.Name;
                }
                if (culture == null)
                {
                    culture = CultureInfo.CreateSpecificCulture(decimalsetting); // "1,097.63" gibi..
                }
            }

            if (double.TryParse(str, style, culture, out myNum))
            {
                return (myNum);
            }
            else
            {
                return (0);
                // it is not a number
            }
        }

        /// <summary>
        /// ByteArray'den MemoryStream oluşturarak,  XmlDocument nesnesi oluşturmak için kullanılan metod.
        /// </summary>
        /// <param name="xmldoc">extension type</param>
        /// <param name="bytes">Xml dokumani olusturulacak byte array</param>
        /// <returns>Xml dosyasından oluşturulan XmlDocument nesnesi.</returns>
        public static XmlDocument LoadBytearray(this XmlDocument xmldoc, byte[] bytes)
        {
            try
            {
                xmldoc.PreserveWhitespace = true;

                MemoryStream ms = new MemoryStream(bytes);
                XmlReader reader = XmlReader.Create(ms);

                xmldoc.Load(reader);

                ms.Close();
                ms.Dispose();
                ms = null;

                return xmldoc;
            }
            catch (Exception e)
            {
                // we shouldn't be here if ENVELOPE_XML is valid
                throw new Exception("XmlDocument nesnesi yaratılamadı: " + e.Message);
            }

        }

        /// <summary>
        /// XmlDocument xml içeriğinin byte array olarak veren metod.
        /// </summary>
        /// <param name="xmldoc">extension type</param>
        /// <returns>Xml dosyasından oluşturulan byte array.</returns>
        public static byte[] GetByteArray(this XmlDocument xmldoc)
        {
            try
            {
                byte[] xmlbytes = null;
                xmlbytes = System.Text.Encoding.UTF8.GetBytes(xmldoc.OuterXml);

                return xmlbytes;
            }
            catch (Exception e)
            {
                // we shouldn't be here if ENVELOPE_XML is valid
                throw new Exception("XmlDocument nesnesi okunamadı: " + e.Message);
            }

        }

        /// <summary>
        /// Bir object nesnesindeki tüm properylerin json çıktısını string olarak verir.
        /// </summary>
        /// <param name="xmldoc">extension type</param>
        /// <param name="bytes">Xml dokumani olusturulacak byte array</param>
        /// <returns>Xml dosyasından oluşturulan XmlDocument nesnesi.</returns>
        private class MyContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        {
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                var props = (type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                                .Select(p => base.CreateProperty(p, memberSerialization))
                            .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                       .Select(f => base.CreateProperty(f, memberSerialization)))
                            .ToList();
                props.ForEach(p => { p.Writable = true; p.Readable = true; });
                return props;
            }
        }

        public static string ToJSONString(this Object o)
        {
            if (o == null) return "";

            try
            {
                string jsonstring = JsonConvert.SerializeObject(o, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    Culture = CultureInfo.InvariantCulture
                });

                //var settings = new JsonSerializerSettings() { ContractResolver = new MyContractResolver() };
                //string jsonstring = JsonConvert.SerializeObject(o, settings);

                return jsonstring;
            }
            catch (Exception ex)
            {
                return " cannot get JSON string:" + ex.Message;
            }
        }

        /// <summary>
        /// Verilen string içerikten Türkçe karakterleri atıp yerine inglizce hafleri koyar.
        /// </summary>
        /// <param name="string">Türkçe karakterli içerik</param>
        /// <returns>Turkce karakteri olmayan içerik</returns>
        public static string ToUpperNOTurkish(this String ne)
        {
            if (ne == null)
            {
                return null;
            }

            string sonuc = "";

            for (int i = 0; i < ne.Length; i++)
            {
                sonuc += strEngH(ne.Substring(i, 1));
            }
            return sonuc;
        }
        public static string isoToTurkish(this String ne)
        {
            if (ne == null)
            {
                return null;
            }
            string sonuc = ne.Replace("Ä±", "ı").Replace("Ã¶", "ö").Replace("ÄŸ", "ğ").Replace("Ã§", "ç").Replace("Ã¼", "ü").Replace("ÅŸ", "ş");
            sonuc = sonuc.Replace("Ä°", "İ");
            return sonuc;
        }

        private static string strEngH(string ne)
        {
            if (ne == "İ") return "I";
            if (ne == "I") return "I";
            if (ne == "Ş") return "S";
            if (ne == "Ğ") return "G";
            if (ne == "Ü") return "U";
            if (ne == "Ö") return "O";
            if (ne == "Ç") return "C";
            if (ne == "ı") return "I";
            if (ne == "i") return "I";
            if (ne == "ş") return "S";
            if (ne == "ğ") return "G";
            if (ne == "ü") return "U";
            if (ne == "ö") return "O";
            if (ne == "ç") return "C";
            return ne.ToUpper();
        }

        /// <summary>
        /// Verilen string içerikten Türkçe karakterleri atıp yerine inglizce hafleri koyar.
        /// </summary>
        /// <param name="string">Türkçe karakterli içerik</param>
        /// <returns>Turkce karakteri olmayan içerik</returns>
        public static string ToLowerNOTurkish(this String ne)
        {
            if (ne == null)
            {
                return null;
            }

            string sonuc = "";

            for (int i = 0; i < ne.Length; i++)
            {
                sonuc += strEngL(ne.Substring(i, 1));
            }
            return sonuc;
        }

        private static string strEngL(string ne)
        {
            if (ne == "I") return "i";
            if (ne == "İ") return "i";
            if (ne == "Ş") return "s";
            if (ne == "Ğ") return "g";
            if (ne == "Ü") return "u";
            if (ne == "Ö") return "o";
            if (ne == "Ç") return "c";
            if (ne == "ı") return "i";
            if (ne == "i") return "i";
            if (ne == "ş") return "s";
            if (ne == "ğ") return "g";
            if (ne == "ü") return "u";
            if (ne == "ö") return "o";
            if (ne == "ç") return "c";
            return ne.ToLower();
        }

        public static XmlElement ToXmlElement(this string ne)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadBytearray(System.Text.Encoding.UTF8.GetBytes(ne));
            return doc.DocumentElement;
        }




        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }

    }
}
