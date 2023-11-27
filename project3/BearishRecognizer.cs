using project3;

public class BearishRecognizer : PatternRecognizer
{
    public BearishRecognizer() : base(1, "Bearish") { }

    // Function to find bearish stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            // Single candlestick pattern
            if(candlesticks[i].isBearish)
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i,
                    endIndex = i,
                    patternName = "Bearish"
                });
            }
        }

        return matches;
    }
}
