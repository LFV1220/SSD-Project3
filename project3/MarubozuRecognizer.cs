using project3;

public class MarubozuRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public MarubozuRecognizer() : base(1, "Marubozu") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(IsMarubozu(candlesticks[i]))
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

    private bool IsMarubozu(smartCandlestick candlestick)
    {
        // Implement logic to check if the candlestick matches the Marubozu pattern
        var body = Math.Abs(candlestick.close - candlestick.open);
        var upperShadow = candlestick.high - Math.Max(candlestick.open, candlestick.close);
        var lowerShadow = Math.Min(candlestick.open, candlestick.close) - candlestick.low;
        var totalLength = candlestick.high - candlestick.low;

        // These thresholds are examples; adjust based on your specific criteria for a Marubozu
        bool isFullBody = body >= (totalLength * 0.95m);
        bool isNoUpperShadow = upperShadow <= (totalLength * 0.05m);
        bool isNoLowerShadow = lowerShadow <= (totalLength * 0.05m);

        return isFullBody && isNoUpperShadow && isNoLowerShadow;
    }
}
