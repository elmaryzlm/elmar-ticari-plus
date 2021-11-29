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
    public partial class frmGunlukKasa : Form
    {
        public frmGunlukKasa()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgKasa);
            NesneGorselleri.dataGridView(dgBanka);
            NesneGorselleri.kontrolEkle(dgKasa);
            NesneGorselleri.kontrolEkle(panel3);
        }

        private void frmGunlukKasa_Load(object sender, EventArgs e)
        {
            listeler.doldurSube(cmbSube);
            tumListeleriYenile();
        }

        void gostergeleriHesapla()
        {
            try
            {
                lblNakitKasaDolar.Text = "0,00";
                lblNakitKasaEuro.Text = "0,00";
                lblNakitKasaTL.Text = "0,00";
                SqlDataReader rw = veri.getDatareader("select SUM(tutar)  tutar, dovizTuru as doviz from dbo.[fonkGetKasaBilgileri_kasa_devir](" + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbSube) + ", " + ComboboxItem.getSelectedValue(cmbKullanici) + ", '" + dtTarih.Value + "')  group by dovizTuru");
                while (rw.Read())
                {
                    if (rw[1].ToString() == "EURO") lblNakitKasaEuro.Text = String.Format("{0:n2}", Convert.ToDouble(rw[0]));
                    else if (rw[1].ToString() == "TL") lblNakitKasaTL.Text = String.Format("{0:n2}", Convert.ToDouble(rw[0])); 
                    else if (rw[1].ToString() == "USD")lblNakitKasaDolar.Text = String.Format("{0:n2}", Convert.ToDouble(rw[0])); 
                }
            }
            catch { }

            try
            {
                lblBankaDolar.Text = "0,00";
                lblBankaEuro.Text = "0,00";
                lblBankaTL.Text = "0,00";
                SqlDataReader rw = veri.getDatareader("select SUM(tutar)  tutar, doviz from dbo.[fonkGetKasaBilgileri_banka_devir](" + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbSube) + ", " + ComboboxItem.getSelectedValue(cmbKullanici) + ", '" + dtTarih.Value + "')  group by doviz");
                while (rw.Read())
                {
                    if (rw[1].ToString() == "EURO") lblBankaEuro.Text = String.Format("{0:n2}", Convert.ToDouble(rw[0]));
                    else if (rw[1].ToString() == "TL") lblBankaTL.Text = String.Format("{0:n2}", Convert.ToDouble(rw[0]));
                    else if (rw[1].ToString() == "USD") lblBankaDolar.Text = String.Format("{0:n2}", Convert.ToDouble(rw[0]));
                }
            }
            catch { }
        }

        void listeleriDoldur()
        {
            dgKasa.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("select * from dbo.[fonkGetKasaBilgileri_kasa](" + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbSube) + ", " + ComboboxItem.getSelectedValue(cmbKullanici) + ", '" + dtTarih.Value + "') order by islemTuru, dovizTuru asc");
            while (dr.Read())
            {
                dgKasa.Rows.Add(dr["islemTuru"].ToString(), Convert.ToDouble(dr["tutar"]), dr["dovizTuru"].ToString());
            }

            dgBanka.Rows.Clear();
            SqlDataReader dr2 = veri.getDatareader("select * from dbo.[fonkGetKasaBilgileri_banka](" + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbSube) + ", " + ComboboxItem.getSelectedValue(cmbKullanici) + ", '" + dtTarih.Value + "') order by islemTuru, doviz asc");
            while (dr2.Read())
            {
                dgBanka.Rows.Add(dr2["islemTuru"].ToString(), Convert.ToDouble(dr2["tutar"]), dr2["doviz"].ToString());
            }
        }

        private void cmbSube_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanici, ComboboxItem.getSelectedValue(cmbSube));
        }

        void tumListeleriYenile()
        {
            gostergeleriHesapla();
            listeleriDoldur();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            tumListeleriYenile();
        }

        private void cmbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
