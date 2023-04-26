using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2010.Excel;
using HtmlAgilityPack;
using System.Net;


namespace Trading_results
{
    public partial class formMain : Form
    {

        static int positionRowTo = 9;
        static FileStream ReadMaket = new FileStream("res\\maket.xlsx", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        static XLWorkbook bookTo = new XLWorkbook(ReadMaket);
        static IXLWorksheet sheetTo = bookTo.Worksheets.Worksheet("Result");

        public void CreateBook(string date)
        {
            FileStream FromRead = new FileStream("res\\test.xls", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            int positionRowFrom = 15;
            IWorkbook bookFrom = new HSSFWorkbook(FromRead);
            ISheet sheetFrom = bookFrom.GetSheetAt(0);
            IRow rowFrom = sheetFrom.GetRow(positionRowFrom);
            ICell cellFrom = rowFrom.GetCell(1);
            IXLRange rngTable;

            do
            {
                sheetTo.Cell(positionRowTo, (2)).Value = date;
                for (int i = 1, j = 2; i <= 5; i++)
                {
                    if (j != 5)
                        sheetTo.Cell(positionRowTo, (j++ + 1)).Value = cellFrom.StringCellValue;
                    else
                    {
                        j++;
                        i--;
                    }

                    if (sheetTo.Cell(positionRowTo, (8)).GetString() != "" && sheetTo.Cell(positionRowTo, (7)).GetString() != "" && sheetTo.Cell(positionRowTo, (8)).GetString() != "-" && sheetTo.Cell(positionRowTo, (7)).GetString() != "-")
                        sheetTo.Cell(positionRowTo, (6)).Value = double.Parse(sheetTo.Cell(positionRowTo, (8)).GetString()) / double.Parse(sheetTo.Cell(positionRowTo, (7)).GetString());
                    cellFrom = rowFrom.GetCell(i + 1);
                }
                rngTable = sheetTo.Range("B9:H" + positionRowTo);
                rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                positionRowTo++;
                positionRowFrom++;
                rowFrom = sheetFrom.GetRow(positionRowFrom);
                cellFrom = rowFrom.GetCell(1);
            } while (cellFrom.StringCellValue != "Итого:");
            FromRead.Close();
            File.Delete("res\\test.xls");
        }

        public formMain()
        {
            InitializeComponent();
        }

        public void DowloadFile(string filename)
        {
            try { }
            catch { }
        }
        private void btCreat_Click(object sender, EventArgs e)
        {
            if ((SFDCreatBook.ShowDialog() == DialogResult.Cancel))
                return;
            positionRowTo = 9;
            string myStringWebResource = null;
            var curDate = calFrom.SelectionStart;
            WebClient myWebClient = new WebClient();

            while (calTo.SelectionStart >= curDate)
            {
                try
                {
                    myStringWebResource = "https://spimex.com/upload/reports/oil_xls/oil_xls_" + curDate.ToString("yyyyMMdd") + "162000.xls";
                    myWebClient.DownloadFile(myStringWebResource, "res\\test.xls");
                    CreateBook(curDate.ToString("yyyy/MM/dd"));
                    curDate = curDate.AddDays(1);
                }
                catch
                {
                    curDate = curDate.AddDays(1);
                }
            }
           
            bookTo.SaveAs(SFDCreatBook.FileName);
        }
        private void Checking_dates(DateTime calFrom, DateTime calTo)
        {
            if (calFrom <= calTo)
                btCreat.Visible = true;
            else
                btCreat.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calFrom.MaxDate = DateTime.Now;
            calTo.MaxDate = DateTime.Now;
        }

        private void calFrom_DateChanged(object sender, DateRangeEventArgs e)
        {
            Checking_dates(calFrom.SelectionStart, calTo.SelectionStart);
        }
    }
}
