using project3;

public class NeutralRecognizer : PatternRecognizer
{
    // Threshold for how close the open and close should be 
    private readonly decimal threshold = 0.01m;

    public NeutralRecognizer() : base(1, "Neutral") { }

    // Function to find neutral stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list of matches 
        var matches = new List<PatternMatch>();

        for (int i = 0; i < candlesticks.Count; i++)
        {
            // Single candlestick pattern
            if (candlesticks[i].isNeutral)
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i,
                    endIndex = i,
                    patternName = "Neutral"
                });
            }
        }

        return matches;
    }
}