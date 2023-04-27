using ClosedXML.Excel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trading_results
{
    public partial class FormSchedule : Form
    {

        //Dictionary<string, string> _tools = new Dictionary<string, string>();

        List<string> _tools = new List<string>();

        public void toolsSelcet(DateTime from, DateTime to)
        {
            
            string myStringWebResource = null;
            var curDate = from;
            WebClient myWebClient = new WebClient();
            while (to >= curDate)
            {
                try
                {
                    //myStringWebResource = "https://spimex.com/upload/reports/oil_xls/oil_xls_" + curDate.ToString("yyyyMMdd") + "162000.xls";
                    //myWebClient.DownloadFile(myStringWebResource, "res\\test.xls");
                    string tempFile = "res\\test.xls";
                    FileStream fromRead = new FileStream(tempFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                    int positionRowFrom = 15;
                    IWorkbook bookFrom = new HSSFWorkbook(fromRead);
                    ISheet sheetFrom = bookFrom.GetSheetAt(0);
                    IRow rowFrom = sheetFrom.GetRow(positionRowFrom);
                    ICell cellFrom = rowFrom.GetCell(2);
                    do
                    {
                        if (!_tools.Contains(cellFrom.StringCellValue))
                            _tools.Add(cellFrom.StringCellValue);                            
                    } while (cellFrom.StringCellValue != null);
                    fromRead.Close();
                   // File.Delete(tempFile);

                }
                catch
                {

                }
                finally
                {
                    curDate = curDate.AddDays(1);
                }
            }

            
        }


        public FormSchedule(DateTime from, DateTime to)
        {
            InitializeComponent();
            toolsSelcet(from, to);
            foreach(string tool in _tools)
            {
                cbSelectTool.Items.Add(tool);
            }




            //double[] xs = { 01.05, 02.05, 03.05, 04.04, 05.04 };
            //double[] ys = { 100, 500, 0, 160, 0 };
            //fpSchedule.Plot.AddScatter(xs,ys);
            //fpSchedule.Refresh();
        }
    }
}
