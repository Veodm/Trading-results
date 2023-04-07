using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Trading_results
{
    public partial class formMain : Form
    {
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

        }
    }
}
