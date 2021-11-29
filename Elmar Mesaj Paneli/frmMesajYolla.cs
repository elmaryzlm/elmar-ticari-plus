using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.Data.SqlClient;
using System.Threading;
namespace Elmar_Mesaj_Paneli
{
    public partial class frmMesajYolla : Form
    {
        public frmMesajYolla()
        {
            InitializeComponent();
        }
        public string kAdi;
        public string kullaniciid;
        Thread kanal;
        private void frmMesajYolla_Load(object sender, EventArgs e)
        {
            this.Text = kAdi + " Konuşma";
            lblGönderen.Text = lblGönderen.Text + " " + kAdi;
            txtGiden.Select();
            kanal = new Thread(new ThreadStart(txtGelen_doldur));
            kanal.Start();
        }

        void txtGelen_doldur()
        {
            if (guvenlikVeKontrol.internetVarmi())
            {
                string gecerliKisi = "";
                SqlDataReader dr = veri.getDatareader("select  kullaniciid, kAdi, mesajMetni from sorMesajlar where firmaid = " + firma.firmaid + " and ((kime = " + firma.kullaniciid + " and kullaniciid = " + kullaniciid + ") or (kime = " + kullaniciid + " and kullaniciid = " + firma.kullaniciid + ")) order by mesajid asc");
                while (dr.Read())
                {
                    //if (dr["kullaniciid"].ToString() == firma.kullaniciid.ToString()) gecerliKisi = firma.kullaniciAdi;
                    //else gecerliKisi = dr["kNo"].ToString();
                    txtGelen.Text += dr["kAdi"].ToString() + ":\r\n";
                    txtGelen.Text += dr["mesajMetni"].ToString() + "\r\n";
                }
                veri.cmd("update tblMesajlar set okundumu = '1' , popupGosterildimi = '1' where kullaniciid = '" + kullaniciid + "' and firmaid = " + firma.firmaid + " and kime = " + firma.kullaniciid + "");
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                if (guvenlikVeKontrol.internetVarmi())
                {
                    if (txtGiden.Text.Length > 0 && txtGiden.Text != " ")
                    {
                        veri.cmd("insert into tblMesajlar(mesajMetni, kime, mesajTarihi, firmaid, subeid, kullaniciid) values('" + txtGiden.Text + "'," + kullaniciid + ",getdate()," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                        txtGelen.Text = txtGelen.Text + firma.kullaniciAdi + ":\r\n";
                        txtGelen.Text = txtGelen.Text + txtGiden.Text + "\r\n";
                        txtGiden.Text = "";
                        txtGiden.Select();
                    }
                }
                else
                {
                    MessageBox.Show("İnternet Bağlantınızı Kontrol Edin", "Elmar Ticari Plus Mesaj Paneli");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }           
        }

        private void txtGiden_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Shift == false)
            {
                btnGonder_Click(sender, e);
                e.Handled = true;
            }
        }

        private void txtGiden_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGelen.SelectionStart = txtGelen.Text.Length - 1;
                txtGelen.SelectionLength = 0;
            }
            catch
            {
            }
        }
    }
}
