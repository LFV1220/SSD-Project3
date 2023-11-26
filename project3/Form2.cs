﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace project3
{
    public partial class Form2 : Form
    {
        private BindingList<smartCandlestick> candlesticks { get; set; }
        private String tickerName { get; set; }
        public AnnotationCollection annotations { get; set; }

        public Form2(String tickerName, BindingList<smartCandlestick> candlesticks)
        {
            InitializeComponent();

            // Get/set variables
            this.candlesticks = candlesticks;
            this.tickerName = tickerName;

            // Displays the data when this form is called
            displayData(getCandlesticksInDateRange(candlesticks));
        }

        // populate stock pattern combobox
        private void populateStockPatterns()
        {
            List<PatternRecognizer> Lr = new List<PatternRecognizer>
            {
                new BullishRecognizer(),
                new BearishRecognizer(),
                new DojiRecognizer(),
                new EngulfingPatternRecognizer(),
                new HammerRecognizer(),
                new MarubozuRecognizer(),
                new PeakAndValleyRecognizer()
            };
        }

        private BindingList<smartCandlestick> getCandlesticksInDateRange(BindingList<smartCandlestick> candlesticks)
        {
            BindingList<smartCandlestick> candlesticksInDateRange = new BindingList<smartCandlestick>();

            // Iterate over all the candlesticks and only add the ones in the date range to the new candlesticks list
            foreach (var cs in this.candlesticks)
            {
                DateTime csDate = DateTime.Parse(cs.date);
                if (csDate < dateTimePicker2_toDate.Value && csDate > dateTimePicker1_fromDate.Value)
                {
                    candlesticksInDateRange.Add(cs);
                }
            }

            return candlesticksInDateRange;
        }

        // TODO: FIX ANNOTATIONS AND CHANGE STOCK PATTERN CHECKING 
        // Function to show the specific stock data pattern, selected by the user
        private void applyPattern(object sender, EventArgs e)
        {
            // Get the index of the selected index from the comboBox for stock patterns
            int stockPattern = comboBox1_stockPattern.SelectedIndex;

            // Check for a valid stock pattern index from combobox 
            if (stockPattern == -1 || stockPattern == 0)
            {
                // Error, no ticker selected
                MessageBox.Show("Please select a stock pattern.", "No Stock Pattern Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create an annotation collection to store the annotations
            annotations = chart1_stockData.Annotations;

            // Remove any existing annotations (to refresh the view)
            annotations.Clear();

            // Iterate over candlesticks and add annotations for the selected pattern
            for (int i = 0; i < candlesticks.Count; i++)
            {
                var cs = candlesticks[i];

                // Check if the candlestick matches the selected pattern
                bool isPatternMatch = false;

                // Example: Check for Bullish pattern
                if (stockPattern == 1 && cs.isBullish)
                {
                    isPatternMatch = true;
                }
                // Example: Check for Bearish pattern
                else if (stockPattern == 2 && cs.isBearish)
                {
                    isPatternMatch = true;
                }

                if (isPatternMatch)
                {
                    annotations.Add(newAnnotation(cs, i));
                }
            }

            // Refresh the chart to display the annotations
            chart1_stockData.Invalidate();

        }

        private RectangleAnnotation newAnnotation(smartCandlestick cs, int i)
        {
            // Define the width and height of the annotation
            double annotationWidth = 10; // Adjust as needed
            double annotationHeight = 10; // Adjust as needed

            // Calculate the X-coordinate based on the index and chart properties
            double chartWidth = chart1_stockData.Width;
            double candlestickCount = candlesticks.Count;
            double annotationX = (i + 0.5) * (chartWidth / candlestickCount) - (annotationWidth / 2);

            // Calculate the Y-coordinate based on your logic or data
            double annotationY = (double)cs.high;

            // Add an annotation for this candlestick
            RectangleAnnotation annotation = new RectangleAnnotation();
            annotation.AxisX = chart1_stockData.ChartAreas[0].AxisX;
            annotation.AxisY = chart1_stockData.ChartAreas[0].AxisY;
            annotation.X = annotationX;
            annotation.Y = annotationY;
            annotation.Width = annotationWidth;
            annotation.Height = annotationHeight;
            annotation.Text = "Bullish Pattern"; // Replace with the appropriate pattern text

            return annotation;
        }

        // Function to apply the date range to the stock charts
        private void applyDates(object sender, EventArgs e)
        {
            // Check for valid date range
            if (dateTimePicker2_toDate.Value < dateTimePicker1_fromDate.Value)
            {
                // Error, invalid date range
                MessageBox.Show("Please make sure the \"from\" date is before the \"to\" date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            displayData(getCandlesticksInDateRange(candlesticks));
        }

        // Function to reset what is on the form/page
        private void resetForm(object sender, EventArgs e)
        {
            // Initialize the annotations to the stockData chart
            annotations = chart1_stockData.Annotations;
            annotations.Clear();

            displayData(getCandlesticksInDateRange(candlesticks));
        }

        // Function to display the stock data as a stock price chart and volume chart
        private void displayData(BindingList<smartCandlestick> candlesticks)
        {
            // Assuming "date" is the property representing X-axis values
            chart1_stockData.Series[0].XValueMember = "date";

            // Assuming "open", "high", "low", and "close" are the properties representing Y-axis values
            chart1_stockData.Series[0].YValueMembers = "open,high,low,close";
            // Assuming "date" is a DateTime property
            chart1_stockData.DataSource = candlesticks.ToList();

            // Set the color for "Up" days (positive change)
            chart1_stockData.Series[0]["PriceUpColor"] = "Green";
            // Set the color for "Down" days (negative change) <-- FIX THIS
            chart1_stockData.Series[0]["PriceDownColor"] = "Red";

            // testing candlestick color 
            foreach (var cs in candlesticks)
            {
                // Determine if the price is up or down
                bool isUp = cs.close > cs.open;

                // Get the data series for the candlestick chart
                var series = chart1_stockData.Series[0];

                // Set the color for "Up" days (positive change)
                if (isUp)
                {
                    series.Points.AddXY(cs.date, cs.low, cs.high, cs.open, cs.close);
                    series.Points[series.Points.Count - 1].Color = Color.Green;
                }
                // Set the color for "Down" days (negative change)
                else
                {
                    series.Points.AddXY(cs.date, cs.low, cs.high, cs.open, cs.close);
                    series.Points[series.Points.Count - 1].Color = Color.Red;
                }
            }

            // TODO: STILL NEED TO ADD CHART TITLES

            //chart1_stockData.DataSource = candlesticks;
            chart1_stockData.DataBind();


            // volume chart stuff
            chart2_volume.Series[0].XValueMember = "Date";
            chart2_volume.Series[0].YValueMembers = "Volume";
            chart2_volume.DataSource = candlesticks.ToList();
            chart2_volume.DataBind();

        }

    }
}
