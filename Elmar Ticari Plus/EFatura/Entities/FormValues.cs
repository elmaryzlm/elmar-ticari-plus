using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrentEDMConnectorClientLibrary.Entities
{
    public class FormValues
    {
        public static string sessionID { get; set; }
        public static string actionDate { get; set; }
        public static string applicationName { get; set; }
        public static string channelName { get; set; }
        public static string compressed { get; set; }
        public static string hostName { get; set; }
        public static string loginEnter { get; set; }
        public static string checkUserEnter { get; set; }
        public static string sendInvoiceEnter { get; set; }
        public static string invoiceStatusEnter { get; set; }
        public static string getInvoiceEnter { get; set; }
        public static string gibUserListEnter { get; set; }
        public static Exception ifHaveError { get; set; }
        public static string ifHaveErrorDetail { get; set; }
        public static Elmar_Ticari_Plus.EDMService.GIBUSER[] vknUser { get; set; }
        public static Elmar_Ticari_Plus.EDMService.GIBUSER[] gibUserList { get; set; }
        public static string[] invoiceStatusElements { get; set; }
        public static string[] invoiceElements { get; set; }
        public static long ActionElapsedMs { get; set; }
        public static string ActionName { get; set; }

    }
}
