using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public class ComboboxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }
        public ComboboxItem(object Value, string Text)
        {
            this.Value = Value;
            this.Text = Text;
        }
        public override string ToString()
        {
            return Text;
        }
        public static void setValue(ComboBox cmb, string value)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {
                if ((cmb.Items[i] as ComboboxItem).Value.ToString() == value)
                {
                    cmb.SelectedIndex = i;
                    break;
                }
            }
        }
        public static string getSelectedValue(ComboBox cmb)
        {
            try
            {
                if (cmb.SelectedIndex == -1) return "0";
                else return (cmb.SelectedItem as ComboboxItem).Value.ToString();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        public static bool seciliMetinKontrolu(ComboBox cmb)
        {
            for (int i = 0; i < cmb.Items.Count; i++)
            {

                if ((cmb.Items[i] as ComboboxItem).Text.ToString() == cmb.Text) return true;
            }
            return false;
        }
    }

}
