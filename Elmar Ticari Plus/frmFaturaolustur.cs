using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{

    public partial class frmFaturaolustur : Form
    {
        public frmFaturaolustur()
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            NesneGorselleri.kontrolEkle(tabPage1);
            NesneGorselleri.kontrolEkle(tabPage2);
            NesneGorselleri.kontrolEkle(tabPage3);
            NesneGorselleri.kontrolEkle(tabPage4);
            NesneGorselleri.kontrolEkle(tabPage5);
            NesneGorselleri.kontrolEkle(tabPage6);
            NesneGorselleri.kontrolEkle(tabPage7);
            NesneGorselleri.kontrolEkle(tabPage8);
            NesneGorselleri.kontrolEkle(tabPage9);
            NesneGorselleri.kontrolEkle(tabPage10);
            NesneGorselleri.kontrolEkle(tabPage11);
            NesneGorselleri.kontrolEkle(tabPage12);
            NesneGorselleri.kontrolEkle(grpUrunbasliklarivesiralama);
        }
        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        //private enum ScrollBarDirection
        //{
        //    SB_HORZ = 0,
        //    SB_VERT = 1,
        //    SB_CTL = 2,
        //    SB_BOTH = 3
        //}
        //protected override void WndProc(ref System.Windows.Forms.Message m)
        //{
        //    ShowScrollBar(this.Handle, (int)ScrollBarDirection.SB_HORZ, false);
        //    base.WndProc(ref m);
        //}
        rapor r = new rapor();
        string[] nesneGetir(byte faturaTuru_degeri)
        {

            string[] dizi = { "Firma Bilgilerim", "Logo Bilgileri", "Cari Bilgileri", "Tarih", "Ürün Bilgileri", "Toplam Tutarlar", "Firma Bilgi Notum", "Yazı ile Tutar", "Açıklama", "Banka Bilgileri", "Kağıt", "Vergi Dairesi", "Vergi No" };
            return dizi;
        }
        void ozellikGetir()
        {
            tabControl1.Visible = true;
            if (listNesneler.Text == "Firma Bilgilerim" && pnlFirmabilgileri.Visible == true)
            {
                tabControl1.SelectedIndex = 0;
                cerceve_ciz(pnlFirmabilgileri);
            }
            else if (listNesneler.Text == "Cari Bilgileri" && pnlCaribilgileri.Visible == true)
            {
                tabControl1.SelectedIndex = 1;
                cerceve_ciz(pnlCaribilgileri);
            }
            else if (listNesneler.Text == "Tarih" && pnlTarih.Visible == true)
            {
                tabControl1.SelectedIndex = 2;
                cerceve_ciz(pnlTarih);
            }
            else if (listNesneler.Text == "Ürün Bilgileri" && pnlUrunbilgileri.Visible == true)
            {
                tabControl1.SelectedIndex = 3;
                cerceve_ciz(pnlUrunbilgileri);
            }
            else if (listNesneler.Text == "Toplam Tutarlar" && pnlToplamlar.Visible == true)
            {
                tabControl1.SelectedIndex = 4;
                cerceve_ciz(pnlToplamlar);
            }
            else if (listNesneler.Text == "Firma Bilgi Notum" && pnlFirmabilginotu.Visible == true)
            {
                tabControl1.SelectedIndex = 5;
                cerceve_ciz(pnlFirmabilginotu);
            }
            else if (listNesneler.Text == "Yazı ile Tutar" && pnlYaziiletutar.Visible == true)
            {
                tabControl1.SelectedIndex = 6;
                cerceve_ciz(pnlYaziiletutar);
            }
            else if (listNesneler.Text == "Açıklama" && pnlAciklama.Visible == true)
            {
                tabControl1.SelectedIndex = 7;
                cerceve_ciz(pnlAciklama);
            }
            else if (listNesneler.Text == "Banka Bilgileri" && pnlBankabilgileri.Visible == true)
            {
                tabControl1.SelectedIndex = 8;
                cerceve_ciz(pnlBankabilgileri);
            }
            else if (listNesneler.Text == "Kağıt")
            {
                tabControl1.SelectedIndex = 9;
            }
            else if (listNesneler.Text == "Vergi Dairesi" && pnlVergiDairesi.Visible == true)
            {
                tabControl1.SelectedIndex = 10;
                cerceve_ciz(pnlVergiDairesi);
            }
            else if (listNesneler.Text == "Vergi No" && pnlVergiNo.Visible == true)
            {
                tabControl1.SelectedIndex = 11;
                cerceve_ciz(pnlVergiNo);
            }
            else if (listNesneler.Text == "Logo Bilgilerim" && pnlLogobilgileri.Visible == true)
            {
                tabControl1.SelectedIndex = 12;
                cerceve_ciz(pnlLogobilgileri);
            }
            else
            {
                tabControl1.Visible = false;
            }
        }
        void nesneEkle()
        {
            if (listNesneler.Text == "Firma Bilgilerim")
            {
                pnlFirmabilgileri.Visible = true;
                pnlFirmabilgileri.BringToFront();
            }
            else if (listNesneler.Text == "Logo Bilgilerim")
            {
                pnlLogobilgileri.Visible = true;
                pnlLogobilgileri.BringToFront();
            }
            else if (listNesneler.Text == "Cari Bilgileri")
            {
                pnlCaribilgileri.Visible = true;
                pnlCaribilgileri.BringToFront();
            }
            else if (listNesneler.Text == "Tarih")
            {
                pnlTarih.Visible = true;
                pnlTarih.BringToFront();
            }
            else if (listNesneler.Text == "Ürün Bilgileri")
            {
                pnlUrunbilgileri.Visible = true;
                pnlUrunbilgileri.BringToFront();
            }
            else if (listNesneler.Text == "Toplam Tutarlar")
            {
                pnlToplamlar.Visible = true;
                pnlToplamlar.BringToFront();
            }
            else if (listNesneler.Text == "Firma Bilgi Notum")
            {
                pnlFirmabilginotu.Visible = true;
                pnlFirmabilginotu.BringToFront();
            }
            else if (listNesneler.Text == "Yazı ile Tutar")
            {
                pnlYaziiletutar.Visible = true;
                pnlYaziiletutar.BringToFront();
            }
            else if (listNesneler.Text == "Açıklama")
            {
                pnlAciklama.Visible = true;
                pnlAciklama.BringToFront();
            }
            else if (listNesneler.Text == "Banka Bilgileri")
            {
                pnlBankabilgileri.Visible = true;
                pnlBankabilgileri.BringToFront();
            }
            else if (listNesneler.Text == "Vergi Dairesi")
            {
                pnlVergiDairesi.Visible = true;
                pnlVergiDairesi.BringToFront();
            }
            else if (listNesneler.Text == "Vergi No")
            {
                pnlVergiNo.Visible = true;
                pnlVergiNo.BringToFront();
            }
            else if (listNesneler.Text == "Logo Bilgileri")
            {
                pnlLogobilgileri.Visible = true;
                pnlVergiNo.BringToFront();
            }
            grpUrunbasliklarivesiralama.BringToFront();
            araBellegi_guncelle();
        }
        private void frmFaturaolustur_Load(object sender, EventArgs e)
        {
            taslak = new string[alanSayisi, 10];
            bilgileriGetir();
            cmbFaturatipi.SelectedIndex = 0;
            saysaSinirlarini_belirle();
            label2.BringToFront();

        }
        private void cmbFaturatipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listNesneler.Items.Clear();
                listNesneler.Items.AddRange(nesneGetir((byte)cmbFaturatipi.SelectedIndex));
                pnlFirmabilgileri.Visible = false;
                pnlCaribilgileri.Visible = false;
                pnlFirmabilginotu.Visible = false;
                pnlTarih.Visible = false;
                pnlToplamlar.Visible = false;
                pnlUrunbilgileri.Visible = false;
                pnlAciklama.Visible = false;
                pnlBankabilgileri.Visible = false;
                pnlVergiDairesi.Visible = false;
                pnlVergiNo.Visible = false;
                pnlLogobilgileri.Visible = false;
                int i = cmbFaturatipi.SelectedIndex;
                if (taslak[2, i] == "1") pnlFirmabilgileri.Visible = true;
                if (taslak[3, i] == "1") pnlCaribilgileri.Visible = true;
                if (taslak[4, i] == "1") pnlTarih.Visible = true;
                if (taslak[5, i] == "1") pnlUrunbilgileri.Visible = true;
                if (taslak[6, i] == "1") pnlToplamlar.Visible = true;
                if (taslak[7, i] == "1") pnlFirmabilginotu.Visible = true;
                listFirma.ClearSelected();
                listCari.ClearSelected();
                listTarih.ClearSelected();
                listToplamlar.ClearSelected();
                listUrun.ClearSelected();
                //firma listboxı getiriliyor
                for (int j = 8; j <= 14; j++)
                {
                    listFirma.SetItemChecked(j - 8, false);
                    if (taslak[j, i].ToString() == "1")
                    {
                        listFirma.SetItemChecked(j - 8, true);
                    }
                }
                Point nokta0 = new Point(Convert.ToInt32(taslak[15, i]), Convert.ToInt32(taslak[16, i]));
                Size boyut0 = new Size(Convert.ToInt32(taslak[17, i]), Convert.ToInt32(taslak[18, i]));
                pnlFirmabilgileri.Size = boyut0;
                pnlFirmabilgileri.Location = nokta0;
                //cari listboxı getiriliyor
                for (int j1 = 19; j1 <= 25; j1++)
                {
                    listCari.SetItemChecked(j1 - 19, false);
                    if (taslak[j1, i].ToString() == "1")
                    {
                        listCari.SetItemChecked(j1 - 19, true);
                    }
                }
                Point nokta1 = new Point(Convert.ToInt32(taslak[26, i]), Convert.ToInt32(taslak[27, i]));
                Size boyut1 = new Size(Convert.ToInt32(taslak[28, i]), Convert.ToInt32(taslak[29, i]));
                pnlCaribilgileri.Size = boyut1;
                pnlCaribilgileri.Location = nokta1;

                //tarih bilgileri getiriliyor
                for (int j2 = 30; j2 <= 31; j2++)
                {
                    listTarih.SetItemChecked(j2 - 30, false);
                    if (taslak[j2, i].ToString() == "1")
                    {
                        listTarih.SetItemChecked(j2 - 30, true);
                    }
                }
                Point nokta2 = new Point(Convert.ToInt32(taslak[32, i]), Convert.ToInt32(taslak[33, i]));
                Size boyut2 = new Size(Convert.ToInt32(taslak[34, i]), Convert.ToInt32(taslak[35, i]));
                pnlTarih.Size = boyut2;
                pnlTarih.Location = nokta2;

                //ürün bilgileri getiriliyor
                for (int j3 = 36; j3 <= 41; j3++)
                {
                    listUrun.SetItemChecked(j3 - 36, false);
                    if (taslak[j3, i].ToString() == "1")
                    {
                        listUrun.SetItemChecked(j3 - 36, true);
                    }
                }
                for (int j3 = 96; j3 <= 98; j3++)
                {
                    listUrun.SetItemChecked(j3 - 90, false);
                    if (taslak[j3, i].ToString() == "1")
                    {
                        listUrun.SetItemChecked(j3 - 90, true);
                    }
                }
                Point nokta3 = new Point(Convert.ToInt32(taslak[42, i]), Convert.ToInt32(taslak[43, i]));
                Size boyut3 = new Size(Convert.ToInt32(taslak[44, i]), Convert.ToInt32(taslak[45, i]));
                pnlUrunbilgileri.Size = boyut3;
                pnlUrunbilgileri.Location = nokta3;
                //toplam bilgileri getiriliyor
                for (int j4 = 46; j4 <= 54; j4++)
                {
                    listToplamlar.SetItemChecked(j4 - 46, false);
                    if (taslak[j4, i].ToString() == "1")
                    {
                        listToplamlar.SetItemChecked(j4 - 46, true);
                    }
                }
                Point nokta4 = new Point(Convert.ToInt32(taslak[55, i]), Convert.ToInt32(taslak[56, i]));
                Size boyut4 = new Size(Convert.ToInt32(taslak[57, i]), Convert.ToInt32(taslak[58, i]));
                pnlToplamlar.Size = boyut4;
                pnlToplamlar.Location = nokta4;

                //bilgiNotu bilgileri getiriliyor
                Point nokta5 = new Point(Convert.ToInt32(taslak[59, i]), Convert.ToInt32(taslak[60, i]));
                Size boyut5 = new Size(Convert.ToInt32(taslak[61, i]), Convert.ToInt32(taslak[62, i]));
                pnlFirmabilginotu.Size = boyut5;
                pnlFirmabilginotu.Location = nokta5;

                //sonradan eklenenler---------------------------------------
                if (taslak[64, i] == "1") chkYazdirmatarihi.Checked = true;
                else chkYazdirmatarihi.Checked = false;

                if (taslak[65, i] == "1") chkYazdirmasaati.Checked = true;
                else chkYazdirmasaati.Checked = false;

                if (taslak[66, i] == "1")
                {
                    chkYazi.Checked = true; pnlYaziiletutar.Visible = true; pnlYaziiletutar.BringToFront();
                    Point noktaYazi = new Point(Convert.ToInt32(taslak[69, i]), Convert.ToInt32(taslak[70, i]));
                    pnlYaziiletutar.Location = noktaYazi;
                }
                else
                { chkYazi.Checked = false; pnlYaziiletutar.Visible = false; }

                if (taslak[67, i] == "1") chkToplambasliklarigosterilsinmi.Checked = true;
                else chkToplambasliklarigosterilsinmi.Checked = false;

                if (taslak[68, i] == "1") chkCaribasliklarigosterilsinmi.Checked = true;
                else chkCaribasliklarigosterilsinmi.Checked = false;
                //Açıklama
                if (taslak[71, i] == "1")
                {
                    pnlAciklama.Visible = true; pnlAciklama.BringToFront();
                    Point noktaAciklama = new Point(Convert.ToInt32(taslak[72, i]), Convert.ToInt32(taslak[73, i]));
                    Size boyutAciklama = new Size(Convert.ToInt32(taslak[74, i]), Convert.ToInt32(taslak[75, i]));
                    pnlAciklama.Size = boyutAciklama;
                    pnlAciklama.Location = noktaAciklama;
                }
                else
                { pnlAciklama.Visible = false; }

                //Banka Bilgileri
                if (taslak[76, i] == "1")
                {
                    pnlBankabilgileri.Visible = true; pnlBankabilgileri.BringToFront();
                    Point noktaBankabilgileri = new Point(Convert.ToInt32(taslak[77, i]), Convert.ToInt32(taslak[78, i]));
                    Size boyutBankabilgileri = new Size(Convert.ToInt32(taslak[79, i]), Convert.ToInt32(taslak[80, i]));
                    pnlBankabilgileri.Size = boyutBankabilgileri;
                    pnlBankabilgileri.Location = noktaBankabilgileri;
                    pnlBankabilgileri.Text = taslak[81, i];
                    txtBankabilgileriicerik.Text = taslak[81, i];
                }
                else
                { pnlBankabilgileri.Visible = false; }
                //Kağıt Bilgileri
                genKagit = Convert.ToInt32(taslak[82, i]);
                yukKagit = Convert.ToInt32(taslak[83, i]);
                txtGenislikkagit.Text = dbi_mm(genKagit).ToString();
                txtYukseklikkagit.Text = dbi_mm(yukKagit).ToString();

                //Vergi Dairesi Bilgileri
                if (taslak[84, i] == "1")
                {
                    pnlVergiDairesi.Visible = true; pnlVergiDairesi.BringToFront();
                    Point noktaVergiDairesi = new Point(Convert.ToInt32(taslak[85, i]), Convert.ToInt32(taslak[86, i]));
                    Size boyutVergiDairesi = new Size(Convert.ToInt32(taslak[87, i]), Convert.ToInt32(taslak[88, i]));
                    pnlVergiDairesi.Size = boyutVergiDairesi;
                    pnlVergiDairesi.Location = noktaVergiDairesi;
                    if (taslak[89, i].ToString() == "1") chkVDbasliklariGosterilsinmi.Checked = true;
                    else chkVDbasliklariGosterilsinmi.Checked = false;
                }

                //Vergi No Bilgileri
                if (taslak[90, i] == "1")
                {
                    pnlVergiNo.Visible = true; pnlVergiNo.BringToFront();
                    Point noktaVergiNo = new Point(Convert.ToInt32(taslak[91, i]), Convert.ToInt32(taslak[92, i]));
                    Size boyutVergiNo = new Size(Convert.ToInt32(taslak[93, i]), Convert.ToInt32(taslak[94, i]));
                    pnlVergiNo.Size = boyutVergiNo;
                    pnlVergiNo.Location = noktaVergiNo;
                    if (taslak[95, i].ToString() == "1") chkVNbasliklariGosterilsinmi.Checked = true;
                    else chkVNbasliklariGosterilsinmi.Checked = false;
                }
                if (taslak[99, i] == "1")
                {
                    pnlLogobilgileri.Visible = true;
                    pnlLogobilgileri.BringToFront();
                    Point noktaVergiNo = new Point(Convert.ToInt32(taslak[100, i]), Convert.ToInt32(taslak[101, i]));
                    Size boyutVergiNo = new Size(Convert.ToInt32(taslak[102, i]), Convert.ToInt32(taslak[103, i]));
                    pnlLogobilgileri.Size = boyutVergiNo;
                    pnlLogobilgileri.Location = noktaVergiNo;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                //hataGonder.gonder(this.Name, hata.ToString());
            }
            taslak2_isle();
            saysaSinirlarini_belirle();
        }
        void taslak2_isle()
        {
            try
            {
                listUrunsirala.Items.Clear();
                int i2 = cmbFaturatipi.SelectedIndex;
                for (int i = 1; i <= 9; i++)
                {
                    if (taslak2[1, i2] == i.ToString()) listUrunsirala.Items.Add("Barkod");
                    if (taslak2[3, i2] == i.ToString()) listUrunsirala.Items.Add("Ürün İsmi");
                    if (taslak2[5, i2] == i.ToString()) listUrunsirala.Items.Add("KDV");
                    if (taslak2[7, i2] == i.ToString()) listUrunsirala.Items.Add("Birim Fiyat");
                    if (taslak2[9, i2] == i.ToString()) listUrunsirala.Items.Add("Miktar");
                    if (taslak2[11, i2] == i.ToString()) listUrunsirala.Items.Add("Isk 1");
                    if (taslak2[13, i2] == i.ToString()) listUrunsirala.Items.Add("Isk 2");
                    if (taslak2[15, i2] == i.ToString()) listUrunsirala.Items.Add("Isk 3");
                    if (taslak2[17, i2] == i.ToString()) listUrunsirala.Items.Add("Toplam");
                }
                if (taslak2[20, i2] == "0") rdGosterilmesin.Checked = true;
                else rdGosterilsin.Checked = true;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
                //hataGonder.gonder(this.Name, hata.ToString());
            }
        }
        private void cerceve_ciz(object sender)
        {
            Pen kalem = new Pen(Brushes.Black, 1);
            Control sndr = (Control)sender;
            saysaSinirlarini_belirle();
            Point nokta = new Point(sndr.Location.X - 5, sndr.Location.Y - 5);
            Size boyut = new Size(sndr.Width + 10, sndr.Height + 10);
            Rectangle dikdortgen = new Rectangle(nokta, boyut);
            Graphics ciz = this.CreateGraphics();
            ciz.DrawRectangle(kalem, dikdortgen);
            tabControl1.Visible = true;
            if (sndr.Tag.ToString() == "0")
            {
                tabControl1.SelectedIndex = 0;
                txtXfirma.Text = dbi_mm(sndr.Location.X).ToString();
                txtYfirma.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikfirma.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikfirma.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "1")
            {
                tabControl1.SelectedIndex = 1;
                txtXcari.Text = dbi_mm(sndr.Location.X).ToString();
                txtYcari.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikcari.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikcari.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "2")
            {
                tabControl1.SelectedIndex = 2;
                txtXtarih.Text = dbi_mm(sndr.Location.X).ToString();
                txtYtarih.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenisliktarih.Text = dbi_mm(sndr.Width).ToString();
                txtYuksekliktarih.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "3")
            {
                tabControl1.SelectedIndex = 3;
                txtXurun.Text = dbi_mm(sndr.Location.X).ToString();
                txtYurun.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikurun.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikurun.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "4")
            {
                tabControl1.SelectedIndex = 4;
                txtXtoplamlar.Text = dbi_mm(sndr.Location.X).ToString();
                txtYtoplamlar.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenisliktoplamlar.Text = dbi_mm(sndr.Width).ToString();
                txtYuksekliktoplamlar.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "5")
            {
                tabControl1.SelectedIndex = 5;
                txtXbilginotu.Text = dbi_mm(sndr.Location.X).ToString();
                txtYbilginotu.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikbilginotu.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikbilginotu.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "6")
            {
                tabControl1.SelectedIndex = 6;
                txtXyaziiletoplam.Text = dbi_mm(sndr.Location.X).ToString();
                txtYyaziiletoplam.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
            }
            else if (sndr.Tag.ToString() == "7")
            {
                tabControl1.SelectedIndex = 7;
                txtXaciklama.Text = dbi_mm(sndr.Location.X).ToString();
                txtYaciklama.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikaciklama.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikaciklama.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "8")
            {
                tabControl1.SelectedIndex = 8;
                txtXbankabilgileri.Text = dbi_mm(sndr.Location.X).ToString();
                txtYbankabilgileri.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikbankabilgileri.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikbankabilgileri.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "9")
            {
                tabControl1.SelectedIndex = 9;
                //kağıt ayarları
            }
            else if (sndr.Tag.ToString() == "10")
            {
                tabControl1.SelectedIndex = 10;
                txtXvd.Text = dbi_mm(sndr.Location.X).ToString();
                txtYvd.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikvd.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikvd.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "11")
            {
                tabControl1.SelectedIndex = 11;
                txtXvn.Text = dbi_mm(sndr.Location.X).ToString();
                txtYvn.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikvn.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikvn.Text = dbi_mm(sndr.Height).ToString();
            }
            else if (sndr.Tag.ToString() == "12")
            {
                tabControl1.SelectedIndex = 12;
                txtXLogo.Text = dbi_mm(sndr.Location.X).ToString();
                txtYLogo.Text = dbi_mm(sndr.Location.Y + scrollDegeri).ToString();
                txtGenislikLogo.Text = dbi_mm(sndr.Width).ToString();
                txtYukseklikLogo.Text = dbi_mm(sndr.Height).ToString();
            }
            sndr.Select();
            sndr.Focus();
            araBellegi_guncelle();
        }
        private void listNesneler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ozellikGetir();
        }
        private void btnNesneyiekle_Click(object sender, EventArgs e)
        {
            nesneEkle();
        }

        private void pnlFirmabilgileri_Click(object sender, EventArgs e)
        {
            cerceve_ciz(sender);
        }

        private void pnlFirmabilgileri_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void pnlFirmabilgileri_MouseUp(object sender, MouseEventArgs e)
        {

            cerceve_ciz(sender);
        }
        private void pnlFirmabilgileri_MouseMove(object sender, MouseEventArgs e)
        {
        }
        private void listNesneler_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnNesneyiekle_Click(sender, e);
        }
        private void txtGenislikfirma_KeyDown(object sender, KeyEventArgs e)
        {
            Control sndr = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    pnlFirmabilgileri.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlFirmabilgileri);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    pnlCaribilgileri.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlCaribilgileri);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    pnlTarih.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlTarih);
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    pnlUrunbilgileri.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlUrunbilgileri);
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    pnlToplamlar.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlToplamlar);
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                    pnlFirmabilginotu.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlFirmabilginotu);
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                    pnlAciklama.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlAciklama);
                }
                else if (tabControl1.SelectedIndex == 8)
                {
                    pnlBankabilgileri.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlBankabilgileri);
                }
                else if (tabControl1.SelectedIndex == 9)
                {
                    genKagit = mm_dbi(Convert.ToInt32(txtGenislikkagit.Text));
                    saysaSinirlarini_belirle();
                }
                else if (tabControl1.SelectedIndex == 10)
                {
                    pnlVergiDairesi.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlVergiDairesi);
                }
                else if (tabControl1.SelectedIndex == 11)
                {
                    pnlVergiNo.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlVergiNo);
                }
                else if (tabControl1.SelectedIndex == 12)
                {
                    pnlLogobilgileri.Width = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlLogobilgileri);
                }
            }
            araBellegi_guncelle();
        }
        private void pnlFirmabilgileri_KeyDown(object sender, KeyEventArgs e)
        {
            Control sndr = (Control)sender;
            if (e.KeyCode == Keys.Delete)
            {
                sndr.Visible = false;
                this.Refresh();
            }
            araBellegi_guncelle();
        }
        Control sndrx;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (tabControl1.SelectedIndex == 0) sndrx = pnlFirmabilgileri;
            else if (tabControl1.SelectedIndex == 1) sndrx = pnlCaribilgileri;
            else if (tabControl1.SelectedIndex == 2) sndrx = pnlTarih;
            else if (tabControl1.SelectedIndex == 3) sndrx = pnlUrunbilgileri;
            else if (tabControl1.SelectedIndex == 4) sndrx = pnlToplamlar;
            else if (tabControl1.SelectedIndex == 5) sndrx = pnlFirmabilginotu;
            else if (tabControl1.SelectedIndex == 6) sndrx = pnlYaziiletutar;
            else if (tabControl1.SelectedIndex == 7) sndrx = pnlAciklama;
            else if (tabControl1.SelectedIndex == 8) sndrx = pnlBankabilgileri;
            else if (tabControl1.SelectedIndex == 10) sndrx = pnlVergiDairesi;
            else if (tabControl1.SelectedIndex == 11) sndrx = pnlVergiNo;
            else if (tabControl1.SelectedIndex == 12) sndrx = pnlLogobilgileri;
            Point nokta;
            if (keyData == Keys.Up)
            {
                nokta = new Point(sndrx.Location.X, sndrx.Location.Y - 1);
                sndrx.Location = nokta;
                cerceve_ciz(sndrx);
                return false;
            }
            if (keyData == Keys.Left)
            {
                nokta = new Point(sndrx.Location.X - 1, sndrx.Location.Y);
                sndrx.Location = nokta;
                cerceve_ciz(sndrx);
                return false;
            }
            if (keyData == Keys.Down)
            {
                nokta = new Point(sndrx.Location.X, sndrx.Location.Y + 1);
                sndrx.Location = nokta;
                cerceve_ciz(sndrx);
                return true;
            }
            if (keyData == Keys.Right)
            {
                nokta = new Point(sndrx.Location.X + 1, sndrx.Location.Y);
                sndrx.Location = nokta;
                cerceve_ciz(sndrx);
                return false;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void txtYukseklikfirma_KeyDown(object sender, KeyEventArgs e)
        {
            Control sndr = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    pnlFirmabilgileri.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlFirmabilgileri);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    pnlCaribilgileri.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlCaribilgileri);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    pnlTarih.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlTarih);
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    pnlUrunbilgileri.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlUrunbilgileri);
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    pnlToplamlar.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlToplamlar);
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                    pnlFirmabilginotu.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlFirmabilginotu);
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                    pnlAciklama.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlAciklama);
                }
                else if (tabControl1.SelectedIndex == 8)
                {
                    pnlBankabilgileri.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlBankabilgileri);
                }
                else if (tabControl1.SelectedIndex == 9)
                {
                    yukKagit = mm_dbi(Convert.ToInt32(txtYukseklikkagit.Text));
                    saysaSinirlarini_belirle();
                }
                else if (tabControl1.SelectedIndex == 10)
                {
                    pnlVergiDairesi.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlVergiDairesi);
                }
                else if (tabControl1.SelectedIndex == 11)
                {
                    pnlVergiNo.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlVergiNo);
                }
                else if (tabControl1.SelectedIndex == 12)
                {
                    pnlLogobilgileri.Height = mm_dbi(Convert.ToInt32(sndr.Text));
                    cerceve_ciz(pnlLogobilgileri);
                }
            }
            araBellegi_guncelle();
        }
        private void frmFaturaolustur_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kaydedildimi == 1)
            {
                DialogResult sonuc = MessageBox.Show("Değişiklikler Kaydedilsinmi?", firma.programAdi, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    araBellegi_guncelle();
                    anaBellegi_guncelle();
                }
                else if (sonuc == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

        }
        private void txtGenislikfirma_KeyPress(object sender, KeyPressEventArgs e)
        {
            //satisislemleri.klavyeKontrol_int(sender,e);
        }
        int alanSayisi = 106;
        string[,] taslak;
        string[,] taslak2 = new string[24, 10];
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            araBellegi_guncelle();
            anaBellegi_guncelle();
        }
        void bilgileriGetir()
        {
            try
            {
                SqlDataReader dr = veri.getDatareader("select id,faturaTipi,pnlFirma,pnlCari,pnlTarih,pnlUrun,pnlTutarlar,pnlBilginotu,firmaAdi,firmaAdresi,firmaVergino,firmaVergidaire,firmaTel,firmaFax,firmaGsm,x0,y0,gen0,yuk0,cariAdi,cariAdresi,cariVergino,cariVergidaire,cariTel,cariGsm,cariBolge,x1,y1,gen1,yuk1,satisTarihi,vadeTarihi,x2,y2,gen2,yuk2,barkod,urunisim,kdv,birimFiyat,miktar,toplam,x3,y3,gen3,yuk3,topkdv,toplam2,pesinat,iskonto,tutar,oncekiBakiye,toplamBakiye,nakit,paraUstu,x4,y4,gen4,yuk4,x5,y5,gen5,yuk5,kullaniciid,yazdirmaTarihi,yazdirmaSaati,yaziylaTutar,toplamBasliklarigosterilsinmi,cariBasliklarigosterilsinmi,yaziylaTutarx,yaziylaTutary,pnlAciklama,xAciklama,yAciklama,genAciklama,yukAciklama,pnlBankabilgileri,xBankabilgileri,yBankabilgileri,genBankabilgileri,yukBankabilgileri,bankaBilgileriicerigi,genKagit,yukKagit,pnlVergiDairesi,xVergiDairesi,yVergiDairesi,genVergiDairesi,yukVergiDairesi,vergiDairesiBasligiGosterilsinmi,pnlVergiNo,xVergiNo,yVergiNo,genVergiNo,yukVergiNo,vergiNoBasligiGosterilsinmi,Isk1,ısk2,Isk3,pnlLogo,xLogo,yLogo,genLogo,yukLogo from tblFaturaDuzenle where firmaid = " + firma.firmaid + " and kullaniciid = " + firma.kullaniciid + "");
                alanSayisi = dr.FieldCount;
                while (dr.Read())
                {
                    for (int i = 0; i < alanSayisi; i++)
                    {
                        taslak[i, Convert.ToInt32(dr["faturaTipi"])] = dr[i].ToString();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString(), "Elmar Ticari");
                //if (internetKontrolu.internetVarmi() == false) MessageBox.Show("İnternet Bağlantınızı Kontrol Edin", "Elmar Ticari");
                //else
                //{
                //    MessageBox.Show(hata.ToString(), "Elmar Ticari");
                //   hataGonder.gonder(this.Name, hata.ToString());
                //}
            }
            try
            {
                SqlDataReader dr = veri.getDatareader("select id, barkodSira, barkodGen, urunisimSira, urunisimGen, kdvSira, kdvGen, birimFiyatsira, birimFiyatgen, miktarSira, miktarGen, Isk1Sira, Isk1Gen, Isk2Sira, Isk2Gen, Isk3Sira, Isk3Gen, toplamSira, toplamGen, faturaTipi, gosterilsinmi, firmaid, subeid, kullaniciid from tblFaturaurunduzenle where firmaid = '" + firma.firmaid + "' and kullaniciid = " + firma.kullaniciid + "");
                while (dr.Read())
                {
                    for (int i = 0; i < 24; i++)
                    {
                        taslak2[i, Convert.ToInt32(dr["faturaTipi"])] = dr[i].ToString();
                    }
                }
            }
            catch (Exception hata)
            {
                //if (internetKontrolu.internetVarmi() == false) MessageBox.Show("İnternet Bağlantınızı Kontrol Edin", "Elmar Ticari");
                //else
                //{
                //    MessageBox.Show(hata.ToString(), "Elmar Ticari");
                //    //hataGonder.gonder(this.Name, hata.ToString());
                //}
            }
        }
        byte kaydedildimi = 1;
        void araBellegi_guncelle()
        {
            kaydedildimi = 0;
            try
            {
                int i = cmbFaturatipi.SelectedIndex;
                if (pnlFirmabilgileri.Visible == false) taslak[2, i] = "0";
                else taslak[2, i] = "1";
                if (pnlCaribilgileri.Visible == false) taslak[3, i] = "0";
                else taslak[3, i] = "1";
                if (pnlTarih.Visible == false) taslak[4, i] = "0";
                else taslak[4, i] = "1";
                if (pnlUrunbilgileri.Visible == false) taslak[5, i] = "0";
                else taslak[5, i] = "1";
                if (pnlToplamlar.Visible == false) taslak[6, i] = "0";
                else taslak[6, i] = "1";
                if (pnlFirmabilginotu.Visible == false) taslak[7, i] = "0";
                else taslak[7, i] = "1";
                //firma listboxı getiriliyor
                for (int j = 8; j <= 14; j++)
                {
                    taslak[j, i] = "0";
                    if (listFirma.GetItemChecked(j - 8) == true)
                    {
                        taslak[j, i] = "1";
                    }
                }
                taslak[15, i] = pnlFirmabilgileri.Location.X.ToString();
                taslak[16, i] = (pnlFirmabilgileri.Location.Y + scrollDegeri).ToString();
                taslak[17, i] = pnlFirmabilgileri.Size.Width.ToString();
                taslak[18, i] = pnlFirmabilgileri.Size.Height.ToString();
                //cari listboxı getiriliyor [19-25] , [26-29]
                for (int j1 = 19; j1 <= 25; j1++)
                {
                    taslak[j1, i] = "0";
                    if (listCari.GetItemChecked(j1 - 19) == true)
                    {
                        taslak[j1, i] = "1";
                    }
                }
                taslak[26, i] = pnlCaribilgileri.Location.X.ToString();
                taslak[27, i] = (pnlCaribilgileri.Location.Y + scrollDegeri).ToString();
                taslak[28, i] = pnlCaribilgileri.Size.Width.ToString();
                taslak[29, i] = pnlCaribilgileri.Size.Height.ToString();

                //tarih bilgileri getiriliyor [30-31] , [32-35]
                for (int j2 = 30; j2 <= 31; j2++)
                {
                    taslak[j2, i] = "0";
                    if (listTarih.GetItemChecked(j2 - 30) == true)
                    {
                        taslak[j2, i] = "1";
                    }
                }
                taslak[32, i] = pnlTarih.Location.X.ToString();
                taslak[33, i] = (pnlTarih.Location.Y + scrollDegeri).ToString();
                taslak[34, i] = pnlTarih.Size.Width.ToString();
                taslak[35, i] = pnlTarih.Size.Height.ToString();

                //ürün bilgileri getiriliyor [36-41] , [42-45]
                for (int j3 = 36; j3 <= 41; j3++)
                {
                    taslak[j3, i] = "0";
                    if (listUrun.GetItemChecked(j3 - 36) == true)
                    {
                        taslak[j3, i] = "1";
                    }
                }
                for (int j3 = 96; j3 <= 98; j3++)
                {
                    taslak[j3, i] = "0";
                    if (listUrun.GetItemChecked(j3 - 90) == true)
                    {
                        taslak[j3, i] = "1";
                    }
                }
                taslak[42, i] = pnlUrunbilgileri.Location.X.ToString();
                taslak[43, i] = (pnlUrunbilgileri.Location.Y + scrollDegeri).ToString();
                taslak[44, i] = pnlUrunbilgileri.Size.Width.ToString();
                taslak[45, i] = pnlUrunbilgileri.Size.Height.ToString();

                //toplam bilgileri getiriliyor [46-54] , [55-58]

                for (int j4 = 46; j4 <= 54; j4++)
                {
                    taslak[j4, i] = "0";
                    if (listToplamlar.GetItemChecked(j4 - 46) == true)
                    {
                        taslak[j4, i] = "1";
                    }
                }
                taslak[55, i] = pnlToplamlar.Location.X.ToString();
                taslak[56, i] = (pnlToplamlar.Location.Y + scrollDegeri).ToString();
                taslak[57, i] = pnlToplamlar.Size.Width.ToString();
                taslak[58, i] = pnlToplamlar.Size.Height.ToString();

                //bilgiNotu bilgileri getiriliyor
                taslak[59, i] = pnlFirmabilginotu.Location.X.ToString();
                taslak[60, i] = (pnlFirmabilginotu.Location.Y + scrollDegeri).ToString();
                taslak[61, i] = pnlFirmabilginotu.Size.Width.ToString();
                taslak[62, i] = pnlFirmabilginotu.Size.Height.ToString();

                //sonradan eklenenler
                if (chkYazdirmatarihi.Checked == true) taslak[64, i] = "1";
                else taslak[64, i] = "0";

                if (chkYazdirmasaati.Checked == true) taslak[65, i] = "1";
                else taslak[65, i] = "0";

                if (chkYazi.Checked == true) taslak[66, i] = "1";
                else taslak[66, i] = "0";

                if (chkToplambasliklarigosterilsinmi.Checked == true) taslak[67, i] = "1";
                else taslak[67, i] = "0";

                if (chkCaribasliklarigosterilsinmi.Checked == true) taslak[68, i] = "1";
                else taslak[68, i] = "0";

                taslak[69, i] = pnlYaziiletutar.Location.X.ToString();
                taslak[70, i] = pnlYaziiletutar.Location.Y.ToString();

                //Aciklama bilgileri getiriliyor
                if (pnlAciklama.Visible == false) taslak[71, i] = "0";
                else taslak[71, i] = "1";
                taslak[72, i] = pnlAciklama.Location.X.ToString();
                taslak[73, i] = (pnlAciklama.Location.Y + scrollDegeri).ToString();
                taslak[74, i] = pnlAciklama.Size.Width.ToString();
                taslak[75, i] = pnlAciklama.Size.Height.ToString();

                //Banka bilgileri getiriliyor
                if (pnlBankabilgileri.Visible == false) taslak[76, i] = "0";
                else taslak[76, i] = "1";

                taslak[77, i] = pnlBankabilgileri.Location.X.ToString();
                taslak[78, i] = (pnlBankabilgileri.Location.Y + scrollDegeri).ToString();
                taslak[79, i] = pnlBankabilgileri.Size.Width.ToString();
                taslak[80, i] = pnlBankabilgileri.Size.Height.ToString();
                taslak[81, i] = txtBankabilgileriicerik.Text;

                //kağıt bilgileri
                taslak[82, i] = genKagit.ToString();
                taslak[83, i] = yukKagit.ToString();

                //Vergi Dairesi bilgileri getiriliyor
                if (pnlVergiDairesi.Visible == false) taslak[84, i] = "0";
                else taslak[84, i] = "1";
                taslak[85, i] = pnlVergiDairesi.Location.X.ToString();
                taslak[86, i] = (pnlVergiDairesi.Location.Y + scrollDegeri).ToString();
                taslak[87, i] = pnlVergiDairesi.Size.Width.ToString();
                taslak[88, i] = pnlVergiDairesi.Size.Height.ToString();
                if (chkVDbasliklariGosterilsinmi.Checked == true) taslak[89, i] = "1";
                else taslak[89, i] = "0";

                //Vergi No bilgileri getiriliyor
                if (pnlVergiNo.Visible == false) taslak[90, i] = "0";
                else taslak[90, i] = "1";
                taslak[91, i] = pnlVergiNo.Location.X.ToString();
                taslak[92, i] = (pnlVergiNo.Location.Y + scrollDegeri).ToString();
                taslak[93, i] = pnlVergiNo.Size.Width.ToString();
                taslak[94, i] = pnlVergiNo.Size.Height.ToString();
                if (chkVNbasliklariGosterilsinmi.Checked == true) taslak[95, i] = "1";
                //Logo bilgileri getiriliyor
                if (pnlLogobilgileri.Visible == false) taslak[99, i] = "0";
                else taslak[99, i] = "1";
                taslak[100, i] = pnlLogobilgileri.Location.X.ToString();
                taslak[101, i] = (pnlLogobilgileri.Location.Y + scrollDegeri).ToString();
                taslak[102, i] = pnlLogobilgileri.Size.Width.ToString();
                taslak[103, i] = pnlLogobilgileri.Size.Height.ToString();

                kaydedildimi = 1;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
                //hataGonder.gonder(this.Name, hata.ToString());
            }
        }
        void anaBellegi_guncelle()
        {
            //veritabanını güncelleme kodları
            try
            {
                int i = cmbFaturatipi.SelectedIndex;
                int j = 2;
                SqlDataReader dr = veri.getDatareader("update tblFaturaduzenle set pnlFirma=" + taslak[j++, i] + ",pnlCari=" + taslak[j++, i] + ",pnlTarih=" + taslak[j++, i] + ",pnlUrun=" + taslak[j++, i] + ",pnlTutarlar=" + taslak[j++, i] + ",pnlBilginotu=" + taslak[j++, i] + ",firmaAdi=" + taslak[j++, i] + ",firmaAdresi=" + taslak[j++, i] + ",firmaVergino=" + taslak[j++, i] + ",firmaVergidaire=" + taslak[j++, i] + ",firmaTel=" + taslak[j++, i] + ",firmaFax=" + taslak[j++, i] + ",firmaGsm=" + taslak[j++, i] + ",x0=" + taslak[j++, i] + ",y0=" + taslak[j++, i] + ",gen0=" + taslak[j++, i] + ",yuk0=" + taslak[j++, i] + ",cariAdi=" + taslak[j++, i] + ",cariAdresi=" + taslak[j++, i] + ",cariVergino=" + taslak[j++, i] + ",cariVergidaire=" + taslak[j++, i] + ",cariTel=" + taslak[j++, i] + ",cariGsm=" + taslak[j++, i] + ",cariBolge=" + taslak[j++, i] + ",x1=" + taslak[j++, i] + ",y1=" + taslak[j++, i] + ",gen1=" + taslak[j++, i] + ",yuk1=" + taslak[j++, i] + ",satisTarihi=" + taslak[j++, i] + ",vadeTarihi=" + taslak[j++, i] + ",x2=" + taslak[j++, i] + ",y2=" + taslak[j++, i] + ",gen2=" + taslak[j++, i] + ",yuk2=" + taslak[j++, i] + ",barkod=" + taslak[j++, i] + ",urunisim=" + taslak[j++, i] + ",kdv=" + taslak[j++, i] + ",birimFiyat=" + taslak[j++, i] + ",miktar=" + taslak[j++, i] + ",toplam=" + taslak[j++, i] + ",x3=" + taslak[j++, i] + ",y3=" + taslak[j++, i] + ",gen3=" + taslak[j++, i] + ",yuk3=" + taslak[j++, i] + ",topkdv=" + taslak[j++, i] + ",toplam2=" + taslak[j++, i] + ",pesinat=" + taslak[j++, i] + ",iskonto=" + taslak[j++, i] + ",tutar=" + taslak[j++, i] + ",oncekiBakiye=" + taslak[j++, i] + ",toplamBakiye=" + taslak[j++, i] + ",nakit=" + taslak[j++, i] + ",paraUstu=" + taslak[j++, i] + ",x4=" + taslak[j++, i] + ",y4=" + taslak[j++, i] + ",gen4=" + taslak[j++, i] + ",yuk4=" + taslak[j++, i] + ",x5=" + taslak[j++, i] + ",y5=" + taslak[j++, i] + ",gen5=" + taslak[j++, i] + ",yuk5=" + taslak[j = j + 2, i] + ",subeid='" + firma.subeid + "',yazdirmaTarihi=" + taslak[j++, i] + ",yazdirmaSaati=" + taslak[j++, i] + ",yaziylaTutar=" + taslak[j++, i] + ",toplamBasliklarigosterilsinmi=" + taslak[j++, i] + ",cariBasliklarigosterilsinmi=" + taslak[j++, i] + ",yaziylaTutarx=" + taslak[j++, i] + ",yaziylaTutary=" + taslak[j++, i] + ",pnlAciklama=" + taslak[j++, i] + ",xAciklama=" + taslak[j++, i] + ",yAciklama=" + taslak[j++, i] + ",genAciklama=" + taslak[j++, i] + ",yukAciklama=" + taslak[j++, i] + ",pnlBankabilgileri=" + taslak[j++, i] + ",xBankabilgileri=" + taslak[j++, i] + ",yBankabilgileri=" + taslak[j++, i] + ",genBankabilgileri=" + taslak[j++, i] + ",yukBankabilgileri=" + taslak[j++, i] + ",bankaBilgileriicerigi='" + taslak[j++, i] + "',genKagit=" + taslak[j++, i] + ",yukKagit=" + taslak[j++, i] + ",pnlVergiDairesi=" + taslak[j++, i] + ",xVergiDairesi=" + taslak[j++, i] + ",yVergiDairesi=" + taslak[j++, i] + ",genVergiDairesi=" + taslak[j++, i] + ",yukVergiDairesi=" + taslak[j++, i] + ",vergiDairesiBasligiGosterilsinmi=" + taslak[j++, i] + ",pnlVergiNo=" + taslak[j++, i] + ",xVergiNo=" + taslak[j++, i] + ",yVergiNo=" + taslak[j++, i] + ",genVergiNo=" + taslak[j++, i] + ",yukVergiNo=" + taslak[j++, i] + ",vergiNoBasligiGosterilsinmi=" + taslak[j++, i] + ",Isk1=" + taslak[j++, i] + ",Isk2=" + taslak[j++, i] + ",Isk3=" + taslak[j++, i] + ",pnlLogo=" + taslak[j++, i] + ",xLogo=" + taslak[j++, i] + ",yLogo=" + taslak[j++, i] + ",genLogo=" + taslak[j++, i] + ",yukLogo=" + taslak[j++, i] + " where faturaTipi='" + i.ToString() + "' and firmaid = " + firma.firmaid + " and kullaniciid = " + firma.kullaniciid + "");
                kaydedildimi = 0;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
                //hataGonder.gonder(this.Name, hata.ToString());
            }
            MessageBox.Show("Kaydedildi", firma.programAdi);
        }
        private void btnSiralamaveboyutlandirma_Click(object sender, EventArgs e)
        {
            grpUrunbasliklarivesiralama.Visible = true;
            grpUrunbasliklarivesiralama.BringToFront();
            grpUrunbasliklarivesiralama.Location = new Point((panel1.Location.X - grpUrunbasliklarivesiralama.Width), grpUrunbasliklarivesiralama.Location.Y);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void btnYukaritasi_Click(object sender, EventArgs e)
        {
            if (listUrunsirala.SelectedIndex > 0)
            {
                byte seciliSatis = (byte)listUrunsirala.SelectedIndex;
                string araString = listUrunsirala.Items[seciliSatis].ToString();
                listUrunsirala.Items[seciliSatis] = listUrunsirala.Items[seciliSatis - 1].ToString();
                listUrunsirala.Items[seciliSatis - 1] = araString;
                listUrunsirala.SelectedIndex = seciliSatis - 1;
            }
        }
        private void btnAsagitasi_Click(object sender, EventArgs e)
        {
            if (listUrunsirala.SelectedIndex < listUrunsirala.Items.Count - 1)
            {
                byte seciliSatis = (byte)listUrunsirala.SelectedIndex;
                string araString = listUrunsirala.Items[seciliSatis].ToString();
                listUrunsirala.Items[seciliSatis] = listUrunsirala.Items[seciliSatis + 1].ToString();
                listUrunsirala.Items[seciliSatis + 1] = araString;
                listUrunsirala.SelectedIndex = seciliSatis + 1;
            }
        }
        private void btnUruniptal_Click(object sender, EventArgs e)
        {
            grpUrunbasliklarivesiralama.Visible = false;
        }
        private void frmFaturaolustur_Click(object sender, EventArgs e)
        {
            listNesneler.SelectedIndex = 9;
            saysaSinirlarini_belirle();
        }
        private void txtBaslikgenisligi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //satisislemleri.klavyeKontrol_int(sender,e);
        }
        int gosterilsinmi;
        private void btnUrunbasligikaydet_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listUrunsirala.Items.Count; i++)
                {
                    if (listUrunsirala.Items[i].ToString() == "Barkod") taslak2[1, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    if (listUrunsirala.Items[i].ToString() == "Ürün İsmi") taslak2[3, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    if (listUrunsirala.Items[i].ToString() == "KDV") taslak2[5, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    if (listUrunsirala.Items[i].ToString() == "Birim Fiyat") taslak2[7, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    if (listUrunsirala.Items[i].ToString() == "Miktar") taslak2[9, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    if (listUrunsirala.Items[i].ToString() == "Isk 1") taslak2[11, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    if (listUrunsirala.Items[i].ToString() == "Isk 2") taslak2[13, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    if (listUrunsirala.Items[i].ToString() == "Isk 3") taslak2[15, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    if (listUrunsirala.Items[i].ToString() == "Toplam") taslak2[17, cmbFaturatipi.SelectedIndex] = (i + 1).ToString();
                    //if (listUrunsirala.Items[i].ToString() == "Barkod") barkodSira = i;
                    //if (listUrunsirala.Items[i].ToString() == "Ürün İsmi") urunSira = i;
                    //if (listUrunsirala.Items[i].ToString() == "KDV") kdvSira = i;
                    //if (listUrunsirala.Items[i].ToString() == "Birim Fiyat") birimFiyatsira = i;
                    //if (listUrunsirala.Items[i].ToString() == "Miktar") miktarSira = i;
                    //if (listUrunsirala.Items[i].ToString() == "Toplam") toplamSira = i;
                }
                if (rdGosterilsin.Checked == true) gosterilsinmi = 1;
                if (rdGosterilmesin.Checked == true) gosterilsinmi = 0;
                veri.cmd("update tblFaturaurunduzenle set barkodSira = '" + taslak2[1, cmbFaturatipi.SelectedIndex] + "' ,barkodGen = '" + taslak2[2, cmbFaturatipi.SelectedIndex] + "',urunisimSira = '" + taslak2[3, cmbFaturatipi.SelectedIndex] + "',urunisimGen = '" + taslak2[4, cmbFaturatipi.SelectedIndex] + "' ,kdvSira = '" + taslak2[5, cmbFaturatipi.SelectedIndex] + "',kdvGen = '" + taslak2[6, cmbFaturatipi.SelectedIndex] + "',birimFiyatsira = '" + taslak2[7, cmbFaturatipi.SelectedIndex] + "',birimFiyatgen = '" + taslak2[8, cmbFaturatipi.SelectedIndex] + "',miktarSira = '" + taslak2[9, cmbFaturatipi.SelectedIndex] + "',miktarGen = '" + taslak2[10, cmbFaturatipi.SelectedIndex] + "',Isk1Sira = '" + taslak2[11, cmbFaturatipi.SelectedIndex] + "',Isk1Gen = '" + taslak2[12, cmbFaturatipi.SelectedIndex] + "',Isk2Sira = '" + taslak2[13, cmbFaturatipi.SelectedIndex] + "',Isk2Gen = '" + taslak2[14, cmbFaturatipi.SelectedIndex] + "',Isk3Sira = '" + taslak2[15, cmbFaturatipi.SelectedIndex] + "',Isk3Gen = '" + taslak2[16, cmbFaturatipi.SelectedIndex] + "',toplamSira = '" + taslak2[17, cmbFaturatipi.SelectedIndex] + "',toplamGen = '" + taslak2[18, cmbFaturatipi.SelectedIndex] + "',gosterilsinmi = '" + gosterilsinmi + "' where faturaTipi='" + cmbFaturatipi.SelectedIndex + "' and firmaid = '" + firma.firmaid + "'");
                MessageBox.Show("Değişiklikler Kaydedildi", firma.programAdi);
                grpUrunbasliklarivesiralama.Visible = false;
            }
            catch (Exception hata)
            {
                //if (internetKontrolu.internetVarmi() == false) MessageBox.Show("İnternet Bağlantınızı Kontrol Edin", "Elmar Ticari");
                //else
                //{
                //    MessageBox.Show(hata.ToString(), "Elmar Ticari");
                //    hataGonder.gonder(this.Name, hata.ToString());
                //}
            }

        }
        private void btnUygula_Click(object sender, EventArgs e)
        {
            int i = listUrunsirala.SelectedIndex;
            int gen = Convert.ToInt32(txtBaslikgenisligi.Text);
            if (listUrunsirala.Items[i].ToString() == "Barkod") taslak2[2, cmbFaturatipi.SelectedIndex] = gen.ToString();
            if (listUrunsirala.Items[i].ToString() == "Ürün İsmi") taslak2[4, cmbFaturatipi.SelectedIndex] = gen.ToString();
            if (listUrunsirala.Items[i].ToString() == "KDV") taslak2[6, cmbFaturatipi.SelectedIndex] = gen.ToString();
            if (listUrunsirala.Items[i].ToString() == "Birim Fiyat") taslak2[8, cmbFaturatipi.SelectedIndex] = gen.ToString();
            if (listUrunsirala.Items[i].ToString() == "Miktar") taslak2[10, cmbFaturatipi.SelectedIndex] = gen.ToString();
            if (listUrunsirala.Items[i].ToString() == "Isk 1") taslak2[12, cmbFaturatipi.SelectedIndex] = gen.ToString();
            if (listUrunsirala.Items[i].ToString() == "Isk 2") taslak2[14, cmbFaturatipi.SelectedIndex] = gen.ToString();
            if (listUrunsirala.Items[i].ToString() == "Isk 3") taslak2[16, cmbFaturatipi.SelectedIndex] = gen.ToString();
            if (listUrunsirala.Items[i].ToString() == "Toplam") taslak2[18, cmbFaturatipi.SelectedIndex] = gen.ToString();
        }
        private void listUrunsirala_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnGor.Text = listUrunsirala.Text;
                int i = listUrunsirala.SelectedIndex;
                if (listUrunsirala.Items[i].ToString() == "Barkod") txtBaslikgenisligi.Text = taslak2[2, cmbFaturatipi.SelectedIndex];
                if (listUrunsirala.Items[i].ToString() == "Ürün İsmi") txtBaslikgenisligi.Text = taslak2[4, cmbFaturatipi.SelectedIndex];
                if (listUrunsirala.Items[i].ToString() == "KDV") txtBaslikgenisligi.Text = taslak2[6, cmbFaturatipi.SelectedIndex];
                if (listUrunsirala.Items[i].ToString() == "Birim Fiyat") txtBaslikgenisligi.Text = taslak2[8, cmbFaturatipi.SelectedIndex];
                if (listUrunsirala.Items[i].ToString() == "Miktar") txtBaslikgenisligi.Text = taslak2[10, cmbFaturatipi.SelectedIndex];
                if (listUrunsirala.Items[i].ToString() == "Isk 1") txtBaslikgenisligi.Text = taslak2[12, cmbFaturatipi.SelectedIndex];
                if (listUrunsirala.Items[i].ToString() == "Isk 2") txtBaslikgenisligi.Text = taslak2[14, cmbFaturatipi.SelectedIndex];
                if (listUrunsirala.Items[i].ToString() == "Isk 3") txtBaslikgenisligi.Text = taslak2[16, cmbFaturatipi.SelectedIndex];
                if (listUrunsirala.Items[i].ToString() == "Toplam") txtBaslikgenisligi.Text = taslak2[12, cmbFaturatipi.SelectedIndex];
            }
            catch
            {
                txtBaslikgenisligi.Text = "100";
            }
        }

        private void txtBaslikgenisligi_TextChanged(object sender, EventArgs e)
        {
            if (txtBaslikgenisligi.Text == "") txtBaslikgenisligi.Text = "100";
            Size boyut = new Size(Convert.ToInt32(txtBaslikgenisligi.Text), 25);
            btnGor.Size = boyut;
            try
            {
                int i = listUrunsirala.SelectedIndex;
                int gen = Convert.ToInt32(txtBaslikgenisligi.Text);
                if (listUrunsirala.Items[i].ToString() == "Barkod") taslak2[2, cmbFaturatipi.SelectedIndex] = gen.ToString();
                if (listUrunsirala.Items[i].ToString() == "Ürün İsmi") taslak2[4, cmbFaturatipi.SelectedIndex] = gen.ToString();
                if (listUrunsirala.Items[i].ToString() == "KDV") taslak2[6, cmbFaturatipi.SelectedIndex] = gen.ToString();
                if (listUrunsirala.Items[i].ToString() == "Birim Fiyat") taslak2[8, cmbFaturatipi.SelectedIndex] = gen.ToString();
                if (listUrunsirala.Items[i].ToString() == "Miktar") taslak2[10, cmbFaturatipi.SelectedIndex] = gen.ToString();
                if (listUrunsirala.Items[i].ToString() == "Isk 2") taslak2[12, cmbFaturatipi.SelectedIndex] = gen.ToString();
                if (listUrunsirala.Items[i].ToString() == "Isk 2") taslak2[14, cmbFaturatipi.SelectedIndex] = gen.ToString();
                if (listUrunsirala.Items[i].ToString() == "Isk 3") taslak2[16, cmbFaturatipi.SelectedIndex] = gen.ToString();
                if (listUrunsirala.Items[i].ToString() == "Toplam") taslak2[12, cmbFaturatipi.SelectedIndex] = gen.ToString();
            }
            catch
            {
            }
        }
        private void txtBaslikgenisligi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnUrunbasligikaydet.Select();
        }

        private void listTarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listTarih.GetItemChecked(1) == true && (cmbFaturatipi.SelectedIndex == 1 || cmbFaturatipi.SelectedIndex == 2))
            //{
            //    MessageBox.Show("Bu Fatura Tipinde Vâde tarihi kullanılamaz.","Elmar Ticari");
            //    listTarih.SetItemChecked(1, false);
            //}
            araBellegi_guncelle();
        }

        private void listToplamlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if ((listToplamlar.GetItemChecked(2) == true || listToplamlar.GetItemChecked(5) == true || listToplamlar.GetItemChecked(6) == true) && (cmbFaturatipi.SelectedIndex == 1 || cmbFaturatipi.SelectedIndex == 2))
            //{
            //    MessageBox.Show("Bu Fatura Tipinde Peşinat, Önceki ve Toplam bakiye alanları kullanılamaz. kullanılamaz.", "Elmar Ticari");
            //    listToplamlar.SetItemChecked(2, false);
            //    listToplamlar.SetItemChecked(5, false);
            //    listToplamlar.SetItemChecked(6, false);
            //}
            //if ((listToplamlar.GetItemChecked(7) == true || listToplamlar.GetItemChecked(8) == true) && cmbFaturatipi.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Bu Fatura Tipinde Nakit , Para Üstü alanları kullanılamaz.", "Elmar Ticari");
            //    listToplamlar.SetItemChecked(7, false);
            //    listToplamlar.SetItemChecked(8, false);
            //}
            araBellegi_guncelle();
        }

        private void listFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            araBellegi_guncelle();
        }

        private void listCari_SelectedIndexChanged(object sender, EventArgs e)
        {
            araBellegi_guncelle();
        }

        private void listUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            araBellegi_guncelle();
        }

        void saysaSinirlarini_belirle()
        {
            this.Refresh();
            Pen kalem = new Pen(Brushes.Black, 2);
            scrollDegeri = this.VerticalScroll.Value;
            Graphics ciz = this.CreateGraphics();
            //if (this.Size.Height + scrollDegeri >= 500)
            //{                
            ciz.DrawLine(kalem, 10, yukKagit - scrollDegeri, genKagit, yukKagit - scrollDegeri);
            ciz.DrawLine(kalem, 0, 0, 0, yukKagit - scrollDegeri);
            //}          
            ciz.DrawLine(kalem, genKagit, 0, genKagit, yukKagit - scrollDegeri);
            ciz.DrawLine(kalem, 0, 0, 0, yukKagit - scrollDegeri);
        }

        int scrollDegeri = 0, yukKagit = 1170, genKagit = 800;
        private void frmFaturaolustur_Scroll(object sender, ScrollEventArgs e)
        {
            saysaSinirlarini_belirle();
        }
        private void pnlFirmabilgileri_LocationChanged(object sender, EventArgs e)
        {
            //Control sndr = (Control)sender;
            ////Point nokta0 = new Point(150, sndr.Location.Y + scrollDegeri-1);            
            ////if (sndr.Location.Y + scrollDegeri < 0) sndr.Location = nokta0;
            //Point nokta1 = new Point(150, 0);          
            //if (sndr.Location.Y + scrollDegeri > 1000) sndr.Location = nokta1;
            //Point nokta2 = new Point(150, 0);            
            //if (sndr.Location.X > 950) sndr.Location = nokta2;
            saysaSinirlarini_belirle();
        }
        int mm_dbi(double mm)
        {
            return r.olcuHesapla(mm);
        }
        int dbi_mm(double dbi)
        {
            return r.olcuyuTersinecevir(dbi);
        }
        private void txtXfirma_KeyDown(object sender, KeyEventArgs e)
        {
            Control sndr = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                Point nokta;
                if (tabControl1.SelectedIndex == 0)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlFirmabilgileri.Location.Y));
                    pnlFirmabilgileri.Location = nokta;
                    cerceve_ciz(pnlFirmabilgileri);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlCaribilgileri.Location.Y));
                    pnlCaribilgileri.Location = nokta;
                    cerceve_ciz(pnlCaribilgileri);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlTarih.Location.Y));
                    pnlTarih.Location = nokta;
                    cerceve_ciz(pnlTarih);
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlUrunbilgileri.Location.Y));
                    pnlUrunbilgileri.Location = nokta;
                    cerceve_ciz(pnlUrunbilgileri);
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlToplamlar.Location.Y));
                    pnlToplamlar.Location = nokta;
                    cerceve_ciz(pnlToplamlar);
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlFirmabilginotu.Location.Y));
                    pnlFirmabilginotu.Location = nokta;
                    cerceve_ciz(pnlFirmabilginotu);
                }
                else if (tabControl1.SelectedIndex == 6)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlYaziiletutar.Location.Y));
                    pnlYaziiletutar.Location = nokta;
                    cerceve_ciz(pnlYaziiletutar);
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlAciklama.Location.Y));
                    pnlAciklama.Location = nokta;
                    cerceve_ciz(pnlAciklama);
                }
                else if (tabControl1.SelectedIndex == 8)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlBankabilgileri.Location.Y));
                    pnlBankabilgileri.Location = nokta;
                    cerceve_ciz(pnlBankabilgileri);
                }
                else if (tabControl1.SelectedIndex == 10)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlVergiDairesi.Location.Y));
                    pnlVergiDairesi.Location = nokta;
                    cerceve_ciz(pnlVergiDairesi);
                }
                else if (tabControl1.SelectedIndex == 11)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlVergiNo.Location.Y));
                    pnlVergiNo.Location = nokta;
                    cerceve_ciz(pnlVergiNo);
                }
                else if (tabControl1.SelectedIndex == 12)
                {
                    nokta = new Point(mm_dbi(Convert.ToInt32(sndr.Text)), (pnlLogobilgileri.Location.Y));
                    pnlLogobilgileri.Location = nokta;
                    cerceve_ciz(pnlLogobilgileri);
                }
                araBellegi_guncelle();
            }
        }

        private void txtYfirma_KeyDown(object sender, KeyEventArgs e)
        {
            Control sndr = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                Point nokta;
                if (tabControl1.SelectedIndex == 0)
                {
                    nokta = new Point((pnlFirmabilgileri.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlFirmabilgileri.Location = nokta;
                    cerceve_ciz(pnlFirmabilgileri);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    nokta = new Point((pnlCaribilgileri.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlCaribilgileri.Location = nokta;
                    cerceve_ciz(pnlCaribilgileri);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    nokta = new Point((pnlTarih.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlTarih.Location = nokta;
                    cerceve_ciz(pnlTarih);
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    nokta = new Point((pnlUrunbilgileri.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlUrunbilgileri.Location = nokta;
                    cerceve_ciz(pnlUrunbilgileri);
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    nokta = new Point((pnlToplamlar.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlToplamlar.Location = nokta;
                    cerceve_ciz(pnlToplamlar);
                }
                else if (tabControl1.SelectedIndex == 5)
                {
                    nokta = new Point((pnlFirmabilginotu.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlFirmabilginotu.Location = nokta;
                    cerceve_ciz(pnlFirmabilginotu);
                }
                else if (tabControl1.SelectedIndex == 6)
                {
                    nokta = new Point((pnlYaziiletutar.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlYaziiletutar.Location = nokta;
                    cerceve_ciz(pnlYaziiletutar);
                }
                else if (tabControl1.SelectedIndex == 7)
                {
                    nokta = new Point((pnlAciklama.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlAciklama.Location = nokta;
                    cerceve_ciz(pnlAciklama);
                }
                else if (tabControl1.SelectedIndex == 8)
                {
                    nokta = new Point((pnlBankabilgileri.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlBankabilgileri.Location = nokta;
                    cerceve_ciz(pnlBankabilgileri);
                }
                else if (tabControl1.SelectedIndex == 10)
                {
                    nokta = new Point((pnlVergiDairesi.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlVergiDairesi.Location = nokta;
                    cerceve_ciz(pnlVergiDairesi);
                }
                else if (tabControl1.SelectedIndex == 11)
                {
                    nokta = new Point((pnlVergiNo.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlVergiNo.Location = nokta;
                    cerceve_ciz(pnlVergiNo);
                }
                else if (tabControl1.SelectedIndex == 12)
                {
                    nokta = new Point((pnlLogobilgileri.Location.X), mm_dbi(Convert.ToInt32(sndr.Text)) - scrollDegeri);
                    pnlLogobilgileri.Location = nokta;
                    cerceve_ciz(pnlLogobilgileri);
                }
                araBellegi_guncelle();
            }
        }

        private void frmFaturaolustur_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void chkCaribasliklarigosterilsinmi_Click(object sender, EventArgs e)
        {
            araBellegi_guncelle();
        }

        private void txtXyaziiletoplam_KeyPress(object sender, KeyPressEventArgs e)
        {
            //satisislemleri.klavyeKontrol_int(sender, e);
        }

        private void txtYyaziiletoplam_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBankabilgileriicerik_TextChanged(object sender, EventArgs e)
        {
            pnlBankabilgileri.Text = txtBankabilgileriicerik.Text;
        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }
    }
}
