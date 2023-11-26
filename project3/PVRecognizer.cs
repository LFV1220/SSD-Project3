using project3;

public class PeakAndValleyRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public PeakAndValleyRecognizer() : base(3, "Peak and Valley") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Start from 1 and end 1 early for a trio of candlesticks
        for(int i = 1; i < candlesticks.Count - 1; i++) 
        {
            if(IsPeak(candlesticks[i - 1], candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i - 1,
                    endIndex = i + 1,
                    patternName = "Peak"
                });
            }
            else if(IsValley(candlesticks[i - 1], candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i - 1,
                    endIndex = i + 1,
                    patternName = "Valley"
                });
            }
        }

        return matches;
    }

    private bool IsPeak(smartCandlestick left, smartCandlestick middle, smartCandlestick right)
    {
        return middle.high > left.high && middle.high > right.high;
    }

    private bool IsValley(smartCandlestick left, smartCandlestick middle, smartCandlestick right)
    {
        return middle.low < left.low && middle.low < right.low;
    }
}
