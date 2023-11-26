using project3;

public class ValleyRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public ValleyRecognizer() : base(3, "Valley") { }

    public override IEnumerable<PatternMatch> IdentifyPatterns(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Logic to identify Valley patterns
        for(int i = 1; i < candlesticks.Count - 1; i++) // Start from 1 and end 1 early to check trio of candlesticks
        {
            if(IsValley(candlesticks[i - 1], candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i - 1,
                    endIndex = i + 1, // Valley pattern consists of three candlesticks
                    patternName = "Valley"
                });
            }
        }

        return matches;
    }

    // Helper method to determine if a trio of candlesticks forms a Valley
    private bool IsValley(smartCandlestick left, smartCandlestick middle, smartCandlestick right)
    {
        return middle.low < left.low && middle.low < right.low;
    }
}
