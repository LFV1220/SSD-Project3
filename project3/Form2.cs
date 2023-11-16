using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            displayData(candlesticks);
        }

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

            // Calculate a size to help with the annotation sizing/positioning
            double avgInterval = (DateTime.Parse(candlesticks[1].date) - DateTime.Parse(candlesticks[0].date)).TotalDays / 2;

            foreach (var cs in candlesticks)
            {
                // Check if the candlestick is in the date range
                DateTime csDate = DateTime.Parse(cs.date);
                if (csDate >= dateTimePicker1_fromDate.Value && csDate <= dateTimePicker2_toDate.Value)
                {
                    switch (stockPattern)
                    {
                        // Stock pattern: Bullish 
                        case 1:
                            if (cs.isBullish)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                        // Stock pattern: Bearish 
                        case 2:
                            if (cs.isBearish)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                        // Stock pattern: Neutral 
                        case 3:
                            if (cs.isNeutral)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                        // Stock pattern: Marubozu 
                        case 4:
                            if (cs.isMarubozu)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                        // Stock pattern: Doji 
                        case 5:
                            if (cs.isDoji)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                        // Stock pattern: Dragonfly Doji 
                        case 6:
                            if (cs.isDragonFlyDoji)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                        // Stock pattern: Gravestone Doji 
                        case 7:
                            if (cs.isGravestoneDoji)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                        // Stock pattern: Hammer 
                        case 8:
                            if (cs.isHammer)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                        // Stock pattern: Inverted Hammer 
                        case 9:
                            if (cs.isInvertedHammer)
                            {
                                RectangleAnnotation annotation = newAnnotation(cs, csDate, avgInterval);
                                annotations.Add(annotation);
                            }
                            break;
                    }
                }
            }

        }

        // Helper function to create the annotations to show stock patterns
        private RectangleAnnotation newAnnotation(smartCandlestick cs, DateTime csDate, double avgInterval)
        {
            // Creates an annotation and other properties for sizing/positioning
            RectangleAnnotation annotation = new RectangleAnnotation();
            annotation.AxisX = chart1_stockData.ChartAreas[0].AxisX;
            annotation.AxisY = chart1_stockData.ChartAreas[0].AxisY;
            annotation.X = csDate.ToOADate() - avgInterval;
            annotation.Y = (double)cs.high;
            annotation.Width = 2.0;
            annotation.Height = (double)cs.range;
            annotation.BackColor = Color.FromArgb(128, Color.Yellow);

            return annotation;
        }

        // Function to apply the date range to the stock charts
        private void applyDates(object sender, EventArgs e)
        {
            BindingList<smartCandlestick> candlesticksInRange = new BindingList<smartCandlestick>();

            // Check for valid date range
            if (dateTimePicker2_toDate.Value < dateTimePicker1_fromDate.Value)
            {
                // Error, invalid date range
                MessageBox.Show("Please make sure the \"from\" date is before the \"to\" date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Iterate over all the candlesticks and only add the ones in the date range to new candlesticks list
            foreach (var cs in this.candlesticks)
            {
                DateTime csDate = DateTime.Parse(cs.date);
                if (csDate < dateTimePicker2_toDate.Value && csDate > dateTimePicker1_fromDate.Value)
                {
                    candlesticksInRange.Add(cs);
                }
            }

            // Call displayData function with new candlesticks list
            displayData(candlesticksInRange);
        }

        // Function to reset what is on the form/page
        private void resetForm(object sender, EventArgs e)
        {
            // Initialize the annotations to the stockData chart
            annotations = chart1_stockData.Annotations;
            annotations.Clear();

            // Call displayData function with global candlesticks list 
            displayData(this.candlesticks);
        }

        // Function to display the stock data as a stock price chart and volume chart
        private void displayData(BindingList<smartCandlestick> candlesticks)
        {
            chart1_stockData.DataSource = candlesticks;
        }

    }
}
