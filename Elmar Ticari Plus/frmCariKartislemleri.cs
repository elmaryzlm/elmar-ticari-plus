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
using System.IO;
namespace Elmar_Ticari_Plus
{
    public partial class frmCariKartislemleri : Form
    {
        public frmCariKartislemleri()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgAdresler);
            NesneGorselleri.dataGridView(dgEkstre);
            NesneGorselleri.dataGridView(dgFaturalar);
            NesneGorselleri.dataGridView(dgUrunler);
            NesneGorselleri.kontrolEkle(panel3);

            NesneGorselleri.kontrolEkle(panel6);
            NesneGorselleri.kontrolEkle(groupBox3);
            NesneGorselleri.kontrolEkle(groupBox5);
            NesneGorselleri.kontrolEkle(groupBox11);
            NesneGorselleri.kontrolEkle(groupBox6);
            NesneGorselleri.kontrolEkle(groupBox9);
            NesneGorselleri.kontrolEkle(groupBox8);

            try { cmbUUrunİsmi.Items.AddRange(listeler.getUrunisim()); }
            catch { }
            listeler.doldurSube(cmbUSubeler);
            listeler.doldurSube(cmbESubeler);
            listeler.doldurSube(cmbFSubeler);

            //cmbFiyatAdi.Items.Clear();
            //try { cmbFiyatAdi.Items.AddRange(listeler.getFiyatAdi()); }
            //catch { }
        }

        public void cariListesiniYenile()
        {
            try
            {
                cmbCariler.Items.Clear();
                cmbCariler.Items.AddRange(listeler.getCariAdi());
            }
            catch { }
            try
            {
                cmbFiyatAdi.Items.Clear();
                cmbFiyatAdi.Items.AddRange(listeler.getFiyatAdi());
            }
            catch { }
        }
        private void frmCariKartislemleri_Load(object sender, EventArgs e)
        {
            cariListesiniYenile();
            cmbCariler.Select();
            tabCari.SelectedTab = tabPage3;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public Int64 cariid = 0;
        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cariBilgileriniGetir();
        }
        void cariBilgileriniGetir()
        {
            temizle();
            try
            {
                cariid = listeler.getCariid()[cmbCariler.SelectedIndex];
            }
            catch
            {
                if (cmbCariler.Text.Trim().Length == 0 && cmbCariler.Text.Length < 12) return;
                var c = cariBilgileri.bul_RIFDNo(cmbCariler.Text);
                if (c == null) return;
                cmbCariler.Text = "";
                cariid = c.cariid;
            }
            var l = cariBilgileri.bul_cariid(cariid);
            txtCariKodu.Text = l.cariKodu;
            txtCariAdi.Text = l.adi;
            txtCariUnvani.Text = l.soyadi;
            string cariGrubuAdi = "", cariFiyatAdi = "";
            try
            {
                var cariGrubu = cariBilgileri.cariGruplari.listCariGruplari.Where(u => u.cariGrupid == l.grupid).First();
                cariGrubuAdi = cariGrubu.grupAdi;
            }
            catch { }

            try
            {
                var cariFiyati = cariBilgileri.listCariBilgileri.FirstOrDefault(u => u.cariid == l.cariid);
                cariFiyatAdi = Elmar_Ticari_Plus.stokkart.fiyatlar.listFiyatlar.FirstOrDefault(u => u.fiyatid == cariFiyati.fiyatid).fiyatAdi;
            }
            catch { }
            cmbCariGrubu.Text = cariGrubuAdi;
            cmbFiyatAdi.Text = cariFiyatAdi;
            txtCariLimiti.Text = l.limit.ToString();
            txtWebSitesi.Text = l.webSitesi;
            txtHatirlatmaGunu.Value = l.hatirlatmaGunu;
            cmbParaBirimi.Text = l.paraBirimi;
            txtVergiDairesi.Text = l.vergiDaire;
            txtVergiNo.Text = l.vergiNo;
            txtCariAciklamasi.Text = l.cariAciklamasi;
            txtRFIDNo.Text = l.rfidkartNo;
            //adresler getiriliyor
            adresListele();

            //if (tabCari.SelectedTab.Name == "tabPage1") btnESorgula.PerformClick();
            //else if (tabCari.SelectedTab.Name == "tabPage2") btnESorgula.PerformClick();
            if (tabCari.SelectedTab.Name == "tabPage2") btnGenelBakiyeYenile.PerformClick();
            else if (tabCari.SelectedTab.Name == "tabPage3") btnESorgula.PerformClick();
            else if (tabCari.SelectedTab.Name == "tabPage4") btnUSorgula.PerformClick();
            else if (tabCari.SelectedTab.Name == "tabPage5") btnSorgula3.PerformClick();

        }
        void adresListele()
        {
            dgAdresler.Rows.Clear();
            var adresListesi = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.cariid == cariid);
            foreach (var adresKaydi in adresListesi)
            {
                dgAdresler.Rows.Add(adresKaydi.adresid, adresKaydi.adresAdi, adresKaydi.boldeAdi, adresKaydi.adres, adresKaydi.postaKodu, adresKaydi.tel, adresKaydi.fax, adresKaydi.gsm, adresKaydi.email, adresKaydi.varsayilanmi, "Sil");
            }
        }
        void temizle()
        {
            //Cari Bilgileri Sekmesi Temizleniyor
            txtCariKodu.Clear();
            txtCariAdi.Clear();
            txtCariUnvani.Clear();
            cmbCariGrubu.Text = "";
            txtCariLimiti.Text = "0";
            txtWebSitesi.Clear();
            txtVergiDairesi.Clear();
            txtVergiNo.Clear();
            txtCariAciklamasi.Clear();
            //adresler temizleniyor
            adresTemizle();
            //Data Gridler Temizleniyor
            dgAdresler.Rows.Clear();
            dgEkstre.Rows.Clear();
            dgFaturalar.Rows.Clear();
            dgUrunler.Rows.Clear();
        }
        void adresTemizle()
        {
            txtBolge.Clear();
            txtBolge.Tag = "00";
            txtAdresAdi.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            txtGsm.Clear();
            txtFax.Clear();
            txtAdres.Clear();
            txtPostaKodu.Clear();
        }
        private void btnCariEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Ekle)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCariKartEkle frm = new frmCariKartEkle();
            frm._frmCariKartislemleri = this;
            frm.Show();
        }

        private void btnCariKartBilgileriniGuncelle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
            if (!cariKontroluYap()) return;
            frmCariKartEkle frm = new frmCariKartEkle();
            frm.cariid = cariid;
            frm.Show();
        }

        private void txtBolgeSec_Click(object sender, EventArgs e)
        {
            if (!cariKontroluYap()) return;
            frmBolgeSecimi frm = new frmBolgeSecimi();
            frm._frmCariKartislemleri = this;
            frm.Show();
        }

        private void btnESorgula_Click(object sender, EventArgs e)
        {
            if (!cariKontroluYap()) return;
            if (cmbCariler.SelectedIndex == -1) return;
            string sorgu = " ";
            string altSorgu = " ";
            //işlemturu-1 sorgusu yapılıyor
            if (chkEAcikHesap.Checked == false && chkECek.Checked == false && chkEKrediKarti.Checked == false && chkEPos.Checked == false && chkEPesin.Checked == false && chkESenet.Checked == false && chkETaksit.Checked == false) altSorgu = " and islemTuru like '%hiçbirinigetirme%' ";
            else if (chkEAcikHesap.Checked == true && chkECek.Checked == true && chkEPos.Checked == false && chkEKrediKarti.Checked == true && chkEPesin.Checked == true && chkESenet.Checked == true && chkETaksit.Checked == true) altSorgu = " ";
            else
            {
                if (chkEAcikHesap.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Açık Hesap%'";
                if (chkECek.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Çek%'";
                if (chkEKrediKarti.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Kredi Kartı%'";
                if (chkEPos.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Pos%'";
                if (chkEPesin.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Peşin%'";
                if (chkESenet.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Sened%'";
                if (chkETaksit.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Taksit%'";
                altSorgu = " and (" + altSorgu.Substring(4) + ") ";
            }
            sorgu = sorgu + altSorgu;

            //işlemturu-2 sorgusu yapılıyor
            altSorgu = " ";
            if (chkESatis.Checked == false && chkEAlis.Checked == false && chkESatisiade.Checked == false && chkETahsilat.Checked == false && chkEOdeme.Checked == false && chkEAlacak.Checked == false && chkEBorc.Checked == false && chkEHavale.Checked == false && chkEEFT.Checked == false) altSorgu = " and islemTuru like '%hiçbirinigetirme%' ";
            else if (chkESatis.Checked == true && chkEAlis.Checked == true && chkESatisiade.Checked == true && chkETahsilat.Checked == true && chkEOdeme.Checked == true && chkEAlacak.Checked == true && chkEBorc.Checked == true && chkEHavale.Checked == true && chkEEFT.Checked == true) altSorgu = " ";
            else
            {
                if (chkESatis.Checked == true) altSorgu = altSorgu + " or islemTuru2 = 'Satış'";
                if (chkEAlis.Checked == true) altSorgu = altSorgu + " or islemTuru2 = 'Alış'";
                if (chkESatisiade.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Satış İade%'";
                if (chkEAlisiade.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Alış İade%'";
                if (chkETahsilat.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Tahsilat%'";
                if (chkEOdeme.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Ödeme%'";
                if (chkEAlacak.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Alacak%'";
                if (chkEBorc.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Borç%'";
                if (chkEHavale.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%Havale%'";
                if (chkEEFT.Checked == true) altSorgu = altSorgu + " or islemTuru2 like '%EFT%'";
                altSorgu = " and (" + altSorgu.Substring(4) + ") ";
            }
            sorgu = sorgu + altSorgu;

            //diğer sorgu filtrelemeleri yapılıyor
            if (chkEKayitTarihi.Checked == true) sorgu = sorgu + " and (kayitTarihi between '" + dtEKayitTarihi1.Value + "' and '" + dtEKayitTarihi2.Value + "') ";
            if (chkEOdemeTarihi.Checked == true) sorgu = sorgu + " and (odemeTarihi between '" + dtEOdemeTarihi1.Value + "' and '" + dtEOdemeTarihi2.Value + "') ";
            if (chkEVadeTarihi.Checked == true) sorgu = sorgu + " and (vadeTarihi between '" + dtEVadeTarihi1.Value + "' and '" + dtEVadeTarihi2.Value + "') ";
            if (cmbESubeler.Text != "") sorgu = sorgu + " and subeid =" + ComboboxItem.getSelectedValue(cmbESubeler);
            if (cmbEKullanicilar.Text != "") sorgu = sorgu + " and kullaniciid =" + ComboboxItem.getSelectedValue(cmbEKullanicilar);

            double toplamBakiye = 0;
            dgEkstre.Rows.Clear();
            string sql = "SELECT [acikHesapid], [ticaretAyrintiid], [cekSenetid], [taksitid], [bankaislemid], [cariid], [kayitTarihi], [odemeTarihi], [vadeTarihi], [borc], [alacak], [dovizTuru], [dovizDegeri], [cezaTutari], abs([bakiye]) as toplam, (Select bakiye from sorAcikHesapEkstresi where acikHesapid = sorAcikHesap.acikHesapid) as bakiye, [islemTuru]+' '+ [islemTuru2] as islemTuru, [yeri], [aciklama], [faturaNo], [belgeNo], [irsaliyeNo], [vergiDaire], [vergiNo], [hesabaislendimi], [eklenmeTarihi], [subeid], [kullaniciid] FROM [sorAcikHesap] where cariid = " + cariid + " and firmaid = " + firma.firmaid + sorgu + "order by [acikHesapid] desc";
            SqlDataReader dr = veri.getDatareader(sql);
            while (dr.Read())
            {
                try
                {
                    dgEkstre.Rows.Add(dr["acikHesapid"].ToString(), dr["ticaretAyrintiid"].ToString(), dr["cekSenetid"].ToString(), dr["taksitid"].ToString(), dr["bankaislemid"].ToString(), dr["cariid"].ToString(), Convert.ToDateTime(dr["kayitTarihi"]), Convert.ToDateTime(dr["odemeTarihi"]), Convert.ToDateTime(dr["vadeTarihi"]), dr["borc"].ToString() + " " + dr["dovizTuru"].ToString(), dr["alacak"].ToString() + " " + dr["dovizTuru"].ToString(), dr["dovizTuru"].ToString(), dr["dovizDegeri"].ToString(), dr["cezaTutari"].ToString(), Convert.ToDouble(dr["toplam"]), Convert.ToDouble(dr["bakiye"]), dr["islemTuru"].ToString(), dr["yeri"].ToString(), dr["aciklama"].ToString(), dr["faturaNo"].ToString(), dr["belgeNo"].ToString(), dr["irsaliyeNo"].ToString(), dr["vergiDaire"].ToString(), dr["vergiNo"].ToString(), dr["hesabaislendimi"].ToString(), dr["eklenmeTarihi"].ToString(), dr["subeid"].ToString(), dr["kullaniciid"].ToString());

                    if (dr["vadeTarihi"].ToString().Contains("1900")) dgEkstre.Rows[dgEkstre.Rows.Count - 1].Cells["vadeTarihi"].Value = null;
                    if (dr["odemeTarihi"].ToString().Contains("1900")) dgEkstre.Rows[dgEkstre.Rows.Count - 1].Cells["odemeTarihi"].Value = null;
                    if (dr["hesabaislendimi"].ToString() == "1")
                    {
                        if (Convert.ToDouble(dr["borc"]) < Convert.ToDouble(dr["alacak"])) toplamBakiye = toplamBakiye + Convert.ToDouble(dr["toplam"]);
                        else toplamBakiye = toplamBakiye - Convert.ToDouble(dr["toplam"]);
                        dgEkstre.Rows[dgEkstre.Rows.Count - 1].Cells["hesabaislendimi"].Value = "Evet";
                    }
                    else dgEkstre.Rows[dgEkstre.Rows.Count - 1].Cells["hesabaislendimi"].Value = "Hayır";
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            for (int i = 0; i < dgEkstre.Rows.Count; i++)
            {
                if (Convert.ToDouble(dgEkstre.Rows[i].Cells["bakiye2"].Value) < 0) dgEkstre.Rows[i].Cells["bakiye2"].Value = String.Format("{0:n2}", Math.Abs(Convert.ToDouble(dgEkstre.Rows[i].Cells["bakiye2"].Value))) + " Alacak";
                else if (Convert.ToDouble(dgEkstre.Rows[i].Cells["bakiye2"].Value) > 0) dgEkstre.Rows[i].Cells["bakiye2"].Value = String.Format("{0:n2}", dgEkstre.Rows[i].Cells["bakiye2"].Value) + " Borç";
                else dgEkstre.Rows[i].Cells["bakiye2"].Value = "0,00";
            }
            string toplamDurum = "Alacaklısınız";
            if (toplamBakiye < 0) toplamDurum = "Borçlusunuz";
            toplamBakiye = Math.Abs(toplamBakiye);
            lblBakiyeE.Text = "   " + String.Format("{0:n2}", toplamBakiye) + " TL    ";
            lblBakiyeDurumuE.Text = toplamDurum;
            lblKayitSayisiE.Text = dgEkstre.Rows.Count.ToString();
        }
        string ticaretAyrintiidMetni_fatura = "";
        private void btnUSorgula_Click(object sender, EventArgs e)
        {
            if (!cariKontroluYap()) return;
            if (cmbCariler.SelectedIndex == -1) return;
            string sorgu = " ";
            string altSorgu = " ";
            if (chkUAlisİade.Checked == false && chkUFaturaliAlis.Checked == false && chkUFaturaliSatis.Checked == false && chkUFaturasizAlis.Checked == false && chkUFaturasizSatis.Checked == false && chkUSatisİade.Checked == false && chkUSiparis.Checked == false && chkUTeklif.Checked == false) altSorgu = " and islemTuru = 'hiçbirinigetirme' ";
            else if (chkUAlisİade.Checked == true && chkUFaturaliAlis.Checked == true && chkUFaturaliSatis.Checked == true && chkUFaturasizAlis.Checked == true && chkUFaturasizSatis.Checked == true && chkUSatisİade.Checked == true && chkUSiparis.Checked == true && chkUTeklif.Checked == true) altSorgu = " ";
            else
            {
                if (chkUAlisİade.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Alış İade%'";
                if (chkUFaturaliAlis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturalı Alış%'";
                if (chkUFaturaliSatis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturalı Satış%'";
                if (chkUFaturasizAlis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturasız Alış%'";
                if (chkUFaturasizSatis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturasız Satış%'";
                if (chkUSatisİade.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Satış İade%'";
                if (chkUSiparis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Sipariş%'";
                if (chkUTeklif.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Teklif%'";
                altSorgu = "  and (" + altSorgu.Substring(4) + ")";
            }
            sorgu = sorgu + altSorgu;
            if (chkUİslemTarihi.Checked == true) sorgu = sorgu + " and (islemTarihi between '" + dtUİslemTarihi1.Value + "' and '" + dtUİslemTarihi2.Value + "') ";
            if (cmbUSubeler.Text != "") sorgu = sorgu + " and subeid =" + ComboboxItem.getSelectedValue(cmbUSubeler);
            if (cmbUKullanicilar.Text != "") sorgu = sorgu + " and kullaniciid =" + ComboboxItem.getSelectedValue(cmbUKullanicilar);
            if (txtUBarkod.Text != "") sorgu = sorgu + " and barkod='" + txtUBarkod.Text + "'";
            else if (cmbUUrunİsmi.Text != "") sorgu = sorgu + " and urunAdi='" + cmbUUrunİsmi.Text + "'";
            else if (txtUStokKodu.Text != "") sorgu = sorgu + " and stokkodu='" + txtUStokKodu.Text + "'";
            else if (txtUSeriNo.Text != "") sorgu = sorgu + " and seriNo='" + txtUSeriNo.Text + "'";


            dgUrunler.Rows.Clear();
            double toplamMiktar = 0, toplamBakiye = 0;
            string sql = "SELECT [ticaretid],[ticaretAyrintiid],[stokid],[barkod],[urunAdi],abs([miktar]) miktar,[satilanMiktar],[birim],[katsayi],[birimFiyat],[kdv],[kdvTipi],[isk1],[isk2],[isk3],abs([AraTop]) AraTop,abs([KdvTop])KdvTop,abs([Toplam])Toplam,[dovizTuru],[dovizDegeri],[kargoUcreti],[seriNo],[eklenmeTarihi],[subeid],[kullaniciid], [islemTarihi],[islemSaati],[islemTuru],[hesabaislendimi], [onay] FROM sorTicaret where cariid=" + cariid + " and silindimi = '0' and firmaid = " + firma.firmaid + sorgu + ticaretAyrintiidMetni_fatura + " order by ticaretid desc";
            SqlDataReader dr = veri.getDatareader(sql);
            while (dr.Read())
            {
                try
                {
                    double carpan = 1;
                    if (dr["islemTuru"].ToString().Contains("İade")) carpan = -1;
                    dgUrunler.Rows.Add(dr["ticaretid"].ToString(), dr["ticaretAyrintiid"].ToString(), dr["stokid"].ToString(), dr["barkod"].ToString(), dr["urunAdi"].ToString(), dr["miktar"].ToString(), dr["satilanMiktar"].ToString(), dr["birim"].ToString(), dr["katsayi"].ToString(), String.Format("{0:n}", (Double)dr["birimFiyat"]), dr["kdv"].ToString(), dr["kdvTipi"].ToString(), dr["isk1"].ToString(), dr["isk2"].ToString(), dr["isk3"].ToString(), String.Format("{0:n}", (Double)dr["aratop"] * carpan) + " " + dr["dovizTuru"].ToString(), String.Format("{0:n}", (Double)dr["KdvTop"]) + " " + dr["dovizTuru"].ToString(), String.Format("{0:n}", (Double)dr["Toplam"] * carpan) + " " + dr["dovizTuru"].ToString(), dr["dovizTuru"].ToString(), dr["dovizDegeri"].ToString(), dr["kargoUcreti"].ToString(), dr["seriNo"].ToString(), dr["eklenmeTarihi"].ToString(), dr["subeid"].ToString(), dr["kullaniciid"].ToString(), Convert.ToDateTime(dr["islemTarihi"]), Convert.ToDateTime(dr["islemSaati"]), dr["islemTuru"].ToString());
                    toplamMiktar += (Convert.ToDouble(dr["miktar"]) * Convert.ToDouble(dr["katsayi"]));
                    toplamBakiye += (Convert.ToDouble(dr["Toplam"]) * Convert.ToDouble(dr["dovizDegeri"])) * carpan;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Test" + ex.Message);
                }

            }
            lblKayitSayisiU.Text = dgUrunler.Rows.Count.ToString();
            lblToplamMiktarU.Text = toplamMiktar.ToString();
            lblBakiyeU.Text = String.Format("{0:n}", toplamBakiye) + " TL";
            ticaretAyrintiidMetni_fatura = "";
        }

        private void btnSorgula3_Click(object sender, EventArgs e)
        {
            if (!cariKontroluYap()) return;
            if (cmbCariler.SelectedIndex == -1) return;
            string sorgu = " ";
            string altSorgu = " ";
            if (chkFAlisİade.Checked == false && chkFFaturaliAlis.Checked == false && chkFFaturaliSatis.Checked == false && chkFFaturasizAlis.Checked == false && chkFFaturasizSatis.Checked == false && chkFSatisİade.Checked == false && chkFSiparis.Checked == false && chkFTeklif.Checked == false) altSorgu = " and islemTuru = 'hiçbirinigetirme' ";
            else if (chkFAlisİade.Checked == true && chkFFaturaliAlis.Checked == true && chkFFaturaliSatis.Checked == true && chkFFaturasizAlis.Checked == true && chkFFaturasizSatis.Checked == true && chkFSatisİade.Checked == true && chkFSiparis.Checked == true && chkFTeklif.Checked == true) altSorgu = " ";
            else
            {
                if (chkFAlisİade.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Alış İade%'";
                if (chkFFaturaliAlis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturalı Alış%'";
                if (chkFFaturaliSatis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturalı Satış%'";
                if (chkFFaturasizAlis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturasız Alış%'";
                if (chkFFaturasizSatis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturasız Satış%'";
                if (chkFSatisİade.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Satış İade%'";
                if (chkFSiparis.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Sipariş%'";
                if (chkFTeklif.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Teklif%'";
                altSorgu = "  and (" + altSorgu.Substring(4) + ")";
            }
            sorgu = sorgu + altSorgu;
            if (chkFİslemTarihi.Checked == true) sorgu = sorgu + " and (islemTarihi between '" + dtFİslemTarihi1.Value + "' and '" + dtFİslemTarihi2.Value + "') ";
            if (cmbFSubeler.Text != "") sorgu = sorgu + " and subeid =" + ComboboxItem.getSelectedValue(cmbFSubeler);
            if (cmbFKullanicilar.Text != "") sorgu = sorgu + " and kullaniciid =" + ComboboxItem.getSelectedValue(cmbFKullanicilar);

            dgFaturalar.Rows.Clear();
            double toplamTutar = 0;
            string sql = "SELECT [ticaretAyrintiid],[cariid],[adiSoyadi],[odemeTuru],[islemTarihi],[islemSaati],[islemTuru],abs([AraTop]) AraTop,abs([KdvTop]) KdvTop,abs([iskonto]) iskonto, yuzdeisk, abs([nakliyat]) nakliyat,abs([iscilik]) iscilik,abs([GenelTop]) GenelTop,[fiiliSevkTarihi],[faturaNo],[belgeNo],[irsaliyeNo],[vergiDaire],[vergiNo],[adres],[faturaAciklamasi],[islemAciklamasi],[hesabaislendimi],[onay],[eklenmeTarihi],[subeid],[kullaniciid] FROM [sorTicaretAyrinti] where cariid=" + cariid + " and silindimi = '0' and firmaid = " + firma.firmaid + sorgu + "";
            SqlDataReader dr = veri.getDatareader(sql);
            while (dr.Read())
            {
                try
                {
                    double carpan = 1;
                    if (dr["islemTuru"].ToString().Contains("İade")) carpan = -1;
                    dgFaturalar.Rows.Add(dr["ticaretAyrintiid"].ToString(), dr["odemeTuru"].ToString(), Convert.ToDateTime(dr["islemTarihi"]), Convert.ToDateTime(dr["islemSaati"]), dr["islemTuru"].ToString(), String.Format("{0:n}", (Double)dr["AraTop"]), String.Format("{0:n}", (Double)dr["KdvTop"]), String.Format("{0:n}", (Double)dr["iskonto"]), String.Format("{0:n}", (Double)dr["yuzdeisk"]), String.Format("{0:n}", (Double)dr["nakliyat"]), String.Format("{0:n}", (Double)dr["iscilik"]), String.Format("{0:n}", (Double)dr["GenelTop"] * carpan), dr["fiiliSevkTarihi"].ToString().Substring(0, 10), dr["faturaNo"].ToString(), dr["belgeNo"].ToString(), dr["irsaliyeNo"].ToString(), dr["vergiDaire"].ToString(), dr["vergiNo"].ToString(), dr["adres"].ToString(), dr["faturaAciklamasi"].ToString(), dr["islemAciklamasi"].ToString(), dr["hesabaİslendimi"].ToString(), dr["onay"].ToString(), dr["eklenmeTarihi"].ToString(), dr["subeid"].ToString(), dr["kullaniciid"].ToString());
                    if (dr["hesabaislendimi"].ToString() == "1")
                    {
                        toplamTutar += Convert.ToDouble(dr["GenelTop"]) * carpan;
                        dgEkstre.Rows[dgEkstre.Rows.Count - 1].Cells["hesabaislendimi3"].Value = "Evet";
                    }
                    else dgEkstre.Rows[dgEkstre.Rows.Count - 1].Cells["hesabaislendimi3"].Value = "Hayır";
                }
                catch
                {
                }
            }
            lblKayitSayisiF.Text = dgFaturalar.Rows.Count.ToString();
            lblBakiyeF.Text = String.Format("{0:n}", toplamTutar);
        }

        private void btnSenetTanimla_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Çek_Senet_Ekleme_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriSenediEkle, cariid, cmbCariler.Text);
            frm.Show();
        }

        private void btnNakitTahsilat_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Nakit_Tahsilat_ve_Ödeme)
            {
                yetkiler.mesajVer();
                return;
            }
            frmOdemeVeTahsilat frm = new frmOdemeVeTahsilat(this.cariid, cmbCariler.Text);
            frm.Show();
        }

        private void kendiÇekimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.kendiCekimEkle, cariid, cmbCariler.Text);
            frm.Show();
        }

        private void müşteriÇekiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriCekiEkle, cariid, cmbCariler.Text);
            frm.Show();
        }

        private void kendiSenedimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.kendiSenedimEkle, cariid, cmbCariler.Text);
            frm.Show();
        }

        private void müşteriSenediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriSenediEkle, cariid, cmbCariler.Text);
            frm.Show();
        }

        private void işlemiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Seçili işlem kaydını silmek istediğinizden emin misiniz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    veri.cmd("Exec spSilAcikHesap " + dgEkstre.CurrentRow.Cells["acikHesapid"].Value + "," + firma.firmaid + "");
                    btnESorgula.PerformClick();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silme işleminde bir hata meydana geldi.\nHata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void işlemiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow rw = dgEkstre.CurrentRow;
                if (rw.Cells["islemTuru"].Value.ToString() == "Açık Hesap Alacak" || rw.Cells["islemTuru"].Value.ToString() == "Açık Hesap Borç")
                {
                    frmDevir frm = new frmDevir(Convert.ToInt64(rw.Cells["acikHesapid"].Value), Convert.ToInt64(rw.Cells["ticaretAyrintiid"].Value), cariid, cmbCariler.Text, rw.Cells["belgeNo"].Value.ToString(), Convert.ToDouble(rw.Cells["bakiye"].Value) / Convert.ToDouble(rw.Cells["dovizDegeri"].Value), rw.Cells["dovizTuru"].Value.ToString(), Convert.ToDouble(rw.Cells["dovizDegeri"].Value), rw.Cells["islemTuru"].Value.ToString(), Convert.ToDateTime(rw.Cells["kayitTarihi"].Value), Convert.ToDateTime(rw.Cells["vadeTarihi"].Value), rw.Cells["aciklama"].Value.ToString(), Convert.ToDouble(lblBakiyeE.Text.Replace(" TL", "")));
                    frm.Show();
                }
                else if (rw.Cells["islemTuru"].Value.ToString() == "Açık Hesap Tahsilat" || rw.Cells["islemTuru"].Value.ToString() == "Açık Hesap Ödeme" || rw.Cells["islemTuru"].Value.ToString() == "Açık Hesap Satış" || rw.Cells["islemTuru"].Value.ToString() == "Açık Hesap Alış")
                {
                    frmOdemeVeTahsilat frm = new frmOdemeVeTahsilat(Convert.ToInt64(rw.Cells["acikHesapid"].Value), Convert.ToInt64(rw.Cells["ticaretAyrintiid"].Value), cariid, cmbCariler.Text, rw.Cells["belgeNo"].Value.ToString(), Convert.ToDouble(rw.Cells["bakiye"].Value) / Convert.ToDouble(rw.Cells["dovizDegeri"].Value), rw.Cells["dovizTuru"].Value.ToString(), Convert.ToDouble(rw.Cells["dovizDegeri"].Value), rw.Cells["islemTuru"].Value.ToString(), Convert.ToDateTime(rw.Cells["kayitTarihi"].Value), rw.Cells["aciklama"].Value.ToString(), Convert.ToDouble(lblBakiyeE.Text.Replace(" TL", "")));
                    frm.Show();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnCariSec_Click(object sender, EventArgs e)
        {
            frmAyrintiliCariListele frm = new frmAyrintiliCariListele(this);
            frm.Show();
        }

        private void btnTaksitTanimla_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Taksit_Tanımla)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTaksitlendirme frm = new frmTaksitlendirme(cariid, cmbCariler.Text);
            frm.Show();
        }

        private void btnCekTanimla_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Çek_Senet_Ekleme_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriCekiEkle, cariid, cmbCariler.Text);
            frm.Show();
        }

        private void btnTaksitTahsilat_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Taksit_Tahsil_Et___Öde)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTaksitOde frm = new frmTaksitOde(cariid, cmbCariler.Text);
            frm.Show();
        }

        private void btnDevir_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Devir_İşlemi)
            {
                yetkiler.mesajVer();
                return;
            }
            frmDevir frm = new frmDevir(cariid, cmbCariler.Text, Convert.ToDouble(lblBakiyeE.Text.Replace(" TL", "")));
            frm.Show();
        }

        private void btnAdresKaydet_Click(object sender, EventArgs e)
        {
            //adres ekleniyor, güncelleniyor.
            if (!cariKontroluYap()) return;
            //if (adresid != 0) cariBilgileri.adresBilgileri.listAdresBilgileri.Remove(cariBilgileri.adresBilgileri.listAdresBilgileri.Where(u => u.adresid == adresid).First());
            string varsayilanAdresmi = "0";
            if (chkVarsayilanAdresmi.Checked == true) varsayilanAdresmi = "1";
            Int64 eklenenAdresid = Convert.ToInt64(veri.getdatacell("exec spAdresEkle 0, '" + cariid + "', '" + txtAdresAdi.Text + "', '" + txtCariAdi.Text + "', '" + txtCariUnvani.Text + "', '" + txtEmail.Text + "', '" + txtTel.Text + "', '" + txtGsm.Text + "', '" + txtFax.Text + "', '" + txtBolge.Tag.ToString() + "', '" + txtAdres.Text + "', '" + txtPostaKodu.Text + "', '', '" + txtVergiDairesi.Text + "', '" + txtVergiNo.Text + "', '', '" + varsayilanAdresmi + "', '" + firma.firmaid + "', '" + firma.subeid + "', '" + firma.kullaniciid + "'"));
            cariBilgileri.adresBilgileri.ekle(eklenenAdresid, cariid, txtCariAdi.Text + " " + txtCariUnvani.Text, txtAdresAdi.Text, txtCariAdi.Text, txtCariUnvani.Text, txtEmail.Text, txtTel.Text, txtGsm.Text, txtFax.Text, txtBolge.Tag.ToString(), "", txtAdres.Text, txtPostaKodu.Text, "", txtVergiDairesi.Text, txtVergiNo.Text, "", varsayilanAdresmi, DateTime.Now, firma.subeid, firma.kullaniciid);
            //listeler.yukleAdresler();
            adresListele();
            adresTemizle();
        }

        private void dgAdresler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgAdresler.Columns["sil"].Index && MessageBox.Show("Seçili adresi silmek istediğinizden emin misiniz ?", "Silinsin mi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                veri.cmd("update tblAdresBilgileri set silindimi = '1' where firmaid = " + firma.firmaid + " and adresid = " + dgAdresler.CurrentRow.Cells["adresid"].Value.ToString() + "");
                guncelle.cariBilgileriVerileriniGuncelle();
                listeler.yukleAdresler();
                dgAdresler.Rows.Remove(dgAdresler.CurrentRow);
            }
        }
        bool cariKontroluYap()
        {
            if (cariid == 0)
            {
                MessageBox.Show("Geçerli bir cari seçiniz.", firma.programAdi);
                cmbCariler.Select();
                return false;
            }
            else return true;
        }
        private void btnMailGonder_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Mail_Gönder)
            {
                yetkiler.mesajVer();
                return;
            }
            if (!cariKontroluYap()) return;
        }

        private void btnRFIDKartislemleri_Click(object sender, EventArgs e)
        {
            if (!yetkiler.RFID_Kart_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            if (!cariKontroluYap()) return;
            //var frm = new Form3();
            //frm.Show();

        }

        private void btnWebSitesiHesapislemleri_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Web_Sitesi_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            if (!cariKontroluYap()) return;

        }

        private void btnCariyiSil_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            if (!cariKontroluYap()) return;
            veri.cmd("Exec spSilCari " + firma.firmaid + ", " + cariid + "");
            MessageBox.Show("Cari Silindi.", firma.programAdi);
            guncelle.cariBilgileriVerileriniGuncelle();
            listeler.yukleCariadi();
            cariListesiniYenile();
            cmbCariler.Select();
        }

        private void btnCarininHesabiniDurdur_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Hesabını_Durdurma)
            {
                yetkiler.mesajVer();
                return;
            }
            if (!cariKontroluYap()) return;
            veri.cmd("Update tblCariBilgileri set hesabaislensinmi = 0 Where firmaid = " + firma.firmaid + " and cariid = " + cariid + "");
            MessageBox.Show("Cari Pasifleştirildi. Artık raporlara ve kasaya etki etmeyecektir.", firma.programAdi);
            guncelle.cariBilgileriVerileriniGuncelle();
            listeler.yukleCariadi();
            cariListesiniYenile();
        }

        rapor rpr;
        private void btnERaporOnizleme_Click(object sender, EventArgs e)
        {
            raporHazirla();
            rpr.onizleme();
        }
        void raporHazirla()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = 290;
            //rpr.sayfayiYatayYap();
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Hesap Ekstresi Raporu - " + cmbCariler.Text, new Font("Arial", 15, FontStyle.Bold), new Point(5, 5)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kayıt T.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 20, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ödeme T.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(25, 15, 20, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Vâde T.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(45, 15, 20, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Borç", new Font("Arial", 10, FontStyle.Underline), new Rectangle(65, 15, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Alacak", new Font("Arial", 10, FontStyle.Underline), new Rectangle(85, 15, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("   NET (TL)", new Font("Arial", 10, FontStyle.Underline), new Rectangle(105, 15, 20, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("   Bakiye (TL)", new Font("Arial", 10, FontStyle.Underline), new Rectangle(125, 15, 25, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Türü", new Font("Arial", 10, FontStyle.Underline), new Rectangle(150, 15, 35, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Açıklama", new Font("Arial", 10, FontStyle.Underline), new Rectangle(185, 15, 25, 4), false));
            double tahsilatT = 0, odemeT = 0, alisT = 0, satisT = 0, iadeT = 0, alacakT = 0, borcT = 0;
            for (int i = 0; i < dgEkstre.Rows.Count; i++)
            {
                DataGridViewRow r = dgEkstre.Rows[i];
                rpr.ekleYazi(new rapor.yazi(r.Cells["kayitTarihi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(5, 20 + i * 4, 19, 4), false));
                if (r.Cells["odemeTarihi"].Value != null) rpr.ekleYazi(new rapor.yazi(r.Cells["odemeTarihi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(25, 20 + i * 4, 19, 4), false));
                if (r.Cells["vadeTarihi"].Value != null) rpr.ekleYazi(new rapor.yazi(r.Cells["vadeTarihi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(45, 20 + i * 4, 19, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["borc"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(65, 20 + i * 4, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["alacak"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(85, 20 + i * 4, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["bakiye"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(105, 20 + i * 4, 19, 4), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(r.Cells["bakiye2"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(125, 20 + i * 4, 24, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["islemTuru"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(150, 20 + i * 4, 34, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["aciklama"].Value.ToString() + " " + r.Cells["belgeNo"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(185, 20 + i * 4, 24, 4), false));
                if (r.Cells["islemTuru"].Value.ToString().Contains("Alış")) alisT += Convert.ToDouble(r.Cells["borc"].Value.ToString().Replace(" TL", "").Replace(" USD", "").Replace(" EURO", ""));
                if (r.Cells["islemTuru"].Value.ToString().Contains("Satış")) satisT += Convert.ToDouble(r.Cells["alacak"].Value.ToString().Replace(" TL", "").Replace(" USD", "").Replace(" EURO", ""));
                if (r.Cells["islemTuru"].Value.ToString().Contains("Alış İade")) iadeT += Convert.ToDouble(r.Cells["borc"].Value.ToString().Replace(" TL", "").Replace(" USD", "").Replace(" EURO", ""));
                if (r.Cells["islemTuru"].Value.ToString().Contains("Satış İade")) iadeT -= Convert.ToDouble(r.Cells["borc"].Value.ToString().Replace(" TL", "").Replace(" USD", "").Replace(" EURO", ""));
                if (r.Cells["islemTuru"].Value.ToString().Contains("Tahsilat") || r.Cells["islemTuru"].Value.ToString().Contains("Peşin Satış")) tahsilatT += Convert.ToDouble(r.Cells["borc"].Value.ToString().Replace(" TL", "").Replace(" USD", "").Replace(" EURO", ""));
                if (r.Cells["islemTuru"].Value.ToString().Contains("Ödeme") || r.Cells["islemTuru"].Value.ToString().Contains("Peşin Alış")) odemeT += Convert.ToDouble(r.Cells["alacak"].Value.ToString().Replace(" TL", "").Replace(" USD", "").Replace(" EURO", ""));
                if (r.Cells["islemTuru"].Value.ToString().Contains("Alacak")) alacakT += Convert.ToDouble(r.Cells["alacak"].Value.ToString().Replace(" TL", "").Replace(" USD", "").Replace(" EURO", ""));
                if (r.Cells["islemTuru"].Value.ToString().Contains("Borç")) borcT += Convert.ToDouble(r.Cells["borc"].Value.ToString().Replace(" TL", "").Replace(" USD", "").Replace(" EURO", ""));


                //if (r.Cells["islemTuru"].Value.ToString().Contains("Alış")) alisT += Convert.ToDouble(r.Cells["bakiye"].Value);
                //else if (r.Cells["islemTuru"].Value.ToString().Contains("Satış")) satisT += Convert.ToDouble(r.Cells["bakiye"].Value);
                //else if (r.Cells["islemTuru"].Value.ToString().Contains("İade")) iadeT += Convert.ToDouble(r.Cells["bakiye"].Value);
                //else if (r.Cells["islemTuru"].Value.ToString().Contains("Tahsilat")) tahsilatT += Convert.ToDouble(r.Cells["bakiye"].Value);
                //else if (r.Cells["islemTuru"].Value.ToString().Contains("Ödeme")) odemeT += Convert.ToDouble(r.Cells["bakiye"].Value);
                //else if (r.Cells["islemTuru"].Value.ToString().Contains("Alacak")) alacakT += Convert.ToDouble(r.Cells["bakiye"].Value);
                //else if (r.Cells["islemTuru"].Value.ToString().Contains("Borç")) borcT += Convert.ToDouble(r.Cells["bakiye"].Value);
                //rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, 20 + i * 4, 20 + i * 4));
            }
            int yukseklik = 25 + dgEkstre.Rows.Count * 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik++;
            rpr.ekleYazi(new rapor.yazi("Toplam Alacak: " + string.Format("{0:n2}", alacakT) + " TL", new Point(5, yukseklik)));
            rpr.ekleYazi(new rapor.yazi("Toplam Borç: " + string.Format("{0:n2}", borcT) + " TL", new Point(55, yukseklik)));
            rpr.ekleYazi(new rapor.yazi("Toplam Tahsilat: " + string.Format("{0:n2}", tahsilatT) + " TL", new Point(110, yukseklik)));
            rpr.ekleYazi(new rapor.yazi("Toplam Ödeme: " + string.Format("{0:n2}", odemeT) + " TL", new Point(160, yukseklik)));
            yukseklik += 3;
            rpr.ekleYazi(new rapor.yazi("Toplam Satış: " + string.Format("{0:n2}", satisT) + " TL", new Point(5, yukseklik)));
            rpr.ekleYazi(new rapor.yazi("Toplam Alış: " + string.Format("{0:n2}", alisT) + " TL", new Point(55, yukseklik)));
            rpr.ekleYazi(new rapor.yazi("Toplam İade: " + string.Format("{0:n2}", iadeT) + " TL", new Point(110, yukseklik)));
            rpr.ekleYazi(new rapor.yazi("Genel Bakiye: " + string.Format("{0:n2}", Convert.ToDouble(lblBakiyeE.Text.Replace(" TL", ""))) + " TL", new Point(160, yukseklik)));
            yukseklik += 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik++;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + dgEkstre.Rows.Count.ToString() + "       Yazdırma Tarihi: " + DateTime.Now.ToString() + "       www.elmaryazilim.com", new Point(5, yukseklik)));

        }
        private void tabCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCariler.SelectedIndex > -1)
            {
                if (tabCari.SelectedTab.Name == "tabPage2") btnGenelBakiyeYenile.PerformClick();
                if (tabCari.SelectedTab.Name == "tabPage3" && dgEkstre.Rows.Count == 0) btnESorgula.PerformClick();
                if (tabCari.SelectedTab.Name == "tabPage4" && dgUrunler.Rows.Count == 0) btnUSorgula.PerformClick();
                if (tabCari.SelectedTab.Name == "tabPage5" && dgFaturalar.Rows.Count == 0) btnSorgula3.PerformClick();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Satış_Raporu_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
            if (dgFaturalar.CurrentRow.Cells["islemTuru3"].Value.ToString().Contains("Satış İade"))
            {
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.satisiadeDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value);
                frm.Show();
            }
            else if (dgFaturalar.CurrentRow.Cells["islemTuru3"].Value.ToString().Contains("Alış İade"))
            {
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.alisiadeDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value);
                frm.Show();
            }
            else if (dgFaturalar.CurrentRow.Cells["islemTuru3"].Value.ToString().Contains("Satış"))
            {
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.satisDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value);
                frm.Show();
            }
            else if (dgFaturalar.CurrentRow.Cells["islemTuru3"].Value.ToString().Contains("Alış"))
            {
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.stokDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value);
                frm.Show();
            }
            else if (dgFaturalar.CurrentRow.Cells["islemTuru3"].Value.ToString().Contains("Sipariş"))
            {
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.siparisDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value);
                frm.Show();
            }
            else if (dgFaturalar.CurrentRow.Cells["islemTuru3"].Value.ToString().Contains("Teklif"))
            {
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.teklifDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value);
                frm.Show();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Satış_Raporu_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            if (MessageBox.Show("Seçili kaydı silmek istiyor musunuz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                veri.cmd("Exec spSilTicaret " + firma.firmaid + "," + dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value + ", '1'");
                btnSorgula3.PerformClick();
            }
        }

        private void işlenenÜrünleriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ticaretAyrintiidMetni_fatura = " and ticaretAyrintiid = " + dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value + "";
                dgUrunler.Rows.Clear();
                tabCari.SelectedTab = tabCari.TabPages["tabPage4"];
            }
            catch (Exception)
            {
            }
        }

        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {
            raporHazirlaUrun();
            rpr.onizleme();
        }
        void raporHazirlaUrun()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = 205;
            rpr.sayfayiYatayYap();
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Ürün Raporları - " + txtCariAdi.Text, new Font("Arial", 15, FontStyle.Bold), new Point(5, 5)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Barkod", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 24, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ürün Adı", new Font("Arial", 10, FontStyle.Underline), new Rectangle(30, 15, 49, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Mik. x Birim F.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(80, 15, 34, 4), false));

            rpr.ekleSabitYazi(new rapor.sabitYazi("KDV%", new Font("Arial", 10, FontStyle.Underline), new Rectangle(115, 15, 16, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Isk1", new Font("Arial", 10, FontStyle.Underline), new Rectangle(132, 15, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Isk2", new Font("Arial", 10, FontStyle.Underline), new Rectangle(144, 15, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Isk3", new Font("Arial", 10, FontStyle.Underline), new Rectangle(156, 15, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("ARATOP", new Font("Arial", 9, FontStyle.Underline), new Rectangle(168, 15, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("KDVTOP", new Font("Arial", 9, FontStyle.Underline), new Rectangle(186, 15, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("TOPLAM", new Font("Arial", 9, FontStyle.Underline), new Rectangle(204, 15, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Doviz", new Font("Arial", 10, FontStyle.Underline), new Rectangle(222, 15, 19, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih", new Font("Arial", 10, FontStyle.Underline), new Rectangle(242, 15, 19, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Türü", new Font("Arial", 10, FontStyle.Underline), new Rectangle(262, 15, 30, 4), false));

            double toplamTutar = 0, toplamMiktar = 0;
            for (int i = 0; i < dgUrunler.Rows.Count; i++)
            {
                DataGridViewRow r = dgUrunler.Rows[i];
                rpr.ekleYazi(new rapor.yazi(r.Cells["barkod"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(5, 20 + i * 4, 24, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["urunAdi"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(30, 20 + i * 4, 49, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["miktar"].Value.ToString() + " " + r.Cells["birim"].Value.ToString() + " x " + r.Cells["birimFiyat"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(80, 20 + i * 4, 34, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["kdv2"].Value.ToString() + " " + r.Cells["kdvTipi2"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(115, 20 + i * 4, 16, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["isk1"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(132, 20 + i * 4, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["isk2"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(144, 20 + i * 4, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["isk3"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(156, 20 + i * 4, 11, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["AraTop"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(168, 20 + i * 4, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["KdvTop"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(186, 20 + i * 4, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["Toplam"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(204, 20 + i * 4, 17, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["dovizTuru2"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(222, 20 + i * 4, 19, 4), false));
                rpr.ekleYazi(new rapor.yazi(string.Format("{0:d}", Convert.ToDateTime(r.Cells["islemTarihi2"].Value)), new Font("Arial", 8, FontStyle.Regular), new Rectangle(242, 20 + i * 4, 19, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["islemTuru2"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(262, 20 + i * 4, 30, 4), false));
                toplamMiktar += (Convert.ToDouble(r.Cells["miktar"].Value) * Convert.ToDouble(r.Cells["katsayi"].Value));

                toplamTutar += (Convert.ToDouble(r.Cells["Toplam"].Value.ToString().Replace(" USD", "").Replace(" TL", "").Replace(" EURO", "").Replace(" $", "").Replace(" €", "")) * Convert.ToDouble(r.Cells["dovizDegeri2"].Value));
            }
            int yukseklik = 25 + dgUrunler.Rows.Count * 4;
            rpr.ekleCizgi(new rapor.cizgi(2, rpr._kagitGenisligi - 5, yukseklik, yukseklik));
            yukseklik += 1;
            rpr.ekleYazi(new rapor.yazi("Toplam Miktar: " + toplamMiktar.ToString() + "                   Toplam Tutar: " + string.Format("{0:n2}", toplamTutar) + " TL", new Point(2, yukseklik)));
            yukseklik += 4;
            rpr.ekleCizgi(new rapor.cizgi(2, rpr._kagitGenisligi - 5, yukseklik, yukseklik));
            yukseklik += 1;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + dgUrunler.Rows.Count.ToString() + "       Yazdırma Tarihi: " + DateTime.Now.ToString() + "       www.elmaryazilim.com", new Point(2, yukseklik)));
        }
        private void dgFaturalar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            işlenenÜrünleriGörüntüleToolStripMenuItem.PerformClick();
        }

        private void btnPosileTahsilat_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Pos_ile_Tahsilat)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaPosTaksitleriGoruntule frm = new frmBankaPosTaksitleriGoruntule(cariid, cmbCariler.Text);
            frm.Show();
        }

        private void btnGenelBakiyeYenile_Click(object sender, EventArgs e)
        {

            //textbox lar sıfırlanıyor
            txtBorcPesin.Text = "0,00";
            txtAlacakPesin.Text = "0,00";
            txtBakiyePesin.Text = "0,00";
            txtBorcAcikHesap.Text = "0,00";
            txtAlacakAcikHesap.Text = "0,00";
            txtBakiyeAcikHesap.Text = "0,00";
            txtBorcTaksit.Text = "0,00";
            txtAlacakTaksit.Text = "0,00";
            txtBakiyeTaksit.Text = "0,00";
            txtBorcCek.Text = "0,00";
            txtAlacakCek.Text = "0,00";
            txtBakiyeCek.Text = "0,00";
            //txtBorcSenet.Text = "0,00";
            //txtAlacakSenet.Text = "0,00";
            //txtBakiyeSenet.Text = "0,00";
            //txtBorcCekMusteri.Text = "0,00";
            //txtAlacakCekMusteri.Text = "0,00";
            //txtBakiyeCekMusteri.Text = "0,00";
            //txtBorcSenetMusteri.Text = "0,00";
            //txtAlacakSenetMusteri.Text = "0,00";
            //txtBakiyeSenetMusteri.Text = "0,00";
            txtBorcKrediKarti.Text = "0,00";
            txtAlacakKrediKarti.Text = "0,00";
            txtBakiyeKrediKarti.Text = "0,00";
            txtBorcPos.Text = "0,00";
            txtAlacakPos.Text = "0,00";
            txtBakiyePos.Text = "0,00";
            string sql = "Select borc,alacak, abs(bakiye) bakiye,islemTuru from sorCariBakiye Where cariid = " + cariid + " and firmaid = " + firma.firmaid;
            SqlDataReader dr = veri.getDatareader(sql);
            while (dr.Read())
            {
                if (dr["islemTuru"].ToString() == "Peşin")
                {
                    txtBorcPesin.Text = String.Format("{0:n2}", Convert.ToDouble(dr["borc"]));
                    txtAlacakPesin.Text = String.Format("{0:n2}", Convert.ToDouble(dr["alacak"]));
                    txtBakiyePesin.Text = String.Format("{0:n2}", Convert.ToDouble(dr["bakiye"]));
                }
                else if (dr["islemTuru"].ToString() == "Açık Hesap")
                {
                    txtBorcAcikHesap.Text = String.Format("{0:n2}", Convert.ToDouble(dr["borc"]));
                    txtAlacakAcikHesap.Text = String.Format("{0:n2}", Convert.ToDouble(dr["alacak"]));
                    txtBakiyeAcikHesap.Text = String.Format("{0:n2}", Convert.ToDouble(dr["bakiye"]));
                }
                else if (dr["islemTuru"].ToString() == "Taksit")
                {
                    txtBorcTaksit.Text = String.Format("{0:n2}", Convert.ToDouble(dr["borc"]));
                    txtAlacakTaksit.Text = String.Format("{0:n2}", Convert.ToDouble(dr["alacak"]));
                    txtBakiyeTaksit.Text = String.Format("{0:n2}", Convert.ToDouble(dr["bakiye"]));
                }
                else if (dr["islemTuru"].ToString().Contains("Çek") || dr["islemTuru"].ToString().Contains("Sene"))
                {
                    txtBorcCek.Text = String.Format("{0:n2}", Convert.ToDouble(txtBorcCek.Text) + Convert.ToDouble(dr["borc"]));
                    txtAlacakCek.Text = String.Format("{0:n2}", Convert.ToDouble(txtAlacakCek.Text) + Convert.ToDouble(dr["alacak"]));
                    txtBakiyeCek.Text = String.Format("{0:n2}", Convert.ToDouble(txtBakiyeCek.Text) + Convert.ToDouble(dr["bakiye"]));
                }
                //else if (dr["islemTuru"].ToString() == "Müşteri Çeki")
                //{
                //    txtBorcCekMusteri.Text = String.Format("{0:n2}", Convert.ToDouble(dr["borc"]));
                //    txtAlacakCekMusteri.Text = String.Format("{0:n2}",  Convert.ToDouble(dr["alacak"]));
                //    txtBakiyeCekMusteri.Text = String.Format("{0:n2}", Convert.ToDouble(dr["bakiye"]));
                //}
                //else if (dr["islemTuru"].ToString() == "Kendi Senedim")
                //{
                //    txtBorcSenet.Text = String.Format("{0:n2}", Convert.ToDouble(dr["borc"]));
                //    txtAlacakSenet.Text = String.Format("{0:n2}", Convert.ToDouble(dr["alacak"]));
                //    txtBakiyeSenet.Text = String.Format("{0:n2}", Convert.ToDouble(dr["bakiye"]));
                //}
                //else if (dr["islemTuru"].ToString() == "Müşteri Senedi")
                //{
                //    txtBorcSenetMusteri.Text = String.Format("{0:n2}",  Convert.ToDouble(dr["borc"]));
                //    txtAlacakSenetMusteri.Text = String.Format("{0:n2}", Convert.ToDouble(dr["alacak"]));
                //    txtBakiyeSenetMusteri.Text = String.Format("{0:n2}", Convert.ToDouble(dr["bakiye"]));
                //}
                else if (dr["islemTuru"].ToString() == "Kredi Kartı")
                {
                    txtBorcKrediKarti.Text = String.Format("{0:n2}", Convert.ToDouble(dr["borc"]));
                    txtAlacakKrediKarti.Text = String.Format("{0:n2}", Convert.ToDouble(dr["alacak"]));
                    txtBakiyeKrediKarti.Text = String.Format("{0:n2}", Convert.ToDouble(dr["bakiye"]));
                }
                else if (dr["islemTuru"].ToString() == "Postan")
                {
                    txtBorcPos.Text = String.Format("{0:n2}", Convert.ToDouble(dr["borc"]));
                    txtAlacakPos.Text = String.Format("{0:n2}", Convert.ToDouble(dr["alacak"]));
                    txtBakiyePos.Text = String.Format("{0:n2}", Convert.ToDouble(dr["bakiye"]));
                }
            }
        }

        private void txtBorcPesin_TextChanged(object sender, EventArgs e)
        {
            double borcToplam = Convert.ToDouble(txtBorcAcikHesap.Text) + Convert.ToDouble(txtBorcCek.Text) + Convert.ToDouble(txtBorcKrediKarti.Text) + Convert.ToDouble(txtBorcPesin.Text) + Convert.ToDouble(txtBorcPos.Text) + Convert.ToDouble(txtBorcTaksit.Text);
            txtBorcToplam.Text = String.Format("{0:n2}", borcToplam);
        }

        private void txtAlacakPesin_TextChanged(object sender, EventArgs e)
        {
            double alacakToplam = Convert.ToDouble(txtAlacakAcikHesap.Text) + Convert.ToDouble(txtAlacakCek.Text) + Convert.ToDouble(txtAlacakKrediKarti.Text) + Convert.ToDouble(txtAlacakPesin.Text) + Convert.ToDouble(txtAlacakPos.Text) + Convert.ToDouble(txtAlacakTaksit.Text);
            txtAlacakToplam.Text = String.Format("{0:n2}", alacakToplam);
        }

        private void txtBakiyePesin_TextChanged(object sender, EventArgs e)
        {
            double bakiyeToplam = Math.Abs(Convert.ToDouble(txtBorcToplam.Text) - Convert.ToDouble(txtAlacakToplam.Text));
            txtBakiyeToplam.Text = String.Format("{0:n2}", bakiyeToplam);
            if (Convert.ToDouble(txtAlacakPesin.Text) > Convert.ToDouble(txtBorcPesin.Text)) lblDurumPesin.Text = "Alacaklısınız";
            else if (Convert.ToDouble(txtAlacakPesin.Text) < Convert.ToDouble(txtBorcPesin.Text)) lblDurumPesin.Text = "Borçlusunuz";
            if (Convert.ToDouble(txtAlacakKrediKarti.Text) > Convert.ToDouble(txtBorcKrediKarti.Text)) lblDurumKrediKarti.Text = "Alacaklısınız";
            else if (Convert.ToDouble(txtAlacakKrediKarti.Text) < Convert.ToDouble(txtBorcKrediKarti.Text)) lblDurumKrediKarti.Text = "Borçlusunuz";
            if (Convert.ToDouble(txtAlacakPos.Text) > Convert.ToDouble(txtBorcPos.Text)) lblDurumPos.Text = "Alacaklısınız";
            else if (Convert.ToDouble(txtAlacakPos.Text) < Convert.ToDouble(txtBorcPos.Text)) lblDurumPos.Text = "Borçlusunuz";
            if (Convert.ToDouble(txtAlacakAcikHesap.Text) > Convert.ToDouble(txtBorcAcikHesap.Text)) lblDurumAcikHesap.Text = "Alacaklısınız";
            else if (Convert.ToDouble(txtAlacakAcikHesap.Text) < Convert.ToDouble(txtBorcAcikHesap.Text)) lblDurumAcikHesap.Text = "Borçlusunuz";
            if (Convert.ToDouble(txtAlacakTaksit.Text) > Convert.ToDouble(txtBorcTaksit.Text)) lblDurumTaksit.Text = "Alacaklısınız";
            else if (Convert.ToDouble(txtAlacakTaksit.Text) < Convert.ToDouble(txtBorcTaksit.Text)) lblDurumTaksit.Text = "Borçlusunuz";
            if (Convert.ToDouble(txtAlacakCek.Text) > Convert.ToDouble(txtBorcCek.Text)) lblDurumCek.Text = "Alacaklısınız";
            else if (Convert.ToDouble(txtAlacakCek.Text) < Convert.ToDouble(txtBorcCek.Text)) lblDurumCek.Text = "Borçlusunuz";
            //if (Convert.ToDouble(txtAlacakSenet.Text) > Convert.ToDouble(txtBorcSenet.Text)) lblDurumSenet.Text = "Alacaklısınız";
            //else if (Convert.ToDouble(txtAlacakSenet.Text) < Convert.ToDouble(txtBorcSenet.Text)) lblDurumSenet.Text = "Borçlusunuz";

            //if (Convert.ToDouble(txtAlacakCekMusteri.Text) > Convert.ToDouble(txtBorcCekMusteri.Text)) lblDurumCekMusteri.Text = "Alacaklısınız";
            //else if (Convert.ToDouble(txtAlacakCekMusteri.Text) < Convert.ToDouble(txtBorcCekMusteri.Text)) lblDurumCekMusteri.Text = "Borçlusunuz";
            //if (Convert.ToDouble(txtAlacakSenetMusteri.Text) > Convert.ToDouble(txtBorcSenetMusteri.Text)) lblDurumSenetMusteri.Text = "Alacaklısınız";
            //else if (Convert.ToDouble(txtAlacakSenetMusteri.Text) < Convert.ToDouble(txtBorcSenetMusteri.Text)) lblDurumSenetMusteri.Text = "Borçlusunuz";

            if (Convert.ToDouble(txtAlacakToplam.Text) > Convert.ToDouble(txtBorcToplam.Text)) lblDurumToplam.Text = "Alacaklısınız";
            else if (Convert.ToDouble(txtAlacakToplam.Text) < Convert.ToDouble(txtBorcToplam.Text)) lblDurumToplam.Text = "Borçlusunuz";
        }

        private void dgAdresler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSmsGonder_Click(object sender, EventArgs e)
        {
            frmMesajGonder frm = null;
            if (cariid > 0)
            {
                var q = cariBilgileri.adresBilgileri.listAdresBilgileri.FirstOrDefault(u => u.cariid == cariid);
                if (q == null) frm = new frmMesajGonder("");
                else frm = new frmMesajGonder(q.gsm.Length == 11 ? q.gsm.Substring(1) : "");
            }
            else frm = new frmMesajGonder("");
            frm.Show();
        }

        private void btnSMSGonderCariGrubu_Click(object sender, EventArgs e)
        {
            new frmMesajGonderGrup().Show();
        }

        private void btnKrediKartiTahsilat_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Kredi_Kartı_ile_Ödeme)
            {
                yetkiler.mesajVer();
                return;
            }
            frmBankaKrediKartiileOdeme frm = new frmBankaKrediKartiileOdeme(cariid, cmbCariler.Text);
            frm.Show();
        }

        private void btnSenetTahsilat_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Çek_Senet_Cirola)
            {
                yetkiler.mesajVer();
                return;
            }
            frmCekSenetileTahsilatveOdeme frm = new frmCekSenetileTahsilatveOdeme(cariid, cmbCariler.Text, "Ciro");
            frm.Show();
        }

        private void btnVirman_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Virman_İşlemi)
            {
                yetkiler.mesajVer();
                return;
            }
        }

        private void tahsilatYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNakitTahsilat.PerformClick();
        }

        private void krediKartıTahsilatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnKrediKartiTahsilat.PerformClick();
        }

        private void taksitGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTaksitTanimla.PerformClick();
        }

        private void cmbESubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar, ComboboxItem.getSelectedValue(cmbESubeler));
        }

        private void cmbUSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbUKullanicilar, ComboboxItem.getSelectedValue(cmbUSubeler));
        }

        private void cmbFSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbFKullanicilar, ComboboxItem.getSelectedValue(cmbFSubeler));
        }

        private void taksitTahsilEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTaksitTahsilat.PerformClick();
        }

        private void devirİşlemiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDevir.PerformClick();
        }

        private void posİleTahsilatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPosileTahsilat.PerformClick();
        }

        private void btnEYazdir_Click(object sender, EventArgs e)
        {
            raporHazirla();
            rpr.yazdir();
        }

        private void hesabaİşlenmesiOlarakAyarlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("Exec [spAktiflestirTicaret]  " + firma.firmaid + ", " + dgFaturalar.CurrentRow.Cells["ticaretAyrintiid3"].Value + ", '0'");
        }

        private void işlemiAktafleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("Update tblAcikHesap set hesabaislendimi = '1' where firmaid = " + firma.firmaid + " and acikHesapid = " + dgEkstre.CurrentRow.Cells["acikHesapid"].Value + "");
            btnESorgula.PerformClick();
        }

        private void işlemiPasifleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("Update tblAcikHesap set hesabaislendimi = '0' where firmaid = " + firma.firmaid + " and acikHesapid = " + dgEkstre.CurrentRow.Cells["acikHesapid"].Value + "");
            btnESorgula.PerformClick();
        }

        private void btnCariyiAktifYap_Click(object sender, EventArgs e)
        {
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            raporHazirlaUrun();
            rpr.yazdir();
        }

        private void btnRaporGoruntule3_Click(object sender, EventArgs e)
        {
            raporHazirlaFatura();
            rpr.onizleme();
        }
        void raporHazirlaFatura()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = 205;
            rpr.sayfayiYatayYap();
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Alış, Satış, Fatura, İade, Teklif, Sipariş Raporu - " + cmbCariler.Text, new Font("Arial", 15, FontStyle.Bold), new Point(5, 5)));

            rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih-Saat", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 30, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Türü", new Font("Arial", 10, FontStyle.Underline), new Rectangle(35, 15, 30, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ödeme Türü", new Font("Arial", 10, FontStyle.Underline), new Rectangle(65, 15, 29, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Fat.No", new Font("Arial", 10, FontStyle.Underline), new Rectangle(95, 15, 16, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Bel.No", new Font("Arial", 10, FontStyle.Underline), new Rectangle(111, 15, 16, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İrs.No", new Font("Arial", 10, FontStyle.Underline), new Rectangle(129, 15, 15, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("AraTop", new Font("Arial", 10, FontStyle.Underline), new Rectangle(145, 15, 25, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("KDVTOP", new Font("Arial", 10, FontStyle.Underline), new Rectangle(170, 15, 25, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İSK", new Font("Arial", 10, FontStyle.Underline), new Rectangle(195, 15, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("NAK", new Font("Arial", 10, FontStyle.Underline), new Rectangle(215, 15, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İŞÇ", new Font("Arial", 10, FontStyle.Underline), new Rectangle(235, 15, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Genel Top.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(255, 15, 30, 4), StringFormatFlags.DirectionRightToLeft, false));
            for (int i = 0; i < dgFaturalar.Rows.Count; i++)
            {
                DataGridViewRow r = dgFaturalar.Rows[i];
                rpr.ekleYazi(new rapor.yazi(string.Format("{0:d}", Convert.ToDateTime(r.Cells["islemTarihi"].Value)) + " " + string.Format("{0:t}", Convert.ToDateTime(r.Cells["saat"].Value)), new Font("Arial", 8, FontStyle.Regular), new Rectangle(5, 20 + i * 4, 30, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["islemTuru3"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(35, 20 + i * 4, 30, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["odemeTuru"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(65, 20 + i * 4, 29, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["faturaNo3"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(95, 20 + i * 4, 16, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["belgeNo3"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(112, 20 + i * 4, 16, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["irsaliyeNo3"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(129, 20 + i * 4, 16, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["araTop3"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(145, 20 + i * 4, 25, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["kdvTop3"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(170, 20 + i * 4, 25, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["iskonto"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(195, 20 + i * 4, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["nakliyat"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(215, 20 + i * 4, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["iscilik"].Value.ToString(), new Font("Arial", 8, FontStyle.Regular), new Rectangle(235, 20 + i * 4, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["GenelToplam"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(255, 20 + i * 4, 30, 4), StringFormatFlags.DirectionRightToLeft, false));
                //rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, 20 + i * 4, 20 + i * 4));
            }
            int yukseklik = 25 + dgFaturalar.Rows.Count * 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik += 3;
            rpr.ekleYazi(new rapor.yazi("Genel Toplam: " + lblBakiyeF.Text + "         Kayıt Sayısı: " + dgFaturalar.Rows.Count.ToString() + "       Yazdırma Tarihi: " + DateTime.Now.ToString() + "       www.elmaryazilim.com", new Point(5, yukseklik)));

        }

        private void btnYazdir3_Click(object sender, EventArgs e)
        {
            raporHazirlaFatura();
            rpr.yazdir();
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void çekTahsilEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Çek_Senet_Ekleme_İşlemleri)
            {
                yetkiler.mesajVer();
                return;
            }
            DataGridViewRow r = dgEkstre.CurrentRow;
            veri.cmd("Exec spCekSenetTahsilEtOde '" + r.Cells["cekSenetid"].Value.ToString() + "', '" + r.Cells["islemTuru"].Value.ToString() + "', '" + DateTime.Now + "', " + firma.firmaid + "");
            btnESorgula.PerformClick();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExportExcell_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgUrunler, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void txtRFIDNo_TextChanged(object sender, EventArgs e)
        {
            var c = cariBilgileri.bul_RIFDNo(txtRFIDNo.Text);
            if (c != null)
            {
                cmbCariler.SelectedText = c.adiSoyadi;
                txtCariLimiti.Text = c.limit.ToString();
                txtGosterge_CariBakiyesi.Text = c.bakiye.ToString();
                //
                // cmbCariler_SelectedIndexChanged(null, null);
            }
        }

        private void cmbCariler_TextChanged(object sender, EventArgs e)
        {
            cariBilgileriniGetir();
        }
    }
}