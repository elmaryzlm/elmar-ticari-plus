using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace Elmar_Ticari_Plus
{
    public partial class frmTeraziyeStokGonder : Form
    {
        public frmTeraziyeStokGonder()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgUrunListesi1);
            NesneGorselleri.dataGridView(dgUrunListesi2);
            NesneGorselleri.kontrolEkle(panel2);
            NesneGorselleri.kontrolEkle(panel3);
            NesneGorselleri.kontrolEkle(panel4);
        }

        private void ExcelDosyasiOlustur()
        {
            //var ExcelNesnesi = new Excel.Application();
            //ExcelNesnesi.Workbooks.Open(Application.StartupPath + @"\TeraziTaslak.xls");
            //ExcelNesnesi.Visible = false;
            //Excel._Worksheet tablo =(Excel.Worksheet)ExcelNesnesi.ActiveSheet;
            //Excel.Range hucre;
            //try
            //{
            //    btnExceleDosyaGonder.Enabled = false;
            //    for (int i = 0; i < dgUrunListesi2.Rows.Count; i++)
            //    {

            //        DataGridViewRow dr = dgUrunListesi2.Rows[i];
            //        //PLU No Yazılıyor
            //        hucre = tablo.get_Range("C" + (i + 2).ToString(), System.Reflection.Missing.Value);
            //        hucre.set_Value(System.Reflection.Missing.Value, dr.Cells["pluNo2"].Value.ToString());

            //        //Ürün Adı Yazılıyor
            //        hucre = tablo.get_Range("E" + (i + 2).ToString(), System.Reflection.Missing.Value);
            //        hucre.set_Value(System.Reflection.Missing.Value, dr.Cells["urunAdi2"].Value.ToString());
            //        //Stokid(itemcode) yazılıyor
            //        hucre = tablo.get_Range("H" + (i + 2).ToString(), System.Reflection.Missing.Value);
            //        hucre.set_Value(System.Reflection.Missing.Value, dr.Cells["stokid2"].Value.ToString());
            //        //Birim Fiyat yazılıyor
            //        hucre = tablo.get_Range("I" + (i + 2).ToString(), System.Reflection.Missing.Value);
            //        hucre.set_Value(System.Reflection.Missing.Value, dr.Cells["birimFiyat2"].Value.ToString());

            //    }
            //    string yol = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //    ExcelNesnesi.DefaultFilePath = Application.StartupPath;
            //    ExcelNesnesi.ActiveWorkbook.SaveAs(yol + @"\TeraziYeni.xls");
            //    ExcelNesnesi.Workbooks.Close();
            //    GC.Collect();
            //    MessageBox.Show("Aktarım tamamlandı. Dosya Yolu: Masaüstü", firma.programAdi);
            //}
            //catch (Exception hata)
            //{
            //    MessageBox.Show("Aktarım Hatası\nHata:" + hata.Message + "\nExcel dosyası açıksa dosyayı kapatın.", firma.programAdi);
            //}
            //btnExceleDosyaGonder.Enabled = true;
        }
     
        private void urunListele(string urunAdi)
        {
            if (seciliFiyatID == 0)
            {
                MessageBox.Show("Geçerli bir fiyat türü seçin", firma.programAdi);
                cmbFiyatTuru.Select();
                return;
            }
            dgUrunListesi1.Rows.Clear();
            var urunListesi = stokkart.listStokkart.Where(u =>
                    u.silindimi == "0" &&
                    u.aktifmi == "1" &&
                    (txtUrunAdi.Text == "" || u.urunAdi.Contains(txtUrunAdi.Text)) &&
                    (cmbKategori.Text == "" || u.katNo == listeler.getKategoriNo()[cmbKategori.SelectedIndex])
                    ).OrderBy(u => u.urunAdi);
            foreach (var i in urunListesi)
            {
                double birimFiyat = stokkart.fiyatlar.getFiyatTutari(seciliFiyatID, i.stokid);
                dgUrunListesi1.Rows.Add(i.stokid, i.stokkodu, i.urunAdi, birimFiyat, "Ekle");
            }
        }

        private void teraziGecmisiniListele()
        {
            dgUrunListesi2.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select * from tblTeraziUrunGecmisi Where firmaid = " + firma.firmaid + " And subeid = " + firma.subeid + " Order by pluNo asc");
            while (dr.Read())
            {
                if (Convert.ToInt32(dr["pluNo"]) > pluNoSayaci) pluNoSayaci = Convert.ToInt32(dr["pluNo"]);
                dgUrunListesi2.Rows.Add(dr["pluNo"].ToString(), dr["stokid"].ToString(), dr["urunAdi"].ToString(), dr["birimFiyat"].ToString(), "Çıkar");
            }
            pluNoSayaci++;

        }

        private int seciliFiyatID = 0;

        private void frmTeraziyeStokGonder_Load(object sender, EventArgs e)
        {
            satisFiyatiListele();
            try { cmbKategori.Items.AddRange(listeler.getKategoriadi()); } catch { }
            urunListele("");
            teraziGecmisiniListele();
        }

        List<int> listSatisFiyatlari = new List<int>();

        void satisFiyatiListele()
        {
            cmbFiyatTuru.Items.Clear();
            listSatisFiyatlari.Clear();
            SqlDataReader dr = veri.getDatareader("Select fiyatid, fiyatAdi From tblFiyatTaslak Where firmaid = " + firma.firmaid + " and silindimi = '0' order by fiyatAdi asc");
            while (dr.Read())
            {
                listSatisFiyatlari.Add(Convert.ToInt32(dr["fiyatid"]));
                cmbFiyatTuru.Items.Add(dr["fiyatAdi"].ToString());
            }
            if (cmbFiyatTuru.Items.Contains("Satış Fiyatı 1")) cmbFiyatTuru.Text = "Satış Fiyatı 1";
            else cmbFiyatTuru.SelectedIndex = 0;

        }

        private void txtUrunAdi_TextChanged(object sender, EventArgs e)
        {
            urunListele(txtUrunAdi.Text);
        }

        private int pluNoSayaci = 1;
        private void dgUrunListesi1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgUrunListesi1.Columns["btnEkle"].Index)
            {
                int urunVarmi = -1;
                for (int i = 0; i < dgUrunListesi2.Rows.Count; i++)
                {
                    if (dgUrunListesi2.Rows[i].Cells["stokid2"].Value.ToString() ==
                        dgUrunListesi1.CurrentRow.Cells["stokid1"].Value.ToString())
                    {
                        urunVarmi = i;
                        break;
                    }
                }
                if (urunVarmi >= 0)
                {
                    dgUrunListesi2.Rows[urunVarmi].Cells["stokid2"].Selected = true;
                    MessageBox.Show("Bu ürün zaten aktarılmış.", firma.programAdi);
                }
                else
                {
                    veri.cmd("Exec spSetTeraziGecmisi '" + pluNoSayaci + "', '" + dgUrunListesi1.CurrentRow.Cells["stokid1"].Value.ToString() + "', '" + dgUrunListesi1.CurrentRow.Cells["urunAdi1"].Value.ToString() + "', '" + dgUrunListesi1.CurrentRow.Cells["birimFiyat1"].Value.ToString().Replace(",", ".") + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");
                    dgUrunListesi2.Rows.Add(pluNoSayaci++, dgUrunListesi1.CurrentRow.Cells["stokKodu"].Value.ToString(), dgUrunListesi1.CurrentRow.Cells["stokid1"].Value.ToString(), dgUrunListesi1.CurrentRow.Cells["urunAdi1"].Value.ToString(), dgUrunListesi1.CurrentRow.Cells["birimFiyat1"].Value.ToString(), "Çıkar");
                    dgUrunListesi1.Rows.Remove(dgUrunListesi1.CurrentRow);
                }
            }
        }

        private void dgUrunListesi2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgUrunListesi2.Columns["btnCikar"].Index)
            {
                veri.cmd("Delete from tblTeraziUrunGecmisi Where firmaid = " + firma.firmaid + " And subeid = " + firma.subeid + " And stokid = " + dgUrunListesi2.CurrentRow.Cells["stokid2"].Value.ToString() + "");
                dgUrunListesi2.Rows.Remove(dgUrunListesi2.CurrentRow);
            }
        }

        private void btnExceleDosyaGonder_Click(object sender, EventArgs e)
        {
            ExcelDosyasiOlustur();
        }

        private void cmbFiyatTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciliFiyatID = listSatisFiyatlari[cmbFiyatTuru.SelectedIndex];
            urunListele(txtUrunAdi.Text);
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunListele(txtUrunAdi.Text);
        }

        private void dgUrunListesi2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                veri.cmd("Exec spSetTeraziGecmisi '" + dgUrunListesi2.CurrentRow.Cells["pluNo2"].Value.ToString() + "', '" + dgUrunListesi2.CurrentRow.Cells["stokid2"].Value.ToString() + "', '" + dgUrunListesi2.CurrentRow.Cells["urunAdi2"].Value.ToString() + "', '" + dgUrunListesi2.CurrentRow.Cells["birimFiyat2"].Value.ToString().Replace(',', '.') + "', " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + "");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dosyayaYaz()
        {
            string dosya_yolu = Application.StartupPath + @"\TeraziVerileri.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < dgUrunListesi2.Rows.Count; i++)
            {

                DataGridViewRow dr = dgUrunListesi2.Rows[i];
                int urunUzunluk = dr.Cells["urunAdi2"].Value.ToString().Length;
                string urunAdi = dr.Cells["urunAdi2"].Value.ToString();
                string pluNo = (i + 1).ToString();
                if (urunUzunluk <= 25)
                {
                    for (int j = urunUzunluk; j < 25; j++)
                        urunAdi += " ";
                }
                else
                {
                    urunAdi = urunAdi.Substring(25);
                }

                if (pluNo.Length == 1) pluNo = "0" + pluNo;

                sw.WriteLine(urunAdi + "" + pluNo + "27" + dr.Cells["stokKodu1"].Value.ToString() + "" + dr.Cells["birimFiyat2"].Value.ToString().Replace(",", "").Replace(".", ""));
            }
            sw.Flush();
            sw.Close();
            fs.Close();
            GC.Collect();
            MessageBox.Show("Aktarım tamamlandı", firma.programAdi);

        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            dosyayaYaz();
        }
    }
}
