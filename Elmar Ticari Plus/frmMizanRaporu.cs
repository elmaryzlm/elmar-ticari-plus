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
    public partial class frmMizanRaporu : Form
    {
        rapor rpr;
        public frmMizanRaporu()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.kontrolEkle(groupBox1);
            listeler.doldurSube(cmbSubeler);
        }

        private void frmMizanRaporu_Load(object sender, EventArgs e)
        {

        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeler.doldurKullanici(cmbKullanici, ComboboxItem.getSelectedValue(cmbSubeler));
        }


        private void btnRaporla_Click(object sender, EventArgs e)
        {
            if (raporOlustur())
            { rpr.onizleme(); }
        }

        private bool raporOlustur()
        {
            rpr = new rapor();
            rpr.yaziYazdirmaSiniri = rpr._kagitYuksekligi - 10;
            int y = 5;

            //rpr.ekleSabitDikgortgen(new rapor.sabitDikdortgen(4, y, rpr._kagitGenisligi - 8, rpr._kagitYuksekligi - y * 3 / 2));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Mizan Raporu", new Font("Arial", 15, FontStyle.Bold), new Point(90, y)));
            string sql = "Exec spGetMizanRaporu " + firma.firmaid + ", " + firma.subeid + ", " + firma.kullaniciid + ",'" + dtTarih1.Value.ToString() + "','" + dtTarih2.Value.ToString() + "'";
            DataRow rw = veri.getdatarow(sql);


            rpr.ekleSabitYazi(new rapor.sabitYazi("Kasadaki Nakitler(TL) Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[0])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 15)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kasadaki Nakitler(USD) Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[1])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 21)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Kasadaki Nakitler(EURO) Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[2])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 27)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Bankadaki Nakitler(TL) Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[3])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 33)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Bankadaki Nakitler(USD) Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[4])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 39)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Bankadaki Nakitler(EURO) Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[5])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 45)));

            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Alacak Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[6])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 51)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Alınan Çek Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[7])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 57)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Alınan Senet Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[8])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 63)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Mal Mevcutu: " + String.Format("{0:n2}", Convert.ToDouble(rw[9])), new Font("Arial", 11, FontStyle.Regular), new Point(10, 70)));
            double gelirToplam = Convert.ToDouble(rw[0]) + Convert.ToDouble(rw[1]) * bilgiler.dovizVerileri.dDolarsatis + Convert.ToDouble(rw[2]) * bilgiler.dovizVerileri.dEurosatis + Convert.ToDouble(rw[3]) + Convert.ToDouble(rw[4]) * bilgiler.dovizVerileri.dDolarsatis + Convert.ToDouble(rw[5]) * bilgiler.dovizVerileri.dEurosatis + Convert.ToDouble(rw[6]) + Convert.ToDouble(rw[7]) + Convert.ToDouble(rw[8]) + Convert.ToDouble(rw[9]);

            rpr.ekleSabitYazi(new rapor.sabitYazi("Cari Borç Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[12])), new Font("Arial", 11, FontStyle.Regular), new Point(120, 15)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Verilen Çek Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[10])), new Font("Arial", 11, FontStyle.Regular), new Point(120, 21)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Verilen Senet Toplamı: " + String.Format("{0:n2}", Convert.ToDouble(rw[11])), new Font("Arial", 11, FontStyle.Regular), new Point(120, 27)));
            double giderToplam = Convert.ToDouble(rw[10]) + Convert.ToDouble(rw[11]) + Convert.ToDouble(rw[12]);

            rpr.ekleCizgi(new rapor.cizgi(10, rpr._kagitGenisligi - 10, 75, 75));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Gelir Toplamı: " + String.Format("{0:n2}", gelirToplam) + " TL", new Font("Arial", 12, FontStyle.Regular), new Point(10, 80)));
            rpr.ekleSabitYazi(new rapor.sabitYazi("Gider Toplamı: " + String.Format("{0:n2}", giderToplam) + " TL", new Font("Arial", 12, FontStyle.Regular), new Point(120, 80)));


            return true;
        }
    }
}
