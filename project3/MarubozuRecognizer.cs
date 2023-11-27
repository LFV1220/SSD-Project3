using project3;

public class MarubozuRecognizer : PatternRecognizer
{
    public MarubozuRecognizer() : base(1, "Marubozu") { }

    // Function to find marubozu stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(candlesticks[i].isMarubozu)
            {
                matches.Add(new PatternMatch
                {
                    // Marubozu is a single-candlestick pattern
                    startIndex = i,
                    endIndex = i, 
                    patternName = "Marubozu"
                });
            }
        }

        return matches;
    }
}
