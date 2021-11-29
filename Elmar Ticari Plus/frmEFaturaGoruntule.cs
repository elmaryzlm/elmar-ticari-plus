using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Elmar_Ticari_Plus
{
   
    public partial class frmEFaturaGoruntule : Form
    {

        public frmEFaturaGoruntule(string faturaNo)
        {
            InitializeComponent();
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            this.webBrowser1.Url = new Uri(Path.Combine(directoryName+"\\ubl_testfatura\\" + faturaNo));
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();
            this.Close();
        }
    }
}
