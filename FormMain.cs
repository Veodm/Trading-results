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

        int _positionRowTo;
        IXLWorksheet _sheetTo;        

        public void CreateBook(string date)
        {
            string tempFile="res\\test.xls";
            FileStream fromRead = new FileStream(tempFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            int positionRowFrom = 15;
            IWorkbook bookFrom = new HSSFWorkbook(fromRead);
            ISheet sheetFrom = bookFrom.GetSheetAt(0);
            IRow rowFrom = sheetFrom.GetRow(positionRowFrom);
            ICell cellFrom = rowFrom.GetCell(1);
            IXLRange rngTable;
            _sheetTo.Cell(4, 3).Value = "Период выгрузки " + calFrom.SelectionStart.ToString("dd/MM/yyyy") + " - " + calTo.SelectionStart.ToString("dd/MM/yyyy");
            do
            {
                _sheetTo.Cell(_positionRowTo, (2)).Value = date;
                for (int i = 1, j = 2; i <= 5; i++)
                {
                    if (j != 5)
                        _sheetTo.Cell(_positionRowTo, (j++ + 1)).Value = cellFrom.StringCellValue;
                    else
                    {
                        j++;
                        i--;
                    }

                    if (_sheetTo.Cell(_positionRowTo, (8)).GetString() != "" && _sheetTo.Cell(_positionRowTo, (7)).GetString() != "" && _sheetTo.Cell(_positionRowTo, (8)).GetString() != "-" && _sheetTo.Cell(_positionRowTo, (7)).GetString() != "-")
                        _sheetTo.Cell(_positionRowTo, (6)).Value = double.Parse(_sheetTo.Cell(_positionRowTo, (8)).GetString()) / double.Parse(_sheetTo.Cell(_positionRowTo, (7)).GetString());
                    cellFrom = rowFrom.GetCell(i + 1);
                }
                
                rngTable = _sheetTo.Range("B9:H" + _positionRowTo);
                rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                _positionRowTo++;
                positionRowFrom++;
                rowFrom = sheetFrom.GetRow(positionRowFrom);
                cellFrom = rowFrom.GetCell(1);
            } while (cellFrom.StringCellValue != "Итого:");            
            fromRead.Close();
            File.Delete(tempFile);
        }

        public formMain()
        {
            InitializeComponent();
        }
      
        private void btCreat_Click(object sender, EventArgs e)
        {
            if ((SFDCreatBook.ShowDialog() == DialogResult.Cancel))
                return;
            XLWorkbook bookTo = new XLWorkbook("res\\maket.xlsx");
            _sheetTo = bookTo.Worksheets.Worksheet("Result");
            List<DateTime> missDays = new List<DateTime>();
            _positionRowTo = 9;
            string myStringWebResource = null;
            var curDate = calFrom.SelectionStart;
            WebClient myWebClient = new WebClient();
            
            while (calTo.SelectionStart >= curDate)
            {
                try
                {
                    myStringWebResource = "https://spimex.com/upload/reports/oil_xls/oil_xls_" + curDate.ToString("yyyyMMdd") + "162000.xls";
                    myWebClient.DownloadFile(myStringWebResource, "res\\test.xls");
                    CreateBook(curDate.ToString("dd/MM/yyyy"));
                }
                catch
                {
                    missDays.Add(curDate);
                }
                finally
                {
                    curDate = curDate.AddDays(1);
                }
            }
           
            bookTo.SaveAs(SFDCreatBook.FileName);

            if (missDays.Count != 0)
                MessageBox.Show("За эти дни нету информации:\n" + string.Join("\n", missDays.Select(i => i.ToString("dd/MM/yyyy")).ToArray()));
            else
                MessageBox.Show("Выполнено!");
        }
        private void Checking_dates(DateTime from, DateTime to)
        {
            btCreat.Visible = from <= to;
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
