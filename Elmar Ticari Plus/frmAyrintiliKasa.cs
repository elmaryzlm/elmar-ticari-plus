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
    public partial class frmAyrintiliKasa : Form
    {
        public frmAyrintiliKasa()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgBanka);
            NesneGorselleri.dataGridView(dgKasa);
            NesneGorselleri.kontrolEkle(panel1);
        }
        private void frmAyrintiliKasa_Load(object sender, EventArgs e)
        {
            listeler.doldurSube(cmbSube);
            listeleriDoldur();
            karZarariHesapla();
        }
        private void btnYenile_Click(object sender, EventArgs e)
        {
            listeleriDoldur();
            karZarariHesapla();
        }
        private void karZarariHesapla()
        {
            try
            {
                string sorgu = "";
                if (cmbSube.Text != "") sorgu = sorgu + " And t.subeid = " + ComboboxItem.getSelectedValue(cmbSube);
                if (cmbKullanici.Text != "") sorgu = sorgu + " And t.kullaniciid = " + ComboboxItem.getSelectedValue(cmbKullanici);
                sorgu = sorgu + " And (t.islemTarihi between '" + dtTarih1.Value + "' And '" + dtTarih2.Value + "')";
                double netKar =Convert.ToDouble(veri.getdatacell("SELECT isnull(sum(abs(t.Toplam)-s.alisFiyat*(abs(t.miktar))),0)  AS karZarar From dbo.sorTicaret AS t Left OUTER JOIN dbo.sorStokkart AS s ON s.stokid = t.stokid inner join sorTicaretAyrinti2 t1 on t1.ticaretAyrintiid = t.ticaretAyrintiid WHERE (t.silindimi = '0') and t.hesabaislendimi=1 And t.firmaid = " + firma.firmaid + " And t.islemTuru !='Satış iade' And t.islemTuru like '%Satış%'" + sorgu));
                double iskonto =Convert.ToDouble(veri.getdatacell("select isnull(sum(iskonto),0) from sorTicaretAyrinti2 as t WHERE (t.silindimi = '0') and t.hesabaislendimi=1 And t.firmaid = " + firma.firmaid + " And t.islemTuru !='Satış iade' And t.islemTuru like '%Satış%'" + sorgu));
                txtNetKar.Text = String.Format("{0:n2}", Convert.ToDouble(netKar+iskonto));
            }
            catch
            {
                txtNetKar.Text = "0";
            }

        }
        void listeleriDoldur()
        {
            double toplamGelirKasaTL = 0, toplamGelirKasaDolar = 0, toplamGelirKasaEuro = 0, toplamGiderKasaTL = 0, toplamGiderKasaDolar = 0, toplamGiderKasaEuro = 0, toplamGelirBankaTL = 0, toplamGelirBankaDolar = 0, toplamGelirBankaEuro = 0, toplamGiderBankaTL = 0, toplamGiderBankaDolar = 0, toplamGiderBankaEuro = 0, toplamGelirTL = 0, toplamGelirDolar = 0, toplamGelirEuro = 0, toplamGiderTL = 0, toplamGiderDolar = 0, toplamGiderEuro = 0, netBakiyeTL = 0, netBakiyeDolar = 0, netBakiyeEuro = 0;
            dgKasa.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("select * from dbo.[fonkGetKasaBilgileri_ayrintilikasa](" + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbSube) + ", " + ComboboxItem.getSelectedValue(cmbKullanici) + ", '" + dtTarih1.Value + "', '" + dtTarih2.Value + "') order by islemTuru, dovizTuru asc");
            while (dr.Read())
            {
                dgKasa.Rows.Add(dr["islemTuru"].ToString(), Convert.ToDouble(dr["tutar"]), dr["dovizTuru"].ToString());
                if (Convert.ToDouble(dr["tutar"]) > 0 && dr["dovizTuru"].ToString() == "TL") toplamGelirKasaTL += Convert.ToDouble(dr["tutar"]);
                else if (Convert.ToDouble(dr["tutar"]) > 0 && dr["dovizTuru"].ToString() == "USD") toplamGelirKasaDolar += Convert.ToDouble(dr["tutar"]);
                else if (Convert.ToDouble(dr["tutar"]) > 0 && dr["dovizTuru"].ToString() == "EURO") toplamGelirKasaEuro += Convert.ToDouble(dr["tutar"]);
                if (Convert.ToDouble(dr["tutar"]) < 0 && dr["dovizTuru"].ToString() == "TL") toplamGiderKasaTL += Convert.ToDouble(dr["tutar"]);
                else if (Convert.ToDouble(dr["tutar"]) < 0 && dr["dovizTuru"].ToString() == "USD") toplamGiderKasaDolar += Convert.ToDouble(dr["tutar"]);
                else if (Convert.ToDouble(dr["tutar"]) < 0 && dr["dovizTuru"].ToString() == "EURO") toplamGiderKasaEuro += Convert.ToDouble(dr["tutar"]);
            }

            dgBanka.Rows.Clear();
            SqlDataReader dr2 = veri.getDatareader("select * from dbo.[fonkGetKasaBilgileri_ayrintiliBanka](" + firma.firmaid + ", " + ComboboxItem.getSelectedValue(cmbSube) + ", " + ComboboxItem.getSelectedValue(cmbKullanici) + ", '" + dtTarih1.Value + "', '" + dtTarih2.Value + "') order by islemTuru, doviz asc");
            while (dr2.Read())
            {
                dgBanka.Rows.Add(dr2["islemTuru"].ToString(), Convert.ToDouble(dr2["tutar"]), dr2["doviz"].ToString());
                if (Convert.ToDouble(dr2["tutar"]) > 0 && dr2["doviz"].ToString() == "TL") toplamGelirBankaTL += Convert.ToDouble(dr2["tutar"]);
                else if (Convert.ToDouble(dr2["tutar"]) > 0 && dr2["doviz"].ToString() == "USD") toplamGelirBankaDolar += Convert.ToDouble(dr2["tutar"]);
                else if (Convert.ToDouble(dr2["tutar"]) > 0 && dr2["doviz"].ToString() == "EURO") toplamGelirBankaEuro += Convert.ToDouble(dr2["tutar"]);
                else if (Convert.ToDouble(dr2["tutar"]) < 0 && dr2["doviz"].ToString() == "TL") toplamGiderBankaTL += Convert.ToDouble(dr2["tutar"]);
                else if (Convert.ToDouble(dr2["tutar"]) < 0 && dr2["doviz"].ToString() == "USD") toplamGiderBankaDolar += Convert.ToDouble(dr2["tutar"]);
                else if (Convert.ToDouble(dr2["tutar"]) < 0 && dr2["doviz"].ToString() == "EURO") toplamGiderBankaEuro += Convert.ToDouble(dr2["tutar"]);
            }
            toplamGelirTL = toplamGelirBankaTL + toplamGelirKasaTL;
            toplamGelirDolar = toplamGelirBankaDolar + toplamGelirKasaDolar;
            toplamGelirEuro = toplamGelirBankaEuro + toplamGelirKasaEuro;
            toplamGiderTL = toplamGiderBankaTL + toplamGiderKasaTL;
            toplamGiderDolar = toplamGiderBankaDolar + toplamGiderKasaDolar;
            toplamGiderEuro = toplamGiderBankaEuro + toplamGiderKasaEuro;
            netBakiyeTL = toplamGelirTL + toplamGiderTL;
            netBakiyeDolar = toplamGelirDolar + toplamGiderDolar;
            netBakiyeEuro = toplamGelirEuro + toplamGiderEuro;
            
            txtToplamGelirKasaTL.Text = String.Format("{0:n2}", toplamGelirKasaTL);
            txtToplamGelirKasaDolar.Text = String.Format("{0:n2}", toplamGelirKasaDolar);
            txtToplamGelirKasaEuro.Text = String.Format("{0:n2}", toplamGelirKasaEuro);
            txtToplamGiderKasaTL.Text = String.Format("{0:n2}", toplamGiderKasaTL);
            txtToplamGiderKasaDolar.Text = String.Format("{0:n2}", toplamGiderKasaDolar);
            txtToplamGiderKasaEuro.Text = String.Format("{0:n2}", toplamGiderKasaEuro);
            txtToplamGelirBankaTL.Text = String.Format("{0:n2}", toplamGelirBankaTL);
            txtToplamGelirBankaDolar.Text = String.Format("{0:n2}", toplamGelirBankaDolar);
            txtToplamGelirBankaEuro.Text = String.Format("{0:n2}", toplamGelirBankaEuro);
            txtToplamGiderBankaTL.Text = String.Format("{0:n2}", toplamGiderBankaTL);
            txtToplamGiderBankaDolar.Text = String.Format("{0:n2}", toplamGiderBankaDolar);
            txtToplamGiderBankaEuro.Text = String.Format("{0:n2}", toplamGiderBankaEuro);
            txtToplamGelirTL.Text = String.Format("{0:n2}", toplamGelirTL);
            txtToplamGelirDolar.Text = String.Format("{0:n2}", toplamGelirDolar);
            txtToplamGelirEuro.Text = String.Format("{0:n2}", toplamGelirEuro);
            txtToplamGiderTL.Text = String.Format("{0:n2}", toplamGiderTL);
            txtToplamGiderDolar.Text = String.Format("{0:n2}", toplamGiderDolar);
            txtToplamGiderEuro.Text = String.Format("{0:n2}", toplamGiderEuro);
            txtNetBakiyeTL.Text = String.Format("{0:n2}", netBakiyeTL);
            txtNetBakiyeDolar.Text = String.Format("{0:n2}", netBakiyeDolar);
            txtNetBakiyeEuro.Text = String.Format("{0:n2}", netBakiyeEuro);
        }
        private void cmbSube_SelectedIndexChanged(object sender, EventArgs e)
        {   
            listeler.doldurKullanici(cmbKullanici, ComboboxItem.getSelectedValue(cmbSube));
        }
        private void cmbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
