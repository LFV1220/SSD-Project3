using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    public class smartCandlestick : candlestick
    {
        public decimal range { get; set; }
        public decimal bodyRange { get; set; }
        public decimal topPrice { get; set; }
        public decimal bottomPrice { get; set; }
        public decimal upperTail { get; set; }
        public decimal lowerTail { get; set; }

        public bool isBullish { get; set; }
        public bool isBearish { get; set; }
        public bool isNeutral { get; set; }
        public bool isMarubozu { get; set; }
        public bool isDoji { get; set; }
        public bool isDragonFlyDoji { get; set; }
        public bool isGravestoneDoji { get; set; }
        public bool isHammer { get; set; }
        public bool isInvertedHammer { get; set; }

        public smartCandlestick() { }

        public smartCandlestick(string rowOfData) : base(rowOfData)
        {
            range = this.high - this.low;
            topPrice = Math.Max(this.open, this.close);
            bottomPrice = Math.Min(this.open, this.close);
            bodyRange = topPrice - bottomPrice;
            upperTail = this.high - topPrice;
            lowerTail = bottomPrice - this.low;

            isBullish = this.open < this.close;
            isBearish = this.open > this.close;
            isNeutral = this.open == this.close;
            isMarubozu = upperTail == 0 && lowerTail == 0;
            isDoji = isNeutral;
            isDragonFlyDoji = upperTail == 0 && lowerTail > 0;
            isGravestoneDoji = upperTail > 0 && lowerTail == 0;
            isHammer = isBullish && lowerTail > bodyRange / 2;
            isInvertedHammer = isBullish && upperTail > bodyRange / 2;

        }
    }
}
