using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using elmarLibrary;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
namespace Elmar_Ticari_Plus
{
    class faturaYazdir
    {
        public List<KeyValuePair<int, double>> keyValueKDVler1;
        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        PrintDocument printDocument1 = new PrintDocument();
        PrintDocument pdFis = new PrintDocument();
        private Font fntKucuk = new Font("Arial", 8, FontStyle.Regular);
        private Font fntNormal = new Font("Arial", 9, FontStyle.Regular);
        private Font fntBaslik = new Font("Arial", 10, FontStyle.Underline);
        private string[] taslak = new string[104];
        private string[] taslak2 = new string[24];
        private string faturaTipi = "0";
        private int kalan = 0, donmeSayisi = 0, kayitSayisi;
        List<cT> listT;
        cTA ta;
        cC c;
        public class cT
        {
            public cT(string barkod, string urunAdi, double miktar, int kdv, string kdvTipi, string birim, double birimFiyat, double isk1, double isk2, double isk3, double araTop, double kdvTop, double tutar, string doviz)
            {
                this.barkod = barkod;
                this.urunAdi = urunAdi;
                this.miktar = miktar;
                this.kdv = kdv;
                this.kdvTipi = kdvTipi;
                this.birim = birim;
                this.birimFiyat = birimFiyat;
                this.isk1 = isk1;
                this.isk2 = isk2;
                this.isk3 = isk3;
                this.araTop = araTop;
                this.kdvTop = kdvTop;
                this.tutar = tutar;
                this.doviz = doviz;
            }
            public string barkod;
            public string urunAdi;
            public double miktar;
            public int kdv;
            public string kdvTipi;
            public string birim;
            public double birimFiyat;
            public double isk1;
            public double isk2;
            public double isk3;
            public double araTop;
            public double kdvTop;
            public double tutar;
            public string doviz;
        }
        public class cTA
        {
            public cTA(long tID, double toplam, double topkdv, double iskonto, double nakliyat, double iscilik, double genelToplam, double topisk, DateTime islemTarihi, string islemSaati, string odemeTuru, string faturaNo, string faturaCiktisi, List<KeyValuePair<int, double>> keyValueKDVler)
            {
                this.tID = tID;
                this.toplam = toplam;
                this.topkdv = topkdv;
                this.iskonto = iskonto;
                this.nakliyat = nakliyat;
                this.iscilik = iscilik;
                this.genelToplam = genelToplam;
                this.topisk = topisk;
                this.islemTarihi = islemTarihi;
                this.islemSaati = islemSaati;
                this.odemeTuru = odemeTuru;
                this.faturaCiktisi = faturaCiktisi;
                this.faturaNo = faturaNo;
                this.keyValueKDVler = keyValueKDVler;
            }
            public long tID;
            public double toplam;
            public double topkdv;
            public double iskonto;
            public double nakliyat;
            public double iscilik;
            public double genelToplam;
            public double topisk;
            public DateTime islemTarihi;
            public string islemSaati;
            public string odemeTuru;
            public string faturaNo;
            public string faturaCiktisi;
            public List<KeyValuePair<int, double>> keyValueKDVler;
        }
        public class cC
        {
            public cC(string cariAdiSoyadi, string vd, string vn, string tel, string adres, double eskiBakiye, double pesinat, short miktarCarpani, double duzenlemeBakiyesi)
            {
                this.cariAdiSoyadi = cariAdiSoyadi;
                this.vd = vd;
                this.vn = vn;
                this.tel = tel;
                this.adres = adres;
                this.eskiBakiye = eskiBakiye;
                this.pesinat = pesinat;
                this.miktarCarpani = miktarCarpani;
                this.duzenlemeBakiyesi = duzenlemeBakiyesi;
            }
            public string cariAdiSoyadi;
            public string vd;
            public string vn;
            public string tel;
            public string adres;
            public double eskiBakiye;
            public double pesinat;
            public short miktarCarpani;
            public double duzenlemeBakiyesi;
        }
        //yazdır fonksiyonları
        private void fisYazdir()
        {
            try
            {
                pdFis.Print();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Yazıcı bulunamadı veya yazdırmayla ilgili bir sorun oluştu." + hata.Message, firma.programAdi);
            }
        }
        private void fisOnizle()
        {
            try
            {
                printPreviewDialog1.Document = pdFis;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Yazıcı bulunamadı veya yazdırmayla ilgili bir sorun oluştu." + hata.Message, firma.programAdi);
            }

        }

        public void yazdir()
        {
            sifirla();
            if (faturaTipi == "ciktiFis")
            {
                fisYazdir();
            }
            else if (faturaTipi == "faturaFis")
            {
                fisYazdir();
            }
            else
            {
                yazdir_ozeller();
            }
        }
        public void onizle()
        {
            sifirla();
            if (faturaTipi == "ciktiFis")
            {
                fisOnizle();
            }
            else if (faturaTipi == "faturaFis")
            {
                fisOnizle();
            }
            else
            {
                onizle_ozeller();
            }
        }
        private void yazdir_ozeller()
        {
            try
            {
                printDocument1.Print();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Yazıcı bulunamadı veya yazdırmayla ilgili bir sorun oluştu.\nHata Metni:" + hata.Message, firma.programAdi);
            }
        }
        private void onizle_ozeller()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void sifirla()
        {
            pdFis.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", r.olcuHesapla(Convert.ToDouble(ayarlar.fis_kagit_genislik)), 270 + kayitSayisi * 15);//330
            ((ToolStrip)printPreviewDialog1.Controls[1]).Items[0].Enabled = false;
            kalan = 0;
            donmeSayisi = 0;
        }
        //yapıcı metotlar
        public faturaYazdir(string _faturaTipi, cTA _cTA, cC _cC, List<cT> _cT)
        {
            this.pdFis.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdFis_PrintPage);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.faturaTipi = _faturaTipi;
            if (!faturaTipi.Contains("Fis")) this.kisitlamalariGetir();
            listT = _cT;
            ta = _cTA;
            c = _cC;
            kayitSayisi = _cT.Count();
        }
        elmarLibrary.rapor r = new rapor();
        private string formatlı(string deger)
        {
            try
            {
                return String.Format("{0:n2}", Convert.ToDouble(deger));
            }
            catch (Exception) { return "0"; }
        }
        private int alanSayisi = 0;
        private void kisitlamalariGetir()
        {
            try
            {
                string sql = "select id,faturaTipi,pnlFirma,pnlCari,pnlTarih,pnlUrun,pnlTutarlar,pnlBilginotu,firmaAdi,firmaAdresi,firmaVergino,firmaVergidaire,firmaTel,firmaFax,firmaGsm,x0,y0,gen0,yuk0,cariAdi,cariAdresi,cariVergino,cariVergidaire,cariTel,cariGsm,cariBolge,x1,y1,gen1,yuk1,satisTarihi,vadeTarihi,x2,y2,gen2,yuk2,barkod,urunisim,kdv,birimFiyat,miktar,toplam,x3,y3,gen3,yuk3,topkdv,toplam2,pesinat,iskonto,tutar,oncekiBakiye,toplamBakiye,nakit,paraUstu,x4,y4,gen4,yuk4,x5,y5,gen5,yuk5,kullaniciid,yazdirmaTarihi,yazdirmaSaati,yaziylaTutar,toplamBasliklarigosterilsinmi,cariBasliklarigosterilsinmi,yaziylaTutarx,yaziylaTutary,pnlAciklama,xAciklama,yAciklama,genAciklama,yukAciklama,pnlBankabilgileri,xBankabilgileri,yBankabilgileri,genBankabilgileri,yukBankabilgileri,bankaBilgileriicerigi,genKagit,yukKagit,pnlVergiDairesi,xVergiDairesi,yVergiDairesi,genVergiDairesi,yukVergiDairesi,vergiDairesiBasligiGosterilsinmi,pnlVergiNo,xVergiNo,yVergiNo,genVergiNo,yukVergiNo,vergiNoBasligiGosterilsinmi,Isk1,Isk2,Isk3,pnlLogo,xLogo,yLogo,genLogo,yukLogo from tblFaturaduzenle where firmaid = " + firma.firmaid + " and kullaniciid = " + firma.kullaniciid + " and faturaTipi = '" + faturaTipi + "'";

                SqlDataReader dr = veri.getDatareader(sql);
                alanSayisi = dr.FieldCount;
                while (dr.Read())
                {
                    for (int i = 0; i < alanSayisi; i++)
                    {
                        taslak[i] = dr[i].ToString();
                    }
                }
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", Convert.ToInt32(taslak[82]), Convert.ToInt32(taslak[83]));
            }
            catch (Exception hata)
            {
            }
            try
            {
                SqlDataReader dr = veri.getDatareader("select id, barkodSira, barkodGen, urunisimSira, urunisimGen, kdvSira, kdvGen, birimFiyatsira, birimFiyatgen, miktarSira, miktarGen, Isk1Sira, Isk1Gen, Isk2Sira, Isk2Gen, Isk3Sira, Isk3Gen, toplamSira, toplamGen, faturaTipi, gosterilsinmi, firmaid, subeid, kullaniciid from tblFaturaurunduzenle where firmaid = " + firma.firmaid + " and kullaniciid = " + firma.kullaniciid + "  and faturaTipi = '" + faturaTipi + "'");
                while (dr.Read())
                {
                    for (int i = 0; i < 24; i++)
                    {
                        taslak2[i] = dr[i].ToString();
                    }
                }
            }
            catch (Exception hata)
            {
            }
        }
        //Print fonksiyonları 

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string doviz = listT[0].doviz;
            //if (faturaTipi == "1" && islemTipi == "yazdir") faturaNoartir();
            Pen kalem = new Pen(Brushes.Black, 1);
            int solBosluk = 0;
            Rectangle dikdörtgen;
            StringFormat metinDüzeni = new StringFormat(StringFormatFlags.NoWrap);
            StringFormat metinDüzeni2 = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            //firma bilgileri yazdırılıyor
            if (taslak[2] == "1")
            {
                string firmaMetni = "";
                if (taslak[8] == "1") firmaMetni = firmaBilgileri.adi + " " + firmaBilgileri.soyadi + "\r\n";
                if (taslak[9] == "1") firmaMetni = firmaMetni + subeBilgileri.adres + "\r\n";
                if (taslak[10] == "1") firmaMetni = firmaMetni + "Vergi no:" + subeBilgileri.vergiNo + "  ";
                if (taslak[11] == "1") firmaMetni = firmaMetni + " Vergi daire:" + subeBilgileri.vergiDaire + "  ";
                if (taslak[12] == "1") firmaMetni = firmaMetni + " Tel:" + subeBilgileri.tel;
                if (taslak[13] == "1") firmaMetni = firmaMetni + " Fax:" + subeBilgileri.fax;
                if (taslak[14] == "1") firmaMetni = firmaMetni + " Gsm:" + subeBilgileri.gsm;
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[15]) - solBosluk, Convert.ToInt32(taslak[16]), Convert.ToInt32(taslak[17]), Convert.ToInt32(taslak[18]));
                e.Graphics.DrawString(firmaMetni, fntNormal, Brushes.Black, dikdörtgen);
            }
            //cari bilgileri yazdırılıyor
            if (taslak[3] == "1")
            {
                string cariMetni = "";
                if (taslak[19] == "1") cariMetni = c.cariAdiSoyadi + "\r\n";
                if (taslak[20] == "1") cariMetni = cariMetni + c.adres + "\r\n";
                if (taslak[68] == "1" && taslak[21] == "1") cariMetni = cariMetni + "Vergi no:";
                if (taslak[21] == "1") cariMetni = cariMetni + c.vn + "  ";
                if (taslak[68] == "1" && taslak[22] == "1") cariMetni = cariMetni + " Vergi daire:";
                if (taslak[22] == "1") cariMetni = cariMetni + c.vd + "  ";
                if (taslak[68] == "1" && taslak[23] == "1") cariMetni = cariMetni + " Tel:";
                if (taslak[23] == "1") cariMetni = cariMetni + c.tel;
                //if (taslak[68] == "1") cariMetni = cariMetni + " Gsm:";
                //if (taslak[24] == "1") cariMetni = cariMetni + c.gsm;
                //if (taslak[68] == "1") cariMetni = cariMetni + " Bölge:";
                //if (taslak[25] == "1") cariMetni = cariMetni + ca.boldeAdi;
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[26]) - solBosluk, Convert.ToInt32(taslak[27]), Convert.ToInt32(taslak[28]), Convert.ToInt32(taslak[29]));
                e.Graphics.DrawString(cariMetni, fntNormal, Brushes.Black, dikdörtgen);
            }
            //tarih bilgileri yazdırılıyor
            if (taslak[4] == "1")
            {
                string tarihMetni = "";
                try
                {
                    if (taslak[64] == "1") tarihMetni = string.Format("{0:d}", DateTime.Now) + "\r\n";
                    if (taslak[65] == "1") tarihMetni = tarihMetni + string.Format("{0:t}", DateTime.Now) + "\r\n";
                    if (taslak[30] == "1") tarihMetni = tarihMetni + string.Format("{0:d}", ta.islemTarihi) + "\r\n";
                    //if (taslak[31] == "1") tarihMetni = tarihMetni + ah.vadeTarihi.ToString();
                }
                catch
                {
                }
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[32]) - solBosluk, Convert.ToInt32(taslak[33]), Convert.ToInt32(taslak[34]), Convert.ToInt32(taslak[35]));
                e.Graphics.DrawString(tarihMetni, fntNormal, Brushes.Black, dikdörtgen);
            }
            donmeSayisi = (int)((Convert.ToInt32(taslak[45]) + 20) / 15);
            int g1 = 0, g2 = 0, g3 = 0, g4 = 0, g5 = 0, g6 = 0, g7 = 0, g8 = 0, g9 = 0;
            int s1 = 0, s2 = 0, s3 = 0, s4 = 0, s5 = 0, s6 = 0, s7 = 0, s8 = 0, s9 = 0;
            int taslakKalan = kalan;

            //çizgi1---------------------------------------------------------
            //e.Graphics.DrawLine(kalem, Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak[44]), Convert.ToInt32(taslak[43]));
            //Ürün bilgileri yazdırılıyor

            #region Ürün Bilgileri
            if (taslak[5] == "1")
            {
                int j = 1;
                int xArtis = 0;
                while (j <= 9)
                {
                    if (taslak[36] == "1")
                    {
                        if (taslak2[1] == j.ToString())
                        {
                            if (taslak[20] == "1")
                            {
                                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[2]), 20);
                                e.Graphics.DrawString("Barkod", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                            }
                            for (int i = kalan; i < kayitSayisi; i++)
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s1 + 1) * 15, Convert.ToInt32(taslak2[2]), Convert.ToInt32(taslak[45]) + 20);
                                e.Graphics.DrawString(listT[i].barkod, fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                                if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                                {
                                    kalan = i + 1;
                                    g1 = 1;
                                    s1++;
                                    break;
                                }
                                kalan = i + 1;
                                s1++;
                            }
                            xArtis = xArtis + Convert.ToInt32(taslak2[2]) + 20;
                        }
                    }
                    if (taslak[37] == "1")
                    {
                        if (taslak2[3] == j.ToString())
                        {
                            if (taslak2[20] == "1")
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[4]), 20);
                                e.Graphics.DrawString("Ürün İsmi", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                            }
                            kalan = taslakKalan;
                            for (int i = kalan; i < kayitSayisi; i++)
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s2 + 1) * 15, Convert.ToInt32(taslak2[4]), Convert.ToInt32(taslak[45]) + 20);
                                e.Graphics.DrawString(listT[i].urunAdi, fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                                if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                                {
                                    kalan = i + 1;
                                    g2 = 1;
                                    s2++;
                                    break;
                                }
                                kalan = i + 1;
                                s2++;
                            }
                            xArtis = xArtis + Convert.ToInt32(taslak2[4]) + 20;
                        }
                    }

                    if (taslak[38] == "1")
                    {
                        if (taslak2[5] == j.ToString())
                        {
                            if (taslak2[20] == "1")
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[6]), 20);
                                e.Graphics.DrawString("KDV", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                            }
                            kalan = taslakKalan;
                            for (int i = kalan; i < kayitSayisi; i++)
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s3 + 1) * 15, Convert.ToInt32(taslak2[6]), Convert.ToInt32(taslak[45]) + 20);
                                e.Graphics.DrawString(listT[i].kdv.ToString(), fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                                if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                                {
                                    kalan = i + 1;
                                    g3 = 1;
                                    s3++;
                                    break;
                                }
                                kalan = i + 1;
                                s3++;
                            }
                            xArtis = xArtis + Convert.ToInt32(taslak2[6]) + 20;
                        }
                    }
                    if (taslak[39] == "1")
                    {
                        if (taslak2[7] == j.ToString())
                        {
                            if (taslak2[20] == "1")
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[8]), 20);
                                e.Graphics.DrawString("Birim Fiyat", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                            }
                            kalan = taslakKalan;
                            for (int i = kalan; i < kayitSayisi; i++)
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s4 + 1) * 15, Convert.ToInt32(taslak2[8]), Convert.ToInt32(taslak[45]) + 20);


                                double gecici_BirimFiyat = 0;

                                if (listT[i].kdvTipi == "Dahil")
                                {
                                    if (firma.firmaid == 2661) gecici_BirimFiyat = listT[i].birimFiyat;
                                    else gecici_BirimFiyat = listT[i].birimFiyat / (1.0 + Convert.ToDouble(listT[i].kdv) / 100.0);
                                }
                                else
                                {
                                    gecici_BirimFiyat = listT[i].birimFiyat;
                                }

                                //string iskMetni = "";
                                //if (listT[i].isk1 != 0.00) iskMetni = iskMetni + " %"+ listT[i].isk1.ToString() + "+ ";
                                //if (listT[i].isk2 != 0.00) iskMetni = iskMetni + " %"+ listT[i].isk2.ToString() + "+ ";
                                //if (listT[i].isk3 != 0.00) iskMetni = iskMetni + " %"+ listT[i].isk3.ToString() + "+ ";


                                //e.Graphics.DrawString(formatlı(gecici_BirimFiyat.ToString())+iskMetni, fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                                e.Graphics.DrawString(formatlı(gecici_BirimFiyat.ToString()), fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                                if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                                {
                                    kalan = i + 1;
                                    g4 = 1;
                                    s4++;
                                    break;
                                }
                                kalan = i + 1;
                                s4++;
                            }
                            xArtis = xArtis + Convert.ToInt32(taslak2[8]) + 20;
                        }
                    }

                    if (taslak[40] == "1")
                    {
                        if (taslak2[9] == j.ToString())
                        {
                            if (taslak2[20] == "1")
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[10]), 20);
                                e.Graphics.DrawString("Miktar", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                            }
                            kalan = taslakKalan;
                            for (int i = kalan; i < kayitSayisi; i++)
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s5 + 1) * 15, Convert.ToInt32(taslak2[10]), Convert.ToInt32(taslak[45]) + 20);
                                e.Graphics.DrawString(listT[i].miktar.ToString() + " " + listT[i].birim.ToString(), fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                                if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                                {
                                    kalan = i + 1;
                                    g5 = 1;
                                    s5++;
                                    break;
                                }
                                kalan = i + 1;
                                s5++;
                            }
                            xArtis = xArtis + Convert.ToInt32(taslak2[10]) + 20;
                        }
                    }

                    if (taslak[96] == "1")
                    {
                        if (taslak2[11] == j.ToString())
                        {
                            if (taslak2[20] == "1")
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[12]), 20);
                                e.Graphics.DrawString("Isk1", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                            }
                            kalan = taslakKalan;
                            for (int i = kalan; i < kayitSayisi; i++)
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s6 + 1) * 15, Convert.ToInt32(taslak2[12]), Convert.ToInt32(taslak[45]) + 20);
                                e.Graphics.DrawString("%" + listT[i].isk1.ToString(), fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                                if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                                {
                                    kalan = i + 1;
                                    g6 = 1;
                                    s6++;
                                    break;
                                }
                                kalan = i + 1;
                                s6++;
                            }
                            xArtis = xArtis + Convert.ToInt32(taslak2[12]) + 20;
                        }
                    }

                    if (taslak[97] == "1")
                    {
                        if (taslak2[13] == j.ToString())
                        {
                            if (taslak2[20] == "1")
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[14]), 20);
                                e.Graphics.DrawString("Isk2", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                            }
                            kalan = taslakKalan;
                            for (int i = kalan; i < kayitSayisi; i++)
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s7 + 1) * 15, Convert.ToInt32(taslak2[14]), Convert.ToInt32(taslak[45]) + 20);
                                e.Graphics.DrawString("%" + listT[i].isk2.ToString(), fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                                if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                                {
                                    kalan = i + 1;
                                    g7 = 1;
                                    s7++;
                                    break;
                                }
                                kalan = i + 1;
                                s7++;
                            }
                            xArtis = xArtis + Convert.ToInt32(taslak2[14]) + 20;
                        }
                    }


                    //if (taslak[98] == "1")
                    //{
                    //    if (taslak2[15] == j.ToString())
                    //    {
                    //        if (taslak2[20] == "1")
                    //        {
                    //            dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[16]), 20);
                    //            e.Graphics.DrawString("Isk3", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                    //        }
                    //        kalan = taslakKalan;
                    //        for (int i = kalan; i < kayitSayisi; i++)
                    //        {
                    //            dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s8 + 1) * 15, Convert.ToInt32(taslak2[16]), Convert.ToInt32(taslak[45]) + 20);
                    //            e.Graphics.DrawString("%" + listT[i].isk3.ToString(), fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                    //            if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                    //            {
                    //                kalan = i + 1;
                    //                g8 = 1;
                    //                s8++;
                    //                break;
                    //            }
                    //            kalan = i + 1;
                    //            s8++;
                    //        }
                    //        xArtis = xArtis + Convert.ToInt32(taslak2[16]) + 20;
                    //    }
                    //}


                    if (taslak[41] == "1")
                    {
                        if (taslak2[17] == j.ToString())
                        {
                            if (taslak2[20] == "1")
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]), Convert.ToInt32(taslak2[18]), 20);

                                e.Graphics.DrawString("Tutar", fntBaslik, Brushes.Black, dikdörtgen, metinDüzeni);
                            }
                            kalan = taslakKalan;
                            for (int i = kalan; i < kayitSayisi; i++)
                            {
                                dikdörtgen = new Rectangle(xArtis + Convert.ToInt32(taslak[42]) - solBosluk, Convert.ToInt32(taslak[43]) + (s9 + 1) * 15, Convert.ToInt32(taslak2[18]), Convert.ToInt32(taslak[45]) + 20);
                                e.Graphics.DrawString(formatlı(listT[i].araTop.ToString()) + " " + listT[i].doviz, fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);

                                if (i % donmeSayisi == 0 && kayitSayisi > donmeSayisi + 1 && i != 0)
                                {
                                    kalan = i + 1;
                                    g9 = 1;
                                    s9++;
                                    break;
                                }
                                kalan = i + 1;
                                s9++;
                            }
                            xArtis = xArtis + Convert.ToInt32(taslak2[18]) + 20;
                        }
                    }
                    j++;
                }
                if ((g1 == 1 || g2 == 1 || g3 == 1 || g4 == 1 || g5 == 1 || g6 == 1 || g7 == 1 || g8 == 1 || g9 == 1) && kalan < kayitSayisi)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            #endregion

            //çizgi2---------------------------------------------------------
            //e.Graphics.DrawLine(kalem, Convert.ToInt32(taslak[55]) - solBosluk, Convert.ToInt32(taslak[56]), Convert.ToInt32(taslak[57]), Convert.ToInt32(taslak[56]));
            //Toplam bilgileri yazdırılıyor
            if (taslak[6] == "1")
            {
                string toplamMetni = "";
                string toplamMetni2 = "";

                toplamMetni = "Ödeme Tipi\r\n";
                toplamMetni2 = ta.odemeTuru + "\r\n";
                if (firma.firmaid == 273)
                {
                    toplamMetni = toplamMetni + "Brüt\r\n";
                    double brut = 0;
                    for (int i = 0; i < listT.Count; i++)
                    {
                        brut += (listT[i].miktar * listT[i].birimFiyat);
                    }
                    toplamMetni2 = toplamMetni2 + formatlı(brut.ToString()) + "\r\n";
                }
                if (taslak[47] == "1")
                {
                    if (taslak[67] == "1") toplamMetni += "ARATOP\r\n";
                    toplamMetni2 += formatlı(ta.toplam.ToString()) + " " + doviz + "\r\n";
                }
                if (taslak[66] == "1")
                {
                    if (taslak[67] == "1") toplamMetni = toplamMetni + "KDV TOP\r\n";

                    toplamMetni2 = toplamMetni2 + formatlı(ta.topkdv.ToString()) + " " + doviz + "\r\n";
                }

                if (taslak[49] == "1")
                {
                    if (taslak[67] == "1") toplamMetni = toplamMetni + "ISKTOP\r\n";

                    toplamMetni2 = toplamMetni2 + formatlı((ta.iskonto + ta.topisk).ToString()) + " " + doviz + "\r\n";
                }

                if (taslak[50] == "1")
                {
                    if (taslak[67] == "1") toplamMetni = toplamMetni + "GENEL TOP\r\n";

                    toplamMetni2 = toplamMetni2 + formatlı(ta.genelToplam.ToString()) + " " + doviz + "\r\n";
                }
                if (taslak[48] == "1")
                {
                    if (taslak[67] == "1") toplamMetni = toplamMetni + "Peşinat\r\n";
                    toplamMetni2 = toplamMetni2 + formatlı(c.pesinat.ToString()) + " " + doviz + "\r\n";
                }
                if (taslak[51] == "1")
                {
                    if (taslak[67] == "1") toplamMetni = toplamMetni + "Önceki Bakiye\r\n";
                    toplamMetni2 = toplamMetni2 + formatlı(c.eskiBakiye.ToString()) + "\r\n";

                }
                if (taslak[52] == "1")
                {
                    if (taslak[67] == "1") toplamMetni = toplamMetni + "Toplam Bakiye\r\n";
                    double yazdirilacakToplamBakiye = c.eskiBakiye;
                    if (ta.odemeTuru != "Peşin") yazdirilacakToplamBakiye = yazdirilacakToplamBakiye + c.miktarCarpani * ta.genelToplam - c.miktarCarpani * c.pesinat - c.duzenlemeBakiyesi;
                    string bakiyeDurumu = "";
                    if (yazdirilacakToplamBakiye < 0) bakiyeDurumu = "Borçlu";
                    else if (yazdirilacakToplamBakiye > 0) bakiyeDurumu = "Alacaklı";
                    toplamMetni2 = toplamMetni2 + formatlı(Math.Abs(yazdirilacakToplamBakiye).ToString()) + "\r\n" + bakiyeDurumu;
                }

                if (taslak[53] == "1")
                {
                    //if (taslak[67] == "1") toplamMetni = toplamMetni + "Nakit\r\n";
                    //toplamMetni2 = toplamMetni2 + formatlı(nakit) + "\r\n";
                }
                if (taslak[54] == "1")
                {
                    //if (taslak[67] == "1") toplamMetni = toplamMetni + "Para Üstü\r\n";
                    //toplamMetni2 = toplamMetni2  + formatlı(paraUstu) + "\r\n";
                }
                PaperSize ps = pdFis.DefaultPageSettings.PaperSize;
                int x, y, genislik, yukseklik;
                x = Convert.ToInt32(taslak[55]) - solBosluk;
                y = Convert.ToInt32(taslak[56]) + 20;
                genislik = Convert.ToInt32(taslak[57]);
                yukseklik = Convert.ToInt32(taslak[58]) + 20;
                ps.Height = yukseklik;
                dikdörtgen = new Rectangle(x, y, genislik, yukseklik);
                e.Graphics.DrawString(toplamMetni, fntNormal, Brushes.Black, dikdörtgen, metinDüzeni);
                dikdörtgen = new Rectangle(x, y, genislik, yukseklik);
                e.Graphics.DrawString(toplamMetni2, fntNormal, Brushes.Black, dikdörtgen, metinDüzeni2);
            }
            //yaziyla tutar
            if (taslak[66] == "1")
            {
                string kdvler = "";
                string para = "";
                double toplamkdv = 0;
                List<KeyValuePair<int, double>> grouped = (from kvp in ta.keyValueKDVler
                                                           group kvp by kvp.Key
                                                                     into g
                                                           select new KeyValuePair<int, double>(g.Key, g.Sum(u => (u.Value)))).ToList();

                List<KeyValuePair<int, double>> grouped1 = (from kvp in keyValueKDVler1
                                                            group kvp by kvp.Key
                                                                    into g
                                                            select new KeyValuePair<int, double>(g.Key, g.Sum(u => (u.Value)))).ToList();
                for (int i = 0; i < grouped.Count; i++)
                {
                    //isk3 e aktarmıştır
                    if (taslak[98] == "1") kdvler = kdvler + "%" + +grouped[i].Key + "   KDV       " + formatlı(grouped1[i].Value.ToString()) + "          " + " " + formatlı(grouped[i].Value.ToString()) + "  " + doviz + "\n";
                    toplamkdv += grouped[i].Value;
                }

                string[] metin = ta.genelToplam.ToString().Split(',');
                para = "Yalnızca " + islemler.sayiyiYaziyacevir(metin[0].ToString()) + "  TL  ";
                if (metin.Length > 1) para = para + islemler.sayiyiYaziyacevir(metin[1].ToString()) + "  Kr. ";
                para = para + " ";
                if (!kdvler.Equals(""))
                    e.Graphics.DrawString(kdvler + " KDV TOPLAM : " + toplamkdv + "\n" + para, fntNormal, Brushes.Black, Convert.ToInt32(taslak[69]), Convert.ToInt32(taslak[70]));
                else
                    e.Graphics.DrawString(para, fntNormal, Brushes.Black, Convert.ToInt32(taslak[69]), Convert.ToInt32(taslak[70]));
            }
            //çizgi3---------------------------------------------------------            
            //e.Graphics.DrawLine(kalem, Convert.ToInt32(taslak[59]) - solBosluk, Convert.ToInt32(taslak[60]), Convert.ToInt32(taslak[61]), Convert.ToInt32(taslak[60]));
            //Bilgi Notu bilgileri yazdırılıyor
            if (taslak[7] == "1")
            {
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[59]) - solBosluk, Convert.ToInt32(taslak[60]) + 20, Convert.ToInt32(taslak[61]), Convert.ToInt32(taslak[62]) + 20);
                e.Graphics.DrawString(subeBilgileri.altBilgiNotu, fntNormal, Brushes.Black, dikdörtgen);
            }
            //açıklama
            if (taslak[71] == "1")
            {
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[72]) - solBosluk, Convert.ToInt32(taslak[73]) + 20, Convert.ToInt32(taslak[74]), Convert.ToInt32(taslak[75]) + 20);
                e.Graphics.DrawString(ta.faturaCiktisi, fntNormal, Brushes.Black, dikdörtgen);
            }
            //Banka Bilgileri
            if (taslak[76] == "1")
            {
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[77]) - solBosluk, Convert.ToInt32(taslak[78]) + 20, Convert.ToInt32(taslak[79]), Convert.ToInt32(taslak[80]) + 20);
                e.Graphics.DrawString(taslak[81], fntNormal, Brushes.Black, dikdörtgen);
            }

            //Vergi Dairesi
            if (taslak[84] == "1")
            {
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[85]) - solBosluk, Convert.ToInt32(taslak[86]) + 20, Convert.ToInt32(taslak[87]), Convert.ToInt32(taslak[88]) + 20);
                string vdMetni = "";
                if (taslak[89] == "1") vdMetni = vdMetni + " Vergi Daire: ";
                vdMetni = vdMetni + c.vd + "  ";
                e.Graphics.DrawString(vdMetni, fntNormal, Brushes.Black, dikdörtgen);
            }

            //Vergi No
            if (taslak[90] == "1")
            {
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[91]) - solBosluk, Convert.ToInt32(taslak[92]) + 20, Convert.ToInt32(taslak[93]), Convert.ToInt32(taslak[94]) + 20);
                string vnMetni = "";
                if (taslak[95] == "1") vnMetni = vnMetni + " Vergi No: ";
                vnMetni = vnMetni + c.vn + "  ";
                e.Graphics.DrawString(vnMetni, fntNormal, Brushes.Black, dikdörtgen);
            }
            //logo işlemleri
            if (taslak[99] == "1")
            {
                dikdörtgen = new Rectangle(Convert.ToInt32(taslak[100]) - solBosluk, Convert.ToInt32(taslak[101]) + 20, Convert.ToInt32(taslak[102]), Convert.ToInt32(taslak[103]) + 20);


                //string vnMetni = "";
                //if (taslak[95] == "1") vnMetni = vnMetni + " Vergi No: ";
                //vnMetni = vnMetni + c.vn + "  ";
                var img = Selahattin.logoGetir();
                if (img != null)
                    e.Graphics.DrawImage(img, dikdörtgen);
            }
        }
        private void pdFis_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //if (faturaTipi != "ciktiFis" && islemTipi == "yazdir") faturaNoartir();
            //fiş için
            int solBosluk = r.olcuHesapla(Convert.ToDouble(ayarlar.fis_kagit_sol_bosluk)), ustBosluk = r.olcuHesapla(Convert.ToDouble(ayarlar.fis_kagit_ust_bosluk));
            StringFormat metinDüzeni = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            Font fnt = new Font("Arial", 8, FontStyle.Regular);
            Font fntKucuk = new Font("Arial", 6, FontStyle.Regular);
            int yukseklik = 0;
            Pen kalem = new Pen(Brushes.Black, 1);
            Rectangle dikdörtgen;
            dikdörtgen = new Rectangle(solBosluk, ustBosluk, 260, 80);
            string vergiler = " VD:" + c.vd + "  VNo:" + c.vn;
            if (faturaTipi == "ciktiFis") vergiler = "";
            if (faturaTipi != "ciktiFis") e.Graphics.DrawString(c.cariAdiSoyadi, fnt, Brushes.Black, dikdörtgen);
            else e.Graphics.DrawString(firmaBilgileri.adi + " " + firmaBilgileri.soyadi + "\n" + subeBilgileri.adres + "  " + subeBilgileri.tel + vergiler, fnt, Brushes.Black, dikdörtgen);
            string fatNo = "   Fat. No: " + ta.faturaNo;
            if (faturaTipi == "ciktiFis") fatNo = "";
            e.Graphics.DrawString("Tarih Saat:" + ta.islemTarihi.ToShortDateString() + " " + ta.islemSaati + "  " + fatNo, fnt, Brushes.Black, solBosluk, 65 + ustBosluk);
            for (int i = 0; i < kayitSayisi; i++)
            {
                //ürün ismi
                dikdörtgen = new Rectangle(solBosluk, ustBosluk + 130 + i * 15, 130, 15);
                e.Graphics.DrawString(listT[i].urunAdi, fnt, Brushes.Black, dikdörtgen);
                //miktar x birimFiyat
                dikdörtgen = new Rectangle(solBosluk + 135, ustBosluk + 130 + i * 15, 60, 15);
                e.Graphics.DrawString(listT[i].miktar + "x" + formatlı(listT[i].birimFiyat.ToString()), fnt, Brushes.Black, dikdörtgen);
                if (faturaTipi != "ciktiFis")
                {
                    //kdv %
                    dikdörtgen = new Rectangle(solBosluk + 195, ustBosluk + 130 + i * 15, 30, 15);
                    e.Graphics.DrawString("%" + listT[i].kdv, fnt, Brushes.Black, dikdörtgen);
                }
                //tutar
                dikdörtgen = new Rectangle(solBosluk + 225, ustBosluk + 130 + i * 15, 35, 15);
                e.Graphics.DrawString(formatlı(listT[i].tutar.ToString()) + " " + listT[i].doviz, fnt, Brushes.Black, dikdörtgen, metinDüzeni);
                yukseklik = 130 + i * 15;
            }
            yukseklik = yukseklik + 20 + ustBosluk;
            e.Graphics.DrawLine(kalem, solBosluk, yukseklik, 285, yukseklik); yukseklik += 5;
            if (faturaTipi != "ciktiFis")
            {
                //Toplam KDV Yazılıyor
                e.Graphics.DrawString("TOPKDV", fntNormal, Brushes.Black, solBosluk, yukseklik);
                dikdörtgen = new Rectangle(195 + solBosluk, yukseklik, 65, 15);
                e.Graphics.DrawString(formatlı(ta.topkdv.ToString()) + " TL", fnt, Brushes.Black, dikdörtgen, metinDüzeni);
                yukseklik += 15;
            }
            //toplam Yazılıyor
            e.Graphics.DrawString("TOPLAM", fntNormal, Brushes.Black, 25, yukseklik);
            dikdörtgen = new Rectangle(195 + solBosluk, yukseklik, 65, 15);
            e.Graphics.DrawString(formatlı(ta.genelToplam.ToString()) + " TL", fnt, Brushes.Black, dikdörtgen, metinDüzeni);
            yukseklik += 15;
            if (faturaTipi != "ciktiFis")
            {
                //bakiye yazılıyor
                e.Graphics.DrawString("Genel Top", fntNormal, Brushes.Black, 25, yukseklik);
                dikdörtgen = new Rectangle(195, yukseklik, 65, 15);
                e.Graphics.DrawString(formatlı(ta.genelToplam.ToString()) + " TL", fnt, Brushes.Black, dikdörtgen, metinDüzeni);
                yukseklik += 15;
            }
            e.Graphics.DrawLine(kalem, solBosluk, yukseklik, 285, yukseklik); yukseklik += 5;
            //bilgiler yazdırılıyor
            dikdörtgen = new Rectangle(solBosluk, yukseklik, 260, 30);
            e.Graphics.DrawString("T ID:" + ta.tID + " | " + "Kas:" + firma.kullaniciAdi + " | " + "Şube:" + subeBilgileri.subeAdi, fnt, Brushes.Black, dikdörtgen); yukseklik += 30;
            //alt bilgi notu yazdırılıyor
            try
            {
                if (subeBilgileri.altBilgiNotu != null && subeBilgileri.altBilgiNotu.Length > 0)
                {
                    dikdörtgen = new Rectangle(solBosluk, yukseklik, 260, 30);
                    e.Graphics.DrawString(subeBilgileri.altBilgiNotu, fnt, Brushes.Black, dikdörtgen); yukseklik += 30;
                }
            }
            catch
            {
            }
            //reklam yazdırılıyor
            dikdörtgen = new Rectangle(solBosluk, yukseklik, 260, 30);
            e.Graphics.DrawString("ELMAR YAZILIM Otomasyon ve Web Hizmetleri www.elmaryazilim.com", fntKucuk, Brushes.Black, dikdörtgen);
        }
    }
}