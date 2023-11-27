using project3;

public class InvertedHammerRecognizer : PatternRecognizer
{
    private readonly decimal threshold; 

    public InvertedHammerRecognizer(decimal threshold = 0.01m) : base(1, "Inverted Hammer")
    {
        this.threshold = threshold;
    }

    // Function to find inverted hammer stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list for matches
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(candlesticks[i].isInvertedHammer)
            {
                matches.Add(new PatternMatch
                {
                    // Single candlestick pattern
                    startIndex = i,
                    endIndex = i, 
                    patternName = "Inverted Hammer"
                });
            }
        }

        return matches;
    }
}
