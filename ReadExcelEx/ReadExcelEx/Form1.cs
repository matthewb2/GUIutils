using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;       //microsoft Excel 14 object in references-> COM tab
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace ReadExcelEx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            Workbook wbook = excel.Workbooks.Open(Directory.GetCurrentDirectory() + "/" + "test.xlsx",
                     Type.Missing, false, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing);

            Sheets worksheets = wbook.Worksheets;

            //note that ExcelGridView is a dataGridView
            for (char c = 'A'; c < 'E'; c++)
            {
                ExcelGridView.Columns.Add("col", c.ToString());
                for (int i = 1; i < 10; i++)
                {
                    string celladdr = c.ToString() + i.ToString();  //cell's address (like A1 or B5, etc.)
                    Range cell = ((Worksheet)worksheets["Sheet1"]).get_Range(celladdr, celladdr);

                    ExcelGridView.Rows.Add();

                    try
                    {
                        ExcelGridView.Rows[i - 1].Cells[(int)c - 65].Value = cell.Value.ToString();
                    }

                    catch { /*empty cell*/ }

                }
            }

            wbook.Close();

        }
    }
}
