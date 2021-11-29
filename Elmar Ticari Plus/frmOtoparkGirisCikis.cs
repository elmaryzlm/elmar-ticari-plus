using elmarLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmOtoparkGirisCikis : Form
    {
        public frmOtoparkGirisCikis()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmOtopark"]);
            NesneGorselleri.dataGridView(dgHizmetler);
            NesneGorselleri.kontrolEkle(panel1);
            NesneGorselleri.kontrolEkle(panel4);
            NesneGorselleri.kontrolEkle(panel5);
            NesneGorselleri.kontrolEkle(panel7);
        }

        private void frmOtoparkGirisCikis_Load(object sender, EventArgs e)
        {
            hizmetListele();
            formuTemizle();
        }
        veri veri1 = new veri();
        private void hizmetListele()
        {
            dgHizmetler.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select hizmetid, adi, fiyat From oTblHizmetTaslak Where firmaid = " + firma.firmaid + "  And silindimi = '0' Order by adi asc");
            while (dr.Read())
            {
                dgHizmetler.Rows.Add(dr["hizmetid"].ToString(), dr["adi"].ToString(), Convert.ToDouble(dr["fiyat"]), false);
            }
        }
        private int aboneid = 0;
        private int cariid = 0;
        private void txtPlaka_TextChanged(object sender, EventArgs e)
        {
            formuTemizle();
            if (txtPlaka.Text == "") return;
            SqlDataReader dr = veri.getDatareader("Exec spGetOtoparkislem '" + txtPlaka.Text + "', " + firma.firmaid + "");
            while (dr.Read())
            {
                string sonislemTuru = dr["islemTuru"].ToString();
                if (sonislemTuru != null && sonislemTuru.Length > 0)
                {
                    if (sonislemTuru == "Giriş")
                    {
                        //Çıkış işlemleri
                        dgHizmetler.Enabled = true;
                        btnGirisYap.Enabled = false;
                        btnCikisYap.Enabled = true;
                        dtGirisTarihi.Value = Convert.ToDateTime(dr["tarih"]);
                        txtGirisSaati.Text = dr["saat"].ToString();
                        string gun = dr["parkGun"].ToString();
                        if (gun.Length == 1) gun = "0" + gun;
                        string saat = dr["parkSaat"].ToString();
                        if (saat.Length == 1) saat = "0" + saat;
                        string dakika = dr["parkDakika"].ToString();
                        if (dakika.Length == 1) dakika = "0" + dakika;
                        lblParkSaati.Text = gun + "\n" + saat + ":" + dakika;
                    }
                    else
                    {
                        //Giriş İşlemleri
                        dgHizmetler.Enabled = false;
                        btnGirisYap.Enabled = true;
                        btnCikisYap.Enabled = false;
                        dtGirisTarihi.Value = DateTime.Now;
                        txtGirisSaati.Text = DateTime.Now.ToShortTimeString();

                    }
                }
                else
                {
                    //Giriş İşlemleri
                    dgHizmetler.Enabled = false;
                    btnGirisYap.Enabled = true;
                    btnCikisYap.Enabled = false;
                    dtGirisTarihi.Value = DateTime.Now;
                    txtGirisSaati.Text = DateTime.Now.ToShortTimeString();
                }
                aboneid = Convert.ToInt32(dr["aboneid"]);
                cariid = Convert.ToInt32(dr["cariid"]);
                if (aboneid == 0) picResim.Image = Properties.Resources.Yeni_Park1;
                else
                {
                    picResim.Image = Properties.Resources.abone2;
                    txtAboneAdi.Text = dr["aboneAdi"].ToString();
                    txtMarka.Text = dr["marka"].ToString();
                    txtModel.Text = dr["model"].ToString();
                    txtRenk.Text = dr["renk"].ToString();
                    chkPazartesi.Checked = Convert.ToBoolean(Convert.ToByte(dr["pazartesi"]));
                    chkSali.Checked = Convert.ToBoolean(Convert.ToByte(dr["sali"]));
                    chkCarsamba.Checked = Convert.ToBoolean(Convert.ToByte(dr["carsamba"]));
                    chkPersembe.Checked = Convert.ToBoolean(Convert.ToByte(dr["persembe"]));
                    chkCuma.Checked = Convert.ToBoolean(Convert.ToByte(dr["cuma"]));
                    chkCumartesi.Checked = Convert.ToBoolean(Convert.ToByte(dr["cumartesi"]));
                    chkPazar.Checked = Convert.ToBoolean(Convert.ToByte(dr["pazar"]));
                }
            }
        }
        private void formuTemizle()
        {
            picResim.Image = null;
            lblParkSaati.Text = "";
            txtMarka.Clear();
            txtModel.Clear();
            txtRenk.Clear();
            txtAboneAdi.Clear();
            aboneid = 0;
            txtGirisSaati.Clear();
            chkPazartesi.Checked = false;
            chkSali.Checked = false;
            chkCarsamba.Checked = false;
            chkPersembe.Checked = false;
            chkCuma.Checked = false;
            chkCumartesi.Checked = false;
            chkPazar.Checked = false;

            txtAnlikTutar.Text = "0";
            txtEskiBakiye.Text = "0";
            txtPesinat.Text = "0";
            txtToplam.Text = "0";
            txtToplamHizmetTutari.Text = "0";

            for (int i = 0; i < dgHizmetler.Rows.Count; i++)
            {
                dgHizmetler.Rows[i].Cells["chkSecim"].Value = false;
            }
            dgHizmetler.Enabled = false;
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (txtPlaka.Text == "") return;
            try
            {

                string tarih = dtGirisTarihi.Value.Month + "." + dtGirisTarihi.Value.Day + "." + dtGirisTarihi.Value.Year + " " + dtGirisTarihi.Value.Hour + ":" + dtGirisTarihi.Value.Minute + ":" + dtGirisTarihi.Value.Second;
                veri.cmd("Insert into oTblOtoparkislemleri(aboneid, plaka, tarih, saat, islemTuru, firmaid, subeid, kullaniciid) values(" + aboneid + ", '" + txtPlaka.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + txtGirisSaati.Text + "', 'Giriş', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + ")");
                formuTemizle();
                txtPlaka.Clear();
                txtPlaka.Select();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Giriş işleminde sorun oluştu\nHata metni:" + hata.Message, firma.programAdi);
            }
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            if (txtPlaka.Text == "") return;
            if (cariid > 0 && Convert.ToDouble(txtPesinat.Text) == 0)
            {
                MessageBox.Show("Peşinat girişi yapmadınız", firma.programAdi);
                txtPesinat.Select();
                return;
            }
            try
            {
                string tarih = DateTime.Now.Month + "." + DateTime.Now.Day + "." + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                int otoparkislemID = 0;
                veri.cmd("Insert into oTblOtoparkislemleri(aboneid, plaka, tarih, saat, islemTuru, firmaid, subeid, kullaniciid) values(" + aboneid + ", '" + txtPlaka.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() + "', 'Çıkış', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + ")");
                SqlDataReader dr = veri.getDatareader("select Max(otoparkislemid)as id from oTblOtoparkislemleri");
                while (dr.Read())
                {
                    otoparkislemID = Convert.ToInt32(dr["id"].ToString());
                }



                string yapilanHizmetler = "";
                for (int i = 0; i < dgHizmetler.Rows.Count; i++)
                {
                    if ((bool)dgHizmetler.Rows[i].Cells["chkSecim"].Value) yapilanHizmetler = yapilanHizmetler + dgHizmetler.Rows[i].Cells["adi"].Value.ToString() + ",";
                }
                if (cariid == 0)
                {
                    acikHesap.ekle(otoparkislemID, 0,  0, 0, 0, cariid, DateTime.Now, DateTime.Now, DateTime.Now, 0, Convert.ToDouble(txtAnlikTutar.Text), "TL", 1, 0, "Peşin", "Satış", "Kasa", yapilanHizmetler, "", "", "", "", "", "1", "0", firma.subeid, firma.kullaniciid, 0, 0);
                }
                if (Convert.ToDouble(txtPesinat.Text) > 0)
                {
                    acikHesap.ekle(otoparkislemID, 0, 0, 0, 0, cariid, DateTime.Now, DateTime.Now, DateTime.Now, Convert.ToDouble(txtPesinat.Text), 0, "TL", 1, 0, "Peşin", "Tahsilat", "Kasa", yapilanHizmetler, "", "", "", "", "", "1", "0", firma.subeid, firma.kullaniciid, 0, 0);
                }
                formuTemizle();
                txtPlaka.Clear();
                txtPlaka.Select();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Giriş işleminde sorun oluştu\nHata metni:" + hata.Message, firma.programAdi);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double toplam = 0;
            for (int i = 0; i < dgHizmetler.Rows.Count; i++)
            {
                if ((bool)dgHizmetler.Rows[i].Cells["chkSecim"].Value)
                    toplam += Convert.ToDouble(dgHizmetler.Rows[i].Cells["fiyat"].Value);
            }
            txtToplamHizmetTutari.Text = String.Format("{0:n2}", toplam);
        }

        private void txtToplamHizmetTutari_TextChanged(object sender, EventArgs e)
        {
            txtAnlikTutar.Text = txtToplamHizmetTutari.Text;
        }

        private void txtAnlikTutar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double _toplam = Convert.ToDouble(txtEskiBakiye.Text) + Convert.ToDouble(txtAnlikTutar.Text) - Convert.ToDouble(txtPesinat.Text);
                txtToplam.Text = string.Format("{0:n2}", _toplam);
            }
            catch
            {
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            raporOlustur();
            rpr.onizleme();

        }
        rapor rpr;
        bool raporOlustur()
        {
            rpr = new rapor();
            rpr.setKagitboyutu(20, 150);
            rpr.yaziYazdirmaSiniri = 0;
            int y = 5;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Otopark Fişi", new Font("Arial", 12, FontStyle.Bold), new Point(5, y)));
            y += 6;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Plaka: " + txtPlaka.Text, new Rectangle(5, y, 100, 4), false));
            y += 4;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Giriş Saati: " + dtGirisTarihi.Value.ToShortDateString() + " " + txtGirisSaati.Text, new Rectangle(5, y, 100, 4), false));
            y += 4;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Park Saati: " + lblParkSaati.Text.Replace("\n", " gün "), new Rectangle(5, y, 100, 4), false));
            y += 4;
            rpr.ekleSabitCizgi(new rapor.sabitCizgi(5, 70, y, y));
            y += 2;
            for (int i = 0; i < dgHizmetler.Rows.Count; i++)
            {
                if ((bool)dgHizmetler.Rows[i].Cells["chkSecim"].Value)
                {
                    rpr.ekleSabitYazi(new rapor.sabitYazi(dgHizmetler.Rows[i].Cells["adi"].Value.ToString(), new Rectangle(5, y, 100, 4), false));
                    rpr.ekleSabitYazi(new rapor.sabitYazi(String.Format("{0:n2}", Convert.ToDouble(dgHizmetler.Rows[i].Cells["fiyat"].Value)), new Font("Arial", 8, FontStyle.Regular), new Point(50, y)));
                    y += 4;
                }
            }
            rpr.ekleSabitCizgi(new rapor.sabitCizgi(5, 70, y, y));
            y += 2;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Toplam: ", new Font("Arial", 8, FontStyle.Regular), new Point(5, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi(String.Format("{0:n2}", Convert.ToDouble(txtToplam.Text)), new Font("Arial", 8, FontStyle.Regular), new Point(50, y)));
            y += 4;
            rpr.ekleSabitCizgi(new rapor.sabitCizgi(5, 70, y, y));
            y += 2;
            rpr.ekleSabitYazi(new rapor.sabitYazi(firmaBilgileri.adi + " " + firmaBilgileri.soyadi + "  " + firmaBilgileri.webSitesi + "  " + subeBilgileri.tel + "  " + subeBilgileri.adres + "  " + subeBilgileri.altBilgiNotu, new Rectangle(5, y, 100, 7), false));
            y += 6;
            rpr.ekleSabitCizgi(new rapor.sabitCizgi(5, 70, y, y));
            y += 2;
            rpr.ekleSabitYazi(new rapor.sabitYazi(DateTime.Now.ToString() + "  www.elmaryazilim.com", new Point(5, y)));
            y += 5;
            rpr.ekleSabitYazi(new rapor.sabitYazi("", new Point(5, y)));
            return true;
        }

    }


}
