using project3;

public class DragonflyDojiRecognizer : PatternRecognizer
{
    private readonly decimal threshold;

    public DragonflyDojiRecognizer(decimal threshold = 0.01m) : base(1, "Dragonfly Doji")
    {
        this.threshold = threshold;
    }

    // Function to find dragonfly doji stock patterns 
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list of dragonfly doji indexes
        var matches = new List<PatternMatch>();

        for (int i = 0; i < candlesticks.Count; i++)
        {
            // If dragonfly doji stock pattern exists add it to new list
            if (candlesticks[i].isDragonFlyDoji)
            {
                matches.Add(new PatternMatch
                {
                    // single candlestick pattern
                    startIndex = i,
                    endIndex = i,
                    patternName = "Dragonfly Doji"
                });
            }
        }

        return matches;
    }
}

