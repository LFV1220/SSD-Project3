using project3;

public class BearishEngulfingRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public BearishEngulfingRecognizer() : base(2, "Bearish Engulfing") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Logic to identify Bearish Engulfing patterns
        for(int i = 0; i < candlesticks.Count - 1; i++) // -1 because we need a pair of candlesticks
        {
            if(IsBearishEngulfing(candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    // Bearish Engulfing pattern consists of two candlesticks
                    startIndex = i,
                    endIndex = i + 1, 
                    patternName = "Bearish Engulfing"
                });
            }
        }

        return matches;
    }

    // Helper method to determine if a pair of candlesticks forms a Bearish Engulfing pattern
    private bool IsBearishEngulfing(smartCandlestick first, smartCandlestick second)
    {
        // A Bearish Engulfing pattern occurs when a smaller bullish candle is followed by a larger bearish candle
        bool isFirstCandleBullish = first.close > first.open;
        bool isSecondCandleBearish = second.close < second.open;

        // Check if the second candle completely engulfs the body of the first candle
        bool isEngulfing = second.open > first.close && second.close < first.open;

        return isFirstCandleBullish && isSecondCandleBearish && isEngulfing;
    }
}
