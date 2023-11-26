using project3;

public class InvertedHammerRecognizer : PatternRecognizer
{
    private readonly decimal threshold; 

    public InvertedHammerRecognizer(decimal threshold = 0.01m) : base(1, "Inverted Hammer")
    {
        this.threshold = threshold;
    }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Logic to identify Inverted Hammer patterns
        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(IsInvertedHammer(candlesticks[i]))
            {
                matches.Add(new PatternMatch
                {
                    // Inverted Hammer pattern consists of a single candlestick
                    startIndex = i,
                    endIndex = i, 
                    patternName = "Inverted Hammer"
                });
            }
        }

        return matches;
    }

    private bool IsInvertedHammer(smartCandlestick candlestick)
    {
        // Check if the candlestick represents an Inverted Hammer
        var bodySize = Math.Abs(candlestick.close - candlestick.open);
        var upperShadow = candlestick.high - Math.Max(candlestick.close, candlestick.open);
        var lowerShadow = Math.Min(candlestick.close, candlestick.open) - candlestick.low;
        bool isSmallBody = bodySize <= (threshold * Math.Abs(candlestick.high - candlestick.low));
        bool isUpperShadowLong = upperShadow > bodySize * 2; // Upper shadow significantly longer than the body
        bool isLowerShadowSmall = lowerShadow < bodySize;

        return isSmallBody && isUpperShadowLong && isLowerShadowSmall;
    }
}
