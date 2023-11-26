using System;
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
            // List<Recognizer> Lr = new List<Recognizer>
            // {
            //      new BullishRecognizer(),
            //      new BearishRecognizer(),
            //      ...
            // }
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

            foreach (var cs in candlesticks)
            {

                // Check if the candlestick is in the date range
                // DateTime csDate = DateTime.Parse(cs.date);
                // if (csDate >= dateTimePicker1_fromDate.Value && csDate <= dateTimePicker2_toDate.Value)
                // {  
                // }
            }

            foreach (var series in chart1_stockData.Series)
            {
                foreach (var point in series.Points)
                {
                    Debug.Write("point: " + point);
                    RectangleAnnotation annotation = new RectangleAnnotation();
                    annotations.Add(annotation);
                }
            }
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
