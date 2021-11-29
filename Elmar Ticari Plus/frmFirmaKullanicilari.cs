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
using System.Diagnostics;
namespace Elmar_Ticari_Plus
{
    public partial class frmFirmaKullanicilari : Form
    {
        int seciliKullaniciid = 0;
        string seciliKullaniciAdi = "";
        byte deger = 0;
        public frmFirmaKullanicilari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgKullanicilar);
            NesneGorselleri.kontrolEkle(pnlBilgileri);
        }

        void kullaniciListele()
        {
            dgKullanicilar.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("SELECT [kullaniciid],[kAdi],[sifre],[adiSoyadi],[gorevi],[onlinemi],[eklenmeTarihi],[subeid],[subeAdi],[girisizni] FROM [sorFirmaKullanicilari] where firmaid = '" + firma.firmaid + "' order by kAdi asc");
            while (dr.Read())
            {
                dgKullanicilar.Rows.Add(dr["kullaniciid"].ToString(), dr["kAdi"].ToString(), dr["sifre"].ToString(), dr["adiSoyadi"].ToString(), dr["gorevi"].ToString(), dr["onlinemi"].ToString(), dr["eklenmeTarihi"].ToString(), dr["subeid"].ToString(), dr["subeAdi"].ToString(), dr["girisizni"].ToString());
            }
        }

        private void frmFirmaKullanicilari_Load(object sender, EventArgs e)
        {
            listeler.doldurSube(cmbSube);
            kullaniciListele();
            temizle();
            ters();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int mevcutkullaniciSayisi = Convert.ToInt32(veri.getdatacell("select count(*) from sorFirmaKullanicilari where firmaid = " + firma.firmaid));
            int maxKullaniciSayisi = Convert.ToInt32(firmaBilgileri.maxKullaniciSayisi);
            if (mevcutkullaniciSayisi + 1 > maxKullaniciSayisi)
            {
                MessageBox.Show("Maksimum kullanıcı sayısına ulaşmışsınız. Yeni kullanıcı eklemek için üst pakete geçmelisiniz. Elmar Yazılım ile irtibata geçin.", firma.programAdi);
                Process.Start(Application.StartupPath + "\\Yardım.exe", "1é" + firma.kullaniciid.ToString());
                return;
            }
            duz();
            temizle();
            txtKullaniciAdi.Select();
            deger = 1;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgKullanicilar.Rows.Count == 1)
                {
                    MessageBox.Show("Son kalan kullanıcınızı silemezsiniz.",firma.programAdi);
                    return;
                }
                if (seciliKullaniciid == 0)
                {
                    MessageBox.Show("Listeden işlem yapılacak kullanıcıyı seçin", firma.programAdi);
                    return;
                }
                if (MessageBox.Show(seciliKullaniciAdi + " adlı kullanıcıyı Silmek İstediğinize Eminmisiniz?", firma.programAdi, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    veri.cmd("Update tblFirmaKullanicilari set silindimi = '1' where kullaniciid = " + seciliKullaniciid + " and firmaid = " + firma.firmaid + "");
                    temizle();
                    dgKullanicilar.Rows.Remove(dgKullanicilar.CurrentRow);
                    listeler.yukleKullanici();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Silinemedi\nHata Metni: " + hata.Message, firma.programAdi);
            }          
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {
            if (seciliKullaniciid == 0)
            {
                MessageBox.Show("Listeden işlem yapılacak kullanıcıyı seçin", firma.programAdi);
                return;
            }
            duz();
            txtKullaniciAdi.Select();
            deger = 2;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                //Kullanıcı kontrolü Yapılıyor
                if (txtKullaniciAdi.Text.Contains(" "))
                {
                    MessageBox.Show("Kullanıcı Adı Boşluk Karakteri İçeremez", firma.programAdi);
                    txtKullaniciAdi.Select();
                    return;
                }
                if (txtKullaniciAdi.Text == "")
                {
                    MessageBox.Show("Kullanıcı Adı alanı boş bırakılamaz.", firma.programAdi);
                    txtKullaniciAdi.Select();
                    return;
                }
                int varmi = Convert.ToInt16(veri.getdatacell("Select count(kAdi) from sorFirmaKullanicilari where kAdi='" + txtKullaniciAdi.Text + "'"));
                if (deger == 2 && txtKullaniciAdi.Text == dgKullanicilar.CurrentRow.Cells["kAdi"].Value.ToString()) varmi = 0;
                if (varmi > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten mevcut durumda.farklı bir kullanıcı adı seçin.", firma.programAdi);
                    txtKullaniciAdi.Clear();
                    txtKullaniciAdi.Select();
                    return;
                }
                //Şifre Kontrolü Yapılıyor
                if (txtSifre.Text == "")
                {
                    MessageBox.Show("Şifre boş bırakılamaz", firma.programAdi);
                    txtSifre.Select();
                    return;
                }
                //Şube Kontrolü Yapılıyor
                if (cmbSube.Text == "" || cmbSube.SelectedIndex==-1)
                {
                    MessageBox.Show("Şube boş bırakılamaz", firma.programAdi);
                    cmbSube.Select();
                    return;
                }
                //Kullanıcı bilgileri ekleniyor, düzenleniyor
                seciliKullaniciid = Convert.ToInt32(veri.getdatacell("Exec spSetFirmaKullanicilari " + seciliKullaniciid + ", '" + txtKullaniciAdi.Text + "', '" + txtSifre.Text + "', '" + txtAdiSoyadi.Text + "', '" + cmbGorevi.Text + "', " + firma.firmaid + ", " + cmbSube.Tag.ToString() + ",'"+  Convert.ToByte(chkGirisizni.Checked) +"'"));
                seciliKullaniciAdi = txtKullaniciAdi.Text;

                if (deger == 1)
                {
                    dgKullanicilar.Rows.Add(seciliKullaniciid, txtKullaniciAdi.Text, txtSifre.Text, txtAdiSoyadi.Text, cmbGorevi.Text, "0", DateTime.Now, cmbSube.Tag, cmbSube.Text, "1");
                    dgKullanicilar.Rows[dgKullanicilar.Rows.Count - 1].Cells[1].Selected = true;
                }
                else if (deger == 2)
                {
                    kullaniciListele();
                }
                listeler.yukleKullanici();
                this.Refresh();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. \nHata Metni: " + hata.Message);
            }
            ters();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            ters();
        }

        void ters()
        {
            btnDegistir.Enabled = true;
            btnEkle.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            btnİptal.Enabled = false;
            pnlBilgileri.Enabled = false;
            dgKullanicilar.Enabled = true ;
        }
        void duz()
        {
            btnDegistir.Enabled = false;
            btnEkle.Enabled = false;
            btnSil.Enabled = false;
            btnKaydet.Enabled = true;
            btnİptal.Enabled = true;
            pnlBilgileri.Enabled = true;
            dgKullanicilar.Enabled = false;
        }

        void temizle()
        {
            txtKullaniciAdi.Clear();
            txtSifre.Text = "";
            seciliKullaniciid = 0;
            seciliKullaniciAdi = "";
            cmbGorevi.Text="";
            cmbSube.Text="";
            cmbSube.Tag = "0";
            txtAdiSoyadi.Clear();
            txtOnlinemi.Clear();
            chkGirisizni.Checked = true;
            txtEklenmeTarihi.Clear();
            dgKullanicilar.ClearSelection();
            deger = 0;
        }

        private void dgKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seciliKullaniciid = Convert.ToInt32(dgKullanicilar.CurrentRow.Cells["kullaniciid"].Value);
                seciliKullaniciAdi = dgKullanicilar.CurrentRow.Cells["kAdi"].Value.ToString();
                txtKullaniciAdi.Text = dgKullanicilar.CurrentRow.Cells["kAdi"].Value.ToString();
                txtSifre.Text = dgKullanicilar.CurrentRow.Cells["sifre"].Value.ToString();
                cmbSube.Tag = dgKullanicilar.CurrentRow.Cells["subeid"].Value.ToString();
                cmbSube.Text = dgKullanicilar.CurrentRow.Cells["subeAdi"].Value.ToString();
                cmbGorevi.Text = dgKullanicilar.CurrentRow.Cells["gorevi"].Value.ToString();
                txtAdiSoyadi.Text = dgKullanicilar.CurrentRow.Cells["adiSoyadi"].Value.ToString();
                txtEklenmeTarihi.Text = dgKullanicilar.CurrentRow.Cells["eklenmeTarihi"].Value.ToString();
                chkGirisizni.Checked = Convert.ToBoolean(Convert.ToByte(dgKullanicilar.CurrentRow.Cells["girisizni"].Value));
                txtOnlinemi.Text = "Hayır";
                if(dgKullanicilar.CurrentRow.Cells["onlinemi"].Value.ToString() == "1") txtOnlinemi.Text = "Evet";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void cmbSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSube.Tag = ComboboxItem.getSelectedValue(cmbSube);
        }
        
    }
}
