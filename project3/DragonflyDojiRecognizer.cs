using project3;

public class DragonflyDojiRecognizer : PatternRecognizer
{
    private readonly decimal threshold; // Threshold for determining the smallness of the candle body

    public DragonflyDojiRecognizer(decimal threshold = 0.01m) : base(1, "Dragonfly Doji")
    {
        this.threshold = threshold;
    }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count; i++)
        {
            if(IsDragonflyDoji(candlesticks[i]))
            {
                matches.Add(new PatternMatch
                {
                    // Dragonfly Doji pattern consists of a single candlestick
                    startIndex = i,
                    endIndex = i, 
                    patternName = "Dragonfly Doji"
                });
            }
        }

        return matches;
    }

    private bool IsDragonflyDoji(smartCandlestick candlestick)
    {
        // Check if the candlestick represents a Dragonfly Doji
        var bodySize = Math.Abs(candlestick.close - candlestick.open);
        bool isSmallBody = bodySize <= (threshold * Math.Abs(candlestick.high - candlestick.low));
        bool isHighEqualOpenClose = candlestick.high == candlestick.open && candlestick.high == candlestick.close;
        bool isLowerShadowLong = (candlestick.open - candlestick.low) > bodySize;

        return isSmallBody && isHighEqualOpenClose && isLowerShadowLong;
    }
}

