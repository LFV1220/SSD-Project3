namespace project3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1_ticker = new ComboBox();
            radioButton1_daily = new RadioButton();
            radioButton2_weekly = new RadioButton();
            radioButton3_monthly = new RadioButton();
            button1_viewTicker = new Button();
            button2_openFile = new Button();
            openFileDialog1 = new OpenFileDialog();
            label1_ticker = new Label();
            SuspendLayout();
            // 
            // comboBox1_ticker
            // 
            comboBox1_ticker.FormattingEnabled = true;
            comboBox1_ticker.Location = new Point(145, 88);
            comboBox1_ticker.Name = "comboBox1_ticker";
            comboBox1_ticker.Size = new Size(194, 23);
            comboBox1_ticker.TabIndex = 0;
            // 
            // radioButton1_daily
            // 
            radioButton1_daily.AutoSize = true;
            radioButton1_daily.Checked = true;
            radioButton1_daily.Location = new Point(145, 126);
            radioButton1_daily.Name = "radioButton1_daily";
            radioButton1_daily.Size = new Size(51, 19);
            radioButton1_daily.TabIndex = 1;
            radioButton1_daily.TabStop = true;
            radioButton1_daily.Text = "Daily";
            radioButton1_daily.UseVisualStyleBackColor = true;
            radioButton1_daily.CheckedChanged += setTimePeriod;
            // 
            // radioButton2_weekly
            // 
            radioButton2_weekly.AutoSize = true;
            radioButton2_weekly.Location = new Point(210, 126);
            radioButton2_weekly.Name = "radioButton2_weekly";
            radioButton2_weekly.Size = new Size(63, 19);
            radioButton2_weekly.TabIndex = 2;
            radioButton2_weekly.Text = "Weekly";
            radioButton2_weekly.UseVisualStyleBackColor = true;
            radioButton2_weekly.CheckedChanged += setTimePeriod;
            // 
            // radioButton3_monthly
            // 
            radioButton3_monthly.AutoSize = true;
            radioButton3_monthly.Location = new Point(279, 126);
            radioButton3_monthly.Name = "radioButton3_monthly";
            radioButton3_monthly.Size = new Size(70, 19);
            radioButton3_monthly.TabIndex = 3;
            radioButton3_monthly.Text = "Monthly";
            radioButton3_monthly.UseVisualStyleBackColor = true;
            radioButton3_monthly.CheckedChanged += setTimePeriod;
            // 
            // button1_viewTicker
            // 
            button1_viewTicker.Location = new Point(381, 79);
            button1_viewTicker.Name = "button1_viewTicker";
            button1_viewTicker.Size = new Size(144, 66);
            button1_viewTicker.TabIndex = 4;
            button1_viewTicker.Text = "View Ticker";
            button1_viewTicker.UseVisualStyleBackColor = true;
            button1_viewTicker.Click += viewTicker;
            // 
            // button2_openFile
            // 
            button2_openFile.Location = new Point(554, 79);
            button2_openFile.Name = "button2_openFile";
            button2_openFile.Size = new Size(122, 66);
            button2_openFile.TabIndex = 5;
            button2_openFile.Text = "Open File (.csv)";
            button2_openFile.UseVisualStyleBackColor = true;
            button2_openFile.Click += openFile;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "All Stock Files|*.csv|Daily Stocks|*-Day.csv|Weekly Stocks|*-Week.csv|Monthly Stocks|*-Month.csv";
            openFileDialog1.Multiselect = true;
            // 
            // label1_ticker
            // 
            label1_ticker.AutoSize = true;
            label1_ticker.Location = new Point(145, 70);
            label1_ticker.Name = "label1_ticker";
            label1_ticker.Size = new Size(44, 15);
            label1_ticker.TabIndex = 6;
            label1_ticker.Text = "Ticker: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 235);
            Controls.Add(label1_ticker);
            Controls.Add(button2_openFile);
            Controls.Add(button1_viewTicker);
            Controls.Add(radioButton3_monthly);
            Controls.Add(radioButton2_weekly);
            Controls.Add(radioButton1_daily);
            Controls.Add(comboBox1_ticker);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1_ticker;
        private RadioButton radioButton1_daily;
        private RadioButton radioButton2_weekly;
        private RadioButton radioButton3_monthly;
        private Button button1_viewTicker;
        private Button button2_openFile;
        private OpenFileDialog openFileDialog1;
        private Label label1_ticker;
    }
}