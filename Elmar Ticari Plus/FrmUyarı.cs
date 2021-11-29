using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class FrmUyarı : Form
    {
        public FrmUyarı(DataTable dt)
        {
            InitializeComponent();
            Properties.Settings.Default["uyariid"] =Convert.ToInt32(dt.Rows[0]["uyariid"]);
            Properties.Settings.Default.Save();
            label1.Text = dt.Rows[0]["uyariMetni"].ToString();
        }
    }
}
