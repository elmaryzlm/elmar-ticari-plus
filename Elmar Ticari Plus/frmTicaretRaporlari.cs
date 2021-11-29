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
using System.Reflection;
using CurrentEDMConnectorClientLibrary;
using CurrentEDMConnectorClientLibrary.Entities;
using System.IO;

namespace Elmar_Ticari_Plus
{
    public partial class frmTicaretRaporlari : Form
    {
        //Alış                
        //Satış        
        //Teklif        
        //Sipariş
        //Transfer
        public enum formTipi
        {
            satis, alis, siparisTeklif, transferi, stokCikis
        }

        string formTipiAdi = "";
        string form_sorgu = " ";
        private SEFatura tester;
        public frmTicaretRaporlari(formTipi formTipi)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgTicaretRapor);
            NesneGorselleri.kontrolEkle(grpBelgeNumarası);
            NesneGorselleri.kontrolEkle(groupBox9);
            listeler.doldurSube(cmbSubeler);
            if (formTipi == frmTicaretRaporlari.formTipi.alis || formTipi == frmTicaretRaporlari.formTipi.transferi)
            {
                this.Text = "Alış, Alış İade, Alış Faturası, Stok Transfer Raporları";
                formTipiAdi = "Alış, Stok Transfer";
                form_sorgu = " and (islemTuru like '%Alış%' or islemTuru like '%Çıkış%' or islemTuru like '%Transfer%' ) ";
                grpİslemTipi.Height = 83;
                chkStokTransferi.Visible = true;
            }
            else if (formTipi == frmTicaretRaporlari.formTipi.satis)
            {
                this.Text = "Satış, Satış İade, Satış Faturası Raporları";
                formTipiAdi = "Satış";
                form_sorgu = " and islemTuru like '%Satış%' ";
                chkKrediKarti.Text = "Pos";
            }
            else if (formTipi == frmTicaretRaporlari.formTipi.siparisTeklif)
            {
                this.Text = "Teklif - Sipariş Raporları";
                formTipiAdi = "Sipariş, Teklif";
                form_sorgu = " and (islemTuru like '%Sipariş%' or islemTuru like '%Teklif%') ";
                chkHesabaİslenmeyenKayitlariGoster.Checked = true;
                chkHesabaİslenmeyenKayitlariGoster.Enabled = false;
                cmbIslemTipi.SelectedIndex = 1;
                cmbIslemTipi.Visible = lblYapilacakIslem.Visible = true;
                tabControl1.Enabled = false;
                dgTicaretRapor.Columns["faturaNo"].Visible = false;
                dgTicaretRapor.Columns["irsaliyeNo"].Visible = false;
                dgTicaretRapor.Columns["faturaAciklamasi"].Visible = false;

            }
            else if (formTipi == frmTicaretRaporlari.formTipi.stokCikis)
            {
                this.Text = "Stok Çıkış Raporları";
                formTipiAdi = "Stok Çıkış";
                form_sorgu = " and islemTuru like '%Satış%' ";
            }
        }

        private void frmTicaretRaporlari_Load(object sender, EventArgs e)
        {

            chkİslemTarihi.Checked = true;
            btnSorgula.PerformClick();
        }
        private string getEnvironmentName(string value)
        {
            string environment = string.Empty;
            switch (value)
            {
                case "TEST":
                    environment = "TEST";
                    break;
                default:
                    environment = "ORTAM YOK";
                    break;
            }
            return environment;
        }
        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            dgTicaretRapor.ContextMenuStrip = cnsStokkart;
            string sorgu = " ";
            string altSorgu = " ";
            if (txtFaturaNo.Text != "") sorgu = " and faturaNo = '" + txtFaturaNo.Text + "' ";
            else if (txtİrsaliyeNo.Text != "") sorgu = " and irsaliyeNo = '" + txtİrsaliyeNo.Text + "' ";
            else if (txtBelgeNo.Text != "") sorgu = " and belgeNo = '" + txtBelgeNo.Text + "' ";
            else
            {
                //Ödeme Türü Sorguları Oluşturuluyor----------------------
                if (chkAcikHesap.Checked == false && chkCek.Checked == false && chkKrediKarti.Checked == false && chkPesin.Checked == false && chkSenet.Checked == false && chkTaksit.Checked == false) altSorgu = " and odemeTuru = '' ";
                else if (chkAcikHesap.Checked == true && chkCek.Checked == true && chkKrediKarti.Checked == true && chkPesin.Checked == true && chkSenet.Checked == true && chkTaksit.Checked == true) altSorgu = " ";
                else
                {
                    if (chkAcikHesap.Checked == true) altSorgu = altSorgu + " or odemeTuru like '%Açık Hesap%'";
                    if (chkCek.Checked == true) altSorgu = altSorgu + " or odemeTuru like '%Çek%'";
                    if (chkKrediKarti.Checked == true) altSorgu = altSorgu + " or odemeTuru like '%" + chkKrediKarti.Text + "%'";
                    if (chkPesin.Checked == true) altSorgu = altSorgu + " or odemeTuru like '%Peşin%'";
                    if (chkSenet.Checked == true) altSorgu = altSorgu + " or odemeTuru like '%Senet%'";
                    if (chkTaksit.Checked == true) altSorgu = altSorgu + " or odemeTuru like '%Taksit%'";
                    if (chkStokTransferi.Checked == true) altSorgu = altSorgu + " or odemeTuru = ''";
                    altSorgu = "  and (" + altSorgu.Substring(4) + ")";
                }
                sorgu = sorgu + altSorgu;

                //İşlem Türü Sorguları Oluşturuluyor----------------------
                altSorgu = " ";
                if (chkDigerİslemler.Checked == false && chkİadeİslemleri.Checked == false && chkFaturaliİslemler.Checked == false && (chkStokTransferi.Checked == false || chkStokTransferi.Visible == false) && chbKesilenFaturalar.Checked == false) altSorgu = " and islemTuru = 'hiçbirinigetirme' ";
                else if (chkDigerİslemler.Checked == true && chkİadeİslemleri.Checked == true && chkFaturaliİslemler.Checked == true && chkStokTransferi.Checked == true) altSorgu = " ";
                else
                {
                    if (chkDigerİslemler.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturasız%' or islemTuru like '%Teklif%' or islemTuru like '%Sipariş%' or islemTuru like '%Çıkış%'";
                    if (chkStokTransferi.Checked == true && chkStokTransferi.Visible) altSorgu = altSorgu + " or islemTuru like '%Transfer%'";
                    if (chkİadeİslemleri.Checked == true) altSorgu = altSorgu + " or islemTuru like '%İade%'";
                    if (chkFaturaliİslemler.Checked == true) altSorgu = altSorgu + " or islemTuru like '%Faturalı%'";
                    if (chbKesilenFaturalar.Checked == true) altSorgu = altSorgu + " or faturaNo!=''";
                    if (altSorgu.Length > 4) altSorgu = "  and (" + altSorgu.Substring(4) + ")";
                }
                sorgu = sorgu + altSorgu;

                //diğer filtreler uygulanıyor
                if (chkİslemTarihi.Checked == true) sorgu = sorgu + " and (islemTarihi between '" + dtİslemTarihi1.Value + "' and '" + dtİslemTarihi2.Value + "') ";
                if (cmbSubeler.Text != "") sorgu = sorgu + " and subeid =" + ComboboxItem.getSelectedValue(cmbSubeler);
                if (cmbKullanicilar.Text != "") sorgu = sorgu + " and kullaniciid =" + ComboboxItem.getSelectedValue(cmbKullanicilar);
                if (chkSilinenKayitlariGoster.Checked == true) sorgu = sorgu + " and silindimi='1' ";
                if (chkSilinenKayitlariGoster.Checked == false) sorgu = sorgu + " and silindimi='0' ";
                if (chkWebKayitlariniGoster.Checked == true) sorgu = sorgu + " and ortam like '%Web%' ";
                if (chkWebKayitlariniGoster.Checked == false) sorgu = sorgu + " and ortam not like '%Web%' ";
                if (chkHesabaİslenmeyenKayitlariGoster.Checked == true) sorgu = sorgu + " and hesabaislendimi='0' ";
                if (chkHesabaİslenmeyenKayitlariGoster.Checked == false) sorgu = sorgu + " and hesabaislendimi='1' ";
                if (chbEFatura.Checked == true) sorgu = sorgu + " and eFaturaMi='1' ";

                //if (chkStokTransferi.Checked && formTipiAdi == "Alış, Stok Transfer") form_sorgu = " and (islemTuru like '%Alış%' or islemTuru like '%Çıkış%' or islemTuru like '%Transfer%' ) ";
                //else if(formTipiAdi == "Alış, Stok Transfer") form_sorgu = " and (islemTuru like '%Alış%' or islemTuru like '%Çıkış%') ";
                sorgu = sorgu + form_sorgu;
            }
            double toplamTutar = 0, toplamISK = 0;
            dgTicaretRapor.Rows.Clear();
            string sql = "SELECT [ticaretAyrintiid],[cariid],[adiSoyadi],[odemeTuru],[islemTarihi],[islemSaati],[islemTuru],abs([AraTop])+yuzdeisk AraTop,abs([KdvTop]) KdvTop,abs([iskonto]) iskonto, yuzdeisk,abs([nakliyat]) nakliyat,abs([iscilik]) iscilik,abs([GenelTop]) GenelTop,[fiiliSevkTarihi],[faturaNo],[belgeNo],[irsaliyeNo],[vergiDaire],[vergiNo],[adres],[faturaAciklamasi],[islemAciklamasi],[hesabaislendimi],[onay],[eklenmeTarihi],[subeid],[kullaniciid] FROM [sorTicaretAyrinti2] where firmaid = " + firma.firmaid + sorgu + " order by ticaretAyrintiid desc";
            if (chbIptalEdilenFaturalar.Checked)
            {
                sql = @"SELECT t.[ticaretAyrintiid],[cariid],[adiSoyadi],[odemeTuru],[islemTarihi],[islemSaati],[islemTuru],abs([AraTop])+yuzdeisk AraTop,abs([KdvTop]) KdvTop,abs([iskonto]) iskonto, yuzdeisk,abs([nakliyat]) nakliyat,abs([iscilik]) iscilik,abs([GenelTop]) GenelTop,[fiiliSevkTarihi],t.[faturaNo],t.[belgeNo],[irsaliyeNo],[vergiDaire],[vergiNo],[adres],[faturaAciklamasi],[islemAciklamasi],[hesabaislendimi],[onay],[eklenmeTarihi],t.[subeid],t.[kullaniciid] FROM [sorTicaretAyrinti2]
                        inner join tblIptalEdilenFaturalar as t on sorTicaretAyrinti2.ticaretAyrintiid=t.ticaretAyrintiid where t.firmaid = " + firma.firmaid + " order by ticaretAyrintiid desc";
                dgTicaretRapor.ContextMenuStrip = null;
            }
            SqlDataReader dr = veri.getDatareader(sql);
            if (EFatura.KullaniciAdi.Length > 0 && chbEFatura.Checked)
            {
                tester = new SEFatura(EFatura.KullaniciAdi, EFatura.Sifre, EFatura.UrlAdresi);
                tester.Current_Login();
            }

            while (dr.Read())
            {
                string durumu = "";
                if (chbEFatura.Checked && EFatura.EFaturaID > 0)
                {
                    string faturaNo = dr["faturaNo"].ToString().Trim();
                    if (faturaNo.Length == 16)
                    {
                        List<FormParameters> getFormParameters = tester.Current_GetInvoiceStatus(faturaNo);

                        if (getFormParameters != null)
                        {
                            if (FormValues.invoiceStatusElements != null)
                            {
                                try
                                {
                                    durumu = FormValues.invoiceStatusElements[1].ToString();
                                }
                                catch
                                {
                                }
                                if (durumu.Equals("RECEIVE - WAIT_SYSTEM_RESPONSE"))
                                    durumu = "SİSTEM ONAYI BEKLİYOR";
                                else if (durumu.Equals("RECEIVE - SUCCEED"))
                                    durumu = "KABUL EDİLDİ";
                                else if (durumu.Equals("RECEIVE - WAIT_APPLICATION_RESPONSE"))
                                    durumu = "KABUL / RED";
                                else if (durumu.Equals("ACCEPT - SUCCEED"))
                                    durumu = "KABUL EDİLDİ";
                                else if (durumu.Equals("SEND - FAILED"))
                                    durumu = "HATALI FATURA";
                                else if (durumu.Equals("SEND - WAIT_SYSTEM_RESPONSE"))
                                    durumu = "GÖNDERİM İŞLEMİ DEVAM EDİYOR";
                                else if (durumu.Equals("SEND - WAIT_GIB_RESPONSE"))
                                    durumu = "GÖNDERİM İŞLEMİ DEVAM EDİYOR";
                                else if (durumu.Equals("SEND - FAILED"))
                                    durumu = "HATALI BİLGİ İÇERİYOR";
                                else if (durumu.Equals("SEND - SUCCEED"))
                                    durumu = "FATURA ALICIYA ULAŞTI";
                                else if (durumu.Equals("SEND - WAIT_APPLICATION_RESPONSE"))
                                    durumu = "ALICIDAN YANIT BEKLENİYOR";
                                else if (durumu.Equals("CANCELLED - SUCCEED"))
                                    durumu = "FATURA İPTAL EDİLDİ";
                                else if (durumu.Equals("ACCEPTED - SUCCEED"))
                                    durumu = "FATURA KABUL EDİLDİ";
                            }
                        }
                    }
                }
                dgTicaretRapor.Rows.Add(dr["ticaretAyrintiid"].ToString(), durumu, dr["cariid"].ToString(), dr["adiSoyadi"].ToString(), dr["odemeTuru"].ToString(), dr["islemTarihi"].ToString().Substring(0, 10) + " " + dr["islemSaati"].ToString(), dr["islemTuru"].ToString(), dr["AraTop"].ToString(), dr["KdvTop"].ToString(), dr["iskonto"].ToString(), Convert.ToDouble(dr["yuzdeisk"]), dr["nakliyat"].ToString(), dr["iscilik"].ToString(), dr["GenelTop"].ToString(), dr["fiiliSevkTarihi"].ToString().Substring(0, 10), dr["faturaNo"].ToString(), dr["belgeNo"].ToString(), dr["irsaliyeNo"].ToString(), dr["vergiDaire"].ToString(), dr["vergiNo"].ToString(), dr["adres"].ToString(), dr["faturaAciklamasi"].ToString(), dr["islemAciklamasi"].ToString(), dr["hesabaİslendimi"].ToString(), dr["onay"].ToString(), dr["eklenmeTarihi"].ToString(), dr["subeid"].ToString(), dr["kullaniciid"].ToString());

            }
            for (int i = 0; i < dgTicaretRapor.RowCount; i++)
            {
                string durumu = (dgTicaretRapor.Rows[i].Cells["Durumu"].Value.ToString());
                if (durumu.Equals("KABUL EDİLDİ") || durumu.Equals("FATURA ALICIYA ULAŞTI")) dgTicaretRapor.Rows[i].Cells["Durumu"].Style.BackColor = Color.Lime;
                else if (durumu.Contains("HATA") || durumu.Contains("İPTAL") || durumu.Contains("RED")) dgTicaretRapor.Rows[i].Cells["Durumu"].Style.BackColor = Color.Red;
                else dgTicaretRapor.Rows[i].Cells["Durumu"].Style.BackColor = Color.AliceBlue;
            }
            double araTop, kdvTop, genelToplam, dovizDegeri, topYuzdeIsk;
            double rowAraTop, rowKdvTop, rowDovizDegeri, rowBirimF, rowMiktar, rowKatSayi, rowIsk1, rowIsk2, rowIsk3, rowCarpimlar, rowToplam;
            string strRowAraTop, strRowKdvTop, strRowDovizDegeri, strRowBirimF, strRowMiktar, strRowKatSayi, strRowIsk1, strRowIsk2, strRowIsk3, strRowCarpimlar, strRowToplam;
            for (int i = 0; i < dgTicaretRapor.Rows.Count; i++)
            {
                araTop = kdvTop = genelToplam = dovizDegeri = topYuzdeIsk = 0;
                int ticaretAyrintiID = Convert.ToInt32(dgTicaretRapor.Rows[i].Cells["ticaretAyrintiid"].Value);
                sql = "select aratop, kdvtop, toplam, dovizdegeri,birimfiyat,miktar,katsayi,isk1, isk2, isk3 from sorticaret where ticaretAyrintiid=" + ticaretAyrintiID + " and silindiMi=0";
                DataTable dt = veri.getdatatable(sql);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    rowAraTop = rowKdvTop = rowDovizDegeri = rowBirimF = rowMiktar = rowKatSayi = rowIsk1 = rowIsk2 = rowIsk3 = rowCarpimlar = rowToplam = 0;

                    strRowDovizDegeri = dt.Rows[j]["dovizDegeri"].ToString();
                    if (!string.IsNullOrEmpty(strRowDovizDegeri)) rowDovizDegeri = Convert.ToDouble(strRowDovizDegeri);

                    strRowAraTop = dt.Rows[j]["araTop"].ToString();
                    if (!string.IsNullOrEmpty(strRowAraTop)) rowAraTop = Convert.ToDouble(strRowAraTop);
                    if (rowAraTop < 0) { rowAraTop = rowAraTop * (-1); }
                    strRowKdvTop = dt.Rows[j]["kdvTop"].ToString();
                    if (!string.IsNullOrEmpty(strRowKdvTop)) rowKdvTop = Convert.ToDouble(strRowKdvTop);
                    if (rowKdvTop < 0) { rowKdvTop = rowKdvTop * (-1); }
                    strRowBirimF = dt.Rows[j]["birimfiyat"].ToString();
                    if (!string.IsNullOrEmpty(strRowBirimF)) rowBirimF = Convert.ToDouble(strRowBirimF);
                    if (rowBirimF < 0) { rowBirimF = rowBirimF * (-1); }
                    strRowMiktar = dt.Rows[j]["miktar"].ToString();
                    if (!string.IsNullOrEmpty(strRowMiktar)) rowMiktar = Convert.ToDouble(strRowMiktar);
                    if (rowMiktar < 0) { rowMiktar = rowMiktar * (-1); }
                    strRowKatSayi = dt.Rows[j]["katsayi"].ToString();
                    if (!string.IsNullOrEmpty(strRowKatSayi)) rowKatSayi = Convert.ToDouble(strRowKatSayi);
                    if (rowKatSayi < 0) { rowKatSayi = rowKatSayi * (-1); }
                    strRowIsk1 = dt.Rows[j]["isk1"].ToString();
                    if (!string.IsNullOrEmpty(strRowIsk1)) rowIsk1 = Convert.ToDouble(strRowIsk1);

                    strRowIsk2 = dt.Rows[j]["isk2"].ToString();
                    if (!string.IsNullOrEmpty(strRowIsk2)) rowIsk2 = Convert.ToDouble(strRowIsk2);

                    strRowIsk3 = dt.Rows[j]["isk3"].ToString();
                    if (!string.IsNullOrEmpty(strRowIsk3)) rowIsk3 = Convert.ToDouble(strRowIsk3);

                    strRowToplam = dt.Rows[j]["toplam"].ToString();
                    if (!string.IsNullOrEmpty(strRowToplam)) rowToplam = Convert.ToDouble(strRowToplam);
                    if (dgTicaretRapor.Rows[i].Cells["islemTuru"].Equals("Satış İade"))
                    {

                    }
                    else rowToplam = rowToplam * (-1);

                    araTop += rowAraTop * rowDovizDegeri;
                    kdvTop += rowKdvTop * rowDovizDegeri;
                    rowCarpimlar = rowBirimF * rowMiktar * rowKatSayi * rowIsk1 * rowDovizDegeri;
                    topYuzdeIsk += (rowCarpimlar / 100 + rowCarpimlar * rowIsk2 / 100 + rowCarpimlar * rowIsk2 * rowIsk3 / 100);

                    genelToplam += rowToplam;
                }
                //    if (genelToplam < 0)
                //   {
                //       genelToplam = genelToplam * (-1);
                //    }
                double isk, nak, isc;
                isk = nak = isc = 0;

                string strIsk, strNak, strIsc;

                strIsk = dgTicaretRapor.Rows[i].Cells["iskonto"].Value.ToString();
                strNak = dgTicaretRapor.Rows[i].Cells["nakliyat"].Value.ToString();
                strIsc = dgTicaretRapor.Rows[i].Cells["iscilik"].Value.ToString();

                if (!string.IsNullOrEmpty(strIsk)) isk = Convert.ToDouble(strIsk);
                if (!string.IsNullOrEmpty(strIsk)) nak = Convert.ToDouble(strNak);
                if (!string.IsNullOrEmpty(strIsk)) isc = Convert.ToDouble(strIsc);


                dgTicaretRapor.Rows[i].Cells["araTop"].Value = (araTop + topYuzdeIsk).ToString();
                dgTicaretRapor.Rows[i].Cells["kdvTop"].Value = kdvTop.ToString();
                dgTicaretRapor.Rows[i].Cells["yuzdeisk"].Value = topYuzdeIsk.ToString();
                genelToplam += isk * (-1) + nak + isc;
                dgTicaretRapor.Rows[i].Cells["GenelToplam"].Value = genelToplam.ToString();
                toplamTutar += Convert.ToDouble(genelToplam);
                toplamISK += isk;
            }

            //toplamTutar += Convert.ToDouble(dr["GenelTop"]);
            //toplamISK += Convert.ToDouble(dr["iskonto"]) + Convert.ToDouble(dr["yuzdeisk"]);
            lblKayitSayisiF.Text = dgTicaretRapor.Rows.Count.ToString();
            lblToplamIskonto.Text = String.Format("{0:n}", toplamISK);
            lblBakiyeF.Text = String.Format("{0:n}", toplamTutar);
        }

        private void verGetir()
        {

        }
        rapor rpr;
        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {
            raporHazirla();
            rpr.onizleme();
        }
       
        void raporHazirla()
        {
            double _toplamTutar = 0;
            double _araTutar = 0;
            double _kdvtTutar = 0;
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = 205;
            rpr.sayfayiYatayYap();
            Image img =Selahattin.logoGetir();
            int resimGenişlik = 0;
            if (img != null)
            {
                //290-50-10
                resimGenişlik = img.Height;
                rpr.ekleResim(new rapor.resim(img, new Rectangle(rpr._kagitGenisligi/2-20, 5, img.Width, resimGenişlik)));
            }
            rpr.ekleSabitYazi(new rapor.sabitYazi(formTipiAdi + " Raporu", new Font("Arial", 15, FontStyle.Bold), new Point(120, 5+resimGenişlik)));

            rpr.ekleSabitYazi(new rapor.sabitYazi("Tarih", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15+ resimGenişlik, 30, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İşlem Türü", new Font("Arial", 10, FontStyle.Underline), new Rectangle(35,  15 + resimGenişlik, 30, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ödeme Türü", new Font("Arial", 10, FontStyle.Underline), new Rectangle(65, 15 + resimGenişlik, 30, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Adı", new Font("Arial", 10, FontStyle.Underline), new Rectangle(95, 15 + resimGenişlik, 50, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("AraTop", new Font("Arial", 10, FontStyle.Underline), new Rectangle(145, 15 + resimGenişlik, 25, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("KDVTOP", new Font("Arial", 10, FontStyle.Underline), new Rectangle(165, 15 + resimGenişlik, 25, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("İSK", new Font("Arial", 10, FontStyle.Underline), new Rectangle(185, 15 + resimGenişlik, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Nak.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(205, 15, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
            // rpr.ekleSabitYazi(new rapor.sabitYazi("İşc.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(225, 15, 20, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Genel Top.", new Font("Arial", 10, FontStyle.Underline), new Rectangle(205, 15 + resimGenişlik, 30, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Fatura No", new Font("Arial", 10, FontStyle.Underline), new Rectangle(240, 15 + resimGenişlik, 50, 4), StringFormatFlags.DirectionRightToLeft, false));
            for (int i = 0; i < dgTicaretRapor.Rows.Count; i++)
            {
                DataGridViewRow r = dgTicaretRapor.Rows[i];
                rpr.ekleYazi(new rapor.yazi(r.Cells["islemTarihi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(5, (20+ resimGenişlik) + i * 4, 30, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["faturaNo"].Value.ToString().Length == 16 ? "E-Fatura" : r.Cells["islemTuru"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(35, (20 + resimGenişlik) + i * 4, 30, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["odemeTuru"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(65, (20 + resimGenişlik) + i * 4, 30, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["adiSoyadi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(95, (20 + resimGenişlik) + i * 4, 50, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["araTop"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(145, (20 + resimGenişlik) + i * 4, 25, 4), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(r.Cells["kdvTop"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(165, (20 + resimGenişlik) + i * 4, 25, 4), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi((Convert.ToDouble(r.Cells["yuzdeisk"].Value) + Convert.ToDouble(r.Cells["iskonto"].Value)).ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(185, (20 + resimGenişlik) + i * 4, 20, 4), StringFormatFlags.DirectionRightToLeft, true));
                // rpr.ekleYazi(new rapor.yazi(r.Cells["nakliyat"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(205, 20 + i * 4, 20, 4), StringFormatFlags.DirectionRightToLeft, true));
                // rpr.ekleYazi(new rapor.yazi(r.Cells["iscilik"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(225, 20 + i * 4, 20, 4), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(r.Cells["GenelToplam"].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), new Rectangle(205, (20 + resimGenişlik) + i * 4, 30, 4), StringFormatFlags.DirectionRightToLeft, true));
                rpr.ekleYazi(new rapor.yazi(r.Cells["faturaNo"].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), new Rectangle(240, (20 + resimGenişlik) + i * 4, 50, 4), StringFormatFlags.DirectionRightToLeft, false));
                _kdvtTutar += Convert.ToDouble(r.Cells["kdvTop"].Value);
                _araTutar += Convert.ToDouble(r.Cells["araTop"].Value);
                _toplamTutar += Convert.ToDouble(r.Cells["GenelToplam"].Value);
                //rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, 20 + i * 4, 20 + i * 4));
            }
            int yukseklik = (25+resimGenişlik) + dgTicaretRapor.Rows.Count * 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik += 3;
            rpr.ekleYazi(new rapor.yazi("Ara Toplam: " + string.Format("{0:n2}", _araTutar) + "TL        KDV Toplam: " + string.Format("{0:n2}", _kdvtTutar) + " TL          Genel Toplam: " + string.Format("{0:n2}", _toplamTutar) + " TL", new Point(5, yukseklik)));
            yukseklik += 4;

            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + dgTicaretRapor.Rows.Count.ToString() + "       Yazdırma Tarihi: " + DateTime.Now.ToString() + "       www.elmaryazilim.com", new Point(5, yukseklik)));

        }
        private void işlemiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string islemTuru = dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString();
            if (islemTuru.Contains("Satış"))
            {
                if (!yetkiler.Satış_Raporu_Sil)
                {
                    yetkiler.mesajVer();
                    return;
                }
            }
            else if (islemTuru.Contains("Alış"))
            {
                if (!yetkiler.Stok_Raporu_Sil)
                {
                    yetkiler.mesajVer();
                    return;
                }
            }
            else if (islemTuru.Contains("Sipariş"))
            {
                if (!yetkiler.Sipariş_Sil)
                {
                    yetkiler.mesajVer();
                    return;
                }
            }
            else if (islemTuru.Contains("Teklif"))
            {
                if (!yetkiler.Teklif_Sil)
                {
                    yetkiler.mesajVer();
                    return;
                }
            }
            if (MessageBox.Show("Seçili kaydı silmek istiyor musunuz ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                veri.cmd("Exec spSilTicaret " + firma.firmaid + "," + dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value + ", '1'");
                dgTicaretRapor.Rows.Remove(dgTicaretRapor.CurrentRow);
            }
        }

        private void silmeİşleminiGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("Exec [spSilTicaret] " + firma.firmaid + "," + dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value + ", '0'");
            btnSorgula.PerformClick();
        }

        private void işlemiDondurKasayaİşlemezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("Exec [spAktiflestirTicaret]  " + firma.firmaid + ", " + dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value + "'1'");
            btnSorgula.PerformClick();
        }

        private void dondurmaİşleminiGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("Exec [spAktiflestirTicaret]  " + firma.firmaid + ", " + dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value + ", '0'");
            btnSorgula.PerformClick();
        }

        private void işlemiDüzenleGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            duzenle();
        }

        private void dgTicaretRapor_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            duzenle();
        }

        private void dgTicaretRapor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            try
            {
                dgTicaretRapor.Rows[e.RowIndex].Cells["KdvTop"].Value = String.Format("{0:n}", Convert.ToDouble(dgTicaretRapor.Rows[e.RowIndex].Cells["KdvTop"].Value));

                dgTicaretRapor.Rows[e.RowIndex].Cells["GenelToplam"].Value = String.Format("{0:n}", Convert.ToDouble(dgTicaretRapor.Rows[e.RowIndex].Cells["GenelToplam"].Value));

                dgTicaretRapor.Rows[e.RowIndex].Cells["AraTop"].Value = String.Format("{0:n}", Convert.ToDouble(dgTicaretRapor.Rows[e.RowIndex].Cells["AraTop"].Value));

                dgTicaretRapor.Rows[e.RowIndex].Cells["iscilik"].Value = String.Format("{0:n}", Convert.ToDouble(dgTicaretRapor.Rows[e.RowIndex].Cells["iscilik"].Value));

                dgTicaretRapor.Rows[e.RowIndex].Cells["nakliyat"].Value = String.Format("{0:n}", Convert.ToDouble(dgTicaretRapor.Rows[e.RowIndex].Cells["nakliyat"].Value));

                dgTicaretRapor.Rows[e.RowIndex].Cells["iskonto"].Value = String.Format("{0:n}", Convert.ToDouble(dgTicaretRapor.Rows[e.RowIndex].Cells["iskonto"].Value));

                dgTicaretRapor.Rows[e.RowIndex].Cells["islemTarihi"].Value = String.Format("{0:g}", Convert.ToDateTime(dgTicaretRapor.Rows[e.RowIndex].Cells["islemTarihi"].Value));


            }
            catch (Exception)
            {

            }
        }

        private void kayıdaAitÜrünleriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Satış_Raporu_Görüntüle)
            {
                yetkiler.mesajVer();
                return;
            }

            frmTicaretUrunRaporlari frm = null;
            if (formTipiAdi == "Alış, Stok Transfer") frm = new frmTicaretUrunRaporlari(frmTicaretUrunRaporlari.formTipi.alis);
            if (formTipiAdi == "Satış") frm = new frmTicaretUrunRaporlari(frmTicaretUrunRaporlari.formTipi.satis);
            if (formTipiAdi == "Sipariş Teklif") frm = new frmTicaretUrunRaporlari(frmTicaretUrunRaporlari.formTipi.siparisTeklif);
            //if (formTipiAdi == "Transfer") frm = new frmTicaretUrunRaporlari(frmTicaretUrunRaporlari.formTipi.transferi);
            if (frm != null) frm.txtTicaretAyrintiid.Text = dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value.ToString();
            frm.Show();
        }

        private void dgTicaretRapor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            kayıdaAitÜrünleriGörüntüleToolStripMenuItem.PerformClick();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            raporHazirla();
            rpr.yazdir();
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar, ComboboxItem.getSelectedValue(cmbSubeler));
        }

        private void dgTicaretRapor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void faturayıİptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int64 ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
            if (FaturayıKontrolEt(ticaretAyrintiid))
            {
                MessageBox.Show("Bu Fatura Daha Önce İptal Edilmiştir", firma.programAdi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime tarih = Convert.ToDateTime(dgTicaretRapor.CurrentRow.Cells["islemTarihi"].Value);
            string faturaNo = dgTicaretRapor.CurrentRow.Cells["faturaNo"].Value.ToString();
            string belgeNo = dgTicaretRapor.CurrentRow.Cells["belgeNo"].Value.ToString();
            DialogResult d = MessageBox.Show("Faturayı iptal Etmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                string query = @"insert into tblIptalEdilenFaturalar (FaturaNo,BelgeNo,IslemTarihi,ticaretAyrintiid,firmaid,subeid,kullaniciid) values('" + faturaNo + "','" + belgeNo + "','" + tarih + "'," + ticaretAyrintiid + "," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ")";
                veri.cmd(query);
                MessageBox.Show("Fatura İptal Edildi", firma.programAdi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                duzenle();
            }

        }
        private void duzenle()
        {
            if (dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString().Contains("Satış İade"))
            {
                if (!yetkiler.Satış_Raporu_Düzenle)
                {
                    yetkiler.mesajVer();
                    return;
                }
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.satisiadeDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                frm.Show();
            }
            else if (dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString().Contains("Alış İade"))
            {
                if (!yetkiler.Satış_Raporu_Düzenle)
                {
                    yetkiler.mesajVer();
                    return;
                }
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.alisiadeDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                frm.Show();
            }
            else if (dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString().Contains("Satış"))
            {
                if (!yetkiler.Satış_Raporu_Düzenle)
                {
                    yetkiler.mesajVer();
                    return;
                }
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.satisDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                frm.Show();
            }
            else if (dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString().Contains("Alış"))
            {
                if (!yetkiler.Stok_Raporu_Düzenle)
                {
                    yetkiler.mesajVer();
                    return;
                }
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.stokDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                frm.Show();
            }
            else if (dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString().Contains("Transfer"))
            {
                if (!yetkiler.Ürün_Transferi)
                {
                    yetkiler.mesajVer();
                    return;
                }
                if (dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString().Contains("Gelen"))
                {
                    MessageBox.Show("Düzenleme işlemini sadece giden transfer üzerinden yapabilirsiniz.", firma.programAdi);
                    return;
                }
                frmTicaret frm = new frmTicaret(frmTicaret.formTipi.transferDuzenle);
                frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                frm.Show();
            }
            else if (dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString().Contains("Sipariş"))
            {
                if (!yetkiler.Sipariş_Düzenle)
                {
                    yetkiler.mesajVer();
                    return;
                }
                if (cmbIslemTipi.SelectedIndex == 0) //Alış
                {
                    frmTicaret frm = new frmTicaret(frmTicaret.formTipi.faturasizAlis);
                    frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                    frm._hesabaislendimi = "1";
                    frm.rdHesabaislensin.Checked = true;
                    frm.Show();
                    frm._hesabaislendimi = "1";
                    frm.rdHesabaislensin.Checked = true;
                    frm.islemTuru = "Faturasız Alış";
                }
                else if (cmbIslemTipi.SelectedIndex == 1)//Satış
                {
                    frmTicaret frm = new frmTicaret(frmTicaret.formTipi.faturasizSatis);
                    frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                    frm._hesabaislendimi = "1";
                    frm.rdHesabaislensin.Checked = true;
                    frm.Show();
                    frm._hesabaislendimi = "1";
                    frm.rdHesabaislensin.Checked = true;
                    frm.islemTuru = "Faturasız Satış";
                }
            }
            else if (dgTicaretRapor.CurrentRow.Cells["islemTuru"].Value.ToString().Contains("Teklif"))
            {
                if (!yetkiler.Teklif_Düzenle)
                {
                    yetkiler.mesajVer();
                    return;
                }
                if (cmbIslemTipi.SelectedIndex == 0) //Alış
                {
                    frmTicaret frm = new frmTicaret(frmTicaret.formTipi.faturasizSatis);
                    frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                    frm._hesabaislendimi = "1";
                    frm.rdHesabaislensin.Checked = true;
                    frm.EnabledAyarla();
                    frm.Show();
                    frm._hesabaislendimi = "1";
                    frm.rdHesabaislensin.Checked = true;
                    frm.islemTuru = "Faturasız Alış";
                }
                else if (cmbIslemTipi.SelectedIndex == 1) //Satış
                {
                    frmTicaret frm = new frmTicaret(frmTicaret.formTipi.faturasizSatis);
                    frm.ticaretAyrintiid = Convert.ToInt64(dgTicaretRapor.CurrentRow.Cells["ticaretAyrintiid"].Value);
                    frm._hesabaislendimi = "1";
                    frm.rdHesabaislensin.Checked = true;
                    frm.EnabledAyarla();
                    frm.Show();
                    frm._hesabaislendimi = "1";
                    frm.rdHesabaislensin.Checked = true;
                    frm.islemTuru = "Faturasız Satış";
                }
            }
        }

        private void chbIptalEdilenFaturalar_CheckedChanged(object sender, EventArgs e)
        {
            bool kontrol = chbIptalEdilenFaturalar.Checked ? true : false;
            foreach (Control k in this.grpOdemeTipi.Controls)
            {
                if (k is CheckBox)
                {
                    if (!(((CheckBox)k).Text.ToString()).Equals("İptal Edilen Faturalar"))
                    {
                        ((CheckBox)k).Checked = !kontrol;
                    }

                }
            }

            foreach (Control k in this.grpİslemTipi.Controls)
            {
                if (k is CheckBox)
                {
                    if (!(((CheckBox)k).Text.ToString()).Equals("İptal Edilen Faturalar"))
                    {
                        ((CheckBox)k).Checked = !kontrol;
                    }

                }
            }
            chbKesilenFaturalar.Checked = !kontrol;
        }

        private bool FaturayıKontrolEt(Int64 ticaretAyrintiid)
        {
            DataTable dt = veri.getdatatable("select * from tblIptalEdilenFaturalar where ticaretAyrintiid=" + ticaretAyrintiid);
            return dt.Rows.Count > 0 ? true : false;
        }

        private void eFaturayıKabulEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string faturaNo = dgTicaretRapor.CurrentRow.Cells["FaturaNo"].Value.ToString();
            tester.Current_SendInvoiceResponseWithServerSign_KABUL(faturaNo);
        }

        private void eFaturayıYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void GetInvoice()
        {
            string faturaNo = dgTicaretRapor.CurrentRow.Cells["FaturaNo"].Value.ToString();
            if (tester == null)
            {
                tester = new SEFatura(EFatura.KullaniciAdi, EFatura.Sifre, EFatura.UrlAdresi);
                tester.Current_Login();
            }
            List<FormParameters> getFormParameters = tester.Current_GetInvoice(faturaNo);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                backgroundWorker1.ReportProgress(i);
            }
            GetInvoice();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            var frm = new frmEFaturaGoruntule(FormValues.hostName + ".xml");
            frm.Show();
        }
    }
}
