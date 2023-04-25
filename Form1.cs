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
        //Защить макет в проект
        static FileStream ReadMaket = new FileStream("C:\\ttt\\maket.xlsx", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        static XLWorkbook bookTo = new XLWorkbook(ReadMaket);
        static IXLWorksheet sheetTo = bookTo.Worksheets.Worksheet("Result");

        public void CreateBook(FileStream FromRead)
        {
            int positionRowFrom = 15;
            IWorkbook bookFrom = new HSSFWorkbook(FromRead);
            ISheet sheetFrom = bookFrom.GetSheetAt(0);
            IRow rowFrom = sheetFrom.GetRow(positionRowFrom);
            ICell cellFrom = rowFrom.GetCell(1);
            IXLRange rngTable;

            do
            {
                sheetTo.Cell(positionRowTo, (2)).Value = "23/04/2023";//Поменять на автоматическую подстановку
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
                rngTable = sheetTo.Range("B9:H" + positionRowTo);//можно оптимизировать
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
        }

        public void SaveBook()
        {
            //Дать выбор пользователю где сохранить файл
            FileStream WriteTo = new FileStream("C:\\ttt\\outfile.xlsx", FileMode.Create);
            bookTo.SaveAs(WriteTo);
            WriteTo.Close();
            ReadMaket.Close();
        }

        public formMain()
        {
            InitializeComponent();
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

        private void btCreat_Click(object sender, EventArgs e)
        {
            string remoteUri = "https://spimex.com/upload/reports/oil_xls/";
            string fileName = "oil_xls_20230420162000.xls", myStringWebResource = null;
            WebClient myWebClient = new WebClient();
            myStringWebResource = remoteUri + fileName;
            myWebClient.DownloadFile(myStringWebResource, "C:\\ttt\\test.xls");

            FileStream FromRead = new FileStream("C:\\ttt\\test.xls", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            //В зависимости от того сколько файлов найдёт столько раз и вызывать функцию
            CreateBook(FromRead);
            File.Delete("C:\\ttt\\test.xls");
            SaveBook();
        }
    }
}
