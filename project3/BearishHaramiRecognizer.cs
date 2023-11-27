using project3;

public class BearishHaramiRecognizer : PatternRecognizer
{
    public BearishHaramiRecognizer() : base(2, "Bearish Harami") { }

    // Function to find bearish harami stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count - 1; i++) 
        {
            if(IsBearishHarami(candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    // Bearish Harami pattern consists of two candlesticks
                    startIndex = i,
                    endIndex = i + 1, 
                    patternName = "Bearish Harami"
                });
            }
        }

        return matches;
    }

    // Helper function to find bearish harami multi candlesticks
    private bool IsBearishHarami(smartCandlestick first, smartCandlestick second)
    {
        // A Bearish Harami pattern occurs when a smaller bearish candle follows a larger bullish candle
        bool isFirstCandleBullish = first.close > first.open;
        bool isSecondCandleBearish = second.close < second.open;

        // Check if the second candle is fully contained within the body of the first candle
        bool isContained = second.open < first.close && second.close > first.open;

        // Size check - ensuring the first candle is significantly larger than the second
        bool isFirstCandleLarger = (first.close - first.open) > (second.close - second.open);

        return isFirstCandleBullish && isSecondCandleBearish && isContained && isFirstCandleLarger;
    }
}

