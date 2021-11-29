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
namespace Elmar_Mesaj_Paneli
{
    public partial class frmMesajlar : Form
    {
        public frmMesajlar()
        {
            InitializeComponent();
        }

        private void frmMesajlar_Load(object sender, EventArgs e)
        {
            MessageBox.Show("2");
            subeleri_getir();
            MessageBox.Show("3");
            dgListele();
            MessageBox.Show("4");
        }
        bool girdimi = false;
        void dgListele()
        {
            try
            {
                if (guvenlikVeKontrol.internetVarmi())
                {
                    SqlDataReader dr = veri.getDatareader("select kullaniciid, kAdi, 'Gönderen: '+ kAdi + '   Tarih:'+ cast(max(mesajTarihi) as nvarchar(25)) +'     Mesaj: ' + left(mesajMetni,110) from sorMesajlar where firmaid = " + firma.firmaid + " and kime = " + firma.kullaniciid + " group by kullaniciid, kAdi, mesajMetni, mesajid order by mesajid desc");
                    while (dr.Read())
                    {
                        girdimi = false;
                        for (int i = 0; i < dgMesajlar.Rows.Count; i++)
                        {
                            if (dgMesajlar.Rows[i].Cells[0].Value.ToString() == dr["kullaniciid"].ToString())
                            {
                                girdimi = true;
                                break;
                            }
                        }
                        if (girdimi==false)
                        {
                            dgMesajlar.Rows.Add(dr["kullaniciid"].ToString(), dr["kAdi"].ToString(), dr[1].ToString());
                            //dgMesajlar.CurrentRow.DefaultCellStyle.BackColor = Color.LemonChiffon;
                        }
                    }
                    dgMesajlar.Columns[0].Visible = false;
                    dgMesajlar.Columns[1].Visible = false;
                    dgMesajlar.ClearSelection();
                    dgMesajlar.Refresh();
                }
            }
            catch
            {
            }

        }
        void subeleri_getir()
        {
            if (guvenlikVeKontrol.internetVarmi())
            {
                cmbSubeler.Items.Clear();
                cmbSubeler.Items.Add(new ComboboxItem("0", "Tümü"));
                SqlDataReader dr = veri.getDatareader("Select subeid, subeAdi from tblFirmaSubeleri where firmaid = " + firma.firmaid + " order by subeAdi");
                while (dr.Read())
                {
                    cmbSubeler.Items.Add(new ComboboxItem(dr["subeid"].ToString(), dr["subeAdi"].ToString()));
                }
                cmbSubeler.Text = cmbSubeler.Items[0].ToString();
            }
        }

        private void dgMesajlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            byte seçildimi = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Text == dgMesajlar.CurrentRow.Cells[1].Value.ToString() + " Konuşma")
                {
                    Application.OpenForms[i].Select();
                    Application.OpenForms[i].BringToFront();
                    seçildimi = 1;
                }
            }
            if (seçildimi == 0)
            {
                frmMesajYolla frm = new frmMesajYolla();
                frm.MdiParent = Application.OpenForms["Form1"];
                frm.kullaniciid = dgMesajlar.CurrentRow.Cells[0].Value.ToString();
                frm.kAdi = dgMesajlar.CurrentRow.Cells[1].Value.ToString();
                frm.Show();
            }
        }

        public void listKullanicilar_doldur()
        {
            try
            {
                if (guvenlikVeKontrol.internetVarmi())
                {
                    dgKullanicilar.Rows.Clear();
                    SqlDataReader dr;
                    if (cmbSubeler.Text == "Tümü")
                    {
                        dr = veri.getDatareader("Select tblFirmaKullanicilari.kullaniciid, kAdi,  kAdi + '('+ subeAdi +')' , onlinemi from tblFirmaKullanicilari, tblFirmaSubeleri where tblFirmaSubeleri.firmaid = " + firma.firmaid + " and tblFirmaKullanicilari.subeid = tblFirmaSubeleri.subeid order by onlinemi desc");
                    }
                    else
                    {
                        dr = veri.getDatareader("Select tblFirmaKullanicilari.kullaniciid, kAdi, onlinemi from tblFirmaKullanicilari, tblFirmaSubeleri where subeid = " + ComboboxItem.getSelectedValue(cmbSubeler) + " and tblFirmaSubeleri.firmaid = " + firma.firmaid + " and tblFirmaKullanicilari.subeid = tblFirmaSubeleri.subeid order by onlinemi desc");
                    }
                    while (dr.Read())
                    {
                        if (dr["onlinemi"].ToString() == "0") dgKullanicilar.Rows.Add(dr["kullaniciid"].ToString(), "☺ " + dr["kAdi"].ToString());
                        else if (dr["onlinemi"].ToString() == "1") dgKullanicilar.Rows.Add(dr["kullaniciid"].ToString(), "☻ " + dr["kAdi"].ToString());
                    }
                    dgKullanicilar.ClearSelection();
                }
                else
                {
                    MessageBox.Show("internet bağlantınızda sorun olabilir.", "Elmar Ticari Mesaj Paneli");
                }
            }
            catch
            {
            }
        }

        private void cmbSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            listKullanicilar_doldur();
        }

        private void dgKullanicilar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            byte seçildimi = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Text == dgKullanicilar.CurrentRow.Cells[1].Value.ToString() + " Konuşma")
                {
                    Application.OpenForms[i].Select();
                    Application.OpenForms[i].BringToFront();
                    seçildimi = 1;
                }
            }
            if (seçildimi == 0)
            {
                frmMesajYolla frm = new frmMesajYolla();
                frm.MdiParent = Application.OpenForms["Form1"];
                frm.kullaniciid = dgKullanicilar.CurrentRow.Cells[0].Value.ToString();
                frm.kAdi = dgKullanicilar.CurrentRow.Cells[1].Value.ToString();
                frm.Show();
            }
        }

        private void btnSubeYenile_Click(object sender, EventArgs e)
        {
            listKullanicilar_doldur();
        }


    }
}
