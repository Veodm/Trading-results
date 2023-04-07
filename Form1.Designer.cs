namespace Trading_results
{
    partial class formMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.calFrom = new System.Windows.Forms.MonthCalendar();
            this.lbFrom = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.calTo = new System.Windows.Forms.MonthCalendar();
            this.btCreat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calFrom
            // 
            resources.ApplyResources(this.calFrom, "calFrom");
            this.calFrom.MaxSelectionCount = 1;
            this.calFrom.MinDate = new System.DateTime(2005, 12, 7, 0, 0, 0, 0);
            this.calFrom.Name = "calFrom";
            this.calFrom.ShowToday = false;
            this.calFrom.ShowTodayCircle = false;
            this.calFrom.TodayDate = new System.DateTime(2023, 4, 7, 0, 0, 0, 0);
            this.calFrom.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calFrom_DateChanged);
            // 
            // lbFrom
            // 
            resources.ApplyResources(this.lbFrom, "lbFrom");
            this.lbFrom.Name = "lbFrom";
            // 
            // lbTo
            // 
            resources.ApplyResources(this.lbTo, "lbTo");
            this.lbTo.Name = "lbTo";
            // 
            // calTo
            // 
            resources.ApplyResources(this.calTo, "calTo");
            this.calTo.MaxDate = new System.DateTime(2023, 5, 7, 0, 0, 0, 0);
            this.calTo.MaxSelectionCount = 1;
            this.calTo.MinDate = new System.DateTime(2005, 12, 7, 0, 0, 0, 0);
            this.calTo.Name = "calTo";
            this.calTo.ShowToday = false;
            this.calTo.ShowTodayCircle = false;
            this.calTo.TodayDate = new System.DateTime(2023, 4, 7, 0, 0, 0, 0);
            this.calTo.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calFrom_DateChanged);
            // 
            // btCreat
            // 
            resources.ApplyResources(this.btCreat, "btCreat");
            this.btCreat.Name = "btCreat";
            this.btCreat.UseVisualStyleBackColor = true;
            this.btCreat.Click += new System.EventHandler(this.btCreat_Click);
            // 
            // formMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btCreat);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.calTo);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.calFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar calFrom;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.MonthCalendar calTo;
        private System.Windows.Forms.Button btCreat;
    }
}

