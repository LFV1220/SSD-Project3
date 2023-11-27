using project3;

public class GravestoneDojiRecognizer : PatternRecognizer
{
    private readonly decimal threshold; // Threshold for determining the smallness of the candle body

    public GravestoneDojiRecognizer(decimal threshold = 0.01m) : base(1, "Gravestone Doji")
    {
        this.threshold = threshold;
    }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Logic to identify Gravestone Doji patterns
        for(int i = 0; i < candlesticks.Count; i++)
        {
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

