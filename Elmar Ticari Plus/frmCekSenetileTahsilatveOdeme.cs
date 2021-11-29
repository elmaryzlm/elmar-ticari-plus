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
    public partial class frmCekSenetileTahsilatveOdeme : Form
    {

        private long cariid = 0;
        private int grupid = 0;
        private long _cekSenetid = 0, ticaretAyrintiid = 0;
        public frmTicaret _frmTicaret = null;
        string aciklama = "";
        double duzenlemeBakiyesi = 0;
        double eskiBakiye;
        
        public frmCekSenetileTahsilatveOdeme(long cariid, string cariAdiSoyadi, string tutari, string islemTipi, DateTime islemTarihi, int grupid, long ticaretAyrintiid, string aciklama, double duzenlemeBakiyesi) // alış-satış
        {
            baslangic();
            this.cariid = cariid;
            this.grupid = grupid;
            this.ticaretAyrintiid = ticaretAyrintiid;

            cmbCariler.Text = cariAdiSoyadi;
            cmbCariler.Enabled = false;

            this.cmbislemTipi.Text = islemTipi;
            dtİslemTarihi.Value = islemTarihi;

            cmbislemTipi.Enabled = false;
            dtİslemTarihi.Enabled = false;
            cmbEKullanicilar.Enabled = false;
            cmbESubeler.Enabled = false;

            txtTutar.Text = tutari;
            txtTutar.Enabled = false;

            txtPesinat.Visible = true;
            lblPesinat.Visible = true;
            txtPesinat.Select();
            this.duzenlemeBakiyesi = duzenlemeBakiyesi;

            this.aciklama = aciklama;
        }

        public frmCekSenetileTahsilatveOdeme(long cekSenetid, long ticaretAyrintiid, long cariid, string cariAdiSoyadi, string belgeNo, double tutar, string doviz, double dovizDegeri, string islemTipi, DateTime islemTarihi, string aciklama, double eskiBakiye)//düzenle (saçma)
        {
            baslangic();
            this.cariid = cariid;
            //txtBelgeNo.Text = belgeNo;
            this._cekSenetid = cekSenetid;
            this.ticaretAyrintiid = ticaretAyrintiid;
            cmbCariler.Text = cariAdiSoyadi;
            txtTutar.Text = String.Format("{0:n2}", tutar);
            txtDovizKuru.Text = doviz;
            txtDovizDegeri.Text = String.Format("{0:n2}", dovizDegeri);
            if (islemTipi.Contains("Satış")) cmbislemTipi.Text = "Satış";
            else if (islemTipi.Contains("Alış")) cmbislemTipi.Text = "Alış";
            dtİslemTarihi.Value = islemTarihi;
            txtAcklama.Text = aciklama;
            this.eskiBakiye = eskiBakiye;
            this.Text = "Alış, Satış Düzenle";
        }

        public frmCekSenetileTahsilatveOdeme(long cariid, string cariAdiSoyadi, string islemTipi)//ciro
        {
            baslangic();
            this.cariid = cariid;
            if(cariid!=0)cmbCariler.Text = cariAdiSoyadi;

            this.cmbislemTipi.Text = islemTipi;
            cmbislemTipi.Enabled = false;


            
            txtTutar.Visible = false;
            txtAcikHesap.Visible = false;
            txtDovizDegeri.Visible = false;
            txtDovizKuru.Visible = false;
            txtDovizliTutar.Visible = false;
            txtPesinat.Visible = false;
            txtKendiCekim.Visible = false;
            txtKendiSenedim.Visible = false;
            lblTutar.Visible = false;
            lblAcikHesap.Visible = false;
            lblDoviz.Visible = false;
            lblDovizKuru.Visible = false;
            lblDovizliTutar.Visible = false;
            lblPesinat.Visible = false;
            lblkendiCekim.Visible = false;
            lblKendiSenedim.Visible = false;

            lblBaslik.Text = "Çek- Senet Cirolama";
        }

        void baslangic()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgCekSenetListesi);
            NesneGorselleri.dataGridView(dgSecilenCekSenetler);
            NesneGorselleri.kontrolEkle(panel3);
            try { cmbCariler.Items.AddRange(listeler.getCariAdi()); }
            catch { }
            listeler.doldurSube(cmbESubeler);
        }

        private void frmCekSenetileTahsilatveOdeme_Load(object sender, EventArgs e)
        {
            cekSenetListele();
        }

        private void chkKendiCekim_Click(object sender, EventArgs e)
        {
            cekSenetListele();
        }
        public void cekSenetListele()
        {
            string sorgu = "''";
            if (chkKendiCekim.Checked) sorgu = sorgu + ",'Kendi Çekim'";
            if (chkKendiSenedim.Checked) sorgu = sorgu + ",'Kendi Senedim'";
            if (chkMusteriCeki.Checked) sorgu = sorgu + ",'Müşteri Çeki'";
            if (chkMusteriSenedi.Checked) sorgu = sorgu + ",'Müşteri Senedi'";
            if (sorgu.Length > 3) sorgu = " and islemTuru in(" + sorgu + ") ";
            else sorgu = "";
            if (cmbislemTipi.Text == "Satış") sorgu = sorgu + " and cariid = "+cariid+"";
            dgCekSenetListesi.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select cekSenetid, cekSenetNo, kayitTarihi, vadeTarihi, tutari, dovizTuru, dovizDegeri, islemTuru, adiSoyadi, cariid  from sorCekSenet where firmaid = " + firma.firmaid + " and subeid = " + firma.subeid + " and yeri = 'Kasa' and durumu = 'Ödenmedi' and silindimi = '0' and Datediff(day,GETDATE(),vadeTarihi)>=0  " + sorgu + " order by islemTuru, vadeTarihi, tutari asc");
            //and cekSenetid not in (select cekSenetid from sorAcikHesap where firmaid = " + firma.firmaid + " and ticaretAyrintiid!=0)
            //and (((islemTuru = 'Müşteri Çeki' or islemTuru = 'Müşteri Senedi') and cariid != " + cariid + ") or (islemTuru = 'Kendi Çekim' or islemTuru = 'Kendi Senedim')) 

            while (dr.Read())
            {
                bool varmi = false;
                for (int i = 0; i < dgSecilenCekSenetler.Rows.Count; i++)
                {
                    if (dgSecilenCekSenetler.Rows[i].Cells["cekSenetid2"].Value.ToString() == dr["cekSenetid"].ToString())
                    {
                        varmi = true;
                        break;
                    }
                    if (dr["cariid"].ToString() == cariid.ToString() && dr["islemTuru"].ToString().Contains("Müşteri") && (cmbislemTipi.Text == "Alış" || cmbislemTipi.Text == "Ciro"))
                    {
                        varmi = true;
                        break;
                    }
                }
                if (varmi == false) dgCekSenetListesi.Rows.Add("Ekle", dr["cekSenetid"].ToString(), dr["cekSenetNo"].ToString(), Convert.ToDateTime(dr["kayitTarihi"]), Convert.ToDateTime(dr["vadeTarihi"]), Convert.ToDouble(dr["tutari"]), dr["dovizTuru"].ToString(), dr["dovizDegeri"].ToString(), dr["islemTuru"].ToString(), dr["adiSoyadi"].ToString(), dr["cariid"].ToString());
            }
            cekOrtvade_hesapla();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtTutar.Text == "0")
                //{
                //    MessageBox.Show("Tutarı Girmediniz", firma.programAdi);
                //    txtTutar.Select();
                //    return;
                //}
                if (cariid == 0)
                {
                    MessageBox.Show("Cari Seçmediniz", firma.programAdi);
                    cmbCariler.Select();
                    return;
                }
                if (cmbislemTipi.Items.Contains(cmbislemTipi.Text) == false)
                {
                    MessageBox.Show("İşlem Tipini listeden seçin", firma.programAdi);
                    cmbislemTipi.Select();
                    return;
                }
                if (ComboboxItem.seciliMetinKontrolu(cmbESubeler) == false)
                {
                    MessageBox.Show("Şubeyi listeden seçin", firma.programAdi);
                    cmbESubeler.Select();
                    return;
                }
                if (ComboboxItem.seciliMetinKontrolu(cmbEKullanicilar) == false)
                {
                    MessageBox.Show("Kullanıcıyı listeden seçin", firma.programAdi);
                    cmbEKullanicilar.Select();
                    return;
                }
                double borc = 0; double alacak = 0;
                string islemTuruMetni = "";
                if (this.cmbislemTipi.Text != "Ciro")
                {
                    //Açık Hesap Alış-Satış kaydı ekleniyor
                    if (this.cmbislemTipi.Text == "Alış")
                    {
                        borc = Convert.ToDouble(txtTutar.Text);
                        islemTuruMetni = "Alış";
                    }
                    else if (this.cmbislemTipi.Text == "Satış")
                    {
                        alacak = Convert.ToDouble(txtTutar.Text);
                        islemTuruMetni = "Satış";
                    }
                    acikHesap.ekle(0, ticaretAyrintiid, 0, 0, 0, cariid, dtİslemTarihi.Value, Convert.ToDateTime(null), Convert.ToDateTime(null), borc, alacak, txtDovizKuru.Text, Convert.ToDouble(txtDovizDegeri.Text), 0, "Çek-Senet", islemTuruMetni, "Kasa", txtAcklama.Text, "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, 0);

                    //Peşinat kaydı Ekleniyor.
                    alacak = 0; borc = 0;
                    if (this.cmbislemTipi.Text == "Alış")
                    {
                        islemTuruMetni = "Ödeme";
                        alacak = Convert.ToDouble(txtPesinat.Text);
                    }
                    else if (this.cmbislemTipi.Text == "Satış")
                    {
                        islemTuruMetni = "Tahsilat";
                        borc = Convert.ToDouble(txtPesinat.Text);
                    }
                    if (Convert.ToDouble(txtPesinat.Text) > 0)
                    {
                        acikHesap.ekle(0, ticaretAyrintiid, 0, 0, 0, cariid, dtİslemTarihi.Value, dtİslemTarihi.Value, Convert.ToDateTime(null), borc, alacak, "TL", 1, 0, "Açık Hesap", islemTuruMetni, "Kasa", txtAcklama.Text, "", "", "", "", "", "1", "0", firma.subeid, firma.kullaniciid, grupid, duzenlemeBakiyesi);
                    }
                }
                //Listedeki Çek-Senetler Ekleniyor
                for (int i = 0; i < dgSecilenCekSenetler.Rows.Count; i++)
			    {
                    DataGridViewRow r = dgSecilenCekSenetler.Rows[i];
                    
                    string ciroEden = "", alacakliBorclu="", yeri="Kasa";
                    alacakliBorclu = cmbCariler.Text;
                    if (r.Cells["islemTuru2"].Value.ToString().Contains("Müşteri") && cmbislemTipi.Text != "Satış")
                    {
                        ciroEden = r.Cells["adiSoyadi2"].Value.ToString();
                        yeri = "Cari";
                    }
                    veri.cmd("Update tblCekSenet set cariid = " + cariid + ", ciroEden = '" + ciroEden + "', alacakliBorclu = '" + alacakliBorclu + "', durumu = 'Ödenmedi', yeri = '"+yeri+"' where firmaid = " + firma.firmaid + " and cekSenetid = " + r.Cells["cekSenetid2"].Value.ToString() + "");


                    if (grupid!=0) ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().listCekSenetID.Add(r.Cells["cekSenetid2"].Value.ToString());

                    //if(ticaretAyrintiid>0)veri.cmd("delete from tblAcikHesap Where firmaid = " + firma.firmaid + " and ticaretAyrintiid = " + ticaretAyrintiid + "  ");

                    if (r.Cells["islemTuru2"].Value.ToString().Contains("Müşteri") && cmbislemTipi.Text != "Satış")//çek-senetin cirolandığı cariye açık hesap kaydı ekleniyor
                    {
                        veri.cmd("Update tblAcikHesap set aciklama = aciklama + ' Ciro Eden'  where firmaid = " + firma.firmaid + " and cekSenetid = " + r.Cells["cekSenetid2"].Value.ToString() + "");

                        alacak = Convert.ToDouble(r.Cells["tutari2"].Value);
                        borc = 0;
                        islemTuruMetni = "Alacak";
                        acikHesap.ekle(0, ticaretAyrintiid, Convert.ToInt64(r.Cells["cekSenetid2"].Value), 0, 0, cariid, dtİslemTarihi.Value, Convert.ToDateTime(null), Convert.ToDateTime(r.Cells["vadeTarihi2"].Value), borc, alacak, r.Cells["dovizTuru2"].Value.ToString(), Convert.ToDouble(r.Cells["dovizDegeri2"].Value), 0, "Çek-Senet", islemTuruMetni, "Kasa", txtAcklama.Text +" Ciro Edilen" , "", "", "", "", "", "1", "0", Convert.ToInt32(ComboboxItem.getSelectedValue(cmbESubeler)), Convert.ToInt32(ComboboxItem.getSelectedValue(cmbEKullanicilar)), grupid, 0);
                    }
			    }
                        
                btnTemizle.PerformClick();
                lblDurum.Text = "Kaydedildi";
                if (_cekSenetid != 0) this.Close();
            }
            catch (Exception hata)
            {
                lblDurum.Text = "Kaydedilirken hata oluştu. Hata Metni: " + hata.Message;
            }
        }

        private void cmbESubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbEKullanicilar, ComboboxItem.getSelectedValue(cmbESubeler));
        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(true);
        }

        void hesapla_AcikHesap(bool dovizKuruOtomatikGetirilsinmi)
        {
            try
            {
                double pb = 1.0;
                if (dovizKuruOtomatikGetirilsinmi)
                {
                    if (txtDovizKuru.Text == "USD") pb = Convert.ToDouble(bilgiler.dovizVerileri.dDolarsatis);
                    else if (txtDovizKuru.Text == "EURO") pb = Convert.ToDouble(bilgiler.dovizVerileri.dEurosatis);
                    txtDovizDegeri.Text = pb.ToString();
                }
                else
                {
                    pb = Convert.ToDouble(txtDovizDegeri.Text);
                }
                txtDovizliTutar.Text = String.Format("{0:n2}", (pb * Convert.ToDouble(txtTutar.Text)));
                cekOrtvade_hesapla();
            }
            catch (Exception hata)
            {
                lblDurum.Text = hata.Message;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (_frmTicaret != null)
            {
                _frmTicaret._pesinat = Convert.ToDouble(txtPesinat.Text);
                _frmTicaret.yeniKayit();
                ticaretAyrinti2.listTicaretAyrinti.Where(u => u.grupid == grupid).First().islemTamamlandimi = true;
                this.Close();
            }
            duzenlemeBakiyesi = 0;
            txtAcklama.Clear();
            txtTutar.Text = "0";
            txtDovizliTutar.Text = "0";
            txtMusteriCeki.Text = "0";
            txtMusteriSenedi.Text = "0";
            txtKendiCekim.Text = "0";
            txtKendiSenedim.Text = "0";
            txtAcikHesap.Text = "0";
            txtTutar.Select();
            lblDurum.Text = "Temizlendi";
            dgSecilenCekSenetler.Rows.Clear();
            cekSenetListele();
        }

        private void dgCekSenetListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgCekSenetListesi.Columns["ekle"].Index)
            {
                DataGridViewRow r = dgCekSenetListesi.CurrentRow;
                dgSecilenCekSenetler.Rows.Add("Çıkar", r.Cells["cekSenetid"].Value, r.Cells["cekSenetNo"].Value, r.Cells["kayitTarihi"].Value, r.Cells["vadeTarihi"].Value, r.Cells["tutari"].Value, r.Cells["dovizTuru"].Value, r.Cells["dovizDegeri"].Value, r.Cells["islemTuru"].Value, r.Cells["adiSoyadi"].Value, r.Cells["_cariid"].Value);
                dgCekSenetListesi.Rows.Remove(dgCekSenetListesi.CurrentRow);
            }
            cekOrtvade_hesapla();
        }

        private void dgSecilenCekSenetler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgSecilenCekSenetler.Columns["cikar"].Index)
            {
                DataGridViewRow r = dgSecilenCekSenetler.CurrentRow;
                dgCekSenetListesi.Rows.Add("Ekle", r.Cells["cekSenetid2"].Value, r.Cells["cekSenetNo2"].Value, r.Cells["kayitTarihi2"].Value, r.Cells["vadeTarihi2"].Value, r.Cells["tutari2"].Value, r.Cells["dovizTuru2"].Value, r.Cells["dovizDegeri2"].Value, r.Cells["islemTuru2"].Value, r.Cells["adiSoyadi2"].Value, r.Cells["_cariid2"].Value);
                dgSecilenCekSenetler.Rows.Remove(dgSecilenCekSenetler.CurrentRow);
            }
            cekOrtvade_hesapla();
        }
        void cekOrtvade_hesapla()
        {
            double ortVade = 0;
            double musteriCekiToplam = 0, musteriSenediToplam = 0, kendiCekimToplam = 0, kendiSenedimToplam = 0;
            DateTime Gunceltarih;
            for (int i = 0; i < dgSecilenCekSenetler.Rows.Count; i++)
            {
                Gunceltarih = Convert.ToDateTime(dgSecilenCekSenetler.Rows[i].Cells["vadeTarihi2"].Value);
                TimeSpan gunSayisi = Gunceltarih - Convert.ToDateTime(DateTime.Now.ToShortDateString());
                ortVade = ortVade + Convert.ToDouble(gunSayisi.TotalDays);
                if (dgSecilenCekSenetler.Rows[i].Cells["islemTuru2"].Value.ToString() == "Kendi Çekim") kendiCekimToplam = kendiCekimToplam + Convert.ToDouble(dgSecilenCekSenetler.Rows[i].Cells["tutari2"].Value);
                else if (dgSecilenCekSenetler.Rows[i].Cells["islemTuru2"].Value.ToString() == "Kendi Senedim") kendiSenedimToplam = kendiSenedimToplam + Convert.ToDouble(dgSecilenCekSenetler.Rows[i].Cells["tutari2"].Value);
                else if (dgSecilenCekSenetler.Rows[i].Cells["islemTuru2"].Value.ToString() == "Müşteri Çeki") musteriCekiToplam = musteriCekiToplam + Convert.ToDouble(dgSecilenCekSenetler.Rows[i].Cells["tutari2"].Value);
                else if (dgSecilenCekSenetler.Rows[i].Cells["islemTuru2"].Value.ToString() == "Müşteri Senedi") musteriSenediToplam = musteriSenediToplam + Convert.ToDouble(dgSecilenCekSenetler.Rows[i].Cells["tutari2"].Value);
            }
            ortVade = ortVade / dgSecilenCekSenetler.Rows.Count;
            txtOrtVade.Text =String.Format("{0:n2}", ortVade);
            txtToplam.Text = String.Format("{0:n2}", kendiSenedimToplam+kendiCekimToplam+musteriCekiToplam+musteriSenediToplam);
            txtKendiCekim.Text = String.Format("{0:n2}", kendiCekimToplam);
            txtKendiSenedim.Text = String.Format("{0:n2}", kendiSenedimToplam);
            txtMusteriCeki.Text = String.Format("{0:n2}", musteriCekiToplam);
            txtMusteriSenedi.Text = String.Format("{0:n2}", musteriSenediToplam);
            txtAcikHesap.Text = String.Format("{0:n2}", (Convert.ToDouble(txtDovizliTutar.Text) - Convert.ToDouble(txtPesinat.Text) - musteriCekiToplam - musteriSenediToplam - kendiCekimToplam - kendiSenedimToplam));
        }

        private void txtDovizKuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(true);
        }

        private void txtDovizDegeri_TextChanged(object sender, EventArgs e)
        {
            hesapla_AcikHesap(false);
        }

        private void cmbislemTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbislemTipi.Text == "Satış" || cmbislemTipi.Text == "Ciro")
            {
                chkKendiCekim.Checked = false;
                chkKendiSenedim.Checked = false;
                chkKendiCekim.Enabled = false;
                chkKendiSenedim.Enabled = false;
                btnKendiCekimEkle.Enabled = false;
                btnKendiSenedimEkle.Enabled = false;
                cekSenetListele(); 
            }
            else if (cmbislemTipi.Text == "Alış")
            {
                chkKendiCekim.Checked = true;
                chkKendiSenedim.Checked = true;
                chkKendiCekim.Enabled = true;
                chkKendiSenedim.Enabled = true;
                btnKendiCekimEkle.Enabled = true;
                btnKendiSenedimEkle.Enabled = true;
                cekSenetListele(); 
            }
            else
            {
                MessageBox.Show("Lütfen listeden seçim yapın", firma.programAdi);
                cmbislemTipi.Select();
                return;
            }
        }

        private void btnKendiCekimEkle_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.kendiCekimEkle, cariid, cmbCariler.Text);
            frm._frmCekSenetileTahsilatveOdeme = this;
            frm.Show();
        }

        private void btnKendiSenedimEkle_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.kendiSenedimEkle, cariid, cmbCariler.Text);
            frm._frmCekSenetileTahsilatveOdeme = this;
            frm.Show();
        }

        private void btnMusteriCekiEkle_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriCekiEkle, cariid, cmbCariler.Text);
            frm._frmCekSenetileTahsilatveOdeme = this;
            frm.Show();
        }

        private void btnMusteriSenediEkle_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriSenediEkle, cariid, cmbCariler.Text);
            frm._frmCekSenetileTahsilatveOdeme = this;
            frm.Show();
        }

        private void frmCekSenetileTahsilatveOdeme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnKaydet.PerformClick();
            }
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            cariid = listeler.getCariid()[cmbCariler.SelectedIndex];
            cekSenetListele();
        }
    }
}
