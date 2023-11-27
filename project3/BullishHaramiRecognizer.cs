using project3;

public class BullishHaramiRecognizer : PatternRecognizer
{
    public BullishHaramiRecognizer() : base(2, "Bullish Harami") { }

    // Function to find bullish harami stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count - 1; i++) 
        {
            // Find multi candlestick pattern
            if(IsBullishHarami(candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    startIndex = i,
                    endIndex = i + 1, 
                    patternName = "Bullish Harami"
                });
            }
        }

        return matches;
    }

    private bool IsBullishHarami(smartCandlestick first, smartCandlestick second)
    {
        // A Bullish Harami pattern occurs when a smaller bearish candle is followed by a larger bullish candle
        bool isFirstCandleBearish = first.close < first.open;
        bool isSecondCandleBullish = second.close > second.open;

        // Check if the second candle is fully contained within the body of the first candle
        bool isContained = second.open > first.close && second.close < first.open;

        // Size check - ensuring the first candle is significantly larger than the second
        bool isFirstCandleLarger = (first.open - first.close) > (second.close - second.open);

        return isFirstCandleBearish && isSecondCandleBullish && isContained && isFirstCandleLarger;
    }
}
