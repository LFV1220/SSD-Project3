using project3;

public class GravestoneDojiRecognizer : PatternRecognizer
{
    private readonly decimal threshold; 

    public GravestoneDojiRecognizer(decimal threshold = 0.01m) : base(1, "Gravestone Doji")
    {
        this.threshold = threshold;
    }

    // Function to find gravestone dojis 
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list for gravestones found
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            // If single candlestick is found
            if (candlesticks[i].isGravestoneDoji)
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i,
                    endIndex = i,
                    patternName = "Gravestone Doji"
                });
            }
        }

        return matches;
    }

}

