using project3;

public class DojiRecognizer : PatternRecognizer
{
    public DojiRecognizer() : base(1, "Doji") { }

    // Function to find doji stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list of doji patterns indexes
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            // if there are doji patterns, add it 
            if(candlesticks[i].isDoji)
            {
                matches.Add(new PatternMatch
                {
                    // Doji is a single-candlestick pattern, so start and end are the same
                    endIndex = i, 
                    startIndex = i,
                    patternName = "Doji"
                });
            }
        }

        return matches;
    }
}