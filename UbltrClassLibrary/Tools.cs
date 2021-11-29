using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace hm.common.Ubltr
{
    public class Tools
    {

        public static System.Xml.Serialization.XmlSerializerNamespaces InvoiceNamespaces
        {
            get
            {
                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();

                ns.Add("", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
                ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                ns.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
                //ns.Add("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                //ns.Add("ubltr", "urn:oasis:names:specification:ubl:schema:xsd:TurkishCustomizationExtensionComponents");
                //ns.Add("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                //ns.Add("ccts", "urn:un:unece:uncefact:documentation:2");
                ns.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
                //ns.Add("ns8", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2");

                return ns;
            }
        }

        public static System.Xml.Serialization.XmlSerializerNamespaces ApplicationResponseNamespaces
        {
            get
            {
                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();

                ns.Add("", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2");
                ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                ns.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
                ns.Add("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                ns.Add("ubltr", "urn:oasis:names:specification:ubl:schema:xsd:TurkishCustomizationExtensionComponents");
                ns.Add("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                ns.Add("ccts", "urn:un:unece:uncefact:documentation:2");
                ns.Add("ds", "http://www.w3.org/2000/09/xmldsig#");

                return ns;
            }
        }

        public static System.Xml.Serialization.XmlSerializerNamespaces UserAccountNamespaces
        {
            get
            {
                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();

                ns.Add("", "http://www.hr-xml.org/3");
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                ns.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
                ns.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
                ns.Add("oa", "http://www.openapplications.org/oagis/9");

                return ns;
            }
        }

        public static System.Xml.Serialization.XmlSerializerNamespaces EnvelopeNamespaces
        {
            get
            {
                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();

                ns.Add("", "http://www.hr-xml.org/3");
                ns.Add("sh", "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader");
                ns.Add("ef", "http://www.efatura.gov.tr/package-namespace");
                ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");

                return ns;
            }
        }


        public static string XmlSerialize<T>(T item, XmlSerializerNamespaces ns, Encoding encoding, bool heading)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            var xmlString = "";

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter streamWriter = new StreamWriter(memoryStream))
                {
                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
                    {
                        Encoding = encoding,
                        OmitXmlDeclaration = !heading,
                    };

                    using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, xmlWriterSettings))
                    {
                        xmlSerializer.Serialize(xmlWriter, item, ns);

                        xmlWriter.Flush();
                        xmlString = xmlWriter.ToString();
                        xmlWriter.Close();
                    }

                    using (StreamReader streamReader = new StreamReader(memoryStream))
                    {
                        memoryStream.Position = 0;
                        xmlString = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
            }

            //using (StringWriter stringWriter = new StringWriter())
            //{

            //    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            //    {
            //        Encoding = Encoding.UTF8
            //    };

            //    using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
            //    {
            //        xmlSerializer.Serialize(xmlWriter, item, ns);
            //    }
            //    xmlString = stringWriter.ToString();
            //}

            return xmlString;
        }

        public static T XmlDeSerialize<T>(byte[] item, XmlSerializerNamespaces ns, Encoding encoding)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            MemoryStream memoryStream = new MemoryStream(item);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(memoryStream, encoding);
            return (T)xmlSerializer.Deserialize(reader);
        }


    }
}
