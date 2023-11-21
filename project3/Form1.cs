using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace project3
{
    public partial class Form1 : Form
    {
        private string timePeriod = "Day";

        public Form1()
        {
            InitializeComponent();
            loadTickers();
        }

        // Function to load unique ticker symbols into the combobox
        private void loadTickers()
        {
            // Get all .csv files from the Stock Data Folder
            string[] csvFiles = Directory.GetFiles(getFolderPath(), "*.csv");

            // To store unique ticker names
            HashSet<string> uniqueTickers = new HashSet<string>();

            // Iterate through the files to get ticker names
            foreach (string csvFile in csvFiles)
            {
                // Get the list of files without the extension or past the '-'
                string[] fileNameParts = Path.GetFileNameWithoutExtension(csvFile).Split('-');

                // Checking for only the correct file types where there is atleast a dash
                if (fileNameParts.Length >= 1)
                {
                    // Get the tickerName and add it to the list of unique tickers (for no duplicates)
                    string tickerName = fileNameParts[0];
                    uniqueTickers.Add(tickerName);
                }
            }

            // Clear the comboBox for any unexpected items 
            comboBox1_ticker.Items.Clear();
            // Add the unique ticker and display it in the comboBox
            comboBox1_ticker.Items.AddRange(uniqueTickers.ToArray());
        }

        // Function to set the time period
        private void setTimePeriod(object sender, EventArgs e)
        {
            // Sets the timePeriod based on which radio button is selected
            if (radioButton1_daily.Checked)
            {
                timePeriod = "Day";
            }
            else if (radioButton2_weekly.Checked)
            {
                timePeriod = "Week";
            }
            else if (radioButton3_monthly.Checked)
            {
                timePeriod = "Month";
            }
        }

        // Function to get the relative path of the Stock Data folder
        public string getFolderPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            // Navigates through the many parent directories to get to the Stock Data folder
            string parentDirectory = Directory.GetParent(currentDirectory).FullName;
            string parentDirectory1 = Directory.GetParent(parentDirectory).FullName;
            string parentDirectory2 = Directory.GetParent(parentDirectory1).FullName;
            string parentDirectory3 = Directory.GetParent(parentDirectory2).FullName;
            string parentDirectory4 = Directory.GetParent(parentDirectory3).FullName;
            string stockDataPath = Path.Combine(parentDirectory4, "Stock Data");

            return stockDataPath;
        }

        // Function to view ticker information when button is clicked  
        private void viewTicker(object sender, EventArgs e)
        {
            // Check if a ticker is selected
            if (comboBox1_ticker.SelectedIndex == -1)
            {
                // Error, no ticker selected
                MessageBox.Show("Please select a ticker symbol.", "No Ticker Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Look for file matching ticker symbol and date period and open it
            string fileName = comboBox1_ticker.SelectedItem.ToString() + "-" + timePeriod + ".csv";
            string stockDataPath = getFolderPath();
            string filePath = Path.Combine(stockDataPath, fileName);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File not found: {filePath}");
                MessageBox.Show("File not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calls readData function to make candlestick objects and push them onto a list
            BindingList<smartCandlestick> candlesticks = readData(filePath);

            // Change to the next form
            String tickerName = comboBox1_ticker.SelectedItem.ToString() + "-" + timePeriod;
            //Change to the next form that displays the stock data
            newStockForm(candlesticks, tickerName);
        }

        // Function to use and open a CSV file for stock data
        private void openFile(object sender, EventArgs e)
        {
            // OpenFileDialog popup
            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                // Iterate through all the files
                foreach (String filePath in openFileDialog1.FileNames)
                {
                    // Calls readData function to make candlestick objects and push them onto a list 
                    String tickerName = Path.GetFileNameWithoutExtension(filePath);
                    BindingList<smartCandlestick> candlesticks = readData(filePath);

                    // Change to the next form that displays the stock data
                    newStockForm(candlesticks, tickerName);
                }
            }
            else
            {
                // Error opening selected file
                MessageBox.Show("Unable to open selected file. Please try again.", "Unable to open selected file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        // Function to read data from .csv file
        private BindingList<smartCandlestick> readData(string filePath)
        {
            BindingList<smartCandlestick> candlesticks = new BindingList<smartCandlestick>();

            // Reference string involves the file header to ignore when reading the data
            string referenceString = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

            // Opens the file and iterates through the csv contents
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    // Gets the line of data
                    string line = sr.ReadLine();

                    // Looks for the reference string, to ignore it
                    if (line != referenceString)
                    {
                        // Pass the data to create a candlestick object
                        smartCandlestick cs = new smartCandlestick(line);
                        candlesticks.Add(cs);
                    }
                }
            }

            // To get the candlesticks in ascending order
            List<smartCandlestick> reversedList = candlesticks.ToList();
            reversedList.Reverse();
            BindingList<smartCandlestick> ascCandlesticks = new BindingList<smartCandlestick>(reversedList);

            return ascCandlesticks;
        }

        // Function to load the stock information in another form
        private void newStockForm(BindingList<smartCandlestick> candlesticks, String tickerName)
        {
            // Create a new form using the tickerName and the candlesticks list
            Form2 form2 = new Form2(tickerName, candlesticks);

            // Name the form and display it
            form2.Text = tickerName;
            form2.Show();
        }

    }
}