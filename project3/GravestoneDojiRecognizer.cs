using project3;

public class GravestoneDojiRecognizer : PatternRecognizer
{
    private readonly decimal threshold; // Threshold for determining the smallness of the candle body

    public GravestoneDojiRecognizer(decimal threshold = 0.01m) : base(1, "Gravestone Doji")
    {
        this.threshold = threshold;
    }

    public override IEnumerable<PatternMatch> IdentifyPatterns(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Logic to identify Gravestone Doji patterns
        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(IsGravestoneDoji(candlesticks[i]))
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

    // Helper method to determine if a single candlestick is a Gravestone Doji
    private bool IsGravestoneDoji(smartCandlestick candlestick)
    {
        // Check if the candlestick represents a Gravestone Doji
        var bodySize = Math.Abs(candlestick.close - candlestick.open);
        bool isSmallBody = bodySize <= (threshold * Math.Abs(candlestick.high - candlestick.low));
        bool isLowEqualOpenClose = candlestick.low == candlestick.open && candlestick.low == candlestick.close;
        bool isUpperShadowLong = (candlestick.high - candlestick.open) > bodySize;

        return isSmallBody && isLowEqualOpenClose && isUpperShadowLong;
    }
}

