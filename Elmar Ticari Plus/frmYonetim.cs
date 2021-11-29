using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmYonetim : Form
    {
        private int seciliFirmaid = 0;
        public frmYonetim()
        {
            InitializeComponent();
            NesneGorselleri.form(this, false);
            NesneGorselleri.dataGridView(dgFirmaBilgileri);
            NesneGorselleri.dataGridView(dgKullanicilar);
            NesneGorselleri.dataGridView(dgSubeler);
            NesneGorselleri.dataGridView(dgUyariMesajlari);
            NesneGorselleri.dataGridView(dgOdemeKayitlari);
            NesneGorselleri.kontrolEkle(panel2);
            NesneGorselleri.kontrolEkle(panel4);
            NesneGorselleri.kontrolEkle(panel6);
            NesneGorselleri.kontrolEkle(panel8);
        }

        private void firmaListele(string sorgu)
        {
            seciliFirmaid = 0;
            dgFirmaBilgileri.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select firmaid, (adi+' '+soyadi) as firmaAdiSoyadi, gsm,email,bolge, webSitesi, aciklama, demomu, kalanGun, engellimi, maxSubeSayisi, maxKullaniciSayisi, uretim, stok, satis, kasa, cari, cekSenet, personel, banka, adisyon, mesajlar, hastane, otel, yurt, mobil, mobil2, smsAdet, eklenmeTarihi from sorFirmaBilgileri " + sorgu + " order by firmaid desc");
            while (dr.Read())
            {
                dgFirmaBilgileri.Rows.Add(dr["firmaid"].ToString(), dr["firmaAdiSoyadi"].ToString(), dr["gsm"].ToString(), dr["email"].ToString(), dr["bolge"].ToString(), dr["demomu"].ToString(), dr["kalanGun"].ToString(), dr["engellimi"].ToString(), dr["maxSubeSayisi"].ToString(), dr["maxKullaniciSayisi"].ToString(), dr["aciklama"].ToString(), dr["webSitesi"].ToString(), dr["uretim"].ToString(), dr["stok"].ToString(), dr["satis"].ToString(), dr["kasa"].ToString(), dr["cari"].ToString(), dr["cekSenet"].ToString(), dr["personel"].ToString(), dr["banka"].ToString(), dr["adisyon"].ToString(), dr["mesajlar"].ToString(), dr["hastane"].ToString(), dr["otel"].ToString(), dr["yurt"].ToString(), dr["mobil"].ToString(), dr["mobil2"].ToString(), dr["smsAdet"].ToString(), dr["eklenmeTarihi"].ToString());
            }
            dgFirmaBilgileri.ClearSelection();
        }

        private void frmYonetim_SizeChanged(object sender, EventArgs e)
        {
            pnlAcilis.Left = (this.Width - pnlAcilis.Width) / 2;
            pnlAcilis.Top = (this.Height - pnlAcilis.Height) / 2;
        }

        private int hataSayisi = 0;
        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Elmaryazilim.com571")
            {
                label5.Text = "Lütfen Bekleyin..";
                this.Refresh();
                panel2.Enabled = true;
                panel4.Enabled = true;
                panel6.Enabled = true;
                panel8.Enabled = true;
                pnlust.Enabled = true;
                dgFirmaBilgileri.Enabled = true;
                pnlAcilis.Visible = false;
                this.Refresh();
                firmaListele("");
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Şifre Yanlış");
                hataSayisi++;
                if (hataSayisi == 3)
                {
                    MessageBox.Show("3 Kez hatalı giriş yaptığınız", firma.programAdi);
                    this.Close();
                }
            }
        }

        private void dgFirmaBilgileri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seciliFirmaid = Convert.ToInt32(dgFirmaBilgileri.CurrentRow.Cells["firmaid"].Value);
                subeListele();
                kullaniciListele();
                uyariListele();
                odemeKaydiListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                seciliFirmaid = 0;
            }
        }


        private void subeListele()
        {
            dgSubeler.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select subeid, subeAdi, adres + ' ' + bolgeAdi as adresBilgisi, tel, gsm, fax, email, vergiDaire, vergiNo, eklenmeTarihi from sorFirmaSubeleri Where firmaid = " + seciliFirmaid + " order by subeid desc");
            while (dr.Read())
            {
                dgSubeler.Rows.Add(dr["subeid"].ToString(), dr["subeAdi"].ToString(), dr["adresBilgisi"].ToString(),
                    dr["tel"].ToString(), dr["gsm"].ToString(), dr["fax"].ToString(), dr["email"].ToString(),
                    dr["vergiDaire"].ToString(), dr["vergiNo"].ToString(), dr["eklenmeTarihi"].ToString());
            }
            dgSubeler.ClearSelection();
        }

        private void kullaniciListele()
        {
            dgKullanicilar.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select kullaniciid, kAdi, sifre, adiSoyadi, gorevi, onlinemi, eklenmeTarihi, subeAdi, girisizni, kullaniciip from sorFirmaKullanicilari Where firmaid = " + seciliFirmaid + " order by subeAdi asc, kAdi asc");
            while (dr.Read())
            {
                dgKullanicilar.Rows.Add(dr["kullaniciid"].ToString(), dr["kAdi"].ToString(), dr["sifre"].ToString(), dr["adiSoyadi"].ToString(), dr["gorevi"].ToString(), dr["onlinemi"].ToString(), dr["subeAdi"].ToString(), dr["girisizni"].ToString(), dr["kullaniciip"].ToString(), dr["eklenmeTarihi"].ToString());
            }
            dgKullanicilar.ClearSelection();
        }

        private void uyariListele()
        {
            dgUyariMesajlari.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select uyariid, uyariMetni, aktifmi, eklenmeTarihi, subeid, subeAdi, kullaniciid, kAdi from sorUyarilar Where firmaid = " + seciliFirmaid + " order by aktifmi asc, uyariid desc");
            while (dr.Read())
            {
                dgUyariMesajlari.Rows.Add(dr["uyariid"].ToString(), dr["uyariMetni"].ToString(), dr["aktifmi"].ToString(), dr["subeAdi"].ToString(), dr["kAdi"].ToString(), dr["eklenmeTarihi"].ToString(), "Sil");
            }
            dgUyariMesajlari.ClearSelection();
            lblUyariGostergeler.Text = "Kayıt Sayısı: " + dgUyariMesajlari.Rows.Count.ToString();
        }

        private void odemeKaydiListele()
        {
            double alacak = 0, borc = 0;
            dgOdemeKayitlari.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("Select odemeID, alacak, borc, kayitTarihi, vadeTarihi, odemeTarihi, islemTuru, aciklama, subeid, subeAdi, kullaniciid, kAdi from sorFirmaOdemeleri Where firmaid = " + seciliFirmaid + " order by kayitTarihi desc");
            while (dr.Read())
            {
                string _vadeTarihi = "";
                if (dr["vadeTarihi"] != null && dr["vadeTarihi"].ToString().Length >= 10) _vadeTarihi = dr["vadeTarihi"].ToString().Substring(0, 10);
                string _odemeTarihi = "";
                if (dr["odemeTarihi"] != null && dr["odemeTarihi"].ToString().Length >= 10) _odemeTarihi = dr["odemeTarihi"].ToString().Substring(0, 10);
                dgOdemeKayitlari.Rows.Add(dr["odemeID"].ToString(), dr["alacak"].ToString(), dr["borc"].ToString(), dr["kayitTarihi"].ToString().Substring(0, 10), _vadeTarihi, _odemeTarihi, dr["islemTuru"].ToString(), dr["aciklama"].ToString(), dr["subeAdi"].ToString(), dr["kAdi"].ToString(), "Sil");
                alacak += Convert.ToDouble(dr["alacak"]);
                borc += Convert.ToDouble(dr["borc"]);
            }
            dgOdemeKayitlari.ClearSelection();
            string durum = "Borçlusunuz";
            if (alacak > borc) durum = "Alacaklısınız";
            lblOdemeGostergeler.Text = "Kayıt Sayısı: " + dgOdemeKayitlari.Rows.Count.ToString();
            lblOdemeGostergeler.Text += "\nBakiye: " + (alacak - borc).ToString() + " TL " + durum;
        }

        private void btnYeniUyariMesaji_Click(object sender, EventArgs e)
        {
            if (seciliFirmaid == 0)
            {
                MessageBox.Show("lütfen geçerli bir firma seçin.", firma.programAdi);
                return;
            }
            frmYeniUyariMesaji frm = new frmYeniUyariMesaji(seciliFirmaid);
            frm.ShowDialog();
        }

        private void btnYeniOdemeKaydi_Click(object sender, EventArgs e)
        {
            if (seciliFirmaid == 0)
            {
                MessageBox.Show("lütfen geçerli bir firma seçin.", firma.programAdi);
                return;
            }
            frmYeniFirmaOdemesiEkle frm = new frmYeniFirmaOdemesiEkle(seciliFirmaid);
            frm.ShowDialog();
        }

        private void dgFirmaBilgileri_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgFirmaBilgileri.CurrentRow;
            veri.cmd("Update tblFirmaBilgileri set webSitesi = '" + r.Cells["webSitesi"].Value.ToString() + "', aciklama = '" + r.Cells["aciklama"].Value.ToString() + "', demomu = '" + r.Cells["demomu"].Value.ToString() + "', engellimi = '" + r.Cells["engellimi"].Value.ToString() + "', maxSubeSayisi = '" + r.Cells["maxSubeSayisi"].Value.ToString() + "', maxKullaniciSayisi = '" + r.Cells["maxKullaniciSayisi"].Value.ToString() + "', uretim = '" + r.Cells["uretim"].Value.ToString() + "', stok = '" + r.Cells["stok"].Value.ToString() + "', satis = '" + r.Cells["satis"].Value.ToString() + "', kasa = '" + r.Cells["kasa"].Value.ToString() + "', cari = '" + r.Cells["cari"].Value.ToString() + "', cekSenet = '" + r.Cells["cekSenet"].Value.ToString() + "', personel = '" + r.Cells["personel"].Value.ToString() + "', banka = '" + r.Cells["banka"].Value.ToString() + "', adisyon = '" + r.Cells["adisyon"].Value.ToString() + "', mesajlar = '" + r.Cells["mesajlar"].Value.ToString() + "', hastane = '" + r.Cells["hastane"].Value.ToString() + "', otel = '" + r.Cells["otel"].Value.ToString() + "', yurt = '" + r.Cells["yurt"].Value.ToString() + "', mobil = '" + r.Cells["mobil"].Value.ToString() + "', mobil2 = '" + r.Cells["mobil2"].Value.ToString() + "', smsAdet='" + r.Cells["smsAdet"].Value.ToString() + "' Where firmaid = " + r.Cells["firmaid"].Value.ToString());
        }

        private void frmYonetim_Load(object sender, EventArgs e)
        {

        }

        private void txtFirmaAdi_TextChanged(object sender, EventArgs e)
        {
            firmaListele(" Where adi like '%" + txtFirmaAdi.Text + "%' ");
        }

        private void txtFirmaSoyadi_TextChanged(object sender, EventArgs e)
        {
            firmaListele(" Where soyadi like '%" + txtFirmaSoyadi.Text + "%' ");
        }

        private void dgUyariMesajlari_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgUyariMesajlari.CurrentRow;
            veri.cmd("Update tblUyarilar set uyariMetni = '" + r.Cells["uyariMetni"].Value.ToString() + "', aktifmi = '" + r.Cells["aktifmi"].Value.ToString() + "' Where uyariid = " + r.Cells["uyariid"].Value.ToString());
        }

        private void dgOdemeKayitlari_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow r = dgOdemeKayitlari.CurrentRow;
            veri.cmd("Update tblFirmaOdemeleri set alacak = '" + r.Cells["alacak"].Value.ToString().Replace(",", ".") + "', borc = '" + r.Cells["borc"].Value.ToString().Replace(",", ".") + "', kayitTarihi = '" + r.Cells["kayitTarihi"].Value.ToString() + "', vadeTarihi = '" + r.Cells["vadeTarihi"].Value.ToString() + "', odemeTarihi = '" + r.Cells["odemeTarihi"].Value.ToString() + "', aciklama = '" + r.Cells["aciklama4"].Value.ToString() + "' Where odemeID = " + r.Cells["odemeID"].Value.ToString());
            odemeKaydiListele();
        }

        private void dgUyariMesajlari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgUyariMesajlari.Columns["sil2"].Index)
            {
                veri.cmd("Delete from tblUyarilar Where uyariid = " + dgUyariMesajlari.CurrentRow.Cells["uyariid"].Value.ToString() + "");
                dgUyariMesajlari.Rows.Remove(dgUyariMesajlari.CurrentRow);
            }
        }

        private void dgOdemeKayitlari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgOdemeKayitlari.Columns["sil3"].Index)
            {
                veri.cmd("Delete from tblFirmaOdemeleri Where odemeID = " + dgOdemeKayitlari.CurrentRow.Cells["odemeID"].Value.ToString() + "");
                dgOdemeKayitlari.Rows.Remove(dgOdemeKayitlari.CurrentRow);
            }
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            firmaListele(" Where firmaid in (Select firmaid from tblFirmaKullanicilari Where silindimi = '0' And  kAdi like '%" + txtKullaniciAdi.Text + "%') ");
        }
    }
}
