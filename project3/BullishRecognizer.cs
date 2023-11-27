using project3;

public class BullishRecognizer : PatternRecognizer
{
    public BullishRecognizer() : base(1, "Bullish") { }

    // Function to find bullish stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list of matches
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            // Single candlestick patterns
            if(candlesticks[i].isBullish)
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i,
                    endIndex = i,
                    patternName = "Bullish"
                });
            }
        }

        return matches;
    }
}
