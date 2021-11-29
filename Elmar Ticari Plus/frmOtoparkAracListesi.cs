using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Elmar_Ticari_Plus
{
    public partial class frmOtoparkAracListesi : Form
    {
        public frmOtoparkAracListesi()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmOtopark"]);
        }

        private void frmOtoparkAracListesi_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            int aboneSayisi = 0, yeniPark = 0;
            lwAracListesi.Clear();
            SqlDataReader dr = veri.getDatareader("Select (Select isnull(adi,'')+' '+isnull(soyadi,'') From oSorAbone Where aboneid = oSorOtoparkTekilAracListesi.aboneid) as aboneAdi , plaka, tarih, saat from oSorOtoparkTekilAracListesi Where firmaid = "+firma.firmaid+" And islemTuru = 'Giriş' Order by otoparkislemid desc");
            while (dr.Read())
            { 
                ListViewItem li = new ListViewItem();
                li.Text = dr["plaka"].ToString() + "\n " + dr["aboneAdi"].ToString() + "\n " + dr["tarih"].ToString().Substring(0, 10) + " " + dr["saat"].ToString().Substring(0, 5);
                li.Font = new Font("Arial", 9, FontStyle.Regular);
                if ( dr["aboneAdi"] != null && dr["aboneAdi"].ToString().Length>0)
                {
                    li.ImageIndex = 0;
                    aboneSayisi++;
                }
                else
                {
                    li.ImageIndex = 1;
                    yeniPark++;
                }
                lwAracListesi.Items.Add(li);
            }
            lblSayac.Text = "Abone Araç Sayısı: " + aboneSayisi.ToString() + "   |   Yeni Park: " + yeniPark.ToString() + "   |   Toplam Araç Sayısı: " + (aboneSayisi + yeniPark).ToString();
        }
        
    }
}
