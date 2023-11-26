using project3;

public class PeakAndValleyRecognizer : PatternRecognizer
{
    // Nothing needs to go inside this constructor. Only necessary to initialize the PatternRecognizer base class through constructor chaining
    public PeakAndValleyRecognizer() : base(3, "Peak and Valley") { }

    public override IEnumerable<PatternMatch> recognizePattern(List<smartCandlestick> candlesticks)
    {
        var matches = new List<PatternMatch>();

        // Start from 1 and end 1 early for a trio of candlesticks
        for(int i = 1; i < candlesticks.Count - 1; i++) 
        {
            if(IsPeak(candlesticks[i - 1], candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    StartIndex = i - 1,
                    EndIndex = i + 1,
                    PatternName = "Peak"
                });
            }
            else if(IsValley(candlesticks[i - 1], candlesticks[i], candlesticks[i + 1]))
            {
                matches.Add(new PatternMatch
                {
                    StartIndex = i - 1,
                    EndIndex = i + 1,
                    PatternName = "Valley"
                });
            }
        }

        return matches;
    }

    private bool IsPeak(smartCandlestick left, smartCandlestick middle, smartCandlestick right)
    {
        return middle.High > left.High && middle.High > right.High;
    }

    private bool IsValley(smartCandlestick left, smartCandlestick middle, smartCandlestick right)
    {
        return middle.Low < left.Low && middle.Low < right.Low;
    }
}
