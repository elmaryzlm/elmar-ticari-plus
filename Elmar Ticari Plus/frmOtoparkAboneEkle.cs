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
    public partial class frmOtoparkAboneEkle : Form
    {
        public frmOtoparkAboneler _frmOtoparkAboneler = null;
        public int aboneid = 0;
        public void guncellemeModu()
        {
            SqlDataReader dr = veri.getDatareader("Select [aboneid], [cariid], [plaka], [marka], [model], [renk], [aboneBaslangic], [aboneSonlanma], [aboneUcreti], [pazartesi], [sali], [carsamba], [persembe], [cuma], [cumartesi], [pazar] From [oTblAbone] Where firmaid = " + firma.firmaid + " And aboneid = " + aboneid + "");
            while (dr.Read())
            {
                cariid = Convert.ToInt32(dr["cariid"]);
                txtPlaka.Text = dr["plaka"].ToString();
                txtMarka.Text = dr["marka"].ToString();
                txtModel.Text = dr["model"].ToString();
                txtRenk.Text = dr["renk"].ToString();
                dtBaslangic.Value = Convert.ToDateTime(dr["aboneBaslangic"]);
                dtBitis.Value = Convert.ToDateTime(dr["aboneSonlanma"]);
                //dr["aboneUcreti"].ToString();
                chkPazartesi.Checked = Convert.ToBoolean(Convert.ToByte(dr["pazartesi"]));
                chkSali.Checked = Convert.ToBoolean(Convert.ToByte(dr["sali"]));
                chkCarsamba.Checked = Convert.ToBoolean(Convert.ToByte(dr["carsamba"]));
                chkPersembe.Checked = Convert.ToBoolean(Convert.ToByte(dr["persembe"]));
                chkCuma.Checked = Convert.ToBoolean(Convert.ToByte(dr["cuma"]));
                chkCumartesi.Checked = Convert.ToBoolean(Convert.ToByte(dr["cumartesi"]));
                chkPazar.Checked = Convert.ToBoolean(Convert.ToByte(dr["pazar"]));
            }


            lblBaslik.Text = "            Abone Bilgilerini Güncelle";
            var l = cariBilgileri.bul_cariid(cariid);
            txtCariKodu.Text = l.cariKodu;
            txtCariAdi.Text = l.adi;
            txtCariUnvani.Text = l.soyadi;
            string cariGrubuAdi = "";
            try
            {
                var cariGrubu = cariBilgileri.cariGruplari.listCariGruplari.Where(u => u.cariGrupid == l.grupid).First();
                cariGrubuAdi = cariGrubu.grupAdi;

            }
            catch { }
            cmbCariGrubu.Text = cariGrubuAdi;
            txtHatirlatmaGunu.Value = l.hatirlatmaGunu;
            txtVergiDairesi.Text = l.vergiDaire;
            txtVergiNo.Text = l.vergiNo;
            txtCariAciklamasi.Text = l.cariAciklamasi;

            //adresler getiriliyor            
            var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid);
            foreach (var adresKaydi in adresListesi)
            {
                txtAdresAdi.Text = adresKaydi.adresAdi;
                txtBolge.Text = adresKaydi.boldeAdi;
                txtAdres.Text = adresKaydi.adres;
                txtTel.Text = adresKaydi.tel;
                txtFax.Text = adresKaydi.fax;
                txtGsm.Text = adresKaydi.gsm;
                txtEmail.Text = adresKaydi.email;
                if (adresKaydi.varsayilanmi == "0") chkVarsayilanAdresmi.Checked = false;
                else chkVarsayilanAdresmi.Checked = true;
                adresid = adresKaydi.adresid;
            }

        }

        public frmOtoparkAboneEkle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmOtopark"]);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(groupBox2);
            NesneGorselleri.kontrolEkle(groupBox3);
            NesneGorselleri.kontrolEkle(groupBox4);
        }

        void listeleriYukle()
        {
            try
            {
                cmbCariGrubu.Items.Clear();
                cmbCariGrubu.Items.AddRange(listeler.getCariGrupAdi());
            }
            catch { }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCariAdi.Text == "")
                {
                    MessageBox.Show("Abone Adını Girmediniz", firma.programAdi);
                    txtCariAdi.Select();
                    return;
                }
                if (txtAdresAdi.Text == "") txtAdresAdi.Text = "İletişim Adresi";
                string varsayilanAdresmi = "0";
                if (chkVarsayilanAdresmi.Checked == true) varsayilanAdresmi = "1";
                int grupid = 0;
                if (cmbCariGrubu.SelectedIndex >= 0) grupid = listeler.getCariGrupid()[cmbCariGrubu.SelectedIndex];
                int guzergahid = 0;
                string bolgeid = txtBolge.Tag.ToString();

                //cari ekleniyor, güncelleniyor.
                Int64 eklenenCariid = Convert.ToInt64(veri.getdatacell("exec spCariEkle " + cariid + ", 0 ,'" + txtCariKodu.Text + "', '" + txtCariAdi.Text + "','" + txtCariUnvani.Text + "', '" + txtVergiDairesi.Text + "','" + txtVergiNo.Text + "', '','" + grupid + "', '" + guzergahid + "','TL', '0','" + txtHatirlatmaGunu.Value + "', '" + txtCariAciklamasi.Text + "','', '','', '','0','0', '" + firma.firmaid + "','" + firma.subeid + "', '" + firma.kullaniciid + "'"));
                if (cariid != 0) cariBilgileri.listCariBilgileri.Remove(cariBilgileri.listCariBilgileri.Where(u => u.cariid == cariid).First());
                cariBilgileri.ekle(eklenenCariid, 0, txtCariKodu.Text, txtCariAdi.Text, txtCariUnvani.Text, txtCariAdi.Text + " " + txtCariUnvani.Text, "", "", txtVergiDairesi.Text, txtVergiNo.Text, "", grupid, guzergahid, "", "TL", 0, Convert.ToInt16(txtHatirlatmaGunu.Value), txtCariAciklamasi.Text, "", "", "", "", "1", "0", "1", "0", 0, DateTime.Now, "0", firma.subeid, firma.kullaniciid, 0, "-");
                listeler.yukleCariadi();

                //adres ekleniyor, güncelleniyor.
                if (adresid != 0) cariBilgileri.adresBilgileri.listAdresBilgileri.Remove(cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.adresid == adresid).First());
                Int64 eklenenAdresid = Convert.ToInt64(veri.getdatacell("exec spAdresEkle 0, '" + eklenenCariid + "', '" + txtAdresAdi.Text + "', '" + txtCariAdi.Text + "', '" + txtCariUnvani.Text + "', '" + txtEmail.Text + "', '" + txtTel.Text + "', '" + txtGsm.Text + "', '" + txtFax.Text + "', '" + bolgeid + "', '" + txtAdres.Text + "', '" + txtPostaKodu.Text + "', '', '" + txtVergiDairesi.Text + "', '" + txtVergiNo.Text + "', '', '" + varsayilanAdresmi + "', '" + firma.firmaid + "', '" + firma.subeid + "', '" + firma.kullaniciid + "'"));
                cariBilgileri.adresBilgileri.ekle(eklenenAdresid, eklenenCariid, txtCariAdi.Text + " " + txtCariUnvani.Text, txtAdresAdi.Text, txtCariAdi.Text, txtCariUnvani.Text, txtEmail.Text, txtTel.Text, txtGsm.Text, txtFax.Text, bolgeid, "", txtAdres.Text, txtPostaKodu.Text, "", txtVergiDairesi.Text, txtVergiNo.Text, "", varsayilanAdresmi, DateTime.Now, firma.subeid, firma.kullaniciid);
                listeler.yukleAdresler();


                string eklenenAboneid = veri.getdatacell("Exec spSetAbone '" + aboneid + "', '" + eklenenCariid + "', '" + txtPlaka.Text + "', '" + txtMarka.Text + "', '" + txtModel.Text + "', '" + txtRenk.Text + "', '" + dtBaslangic.Value + "', '" + dtBitis.Value + "' ,'" + 0 + "' ,'" + Convert.ToByte(chkPazartesi.Checked) + "', '" + Convert.ToByte(chkSali.Checked) + "', '" + Convert.ToByte(chkCarsamba.Checked) + "', '" + Convert.ToByte(chkPersembe.Checked) + "', '" + Convert.ToByte(chkCuma.Checked) + "', '" + Convert.ToByte(chkCumartesi.Checked) + "', '" + Convert.ToByte(chkPazar.Checked) + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");



                if (_frmOtoparkAboneler != null) _frmOtoparkAboneler.aboneListesiniYenile();
                this.Close();
                MessageBox.Show("İşlem Başarılı", firma.programAdi);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Cari Eklemede Hata Oluştu\nHata: " + hata.Message);
            }
        }
        public Int64 cariid = 0;
        Int64 adresid = 0;
        private void txtBolgeSec_Click(object sender, EventArgs e)
        {
            frmBolgeSecimi frm = new frmBolgeSecimi();
            frm._frmOtoparkAboneEkle = this;
            frm.Show();
        }

        private void frmOtoparkAboneEkle_Load(object sender, EventArgs e)
        {
            listeleriYukle();
            if (aboneid != 0) guncellemeModu();
        }
    }
}
