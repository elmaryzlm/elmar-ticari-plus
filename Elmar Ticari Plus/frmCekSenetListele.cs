using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public partial class frmCekSenetListele : Form
    {
        public enum formTipi
        {
            kendiCekim, kendiSenedim, musteriCeki, musteriSenedi
        }
        public frmCekSenetListele(formTipi formTipi)
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgCekSenet);
            NesneGorselleri.kontrolEkle(panel3);
            NesneGorselleri.kontrolEkle(groupBox3);
            NesneGorselleri.kontrolEkle(panel6);
            NesneGorselleri.kontrolEkle(pnlCekSenetNo);
            NesneGorselleri.kontrolEkle(panel3);
            if (formTipi == frmCekSenetListele.formTipi.kendiCekim)
            {
                this.Text = "Kendi Çekim";
                pnlCekSenetNo.Visible = true;
                kendiÇekimiDüzenleToolStripMenuItem.Visible = true;
                kendiÇekimEkleToolStripMenuItem.Visible = true;
            }
            if (formTipi == frmCekSenetListele.formTipi.kendiSenedim)
            {
                this.Text = "Kendi Senedim";
                lblCekSenetBaslik.Text = "Senet No";
                kendiSenedimiDüzenleToolStripMenuItem.Visible = true;
                kendiSenedimEkleToolStripMenuItem.Visible = true;
            }
            if (formTipi == frmCekSenetListele.formTipi.musteriCeki)
            {
                this.Text = "Müşteri Çeki";
                pnlCekSenetNo.Visible = true;
                müşteriÇekiEkleToolStripMenuItem.Visible = true;
                müşteriÇekiniDüzenleToolStripMenuItem.Visible = true;
                
            }
            if (formTipi == frmCekSenetListele.formTipi.musteriSenedi)
            {
                this.Text = "Müşteri Senedi";
                lblCekSenetBaslik.Text = "Senet No";
                müşteriSenediEkleToolStripMenuItem.Visible = true;
                müşteriSenediniDüzenleToolStripMenuItem.Visible = true;
            }            
        }

        private void frmCekSenetListele_Load(object sender, EventArgs e)
        {
            cariListesiniYenile();
            listeler.doldurSube(cmbSube);
            btnSorgula_Click(sender,e);
        }
        public void cariListesiniYenile()
        {
            cmbCariler.Items.Clear();
            try
            {
                cmbCariler.Items.AddRange(listeler.getCariAdi());
            }
            catch { }
        }

        private void kendiÇekimEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.kendiCekimEkle,0,"");
            frm._frmCekSenetListele = this;
            frm.Show();
        }

        private void kendiSenedimEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.kendiSenedimEkle,0,"");
            frm._frmCekSenetListele = this;
            frm.Show();
        }

        private void müşteriÇekiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriCekiEkle,0,"");
            frm._frmCekSenetListele = this;
            frm.Show();
        }

        private void müşteriSenediEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriSenediEkle,0,"");
            frm._frmCekSenetListele = this;
            frm.Show();
        }

        private void kendiÇekimiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.kendiCekimDuzenle,0,"");
            frm._frmCekSenetListele = this;
            frm.cekSenetid = Convert.ToInt64(dgCekSenet.CurrentRow.Cells["cekSenetid"].Value);
            frm.Show();
        }

        private void kendiSenedimiDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.kendiSenedimDuzenle,0,"");
            frm._frmCekSenetListele = this;
            frm.cekSenetid = Convert.ToInt64(dgCekSenet.CurrentRow.Cells["cekSenetid"].Value);
            frm.Show();
        }

        private void müşteriÇekiniDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriCekiDuzenle,0,"");
            frm._frmCekSenetListele = this;
            frm.cekSenetid = Convert.ToInt64(dgCekSenet.CurrentRow.Cells["cekSenetid"].Value);
            frm.Show();
        }

        private void müşteriSenediniDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCekSenetEkle frm = new frmCekSenetEkle(frmCekSenetEkle.formTipi.musteriSenediDuzenle,0,"");
            frm._frmCekSenetListele = this;
            frm.cekSenetid = Convert.ToInt64(dgCekSenet.CurrentRow.Cells["cekSenetid"].Value);
            frm.Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("update tblCekSenet set silindimi ='1' where cekSenetid = " + dgCekSenet.CurrentRow.Cells["cekSenetid"].Value + " and firmaid = "+firma.firmaid+"");
                veri.cmd("update tblAcikHesap set silindimi ='1' where cekSenetid = " + dgCekSenet.CurrentRow.Cells["cekSenetid"].Value + " and firmaid = "+firma.firmaid+"");
                cekSenetListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silmede sorun oluştu. Hata Metni: "+hata.Message,firma.programAdi);
            }
          
        }
        Int64 cariid2 = 0;
        Int64 bankaHesapid2 = 0;
        public void cekSenetListele()
        {

            string sorguMetni = " Where firmaid = " + firma.firmaid + " and islemTuru = '" + this.Text + "'";
            if (chkSilinenKayitlariGoster.Checked == true) sorguMetni = sorguMetni + " and silindimi = '1' ";
            if (chkSilinenKayitlariGoster.Checked == false) sorguMetni = sorguMetni + " and silindimi = '0' ";
            if (txtSeriNo.Text != "") sorguMetni = sorguMetni + " and seriNo = " + txtSeriNo.Text + " ";
            if (txtCekSenetNo.Text != "") sorguMetni = sorguMetni + " and cekSenetNo = " + txtCekSenetNo.Text + " ";
            if (cmbCariler.Text != "") sorguMetni = sorguMetni + " and cariid = " + cariid2 + " ";
            if (cmbYeri.Text != "") sorguMetni = sorguMetni + " and yeri = '" + cmbYeri.Text + "' ";
            if (cmbDurumu.Text != "") sorguMetni = sorguMetni + " and durumu = '" + cmbDurumu.Text + "' ";
            if (chkKayitTarihi.Checked == true) sorguMetni = sorguMetni + " and (kayitTarihi between '" + dtKayit1.Value + "' and '" + dtKayit2.Value + "') ";
            if (chkOdemeTarihi.Checked == true) sorguMetni = sorguMetni + " and (odemeTarihi between '" + dtOdeme1.Value + "' and '" + dtOdeme2.Value + "') ";
            if (chkVadeTarihi.Checked == true) sorguMetni = sorguMetni + " and (vadeTarihi between '" + dtVade1.Value + "' and '" + dtVade2.Value + "') ";
            if (cmbSube.Text != "") sorguMetni = sorguMetni + " and subeid = " + ComboboxItem.getSelectedValue(cmbSube) + " ";
            if (cmbKullanici.Text != "") sorguMetni = sorguMetni + " and kullaniciid = " + ComboboxItem.getSelectedValue(cmbKullanici) + " ";


            dgCekSenet.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("SELECT [cekSenetid], [adiSoyadi], [cariid], [bankaHesapid], [ticaretAyrintiid], [seriNo], [CekSenetNo], [kayitTarihi], [odemeTarihi], [vadeTarihi], [tutari], [odeme], [dovizTuru], [dovizDegeri], [cekSenetGideri], [cekSenetBakiye],[bankaAdi],[subeAdi], [aciklama], [alacakliBorclu], [ciroEden], [faturaNo], [vergiDaire], [durumu], [yeri], [subeid], [kullaniciid] FROM [sorCekSenet] " + sorguMetni + " order by cekSenetid desc");
            while (dr.Read())
            {
                string _odemeTarihi = "";
                if (dr["odemeTarihi"].ToString().Length > 1) _odemeTarihi = string.Format("{0:d}",Convert.ToDateTime(dr["odemeTarihi"]));
                string _vadeTarihi = "";
                if (dr["vadeTarihi"].ToString().Length > 1) _vadeTarihi = string.Format("{0:d}", Convert.ToDateTime(dr["vadeTarihi"]));
                dgCekSenet.Rows.Add(dr["cekSenetid"].ToString(), dr["adiSoyadi"].ToString(), dr["cariid"].ToString(), dr["bankaHesapid"].ToString(), dr["ticaretAyrintiid"].ToString(), dr["seriNo"].ToString(), dr["CekSenetNo"].ToString(), Convert.ToDateTime(dr["kayitTarihi"]),_odemeTarihi,_vadeTarihi, Convert.ToDouble(dr["tutari"]),Convert.ToDouble(dr["odeme"]), dr["dovizTuru"].ToString(), dr["dovizDegeri"].ToString(), dr["cekSenetGideri"].ToString(), Convert.ToDouble(dr["cekSenetBakiye"]),dr["bankaAdi"].ToString()+" "+dr["subeAdi"].ToString(), dr["aciklama"].ToString(), dr["alacakliBorclu"].ToString(), dr["ciroEden"].ToString(), dr["faturaNo"].ToString(), dr["vergiDaire"].ToString(), dr["durumu"].ToString(), dr["yeri"].ToString(), dr["subeid"].ToString(), dr["kullaniciid"].ToString());   
            }

            lblKayitSayisi.Text = "Kayıt Sayısı: "+dgCekSenet.Rows.Count.ToString();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            cekSenetListele();
        }

        private void cmbSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanici, ComboboxItem.getSelectedValue(cmbSube));
        }

        private void silmeİşleminiGeriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("update tblCekSenet set silindimi ='0' where cekSenetid = " + dgCekSenet.CurrentRow.Cells["cekSenetid"].Value + " and firmaid = " + firma.firmaid + "");
                veri.cmd("update tblAcikHesap set silindimi ='0' where cekSenetid = " + dgCekSenet.CurrentRow.Cells["cekSenetid"].Value + " and firmaid = " + firma.firmaid + "");
                cekSenetListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Silmeyi geri alma işleminde sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void kasayaGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("update tblCekSenet set yeri = 'Kasa' where cekSenetid = " + dgCekSenet.CurrentRow.Cells["cekSenetid"].Value + " ");
                cekSenetListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Aktarımda sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void bankayaGönderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("update tblCekSenet set yeri = 'Banka' where cekSenetid = " + dgCekSenet.CurrentRow.Cells["cekSenetid"].Value + " ");
                cekSenetListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Aktarımda sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void iadeEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                veri.cmd("update tblCekSenet set durumu = 'İade Edildi' where cekSenetid = " + dgCekSenet.CurrentRow.Cells["cekSenetid"].Value + " ");
                cekSenetListele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İade İşleminde sorun oluştu. Hata Metni: " + hata.Message, firma.programAdi);
            }
        }

        private void cmbCariler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCariler.SelectedIndex>-1)cariid2 = listeler.getCariid()[cmbCariler.SelectedIndex];
        }

        private void cirolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
