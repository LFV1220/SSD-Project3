using project3;

public class HammerRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public HammerRecognizer() : base(1, "Hammer") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(IsHammer(candlesticks[i]))
            {
                matches.Add(new PatternMatch
                {
                    // Hammer is a single-candlestick pattern
                    startIndex = i,
                    endIndex = i, 
                    patternName = "Hammer"
                });
            }
        }

        return matches;
    }

    private bool IsHammer(smartCandlestick candlestick)
    {
        // Implement logic to check if the candlestick matches the Hammer pattern
        var body = Math.Abs(candlestick.close - candlestick.open);
        var lowerShadow = candlestick.open - candlestick.low;
        var upperShadow = candlestick.high - candlestick.close;
        var totalLength = candlestick.high - candlestick.low;

        // These thresholds are examples; adjust based on your specific criteria for a Hammer
        bool isSmallBody = body <= (totalLength * 0.2m);
        bool isLongLowerShadow = lowerShadow >= (totalLength * 0.5m);
        bool isSmallUpperShadow = upperShadow <= (body * 0.5m);

        return isSmallBody && isLongLowerShadow && isSmallUpperShadow;
    }
}
