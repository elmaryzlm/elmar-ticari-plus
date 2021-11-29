using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using elmarLibrary;
namespace Elmar_Ticari_Plus
{
    public static class NesneGorselleri
    {
        //public static void rengiAyarla(object sender)
        //{
        //    Control c = (Control)sender;
        //    if (c.BackColor == Color.White)
        //    {

        //        c.BackColor = SystemColors.GradientInactiveCaption;
        //        c.ForeColor = Color.Black;
        //        //if (ayarlar.ekranKlavyesiOTO == 1) ekranklavyesi();
        //    }
        //    else if (c.BackColor == SystemColors.GradientInactiveCaption)
        //    {
        //        c.BackColor = Color.White;
        //        c.ForeColor = Color.Black;
        //    }
        //}

        public static void kontrolEkle(Control cnt)
        {
            foreach (Control c in cnt.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(MaskedTextBox) || c.GetType() == typeof(ComboBox))
                {
                    c.KeyPress += c_KeyPress;
                    c.Enter += c_Enter;
                    c.Leave += c_Leave;
                    c.KeyDown += c_KeyDown;
                }
            }
        }
        public static void kontrolEkle(Form cnt)
        {
            foreach (Control c in cnt.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(MaskedTextBox) || c.GetType() == typeof(ComboBox) || c.GetType() == typeof(NumericUpDown))
                {
                    c.KeyPress += c_KeyPress;
                    c.Enter += c_Enter;
                    c.Leave += c_Leave;
                    c.KeyDown += c_KeyDown;
                }
            }
        }
        public static void form(Form frm, bool mdiFormmu)
        {
            frm.Icon = icon_yukle();
            if (frm.Name.Equals("frmOdemeVeTahsilat")) return;
            frm.StartPosition = FormStartPosition.Manual;
            frm.BackColor = Color.Gainsboro;
            if (mdiFormmu == true) frm.MdiParent = Application.OpenForms["Form1"];
        }

        //0: Format Tipi
        //1: Key Press
        //2: Renk
        static void c_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Control c = (Control)sender;
                if (e.KeyCode == Keys.Enter)
                {
                    if (c.Tag.ToString().Length > 3 && c.Tag.ToString()[3] == '0') return;
                    if ((c.GetType() == typeof(TextBox) && ((TextBox)c).Multiline == false) || c.GetType() != typeof(TextBox))
                        c.Parent.SelectNextControl(c, true, true, true, true);
                }
            }
            catch { }
        }
        static void c_Leave(object sender, EventArgs e)
        {
            try
            {
                /*Tag Bilgilendirme
                *0. karakter 0 ise formatlama, 2 ise 2 hane formatla, 5 ise hane formatla
                *2. karakter */
                Control c = (Control)sender;
                if (c.Tag.ToString()[0] == '1') c.Text = string.Format("{0:n1}", Convert.ToDouble(c.Text));
                else if (c.Tag.ToString()[0] == '2') c.Text = string.Format("{0:n2}", Convert.ToDouble(c.Text));
                else if (c.Tag.ToString()[0] == '3') c.Text = string.Format("{0:n3}", Convert.ToDouble(c.Text));
                else if (c.Tag.ToString()[0] == '4') c.Text = string.Format("{0:n4}", Convert.ToDouble(c.Text));
                else if (c.Tag.ToString()[0] == '5') c.Text = string.Format("{0:n5}", Convert.ToDouble(c.Text));
                //1 renk değiş, 0 renk değişme
                if (c.Tag.ToString()[2] == '1') c.BackColor = Color.White;
                //SQL Injection
                c.Text = c.Text.Replace("'", "ʹ");
            }
            catch { }
        }

        static void c_Enter(object sender, EventArgs e)
        {
            try
            {
                Control c = (Control)sender;
                //1 renk değiş, 0 renk değişme
                if (c.Tag.ToString()[2] == '1') c.BackColor = SystemColors.GradientInactiveCaption;
            }
            catch { }
        }

        static void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Control c = (Control)sender;
                //0 ise kontrol yok
                if (c.Tag.ToString()[1] == '1') guvenlikVeKontrol.klavyeKontrol_int(sender, e);
                else if (c.Tag.ToString()[1] == '2') guvenlikVeKontrol.klavyeKontrol_double(sender, e);
            }
            catch { }
        }

        public static void form(Form frmCocuk, Form frmAna)
        {
            frmCocuk.StartPosition = FormStartPosition.Manual;
            frmCocuk.BackColor = Color.Gainsboro;
            frmCocuk.Icon = icon_yukle();
            frmCocuk.MdiParent = frmAna;
        }
        public static void dataGridView(DataGridView dg)
        {
            //renkler
            dg.BackgroundColor = Color.Gainsboro;
            dg.GridColor = Color.Gainsboro;

            //izinler
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.AllowUserToOrderColumns = false;
            dg.AllowUserToResizeColumns = false;
            dg.AllowUserToResizeRows = false;
            //dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg.BorderStyle = BorderStyle.FixedSingle;

            //sütun başlığı biçimi
            //dg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            //dg.ColumnHeadersHeight = 10;
            dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dg.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataGridViewCellStyle s1 = new DataGridViewCellStyle();
            s1.BackColor = Color.Silver;
            s1.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            s1.ForeColor = Color.Black;
            s1.WrapMode = DataGridViewTriState.False;
            dg.ColumnHeadersDefaultCellStyle = s1;


            //genel hücre biçimi
            DataGridViewCellStyle s2 = new DataGridViewCellStyle();
            s2.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            s2.ForeColor = Color.Black;
            s2.BackColor = Color.White;
            //s2.WrapMode = DataGridViewTriState.False;
            dg.DefaultCellStyle = s2;

            //genel özellikler
            dg.MultiSelect = false;
            dg.EnableHeadersVisualStyles = false;
            dg.RowHeadersVisible = true;


            //Satır başlığı biçimi
            dg.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dg.RowHeadersWidth = 16;
            dg.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            DataGridViewCellStyle s3 = new DataGridViewCellStyle();
            s3.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            //s3.ForeColor = Color.Pink;
            dg.RowHeadersDefaultCellStyle = s3;

            dg.DataError += dg_DataError;
            dg.RowsAdded += dg_RowsAdded;
        }

        static void dg_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            if ((dg.Rows.Count - 1) % 2 == 1) dg.Rows[dg.Rows.Count - 1].DefaultCellStyle.BackColor = SystemColors.GradientInactiveCaption;
        }
        static void dg_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private static Icon icon_yukle()
        {
            try
            {
                System.Drawing.Icon ico = new System.Drawing.Icon(Application.StartupPath + "\\resimler\\elmaricon.ico");
                return ico;
            }
            catch
            {
                return null;
            }
        }

    }
}
