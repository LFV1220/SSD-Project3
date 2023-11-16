using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    public class candlestick
    {
        public Decimal open { get; set; }
        public Decimal high { get; set; }
        public Decimal low { get; set; }
        public Decimal close { get; set; }
        public long volume { get; set; }
        public string date { get; set; }

        public candlestick() { }

        // Given a row of data, this function creates an object of type candlestick 
        public candlestick(String rowOfData)
        {
            char[] separators = new char[] { ',', ' ', '"', '-' };
            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Decimal temp;
            long temp1;
            bool success;
            success = Decimal.TryParse(subs[5], out temp);
            open = temp;
            success = Decimal.TryParse(subs[6], out temp);
            high = temp;
            success = Decimal.TryParse(subs[7], out temp);
            low = temp;
            success = Decimal.TryParse(subs[8], out temp);
            close = temp;
            success = long.TryParse(subs[9], out temp1);
            volume = temp1;
            date = subs[2] + " " + subs[3] + " " + subs[4];

            // test
            //Debug.Write("open: " + open + " ");
            //Debug.Write("high: " + high + " ");
            //Debug.Write("low: " + low + " ");
            //Debug.Write("close: " + close + " ");
            //Debug.Write("volume: " + volume + " ");
            //Debug.Write("date: " + date + " ");
            //Debug.WriteLine("");

        }
    }
}
