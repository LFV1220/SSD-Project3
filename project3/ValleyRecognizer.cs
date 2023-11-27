using project3;

public class ValleyRecognizer : PatternRecognizer
{
    public ValleyRecognizer() : base(3, "Valley") { }

    // Function to recognize valley patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list of matches
        var matches = new List<PatternMatch>();

        for(int i = 1; i < candlesticks.Count - 1; i++)
        {
            // Check to see if the 3 candlesticks are a valley
            if(IsValley(candlesticks[i - 1], candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    // Since its a 3 candlestick pattern
                    startIndex = i - 1,
                    endIndex = i + 1,
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
