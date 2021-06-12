using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingSystemGUI
{
   public  class UserControlFeatures
    {
        public static void ExportDataToExcel(DataGridView dataGridView) 
        {
            if (dataGridView.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application Excel = new Microsoft.Office.Interop.Excel.Application();
                Excel.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                {
                    Excel.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        Excel.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                Excel.Columns.AutoFit();
                Excel.Visible = true;
            }
        }
    }
}
