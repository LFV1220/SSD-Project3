using project3;

public class HammerRecognizer : PatternRecognizer
{
    public HammerRecognizer() : base(1, "Hammer") { }

    // Function to find hammer stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list for matches
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(candlesticks[i].isHammer)
            {
                matches.Add(new PatternMatch
                {
                    // Single candlestick pattern
                    startIndex = i,
                    endIndex = i, 
                    patternName = "Hammer"
                });
            }
        }

        return matches;
    }
}
