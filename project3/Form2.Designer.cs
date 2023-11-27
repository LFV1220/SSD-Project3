namespace project3
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2_volume = new System.Windows.Forms.DataVisualization.Charting.Chart();
            comboBox1_stockPattern = new ComboBox();
            dateTimePicker1_fromDate = new DateTimePicker();
            dateTimePicker2_toDate = new DateTimePicker();
            button1_reset = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
            label1_stockPattern = new Label();
            label2_dateRange = new Label();
            label3_toDate = new Label();
            button1_applyPattern = new Button();
            button2_applyDates = new Button();
            label1_fromDate = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1_stockData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2_volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // chart1_stockData
            // 
            chartArea1.Name = "ChartArea1";
            chart1_stockData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1_stockData.Legends.Add(legend1);
            chart1_stockData.Location = new Point(359, 26);
            chart1_stockData.Name = "chart1_stockData";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            chart1_stockData.Series.Add(series1);
            chart1_stockData.Size = new Size(867, 303);
            chart1_stockData.TabIndex = 0;
            chart1_stockData.Text = "chart1";
            // 
            // chart2_volume
            // 
            chartArea2.Name = "ChartArea1";
            chart2_volume.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2_volume.Legends.Add(legend2);
            chart2_volume.Location = new Point(359, 348);
            chart2_volume.Name = "chart2_volume";
            series2.ChartArea = "ChartArea1";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2_volume.Series.Add(series2);
            chart2_volume.Size = new Size(867, 303);
            chart2_volume.TabIndex = 1;
            chart2_volume.Text = "chart2";
            // 
            // comboBox1_stockPattern
            // 
            comboBox1_stockPattern.FormattingEnabled = true;
            comboBox1_stockPattern.Items.AddRange(new object[] { "Bullish", "Bearish", "Neutral", "Marubozu", "Doji", "Dragonfly Doji", "Gravestone Doji", "Hammer", "Inverted Hammer", "Bullish Engulfing", "Bearish Engulfing", "Bullish Harami", "Bearish Harami", "Peak", "Valley" });
            comboBox1_stockPattern.Location = new Point(107, 72);
            comboBox1_stockPattern.Name = "comboBox1_stockPattern";
            comboBox1_stockPattern.Size = new Size(156, 23);
            comboBox1_stockPattern.TabIndex = 2;
            // 
            // dateTimePicker1_fromDate
            // 
            dateTimePicker1_fromDate.Location = new Point(89, 306);
            dateTimePicker1_fromDate.MaxDate = new DateTime(2023, 12, 31, 0, 0, 0, 0);
            dateTimePicker1_fromDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker1_fromDate.Name = "dateTimePicker1_fromDate";
            dateTimePicker1_fromDate.Size = new Size(200, 23);
            dateTimePicker1_fromDate.TabIndex = 3;
            dateTimePicker1_fromDate.Value = new DateTime(2023, 1, 1, 22, 18, 0, 0);
            // 
            // dateTimePicker2_toDate
            // 
            dateTimePicker2_toDate.Location = new Point(89, 347);
            dateTimePicker2_toDate.MaxDate = new DateTime(2023, 12, 31, 0, 0, 0, 0);
            dateTimePicker2_toDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker2_toDate.Name = "dateTimePicker2_toDate";
            dateTimePicker2_toDate.Size = new Size(200, 23);
            dateTimePicker2_toDate.TabIndex = 4;
            // 
            // button1_reset
            // 
            button1_reset.Location = new Point(78, 561);
            button1_reset.Name = "button1_reset";
            button1_reset.Size = new Size(154, 70);
            button1_reset.TabIndex = 5;
            button1_reset.Text = "Reset";
            button1_reset.UseVisualStyleBackColor = true;
            button1_reset.Click += resetForm;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label1_stockPattern
            // 
            label1_stockPattern.AutoSize = true;
            label1_stockPattern.Location = new Point(24, 75);
            label1_stockPattern.Name = "label1_stockPattern";
            label1_stockPattern.Size = new Size(83, 15);
            label1_stockPattern.TabIndex = 6;
            label1_stockPattern.Text = "Stock Pattern: ";
            // 
            // label2_dateRange
            // 
            label2_dateRange.AutoSize = true;
            label2_dateRange.Location = new Point(23, 272);
            label2_dateRange.Name = "label2_dateRange";
            label2_dateRange.Size = new Size(73, 15);
            label2_dateRange.TabIndex = 7;
            label2_dateRange.Text = "Date Range: ";
            // 
            // label3_toDate
            // 
            label3_toDate.AutoSize = true;
            label3_toDate.Location = new Point(58, 353);
            label3_toDate.Name = "label3_toDate";
            label3_toDate.Size = new Size(25, 15);
            label3_toDate.TabIndex = 8;
            label3_toDate.Text = "To: ";
            // 
            // button1_applyPattern
            // 
            button1_applyPattern.Location = new Point(116, 113);
            button1_applyPattern.Name = "button1_applyPattern";
            button1_applyPattern.Size = new Size(99, 34);
            button1_applyPattern.TabIndex = 9;
            button1_applyPattern.Text = "Apply";
            button1_applyPattern.UseVisualStyleBackColor = true;
            button1_applyPattern.Click += applyPattern;
            // 
            // button2_applyDates
            // 
            button2_applyDates.Location = new Point(127, 395);
            button2_applyDates.Name = "button2_applyDates";
            button2_applyDates.Size = new Size(99, 34);
            button2_applyDates.TabIndex = 10;
            button2_applyDates.Text = "Apply";
            button2_applyDates.UseVisualStyleBackColor = true;
            button2_applyDates.Click += applyDates;
            // 
            // label1_fromDate
            // 
            label1_fromDate.AutoSize = true;
            label1_fromDate.Location = new Point(45, 312);
            label1_fromDate.Name = "label1_fromDate";
            label1_fromDate.Size = new Size(41, 15);
            label1_fromDate.TabIndex = 11;
            label1_fromDate.Text = "From: ";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(label1_fromDate);
            Controls.Add(button2_applyDates);
            Controls.Add(button1_applyPattern);
            Controls.Add(label3_toDate);
            Controls.Add(label2_dateRange);
            Controls.Add(label1_stockPattern);
            Controls.Add(button1_reset);
            Controls.Add(dateTimePicker2_toDate);
            Controls.Add(dateTimePicker1_fromDate);
            Controls.Add(comboBox1_stockPattern);
            Controls.Add(chart2_volume);
            Controls.Add(chart1_stockData);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)chart1_stockData).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2_volume).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1_stockData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2_volume;
        private ComboBox comboBox1_stockPattern;
        private DateTimePicker dateTimePicker1_fromDate;
        private DateTimePicker dateTimePicker2_toDate;
        private Button button1_reset;
        private FileSystemWatcher fileSystemWatcher1;
        private Label label3_toDate;
        private Label label2_dateRange;
        private Label label1_stockPattern;
        private Label label1_fromDate;
        private Button button2_applyDates;
        private Button button1_applyPattern;
    }
}