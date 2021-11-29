using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.Data.SqlServerCe;
namespace Elmar_Ticari_Plus
{
    public partial class frmSicakSatisAktarimModulu : Form
    {
        public frmSicakSatisAktarimModulu()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(groupBox3);
        }
        string yol = "";
        private void btnDosyaSecimi_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Title = "Veri Tabanı Seçimi";
            o.Filter = "Veri Tabanı Dosyaları|*.sdf";
            o.ShowDialog();
            if (o.SafeFileName == "")
            {
            }
            else
            {
                yol = o.FileName;
                txtYol.Text = yol;
                connectionStringOlustur();
            }
        }

        private void btnAktarimiBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKullaniciAdi.Text == "")
                {
                    MessageBox.Show("Kullanıcı adını girmediniz", firma.programAdi);
                    txtKullaniciAdi.Select();
                    return;
                }
                if (txtSifre.Text == "")
                {
                    MessageBox.Show("Şifreyi girmediniz", firma.programAdi);
                    txtSifre.Select();
                    return;
                }
                if (txtKullaniciAdi.Text.Contains(" "))
                {
                    MessageBox.Show("Kullanıcı Adı Boşluk Karakteri İçeremez", firma.programAdi);
                    txtKullaniciAdi.Select();
                    return;
                }
                if (txtKullaniciAdi.Text.Contains("é"))
                {
                    MessageBox.Show("Kullanıcı Adı 'é' özel karakterini içeremez.", firma.programAdi);
                    txtKullaniciAdi.Select();
                    return;
                }
                this.Refresh();
                string girisMesaji = "";
                string girisizni = "0";
                string onlinemi = "0";
                SqlDataReader dr = veri.getDatareader("exec [spGirisKontrol] '" + txtKullaniciAdi.Text + "','" + txtSifre.Text + "'");
                while (dr.Read())
                {
                    firma2.kullaniciAdi = txtKullaniciAdi.Text;
                    firma2.sifre = txtSifre.Text;
                    firma2.firmaid = Convert.ToInt32(dr[0]);
                    firma2.subeid = Convert.ToInt32(dr[1].ToString());
                    firma2.kullaniciid = Convert.ToInt32(dr[2].ToString());
                    girisizni = dr[3].ToString();
                    onlinemi = dr[4].ToString();
                    firma2.demoKalanGun = dr[5].ToString();
                    firma2.demomu = dr[6].ToString();
                    firma2.gorevi = "Plasiyer";
                    girisMesaji = dr[7].ToString();
                    firma2.muhasebe = "1";
                    firma2.personel = dr[8].ToString();
                    firma2.hastane = dr[11].ToString();
                    firma2.otel = dr[12].ToString();
                    firma2.yurt = dr[13].ToString();
                    firma2.programAdi = "Elmar Ticari Plus Mobile";
                    if (girisizni == "0")
                    {
                        MessageBox.Show(girisMesaji, firma2.programAdi);
                        return;
                    }
                    else
                    {
                        if (girisMesaji != "")
                        {
                            MessageBox.Show(girisMesaji, firma2.programAdi);
                        }
                        //Senkronize işlemini yap ve ana formu aç.
                        if (rdAnaYazilimToPDA.Checked) verileriCekVeGirisYap();
                        else if (rdPDAtoAnaYazilim.Checked) senkronizeEt();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        void verileriCekVeGirisYap()
        {
            p1.Value = 0;
            p1.Maximum = 13;
            this.Refresh();
            p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.tabloOlustur();
            p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.firmaVerileriniGuncelle2();
            p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.subeVerileriniGuncelle2();
            p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.stokkartVerileriniGuncelle2();
            p1.Value++; p1.Value++; p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.cariBilgileriVerileriniGuncelle2();
            p1.Value++; p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.ayarlariGuncelle2();
            p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.yetkileriGuncelle2();
            p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.yazdirmaKoordinatlariniGuncelle();
            p1.Value++; this.Refresh(); p1.Refresh();
            guncelle2.BankaPosBilgileriniGuncelle();
            p1.Value++; this.Refresh(); p1.Refresh();
            MessageBox.Show("Yükleme İşlemi Başarılı.", firma.programAdi);
        }

        void connectionStringOlustur()
        {

            veriCE.connectionstring = @"Data Source='" + yol + "';Encrypt Database=True;Password='elmar.yazilim123';File Mode=Read Write;Persist Security Info=False;SSCE:Default Lock Timeout=500";
            veriCE.bagliKal();
        }

        void senkronizeEt()
        {
            p1.Value = 0;
            p1.Maximum = 22;
            btnAktarimiBaslat.Enabled = false;
            if (guvenlikVeKontrol.internetVarmi() == false)
            {
                MessageBox.Show("İnternete erişilemediğinden aktarım yapılamıyor.", firma2.programAdi);
                btnAktarimiBaslat.Enabled = true;
                return;
            }
            //cari bilgileri aktarılıyor
            string aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblCariBilgileri Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            int aktarilan = 0;
            p1.Value++;
            SqlCeDataReader dr = veriCE.getdatareader("Select cariid, _cariid, adi, soyadi, vergiDaire, vergiNo, rfidKartNo, paraBirimi, limit, hesabaislensinmi, tel, gsm, fax, adres, subeid, kullaniciid from tblCariBilgileri Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //cari ekleniyor, güncelleniyor.
                int eklenenCariid = Convert.ToInt32(veri.getdatacell("exec spCariEkle 0, 0 ,'', '" + dr["adi"] + "','" + dr["soyadi"] + "', '" + dr["vergiDaire"] + "','" + dr["vergiNo"] + "', '',0, 0,'" + dr["paraBirimi"] + "', '" + dr["limit"].ToString().Replace(",", ".") + "','0', 'Mobilden Eklendi','', '','', '','0', " + firma2.firmaid + "," + dr["subeid"] + ", " + dr["kullaniciid"] + ""));
                veri.cmd("exec spAdresEkle 0, '" + eklenenCariid + "', 'İletişim Adresi', '" + dr["adi"] + "', '" + dr["soyadi"] + "', '', '" + dr["tel"] + "', '" + dr["gsm"] + "', '" + dr["fax"] + "', '0', '" + dr["adres"] + "', '', '', '" + dr["vergiDaire"] + "', '" + dr["vergiNo"] + "', '', '1', " + firma2.firmaid + ", " + dr["subeid"] + ", " + dr["kullaniciid"] + "");

                //Diğer tablolardaki ilişkiler düzenleniyor
                veriCE.cmd("Update tblCariBilgileri set cariid = " + eklenenCariid + ", _cariid = 0, servereYuklendimi = '1' where _cariid = " + dr["_cariid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblAcikHesap set cariid = " + eklenenCariid + ", _cariid = 0 where _cariid = " + dr["_cariid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblTicaretAyrinti set cariid = " + eklenenCariid + ", _cariid = 0 where _cariid = " + dr["_cariid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblBankaislemleri set cariid = " + eklenenCariid + ", _cariid = 0 where _cariid = " + dr["_cariid"] + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            p1.Value++; p1.Value++;
            //stok bilgileri aktarılıyor
            aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblStokkart Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            aktarilan = 0;
            p1.Value++;
            dr = veriCE.getdatareader("Select stokid, _stokid, stokkodu, rfidEtiketi, urunAdi, alisFiyat, kdv, kdvTipi, katNo, aktifmi, subeid, kullaniciid, servereYuklendimi from tblStokkart Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //stokkart ekleniyor
                int eklenenStokid = Convert.ToInt32(veri.getdatacell("exec spSetStokKartAyrinti " + 0 + ",'" + dr["stokkodu"] + "','','" + dr["urunAdi"] + "','" + dr["alisFiyat"].ToString().Replace(",", ".") + "','" + dr["kdv"] + "','" + dr["kdvTipi"] + "','" + dr["katNo"] + "','','','','','Mobilden Eklendi','','0'," + firma2.firmaid + "," + dr["subeid"] + "," + dr["kullaniciid"] + ""));
                //Diğer tablolardaki ilişkiler düzenleniyor
                veriCE.cmd("Update tblStokkart set stokid = " + eklenenStokid + ", _stokid = 0, servereYuklendimi = '1' where _stokid = " + dr["_stokid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblStokFiyatlari set stokid = " + eklenenStokid + ", _stokid = 0 where _stokid = " + dr["_stokid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblStokkartBirimleri set stokid = " + eklenenStokid + ", _stokid = 0 where _stokid = " + dr["_stokid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblTicaret set stokid = " + eklenenStokid + ", _stokid = 0 where _stokid = " + dr["_stokid"] + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            //Birimler Aktarılıyor
            aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblStokkartBirimleri Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            aktarilan = 0;
            p1.Value++;
            dr = veriCE.getdatareader("Select stokid, birimid, katsayi, barkod, subeid, kullaniciid from tblStokkartBirimleri where  firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //birim ekleniyor
                veri.cmd("exec spSetStokkartBirim 0," + dr["stokid"] + "," + dr["birimid"] + ",'" + dr["katsayi"] + "','" + dr["barkod"] + "'," + firma2.firmaid + "," + dr["subeid"] + "," + dr["kullaniciid"] + "");
                veriCE.cmd("Update tblStokkartBirimleri set servereYuklendimi = '1' where stokid = " + dr["stokid"] + " and barkod = '" + dr["barkod"] + "' and birimid = " + dr["birimid"] + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            //Fiyatlar Aktarılıyor
            aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblStokFiyatlari Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            aktarilan = 0;
            p1.Value++;
            dr = veriCE.getdatareader("Select stokid, fiyatid, indirimliFiyat, doviz, subeid, kullaniciid from tblStokFiyatlari where  firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //fiyat ekleniyor
                veri.cmd("exec spSetStokkartFiyat 0," + dr["stokid"] + "," + dr["fiyatid"] + "," + dr["indirimliFiyat"].ToString().Replace(",", ".") + ",0,'TL','" + dr["doviz"] + "'," + firma2.firmaid + "," + dr["subeid"] + "," + dr["kullaniciid"] + "");
                veriCE.cmd("Update tblStokFiyatlari set servereYuklendimi = '1' where stokid = " + dr["stokid"] + " and indirimliFiyat = " + dr["indirimliFiyat"] + " and fiyatid = " + dr["fiyatid"] + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            p1.Value++; p1.Value++;

            //Ticaret Ayrıntı Tablosu Aktarılıyor
            aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblTicaretAyrinti Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            aktarilan = 0;
            p1.Value++;
            dr = veriCE.getdatareader("Select ticaretAyrintiid, _ticaretAyrintiid, cariid, odemeTuru, islemTarihi, islemSaati, islemTuru, belgeNo, faturaNo, irsaliyeNo, vergiDaire, vergiNo, adres, faturaAciklamasi, islemAciklamasi, iskonto, hesabaislendimi, onay, subeid, kullaniciid from tblTicaretAyrinti where  firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //Ticaret Ayrıntı ekleniyor
                string islemTarihi = null;
                if (dr["islemTarihi"] != DBNull.Value) islemTarihi = String.Format("{0:dd.MM.yyyy}", Convert.ToDateTime(dr["islemTarihi"]));
                int ticaretAyrintiid = Convert.ToInt32(veri.getdatacell("exec spSetTicaretAyrinti 0," + dr["cariid"] + ",'" + dr["odemeTuru"] + "','" + islemTarihi + "','" + dr["islemSaati"] + "','','" + dr["islemTuru"] + "','" + dr["faturaNo"] + "','" + dr["belgeNo"] + "','" + dr["irsaliyeNo"] + "','" + dr["vergiDaire"] + "','" + dr["vergiNo"] + "','" + dr["adres"] + "','" + dr["faturaAciklamasi"] + "','" + dr["islemAciklamasi"] + "','','" + dr["iskonto"].ToString().Replace(",", ".") + "',0,0,'" + dr["hesabaislendimi"] + "','" + dr["onay"] + "','Mobil'," + firma2.firmaid + "," + dr["subeid"] + "," + dr["kullaniciid"] + ",0,'','','','',0,0,0,0,0"));
                veriCE.cmd("Update tblTicaretAyrinti set ticaretAyrintiid = " + ticaretAyrintiid + ", _ticaretAyrintiid = 0,  servereYuklendimi = '1' where _ticaretAyrintiid =  " + dr["_ticaretAyrintiid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblTicaret set ticaretAyrintiid = " + ticaretAyrintiid + ", _ticaretAyrintiid = 0 where _ticaretAyrintiid =  " + dr["_ticaretAyrintiid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblAcikHesap set ticaretAyrintiid = " + ticaretAyrintiid + ", _ticaretAyrintiid = 0 where _ticaretAyrintiid =  " + dr["_ticaretAyrintiid"] + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            p1.Value++; p1.Value++;

            //Ticaret Tablosu Aktarılıyor
            aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblTicaret Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            aktarilan = 0;
            p1.Value++;
            dr = veriCE.getdatareader("Select ticaretid, _ticaretid, ticaretAyrintiid, stokid, barkod, urunAdi, miktar, birim, katsayi, birimFiyat, kdv, kdvTipi, subeid, kullaniciid from tblTicaret where  firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //Ticaret ekleniyor
                int eklenenTicaretid = Convert.ToInt32(veri.getdatacell("exec spSetTicaret 0,'" + dr["ticaretAyrintiid"] + "','" + dr["stokid"] + "','" + dr["barkod"] + "','" + dr["urunAdi"] + "','" + dr["miktar"].ToString().Replace(",", ".") + "',0,'" + dr["birim"] + "','" + dr["katsayi"].ToString().Replace(",", ".") + "','" + dr["birimFiyat"].ToString().Replace(",", ".") + "','" + dr["kdv"] + "','" + dr["kdvTipi"] + "',0,0,0,'TL','1',0,''," + firma2.firmaid + "," + dr["subeid"] + "," + dr["kullaniciid"] + ""));
                veriCE.cmd("Update tblTicaret set ticaretid = " + eklenenTicaretid + ", _ticaretid = 0,  servereYuklendimi = '1' where _ticaretid =  " + dr["_ticaretid"] + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            p1.Value++; p1.Value++;

            //Banka bilgileri aktarılıyor
            aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblBankaislemleri Where firmaid = " + firma.firmaid + " and servereYuklendimi = '0'");
            aktarilan = 0;
            p1.Value++;
            dr = veriCE.getdatareader("Select [bankaislemid], [_bankaislemid],[bankaHesapid],[krediKartid],[posid],[taksitSayisi],[aylikTaksitTutari],[cekSenetid],[_cekSenetid],[cariBankaHesapid],[cariKrediKartid],[cariid],[_cariid],[tutar],[doviz],[dovizKuru],[ayrinti],[islemTuru],[islemTarihi],[firmaid],[subeid],[kullaniciid] from [tblBankaislemleri] Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //Banka İşlemi ekleniyor, güncelleniyor.
                string islemTarihi = null;
                if (dr["islemTarihi"] != DBNull.Value) islemTarihi = String.Format("{0:dd.MM.yyyy}", Convert.ToDateTime(dr["islemTarihi"]));
                int eklenenBankaislemid = Convert.ToInt32(veri.getdatacell("exec [spSetBankaislemleri] '0', '" + dr["bankaHesapid"] + "','" + dr["krediKartid"] + "','" + dr["posid"] + "','" + dr["taksitSayisi"] + "','" + dr["aylikTaksitTutari"].ToString().Replace(",", ".") + "','" + dr["cekSenetid"] + "','" + dr["cariBankaHesapid"] + "','" + dr["cariid"] + "','" + dr["tutar"].ToString().Replace(",", ".") + "','" + dr["doviz"].ToString().Replace(",", ".") + "','" + dr["dovizKuru"] + "','" + dr["ayrinti"] + "','" + dr["islemTuru"] + "','" + islemTarihi + "', '" + firma2.firmaid + "','" + dr["subeid"] + "','" + dr["kullaniciid"] + "'"));
                //Diğer tablolardaki ilişkiler düzenleniyor

                veriCE.cmd("Update [tblBankaislemleri] set [bankaislemid] = " + eklenenBankaislemid + ", [_bankaislemid] = 0,  servereYuklendimi = '1' where [_bankaislemid] =  " + dr["_bankaislemid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblAcikHesap set [bankaislemid] = " + eklenenBankaislemid + " where [bankaislemid] != 0 and [bankaislemid] = " + dr["bankaislemid"].ToString() + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            p1.Value++; 

            //Açık Hesap Tablosu Aktarılıyor
            aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblAcikHesap Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            aktarilan = 0;
            p1.Value++;
            dr = veriCE.getdatareader("Select acikHesapid, _acikHesapid, ticaretAyrintiid, cariid, kayitTarihi, odemeTarihi, vadeTarihi, borc, alacak, islemTuru, islemTuru2, aciklama, belgeNo, subeid, kullaniciid from tblAcikHesap where  firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //Açık Hesap ekleniyor
                string kayitTarihi = null;
                string odemeTarihi = null;
                string vadeTarihi = null;
                if (dr["kayitTarihi"] != DBNull.Value) kayitTarihi = String.Format("{0:dd.MM.yyyy}", Convert.ToDateTime(dr["kayitTarihi"]));
                if (dr["odemeTarihi"] != DBNull.Value) odemeTarihi = String.Format("{0:dd.MM.yyyy}", Convert.ToDateTime(dr["odemeTarihi"]));
                if (dr["vadeTarihi"] != DBNull.Value) vadeTarihi = String.Format("{0:dd.MM.yyyy}", Convert.ToDateTime(dr["vadeTarihi"]));
                int eklenenAcikHesapid = Convert.ToInt32(veri.getdatacell("exec spSetAcikHesap 0,'" + dr["ticaretAyrintiid"] + "',0,0,0,'" + dr["cariid"] + "','" + kayitTarihi + "','" + odemeTarihi + "','" + vadeTarihi + "','" + dr["borc"].ToString().Replace(",", ".") + "','" + dr["alacak"].ToString().Replace(",", ".") + "','TL',1,0,'" + dr["islemTuru"] + "','" + dr["islemTuru2"] + "','Kasa','" + dr["aciklama"] + "','','" + dr["belgeNo"] + "','','','','1'," + firma2.firmaid + "," + dr["subeid"] + "," + dr["kullaniciid"] + ""));
                veriCE.cmd("Update tblAcikHesap set acikHesapid = " + eklenenAcikHesapid + ", _acikHesapid = 0,  servereYuklendimi = '1' where _acikHesapid =  " + dr["_acikHesapid"] + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            p1.Value++; p1.Value++;

            //Kullanıcı Ayarları Aktarılıyor
            aktarilacakKayitSayisi = veriCE.getdatacell("Select count(*) from tblFirmaKullaniciAyarlari Where firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            aktarilan = 0;
            p1.Value++;
            dr = veriCE.getdatareader("Select ayarid, subeid, kullaniciid, ayarAdi, degeri from tblFirmaKullaniciAyarlari where  firmaid = " + firma2.firmaid + " and servereYuklendimi = '0'");
            while (dr.Read())
            {
                aktarilan++;
                this.Refresh();
                //Ayarlar Yükleniyor
                veri.cmd("Update tblFirmaKullaniciAyarlari set degeri = '" + dr["degeri"] + "' where ayarid = " + dr["ayarid"] + " and firmaid = " + firma2.firmaid + "");
                veriCE.cmd("Update tblFirmaKullaniciAyarlari set servereYuklendimi = '1' where ayarid =  " + dr["ayarid"] + " and firmaid = " + firma2.firmaid + "");
            }
            dr.Close();
            dr.Dispose();
            p1.Value++; p1.Value++;
            btnAktarimiBaslat.Enabled = true;
            p1.Value = 0;
            MessageBox.Show("Senkronize İşlemi Başarıyla Tamamlandı", firma2.programAdi);
        }

        private void frmSicakSatisAktarimModulu_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmYonetim frm = new frmYonetim();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}