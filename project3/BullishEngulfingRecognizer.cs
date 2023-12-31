﻿using project3;

public class BullishEngulfingRecognizer : PatternRecognizer
{
    public BullishEngulfingRecognizer() : base(2, "Bullish Engulfing") { }

    // Function to find bullish engulfing stock patterns
    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        for(int i = 0; i < candlesticks.Count - 1; i++) 
        {
            if(IsBullishEngulfing(candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    // Bullish Engulfing pattern consists of two candlesticks
                    startIndex = i,
                    endIndex = i + 1,
                    patternName = "Bullish Engulfing"
                });
            }
        }

        return matches;
    }

    // Helper method to determine if a pair of candlesticks forms a Bullish Engulfing pattern
    private bool IsBullishEngulfing(smartCandlestick first, smartCandlestick second)
    {
        // A Bullish Engulfing pattern occurs when a smaller bearish candle is followed by a larger bullish candle
        bool isFirstCandleBearish = first.close < first.open;
        bool isSecondCandleBullish = second.close > second.open;

        // Check if the second candle completely engulfs the body of the first candle
        bool isEngulfing = second.open < first.close && second.close > first.open;

        return isFirstCandleBearish && isSecondCandleBullish && isEngulfing;
    }
}
