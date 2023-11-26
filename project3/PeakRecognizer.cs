using project3;

public class PeakRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public PeakRecognizer() : base(3, "Peak") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Start from 1 and end 1 early to check trio of candlesticks
        for(int i = 1; i < candlesticks.Count - 1; i++) 
        {
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
