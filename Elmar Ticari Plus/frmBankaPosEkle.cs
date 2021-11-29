using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmBankaPosEkle : Form
    {
        public frmBankaPosEkle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(panel2);
        }
        public frmBankaPos _frmBankaPos = null;
        private void frmBankaPosEkle_Load(object sender, EventArgs e)
        {
            dgDoldur();
            getHesapAdi();
            getPosAdi();
        }
        List<int> listBankaHesapid = new List<int>();
        public void getHesapAdi()
        {
            listBankaHesapid.Clear();
            SqlDataReader dr = veri.getDatareader("select bankaHesapid, hesapAdi from sorBankaHesaplari where silindimi = '0' and firmaid = "+firma.firmaid+" and hesapTuru like '%Kendi%' order by hesapAdi asc");
            while (dr.Read())
            {
                cmbBankaHesabi.Items.Add(dr["hesapAdi"].ToString());
                listBankaHesapid.Add(Convert.ToInt32(dr["bankaHesapid"]));
            }
        }

        List<int> listPosTaslakID = new List<int>();
        public void getPosAdi()
        {
            listPosTaslakID.Clear();
            cmbPosAdi.Items.Clear();
            SqlDataReader dr = veri.getDatareader("select posTaslakid, posTaslakAdi from tblBankaPosTaslak order by posTaslakAdi asc");
            while (dr.Read())
            {
                cmbPosAdi.Items.Add(dr["posTaslakAdi"].ToString());
                listPosTaslakID.Add(Convert.ToInt32(dr["posTaslakid"]));
            }
        }
        void dgDoldur()
        {
            dgTaksitOranlari.Rows.Clear();
            for (int i = 1; i <= 36; i++)
            {
                dgTaksitOranlari.Rows.Add("0", i.ToString(), "-");
            }
            dgTaksitOranlari.Columns["taksitSayisi"].DefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBankaHesabi.Items.Contains(cmbBankaHesabi.Text) == false)
                { 
                    MessageBox.Show("Geçerli bir Banka Hesabı Seçin",firma.programAdi);
                    cmbBankaHesabi.Select();
                    return;
                }
                string eklenenPosiid = veri.getdatacell("exec spSetBankaPos 0, " + listBankaHesapid[cmbBankaHesabi.SelectedIndex] + ", '" + txtTanimAdi.Text + "', " + listPosTaslakID[cmbPosAdi.SelectedIndex] + ", '" + cmbPosAdi.Text + "','0', '" + txtAyrinti.Text + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");
                

                string metin = "";
                for (int i = 0; i < dgTaksitOranlari.Rows.Count; i++)
                {
                    string aylikOran = "-1";
                    if (dgTaksitOranlari.Rows[i].Cells["aylikOran"].Value.ToString() != "-") aylikOran = dgTaksitOranlari.Rows[i].Cells["aylikOran"].Value.ToString();
                    metin = metin + aylikOran + "|";
                }
                
                
                veri.cmd("exec spSetBankaPosTaksitAyir  " + eklenenPosiid + ", '" + metin + "'," + firma.firmaid + ", " + subeBilgileri.subeid + " ," + firma.kullaniciid + " ");
                MessageBox.Show("Kayıt İşlemi Başarıyla Yapıldı", firma.programAdi);
                this.Close();
            }
            catch (Exception hata) 
            {
                MessageBox.Show("Kayıt İşleminde Hata Oluştu. Hata Metni: "+hata.Message, firma.programAdi);
            }
        }
    }
}