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
namespace Elmar_Ticari_Plus
{
    public partial class frmGelirGiderRaporlari : Form
    {
        public frmGelirGiderRaporlari()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgGelirRaporlari);
            NesneGorselleri.dataGridView(dgGiderRaporlari);
            NesneGorselleri.dataGridView(dgGelirGiderRaporlari);
            NesneGorselleri.kontrolEkle(groupBox1);
            NesneGorselleri.kontrolEkle(groupBox9);
            NesneGorselleri.kontrolEkle(groupBox2);
            NesneGorselleri.kontrolEkle(groupBox3);
            NesneGorselleri.kontrolEkle(groupBox5);
            NesneGorselleri.kontrolEkle(groupBox4);
            listeler.doldurSube(cmbSubeler1);
            listeler.doldurSube(cmbSubeler2);
            listeler.doldurSube(cmbSubeler3);
            masrafKartiListele();

        }
        public void masrafKartiListele()
        {
            try
            {
                listMasrafKartid.Clear();
                cmbMasrafKartSecimi.Items.Clear();
                SqlDataReader dr = veri.getDatareader("Select masrafKartid, masrafAdi from tblMasrafKartlari where firmaid = " + firma.firmaid + " and silindimi = '0' order by masrafAdi asc");
                while (dr.Read())
                {
                    listMasrafKartid.Add(Convert.ToInt32(dr["masrafKartid"]));
                    cmbMasrafKartSecimi.Items.Add(dr["masrafAdi"].ToString());
                }
            }
            catch { }
        }
        List<int> listMasrafKartid = new List<int>();
        List<int> listHastaid = new List<int>();
        private void frmGelirGiderRaporlari_Load(object sender, EventArgs e)
        {
            if (firma.hastane == "1")
            {
                dgGiderRaporlari.Columns["hastaAdiSoyadi"].Visible = true;
                cmbMasrafTipi.Items.Add("Hizmet Alan Gideri");
            }
            gelirListele();
        }

        public void gelirListele()
        {
            try
            {
                string sorgu = " ";
                if (txtGelirAdi.Text != "") sorgu = sorgu + " and gelirAdi like '%" + txtGelirAdi.Text + "%'";
                if (txtAciklama1.Text != "") sorgu = sorgu + " and aciklama like '%" + txtAciklama1.Text + "%'";
                if (chkİslemTarihi1.Checked) sorgu = sorgu + " and (islemTarihi between '" + dtİslemTarihi1.Value + "' and '" + dtİslemTarihi2.Value + "')";
                if (txtTutar1.Text != "") sorgu = sorgu + " and tutar " + cmbTutar1.Text + txtTutar1.Text.Replace(".", "").Replace(",", ".") + " ";
                if (cmbSubeler1.Text != "") sorgu = sorgu + " and subeid = " + ComboboxItem.getSelectedValue(cmbSubeler1) + "";
                if (cmbKullanicilar1.Text != "") sorgu = sorgu + " and kullaniciid = " + ComboboxItem.getSelectedValue(cmbKullanicilar1) + "";
                if (chkSilinenKayitlariGoster1.Checked) sorgu = sorgu + " and silindimi = '1'";
                else sorgu = sorgu + " and silindimi = '0'";
                dgGelirRaporlari.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("SELECT [gelirid],[gelirAdi],[tutar],[islemTarihi],[aciklama],[subeid],[subeAdi],[kullaniciid],[kAdi] FROM [sorGelirler] where [firmaid]=" + firma.firmaid + " " + sorgu + "");
                double toplamTutar = 0;
                while (dr.Read())
                {
                    dgGelirRaporlari.Rows.Add(dr["gelirid"].ToString(), dr["gelirAdi"].ToString(), Convert.ToDouble(dr["tutar"]), Convert.ToDateTime(dr["islemTarihi"]), dr["aciklama"].ToString(), dr["subeid"].ToString(), dr["subeAdi"].ToString(), dr["kullaniciid"].ToString(), dr["kAdi"].ToString(), "Düzenle", "Sil");
                    toplamTutar = toplamTutar + Convert.ToDouble(dr["tutar"]);
                }
                dgGelirRaporlari.ClearSelection();
                lblKayitSayisi1.Text = dgGelirRaporlari.Rows.Count.ToString();
                lblToplamTutar1.Text = String.Format("{0:n}", toplamTutar);
            }
            catch (Exception hata)
            {
            }
        }
        
        public void giderListele()
        {
            try
            {
                string sorgu = " ";
                if (cmbMasrafKartSecimi.SelectedIndex >= 0) sorgu = sorgu + " and masrafKartid = " + listMasrafKartid[cmbMasrafKartSecimi.SelectedIndex] + "";
                if (cmbMasrafTipi.Text == "Firma Gideri") sorgu = sorgu + " and masrafTipi = 'Firma Gideri'";
                else if (cmbMasrafTipi.Text == "Personel Gideri") sorgu = sorgu + " and personelid = " + listeler.getPersonelid()[cmbPersonelSecimi.SelectedIndex] + "";
                else if (cmbMasrafTipi.Text == "Cari Gideri") sorgu = sorgu + " and cariid = " + listeler.getCariid()[cmbCariSecimi.SelectedIndex] + "";
                else if (cmbMasrafTipi.Text == "Hizmet Alan Gideri") sorgu = sorgu + " and hastaid = " + listHastaid[cmbHastaSecimi.SelectedIndex] + "";

                if (txtAciklama2.Text != "") sorgu = sorgu + " and aciklama like '%" + txtAciklama2.Text + "%'";
                if (txtBelgeNo.Text != "") sorgu = sorgu + " and belgeNo like '%" + txtBelgeNo.Text + "%'";
                if (chkislemTarihi2.Checked) sorgu = sorgu + " and (islemTarihi between '" + dtislemTarihi3.Value + "' and '" + dtislemTarihi4.Value + "')";
                if (txtTutar2.Text != "") sorgu = sorgu + " and tutar " + cmbTutar2.Text + txtTutar2.Text.Replace(".", "").Replace(",", ".") + " ";
                if (cmbSubeler2.Text != "") sorgu = sorgu + " and subeid = " + ComboboxItem.getSelectedValue(cmbSubeler2) + "";
                if (cmbKullanicilar2.Text != "") sorgu = sorgu + " and kullaniciid = " + ComboboxItem.getSelectedValue(cmbKullanicilar2) + "";
                if (chkSilinenKayitlariGoster2.Checked) sorgu = sorgu + " and silindimi = '1'";
                else sorgu = sorgu + " and silindimi = '0'";
                dgGiderRaporlari.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("SELECT [masrafid],[masrafKartid],[masrafAdi],[islemTarihi],[tutar],[belgeNo],[aciklama],[masrafTipi],[hastaid],[hastaAdiSoyadi],[personelid],[personelAdiSoyadi],[cariid],[cariAdiSoyadi],[subeid],[subeAdi],[kullaniciid],[kAdi] FROM [sorMasraflar] where firmaid = "+firma.firmaid+sorgu+" ");
                double toplamTutar = 0;
                while (dr.Read())
                {
                    dgGiderRaporlari.Rows.Add(dr["masrafid"].ToString(), dr["masrafKartid"].ToString(), dr["masrafAdi"].ToString(), Convert.ToDouble(dr["tutar"]), dr["belgeNo"].ToString(), Convert.ToDateTime(dr["islemTarihi"]), dr["aciklama"].ToString(), dr["masrafTipi"].ToString(), dr["hastaid"].ToString(), dr["hastaAdiSoyadi"].ToString(), dr["personelid"].ToString(), dr["personelAdiSoyadi"].ToString(), dr["cariid"].ToString(), dr["cariAdiSoyadi"].ToString(), dr["subeid"].ToString(), dr["subeAdi"].ToString(), dr["kullaniciid"].ToString(), dr["kAdi"].ToString(), "Düzenle", "Sil");
                    toplamTutar = toplamTutar + Convert.ToDouble(dr["tutar"]);
                }
                dgGiderRaporlari.ClearSelection();
                lblKayitSayisi2.Text = dgGiderRaporlari.Rows.Count.ToString();
                lblToplamTutar2.Text = String.Format("{0:n}", toplamTutar);
            }
            catch (Exception hata)
            {
            }
        }

        public void gelirGiderListele()
        {
            try
            {
                string sorgu = " ";
                if (txtAciklama3.Text != "") sorgu = sorgu + " and aciklama like '%" + txtAciklama3.Text + "%'";
                if (chkislemTarihi3.Checked) sorgu = sorgu + " and (islemTarihi between '" + dtislemTarihi5.Value + "' and '" + dtislemTarihi6.Value + "')";
                if (txtTutar3.Text != "") sorgu = sorgu + " and tutar " + cmbTutar3.Text + txtTutar3.Text.Replace(".", "").Replace(",", ".") + " ";
                if (cmbSubeler3.Text != "") sorgu = sorgu + " and subeid = " + ComboboxItem.getSelectedValue(cmbSubeler3) + "";
                if (cmbKullanicilar3.Text != "") sorgu = sorgu + " and kullaniciid = " + ComboboxItem.getSelectedValue(cmbKullanicilar3) + "";
                if (chkSilinmisKayitlariGoster3.Checked) sorgu = sorgu + " and silindimi = '1'";
                else sorgu = sorgu + " and silindimi = '0'";
                dgGelirGiderRaporlari.Rows.Clear();
                SqlDataReader dr = veri.getDatareader("(select masrafAdi as gelirGiderAdi, masrafTipi as gelirGiderTipi, (tutar*-1) as tutar,islemTarihi,aciklama,subeAdi,kAdi from sorMasraflar where firmaid = " + firma.firmaid + sorgu + " union select gelirAdi as gelirGiderAdi,  'Gelir' as gelirGiderTipi,   tutar,islemTarihi,aciklama,subeAdi,kAdi from sorGelirler where firmaid = " + firma.firmaid + sorgu + ") order by islemTarihi desc");
                double toplamTutar = 0;
                while (dr.Read())
                {
                    dgGelirGiderRaporlari.Rows.Add(dr["gelirGiderAdi"].ToString(), dr["gelirGiderTipi"].ToString(), Convert.ToDouble(dr["tutar"]), Convert.ToDateTime(dr["islemTarihi"]), dr["aciklama"].ToString(), dr["subeAdi"].ToString(), dr["kAdi"].ToString());
                    toplamTutar = toplamTutar + Convert.ToDouble(dr["tutar"]);
                }
                dgGelirGiderRaporlari.ClearSelection();
                lblKayitSayisi3.Text = dgGelirGiderRaporlari.Rows.Count.ToString();
                lblToplamTutar3.Text = String.Format("{0:n}", toplamTutar);
            }
            catch (Exception hata)
            {
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tbMasrafRaporlari" && dgGiderRaporlari.Rows.Count == 0)
            {
                giderListele();
            }
            else if (tabControl1.SelectedTab.Name == "tbGelirGiderRaporlari" && dgGelirGiderRaporlari.Rows.Count == 0)
            {
                gelirGiderListele();
            }
        }

        void panelleriGizle()
        {
            pnlCari.Visible = false;
            pnlHasta.Visible = false;
            pnlPersonel.Visible = false;
            dgGiderRaporlari.Columns["cariAdiSoyadi"].Visible = false;
            dgGiderRaporlari.Columns["personelAdiSoyadi"].Visible = false;
            dgGiderRaporlari.Columns["hastaAdiSoyadi"].Visible = false;
        }


        private void cmbMasrafTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasrafTipi.Text == "Tümü")
            {
                panelleriGizle();
                dgGiderRaporlari.Columns["cariAdiSoyadi"].Visible = true;
                dgGiderRaporlari.Columns["personelAdiSoyadi"].Visible = true;
                dgGiderRaporlari.Columns["hastaAdiSoyadi"].Visible = true;
            }
            else if (cmbMasrafTipi.Text == "Firma Gideri")
            {
                panelleriGizle();
            }
            else if (cmbMasrafTipi.Text == "Personel Gideri")
            {
                try { cmbPersonelSecimi.Items.Clear(); cmbPersonelSecimi.Items.AddRange(listeler.getPersonelAdi()); }
                catch { }
                panelleriGizle();
                dgGiderRaporlari.Columns["personelAdiSoyadi"].Visible = true;
                pnlPersonel.Visible = true;
            }
            else if (cmbMasrafTipi.Text == "Cari Gideri")
            {
                try { cmbCariSecimi.Items.Clear(); cmbCariSecimi.Items.AddRange(listeler.getCariAdi()); }
                catch { }
                panelleriGizle();
                dgGiderRaporlari.Columns["cariAdiSoyadi"].Visible = true;
                pnlCari.Visible = true;
            }
            else if (cmbMasrafTipi.Text == "Hizmet Alan Gideri")
            {
                try
                {
                    if (cmbHastaSecimi.Items.Count == 0)
                    {
                        listHastaid.Clear();
                        cmbHastaSecimi.Items.Clear();
                        SqlDataReader dr = veri.getDatareader("select hastaid,(isnull(adi,'')+' '+isnull(soyadi,'')) as hastaAdiSoyadi from hTblHastalar where firmaid = " + firma.firmaid + " and silindimi = '0' order by adi,soyadi ");
                        while (dr.Read())
                        {
                            listHastaid.Add(Convert.ToInt32(dr["hastaid"]));
                            cmbHastaSecimi.Items.Add(dr["hastaAdiSoyadi"].ToString());
                        }
                        if (cmbHastaSecimi.Items.Count > 0) cmbHastaSecimi.SelectedIndex = 0;
                    }
                }
                catch { }
                panelleriGizle();
                dgGiderRaporlari.Columns["hastaAdiSoyadi"].Visible = true;
                pnlHasta.Visible = true;
                btnSorgula1.PerformClick();
            }
            else
            {
                MessageBox.Show("Geçerli bir Masraf Tipi seçmediniz.", firma.programAdi);
                cmbMasrafTipi.Select();
            }
        }

        private void btnSorgula1_Click(object sender, EventArgs e)
        {
            gelirListele();
        }

        private void btnSorgula2_Click(object sender, EventArgs e)
        {
            giderListele();
        }

        private void dgGiderRaporlari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgGiderRaporlari.Columns["sil2"].Index)
            {
                if (MessageBox.Show("Seçili kayıt silinsin mi?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    veri.cmd("Update tblMasraflar set silindimi = '1' Where masrafid = "+dgGiderRaporlari.CurrentRow.Cells["masrafid"].Value+" and firmaid = "+firma.firmaid+"");
                    giderListele();
                }
            }
            else if (e.ColumnIndex == dgGiderRaporlari.Columns["duzenle2"].Index)
            {
                frmMasraflar frm = new frmMasraflar();
                frm.txtAciklama.Text = dgGiderRaporlari.CurrentRow.Cells["aciklama2"].Value.ToString();
                frm.txtTutar.Text = dgGiderRaporlari.CurrentRow.Cells["tutar2"].Value.ToString();
                frm.cmbCariSecimi.Text = dgGiderRaporlari.CurrentRow.Cells["cariAdiSoyadi"].Value.ToString();
                frm.cmbHastaSecimi.Text = dgGiderRaporlari.CurrentRow.Cells["hastaAdiSoyadi"].Value.ToString();
                frm.cmbKullanicilar.Text = dgGiderRaporlari.CurrentRow.Cells["kullaniciAdi2"].Value.ToString();
                frm.cmbMasrafKartSecimi.Text = dgGiderRaporlari.CurrentRow.Cells["masrafAdi"].Value.ToString();
                frm.cmbMasrafTipi.Text = dgGiderRaporlari.CurrentRow.Cells["masrafTipi"].Value.ToString();
                frm.cmbPersonelSecimi.Text = dgGiderRaporlari.CurrentRow.Cells["personelAdiSoyadi"].Value.ToString();
                frm.cmbSubeler.Text = dgGiderRaporlari.CurrentRow.Cells["subeAdi2"].Value.ToString();
                frm.dtislemTarihi.Value = Convert.ToDateTime(dgGiderRaporlari.CurrentRow.Cells["islemTarihi2"].Value);
                frm.masrafid = Convert.ToInt32(dgGiderRaporlari.CurrentRow.Cells["masrafid"].Value);
                frm.Show();
            }
        }

        private void dgGelirRaporlari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgGelirRaporlari.Columns["sil1"].Index)
            {
                if (MessageBox.Show("Seçili kayıt silinsin mi?", firma.programAdi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    veri.cmd("Update tblGelirler set silindimi = '1' Where gelirid = " + dgGelirRaporlari.CurrentRow.Cells["gelirid"].Value + " and firmaid = " + firma.firmaid + "");
                    gelirListele();
                }
            }
            else if (e.ColumnIndex == dgGelirRaporlari.Columns["duzenle1"].Index)
            {
                frmGelirler frm = new frmGelirler();
                frm.txtGelirAdi.Text = dgGelirRaporlari.CurrentRow.Cells["gelirAdi"].Value.ToString();
                frm.txtAciklama.Text = dgGelirRaporlari.CurrentRow.Cells["aciklama"].Value.ToString();
                frm.txtTutar.Text = dgGelirRaporlari.CurrentRow.Cells["tutar"].Value.ToString();
                frm.cmbKullanicilar.Text = dgGelirRaporlari.CurrentRow.Cells["kullaniciAdi"].Value.ToString();
                frm.cmbSubeler.Text = dgGelirRaporlari.CurrentRow.Cells["subeAdi"].Value.ToString();
                frm.dtislemTarihi.Value = Convert.ToDateTime(dgGelirRaporlari.CurrentRow.Cells["islemTarihi"].Value);
                frm.gelirid = Convert.ToInt32(dgGelirRaporlari.CurrentRow.Cells["gelirid"].Value);
                frm.Show();
            }
        }

        private void btnSorgula3_Click(object sender, EventArgs e)
        {
            gelirGiderListele();
        }

        private void cmbSubeler1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar1, ComboboxItem.getSelectedValue(cmbSubeler1));
        }

        private void cmbSubeler2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar2, ComboboxItem.getSelectedValue(cmbSubeler2));
        }

        private void cmbSubeler3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanicilar3, ComboboxItem.getSelectedValue(cmbSubeler3));
        }

        private void btnRaporGoruntule3_Click(object sender, EventArgs e)
        {
            raporHazirla3();
            rpr3.onizleme();
        }
        rapor rpr3;
        void raporHazirla3()
        {
            rpr3 = new rapor();
            rpr3.yaziYazdirmaSiniri = 287;
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Gelir - Gider Raporları", new Font("Arial", 15, FontStyle.Bold), new Point(80, 5)));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("İşlem Adı", new Font("Arial", 10, FontStyle.Underline), new Rectangle(5, 15, 34, 4), false));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("İşlem Tipi", new Font("Arial", 10, FontStyle.Underline), new Rectangle(40, 15, 24, 4), false));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Tutar", new Font("Arial", 10, FontStyle.Underline), new Rectangle(65, 15, 24, 4), StringFormatFlags.DirectionRightToLeft, false));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Tarih", new Font("Arial", 10, FontStyle.Underline), new Rectangle(90, 15, 19, 4), false));
            rpr3.ekleSabitYazi(new rapor.sabitYazi("Açıklama", new Font("Arial", 10, FontStyle.Underline), new Rectangle(110, 15, 95, 4), false));
            for (int i = 0; i < dgGelirGiderRaporlari.Rows.Count; i++)
            {
                DataGridViewRow r = dgGelirGiderRaporlari.Rows[i];
                rpr3.ekleYazi(new rapor.yazi(r.Cells["gelirGiderAdi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(5, 20 + i * 4, 34, 4), false));
                rpr3.ekleYazi(new rapor.yazi(r.Cells["gelirGiderTipi"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(40, 20 + i * 4, 24, 4), false));
                rpr3.ekleYazi(new rapor.yazi(r.Cells["tutar3"].Value.ToString(), new Font("Arial", 10, FontStyle.Regular), new Rectangle(65, 20 + i * 4, 24, 4), StringFormatFlags.DirectionRightToLeft, true));
                rpr3.ekleYazi(new rapor.yazi(r.Cells["islemTarihi3"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(90, 20 + i * 4, 19, 4), false));
                rpr3.ekleYazi(new rapor.yazi(r.Cells["aciklama3"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), new Rectangle(110, 20 + i * 4, 95, 4), false));
                //rpr.ekleCizgi(new rapor.cizgi(5, rpr._kagitGenisligi - 10, 20 + i * 4, 20 + i * 4));
            }
            int yukseklik = 25 + dgGelirGiderRaporlari.Rows.Count * 4;
            rpr3.ekleCizgi(new rapor.cizgi(5, rpr3._kagitGenisligi - 10, yukseklik, yukseklik));
            yukseklik += 3;
            rpr3.ekleYazi(new rapor.yazi("Toplam Tutar: " + lblToplamTutar3.Text + " TL            Kayıt Sayısı: " + lblKayitSayisi3.Text + "            Yazdırma Tarihi: " + DateTime.Now.ToString() + "            www.elmaryazilim.com", new Point(5, yukseklik)));

        }

    }
}
