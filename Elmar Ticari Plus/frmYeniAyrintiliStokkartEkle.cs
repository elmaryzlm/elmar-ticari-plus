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
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmYeniAyrintiliStokkartEkle : Form
    {
        public frmYeniAyrintiliStokkartEkle()
        {
            InitializeComponent();
            texttemizle();
            baslangic();
            texttemizle();
        }
        public frmYeniAyrintiliStokkartEkle(Int64 stokid)
        {
            InitializeComponent();
            texttemizle();
            baslangic();
            this.stokid = stokid;
            duzenlemeModu();
        }
        string duzenle_urunismi = "";
        void duzenlemeModu()
        {
            lblBaslik.Text = "Stok Kartını Ayrıntılı Düzenle";
            this.Text = "Stok Kartı Ayrıntılı Düzenle";
            var l = stokkart.bul_stokid(stokid);
            var birimler = stokkart.birimler.listBirimler.Where(u => u.stokid == stokid);
            foreach (var b in birimler)
            {
                dgBirim.Rows.Add(b.stokkartBirimid, b.birimid, b.birimAdi, b.katsayi, b.barkod, "Düzenle", "Sil");
            }
            var fiyatlar = stokkart.fiyatlar.listFiyatlar.Where(u => u.stokid == stokid);
            foreach (var f in fiyatlar)
            {
                dgFiyat.Rows.Add(f.stokFiyatid, f.fiyatid, f.fiyatAdi, f.fiyatTutari, f.indirim, f.indirimTipi, f.dovizi, "Sil");
            }
            txtStokkodu.Text = l.stokkodu;
            txtUrunismi.Text = l.urunAdi;
            duzenle_urunismi = l.urunAdi;
            txtAlisFiyat.Text = l.alisFiyat.ToString();
            cmbKdv.Text = l.kdv.ToString();
            cmbKdvTipi.Text = l.kdvTipi.ToString();
            cmbKategori.Text = l.kategoriAdi;
            cmbKategori.Tag = l.katNo;
            cmbMarka.Text = l.markaAdi;
            cmbMarka.Tag = l.markaid.ToString();
            txtRaf.Text = l.rafAdi;
            txtGaranti.Text = l.garantiSuresi;
            txtUrunKodu.Text = l.urunKodu;
            txtAyrinti.Text = l.ayrinti;
            if (l.webdeGosterilsinmi == "1") chkWebdeGosterilsinmi.Checked = true;
            else if (l.webdeGosterilsinmi == "0") chkWebdeGosterilsinmi.Checked = false;

            //Resimler Getiriliyor
            if (guvenlikVeKontrol.internetVarmi())
            {
                DataRow rw =
                       veri.getdatarow(
                           "Select ftpAdres, ftpKullanici, ftpSifre from sorFirmaBilgileri where firmaid = " +
                           firma.firmaid + "");
                if (rw["ftpAdres"] != null && rw["ftpAdres"].ToString().Length > 10)
                {
                    elmarDosyaislemleri.sunucuFTPAdresi = rw["ftpAdres"].ToString();
                    elmarDosyaislemleri.sunucuKullaniciAdi = rw["ftpKullanici"].ToString();
                    elmarDosyaislemleri.sunucuSifre = rw["ftpSifre"].ToString();
                }
                else
                {
                    elmarDosyaislemleri.sunucuFTPAdresi =
                        "ftp://ftp.elazigyoreselmarket.com/httpdocs/ElmarProgramResimleri/stokkart/" +
                        firma.firmaid.ToString() + "/";
                    elmarDosyaislemleri.sunucuKullaniciAdi = "elazigyoreselm";
                    elmarDosyaislemleri.sunucuSifre = "elazigyore.23";
                }
                SqlDataReader dr = veri.getDatareader("Select resimid, resimYolu from [wtblStokkartResimleri] where firmaid = " + firma.firmaid + " And stokid = " + stokid + " And silindimi = '0'");
                while (dr.Read())
                {
                    Image imgBuffer =
                        elmarDosyaislemleri.resimindir("o" + dr["resimYolu"].ToString());
                    resimKutusuOlustur(dr["resimid"].ToString(), imgBuffer, dr["resimYolu"].ToString(), false);
                    this.Refresh();
                }

                dr.Close();
                dr.Dispose();
                dr = veri.getDatareader("SELECT Top 1 [urunSirasi],[detayliBilgi],[gAnahtarKelime],[gAciklama],[asgariSiparisMiktari],[urunPuani],[gosterimAnaSayfa],[gosterimSagSol],[gosterimVitrin],[kargoDesi],[kargoBedavami],[sayac],[kargoTutari] FROM  [wtblStokkartWeb] Where [stokid] = " + stokid + " And [silindimi] = '0' And [firmaid] = " + firma.firmaid + " order by eklenmeTarihi desc");
                while (dr.Read())
                {
                    txtUrunSirasi.Text = dr["urunSirasi"].ToString();
                    txtDetayliBilgi.Text = dr["detayliBilgi"].ToString();
                    txtGoogleAnahtarKelime.Text = dr["gAnahtarKelime"].ToString();
                    txtGoogleAciklama.Text = dr["gAciklama"].ToString();
                    txtAsgariSiparisMiktari.Text = dr["asgariSiparisMiktari"].ToString();
                    txtUrunPuani.Text = dr["urunPuani"].ToString();
                    chkAnaSayfadaGosterilsin.Checked = Convert.ToBoolean(Convert.ToByte(dr["gosterimAnaSayfa"]));
                    chkSagSolMenudeGosterilsin.Checked = Convert.ToBoolean(Convert.ToByte(dr["gosterimSagSol"]));
                    chkVitrindeGosterilsin.Checked = Convert.ToBoolean(Convert.ToByte(dr["gosterimVitrin"]));
                    txtKargoDesi.Text = dr["kargoDesi"].ToString();
                    chkKargoBedavami.Checked = Convert.ToBoolean(Convert.ToByte(dr["kargoBedavami"]));
                }
                dr.Close();
                dr.Dispose();
            }

        }
        public Int64 stokid;
        private void frmYeniAyrintiliStokkartEkle_Load(object sender, EventArgs e)
        {
        }
        public void baslangic()
        {
            cmbFiyatAdi.Items.Clear();
            try { cmbFiyatAdi.Items.AddRange(listeler.getFiyatAdi()); }
            catch { }
            cmbMarka.Items.Clear();
            try { cmbMarka.Items.AddRange(listeler.getMarkaadi()); }
            catch { }
            cmbKategori.Items.Clear();
            try { cmbKategori.Items.AddRange(listeler.getKategoriadi()); }
            catch { }
            cmbBirimAdi.Items.Clear();
            try { cmbBirimAdi.Items.AddRange(listeler.getBirimAdi()); }
            catch { }
            cmbDuzenleBirimAdi.Items.Clear();
            try { cmbDuzenleBirimAdi.Items.AddRange(listeler.getBirimAdi()); }
            catch { }
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgBirim);
            NesneGorselleri.dataGridView(dgFiyat);
            NesneGorselleri.kontrolEkle(pnlBirimTanimlamalari);
            NesneGorselleri.kontrolEkle(pnlFiyatTanimlamalari);
            NesneGorselleri.kontrolEkle(pnlUst);
            NesneGorselleri.kontrolEkle(panel1);
            NesneGorselleri.kontrolEkle(panel3);
            NesneGorselleri.kontrolEkle(panel5);
            NesneGorselleri.kontrolEkle(grpBarkodveBirimDuzenle);
            NesneGorselleri.kontrolEkle(tabPage3);
        }
        void texttemizle()
        {
            p.Value = 0;
            txtStokkodu.Clear();
            txtRaf.Text = "";
            txtGaranti.Text = "0";
            txtAyrinti.Clear();
            txtUrunKodu.Clear();
            txtindirim.Text = "0";
            txtUrunismi.Clear();
            txtAlisFiyat.Text = "0";
            cmbKategori.Text = "";
            cmbKategori.Tag = "0";
            dgBirim.Rows.Clear();
            dgFiyat.Rows.Clear();
            txtFiyatTutari.Text = "0";
            txtBirimKatsayi.Text = "1";
            txtBarkod.Clear();
            if (cmbKdv.Text == "") cmbKdv.Text = "18";
            txtUrunismi.Select();
        }

        private void txtUrunismi_Leave(object sender, EventArgs e)
        {
            //txtUrunisim.Text = satisislemleri.tirnakDuzenle(txtUrunisim.Text);
            //satisislemleri.rengiAyarla(sender);
            if (txtUrunismi.Text != "")
            {
                int urun_varmı = 0;
                SqlDataReader dr = veri.getDatareader("select urunAdi from sorStokkart where firmaid = '" + firma.firmaid + "' and urunAdi = '" + txtUrunismi.Text + "'  and silindimi = '0' ");
                while (dr.Read())
                {
                    urun_varmı = 1;
                }
                if (urun_varmı == 1 && duzenle_urunismi != txtUrunismi.Text)
                {
                    MessageBox.Show("Bu ürün ismi zaten kullanılıyor.", firma.programAdi);
                    txtUrunismi.Clear();
                    txtUrunismi.Select();
                    return;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

        }

        private void btnKategoriBul_Click(object sender, EventArgs e)
        {
            frmKategoriSecimi frm = new frmKategoriSecimi();
            frm._frmYeniAyrintiliStokkartEkle = this;
            frm.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBirimEkle_Click(object sender, EventArgs e)
        {
            if (txtBarkod.Text != "")
            {
                byte barkod_varmı = 0;
                SqlDataReader dr = veri.getDatareader("select 1 from tblStokkartBirimleri Where firmaid = " + firma.firmaid + " and barkod = '" + txtBarkod.Text + "' and silindimi = '0'");
                while (dr.Read())
                {
                    barkod_varmı = 1;
                }
                for (int i = 0; i < dgBirim.Rows.Count; i++) if (dgBirim.Rows[i].Cells["barkod"].Value.ToString() == txtBarkod.Text) barkod_varmı = 1;
                if (barkod_varmı == 1)
                {
                    MessageBox.Show("Bu barkod daha önce girilmiş", firma.programAdi);
                    barkod_varmı = 0;
                    txtBarkod.Clear();
                    txtBarkod.Select();
                    return;
                }
            }
            if (cmbBirimAdi.SelectedIndex == -1)
            {
                MessageBox.Show("Geçerli bir Birim Seçin", firma.programAdi);
                cmbBirimAdi.Select();
                return;
            }
            //for (int i = 0; i < dgBirim.Rows.Count; i++)
            //{
            //    if (dgBirim.Rows[i].Cells["birimid2"].Value.ToString() == listeler.getBirimid()[cmbBirimAdi.SelectedIndex].ToString())
            //    {
            //        MessageBox.Show("Bu birim daha önce tanımlanmış",firma.programAdi);
            //        dgBirim.Rows[i].Selected = true;
            //        return;
            //    }
            //}
            dgBirim.Rows.Add(0, listeler.getBirimid()[cmbBirimAdi.SelectedIndex], cmbBirimAdi.Text, txtBirimKatsayi.Text, txtBarkod.Text, "Düzenle", "Sil");
            txtBarkod.Clear();
            txtBirimKatsayi.Text = "1";
        }

        private void btnFiyatEkle_Click(object sender, EventArgs e)
        {
            if (cmbFiyatAdi.SelectedIndex == -1)
            {
                MessageBox.Show("Geçerli bir Fiyat Adı Seçin", firma.programAdi);
                cmbFiyatAdi.Select();
                return;
            }
            for (int i = 0; i < dgFiyat.Rows.Count; i++)
            {
                if (dgFiyat.Rows[i].Cells["fiyatid"].Value.ToString() == listeler.getFiyatid()[cmbFiyatAdi.SelectedIndex].ToString())
                {
                    MessageBox.Show("Bu Fiyat adı için bir fiyat daha önce tanımlanmış", firma.programAdi);
                    dgFiyat.Rows[i].Selected = true;
                    return;
                }
            }
            dgFiyat.Rows.Add(0, listeler.getFiyatid()[cmbFiyatAdi.SelectedIndex], cmbFiyatAdi.Text, txtFiyatTutari.Text, txtindirim.Text, cmbindirimTipi.Text, cmbFiyatDovizi.Text, "Sil");
        }

        private void birimlerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimBirim frm = new frmTanimBirim();
            frm._frmYeniAyrintiliStokkartEkle = this;
            frm.Show();
        }

        private void fiyatAdlarıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimFiyatAdi frm = new frmTanimFiyatAdi();
            frm._frmYeniAyrintiliStokkartEkle = this;
            frm.Show();
        }

        private void markalarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            frmTanimMarkalar frm = new frmTanimMarkalar();
            frm._frmYeniAyrintiliStokkartEkle = this;
            frm.Show();
        }

        private void kategorilerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Stok_Tanımlamaları)
            {
                yetkiler.mesajVer();
                return;
            }
            btnKategoriBul_Click(sender, e);
        }

        private void dgBirim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgBirim["sil2", e.RowIndex].ColumnIndex)
                {
                    if (MessageBox.Show(dgBirim.CurrentRow.Cells["birimAdi2"].Value.ToString() + " - " + dgBirim.CurrentRow.Cells["barkod"].Value.ToString() + " Silinsin mi?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (dgBirim.CurrentRow.Cells["stokkartBirimid"].Value.ToString() != "0") veri.cmd("Update tblStokkartBirimleri set silindimi = '1' where stokkartBirimid = '" + dgBirim.CurrentRow.Cells["stokkartBirimid"].Value.ToString() + "'");
                        dgBirim.Rows.Remove(dgBirim.CurrentRow);
                        stokkart.birimler.listBirimler.Remove(stokkart.birimler.bul_barkod(dgBirim.CurrentRow.Cells["barkod"].Value.ToString()).First());
                    }
                }
                else if (e.ColumnIndex == dgBirim["duzenle2", e.RowIndex].ColumnIndex)
                {
                    grpBarkodveBirimDuzenle.Visible = true;
                    grpBarkodveBirimDuzenle.BringToFront();
                    txtDuzenleBarkod.Text = dgBirim.CurrentRow.Cells["barkod"].Value.ToString();
                    txtDuzenleKatsayi.Text = dgBirim.CurrentRow.Cells["katsayi"].Value.ToString();
                    cmbDuzenleBirimAdi.Text = dgBirim.CurrentRow.Cells["birimAdi2"].Value.ToString();
                }
            }
            catch
            {
            }
        }

        private void dgFiyat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgFiyat["sil3", e.RowIndex].ColumnIndex)
                {
                    if (MessageBox.Show(dgFiyat.CurrentRow.Cells["fiyatAdi"].Value.ToString() + " Silinsin mi?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (dgFiyat.CurrentRow.Cells["stokFiyatid"].Value.ToString() != "0") veri.cmd("Update tblStokFiyatlari set silindimi = '1' where stokFiyatid = '" + dgFiyat.CurrentRow.Cells["stokFiyatid"].Value.ToString() + "'");
                        dgFiyat.Rows.Remove(dgFiyat.CurrentRow);
                        guncelle.stokkartVerileriniGuncelle();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbBirimAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBirimBarkodDuzenle_Click(object sender, EventArgs e)
        {
            if (stokid > 0) return;
            if (txtBarkod.Text != "")
            {
                byte barkod_varmı = 0;
                SqlDataReader dr = veri.getDatareader("select 1 from tblStokkartBirimleri Where firmaid = " + firma.firmaid + " and barkod = '" + dgBirim.CurrentRow.Cells["barkod"].Value + "' and silindimi = '0'");
                while (dr.Read())
                {
                    barkod_varmı = 1;
                }
                if (barkod_varmı == 1)
                {
                    MessageBox.Show("Bu barkod daha önce girilmiş", firma.programAdi);
                    barkod_varmı = 0;
                    txtDuzenleBarkod.Clear();
                    txtDuzenleBarkod.Select();
                    return;
                }
            }
            if (cmbDuzenleBirimAdi.SelectedIndex == -1)
            {
                MessageBox.Show("Geçerli bir Birim Seçin", firma.programAdi);
                cmbDuzenleBirimAdi.Select();
                return;
            }

            dgBirim.CurrentRow.Cells["birimid2"].Value = listeler.getBirimid()[cmbDuzenleBirimAdi.SelectedIndex];
            dgBirim.CurrentRow.Cells["barkod"].Value = txtDuzenleBarkod.Text;
            dgBirim.CurrentRow.Cells["katsayi"].Value = txtDuzenleKatsayi.Text;
            dgBirim.CurrentRow.Cells["birimAdi2"].Value = cmbDuzenleBirimAdi.Text;
            grpBarkodveBirimDuzenle.Visible = false;
        }

        private void btnBirimBarkodİptal_Click(object sender, EventArgs e)
        {
            grpBarkodveBirimDuzenle.Visible = false;
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            //txtBarkod.Text = satisislemleri.tirnakDuzenle(txtBarkod.Text);
            //txtUrunisim.Text = satisislemleri.tirnakDuzenle(txtUrunisim.Text);

            if (txtUrunismi.Text == "")
            {
                MessageBox.Show("Ürün ismi girişi yapın", firma.programAdi);
                txtUrunismi.Select();
                return;
            }
            if (cmbKdv.Items.Contains(cmbKdv.Text) == false)
            {
                MessageBox.Show("Kdv'yi listeden seçin", firma.programAdi);
                cmbKdv.Select();
                return;
            }
            if (cmbKategori.Text != "" && cmbKategori.Items.Contains(cmbKategori.Text) == false)
            {
                MessageBox.Show("Kategoriyi listeden seçin", firma.programAdi);
                cmbKategori.Select();
                return;
            }
            if (cmbMarka.Text != "" && cmbMarka.Items.Contains(cmbMarka.Text) == false)
            {
                MessageBox.Show("Markayı listeden seçin", firma.programAdi);
                cmbMarka.Select();
                return;
            }
            if (dgBirim.Rows.Count == 0)
            {
                DialogResult cevap = MessageBox.Show("Birim Girmediniz. stok kartına ait birim 'Adet' olarak tanımlansın mı ?", firma.programAdi, MessageBoxButtons.YesNoCancel);
                if (cevap == DialogResult.Yes)
                {
                    cmbBirimAdi.Text = "Adet";
                    dgBirim.Rows.Add(0, listeler.getBirimid()[cmbBirimAdi.SelectedIndex], cmbBirimAdi.Text, txtBirimKatsayi.Text, txtBarkod.Text, "Sil");
                }
                else
                {
                    MessageBox.Show("Lütfen birim ekleyin.", firma.programAdi);
                    return;
                }
            }
            try
            {
                //veritabanına stokkart bilgileri ekleniyor
                p.Visible = true;
                this.Refresh();
                p.Value = 0;
                p.Maximum = 1 + dgBirim.Rows.Count + dgFiyat.Rows.Count;
                string katNo = "";
                if (cmbKategori.SelectedIndex >= 0) katNo = listeler.getKategoriNo()[cmbKategori.SelectedIndex];
                int markaID = 0;
                if (cmbMarka.SelectedIndex >= 0) markaID = listeler.getMarkano()[cmbMarka.SelectedIndex];
                Int64 eklenenStokid = Convert.ToInt64(veri.getdatacell("exec spSetStokKartAyrinti " + stokid + ",'" + txtStokkodu.Text + "','','" + txtUrunismi.Text + "','" + txtAlisFiyat.Text.Replace(".", "").Replace(',', '.') + "','" + cmbKdv.Text + "','" + cmbKdvTipi.Text + "','" + katNo + "','" + txtUrunKodu.Text + "','" + txtGaranti.Text + "','" + markaID + "','" + txtRaf.Text + "','" + txtAyrinti.Text + "','','" + Convert.ToByte(chkWebdeGosterilsinmi.CheckState) + "','" + firma.firmaid + "','" + firma.subeid + "','" + firma.kullaniciid + "'"));
                //class'a stokkart verileri ekleniyor
                if (stokid != 0) stokkart.sil(stokid);//daha önce varsa güncellenmesi için siliniyor.
                else stokid = eklenenStokid;
                stokkart.ekle(stokid, txtStokkodu.Text, "", txtUrunismi.Text, Convert.ToDouble(txtAlisFiyat.Text), Convert.ToInt16(cmbKdv.Text), cmbKdvTipi.Text, katNo, cmbKategori.Text, txtUrunKodu.Text, txtGaranti.Text, markaID, cmbMarka.Text, txtRaf.Text, txtAyrinti.Text, "1", "", Convert.ToByte(chkWebdeGosterilsinmi.CheckState).ToString(), false, Convert.ToBoolean(chkVitrin.CheckState), DateTime.Now, "0", firma.subeid, firma.kullaniciid);
                listeler.yukleUrunadi();

                p.Value += 1;
                //Birimler ekleniyor
                for (int i = 0; i < dgBirim.Rows.Count; i++)
                {
                    Int64 eklenenStokBirimid = Convert.ToInt64(veri.getdatacell("exec spSetStokkartBirim " + dgBirim.Rows[i].Cells["stokkartBirimid"].Value + "," + this.stokid + "," + dgBirim.Rows[i].Cells["birimid2"].Value + ",'" + dgBirim.Rows[i].Cells["katsayi"].Value.ToString().Replace(",", ".") + "','" + dgBirim.Rows[i].Cells["barkod"].Value.ToString() + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ""));
                    if (dgBirim.Rows[i].Cells["stokkartBirimid"].Value.ToString() != "0") stokkart.birimler.sil(Convert.ToInt64(dgBirim.Rows[i].Cells["stokkartBirimid"].Value));
                    stokkart.birimler.ekle(eklenenStokBirimid, eklenenStokid, Convert.ToInt32(dgBirim.Rows[i].Cells["birimid2"].Value), dgBirim.Rows[i].Cells["birimAdi2"].Value.ToString(), Convert.ToDouble(dgBirim.Rows[i].Cells["katsayi"].Value), dgBirim.Rows[i].Cells["barkod"].Value.ToString(), DateTime.Now, firma.subeid, firma.kullaniciid);
                    p.Value += 1;
                }
                //fiyatlar ekleniyor
                for (int i = 0; i < dgFiyat.Rows.Count; i++)
                {
                    Int64 eklenenStokFiyatid = Convert.ToInt64(veri.getdatacell("exec spSetStokkartFiyat " + dgFiyat.Rows[i].Cells["stokFiyatid"].Value + "," + this.stokid + "," + dgFiyat.Rows[i].Cells["fiyatid"].Value + ",'" + dgFiyat.Rows[i].Cells["fiyatTutari"].Value.ToString().Replace(".", "").Replace(",", ".") + "','" + dgFiyat.Rows[i].Cells["indirim"].Value.ToString().Replace(".", "").Replace(",", ".") + "','" + dgFiyat.Rows[i].Cells["indirimTipi"].Value.ToString() + "','" + dgFiyat.Rows[i].Cells["dovizi"].Value.ToString() + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ""));
                    if (dgFiyat.Rows[i].Cells["stokFiyatid"].Value.ToString() != "0") stokkart.fiyatlar.sil(Convert.ToInt64(dgFiyat.Rows[i].Cells["stokFiyatid"].Value));
                    double indirimliFiyat = Convert.ToDouble(dgFiyat.Rows[i].Cells["fiyatTutari"].Value) - Convert.ToDouble(dgFiyat.Rows[i].Cells["indirim"].Value);
                    if (dgFiyat.Rows[i].Cells["indirimTipi"].Value.ToString() == "%") indirimliFiyat = Convert.ToDouble(dgFiyat.Rows[i].Cells["fiyatTutari"].Value) - Convert.ToDouble(dgFiyat.Rows[i].Cells["fiyatTutari"].Value) * Convert.ToDouble(dgFiyat.Rows[i].Cells["indirim"].Value) / 100;

                    stokkart.fiyatlar.ekle(eklenenStokFiyatid, eklenenStokid, Convert.ToInt32(dgFiyat.Rows[i].Cells["fiyatid"].Value), dgFiyat.Rows[i].Cells["fiyatAdi"].Value.ToString(), Convert.ToDouble(dgFiyat.Rows[i].Cells["fiyatTutari"].Value.ToString()), Convert.ToDouble(dgFiyat.Rows[i].Cells["indirim"].Value.ToString()), dgFiyat.Rows[i].Cells["indirimTipi"].Value.ToString(), indirimliFiyat, dgFiyat.Rows[i].Cells["dovizi"].Value.ToString(), DateTime.Now, firma.subeid, firma.kullaniciid);
                    p.Value += 1;
                }

                if (stokid != 0) this.Close();
                else texttemizle();

            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Eklenemedi. Hata Metni:\n" + hata.Message, firma.programAdi);
            }
            p.Visible = false;
            this.Refresh();
        }

        public static string dosyaAdiOlustur(string metin, string stokid, string eklenenResimid)
        {
            metin = "urun-" + stokid + "-" + eklenenResimid + "-" + metin;
            metin = sanalOlustur(metin);
            metin = metin.Replace("-jpg", ".jpg");
            metin = metin.Replace("-gif", ".gif");
            metin = metin.Replace("-jpeg", ".jpeg");
            metin = metin.Replace("-png", ".png");
            metin = metin.Replace("-bmp", ".bmp");
            metin = metin.Replace("-doc", ".doc");
            metin = metin.Replace("-docx", ".docx");
            metin = metin.Replace("-xls", ".xls");
            metin = metin.Replace("-xlsx", ".xlsx");
            metin = metin.Replace("-pdf", ".pdf");
            metin = metin.Replace("-ppt", ".ppt");
            metin = metin.Replace("-pptx", ".pptx");
            metin = metin.Replace("-rar", ".rar");
            metin = metin.Replace("-zip", ".zip");
            metin = metin.Replace("-swf", ".swf");
            return metin;
        }
        OpenFileDialog o;
        private void btnResimYukle_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Fotoğrafın ölçüsü 80X80 piksel olmalı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (d == DialogResult.OK)
            {
                o = new OpenFileDialog();
                o.Title = "Resim Seçimi";
                o.Filter = "Resim Dosyaları|*.png;*.bmp;*.gif;*.jpg;*.jpeg";
                o.Multiselect = true;
                o.ShowDialog();
                if (o.SafeFileNames != null && o.SafeFileNames.Count() == 0)
                {
                }
                else
                {
                    for (int i = 0; i < o.FileNames.Count(); i++)
                    {
                        Image imgBuffer = Image.FromFile(o.FileNames[i]);
                        resimKutusuOlustur("0", imgBuffer, o.SafeFileNames[i], true);
                        this.Refresh();
                    }
                }
            }
        }

        private Panel pnl;
        private Button btnResimDuzenle, btnResimSil;
        private PictureBox pic;
        private void resimKutusuOlustur(string resimid, Image resim, string dosyaAdi, bool servereYuklenecekmi)
        {
            //pnl
            pnl = new Panel();
            //pnl.SuspendLayout();
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Location = new Point(3, 3);
            pnl.Name = "pnlResim" + (pnlResimler.Controls.Count + 1).ToString();
            pnl.Size = new Size(135, 125);
            pnl.TabIndex = pnlResimler.Controls.Count + 1;
            pnl.Tag = new resimTaslak(Convert.ToInt64(resimid), dosyaAdi, resim, servereYuklenecekmi);
            // 
            // btnResimDuzenle
            // 
            btnResimDuzenle = new Button();
            btnResimDuzenle.BackColor = SystemColors.InactiveCaption;
            btnResimDuzenle.Image = Properties.Resources.Pencil_icon;
            btnResimDuzenle.ImageAlign = ContentAlignment.MiddleLeft;
            btnResimDuzenle.Location = new Point(58, 100);
            btnResimDuzenle.Name = "btnResimDuzenle" + (pnlResimler.Controls.Count + 1).ToString();
            btnResimDuzenle.Size = new Size(74, 23);
            btnResimDuzenle.TabIndex = pnlResimler.Controls.Count + 1;
            btnResimDuzenle.Text = "Düzenle ";
            btnResimDuzenle.TextAlign = ContentAlignment.MiddleRight;
            btnResimDuzenle.UseVisualStyleBackColor = false;
            btnResimDuzenle.Click += btnResimDuzenle_Click;
            // 
            // btnResimSil
            // 
            btnResimSil = new Button();
            btnResimSil.BackColor = SystemColors.InactiveCaption;
            btnResimSil.Image = Properties.Resources.Delete_icon;
            btnResimSil.ImageAlign = ContentAlignment.MiddleLeft;
            btnResimSil.Location = new Point(0, 100);
            btnResimSil.Name = "btnResimSil" + (pnlResimler.Controls.Count + 1).ToString();
            btnResimSil.Size = new Size(55, 23);
            btnResimSil.TabIndex = pnlResimler.Controls.Count + 1;
            btnResimSil.Text = "    Sil";
            btnResimSil.UseVisualStyleBackColor = false;
            btnResimSil.Click += btnResimSil_Click;

            // 
            // pic
            // 
            pic = new PictureBox();
            pic.Dock = DockStyle.Top;
            pic.Location = new Point(0, 0);
            pic.Name = "resim" + (pnlResimler.Controls.Count + 1).ToString();
            pic.Size = new Size(133, 100);
            pic.TabIndex = pnlResimler.Controls.Count + 1;
            pic.TabStop = false;
            pic.BackgroundImage = resim;
            pic.BackgroundImageLayout = ImageLayout.Zoom;

            //btnResimDuzenle.Tag = pic;
            //btnResimSil.Tag = pic;

            // 
            pnl.Controls.Add(pic);
            pnl.Controls.Add(btnResimDuzenle);
            pnl.Controls.Add(btnResimSil);
            this.pnlResimler.Controls.Add(pnl);
        }

        private void btnResimDuzenle_Click(object sender, EventArgs e)
        {
            Button sndr = (Button)sender;
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Resim Değiştir";
            o.Filter = "Resim Dosyaları|*.png;*.bmp;*.gif;*.jpg";
            o.ShowDialog();
            if (o.SafeFileName == "")
            {
            }
            else
            {
                ((PictureBox)sndr.Parent.Controls[0]).BackgroundImage = Image.FromFile(o.FileName);
                ((resimTaslak)(sndr.Parent).Tag).dosyaAdi = o.SafeFileName;
                ((resimTaslak)(sndr.Parent).Tag).resim = Image.FromFile(o.FileName);
                ((resimTaslak)(sndr.Parent).Tag).servereYuklenecekmi = true;
            }

        }

        private void btnResimSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Resim Silinsin mi ?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Button sndr = (Button)sender;
                veri.cmd("Update wtblStokkartResimleri Set silindimi = '1' where stokid = " + stokid + " And resimid = " + ((resimTaslak)(sndr.Parent).Tag).resimID + "");
                sndr.Parent.Dispose();
            }
        }

        private void btnKaydet2_Click(object sender, EventArgs e)
        {
            if (txtUrunismi.Text == "")
            {
                MessageBox.Show("Ürün ismi girişi yapın", firma.programAdi);
                txtUrunismi.Select();
                return;
            }
            if (cmbKdv.Items.Contains(cmbKdv.Text) == false)
            {
                MessageBox.Show("Kdv'yi listeden seçin", firma.programAdi);
                cmbKdv.Select();
                return;
            }
            if (cmbKategori.Text != "" && cmbKategori.Items.Contains(cmbKategori.Text) == false)
            {
                MessageBox.Show("Kategoriyi listeden seçin", firma.programAdi);
                cmbKategori.Select();
                return;
            }
            if (cmbMarka.Text != "" && cmbMarka.Items.Contains(cmbMarka.Text) == false)
            {
                MessageBox.Show("Markayı listeden seçin", firma.programAdi);
                cmbMarka.Select();
                return;
            }
            if (chkVitrin.Checked == true)
            {
                DataTable dt = veri.getdatatable("Select * from tblStokkart where silindimi = '0' and vitrin = '1' and firmaid=" + firma.firmaid);
                if (dt.Rows.Count >= 36)
                {
                    MessageBox.Show("Vitrinde gösterilecek maksimum stok sayısına ulaşılmıştır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (dgBirim.Rows.Count == 0)
            {
                DialogResult cevap = MessageBox.Show("Birim Girmediniz. Stok kartına ait birim 'Adet' olarak tanımlansın mı ?", firma.programAdi, MessageBoxButtons.YesNoCancel);
                if (cevap == DialogResult.Yes)
                {
                    cmbBirimAdi.Text = "Adet";
                    dgBirim.Rows.Add(0, listeler.getBirimid()[cmbBirimAdi.SelectedIndex], cmbBirimAdi.Text, txtBirimKatsayi.Text, txtBarkod.Text, "Sil");
                }
                else
                {
                    MessageBox.Show("Lütfen birim ekleyin.", firma.programAdi);
                    return;
                }
            }
            try
            {
                //veritabanına stokkart bilgileri ekleniyor
                p.Visible = true;
                this.Refresh();
                p.Value = 0;
                p.Maximum = 1 + dgBirim.Rows.Count + dgFiyat.Rows.Count + pnlResimler.Controls.Count;
                lblDurum.Text = "Stok kartı bilgileri kaydediliyor.."; this.Refresh();
                string katNo = "";
                if (cmbKategori.SelectedIndex >= 0) katNo = listeler.getKategoriNo()[cmbKategori.SelectedIndex];
                int markaID = 0;
                if (cmbMarka.SelectedIndex >= 0) markaID = listeler.getMarkano()[cmbMarka.SelectedIndex];
                Int64 eklenenStokid = Convert.ToInt64(veri.getdatacell("exec SpSetStokkartOrtak " + stokid + ", '', '" + txtStokkodu.Text + "','','" + txtUrunismi.Text + "','" + txtAlisFiyat.Text.Replace(".", "").Replace(',', '.') + "','" + cmbKdv.Text + "','" + cmbKdvTipi.Text + "','" + katNo + "','" + txtUrunKodu.Text + "','" + txtGaranti.Text + "','" + markaID + "','" + txtRaf.Text + "', " + txtUrunSirasi.Text + ", '" + txtDetayliBilgi.Text + "','" + txtGoogleAnahtarKelime.Text + "', '" + txtGoogleAciklama.Text + "','" + txtAyrinti.Text + "','" + txtAsgariSiparisMiktari.Text.Replace(".", "").Replace(',', '.') + "','" + txtUrunPuani.Text.Replace(".", "").Replace(',', '.') + "','" + Convert.ToByte(chkAnaSayfadaGosterilsin.CheckState) + "','" + Convert.ToByte(chkSagSolMenudeGosterilsin.CheckState) + "','" + Convert.ToByte(chkVitrindeGosterilsin.CheckState) + "','" + txtKargoDesi.Text.Replace(".", "").Replace(',', '.') + "','" + Convert.ToByte(chkKargoBedavami.CheckState) + "','0','0','0','0','TL','TL','" + Convert.ToByte(chkWebdeGosterilsinmi.CheckState) + "','" + firma.firmaid + "','" + firma.subeid + "','" + firma.kullaniciid + "'"));
                //class'a stokkart verileri ekleniyor
                if (chkVitrin.Checked == true)
                {
                    veri.getdatacell("update tblStokKart set vitrin=1 where stokid=" + eklenenStokid);
                }
                else
                {
                    veri.getdatacell("update tblStokKart set vitrin=0 where stokid=" + eklenenStokid);
                }

                if (stokid != 0)
                    stokkart.sil(stokid);

                //daha önce varsa güncellenmesi için siliniyor.

                else stokid = eklenenStokid;
                stokkart.ekle(stokid, txtStokkodu.Text, "", txtUrunismi.Text, Convert.ToDouble(txtAlisFiyat.Text), Convert.ToInt16(cmbKdv.Text), cmbKdvTipi.Text, katNo, cmbKategori.Text, txtUrunKodu.Text, txtGaranti.Text, markaID, cmbMarka.Text, txtRaf.Text, txtAyrinti.Text, "1", "", Convert.ToByte(chkWebdeGosterilsinmi.CheckState).ToString(), false, Convert.ToBoolean(chkVitrin.CheckState), DateTime.Now, "0", firma.subeid, firma.kullaniciid);
                listeler.yukleUrunadi();

                p.Value += 1;
                lblDurum.Text = "Birimler kaydediliyor.."; this.Refresh();
                //Birimler ekleniyor
                for (int i = 0; i < dgBirim.Rows.Count; i++)
                {
                    Int64 eklenenStokBirimid = Convert.ToInt64(veri.getdatacell("exec spSetStokkartBirim " + dgBirim.Rows[i].Cells["stokkartBirimid"].Value + "," + this.stokid + "," + dgBirim.Rows[i].Cells["birimid2"].Value + ",'" + dgBirim.Rows[i].Cells["katsayi"].Value.ToString().Replace(",", ".") + "','" + dgBirim.Rows[i].Cells["barkod"].Value.ToString() + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ""));
                    if (dgBirim.Rows[i].Cells["stokkartBirimid"].Value.ToString() != "0") stokkart.birimler.sil(Convert.ToInt64(dgBirim.Rows[i].Cells["stokkartBirimid"].Value));
                    stokkart.birimler.ekle(eklenenStokBirimid, eklenenStokid, Convert.ToInt32(dgBirim.Rows[i].Cells["birimid2"].Value), dgBirim.Rows[i].Cells["birimAdi2"].Value.ToString(), Convert.ToDouble(dgBirim.Rows[i].Cells["katsayi"].Value), dgBirim.Rows[i].Cells["barkod"].Value.ToString(), DateTime.Now, firma.subeid, firma.kullaniciid);
                    p.Value += 1;
                }
                lblDurum.Text = "Fiyatlar kaydediliyor.."; this.Refresh();
                //fiyatlar ekleniyor
                for (int i = 0; i < dgFiyat.Rows.Count; i++)
                {
                    Int64 eklenenStokFiyatid = Convert.ToInt64(veri.getdatacell("exec spSetStokkartFiyat " + dgFiyat.Rows[i].Cells["stokFiyatid"].Value + "," + this.stokid + "," + dgFiyat.Rows[i].Cells["fiyatid"].Value + ",'" + dgFiyat.Rows[i].Cells["fiyatTutari"].Value.ToString().Replace(".", "").Replace(",", ".") + "','" + dgFiyat.Rows[i].Cells["indirim"].Value.ToString().Replace(".", "").Replace(",", ".") + "','" + dgFiyat.Rows[i].Cells["indirimTipi"].Value.ToString() + "','" + dgFiyat.Rows[i].Cells["dovizi"].Value.ToString() + "'," + firma.firmaid + "," + firma.subeid + "," + firma.kullaniciid + ""));
                    if (dgFiyat.Rows[i].Cells["stokFiyatid"].Value.ToString() != "0") stokkart.fiyatlar.sil(Convert.ToInt64(dgFiyat.Rows[i].Cells["stokFiyatid"].Value));
                    double indirimliFiyat = Convert.ToDouble(dgFiyat.Rows[i].Cells["fiyatTutari"].Value) - Convert.ToDouble(dgFiyat.Rows[i].Cells["indirim"].Value);
                    if (dgFiyat.Rows[i].Cells["indirimTipi"].Value.ToString() == "%") indirimliFiyat = Convert.ToDouble(dgFiyat.Rows[i].Cells["fiyatTutari"].Value) - Convert.ToDouble(dgFiyat.Rows[i].Cells["fiyatTutari"].Value) * Convert.ToDouble(dgFiyat.Rows[i].Cells["indirim"].Value) / 100;

                    stokkart.fiyatlar.ekle(eklenenStokFiyatid, eklenenStokid, Convert.ToInt32(dgFiyat.Rows[i].Cells["fiyatid"].Value), dgFiyat.Rows[i].Cells["fiyatAdi"].Value.ToString(), Convert.ToDouble(dgFiyat.Rows[i].Cells["fiyatTutari"].Value.ToString()), Convert.ToDouble(dgFiyat.Rows[i].Cells["indirim"].Value.ToString()), dgFiyat.Rows[i].Cells["indirimTipi"].Value.ToString(), indirimliFiyat, dgFiyat.Rows[i].Cells["dovizi"].Value.ToString(), DateTime.Now, firma.subeid, firma.kullaniciid);
                    p.Value += 1;
                }

                //Resimler
                if (pnlResimler.Controls.Count > 0 && guvenlikVeKontrol.internetVarmi())
                {
                    if (chkVitrin.Checked == true)
                    {
                        //OpenFileDialog dosya = new OpenFileDialog();
                        // pic
                        lblDurum.Text = "Resimler kaydediliyor..";
                        string adi = eklenenStokid.ToString() + ".jpg";
                        //  o.FileName = eklenenStokid.ToString()+".jpg";
                        string dosyaadi = o.FileName;
                        pic.Image = Image.FromFile(dosyaadi);
                        pic.Top = 50;
                        pic.Size = new System.Drawing.Size(200, 200);
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.Controls.Add(pic);
                        this.Text = o.SafeFileName;
                        pic.Image.Save(Application.StartupPath + "\\vitrinresimleri\\" + adi, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //pic.Image.Save(Application.StartupPath);
                    }
                    else
                    {
                        lblDurum.Text = "Resimler kaydediliyor..";
                        this.Refresh();
                        DataRow rw =
                            veri.getdatarow(
                                "Select ftpAdres, ftpKullanici, ftpSifre from sorFirmaBilgileri where firmaid = " +
                                firma.firmaid + "");
                        if (rw["ftpAdres"] != null && rw["ftpAdres"].ToString().Length > 10)
                        {
                            elmarDosyaislemleri.sunucuFTPAdresi = rw["ftpAdres"].ToString();
                            elmarDosyaislemleri.sunucuKullaniciAdi = rw["ftpKullanici"].ToString();
                            elmarDosyaislemleri.sunucuSifre = rw["ftpSifre"].ToString();
                        }
                        else
                        {
                            elmarDosyaislemleri.sunucuFTPAdresi =
                                "ftp://ftp.elazigyoreselmarket.com/httpdocs/ElmarProgramResimleri/stokkart/" +
                                firma.firmaid.ToString() + "/";
                            elmarDosyaislemleri.sunucuKullaniciAdi = "elazigyoreselm";
                            elmarDosyaislemleri.sunucuSifre = "elazigyore.23";
                        }

                        for (int i = 0; i < pnlResimler.Controls.Count; i++)
                        {

                            if (pnlResimler.Controls[i].Controls[0].GetType() == typeof(PictureBox))
                            {
                                resimTaslak rt = (resimTaslak)pnlResimler.Controls[i].Tag;

                                if (rt.servereYuklenecekmi)
                                {
                                    string eklenenResimID = veri.getdatacell("Exec spSetStokkartResim " + rt.resimID + "," + stokid + ",'" + rt.dosyaAdi + "'," + firma.firmaid + "");
                                    string dosyaAdi = dosyaAdiOlustur(rt.dosyaAdi, stokid.ToString(), eklenenResimID);
                                    veri.getdatacell("Exec spSetStokkartResim " + eklenenResimID + "," + stokid + ",'" + dosyaAdi + "'," + firma.firmaid + "");

                                    Image normal = rt.resim.GetThumbnailImage(1024, 768, null, IntPtr.Zero);
                                    Image orta = rt.resim.GetThumbnailImage(411, 274, null, IntPtr.Zero);
                                    Image kucuk = rt.resim.GetThumbnailImage(100, 67, null, IntPtr.Zero);
                                    elmarDosyaislemleri.resimYukle(normal, dosyaAdi);
                                    elmarDosyaislemleri.resimYukle(orta, "o" + dosyaAdi);
                                    elmarDosyaislemleri.resimYukle(kucuk, "k" + dosyaAdi);

                                }
                                p.Value += 1;
                            }
                        }
                    }

                }
                p.Value = 0;
                p.Visible = false;
                this.Refresh();
                if (stokid != 0) this.Close();
                else texttemizle();

            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Eklenemedi. Hata Metni:\n" + hata.Message, firma.programAdi);
            }
        }

        private class resimTaslak
        {
            public long resimID;
            public string dosyaAdi = "";
            public Image resim;
            public bool servereYuklenecekmi = false;

            public resimTaslak(long resimID, string dosyaAdi, Image resim, bool servereYuklenecekmi)
            {
                this.resimID = resimID;
                this.dosyaAdi = dosyaAdi;
                this.resim = resim;
                this.servereYuklenecekmi = servereYuklenecekmi;
            }
        }

        private void btnBarkodUret_Click(object sender, EventArgs e)
        {
            RandomBarcode barcode = new RandomBarcode();
            //bu kod barkodun ilk 2 hanesi -ülke kodu
            barcode.CountryCode = "869";
            Random rastgele = new Random();
            int sayi = rastgele.Next(10, 50);
            int sayi2 = rastgele.Next(50, 100);
            int sayi3 = rastgele.Next(1000, 9999);
            barcode.ManufacturerCode = sayi.ToString() + sayi2.ToString();
            barcode.ProductCode = "0" + sayi3;
            barcode.CalculateChecksumDigit();
            txtBarkod.Text = barcode.CountryCode + barcode.ManufacturerCode + barcode.ProductCode + barcode.ChecksumDigit;
        }
        public static string sanalOlustur(string metin)
        {
            metin = metin.Replace("A", "a");
            metin = metin.Replace("B", "b");
            metin = metin.Replace("C", "c");
            metin = metin.Replace("Ç", "c");
            metin = metin.Replace("D", "d");
            metin = metin.Replace("E", "e");
            metin = metin.Replace("F", "f");
            metin = metin.Replace("G", "g");
            metin = metin.Replace("Ğ", "g");
            metin = metin.Replace("H", "h");
            metin = metin.Replace("I", "i");
            metin = metin.Replace("İ", "i");
            metin = metin.Replace("J", "j");
            metin = metin.Replace("K", "k");
            metin = metin.Replace("L", "l");
            metin = metin.Replace("M", "m");
            metin = metin.Replace("N", "n");
            metin = metin.Replace("O", "o");
            metin = metin.Replace("Ö", "o");
            metin = metin.Replace("P", "p");
            metin = metin.Replace("R", "r");
            metin = metin.Replace("S", "s");
            metin = metin.Replace("Ş", "s");
            metin = metin.Replace("T", "t");
            metin = metin.Replace("U", "u");
            metin = metin.Replace("Ü", "u");
            metin = metin.Replace("V", "v");
            metin = metin.Replace("Y", "y");
            metin = metin.Replace("Z", "z");
            metin = metin.Replace("X", "x");
            metin = metin.Replace("W", "w");
            metin = metin.Replace("Q", "q");
            metin = metin.Replace("ç", "c");
            metin = metin.Replace("ı", "i");
            metin = metin.Replace("ğ", "g");
            metin = metin.Replace("ö", "o");
            metin = metin.Replace("ü", "u");
            metin = metin.Replace("ş", "s");
            metin = metin.Replace("&", "-ve-");
            metin = metin.Replace("'", "");
            metin = metin.Replace(" ", "-");
            metin = metin.Replace("/", "");
            metin = metin.Replace("?", "");
            metin = metin.Replace("+", "");
            metin = metin.Replace("(", "");
            metin = metin.Replace(")", "");
            metin = metin.Replace("[", "");
            metin = metin.Replace("]", "");
            metin = metin.Replace("{", "");
            metin = metin.Replace("}", "");
            metin = metin.Replace("=", "esittir");
            metin = metin.Replace("#", "");
            metin = metin.Replace("$", "dolar");
            metin = metin.Replace(":", "-");
            metin = metin.Replace(";", "-");
            metin = metin.Replace("~", "");
            metin = metin.Replace("@", "at");
            metin = metin.Replace("^", "");
            metin = metin.Replace("<", "kucuktur");
            metin = metin.Replace(">", "buyuktur");
            metin = metin.Replace("|", "");
            metin = metin.Replace("*", "");
            metin = metin.Replace("%", "yuzde");
            metin = metin.Replace(".", "-");
            metin = metin.Replace(",", "-");
            return metin;
        }
    }
}