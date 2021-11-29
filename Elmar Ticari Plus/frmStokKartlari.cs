using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using elmarLibrary;
using System.IO;

namespace Elmar_Ticari_Plus
{
    public partial class frmStokKartlari : Form
    {
        private List<int> listFiyat = new List<int>();
        private List<KeyValuePair<Int64, double>> listCanliStok = new List<KeyValuePair<Int64, double>>();

        public frmStokKartlari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgStokKart);
            NesneGorselleri.kontrolEkle(panel11);
        }

        private void frmStokKartlari_Load(object sender, EventArgs e)
        {
            cmbUrunAdi.Items.Clear();
            cmbSube.Items.Clear();
            cmbKategori.Items.Clear();
            cmbMarkalar.Items.Clear();
            try { cmbUrunAdi.Items.AddRange(listeler.getUrunisim()); }
            catch { }
            try { cmbKategori.Items.AddRange(listeler.getKategoriadi()); }
            catch { }
            try { cmbMarkalar.Items.AddRange(listeler.getMarkaadi()); }
            catch { }
            listeler.doldurSube(cmbSube);
            satisFiyatiListele();
            btnSorgula_Click(sender, e);
        }

        void ara_barkod()
        {
            try
            {
                dgStokKart.Rows.Clear();
                var l = stokkart.bul_barkod(txtBarkod.Text);
                dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, "", l.urunAdi, l.alisFiyat, l.kdv, l.kdvTipi, l.katNo, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, l.aktifmi, l.eklenmeTarihi, l.silindimi);
            }
            catch
            {
            }
        }

        void ara_stokkodu()
        {
            try
            {
                dgStokKart.Rows.Clear();
                var l = stokkart.bul_stokkodu(txtStokkodu.Text);
                var l2 = stokkart.fiyatlar.listFiyatlar.FirstOrDefault(u => u.stokid == l.stokid);
                dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, "", l.urunAdi, l.alisFiyat, l2.fiyatTutari, l.kdv, l.kdvTipi, l.katNo, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, l.aktifmi, l.eklenmeTarihi, l.silindimi);
                //dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, "", l.urunAdi, l.alisFiyat, l.kdv, l.kdvTipi, l.katNo, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, l.aktifmi, l.eklenmeTarihi, l.silindimi);
            }
            catch
            {
            }
        }

        void ara_urunKodu()
        {
            try
            {
                dgStokKart.Rows.Clear();
                var l = stokkart.bul_urunKodu(txtUrunKodu.Text);
                var l2 = stokkart.fiyatlar.listFiyatlar.FirstOrDefault(u => u.stokid == l.stokid);
                dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, "", l.urunAdi, l.alisFiyat, l2.fiyatTutari, l.kdv, l.kdvTipi, l.katNo, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, l.aktifmi, l.eklenmeTarihi, l.silindimi);
                //dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, "", l.urunAdi, l.alisFiyat, l.kdv, l.kdvTipi, l.katNo, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, l.aktifmi, l.eklenmeTarihi, l.silindimi);
            }
            catch
            {
            }
        }

        void ara_urunAdi()
        {
            try
            {
                dgStokKart.Rows.Clear();
                var l1 = stokkart.listStokkart.Where(u => u.stokid == listeler.getStokid()[cmbUrunAdi.SelectedIndex]);

                foreach (stokkart.stokkartAyrinti l in l1)
                {
                    var l2 = stokkart.fiyatlar.listFiyatlar.FirstOrDefault(u => u.stokid == l.stokid);
                    dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, "", l.urunAdi, l.alisFiyat, l2.fiyatTutari, l.kdv, l.kdvTipi, l.katNo, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, l.aktifmi, l.eklenmeTarihi, l.silindimi);
                }
            }
            catch
            {
            }
        }

        void ara_seriNo()
        {
            try
            {
                dgStokKart.Rows.Clear();
                var l = stokkart.bul_seriNo(txtSeriNo.Text);
                var l2 = stokkart.fiyatlar.listFiyatlar.FirstOrDefault(u => u.stokid == l.stokid);
                dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, "", l.urunAdi, l.alisFiyat, l2.fiyatTutari, l.kdv, l.kdvTipi, l.katNo, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, l.aktifmi, l.eklenmeTarihi, l.silindimi);
                //dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, "", l.urunAdi, l.alisFiyat, l.kdv, l.kdvTipi, l.katNo, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, l.aktifmi, l.eklenmeTarihi, l.silindimi);
            }
            catch
            {
            }
        }

        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSorgula_Click(sender, e);
            }
        }

        private void cmbSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanici, ComboboxItem.getSelectedValue(cmbSube));
        }

        private void satisFiyatiListele()
        {
            cmbGecerliSatisFiyati.Items.Clear();
            listFiyat.Clear();
            SqlDataReader dr = veri.getDatareader("Select fiyatid, fiyatAdi From tblFiyatTaslak Where firmaid = " + firma.firmaid + " and silindimi = '0' order by fiyatAdi asc");
            while (dr.Read())
            {
                listFiyat.Add(Convert.ToInt32(dr["fiyatid"]));
                cmbGecerliSatisFiyati.Items.Add(dr["fiyatAdi"].ToString());
            }
            for (int i = 0; i < listFiyat.Count; i++)
            {
                if (listFiyat[i] == Convert.ToInt32(ayarlar.Faturalı_Satış_Fiyatı))
                {
                    cmbGecerliSatisFiyati.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {

            double canliStok = 0;
            dgStokKart.Rows.Clear();
            if (txtBarkod.Text != "") { ara_barkod(); return; }
            else if (txtStokkodu.Text != "") { ara_stokkodu(); return; }
            else if (txtUrunKodu.Text != "") { ara_urunKodu(); return; }
            else if (cmbUrunAdi.Text != "") { ara_urunAdi(); return; }
            else if (txtSeriNo.Text != "") { ara_seriNo(); return; }
            else if (chbCanliStok.Checked)
            {
                dgStokKart.Columns["CanliStok"].Visible = true;
                listCanliStok.Clear();
                string sql = "SELECT t.stokid, round(SUM(t.miktar),3)  AS canliStok FROM tblTicaret AS t INNER JOIN tblTicaretAyrinti AS ta ON t.ticaretAyrintiid = ta.ticaretAyrintiid INNER JOIN tblFirmaSubeleri s ON s.subeid = ta.subeid Inner Join sorStokkart as sk On sk.stokid = t.stokid WHERE sk.silindimi = 0  and t.silindimi = '0' and t.firmaid = " + firma.firmaid + " GROUP BY t.stokid";
                SqlDataReader dr = veri.getDatareader(sql);
                while (dr.Read())
                {
                    listCanliStok.Add(new KeyValuePair<Int64, double>(Convert.ToInt64(dr["stokid"]), Convert.ToDouble(dr["canliStok"])));
                }
            }
            var l1 = stokkart.listStokkart.Where
            (u =>
              (cmbKategori.Text == "" || u.katNo == listeler.getKategoriNo()[cmbKategori.SelectedIndex]) &&
              (cmbMarkalar.Text == "" || u.markaid == listeler.getMarkano()[cmbMarkalar.SelectedIndex]) &&
              (cmbKdv.Text == "" || u.kdv == Convert.ToInt32(cmbKdv.Text)) &&
              (cmbKdvTipi.Text == "" || u.kdvTipi == cmbKdvTipi.Text) &&
              (txtRaf.Text == "" || u.rafAdi.StartsWith(txtRaf.Text)) &&
              (cmbSube.Text == "" || u.subeid == Convert.ToInt32(ComboboxItem.getSelectedValue(cmbSube))) &&
              (cmbKullanici.Text == "" || u.kullaniciid == Convert.ToInt32(ComboboxItem.getSelectedValue(cmbKullanici))) &&
              //(!chkindirimYapilanStokKartlari.Checked == true || u.indirim != 0) &&
              //(!chkindirimYapilanStokKartlari.Checked == false || u.indirim != 1) &&
              (!chkAktifmi.Checked == true || u.aktifmi == "0") &&
              (!chkAktifmi.Checked == false || u.aktifmi == "1") &&
              (!chkWebdeGosterilecek.Checked == true || u.webdeGosterilsinmi == "1") &&
              //(!chkWebdeGosterilecek.Checked == false || u.webdeGosterilsinmi == "0") &&
              (!chkSilinen.Checked == true || u.silindimi == "1") &&
              (!chkSilinen.Checked == false || u.silindimi == "0")

            ).OrderByDescending(u => u.stokid);
            string _silindimi = "Hayır", _aktifmi = "Evet", _barkod = "";
            double _birimFiyat = 0;
            foreach (stokkart.stokkartAyrinti l in l1)
            {
                if (l.aktifmi == "1") _aktifmi = "Evet";
                else _aktifmi = "Hayır";
                if (l.silindimi == "1") _silindimi = "Evet";
                else _silindimi = "Hayır";
                try
                {
                    int fiyatid = listFiyat[cmbGecerliSatisFiyati.SelectedIndex];
                    _birimFiyat = stokkart.fiyatlar.listFiyatlar.Where(u => u.indirimliFiyat != 0 && u.stokid == Convert.ToInt64(l.stokid) && u.fiyatid == fiyatid)
                        .OrderBy(u => u.indirimliFiyat).First().indirimliFiyat;
                }
                catch (Exception)
                {
                    _birimFiyat = 0;
                }
                try
                {
                    _barkod =
                        stokkart.birimler.listBirimler.Where(u => u.stokid == l.stokid && u.barkod.Length > 0)
                            .OrderByDescending(u => u.barkod)
                            .First()
                            .barkod;
                }
                catch (Exception h)
                {
                    _barkod = "";
                }

                try
                {
                    if (chbCanliStok.Checked && listCanliStok.Count>0)
                    {
                        canliStok = listCanliStok.Where(k => k.Key == l.stokid).First().Value;
                    }
                }
                catch (Exception exception)
                {
                    canliStok = 0;
                }
                dgStokKart.Rows.Add(l.stokid, l.stokkodu, l.rfidEtiketi, _barkod, l.urunAdi, l.alisFiyat, _birimFiyat, l.kdv, l.kdvTipi, l.katNo, canliStok, l.kategoriAdi, l.urunKodu, l.garantiSuresi, l.markaid, l.markaAdi, l.rafAdi, l.ayrinti, _aktifmi, l.mobil, l.vitrin, l.eklenmeTarihi, _silindimi);
            }

            lblKayitSayisi.Text = "Kayıt Sayısı:" + dgStokKart.Rows.Count.ToString();
        }

        private void listeyiYenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSorgula_Click(sender, e);
        }

        private void stokKartınıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Kart_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            if (MessageBox.Show(dgStokKart.CurrentRow.Cells["urunAdi"].Value.ToString() + " adlı Ürünü silmek istediğinizden emin misiniz ? ", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                veri.cmd("Exec spSilStokkart " + firma.firmaid + ", " + dgStokKart.CurrentRow.Cells["stokid"].Value.ToString() + ",'1' ");
                guncelle.stokkartVerileriniGuncelle();
                btnSorgula_Click(sender, e);
            }
        }

        private void silmeİşleminiGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!yetkiler.Stok_Kart_Sil)
                {
                    yetkiler.mesajVer();
                    return;
                }
                veri.getdatacell("Exec spSilStokkart " + firma.firmaid + ", " + dgStokKart.CurrentRow.Cells["stokid"].Value.ToString() + ",'0'");
                guncelle.stokkartVerileriniGuncelle();
                btnSorgula_Click(sender, e);
                MessageBox.Show("İşlem Başarılı");
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Başarılı değil" + hata.Message, firma.programAdi);
            }

        }

        private void stokKartınıPasifYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(dgStokKart.CurrentRow.Cells["urunAdi"].Value.ToString() + " adlı Ürünü Pasif hale getirmek istediğinizden emin misiniz ? ", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                veri.cmd("update tblStokkart set aktifmi = '0' where stokid = " + dgStokKart.CurrentRow.Cells["stokid"].Value.ToString() + " ");
                stokkart.setAktifmi(Convert.ToInt64(dgStokKart.CurrentRow.Cells["stokid"].Value), "0");
                btnSorgula_Click(sender, e);
            }
        }

        private void stokKartınıAktifYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("update tblStokkart set aktifmi = '1' where stokid = " + dgStokKart.CurrentRow.Cells["stokid"].Value.ToString() + " ");
            stokkart.setAktifmi(Convert.ToInt64(dgStokKart.CurrentRow.Cells["stokid"].Value), "1");
            btnSorgula_Click(sender, e);
        }

        private void webdeGösterilsinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(dgStokKart.CurrentRow.Cells["urunAdi"].Value.ToString() + " adlı Ürün Web Sitenizde Gösterilsin mi? ", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                veri.cmd("update tblStokkart set webdeGosterilsinmi = '1' where stokid = " + dgStokKart.CurrentRow.Cells["stokid"].Value.ToString() + " ");
                stokkart.setWebdeGosterilsinmi(Convert.ToInt64(dgStokKart.CurrentRow.Cells["stokid"].Value), "1");
                btnSorgula_Click(sender, e);
            }
        }

        private void webdeGösterilmesinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            veri.cmd("update tblStokkart set webdeGosterilsinmi = '0' where stokid = " + dgStokKart.CurrentRow.Cells["stokid"].Value.ToString() + " ");
            stokkart.setWebdeGosterilsinmi(Convert.ToInt64(dgStokKart.CurrentRow.Cells["stokid"].Value), "0");
            btnSorgula_Click(sender, e);
        }

        private void ayrıntılıDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Kart_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
            try
            {
                frmYeniAyrintiliStokkartEkle frm = new frmYeniAyrintiliStokkartEkle(Convert.ToInt64(dgStokKart.CurrentRow.Cells["stokid"].Value));
                frm.Show();
            }
            catch
            {
            }

        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Kart_Düzenle)
            {
                yetkiler.mesajVer();
                return;
            }
            try
            {
                frmStokKartEkle frm = new frmStokKartEkle(Convert.ToInt64(dgStokKart.CurrentRow.Cells["stokid"].Value));
                frm.Show();
            }
            catch
            {
            }
        }

        private void stokKartDetaylarınıGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow rw = veri.getdatarow("select stokid, rfidEtiketi, urunAdi, eklenmeTarihi, subeid, kullaniciid from sorStokkart where stokid = " + dgStokKart.CurrentRow.Cells["stokid"].Value + "");
            MessageBox.Show(rw["urunAdi"].ToString() + " Stok kartının ayrıntıları: \nStok ID: " + rw["stokid"].ToString() + "\nRFID Etiketi: " + rw["rfidEtiketi"].ToString() + "\nEklenme Tarihi: " + rw["eklenmeTarihi"].ToString() + "\nEkleyen Şube ID: " + rw["subeid"].ToString() + "\nKullanıcı ID: " + rw["kullaniciid"].ToString(), firma.programAdi, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKategoriSec_Click(object sender, EventArgs e)
        {
            frmKategoriSecimi frm = new frmKategoriSecimi();
            frm._frmStokKartlari = this;
            frm.Show();
        }

        private void btnBarkodYazdir_Click(object sender, EventArgs e)
        {
            frmStokkartBarkodYazdir frm = new frmStokkartBarkodYazdir();
            frm.Show();
        }
        rapor rpr;
        bool raporOlustur()
        {
            rpr = new rapor();
            rpr.sayfayiYatayYap();
            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 5;
            rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(4, y, rpr._kagitGenisligi - 8, rpr._kagitYuksekligi - y * 3 / 2));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Stok Kartı Listesi", new Font("Arial", 14, FontStyle.Bold), new Point(120, y)));
            y += 10;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Stok Kod", new Font("Arial", 9, FontStyle.Underline), new Point(4, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Barkod", new Font("Arial", 9, FontStyle.Underline), new Point(24, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ürün Adı", new Font("Arial", 9, FontStyle.Underline), new Point(44, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Alış F.", new Font("Arial", 9, FontStyle.Underline), new Rectangle(85, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Satış F.", new Font("Arial", 9, FontStyle.Underline), new Rectangle(105, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("%KDV", new Font("Arial", 9, FontStyle.Underline), new Point(125, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Tipi", new Font("Arial", 9, FontStyle.Underline), new Point(140, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kategori", new Font("Arial", 9, FontStyle.Underline), new Point(155, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Marka", new Font("Arial", 9, FontStyle.Underline), new Point(185, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Raf", new Font("Arial", 9, FontStyle.Underline), new Point(215, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Açıklama", new Font("Arial", 9, FontStyle.Underline), new Point(225, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kayıt T.", new Font("Arial", 9, FontStyle.Underline), new Point(260, y)));

            for (int i = 0; i < dgStokKart.Rows.Count; i++)
            {
                y += 4;
                DataGridViewRow dr = dgStokKart.Rows[i];
                rpr.ekleYazi(new rapor.yazi(dr.Cells["stokkodu"].Value.ToString(), new Rectangle(4, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["barkod1"].Value.ToString(), new Rectangle(24, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["urunAdi"].Value.ToString(), new Rectangle(44, y, 40, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["alisFiyat"].Value.ToString(), new Rectangle(85, y, 19, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["satisFiyat1"].Value.ToString(), new Rectangle(105, y, 19, 3), StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["kdv"].Value.ToString(), new Rectangle(125, y, 14, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["kdvTipi"].Value.ToString(), new Rectangle(140, y, 14, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["kategoriAdi"].Value.ToString(), new Rectangle(155, y, 29, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["markaAdi"].Value.ToString(), new Rectangle(185, y, 29, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["rafAdi"].Value.ToString(), new Rectangle(215, y, 9, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["ayrinti"].Value.ToString(), new Rectangle(225, y, 34, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["eklenmeTarihi"].Value.ToString(), new Rectangle(260, y, 29, 3), false));

                rpr.ekleCizgi(new rapor.cizgi(4, rpr._kagitGenisligi - 4, y, y));
            }
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(4, rpr._kagitGenisligi - 4, y, y));
            y += 4;

            rpr.ekleYazi(new rapor.yazi("Toplam Kayıt Sayısı: " + dgStokKart.Rows.Count.ToString() + "     Çıktı Tarihi: " + DateTime.Now.ToString() + "     |   www.elmaryazilim.com", new Point(4, y)));
            return true;
        }

        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {
            if (raporOlustur())
            { rpr.onizleme(); }
        }

        private void barkoduYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBarkodYazdir.PerformClick();
        }

        private void raporGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRaporGoruntule.PerformClick();
        }

        private void cmbUrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemMobil_Click(object sender, EventArgs e)
        {
            veri.cmd("update tblStokkart set mobil = '1' where stokid = " + dgStokKart.CurrentRow.Cells["stokid"].Value.ToString() + " ");
            stokkart.setMobilGosterilsinmi(Convert.ToInt64(dgStokKart.CurrentRow.Cells["stokid"].Value), true);

            btnSorgula_Click(sender, e);
        }

        private void toolStripMenuItemVitrin_Click(object sender, EventArgs e)
        {
            veri.cmd("update tblStokkart set vitrin='1' where stokid = " + dgStokKart.CurrentRow.Cells["stokid"].Value.ToString() + " ");
            stokkart.setVitrinGosterilsinmi(Convert.ToInt64(dgStokKart.CurrentRow.Cells["stokid"].Value), true);
            btnSorgula_Click(sender, e);
        }

        private void btnexcelaktar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Stok Kart Listesi.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dgStokKart, sfd.FileName);
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

        private void cmbGecerliSatisFiyati_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSorgula_Click(sender, e);
        }

    }
}