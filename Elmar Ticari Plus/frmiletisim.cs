using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmiletisim : Form
    {
        public frmiletisim()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
        }

        private void frmiletisim_Load(object sender, EventArgs e)
        {

        }
    }
}
