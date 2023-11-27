using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;

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

        private void applyPattern(object sender, EventArgs e)
        {
            // List of pattern recognizer classes
            List<PatternRecognizer> Lr = new List<PatternRecognizer>
            {
                new BullishRecognizer(),
                new BearishRecognizer(),
                new NeutralRecognizer(),
                new MarubozuRecognizer(),
                new DojiRecognizer(),
                new DragonflyDojiRecognizer(),
                new GravestoneDojiRecognizer(),
                new HammerRecognizer(),
                new InvertedHammerRecognizer(),
                new BullishEngulfingRecognizer(),
                new BearishEngulfingRecognizer(),
                new BullishHaramiRecognizer(),
                new BearishHaramiRecognizer(),
                new PeakRecognizer(),
                new ValleyRecognizer(),
            };

            int stockPattern = comboBox1_stockPattern.SelectedIndex;

            // Check for valid selection
            if (stockPattern == -1)
            {
                MessageBox.Show("Please select a stock pattern.", "No Stock Pattern Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Initialize and clear annotations
            annotations = chart1_stockData.Annotations;
            annotations.Clear();

            // Use the selected pattern recognizer directly from the list
            PatternRecognizer recognizerInstance = Lr[stockPattern];

            if (recognizerInstance != null)
            {
                // Create a list of recognizer instances
                IEnumerable<PatternMatch> patternMatches = recognizerInstance.recognizePattern(getCandlesticksInDateRange(candlesticks).ToList());

                // Iterate through the pattern instances
                foreach (var patternMatch in patternMatches)
                {
                    // Look through multi-candlestick patterns
                    for (int i = patternMatch.startIndex; i <= patternMatch.endIndex; i++)
                    {
                        if (i >= 0 && i < candlesticks.Count)
                        {
                            DataPoint dp = chart1_stockData.Series["Series1"].Points[i];
                            annotations.Add(newAnnotation(candlesticks[i], i, comboBox1_stockPattern.SelectedItem.ToString(), dp));
                        }
                    }
                }
            }

            // Refresh the stock data chart
            chart1_stockData.Invalidate();
        }

        // Function to create a rectangle annotation 
        private RectangleAnnotation newAnnotation(smartCandlestick cs, int i, string pattern, DataPoint dp)
        {
            // Add an annotation for this candlestick
            RectangleAnnotation annotation = new RectangleAnnotation();
            annotation.AxisX = chart1_stockData.ChartAreas[0].AxisX;
            annotation.AxisY = chart1_stockData.ChartAreas[0].AxisY;
            annotation.Width = 3;
            annotation.Height = (double)cs.range;
            //annotation.Text = pattern;
            annotation.BackColor = Color.FromArgb(128, Color.Yellow);
            annotation.AnchorDataPoint = dp;

            return annotation;
        }

        // Function to make a new list of candlesticks in a specific date range
        private BindingList<smartCandlestick> getCandlesticksInDateRange(BindingList<smartCandlestick> candlesticks)
        {
            BindingList<smartCandlestick> candlesticksInDateRange = new BindingList<smartCandlestick>();

            // Iterate over all the candlesticks and only add the ones in the date range to the new candlesticks list
            foreach (var cs in this.candlesticks)
            {
                // Checks if the candlestick is within the date range and adds it to then new list if so
                DateTime csDate = DateTime.Parse(cs.date);
                if (csDate < dateTimePicker2_toDate.Value && csDate > dateTimePicker1_fromDate.Value)
                {
                    candlesticksInDateRange.Add(cs);
                }
            }

            return candlesticksInDateRange;
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

            // Initialize and clear annotations to the stockData chart
            annotations = chart1_stockData.Annotations;
            annotations.Clear();

            // Display the data back 
            displayData(getCandlesticksInDateRange(candlesticks));
        }

        // Function to reset what is on the form/page
        private void resetForm(object sender, EventArgs e)
        {
            // Initialize and clear annotations to the stockData chart
            annotations = chart1_stockData.Annotations;
            annotations.Clear();

            // Display the data back 
            displayData(getCandlesticksInDateRange(candlesticks));
        }

        // Function to display the stock data as a stock price chart and volume chart
        private void displayData(BindingList<smartCandlestick> candlesticks)
        {
            // Stock chart information
            chart1_stockData.Series[0].XValueMember = "date";
            chart1_stockData.Series[0].YValueMembers = "open,high,low,close";

            chart1_stockData.Titles.Clear();
            chart1_stockData.Titles.Add(tickerName);

            chart1_stockData.ChartAreas[0].AxisX.Title = "Date";
            chart1_stockData.ChartAreas[0].AxisY.Title = "Price";

            chart1_stockData.DataSource = candlesticks.ToList();
            chart1_stockData.DataBind();

            // Candlestick Color 
            for (int i = 0; i < chart1_stockData.Series["Series1"].Points.Count; i++)
            {
                DataPoint dataPoint = chart1_stockData.Series["Series1"].Points[i];

                double open = dataPoint.YValues[0];
                double close = dataPoint.YValues[3];

                // Candlestick color depending on price 
                if (open < close)
                {
                    dataPoint.Color = Color.Green;
                }
                else
                {
                    dataPoint.Color = Color.Red;
                }
            }

            // Volume chart information 
            chart2_volume.Series[0].XValueMember = "Date";
            chart2_volume.Series[0].YValueMembers = "Volume";

            chart2_volume.ChartAreas[0].AxisY.Title = "Volume Amount";
            chart2_volume.ChartAreas[0].AxisX.Title = "Date";
            chart2_volume.Titles.Clear();
            chart2_volume.Titles.Add(tickerName + " Volume");

            chart2_volume.DataSource = candlesticks.ToList();
            chart2_volume.DataBind();
        }

    }
}