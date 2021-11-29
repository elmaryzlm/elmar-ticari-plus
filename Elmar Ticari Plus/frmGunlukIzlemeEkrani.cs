using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmGunlukIzlemeEkrani : Form
    {
        DateTime dt1, dt2;
        static Thread t1;
        public static bool programCalisiyormu = true;

        public frmGunlukIzlemeEkrani()
        {

            InitializeComponent();
            NesneGorselleri.dataGridView(dataGridView1);
            NesneGorselleri.form(this, true);
            dtp1.Value = DateTime.Now.AddDays(-2);
            dtp2.Value = DateTime.Now.AddDays(3);
            SorguyuGetir();
            SetGrid();
            bakiyeGetir();
            baslangic();
        }

        public void baslangic()
        {
            t1 = new Thread(new ThreadStart(bekleVeIslemiTekrarla));
            t1.Start();
        }

        public void bekleVeIslemiTekrarla()
        {
            while (programCalisiyormu)
            {
                Thread.Sleep(59000);
                if (SmsYetkileri.Cari_Borc_Hatırlatma) Gonder();
            }

        }

        //public static void kontrolEt()
        //{

        //    Thread kanal = new Thread(new ThreadStart(Gonder));
        //    kanal.Start();
        //}
        private void SetGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["sec"].Value = true;
            }
        }

        private void btnAllUnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["sec"].Value = false;
            }
        }

        private void chbTarihAraligi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTarihAraligi.Checked == true)
            {
                dtp2.Enabled = true;
                dtp1.Enabled = true;
                chbVadesiGecenler.Checked = chbTaksidiGecenler.Checked = false;
            }
        }

        private void chbVadesiGecenler_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVadesiGecenler.Checked == true)
            {
                VadesiGecenler();
            }
            else
            {
                dtp2.Enabled = true;
                dtp1.Enabled = true;
                chbTarihAraligi.Checked = true;
            }
        }

        private void chbTaksidiGecenler_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTaksidiGecenler.Checked == true)
            {
                dataGridView1.Rows.Clear();
                chbTarihAraligi.Checked = chbVadesiGecenler.Checked = false;
                dtp1.Enabled = dtp2.Enabled = false;
                TaksidiGecenler();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dt1 = dtp1.Value;
            dt2 = dtp2.Value;
            SorguyuGetir();

        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            Gonder2();
        }

        void Toplamlar()
        {
            double tutar = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tutar += Convert.ToDouble(dataGridView1.Rows[i].Cells["Alacak"].Value);
            }
            lblToplamKayitSayisi.Text = dataGridView1.Rows.Count.ToString();
            lblToplamAlacak.Text = tutar.ToString() + " TL";

        }

        void Gonder()
        {
            try
            {
                int a, b, c = 0;
                DataTable dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%borç%' and FirmaID=" + firma.firmaid);
                string mesaj = dtMesaj.Rows[0]["Mesaj"].ToString();
                string mesajSaati = Convert.ToString(dtMesaj.Rows[0]["mesajSaati"]);
                DateTime mesajSaati1 = Convert.ToDateTime(mesajSaati);
                DateTime mesajAralik = mesajSaati1.AddMinutes(1);
                DateTime dt = DateTime.Now;
                a = mesajSaati1.Hour * 3600 + mesajSaati1.Minute * 60 +mesajSaati1.Second;
                b = mesajAralik.Hour * 3600 + mesajAralik.Minute * 60 + mesajAralik.Second;
                c = dt.Hour * 3600 + dt.Minute * 60 +dt.Second;
                if (a < c)
                {
                    if (b > c)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++) dataGridView1.Rows[i].Cells["sec"].Value = true;
                        int smsAdet = bakiyeGetir();
                        if (smsAdet == 0)
                        {
                            MessageBox.Show("SMS Bakiyeniz Yoktur!");
                            return;
                        }
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            bool isCheck = Convert.ToBoolean(dataGridView1.Rows[i].Cells["sec"].Value);
                            string phone = "0" + dataGridView1.Rows[i].Cells["gsm"].Value.ToString();
                            string cari = dataGridView1.Rows[i].Cells["adi"].Value.ToString();
                            phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                            if (isCheck)
                            {
                                if (phone.Length != 11)
                                {
                                    MessageBox.Show(cari + " İsimli Carinin Telefon Nosunu Düzgün Bir Şekilde Girin!");
                                    return;
                                }
                            }
                        }
                        string numbers = "";
                        int messageCount = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            bool isCheck = Convert.ToBoolean(dataGridView1.Rows[i].Cells["sec"].Value);
                            string phone = "0" + dataGridView1.Rows[i].Cells["gsm"].Value.ToString();
                            phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                            if (isCheck)
                            {
                                numbers += "<no>" + phone + "</no>";
                                messageCount++;
                            }
                        }
                        if (messageCount > smsAdet)
                        {
                            MessageBox.Show("Yeteri Kadar Mesaj Hakkınız Yok. Paket Alınız.");
                            return;
                        }
                        //  string value =SMSPaketi.SendSmsCoklu("ELMAR YZLM", mesaj, tel);
                        string value = Utility.SendSMS(numbers, mesaj);
                        if (value != "20" && value != "30" && value != "40" && value != "70")
                        {
                            veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-" + messageCount + " where firmaid=" + firma.firmaid);
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                Int64 cariid = Convert.ToInt64(dataGridView1.Rows[i].Cells["cariid"].Value);
                                veri.cmd("insert into tblMesajlar (mesajMetni,Baslik,cariid,firmaid,subeid,kullaniciid)values('" + mesaj + "','" + firma.firmaAdi + "'," + cariid + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                            }
                        }
                        else MessageBox.Show("Gönderilemedi!");
                    }
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }

        private int bakiyeGetir()
        {
            try
            {

                int bakiye = Convert.ToInt32(veri.getdatacell("Select smsAdet from tblFirmaBilgileri Where firmaid = " + firma.firmaid + " and silindimi = '0'"));
                lblBakiye.Text = bakiye.ToString() + " Adet";
                return bakiye;
            }
            catch
            {
                return 0;
            }
        }

        void Renkleendir()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DateTime tarih = Convert.ToDateTime(dataGridView1.Rows[i].Cells["vadeTarihi"].Value.ToString());
                long simdiki = long.Parse(DateTime.Now.ToString("yyyyMMdd"));
                long tarih1 = long.Parse(tarih.ToString("yyyyMMdd"));
                if (tarih1 == simdiki) { dataGridView1.Rows[i].Cells["Durum"].Value = "Ödemesi bu gün olanlar"; dataGridView1.Rows[i].Cells["Durum"].Style.BackColor = Color.Green; }
                else if (tarih1 < simdiki) { dataGridView1.Rows[i].Cells["Durum"].Value = "Ödemesi Geçenler"; dataGridView1.Rows[i].Cells["Durum"].Style.BackColor = Color.DarkRed; }
                else if (tarih1 > simdiki) dataGridView1.Rows[i].Cells["Durum"].Value = "Ödemesi Yaklaşanlar";
            }
        }

        void SorguyuGetir()
        {
            dataGridView1.Rows.Clear();
            DataTable dtSorgu = veri.getdatatable(@"SELECT tblCariBilgileri.cariid,tblCariBilgileri.adi,dbo.tblCariBilgileri.soyadi,tblAcikHesap.islemTuru,
             dbo.tblAcikHesap.vadeTarihi,(sum(tblAcikHesap.alacak-tblAciKHesap.borc))As Alacak, dbo.tblAdresBilgileri.gsm                  
             FROM dbo.tblAcikHesap INNER JOIN
             dbo.tblCariBilgileri ON dbo.tblAcikHesap.cariid = dbo.tblCariBilgileri.cariid
             INNER JOIN dbo.tblAdresBilgileri ON dbo.tblCariBilgileri.cariid = dbo.tblAdresBilgileri.cariid
             WHERE (tblAcikHesap.firmaid =" + firma.firmaid + ")  and tblAcikHesap.vadeTarihi between '" + dt1 + "' and '" + dt2 + "'and islemTuru !='Taksit' group by dbo.tblAcikHesap.vadeTarihi,tblCariBilgileri.cariid,dbo.tblCariBilgileri.adi, dbo.tblCariBilgileri.soyadi,tblAcikHesap.islemTuru,tblAdresBilgileri.gsm");

            for (int i = 0; i < dtSorgu.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(dtSorgu.Rows[i]["cariid"].ToString(), dtSorgu.Rows[i]["adi"].ToString(), dtSorgu.Rows[i]["soyadi"].ToString(), dtSorgu.Rows[i]["islemTuru"].ToString(), dtSorgu.Rows[i]["vadeTarihi"].ToString(), dtSorgu.Rows[i]["Alacak"].ToString(), dtSorgu.Rows[i]["gsm"].ToString());

            }
            SqlDataReader dr = veri.getDatareader(@"SELECT  dbo.tblCariBilgileri.cariid,dbo.tblCariBilgileri.adi, dbo.tblCariBilgileri.soyadi, 
                dbo.tblTaksit.odemeBilgisi, dbo.tblTaksit.vadeTarihi, dbo.tblTaksit.tutari, 
                dbo.tblAdresBilgileri.gsm
                FROM dbo.tblAdresBilgileri INNER JOIN
                dbo.tblCariBilgileri ON dbo.tblAdresBilgileri.cariid = dbo.tblCariBilgileri.cariid INNER JOIN
                dbo.tblTaksit ON dbo.tblCariBilgileri.cariid = dbo.tblTaksit.cariid
                WHERE (dbo.tblCariBilgileri.firmaid =" + firma.firmaid + ") and tblTaksit.vadeTarihi between '" + dt1 + "' and '" + dt2 + "' ");
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["cariid"].ToString(), dr["adi"].ToString(), dr["soyadi"].ToString(), dr["odemeBilgisi"].ToString(), dr["vadeTarihi"].ToString(), dr["tutari"].ToString(), dr["gsm"].ToString());
            }
            Renkleendir();
            Toplamlar();
        }

        void TaksidiGecenler()
        {
            SqlDataReader dr = veri.getDatareader(@"SELECT  dbo.tblCariBilgileri.cariid,dbo.tblCariBilgileri.adi, dbo.tblCariBilgileri.soyadi, 
                dbo.tblTaksit.odemeBilgisi, dbo.tblTaksit.vadeTarihi, dbo.tblTaksit.tutari, 
                dbo.tblAdresBilgileri.gsm
                FROM dbo.tblAdresBilgileri INNER JOIN
                dbo.tblCariBilgileri ON dbo.tblAdresBilgileri.cariid = dbo.tblCariBilgileri.cariid INNER JOIN
                dbo.tblTaksit ON dbo.tblCariBilgileri.cariid = dbo.tblTaksit.cariid
                WHERE (dbo.tblCariBilgileri.firmaid =" + firma.firmaid + ") and tblTaksit.vadeTarihi between '" + dt1 + "' and '" + dt2 + "' ");
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["cariid"].ToString(), dr["adi"].ToString(), dr["soyadi"].ToString(), dr["odemeBilgisi"].ToString(), dr["vadeTarihi"].ToString(), dr["tutari"].ToString(), dr["gsm"].ToString());
            }
            Renkleendir();
            Toplamlar();
        }

        void VadesiGecenler()
        {
            dataGridView1.Rows.Clear();
            dtp2.Enabled = false;
            dtp1.Enabled = false;
            chbTarihAraligi.Checked = false;
            SqlDataReader dr = veri.getDatareader(@"SELECT tblCariBilgileri.cariid,tblCariBilgileri.adi,dbo.tblCariBilgileri.soyadi,tblAcikHesap.islemTuru,
             dbo.tblAcikHesap.vadeTarihi,(sum(tblAcikHesap.alacak-tblAciKHesap.borc))As Alacak, dbo.tblAdresBilgileri.gsm                  
             FROM dbo.tblAcikHesap INNER JOIN
             dbo.tblCariBilgileri ON dbo.tblAcikHesap.cariid = dbo.tblCariBilgileri.cariid
             INNER JOIN dbo.tblAdresBilgileri ON dbo.tblCariBilgileri.cariid = dbo.tblAdresBilgileri.cariid
             WHERE (tblAcikHesap.firmaid =" + firma.firmaid + ")  and tblAcikHesap.vadeTarihi<'" + dt1 + "' and islemTuru !='Taksit' group by dbo.tblAcikHesap.vadeTarihi,dbo.tblCariBilgileri.cariid,dbo.tblCariBilgileri.adi, dbo.tblCariBilgileri.soyadi,tblAcikHesap.islemTuru,tblAdresBilgileri.gsm");
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["cariid"].ToString(), dr["adi"].ToString(), dr["soyadi"].ToString(), dr["islemTuru"].ToString(), dr["vadeTarihi"].ToString(), dr["Alacak"].ToString(), dr["gsm"].ToString());
            }
            Renkleendir();
            Toplamlar();
        }

        void Gonder2()
        {
            DateTime dt = DateTime.Now;
            DataTable dtMesaj = veri.getdatatable("select Adi,Mesaj,mesajSaati from tblHazirMesaj  where  Adi like '%borç%' and FirmaID=" + firma.firmaid);
            string mesaj = dtMesaj.Rows[0]["Mesaj"].ToString();
            int smsAdet = bakiyeGetir();
            if (smsAdet == 0)
            {
                MessageBox.Show("SMS Bakiyeniz Yoktur!");
                return;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool isCheck = Convert.ToBoolean(dataGridView1.Rows[i].Cells["sec"].Value);
                string phone = "0" + dataGridView1.Rows[i].Cells["gsm"].Value.ToString();
                string cari = dataGridView1.Rows[i].Cells["adi"].Value.ToString();
                phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                if (isCheck)
                {
                    if (phone.Length != 11)
                    {
                        MessageBox.Show(cari + " İsimli Carinin Telefon Nosunu Düzgün Bir Şekilde Girin!");
                        return;
                    }
                }
            }
            string numbers = "";
            int messageCount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool isCheck = Convert.ToBoolean(dataGridView1.Rows[i].Cells["sec"].Value);
                string phone = "0" + dataGridView1.Rows[i].Cells["gsm"].Value.ToString();
                phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                if (isCheck)
                {
                    numbers += "<no>" + phone + "</no>";
                    messageCount++;
                }
            }
            if (messageCount > smsAdet)
            {
                MessageBox.Show("Yeteri Kadar Mesaj Hakkınız Yok. Paket Alınız.");
                return;
            }
            //  string value =SMSPaketi.SendSmsCoklu("ELMAR YZLM", mesaj, tel);
            string value = Utility.SendSMS(numbers, mesaj);
            if (value != "20" && value != "30" && value != "40" && value != "70")
            {
                veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-" + messageCount + " where firmaid=" + firma.firmaid);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool isCheck = Convert.ToBoolean(dataGridView1.Rows[i].Cells["sec"].Value);
                    if (isCheck)
                    {
                        Int64 cariid = Convert.ToInt64(dataGridView1.Rows[i].Cells["cariid"].Value);
                        veri.cmd("insert into tblMesajlar (mesajMetni,Baslik,cariid,firmaid,subeid,kullaniciid)values('" + mesaj + "','" + firma.firmaAdi + "'," + cariid + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                    }
                }
                MessageBox.Show("SMS Gönderildi.");
                Close();
            }
            else MessageBox.Show("Gönderilemedi!");
        }
    }
}
