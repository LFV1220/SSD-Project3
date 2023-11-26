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
                    StartIndex = i,
                    EndIndex = i, 
                    PatternName = "Marubozu"
                });
            }
        }

        return matches;
    }

    private bool IsMarubozu(smartCandlestick candlestick)
    {
        // Implement logic to check if the candlestick matches the Marubozu pattern
        var body = Math.Abs(candlestick.Close - candlestick.Open);
        var upperShadow = candlestick.High - Math.Max(candlestick.Open, candlestick.Close);
        var lowerShadow = Math.Min(candlestick.Open, candlestick.Close) - candlestick.Low;
        var totalLength = candlestick.High - candlestick.Low;

        // These thresholds are examples; adjust based on your specific criteria for a Marubozu
        bool isFullBody = body >= (totalLength * 0.95m);
        bool isNoUpperShadow = upperShadow <= (totalLength * 0.05m);
        bool isNoLowerShadow = lowerShadow <= (totalLength * 0.05m);

        return isFullBody && isNoUpperShadow && isNoLowerShadow;
    }
}
