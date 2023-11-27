using project3;

public class BearishEngulfingRecognizer : PatternRecognizer
{
    public BearishEngulfingRecognizer() : base(2, "Bearish Engulfing") { }

    // Function to find bearish engulfing stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        // New list of matches
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count - 1; i++)
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
