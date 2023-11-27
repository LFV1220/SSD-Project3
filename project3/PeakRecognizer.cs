using project3;

public class PeakRecognizer : PatternRecognizer
{
    public PeakRecognizer() : base(3, "Peak") { }

    // Function to find peak stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list for matches of stock pattern
        var matches = new List<PatternMatch>();

        for(int i = 1; i < candlesticks.Count - 1; i++) 
        {
            // Check for peaks 
            if(IsPeak(candlesticks[i - 1], candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    // Peak pattern consists of three candlesticks
                    startIndex = i - 1,
                    endIndex = i + 1, 
                    patternName = "Peak"
                });
            }
        }

        return matches;
    }

    // Helper method to determine if a trio of candlesticks forms a Peak
    private bool IsPeak(smartCandlestick left, smartCandlestick middle, smartCandlestick right)
    {
        return middle.high > left.high && middle.high > right.high;
    }
}
