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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chart1_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2_volume = new System.Windows.Forms.DataVisualization.Charting.Chart();
            comboBox1_stockPattern = new ComboBox();
            dateTimePicker1_fromDate = new DateTimePicker();
            dateTimePicker2_toDate = new DateTimePicker();
            button1_reset = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
            label1_stockPattern = new Label();
            label2_dateRange = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1_stockData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2_volume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // chart1_stockData
            // 
            chartArea3.Name = "ChartArea1";
            chart1_stockData.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart1_stockData.Legends.Add(legend3);
            chart1_stockData.Location = new Point(24, 24);
            chart1_stockData.Name = "chart1_stockData";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 4;
            chart1_stockData.Series.Add(series3);
            chart1_stockData.Size = new Size(867, 303);
            chart1_stockData.TabIndex = 0;
            chart1_stockData.Text = "chart1";
            // 
            // chart2_volume
            // 
            chartArea4.Name = "ChartArea1";
            chart2_volume.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart2_volume.Legends.Add(legend4);
            chart2_volume.Location = new Point(24, 346);
            chart2_volume.Name = "chart2_volume";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chart2_volume.Series.Add(series4);
            chart2_volume.Size = new Size(867, 303);
            chart2_volume.TabIndex = 1;
            chart2_volume.Text = "chart2";
            // 
            // comboBox1_stockPattern
            // 
            comboBox1_stockPattern.FormattingEnabled = true;
            comboBox1_stockPattern.Items.AddRange(new object[] { "", "Bullish", "Bearish", "Neutral", "Marubozu", "Doji", "Dragonfly Doji", "Gravestone Doji", "Hammer", "Inverted Hammer" });
            comboBox1_stockPattern.Location = new Point(1029, 77);
            comboBox1_stockPattern.Name = "comboBox1_stockPattern";
            comboBox1_stockPattern.Size = new Size(184, 23);
            comboBox1_stockPattern.TabIndex = 2;
            // 
            // dateTimePicker1_fromDate
            // 
            dateTimePicker1_fromDate.Location = new Point(1000, 300);
            dateTimePicker1_fromDate.MaxDate = new DateTime(2023, 12, 31, 0, 0, 0, 0);
            dateTimePicker1_fromDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker1_fromDate.Name = "dateTimePicker1_fromDate";
            dateTimePicker1_fromDate.Size = new Size(200, 23);
            dateTimePicker1_fromDate.TabIndex = 3;
            dateTimePicker1_fromDate.Value = new DateTime(2023, 1, 1, 22, 18, 0, 0);
            // 
            // dateTimePicker2_toDate
            // 
            dateTimePicker2_toDate.Location = new Point(1000, 358);
            dateTimePicker2_toDate.MaxDate = new DateTime(2023, 12, 31, 0, 0, 0, 0);
            dateTimePicker2_toDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker2_toDate.Name = "dateTimePicker2_toDate";
            dateTimePicker2_toDate.Size = new Size(200, 23);
            dateTimePicker2_toDate.TabIndex = 4;
            // 
            // button1_reset
            // 
            button1_reset.Location = new Point(1000, 566);
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
            label1_stockPattern.Location = new Point(940, 80);
            label1_stockPattern.Name = "label1_stockPattern";
            label1_stockPattern.Size = new Size(83, 15);
            label1_stockPattern.TabIndex = 6;
            label1_stockPattern.Text = "Stock Pattern: ";
            // 
            // label2_dateRange
            // 
            label2_dateRange.AutoSize = true;
            label2_dateRange.Location = new Point(946, 270);
            label2_dateRange.Name = "label2_dateRange";
            label2_dateRange.Size = new Size(73, 15);
            label2_dateRange.TabIndex = 7;
            label2_dateRange.Text = "Date Range: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1083, 332);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 8;
            label3.Text = "to";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(label3);
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
        private Label label3;
        private Label label2_dateRange;
        private Label label1_stockPattern;
    }
}