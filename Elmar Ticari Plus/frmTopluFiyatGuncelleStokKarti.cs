using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public partial class frmTopluFiyatGuncelleStokKarti : Form
    {
        public frmTopluFiyatGuncelleStokKarti()
        {
            InitializeComponent();
            veriGetir();

        }
        public void veriGetir()
        {
            cmbKategori.Items.Clear();
            try { cmbKategori.Items.AddRange(listeler.getKategoriadi()); }
            catch { }
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { cmbKategori.Tag = listeler.getKategoriNo()[cmbKategori.SelectedIndex]; }
            catch { cmbKategori.Tag = "0"; }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (cmbKategori.Text != "" && cmbKategori.Items.Contains(cmbKategori.Text) == false)
            {
                MessageBox.Show("Kategoriyi listeden seçin", firma.programAdi);
                cmbKategori.Select();
                return;
            }
            string katNo = "";
            if (cmbKategori.SelectedIndex >= 0) katNo = listeler.getKategoriNo()[cmbKategori.SelectedIndex];
            if (txtSatisFiyati.Text.Equals("0") || txtAlisFiyat.Text.Length <= 0)
            {
                MessageBox.Show("Lütfen Gerekli Boşlukları Doldurunuz..!", firma.programAdi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!bilgiVer()) return;
            string alis= txtAlisFiyat.Text.Replace(",",".");
            string satis= txtAlisFiyat.Text.Replace(",", ".");
            veri.cmd("update tblStokFiyatlari set fiyatTutari +=(fiyatTutari*(" + Convert.ToDouble(satis) + "))/100 where stokid in(select stokid from tblStokkart where firmaid=" + firma.firmaid + " and silindimi=0 and katNo='" + katNo + "')");
            if (!txtAlisFiyat.Text.Equals("0") || !txtAlisFiyat.Text.Equals(""))
                veri.cmd("update tblStokkart set alisFiyat +=(alisFiyat*(" + Convert.ToDouble(alis) + "))/100 where firmaid=" + firma.firmaid + " and silindimi=0 and katNo='" + katNo + "')");
            MessageBox.Show("İşlem Tamamlandı", firma.programAdi, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

       public bool bilgiVer()
        {
            var l1 = stokkart.listStokkart.Where(u =>(cmbKategori.Text == "" || u.katNo == listeler.getKategoriNo()[cmbKategori.SelectedIndex])).OrderByDescending(u => u.stokid);
            string bilgi = " Adet Stoğun %"+txtSatisFiyati.Text+" Fiyatında Güncelleme Yapılacaktır, Güncelleme Yapmak İstediğinize Emin Misiniz?";
            DialogResult d = MessageBox.Show(l1.Count()+ bilgi, "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes) return true;
            else return false;
        }
    }
}
