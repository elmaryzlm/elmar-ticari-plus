using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
using System.Data.SqlClient;
namespace Elmar_Ticari_Plus
{
    public partial class frmPersonelVardiyasiEkle : Form
    {
        public frmPersonelVardiyasiEkle()
        {
            InitializeComponent();
            NesneGorselleri.form(this, Application.OpenForms["frmPersonelAna"]);
            NesneGorselleri.kontrolEkle(this);
            try { cmbPersonel.Items.AddRange(listeler.getPersonelAdi()); }
            catch { }
            vardiyaListele();
            if (personelVardiyaid != 0)
            {
                lblBaslik.Text = "Personel Vardiyası Düzenle";
            }
            else
            {
                if (cmbVardiya.Items.Count > 0) cmbVardiya.SelectedIndex = 0;
            }
        }
        public long personelVardiyaid = 0;
        public long personelid = 0;
        public long vardiyaid = 0;
        public frmPersonelVardiyalari _frmPersonelVardiyalari = null;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            veri.cmd("Exec spSetPersonelVardiyalari " + personelVardiyaid + "," + personelid + "," + vardiyaid + ",'"+dtBaslangicTarihi.Value+"','"+dtBitisTarihi.Value+"','"+txtTatilGunleri.Text+"',"+firma.firmaid+","+firma.subeid+","+firma.kullaniciid+" ");
            if (_frmPersonelVardiyalari != null) _frmPersonelVardiyalari.listele();
            if (personelVardiyaid == 0)
            {
                MessageBox.Show("Personele vardiya tanımlama işlemi başarıyla gerçekleştirildi.", firma.programAdi);
                this.Close();
            }
            else
            {
                MessageBox.Show("Personel vardiyası başarıyla düzenlendi.", firma.programAdi);
                this.Close();
            }
        }

        private void frmPersonelVardiyasiEkle_Load(object sender, EventArgs e)
        {
        }
        public List<long> listVardiyaid = new List<long>();
        private void cmbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            personelid = listeler.getPersonelid()[cmbPersonel.SelectedIndex];
        }

        public void vardiyaListele()
        {
            listVardiyaid.Clear();
            cmbVardiya.Items.Clear();
            SqlDataReader dr = veri.getDatareader("Select vardiyaid, vardiyaAdi + ' (' + CAST(baslangicSaati AS varchar(5)) + ' - ' + CAST(bitisSaati AS varchar(5)) + ')' AS vardiyaAdi from sorPersonelVardiyaTanim where firmaid = " + firma.firmaid + " order by vardiyaAdi asc");
            while (dr.Read())
            {
                listVardiyaid.Add(Convert.ToInt64(dr["vardiyaid"]));
                cmbVardiya.Items.Add(dr["vardiyaAdi"].ToString());
            }
        }


        private void cmbVardiya_SelectedIndexChanged(object sender, EventArgs e)
        {
            vardiyaid = listVardiyaid[cmbVardiya.SelectedIndex];
        }

        private void btnVardiyaEkle_Click(object sender, EventArgs e)
        {
            frmPersonelVardiyaTanimEkle frm = new frmPersonelVardiyaTanimEkle();
            frm._frmPersonelVardiyasiEkle = this;
            frm.Show();
        }
    }
}