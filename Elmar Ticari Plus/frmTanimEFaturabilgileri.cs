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
    public partial class frmTanimEFaturabilgileri : Form
    {
        public frmTanimEFaturabilgileri()
        {
            InitializeComponent();
            txtAdres.Text = EFatura.Adres;
            txtFirmaAdi.Text = EFatura.FirmaAdi;
            txtKullaniciAdi.Text = EFatura.KullaniciAdi;
            txtSifre.Text = EFatura.Sifre;
            txtGB.Text = EFatura.Gb;
            txtMersisNo.Text = EFatura.MersisNo;
            txtSehir.Text = EFatura.Sehir;
            txtTicaretSicilNo.Text = EFatura.TicaretSicilNo;
            txtVergiDairesi.Text = EFatura.VergiDairesi;
            txtVergiNo.Text = EFatura.VergiNo;
            chbOto.Checked = EFatura.OtoGonder;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text.Trim().Length == 0)
            {
                myMesaj("Şifre giriniz");
                return;
            }
            if (txtKullaniciAdi.Text.Trim().Length == 0)
            {
                myMesaj("Kullanıcı Adı giriniz");
                return;
            }
            if (txtGB.Text.Trim().Length == 0)
            {
                myMesaj("GB(Gib posta kutusu) giriniz");
                return;
            }
            if (txtVergiNo.Text.Trim().Length == 0)
            {
                myMesaj("Vergi No giriniz");
                return;
            }
            if (txtVergiDairesi.Text.Trim().Length == 0)
            {
                myMesaj("Vergi Dairesi giriniz");
                return;
            }

            if (txtTicaretSicilNo.Text.Trim().Length == 0)
            {
                myMesaj("Ticaret Sicil No giriniz");
                return;
            }

            try
            {
                if(EFatura.EFaturaID==0)
                veri.cmd(@"insert into tblEFaturaBilgileri(KAdi, Sifre,GB, VNo,VD,Adres,MN,TSC,FirmaAdi,Sehir,FirmaID,OtoGonder) " +
                         "values('"+txtKullaniciAdi.Text+"','"+txtSifre.Text+"','"+txtGB.Text+"','"+txtVergiNo.Text+"','"+txtVergiDairesi.Text+"','"+txtAdres.Text+"','"+txtMersisNo.Text+"','"+txtTicaretSicilNo.Text+"','"+txtFirmaAdi.Text+"','"+txtSehir.Text+"',"+firma.firmaid+",'"+Convert.ToBoolean(chbOto.Checked)+"')");

                else veri.cmd(@"update tblEFaturaBilgileri set KAdi='" + txtKullaniciAdi.Text + "', Sifre='" + txtSifre.Text + "', GB='" + txtGB.Text + "', VNo='" + txtVergiNo.Text + "', VD='" + txtVergiDairesi.Text + "', Adres='" + txtAdres.Text + "',MN='" + txtMersisNo.Text + "', TSC='" + txtTicaretSicilNo.Text + "',FirmaAdi='" + txtFirmaAdi.Text + "', Sehir='" + txtSehir.Text + "',OtoGonder='"+Convert.ToBoolean(chbOto.Checked)+"' where EFaturaID="+EFatura.EFaturaID);
                MessageBox.Show("İşlem Başarılı");
                EFatura.getEFaturaBilgileri();
                this.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Ekleme işleminde hata oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }

        }

        private void myMesaj(string s)
        {
            MessageBox.Show(s, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
