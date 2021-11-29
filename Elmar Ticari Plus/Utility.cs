using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Elmar_Ticari_Plus
{
    public class Utility
    {
        public static string SendSMS(string phoneNumber, string message)
        {
            //netgsm den mutlucelle çevirilmiştir
            string userName = "serviscim"; // kullanıcıadı
            string pass = "serviscim23";//şifre
            string originator = "ELMAR YZLM";//mesaj adı, mutlucellde ikitane var 
            Selahattin sms = new Selahattin(userName, pass, originator);
            string[] phone = { phoneNumber };
            sms.addSMS(message, phone);
            return sms.gonder();
        }
        public static void exportExcel(DataGridView gd)
        {

            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
          //  Microsoft.Office.Interop.Excel._Worksheet worksheet =null;

            //try
            //{
            //    Microsoft.Office.Interop.Excel._Worksheet worksheet;

            //    worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets[0];

            //    worksheet.Name = "ExportedFromDatGrid";

            //    int cellRowIndex = 1;
            //    int cellColumnIndex = 1;


            //    for (int i = 0; i < gd.Rows.Count - 1; i++)
            //    {
            //        for (int j = 0; j < gd.Columns.Count; j++)
            //        {

            //            if (cellRowIndex == 1)
            //            {
            //                worksheet.Cells[cellRowIndex, cellColumnIndex] = gd.Columns[j].HeaderText;
            //            }
            //            else
            //            {
            //                worksheet.Cells[cellRowIndex, cellColumnIndex] = gd.Rows[i].Cells[j].Value.ToString();
            //            }
            //            cellColumnIndex++;
            //        }
            //        cellColumnIndex = 1;
            //        cellRowIndex++;
            //    }

            //    SaveFileDialog saveDialog = new SaveFileDialog();
            //    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            //    saveDialog.FilterIndex = 2;

            //    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        workbook.SaveAs(saveDialog.FileName);
            //        MessageBox.Show("Export Successful");
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    excel.Quit();
            //    workbook = null;
            //    excel = null;

            //}
        }
    }
}
