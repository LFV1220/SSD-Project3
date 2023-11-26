using project3;

public class BullishHaramiRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public BullishHaramiRecognizer() : base(2, "Bullish Harami") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // -1 because we need a pair of candlesticks
        for(int i = 0; i < candlesticks.Count - 1; i++) 
        {
            if(IsBullishHarami(candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    // Bullish Harami pattern consists of two candlesticks
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
