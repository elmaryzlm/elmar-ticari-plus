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
    public partial class FrmTopluSms : Form
    {
        private Thread _thread;
        private bool aktifMi = false;
        public FrmTopluSms()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            NesneGorselleri.dataGridView(dataGridView1);
            SetGrid();
            bakiyeGetir();
            cariListele("");
            listeleriYukle();
        }
        private void SetGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

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

        void cariListele(string query)
        {
            dataGridView1.Rows.Clear();
            SqlDataReader dr = veri.getDatareader(@"SELECT distinct tblCariBilgileri.cariid,tblCariBilgileri.adi,dbo.tblCariBilgileri.soyadi,dbo.tblAdresBilgileri.gsm,tblCariGruplari.grupAdi
                                                   FROM dbo.tblCariBilgileri INNER JOIN
                                                   dbo.tblAdresBilgileri ON dbo.tblCariBilgileri.cariid = dbo.tblAdresBilgileri.cariid 
			                                       LEFT JOIN tblCariGruplari ON tblCariBilgileri.grupid=tblCariGruplari.cariGrupid WHERE tblCariBilgileri.firmaid =" + firma.firmaid + "  and tblCariBilgileri.Silindimi=0 and tblAdresBilgileri.gsm like '%5%' " + query);
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["cariid"].ToString(), dr["adi"].ToString(), dr["soyadi"].ToString(), dr["grupAdi"].ToString(), dr["gsm"].ToString());
            }


        }

        void basla()
        {
            while (aktifMi)
            {
                Thread.Sleep(2000);
                _thread = new Thread(Gonder);
                _thread.Start();

            }
            aktifMi = false;
            _thread.Abort(0);
        }

        void Gonder()
        {

        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            int smsAdet = bakiyeGetir();
            if (smsAdet == 0)
            {
                MessageBox.Show("SMS Bakiyeniz Yoktur!");
                return;
            }

            aktifMi = true;
            _thread = new Thread(new ThreadStart(bekleVeIslemiTekrarla));
            _thread.Start();

        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = listeler.getCariGrupid()[cmbCariGrubu.SelectedIndex];
            }
            catch (Exception)
            {

                id = 0;
            }

            if (id > 0)
                cariListele(" and (tblCariGruplari.cariGrupid=" + id + " and tblCariBilgileri.adi like '%" + textBox1.Text + "%')");
            else cariListele(" and (tblCariBilgileri.adi like '%" + textBox1.Text + "%')");
        }
        private void bekleVeIslemiTekrarla()
        {
            Thread.Sleep(3000);//3 saniyede 1 kontrol et
            while (aktifMi)
            {
                string numbers = "";
                string value = "";
                int a = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool isCheck = Convert.ToBoolean(dataGridView1.Rows[i].Cells["sec"].Value);
                    if (isCheck)
                    {
                        string phone = "0" + dataGridView1.Rows[i].Cells["gsm"].Value.ToString();
                        string cari = dataGridView1.Rows[i].Cells["adi"].Value.ToString();
                        phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                        if (isCheck)
                        {
                            if (phone.Length != 11)
                            {
                                MessageBox.Show(cari + " İsimli Carinin Telefon Numarası Düzgün Bir Formatta Giriniz!");
                                return;
                            }
                        }
                        phone = "0" + dataGridView1.Rows[i].Cells["gsm"].Value.ToString();
                        phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                        numbers = "<no>" + phone + "</no>";

                        string mesaj = txtMesaj.Text;
                        value = Utility.SendSMS(numbers, mesaj);

                        if (value != "20" && value != "30" && value != "40" && value != "70")
                        {
                            veri.cmd("update tblFirmaBilgileri set smsAdet=smsAdet-" + 1 + " where firmaid=" + firma.firmaid);
                            a++;
                            label5.Text = "Gönderilen SMS Sayısı:" + a.ToString();
                            Int64 cariid = Convert.ToInt64(dataGridView1.Rows[i].Cells["cariid"].Value);
                            veri.cmd("insert into tblMesajlar (mesajMetni,Baslik,cariid,firmaid,subeid,kullaniciid)values('" + mesaj + "','" + firma.firmaAdi + "'," + cariid + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")");
                        }
                    }
                }
                if (value != "20" && value != "30" && value != "40" && value != "70")
                    MessageBox.Show("İşlem Başarılı!\n" + a.ToString() + " Adet SMS Gönderildi");
                else MessageBox.Show("Gönderilemedi!\n" + a.ToString() + " Adet SMS Gönderildi");
                aktifMi = false;
            }
            _thread.Abort();
        }

    }
}

