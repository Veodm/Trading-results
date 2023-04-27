namespace Trading_results
{
    partial class FormSchedule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fpSchedule = new ScottPlot.FormsPlot();
            this.cbSelectTool = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // fpSchedule
            // 
            this.fpSchedule.BackColor = System.Drawing.Color.White;
            this.fpSchedule.Location = new System.Drawing.Point(38, 12);
            this.fpSchedule.Name = "fpSchedule";
            this.fpSchedule.Size = new System.Drawing.Size(476, 226);
            this.fpSchedule.TabIndex = 0;
            // 
            // cbSelectTool
            // 
            this.cbSelectTool.FormattingEnabled = true;
            this.cbSelectTool.Location = new System.Drawing.Point(38, 262);
            this.cbSelectTool.Name = "cbSelectTool";
            this.cbSelectTool.Size = new System.Drawing.Size(476, 21);
            this.cbSelectTool.TabIndex = 1;
            // 
            // FormSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 396);
            this.Controls.Add(this.cbSelectTool);
            this.Controls.Add(this.fpSchedule);
            this.Name = "FormSchedule";
            this.Text = "FormSchedule";
            this.ResumeLayout(false);

        }

        #endregion

        private ScottPlot.FormsPlot fpSchedule;
        private System.Windows.Forms.ComboBox cbSelectTool;
    }
}