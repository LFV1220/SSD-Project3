using project3;

public class BullishRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public BullishRecognizer() : base(1, "Bullish") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(IsBullish(candlesticks[i]))
            {
                matches.Add(new PatternMatch
                {
                    StartIndex = i,
                    EndIndex = i,
                    PatternName = "Bullish"
                });
            }
        }

        return matches;
    }

    private bool IsBullish(smartCandlestick candlestick)
    {
        // A bullish candlestick is identified when the closing price is higher than the opening price
        return candlestick.Close > candlestick.Open;
    }
}
