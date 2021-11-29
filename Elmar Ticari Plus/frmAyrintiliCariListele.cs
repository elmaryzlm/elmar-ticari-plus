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
    public partial class frmAyrintiliCariListele : Form
    {
        Form frm = null;
        long seciliCariid = 0;
        public frmAyrintiliCariListele(Form frm)
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgCariler);
            NesneGorselleri.kontrolEkle(panel3);
            if (frm != null)
            {
                dgCariler.Columns["sec"].Visible = true;
                dgCariler.MultiSelect = false;
                this.frm = frm;
            }
        }

        private void frmAyrintiliCariListele_Load(object sender, EventArgs e)
        {
            listeleriYukle();
            btnSorgula.PerformClick();
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
        public void cariListele()
        {
            dgCariler.Rows.Clear();
            var l1 = cariBilgileri.listCariBilgileri.Where
             (u =>
               (cmbCariGrubu.Text == "" || u.grupid == listeler.getCariGrupid()[cmbCariGrubu.SelectedIndex]) &&
               (cmbSube.Text == "" || u.subeid == Convert.ToInt32(ComboboxItem.getSelectedValue(cmbSube))) &&
               (cmbKullanici.Text == "" || u.kullaniciid == Convert.ToInt32(ComboboxItem.getSelectedValue(cmbKullanici))) &&
               (!chkAktifmi.Checked == true || u.hesabaislensinmi == "0") &&
               (!chkAktifmi.Checked == false || u.hesabaislensinmi == "1") &&
               (!chkWebdeGosterilecek.Checked == true || u.webdeGosterilsinmi == "1") &&
               (!chkSilinen.Checked == true || u.silindimi == "1") &&
               (!chkSilinen.Checked == false || u.silindimi == "0") &&
               (txtAdi.Text == "" || u.adi.StartsWith(txtAdi.Text)) &&
               (txtSoyadi.Text == "" || u.soyadi.StartsWith(txtSoyadi.Text)) &&
               (txtCariKodu.Text == "" || u.cariKodu == txtCariKodu.Text) &&
               (txtTcNo.Text == "" || u.tcNo == txtTcNo.Text)
             );
            foreach (cariBilgileri.cariBilgileriAyrinti l in l1)
            {
                string adres = "";
                try
                {

                    adres = cariBilgileri.adresBilgileri.listAdresBilgileri.Where(c => c.cariid == l.cariid).First()
                         .adres;
                }
                catch (Exception e)
                {
                    adres = "";
                }

                dgCariler.Rows.Add("Seç", l.cariid, l.cariKodu, l.adi, l.soyadi, String.Format("{0:n2}", Math.Abs(l.bakiye)) + " " + l.bakiyeDurumu, l.vergiDaire, l.vergiNo, adres, l.tcNo, l.grupid, l.guzergahid, l.rfidkartNo, l.paraBirimi, l.limit, l.hatirlatmaGunu, l.cariAciklamasi, l.webdeGosterilsinmi, l.cinsiyet, l.plaka, l.resim, "Resim", l.engellimi, l.hesabaislensinmi, l.webdeGosterilsinmi, l.eklenmeTarihi, l.subeid, l.kullaniciid, "Düzenle");
            }
            lblKayitSayisi.Text = "Kayıt Sayısı: " + dgCariler.Rows.Count.ToString();
            dgCariler.ClearSelection();
            seciliCariid = 0;
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            cariListele();
        }

        private void dgCariler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seciliCariid = Convert.ToInt64(dgCariler.CurrentRow.Cells["cariid"].Value);
                if (e.ColumnIndex == dgCariler.Columns["sec"].Index && frm != null)
                {
                    if (frm.Name == "frmCariKartislemleri") ((frmCariKartislemleri)frm).cmbCariler.Text = dgCariler.CurrentRow.Cells["adi"].Value.ToString() + " " + dgCariler.CurrentRow.Cells["soyadi"].Value.ToString();
                    else if (frm.Name == "frmTicaret") ((frmTicaret)frm).cmbCariListesi.Text = dgCariler.CurrentRow.Cells["adi"].Value.ToString() + " " + dgCariler.CurrentRow.Cells["soyadi"].Value.ToString();
                    frm.Activate();
                    frm.Select();
                    frm.BringToFront();
                    this.Close();
                }
                if (e.ColumnIndex == dgCariler.Columns["duzenle"].Index)
                {
                    frmCariKartEkle frm2 = new frmCariKartEkle();
                    frm2.cariid = Convert.ToInt64(dgCariler.CurrentRow.Cells["cariid"].Value);
                    frm2.Show();
                    frm2.Select();
                }
            }
            catch
            {
                dgCariler.ClearSelection();
                seciliCariid = 0;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            if (seciliCariid == 0)
            {
                MessageBox.Show("Listeden birc cari seçin", firma.programAdi);
                return;
            }
            veri.cmd("Exec spSilCari " + firma.firmaid + ", " + seciliCariid + ", '1'");
            MessageBox.Show("Cari Silindi.", firma.programAdi);
            guncelle.cariBilgileriVerileriniGuncelle();
            listeler.yukleCariadi();
            btnSorgula.PerformClick();
        }

        private void btnSilmeislleminiGeriAl_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Sil)
            {
                yetkiler.mesajVer();
                return;
            }
            if (seciliCariid == 0)
            {
                MessageBox.Show("Listeden birc cari seçin", firma.programAdi);
                return;
            }
            veri.cmd("Exec spSilCari " + firma.firmaid + ", " + seciliCariid + ", '0'");
            MessageBox.Show("Silme İşlemi Geri Alındı.", firma.programAdi);
            guncelle.cariBilgileriVerileriniGuncelle();
            listeler.yukleCariadi();
            btnSorgula.PerformClick();
        }

        private void btnPafislestir_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Hesabını_Durdurma)
            {
                yetkiler.mesajVer();
                return;
            }
            if (seciliCariid == 0)
            {
                MessageBox.Show("Listeden birc cari seçin", firma.programAdi);
                return;
            }
            veri.cmd("Update tblCariBilgileri set hesabaislensinmi = 0 Where firmaid = " + firma.firmaid + " and cariid = " + seciliCariid + "");
            MessageBox.Show("Cari Pasifleştirildi. Artık raporlara ve kasaya etki etmeyecektir.", firma.programAdi);
            guncelle.cariBilgileriVerileriniGuncelle();
            listeler.yukleCariadi();
            btnSorgula.PerformClick();
        }

        private void btnAktiflestir_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Cari_Hesabını_Durdurma)
            {
                yetkiler.mesajVer();
                return;
            }
            if (seciliCariid == 0)
            {
                MessageBox.Show("Listeden birc cari seçin", firma.programAdi);
                return;
            }
            veri.cmd("Update tblCariBilgileri set hesabaislensinmi = 1 Where firmaid = " + firma.firmaid + " and cariid = " + seciliCariid + "");
            MessageBox.Show("Cari Aktifleştirtildi.", firma.programAdi);
            guncelle.cariBilgileriVerileriniGuncelle();
            listeler.yukleCariadi();
            btnSorgula.PerformClick();
        }

        private void btnRaporGoruntule_Click(object sender, EventArgs e)
        {
            if (raporOlustur())
            { rpr.onizleme(); }
        }
        rapor rpr;
        bool raporOlustur()
        {
            rpr = new rapor();
            rpr.sayfayiYatayYap();
            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 5;
            rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(4, y, rpr._kagitGenisligi - 8, rpr._kagitYuksekligi - y * 3 / 2));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Ayrıntılı Cari Listesi", new Font("Arial", 14, FontStyle.Bold), new Point(120, y)));
            y += 10;
            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Kod", new Font("Arial", 9, FontStyle.Underline), new Point(4, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Adı", new Font("Arial", 9, FontStyle.Underline), new Point(24, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Soyadı", new Font("Arial", 9, FontStyle.Underline), new Point(54, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Bakiye", new Font("Arial", 9, FontStyle.Underline), new Point(84, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("V.D.", new Font("Arial", 9, FontStyle.Underline), new Point(114, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("V.No", new Font("Arial", 9, FontStyle.Underline), new Point(134, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("TC No", new Font("Arial", 9, FontStyle.Underline), new Point(154, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Doviz", new Font("Arial", 9, FontStyle.Underline), new Point(174, y)));
            //rpr.ekleSabitYazi(new rapor.sabitYazi("Limit", new Font("Arial", 9, FontStyle.Underline), new Rectangle(180, y, 19, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Açıklama", new Font("Arial", 9, FontStyle.Underline), new Point(190, y)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kayıt T.", new Font("Arial", 9, FontStyle.Underline), new Point(260, y)));

            for (int i = 0; i < dgCariler.Rows.Count; i++)
            {
                y += 4;
                DataGridViewRow dr = dgCariler.Rows[i];
                rpr.ekleYazi(new rapor.yazi(dr.Cells["cariKodu"].Value.ToString(), new Rectangle(4, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["adi"].Value.ToString(), new Rectangle(24, y, 29, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["soyadi"].Value.ToString(), new Rectangle(54, y, 29, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["bakiye"].Value.ToString(), new Rectangle(84, y, 29, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["vergiDaire"].Value.ToString(), new Rectangle(114, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["vergiNo"].Value.ToString(), new Rectangle(134, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["tcNo"].Value.ToString(), new Rectangle(154, y, 19, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["paraBirimi"].Value.ToString(), new Rectangle(174, y, 14, 3), false));
                //rpr.ekleYazi(new rapor.yazi(dr.Cells["limit"].Value.ToString(), new Rectangle(180, y, 19, 3),StringFormatFlags.DirectionRightToLeft, false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["cariAciklamasi"].Value.ToString(), new Rectangle(190, y, 69, 3), false));
                rpr.ekleYazi(new rapor.yazi(dr.Cells["eklenmeTarihi"].Value.ToString(), new Rectangle(260, y, 24, 3), false));

                rpr.ekleCizgi(new rapor.cizgi(4, rpr._kagitGenisligi - 4, y, y));
            }
            y += 4;
            rpr.ekleCizgi(new rapor.cizgi(4, rpr._kagitGenisligi - 4, y, y));
            y += 4;

            rpr.ekleYazi(new rapor.yazi("Toplam Kayıt Sayısı: " + dgCariler.Rows.Count.ToString() + "     Çıktı Tarihi: " + DateTime.Now.ToString() + "     |   www.elmaryazilim.com", new Point(4, y)));
            return true;
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (raporOlustur())
            { rpr.yazdir(); }
        }
        System.Globalization.CultureInfo original_Language = System.Threading.Thread.CurrentThread.CurrentCulture;
        private void btnexcelaktar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Cari Listesi.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToCsV(dgCariler, sfd.FileName);
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
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
