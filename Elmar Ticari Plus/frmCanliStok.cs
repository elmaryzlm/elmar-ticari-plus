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
using System.Windows.Controls;
using Control = System.Windows.Forms.Control;

namespace Elmar_Ticari_Plus
{
    public partial class frmCanliStok : Form
    {
        private bool stokSayimFormu = false;
        public frmCanliStok(bool stokSayim)
        {
            baslangic();
            if (stokSayim)
            {
                this.Text = "Canlı Stok Sayım Modülü";
                pnlUst.Visible = true;
                dgCanliStok.Columns["sayilanCanliStok"].Visible = true;
                dgCanliStok.Columns["fark"].Visible = true;
                sorgula();
                stokSayimFormu = true;
                dgCanliStok.MultiSelect = true;
                try { cmbUrunAdi.Items.AddRange(listeler.getUrunisim()); }
                catch { }
                farkHesapla();
            }
            else
            {
                sorgula();
            }
        }

        private void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgCanliStok);
            NesneGorselleri.kontrolEkle(groupBox2);
            NesneGorselleri.kontrolEkle(grpİslemTarihi);
            listeler.doldurSube(cmbSubeler);
            try { cmbKategori.Items.AddRange(listeler.getKategoriadi()); }
            catch { }
            try { comboBox1.Items.AddRange(listeler.getUrunisim()); }
            catch { }
        }

        private void frmCanliStok_Load(object sender, EventArgs e)
        {
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            sorgula();
        }

        private void sorgula()
        {

            if (stokSayimFormu == true)
            {
                if (MessageBox.Show("Canlı stok listesini yenilediğinizde, 'Sayılan' sütunundaki verilerde sıfırlanacaktır. Devam etek istiyor musunuz?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }
            dgCanliStok.Rows.Clear();
            dgCanliStok.Columns["islemTarihi"].Visible = true;
            dgCanliStok.Columns["subeAdi"].Visible = true;

            string anaSorgu = "";
            string havingMetni = "";
            string islemTarihiMetni = "";
            string subeMetni = "";

            //Şube sorgusu oluşturuluyor-------------------------------
            if (cmbSubeler.SelectedIndex > -1)
            {
                anaSorgu = " and ta.subeid = " + ComboboxItem.getSelectedValue(cmbSubeler) + "";
                subeMetni = ",s.subeAdi";
            }
            //İşlem Türü Sorguları Oluşturuluyor----------------------
            string altSorgu = " ";
            if (chkFaturasizislemler.Checked == false && chkİadeİslemleri.Checked == false && chkFaturaliİslemler.Checked == false) altSorgu = " and ta.islemTuru = 'hiçbirinigetirme' ";
            else if (chkFaturasizislemler.Checked == true && chkİadeİslemleri.Checked == true && chkFaturaliİslemler.Checked == true) altSorgu = " ";
            else
            {
                if (chkFaturasizislemler.Checked == true) altSorgu = altSorgu + " or ta.islemTuru like '%Faturasız%' or ta.islemTuru like '%Transfer%'";
                if (chkİadeİslemleri.Checked == true) altSorgu = altSorgu + " or ta.islemTuru like '%İade%'";
                if (chkFaturaliİslemler.Checked == true) altSorgu = altSorgu + " or ta.islemTuru like '%Faturalı%'";
                altSorgu = "  and (" + altSorgu.Substring(4) + ")";
            }
            anaSorgu = anaSorgu + altSorgu;

            //canli stok miktarı sorgusu oluşturuluyor----------------
            if (cmbCanliStokMiktari.SelectedIndex > 0) havingMetni = " Having SUM(t.miktar*t.katsayi)  " + cmbCanliStokMiktari.Text + " '" + txtCanliStokMiktari.Text.Replace(".", "").Replace(",", ".") + "' ";
            //İşlem tarihi sorgusu oluşturuluyor----------------
            if (chkİslemTarihi.Checked)
            {
                anaSorgu = anaSorgu + " and (islemTarihi between '" + dtİslemTarihi1.Value + "' and '" + dtİslemTarihi2.Value + "')";
                islemTarihiMetni = ", ta.islemTarihi";
            }

            if (comboBox1.Text != "") anaSorgu = anaSorgu + " and sk.stokid=" + listeler.getStokid()[comboBox1.SelectedIndex] + "";
            if (textBox1.Text != "") anaSorgu = anaSorgu + " and t.barkod='" + textBox1.Text + "'";
            if (cmbKategori.Text!= "") anaSorgu = anaSorgu + " and sk.katNo='" + listeler.getKategoriNo()[cmbKategori.SelectedIndex]+"'";
            //Web kayıtları sorgusu oluşturuluyor--------------
            if (chkWebKayitlariniGoster.Checked) anaSorgu = anaSorgu + " and ta.ortam like '%web%' ";
            anaSorgu = anaSorgu + " and ta.islemTuru not in ('Teklif','Sipariş')";
            string sql = "SELECT t.stokid, sk.urunAdi, sk.alisFiyat, round(SUM(t.miktar),3)  AS canliStok,round(SUM(t.miktar),3)*sk.alisFiyat*t.katsayi as maliyet, t.satilanMiktar, t.birim, t.katsayi, t.firmaid" + subeMetni + " " + islemTarihiMetni + " FROM tblTicaret AS t INNER JOIN tblTicaretAyrinti AS ta ON t.ticaretAyrintiid = ta.ticaretAyrintiid INNER JOIN tblFirmaSubeleri s ON s.subeid = ta.subeid Inner Join sorStokkart as sk On sk.stokid = t.stokid WHERE sk.silindimi = 0  and t.silindimi = '0' and t.firmaid = " + firma.firmaid + anaSorgu + " GROUP BY t.stokid, sk.urunAdi, t.satilanMiktar,sk.alisFiyat, t.birim, t.katsayi, t.firmaid" + subeMetni + "" + islemTarihiMetni + havingMetni;
            SqlDataReader dr = veri.getDatareader(sql);
            double topMaliyet = 0, topHasilat = 0, topKarZarar = 0, _maliyet = 0, _hasilat = 0, _karZarar = 0;
            while (dr.Read())
            {
                try
                {
                    _maliyet = Convert.ToDouble(dr["maliyet"]);
                    topMaliyet += _maliyet;
                }
                catch { }

                try
                {
                    _hasilat =
                    stokkart.fiyatlar.listFiyatlar.Where(
                        u => u.indirimliFiyat != 0 && u.stokid == Convert.ToInt64(dr["stokid"])).OrderBy(u => u.indirimliFiyat).First().indirimliFiyat * Convert.ToDouble(dr["canliStok"]);
                    topHasilat += _hasilat;
                }
                catch { }
                _karZarar = _hasilat - _maliyet;
                topKarZarar += _karZarar;

                dgCanliStok.Rows.Add(dr["stokid"].ToString(), "", dr["urunAdi"].ToString(), Convert.ToDouble(dr["alisFiyat"]), "", dr["canliStok"].ToString(), dr["birim"].ToString(), (Convert.ToDouble(dr["canliStok"]) * Convert.ToDouble(dr["katsayi"])).ToString() + " Birim", 0, 0, dr["maliyet"].ToString(), _hasilat, _karZarar);
                if (islemTarihiMetni != "") dgCanliStok.Rows[dgCanliStok.Rows.Count - 1].Cells["islemTarihi"].Value = dr["islemTarihi"].ToString().Substring(0, 10);
                if (subeMetni != "") dgCanliStok.Rows[dgCanliStok.Rows.Count - 1].Cells["subeAdi"].Value = dr["subeAdi"].ToString();
            }
            lblKayitSayisi3.Text = dgCanliStok.Rows.Count.ToString();
            lblTopMaliyet.Text = String.Format("{0:n2}", topMaliyet);
            lblTopHasilat.Text = String.Format("{0:n2}", topHasilat);
            lblTopKarZarar.Text = String.Format("{0:n2}", topKarZarar);

            if (chkİslemTarihi.Checked == false) dgCanliStok.Columns["islemTarihi"].Visible = false;
            if (cmbSubeler.SelectedIndex == -1) dgCanliStok.Columns["subeAdi"].Visible = false;
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        rapor rpr;
        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {
            try
            {
                if (stokSayimFormu) raporHazirlaStokSayim();
                else raporHazirla();
                rpr.onizleme();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void raporHazirla()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = 290;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Canlı Stok Raporu", new Font("Arial", 15, FontStyle.Bold), new Point(80, 5)));

            //rpr.ekleSabitYazi(new rapor.sabitYazi("Barkod", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 34, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ürün Adı", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 69, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Canlı Stok", new Font("Arial", 10, FontStyle.Underline), new Rectangle(75, 15, 24, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Maliyet", new Font("Arial", 10, FontStyle.Underline), new Rectangle(100, 15, 24, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Hasılat", new Font("Arial", 10, FontStyle.Underline), new Rectangle(125, 15, 24, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kâr-Zarar", new Font("Arial", 10, FontStyle.Underline), new Rectangle(150, 15, 24, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Şube", new Font("Arial", 10, FontStyle.Underline), new Rectangle(175, 15, 30, 4), false));
            for (int i = 0; i < dgCanliStok.Rows.Count; i++)
            {
                DataGridViewRow r = dgCanliStok.Rows[i];
                //rpr.ekleYazi(new rapor.yazi(r.Cells["barkod"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(2, 20 + i * 4, 27, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["urunAdi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(5, 20 + i * 4, 69, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["canliStok"].Value.ToString() + " " + r.Cells["birim"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(75, 20 + i * 4, 24, 4), false));
                rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", Convert.ToDouble(r.Cells["maliyet"].Value)), new Font("Arial", 9, FontStyle.Regular), new Rectangle(100, 20 + i * 4, 24, 4), true));
                rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", Convert.ToDouble(r.Cells["hasilat"].Value)), new Font("Arial", 9, FontStyle.Regular), new Rectangle(125, 20 + i * 4, 24, 4), true));
                rpr.ekleYazi(new rapor.yazi(String.Format("{0:n2}", Convert.ToDouble(r.Cells["karZarar"].Value)), new Font("Arial", 9, FontStyle.Regular), new Rectangle(150, 20 + i * 4, 24, 4), true));
                rpr.ekleYazi(new rapor.yazi(r.Cells["subeAdi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(175, 20 + i * 4, 30, 4), false));
                //rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, 20 + i * 4, 20 + i * 4));
            }
            int yukseklik = 25 + dgCanliStok.Rows.Count * 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik += 1;
            rpr.ekleYazi(new rapor.yazi("Toplam Maliyet: " + lblTopMaliyet.Text + " TL", new Font("Arial", 9, FontStyle.Regular), new Rectangle(5, yukseklik, 50, 4), false));
            rpr.ekleYazi(new rapor.yazi("Toplam Hasılat: " + lblTopHasilat.Text + " TL", new Font("Arial", 9, FontStyle.Regular), new Rectangle(60, yukseklik, 50, 4), false));
            rpr.ekleYazi(new rapor.yazi("Toplam Kâr-Zarar: " + lblTopKarZarar.Text + " TL", new Font("Arial", 9, FontStyle.Regular), new Rectangle(120, yukseklik, 50, 4), false));

            yukseklik += 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik += 3;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + dgCanliStok.Rows.Count.ToString() + "       Yazdırma Tarihi: " + DateTime.Now.ToString() + "       www.elmaryazilim.com", new Point(5, yukseklik)));
        }

        private void raporHazirlaStokSayim()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = 290;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Stok Sayım Raporu", new Font("Arial", 15, FontStyle.Bold), new Point(80, 5)));

            //rpr.ekleSabitYazi(new rapor.sabitYazi("Barkod", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 34, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ürün Adı", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 89, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Canlı Stok", new Font("Arial", 10, FontStyle.Underline), new Rectangle(95, 15, 34, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Sayılan", new Font("Arial", 10, FontStyle.Underline), new Rectangle(130, 15, 24, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Fark", new Font("Arial", 10, FontStyle.Underline), new Rectangle(155, 15, 24, 4), false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Şube", new Font("Arial", 10, FontStyle.Underline), new Rectangle(180, 15, 25, 4), false));
            for (int i = 0; i < dgCanliStok.Rows.Count; i++)
            {
                DataGridViewRow r = dgCanliStok.Rows[i];
                //rpr.ekleYazi(new rapor.yazi(r.Cells["barkod"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(2, 20 + i * 4, 27, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["urunAdi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(5, 20 + i * 4, 89, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["canliStok"].Value.ToString() + " " + r.Cells["birim"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(95, 20 + i * 4, 34, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["sayilanCanliStok"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(130, 20 + i * 4, 24, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["fark"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(155, 20 + i * 4, 24, 4), false));
                rpr.ekleYazi(new rapor.yazi(r.Cells["subeAdi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(180, 20 + i * 4, 25, 4), false));
                //rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, 20 + i * 4, 20 + i * 4));
            }
            int yukseklik = 25 + dgCanliStok.Rows.Count * 4;
            rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik += 1;
            rpr.ekleYazi(new rapor.yazi("Kayıt Sayısı: " + dgCanliStok.Rows.Count.ToString() + "       Yazdırma Tarihi: " + DateTime.Now.ToString() + "       www.elmaryazilim.com", new Point(5, yukseklik)));
        }

        private stokkart.stokkartAyrinti urunBilgisi;
        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMiktar1.Select();
            }
        }

        private void urunAra(object sender)
        {
            Control sndr = (Control)sender;
            string _miktar = "0";
            if (sndr.Name == "txtBarkod")
            {
                urunBilgisi = stokkart.bul_barkod(txtBarkod.Text);
                _miktar = txtMiktar1.Text;
            }
            else if (sndr.Name == "cmbUrunAdi")
            {
                urunBilgisi = stokkart.bul_urunAdi(cmbUrunAdi.Text);
                _miktar = txtMiktar2.Text;
            }
            try
            {
                if (urunBilgisi.silindimi == "1")
                {
                    MessageBox.Show("Böyle bir stok kartı bulunamadı.", firma.programAdi);
                    return;
                }
                else if (urunBilgisi.aktifmi == "0")
                {
                    MessageBox.Show("Bu stok kartı devre dışı bırakılmış satılamaz.", firma.programAdi);
                    return;
                }
                urunuDataGrideEkle(txtBarkod.Text, _miktar);
                if (sndr.Name != "txtBarkod") txtBarkod.Text = "";
            }
            catch (Exception hata)
            {
                if (txtBarkod.Text.StartsWith("27"))
                {
                    try
                    {
                        urunBilgisi = stokkart.bul_stokid(Convert.ToInt64((txtBarkod.Text.Substring(2, 5))));
                        _miktar = (Convert.ToDouble(txtBarkod.Text.Substring(7, 6)) / 10000).ToString();
                        urunuDataGrideEkle(txtBarkod.Text, _miktar);
                    }
                    catch { }
                }
                else if (MessageBox.Show("Ürün bulunamadı. Eklemek ister misiniz?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    frmStokKartEkle frm = new frmStokKartEkle();
                    frm.Show();
                }
            }
        }
        private void urunuDataGrideEkle(string pBarkod, string pMiktar)
        {
            dgCanliStok.ClearSelection();
            bool foraGirdmi = false;
            //Daha önce eklenmişmi diye bakılıyor.
            for (int i = 0; i < dgCanliStok.Rows.Count; i++)
            {
                if (dgCanliStok.Rows[i].Cells["stokid"].Value.ToString() == urunBilgisi.stokid.ToString())
                {
                    dgCanliStok.Rows[i].Cells["sayilanCanliStok"].Value = (Convert.ToDouble(dgCanliStok.Rows[i].Cells["sayilanCanliStok"].Value) + Convert.ToDouble(pMiktar)).ToString();
                    dgCanliStok.Rows[i].Selected = true;
                    try { dgCanliStok.Rows[i].Cells["sayilanCanliStok"].Selected = true; }
                    catch { }
                    foraGirdmi = true;
                }
            }

            if (foraGirdmi == false)
            {
                //Datagride ekleniyor.
                dgCanliStok.Rows.Add(urunBilgisi.stokid, "", urunBilgisi.urunAdi, urunBilgisi.alisFiyat, 0, "Adet", "0 Birim", pMiktar, 0, 0, 0);

                dgCanliStok.Rows[dgCanliStok.Rows.Count - 1].Selected = true;
                try { dgCanliStok.Rows[dgCanliStok.Rows.Count - 1].Cells["sayilanCanliStok"].Selected = true; }
                catch { }
            }
            farkHesapla();
        }

        private void farkHesapla()
        {
            for (int i = 0; i < dgCanliStok.Rows.Count; i++)
            {
                DataGridViewRow r = dgCanliStok.Rows[i];
                r.Cells["fark"].Value = Convert.ToDouble(r.Cells["canliStok"].Value) - Convert.ToDouble(r.Cells["sayilanCanliStok"].Value);
                if (Convert.ToDouble(r.Cells["fark"].Value) == 0) r.Cells["fark"].Style.BackColor = Color.LightGreen;
                else r.Cells["fark"].Style.BackColor = Color.PaleVioletRed;
                r.Cells["canliStok"].Style.BackColor = Color.LawnGreen;
                r.Cells["sayilanCanliStok"].Style.BackColor = Color.LightSkyBlue;
            }
        }


        private void cmbUrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMiktar2.Select();
        }

        private void dgCanliStok_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgCanliStok.Columns["sayilanCanliStok"].Index) farkHesapla();
            }
            catch { }
        }

        private void txtMiktar1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                urunAra(txtBarkod);
                txtMiktar1.Text = "0";
                txtBarkod.Select();
            }
        }

        private void txtMiktar2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                urunAra(cmbUrunAdi);
                txtMiktar2.Text = "0";
                cmbUrunAdi.Select();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Canlı Stok Listesi.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dgCanliStok, sfd.FileName);
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
            MessageBox.Show("Aktarın bitti", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSorgula_Click(sender, e);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSorgula_Click(sender, e);
            }
        }
    }
}