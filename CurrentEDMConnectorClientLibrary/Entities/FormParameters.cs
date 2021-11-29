using System;


namespace CurrentEDMConnectorClientLibrary
{
    public class FormParameters
    {
        public string sessionID { get; set; }
        public string actionDate { get; set; }
        public string applicationName { get; set; }
        public string channelName { get; set; }
        public string compressed { get; set; }
        public string hostName { get; set; }
        public bool loginEnter { get; set; }
        public string checkUserEnter { get; set; }
        public string sendInvoiceEnter { get; set; }
        public string invoiceStatusEnter { get; set; }
        public string getInvoiceEnter { get; set; }
        public string gibUserListEnter { get; set; }
        public Exception ifHaveError { get; set; }
        public string ifHaveErrorDetail { get; set; }
        public EdmService.GIBUSER[] vknUser { get; set; }
        public EdmService.GIBUSER[] gibUserList { get; set; }
        public string[] invoiceStatusElements { get; set; }
        public string[] invoiceElements { get; set; }
        public long ActionElapsedMs { get; set; }
        public string ActionName { get; set; }
    }
    
}
