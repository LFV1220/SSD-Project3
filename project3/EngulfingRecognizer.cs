using project3;

public class EngulfingPatternRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public EngulfingPatternRecognizer() : base(2, "Engulfing") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // -1 because we need a pair of candlesticks
        for(int i = 0; i < candlesticks.Count - 1; i++) 
        {
            if(IsEngulfing(candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    // Engulfing pattern consists of two candlesticks
                    startIndex = i,
                    endIndex = i + 1, 
                    patternName = "Engulfing"
                });
            }
        }

        return matches;
    }

    private bool IsEngulfing(smartCandlestick first, smartCandlestick second)
    {
        // Implement logic to check if the pair of candlesticks matches the Engulfing pattern
        // An engulfing pattern is identified when the second candle's body completely engulfs the first one's body

        // Check if the first candle is bearish and the second is bullish for a Bullish Engulfing
        bool isBullishEngulfing = first.open > first.close && second.open < second.close &&
                                  second.open < first.close && second.close > first.open;

        // Check if the first candle is bullish and the second is bearish for a Bearish Engulfing
        bool isBearishEngulfing = first.open < first.close && second.open > second.close &&
                                  second.open > first.close && second.close < first.open;

        return isBullishEngulfing || isBearishEngulfing;
    }
}
