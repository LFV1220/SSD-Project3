using project3;

public class BearishRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public BearishRecognizer() : base(1, "Bearish") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(IsBearish(candlesticks[i]))
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

    private bool IsBearish(smartCandlestick candlestick)
    {
        return candlestick.close < candlestick.open;
    }
}
