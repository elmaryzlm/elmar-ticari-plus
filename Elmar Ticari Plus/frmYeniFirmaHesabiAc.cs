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
    public partial class frmYeniFirmaHesabiAc : Form
    {
        public frmYeniFirmaHesabiAc()
        {
            InitializeComponent();
        }

        private void frmYeniFirmaHesabiAc_Load(object sender, EventArgs e)
        {
            NesneGorselleri.form(this, false);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(groupBox2);
            illeriListele();

        }
        public void illeriListele()
        {
           
            SqlDataReader dr = veri.getDatareader("select bolgeid,bolgeAdi from sorBolgeler where len(bolgeid)=2 order by bolgeid asc");
            while (dr.Read())
            {
                try
                {

                    cmbBolge.Items.Add(dr["bolgeAdi"]);
                  
                }
                catch
                {
                }
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirmaAdi.Text == "")
                {
                    MessageBox.Show("Firma Adı boş bırakılamaz", firma.programAdi);
                    txtFirmaAdi.Select();
                    return;
                }
                if (txtTelefon.Text == "")
                {
                    MessageBox.Show("Telefon Adı boş bırakılamaz", firma.programAdi);
                    txtTelefon.Select();
                    return;
                }
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Email Adı boş bırakılamaz", firma.programAdi);
                    txtEmail.Select();
                    return;

                  
                }
                if (cmbBolge.Text == "")
                {
                    MessageBox.Show("Bölge Adı boş bırakılamaz", firma.programAdi);
                    cmbBolge.Select();
                    return;
                }
                if (txtSubeadi.Text == "")
                {
                    MessageBox.Show("Şube Adı boş bırakılamaz", firma.programAdi);
                    txtSubeadi.Select();
                    return;
                }
                if (txtKullaniciadi.Text == "")
                {
                    MessageBox.Show("Kullanıcı adı boş bırakılamaz", firma.programAdi);
                    txtKullaniciadi.Select();
                    return;
                }
                if (txtSifre.Text == "")
                {
                    MessageBox.Show("Şifre boş bırakılamaz", firma.programAdi);
                    txtSifre.Select();
                    return;
                }
                if (txtKullaniciadi.Text.Contains(" "))
                {
                    MessageBox.Show("Kullanıcı Adı Boşluk Karakteri İçeremez", firma.programAdi);
                    txtKullaniciadi.Select();
                    return;
                }
              
                if (txtKullaniciadi.Text.Contains("é"))
                {
                    MessageBox.Show("Kullanıcı Adı 'é' özel karakterini içeremez.", firma.programAdi);
                    txtKullaniciadi.Select();
                    return;
                }
                string eskiDb = veri.db;

               veri.db = "ElmarTicariPlus2017";
                int varmi = Convert.ToInt16(veri.getdatacell("Select count(kAdi) from sorFirmaKullanicilari where kAdi='" + txtKullaniciadi.Text + "'"));
                if (varmi > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten mevcut durumda.farklı bir kullanıcı adı seçin.", firma.programAdi);
                    txtKullaniciadi.Clear();
                    txtKullaniciadi.Select();
                    return;
                }
                veri.cmd("exec spFirmaHesabiAc '" + txtFirmaAdi.Text + "','" + txtFirmaUnvani.Text + "','" + txtTelefon.Text + "','" + txtEmail.Text + "','" + cmbBolge.Text + "','" + txtSubeadi.Text + "','" + txtKullaniciadi.Text + "','" + txtSifre.Text + "','" + txtAdsoyad.Text + "'");
                int sayac = 0;

                for (int i = 0; i < txtEmail.Text.Length - 3; i++)
                {
                    if (txtEmail.Text.Substring(i, 4) == ".com" && txtEmail.Text.Substring(i - 1, 1) != "@")
                    {
                        sayac++;
                    }
                    if (txtEmail.Text.Substring(i, 1) == "@")
                    {
                        sayac++;
                    }
                }
                if (sayac == 2)
                {

                }
                else
                {
                    MessageBox.Show("Geçerli bir mail adresi giriniz!");
                    sayac = 0;
                    txtEmail.Select();
                    return;
                }
                MessageBox.Show("Hesabınız Başarıyla Oluşturuldu.Artık bu kullanıcı ile giriş yapabilirsiniz.", firma.programAdi);
                veri.db = eskiDb;
                this.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt işleminde Bir hata oluştu.\nHata Metni: "+hata.Message,firma.programAdi);
            }
        }

       
       
    }
}
