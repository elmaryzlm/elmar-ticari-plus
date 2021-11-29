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
    public partial class frmFirmaKullaniciYetkileri : Form
    {
        public frmFirmaKullaniciYetkileri()
        {
            InitializeComponent();
            NesneGorselleri.form(this, true);
            NesneGorselleri.dataGridView(dgFirmaKullanicilari);
            NesneGorselleri.kontrolEkle(panel1);
        }

        private void frmFirmaKullaniciYetkileri_Load(object sender, EventArgs e)
        {
            listeler.doldurSube(cmbSubeAdi);
        }

        private void _stokAna_Click(object sender, EventArgs e)
        {
            if (dgFirmaKullanicilari.SelectedRows.Count == 0)
            {
                MessageBox.Show("Önce listeden bir kullanıcı seçin", firma.programAdi);
                return;
            }
            CheckBox chk = (CheckBox) sender;
            veri.cmd("Update tblFirmaKullaniciYetkileri set degeri = '"+Convert.ToByte(chk.Checked)+"' Where kullaniciid = "+dgFirmaKullanicilari.CurrentRow.Cells["kullaniciid"].Value+" and yetkiAdi = '"+chk.Text+"' and ortam = 'Ticari Program' ");
            yetkiler.yetkileriGuncelle();
        }

        private void cmbSubeAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgFirmaKullanicilari.Rows.Clear();
            SqlDataReader dr = veri.getDatareader("select kullaniciid, kAdi from sorFirmaKullanicilari Where firmaid = " + firma.firmaid + " and subeid = " + ComboboxItem.getSelectedValue(cmbSubeAdi) + " order by kAdi asc");
            while (dr.Read())
            {
                dgFirmaKullanicilari.Rows.Add(dr["kullaniciid"].ToString(), dr["kAdi"].ToString());
            }
            dgFirmaKullanicilari.ClearSelection();
        }

        private void dgFirmaKullanicilari_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlDataReader dr = veri.getDatareader("Select yetkiAdi, degeri from tblFirmaKullaniciYetkileri Where kullaniciid = " + dgFirmaKullanicilari.CurrentRow.Cells["kullaniciid"].Value + " and ortam = 'Ticari Program' order by yetkiid asc");
            while (dr.Read())
            {
                foreach (CheckBox chk in pnlYetkiler.Controls)
                {
                    if (chk.Text == dr["yetkiAdi"].ToString())
                    {
                        chk.Checked = Convert.ToBoolean(Convert.ToByte(dr["degeri"]));
                        break;
                    }
                }
            }
        }

        private void btnYeniKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (!yetkiler.Firma_ve_Şube_Tanıml_)
            {
                yetkiler.mesajVer();
                return;
            }
            frmFirmaKullanicilari frm = new frmFirmaKullanicilari();
            frm.Show();
        }
    }
}
